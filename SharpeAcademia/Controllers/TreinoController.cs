using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Repository;

namespace SharpeAcademia.Controllers
{
    [Authorize]
    //[Authorize(Roles = "ADM")]
    public class TreinoController : Controller
    {

        public static List<Exercicios> Exercicios = new List<Exercicios>();
        private readonly ClienteDAO _clienteDAO;
        private readonly ProfessorDAO _professorDAO;
        private readonly TreinoDAO _treinoDAO;
        private readonly ExercicioDAO _exercicioDAO;
        private readonly IHostingEnvironment _hosting;
        public TreinoController(ClienteDAO clienteDAO,
            ProfessorDAO professorDAO,
            TreinoDAO treinoDAO,
            ExercicioDAO exercicioDAO,
        IHostingEnvironment hosting)
        {
            _clienteDAO = clienteDAO;
            _treinoDAO = treinoDAO;
            _professorDAO = professorDAO;
            _exercicioDAO = exercicioDAO;
            _hosting = hosting;
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente c, Professor p)
        {


            ViewBag.Exercicios =
                new SelectList(_exercicioDAO.ListarTodos(),
                "ExercicioId", "Nome", "Categoria");

            return View();
        }


        public IActionResult Index()
        {
            return View(/*_treinoDAO.ListarTodos()*/);
        }

        public void ListaExercicio()
        {
            List<Exercicios> exercicio = new List<Exercicios>();

            using (var client = new WebClient())
            {
                String json = client.DownloadString("http://localhost:61822/api/ExercicioAPI/Listar");

                exercicio = JsonConvert.DeserializeObject<List<Exercicios>>(json);

            }

        }

    }
}
