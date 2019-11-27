using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace SharpeAcademia.Controllers
{
    [Authorize]
    //[Authorize(Roles = "ADM")]
    public class TreinoController : Controller
    {
        private readonly ClienteDAO _clienteDAO;
        private readonly ProfessorDAO _professorDAO;
        private readonly TreinoDAO _treinoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly IHostingEnvironment _hosting;
        public TreinoController(ClienteDAO clienteDAO,
            ProfessorDAO professorDAO,
            TreinoDAO treinoDAO,
            CategoriaDAO categoriaDAO,
        IHostingEnvironment hosting)
        {
            _clienteDAO = clienteDAO;
            _treinoDAO = treinoDAO;
            _professorDAO = professorDAO;
            _categoriaDAO = categoriaDAO;
            _hosting = hosting;
        }

        //[HttpPost]
        //public IActionResult Cadastrar(Produto p,
        //    int drpCategorias, IFormFile fupImagem)
        //{
        //    ViewBag.Categorias =
        //        new SelectList(_categoriaDAO.ListarTodos(),
        //        "CategoriaId", "Nome");            

        //    if (ModelState.IsValid)
        //    {
        //        //Cadastrar a imagem
        //        if (fupImagem != null)
        //        {
        //            //paste: ecommerceimagens
        //            string arquivo = Guid.NewGuid().ToString() +
        //                Path.GetExtension(fupImagem.FileName);
        //            string caminho = Path.Combine(_hosting.WebRootPath,
        //                "ecommerceimagens", arquivo);
        //            fupImagem.CopyTo(
        //                new FileStream(caminho, FileMode.Create));
        //            p.Imagem = arquivo;
        //        }
        //        else
        //        {
        //            p.Imagem = "semimagem.jfif";
        //        }

        //        p.Categoria =
        //            _categoriaDAO.BuscarPorId(drpCategorias);

        //        if (_produtoDAO.Cadastrar(p))
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        ModelState.AddModelError
        //            ("", "Esse produto já existe!");
        //    }
        //    return View(p);
        //}

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_treinoDAO.ListarTodos());
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categoria =
                new SelectList(_categoriaDAO.ListarTodos(),
                "CategoriaId", "Nome");
            return View();
        }


        //public IActionResult Remover(int id)
        //{
        //    _treinoDAO.Remover(id);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Alterar(int id)
        //{
        //    return View
        //        (_treinoDAO.BuscarPorId(id));
        //}

        //[HttpPost]
        //public IActionResult Alterar(Treino p)
        //{
        //    _treinoDAO.Alterar(p);
        //    return RedirectToAction("Index");
        //}
    }
}