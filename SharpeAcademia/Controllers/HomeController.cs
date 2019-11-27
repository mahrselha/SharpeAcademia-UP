using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using SharpeAcademia.Utils;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace SharpeAcademia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProfessorDAO _professorDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly TreinoDAO _treinoDAO;
        private readonly UtilsSession _utilsSession;

        public HomeController(ProfessorDAO professorDAO,
        ClienteDAO clienteDAO,
        TreinoDAO treinoDAO,
        UtilsSession utilsSession)
        {
            _professorDAO = professorDAO;
            _clienteDAO = clienteDAO;
            _treinoDAO = treinoDAO;
            _utilsSession = utilsSession;
        }
        public IActionResult Index(int? id)
        {

            //ViewBag.Categorias = _categoriaDAO.ListarTodos();
            //if (id == null)
            //{
            //    return View(_produtoDAO.ListarTodos());
            //}
            return View();
        }
        //public IActionResult Detalhes(int id)
        //{
        //    return View(_produtoDAO.BuscarPorId(id));
        //}
        //public IActionResult RemoverDoCarrinho(int id)
        //{
        //    _itemVendaDAO.Remover(id);
        //    return RedirectToAction("CarrinhoCompras");
        //}
        //public IActionResult CarrinhoCompras()
        //{
        //    ViewBag.TotalCarrinho = _itemVendaDAO.
        //        RetornarTotalCarrinho(_utilsSession.RetornarCarrinhoId());

        //    return View(_itemVendaDAO.
        //        ListarItensPorCarrinhoId
        //        (_utilsSession.RetornarCarrinhoId()));
        //}
        //public IActionResult AumentarQuantidade(int id)
        //{
        //    _itemVendaDAO.AumentarQuantidade(id);
        //    return RedirectToAction("CarrinhoCompras");
        //}
        //public IActionResult DiminuirQuantidade(int id)
        //{
        //    _itemVendaDAO.DiminuirQuantidade(id);
        //    return RedirectToAction("CarrinhoCompras");
        //}
        //public IActionResult AdicionarAoCarrinho(int id)
        //{
        //    //Adicionar os produtos dentro do carrinho
        //    Produto p = _produtoDAO.BuscarPorId(id);
        //    ItemVenda i = new ItemVenda
        //    {
        //        Produto = p,
        //        Quantidade = 1,
        //        Preco = p.Preco.Value,
        //        CarrinhoId = _utilsSession.RetornarCarrinhoId()
        //    };
        //    //Gravar o objeto na tabela
        //    _itemVendaDAO.Cadastrar(i);
        //    return RedirectToAction("CarrinhoCompras");
        //}
    }
}