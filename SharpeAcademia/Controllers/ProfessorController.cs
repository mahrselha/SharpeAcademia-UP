using System.Net;
using Domain;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SharpeAcademia.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ProfessorDAO _professorDAO; 
        public ProfessorController(ProfessorDAO professorDAO)
        {
            _professorDAO = professorDAO;
        }
        public IActionResult Index()
        {
            List<Professor> professores = new List<Professor>();
            using (var client = new WebClient()) {
                string json = client.DownloadString("http://localhost:61822/api/Professor/ListarTodos");
                professores = JsonConvert.DeserializeObject<List<Professor>>(json);
            }
            return View(professores);
        }

        [HttpPost]
        public IActionResult Cadastrar(Professor professor)
        {
            if (_professorDAO.Cadastrar(professor)) {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Cadastrar() {
            return View();
        }
        public IActionResult Remover(int id) {
            _professorDAO.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int id) {
            return View
                (_professorDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Professor professor) {
            _professorDAO.Alterar(professor);
            return RedirectToAction("Index");
        }
        /*
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
        //}*/
    }
}