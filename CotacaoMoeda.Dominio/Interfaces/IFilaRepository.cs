using System;
using CotacaoMoeda.Dominio.Entidades;
using System.Collections.Generic;

namespace CotacaoMoeda.Domain.Interfaces
{
    public interface IFilaRepository
    {
        void AddItemFila(IEnumerable<ItemFila> itens);
        Fila GetFila();
        void RemoveItemDaFila(Guid id);
    }
}
