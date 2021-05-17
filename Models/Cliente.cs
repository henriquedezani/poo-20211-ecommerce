using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce2021a.Models
{
    public class Cliente
    {

        //propriedades & atributos:
        public int? IdCliente { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage ="Campo nome obrigatório")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo e-mail obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo senha obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Senha { get; set; }


    }
}
