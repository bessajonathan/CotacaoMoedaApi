using CotacaoMoeda.Dominio.Enum;
using System;

namespace CotacaoMoeda.Dominio.Entidades
{
    /// <summary>
    /// Entidade que representa um item da fila
    /// </summary>
    public class ItemFila
    {
        public ItemFila(ETipoMoeda moeda,DateTime data_inicio,DateTime data_fim)
        {
            Id = Guid.NewGuid();
            Moeda = moeda;
            Data_Inicio = data_inicio;
            Data_Fim = data_fim;
        }
        public Guid Id { get; set; }
        public ETipoMoeda Moeda { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Fim { get; set; }
    }
}
