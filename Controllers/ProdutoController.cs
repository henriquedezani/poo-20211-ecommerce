using Ecommerce2021a.Data;
using Ecommerce2021a.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using inteiro = System.Int32; // apelido.

namespace Ecommerce2021a.Controllers
{
        //Um controlador é apenas uma classe que deriva (herda) da classe base
        //System.Web.Mvc.Controller.  Como um controlador herda dessa classe
        //base, um controlador herda vários métodos úteis
        public class ProdutoController : Controller // controller
        {
            //O IAction tipo de retorno é apropriado quando vários  ActionResult
            //tipos de retorno são possíveis em uma ação
            //Os tipo AcrionResult representam vários códigos de status HTTP
            public IActionResult Index() // action
            {
                //Criando um objeto data da classe ProdutoData
                using(ProdutoData data = new ProdutoData()) // abrindo a conexão
                { 
                    List<Produto> lista = data.Read();
                    return View(lista);
                } // Dispose();
            }

            public IActionResult Create()
            {
                //ViewBag tem como objetibo trasnportar pequenas quantidades de dados
                //entre views ou de controllers para views
                using (var data = new CategoriaData())
                    ViewBag.Categorias = data.Read();

                return View();
            }

            // A ideia geral é a seguinte: seu serviço vai prover uma url base
            // e os verbos HTTP vão indicar qual ação está sendo requisitada pelo
            // consumidor do serviço. Por exemplo, considerando a URL
            // www.dominio.com/rest/notas/, se enviarmos para ela uma requisição
            // HTTP utilizando o verbo GET, provavelmente obteremos como resultado
            // uma listagem de registros(notas, nesse caso). Por outro lado,
            // se utilizarmos o verbo POST, provalmente estaremos tentando adicionar
            // um novo registro, cujos dados serão enviados no corpo da requisição.

            [HttpPost]
            public IActionResult Create(Produto produto)
            {
                //O ModeState é uma propriedade da classe Controller e pode ser
                //acessada a partir das classes que herdam de System.Web.Mvc.Controller.
                //Ele representa uma coleção de pares nome/valor que são submetidos
                //ao servidor durante o POST e também contém uma coleção de mensagens
                //de erros para cada calor submetido
                if (!ModelState.IsValid)
                {
                    return View(produto);
                }

                using (var data = new ProdutoData())
                    data.Create(produto);
                return RedirectToAction("Index");
            }

            public IActionResult Delete(int id)
            {
                using (var data = new ProdutoData())
                    data.Delete(id);

                return RedirectToAction("Index");
            }

            // http://localhost:5001/produto/update/5
            [HttpGet]
            public IActionResult Update(int id)
            {
                using (var data = new CategoriaData())
                {
                    var lista = data.Read();
                    var item = new SelectList(lista, "IdCategoria", "Nome");
                    ViewBag.Categorias = item;
                }

                using (var data = new ProdutoData())
                    return View(data.Read(id));
            }

            [HttpPost]
            public IActionResult Update(int id, Produto produto)
            {
                produto.IdProduto = id;

                if (!ModelState.IsValid)
                {
                    return View(produto);
                }

                using (var data = new ProdutoData())
                    data.Update(produto);

                return RedirectToAction("Index");
            }
        }
    }
