using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce2021a.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // http://localhost:5000/carrinho/comprar/4?quantidade=2
        [HttpGet]
        public IActionResult Comprar(int id, [FromQuery]int quantidade) {
            // using(var data = new ProdutoData()) {
            //     Produto produto = data.Read(id);
            // }
            // id = 4
            // quantidade = 2
            return View();
        }
    }
}
