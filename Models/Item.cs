using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce2021a.Models
{
    public class Item
    {
        //propriedades & atributos

        public int IdPedido { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public Produto Produto { get; set; } //is - a

        public decimal ValorTotal
        {
            get
            {
                return Quantidade * Valor;
            }
        }
    }
}
