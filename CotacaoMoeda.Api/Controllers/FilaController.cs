using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Net;
using System.Threading.Tasks;
using CotacaoMoeda.Aplicacao.Fila.Comandos;
using CotacaoMoeda.Aplicacao.Fila.ViewModels;
using CotacaoMoeda.Application.Fila.Queries;
using MediatR;

namespace CotacaoMoeda.Api.Controllers
{
    [Route("v1/filas")]
    public class FilaController : ControllerBase
    {
        /// <summary>
        /// Adiciona item na fila
        /// </summary>
        [HttpPost]
        [OpenApiTag("Fila")]
        [ProducesResponseType(typeof(FilaViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddItemFila([FromServices] IMediator mediator,[FromBody] AdicionarItensCommand command)
        {
            if (command is null)
                BadRequest();

            return Created(string.Empty,await mediator.Send(command));
        }

        /// <summary>
        /// Retornar o último item da fila
        /// </summary>
        [HttpGet]
        [OpenApiTag("Fila")]
        [ProducesResponseType(typeof(FilaViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetItemFila([FromServices] IMediator mediator)
        {

            return Ok(await mediator.Send(new GetItemFilaQuery()));
        }
    }
}
