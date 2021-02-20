using System.Collections.Generic;

namespace CotacaoMoeda.Dominio.Entidades
{
    /// <summary>
    /// Entidade que representa uma fila
    /// </summary>
    public class Fila
    {
        public Fila()
        {
            Itens = new List<ItemFila>();
        }
        public ICollection<ItemFila> Itens { get; set; }
    }
}
