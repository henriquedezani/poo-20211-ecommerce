using Ecommerce2021a.Data;
using Ecommerce2021a.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce2021a.Controllers
{
    public class ClienteController : Controller
    {
        //private static List<ClienteL clientes = new List<Cliente>();
        public IActionResult Index(Cliente novoCliente)
        {
            return View(novoCliente);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection cliente)
        {
            string nome = cliente["nome"];
            string email = cliente["email"];
            string senha = cliente["senha"];

            if(nome.Length < 6)
            {
                ViewBag.Mensagem = "Nome deve conter 6 ou mais carecteres";
            }
            if(!email.Contains("@"))
            {
                ViewBag.Mensagem = "Email inválido";
                return View();
            }
            if(senha.Length < 6)
            {
                ViewBag.Mensagem = "Senha deve conter 6 caracteres ou mais";
                return View();
            }

            var novoCliente = new Cliente();
            novoCliente.Nome = cliente["nome"];
            novoCliente.Email = cliente["email"];
            novoCliente.Senha = cliente["senha"];

            using (var data = new ClienteData())
                data.Create(novoCliente);

            return RedirectToAction("Index", novoCliente);
        }

        [HttpPost]
        public IActionResult Read(IFormCollection cliente)
        {
            string nome = cliente["nome"];
            string email = cliente["email"];
            string senha = cliente["senha"];

            if(!email.Equals(" "))
            {
                var cli = new Cliente();

                cli.Nome = cliente["nome"];
                cli.Email = cliente["email"];
                cli.Senha = cliente["senha"];

                Cliente c = new Cliente();

                using (var data = new ClienteData())
                    c = data.Read(cli.Email);

                if(c.Senha == cli.Senha)
                {
                    ViewBag.Mensagem = "Olá";
                    return View("Index", c);
                }
                else
                {
                    ViewBag.Mensagem = "Usuário ou senha inválidos";
                    return View("Index", null);
                }

            }

            return View("Create");
        }

        public IActionResult Delete(int id)
        {
            using (var data = new ClienteData())
                data.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new ClienteData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Cliente cliente)
        {
            cliente.IdCliente = id;

            if(!ModelState.IsValid)
                return View(cliente);

            using (var data = new ClienteData())
                data.Update(cliente);

            return RedirectToAction("Index");
        }
    }
}
