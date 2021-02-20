using CotacaoMoeda.Aplicacao.Fila.ViewModels;
using MediatR;
using System.Collections.Generic;
using CotacaoMoeda.Dominio.Enum;

namespace CotacaoMoeda.Aplicacao.Fila.Comandos
{
    public class AdicionarItensCommand: IRequest<FilaViewModel>
    {
        public IEnumerable<ItemCommand> Itens { get; set; }
    }

    public class ItemCommand
    {
        public ETipoMoeda Moeda { get; set; }
        public string Data_Inicio { get; set; }
        public string Data_Fim { get; set; }
    }
}
