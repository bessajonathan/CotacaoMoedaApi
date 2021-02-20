using CotacaoMoeda.Aplicacao.Fila.ViewModels;
using MediatR;

namespace CotacaoMoeda.Application.Fila.Queries
{
    public class GetItemFilaQuery : IRequest<ItemFilaViewModel>
    {
    }
}
