using System;
using System.Collections.Generic;
using CotacaoMoeda.Dominio.Entidades;

namespace CotacaoMoeda.Domain.Interfaces
{
    public interface IFilaService
    {
        void AddItemFila(IEnumerable<ItemFila> itens);
        Fila GetFila();
        void RemoveItemDaFila(Guid id);
    }
}
