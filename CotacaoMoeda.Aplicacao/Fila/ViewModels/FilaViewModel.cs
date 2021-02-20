using System.Collections.Generic;

namespace CotacaoMoeda.Aplicacao.Fila.ViewModels
{
    public class FilaViewModel
    {
        public FilaViewModel()
        {
            Itens = new List<ItemFilaViewModel>();
        }
        public IEnumerable<ItemFilaViewModel> Itens { get; set; }
    }
}
