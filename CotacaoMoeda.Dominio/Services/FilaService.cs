using System;
using CotacaoMoeda.Domain.Interfaces;
using CotacaoMoeda.Dominio.Entidades;
using System.Collections.Generic;

namespace CotacaoMoeda.Domain.Services
{
    public class FilaService : IFilaService
    {
        private readonly IFilaRepository _filaRepository;

        public FilaService(IFilaRepository filaRepository)
        {
            _filaRepository = filaRepository;
        }
        public void AddItemFila(IEnumerable<ItemFila> itens)
        {
            _filaRepository.AddItemFila(itens);
        }

        public Fila GetFila()
        {
            return _filaRepository.GetFila();
        }

        public void RemoveItemDaFila(Guid id)
        {
            _filaRepository.RemoveItemDaFila(id);
        }
    }
}
