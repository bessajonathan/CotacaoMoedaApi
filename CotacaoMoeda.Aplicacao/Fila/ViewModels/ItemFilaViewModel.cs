using System;
using CotacaoMoeda.Dominio.Enum;

namespace CotacaoMoeda.Aplicacao.Fila.ViewModels
{
    public class ItemFilaViewModel
    {
        public Guid Id { get; set; }
        public ETipoMoeda Moeda { get; set; }
        public string Data_Inicio { get; set; }
        public string Data_Fim { get; set; }
    }
}
