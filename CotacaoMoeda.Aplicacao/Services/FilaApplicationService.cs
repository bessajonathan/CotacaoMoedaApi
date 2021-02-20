using System;
using System.Collections.Generic;
using System.Linq;
using CotacaoMoeda.Aplicacao.Fila.ViewModels;
using CotacaoMoeda.Aplicacao.Interfaces;
using CotacaoMoeda.Application.Exceptions;
using CotacaoMoeda.Domain.Interfaces;
using CotacaoMoeda.Dominio.Entidades;

namespace CotacaoMoeda.Application.Services
{
    public class FilaApplicationService : IFilaApplicationService
    {
        private readonly IFilaService _filaService;

        public FilaApplicationService(IFilaService filaService)
        {
            _filaService = filaService;
        }
        public void AddItemFila(IEnumerable<ItemFilaViewModel> itens)
        {
            var itensFila = new List<ItemFila>();

            foreach (var item in itens)
            {
                var splitDataInicio = item.Data_Inicio.Split("-");
                var splitDataFim = item.Data_Inicio.Split("-");

                var datainicio = new DateTime(int.Parse(splitDataInicio[0]), int.Parse(splitDataInicio[1]),
                    int.Parse(splitDataInicio[2]));

                var datafim = new DateTime(int.Parse(splitDataInicio[0]), int.Parse(splitDataInicio[1]),
                    int.Parse(splitDataInicio[2]));

                itensFila.Add(new ItemFila(item.Moeda, datainicio, datafim));
            }
            _filaService.AddItemFila(itensFila);
        }

        public FilaViewModel GetFila()
        {

            var fila = _filaService.GetFila();

            var itemFila = fila.Itens.Select(x => new ItemFilaViewModel
            {
                Id = x.Id,
                Moeda = x.Moeda,
                Data_Inicio = x.Data_Inicio.ToString("yyyy/MM/dd"),
                Data_Fim = x.Data_Fim.ToString("yyyy/MM/dd"),
            });

            return new FilaViewModel
            {
                Itens = itemFila
            };
        }

        public ItemFilaViewModel GetItemFila()
        {
            var fila = _filaService.GetFila();

            var item =  fila.Itens.LastOrDefault();

            if (item is null)
                throw new NotFoundException("Item não encontrado ou inexistente.");

            _filaService.RemoveItemDaFila(item.Id);

            return new ItemFilaViewModel
            {
                Id = item.Id,
                Moeda = item.Moeda,
                Data_Inicio = item.Data_Inicio.ToString("yyyy/MM/dd"),
                Data_Fim = item.Data_Fim.ToString("yyyy/MM/dd"),
            };
        }
    }
}
