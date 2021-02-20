using CotacaoMoeda.Aplicacao.Fila.ViewModels;
using System.Collections.Generic;

namespace CotacaoMoeda.Aplicacao.Interfaces
{
    public interface IFilaApplicationService
    {
        void AddItemFila(IEnumerable<ItemFilaViewModel> item);
        FilaViewModel GetFila();
        ItemFilaViewModel GetItemFila();
        ItemFilaViewModel GetItemFilaDataFormatada();
    }
}
