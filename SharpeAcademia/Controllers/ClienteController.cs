using System.Net;
using Domain;
using Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace SharpeAcademia.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDAO _clienteDAO;
        private readonly UserManager<UsuarioLogado> _userManager;
        private readonly SignInManager<UsuarioLogado> _signInManager;
        public ClienteController(ClienteDAO clienteDAO,
            UserManager<UsuarioLogado> userManager,
            SignInManager<UsuarioLogado> signInManager)
        {
            _clienteDAO = clienteDAO;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View(_clienteDAO.ListarTodos());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Cliente u)
        {
            if (ModelState.IsValid)
            {
                //Obrigatoriamente o email e o username devem ser
                //preenchidos
                UsuarioLogado uLogado = new UsuarioLogado
                {
                    UserName = u.Email,
                    Email = u.Email
                };
                //Cadastrar o usuário na tabela do Identity
                IdentityResult result =
                    await _userManager.CreateAsync(uLogado, u.Senha);
                if (result.Succeeded)
                {
                    //Token de confirmação do email
                    string token = await
                        _userManager.GenerateEmailConfirmationTokenAsync(uLogado);
                    //Autenticação do usuário
                    await _signInManager.
                        SignInAsync(uLogado, isPersistent: false);
                    u.Imc = getImc(u.Peso, u.Altura);
                    if (_clienteDAO.Cadastrar(u))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Esse e-mail já está sendo usado!");
                }
                AdicionarErros(result);
            }
            return View(u);
        }
        private void AdicionarErros(IdentityResult result)
        {
            foreach (var erro in result.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        public IActionResult Remover(int id) {
            _clienteDAO.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int id) {
            return View
                (_clienteDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Cliente cliente) {
            _clienteDAO.Alterar(cliente);
            return RedirectToAction("Index");
        }


        public double getImc(double peso, double altura)
        {
        
            double imc = 0;
            using (var client = new WebClient())
            {
                double teste = 1.59;
                string url = "http://localhost:61822/api/IMC?peso=" + 59 + "&altura=" + teste;
                string json = client.DownloadString(url);

                imc = Convert.ToDouble(new string(json.Where(char.IsDigit).ToArray()));

            }
            return imc;
        }
    }

        
    
}