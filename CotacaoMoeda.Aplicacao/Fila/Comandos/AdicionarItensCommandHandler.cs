using CotacaoMoeda.Aplicacao.Fila.ViewModels;
using CotacaoMoeda.Aplicacao.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CotacaoMoeda.Aplicacao.Fila.Comandos
{
    public class AdicionarItensCommandHandler : IRequestHandler<AdicionarItensCommand, FilaViewModel>
    {
        private readonly IFilaApplicationService _filaApplicationService;

        public AdicionarItensCommandHandler(IFilaApplicationService filaApplicationService)
        {
            _filaApplicationService = filaApplicationService;
        }
        public async Task<FilaViewModel> Handle(AdicionarItensCommand request, CancellationToken cancellationToken)
        {

            _filaApplicationService.AddItemFila(request.Itens.Select(x => new ItemFilaViewModel { Moeda = x.Moeda, Data_Inicio = x.Data_Inicio, Data_Fim = x.Data_Fim }));

            return _filaApplicationService.GetFila();
        }
    }
}
