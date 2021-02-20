using System;
using CotacaoMoeda.Dominio.Enum;

namespace CotacaoMoeda.Application.Fila.Jobs
{
    public class DadosMoeda
    {
        public ETipoMoeda Moeda { get; set; }
        public DateTime Data_Ref { get; set; }
    }
}
