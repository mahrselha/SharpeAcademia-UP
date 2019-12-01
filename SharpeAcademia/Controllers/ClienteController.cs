using System.Net;
using Domain;
using Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}

        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(Cliente u)
        //{
        //    var result = await _signInManager.PasswordSignInAsync
        //        (u.Email, u.Senha, true, lockoutOnFailure: false);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Treino");
        //    }
        //    ModelState.AddModelError("", "Falha no login!");
        //    return View(u);
        //}
    }
}