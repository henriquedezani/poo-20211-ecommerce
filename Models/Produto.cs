using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce2021a.Models
{
    public class Produto
    {
        //propriedades & atributos

        public int? IdProduto { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo descrição obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Campo valor obrigatório")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        #region Dados da Categoria
        public int IdCategoria { get; set; } // Foreign Key
        public string Categoria { get; set; } 
        #endregion
    }
}
