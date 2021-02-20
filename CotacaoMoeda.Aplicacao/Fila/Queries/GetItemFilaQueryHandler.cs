using CotacaoMoeda.Aplicacao.Fila.ViewModels;
using CotacaoMoeda.Aplicacao.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CotacaoMoeda.Application.Fila.Queries
{
    public class GetItemFilaQueryHandler : IRequestHandler<GetItemFilaQuery,ItemFilaViewModel>
    {
        private readonly IFilaApplicationService _service;

        public GetItemFilaQueryHandler(IFilaApplicationService service)
        {
            _service = service;
        }
        public async Task<ItemFilaViewModel> Handle(GetItemFilaQuery request, CancellationToken cancellationToken)
        {
            return _service.GetItemFila();
        }
    }
}
