using CotacaoMoeda.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CotacaoMoeda.Api.Filtros
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            var resposta = new ExceptionResponse();

            resposta.Titulo = "Error";
            resposta.StatusCode = (int)HttpStatusCode.InternalServerError;
            resposta.Resposta = context.Exception.ToString();

            if (context.Exception is NotFoundException)
            {
                resposta.Titulo = "Alerta";
                resposta.StatusCode = (int)HttpStatusCode.NotFound;
                resposta.Resposta = context.Exception.Message;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            if (context.Exception is ValidationException)
            {
                var errorValues = ((ValidationException)context.Exception).Failures.Values;

                var mensagem = "";

                foreach (var error in errorValues)
                    mensagem += "- " + error[0];

                resposta.Titulo = "Alerta";
                resposta.StatusCode = (int)HttpStatusCode.BadRequest;
                resposta.Resposta = $"Erro de validação: {mensagem}";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            context.Result = new JsonResult(
                new
                {
                    resposta.Titulo,
                    resposta.StatusCode,
                    resposta.Resposta
                });
        }
    }
}
