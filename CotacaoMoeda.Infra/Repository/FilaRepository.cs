using System;
using System.Collections.Generic;
using System.Linq;
using CotacaoMoeda.Domain.Interfaces;
using CotacaoMoeda.Dominio.Entidades;

namespace CotacaoMoeda.Infra.Repository
{
    public class FilaRepository : IFilaRepository
    {
        private Fila Fila { get; set; }

        public void AddItemFila(IEnumerable<ItemFila> itens)
        {
            Fila = new Fila();

            foreach (var item in itens)
            {
                Fila.Itens.Add(item);
            }
        }

        public Fila GetFila()
        {
            return Fila;
        }

        public void RemoveItemDaFila(Guid id)
        {
            var item = Fila.Itens.FirstOrDefault(x => x.Id == id);
            Fila.Itens.Remove(item);
        }
    }
}
