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

    public class TreinoController : Controller
    {

        public static List<Exercicios> listExercicios = new List<Exercicios>();
        private readonly ClienteDAO _clienteDAO;
        private readonly ProfessorDAO _professorDAO;
        private readonly TreinoDAO _treinoDAO;
        private readonly ExercicioDAO _exercicioDAO;
        //private readonly IHostingEnvironment _hosting;
        public TreinoController(ClienteDAO clienteDAO,
            ProfessorDAO professorDAO,
            TreinoDAO treinoDAO,
            ExercicioDAO exercicioDAO
        /*IHostingEnvironment hosting*/)
        {
            _clienteDAO = clienteDAO;
            _treinoDAO = treinoDAO;
            _professorDAO = professorDAO;
            _exercicioDAO = exercicioDAO;
            //_hosting = hosting;
        }
        public IActionResult Cadastrar()
        {
            ListaExercicio();
            ViewBag.Exercicios =
                   new SelectList(listExercicios,
                   "ExercicioId", "Nome", "Categoria");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Treino t)
        {

            //t.NomeExercicio = listExercicios;

            ViewBag.Exercicios =
                    new SelectList(listExercicios,
                    "ExercicioId", "Nome", "Categoria");

            //ViewBag.Cliente =
            //    new SelectList(_clienteDAO.ListarTodos(),
            //    "ClienteID", "Nome");

            _treinoDAO.Cadastrar(t);

            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        public void ListaExercicio()
        {
            Exercicios e = new Exercicios();

            using (var client = new WebClient())
            {
                String json = client.DownloadString("http://localhost:61822/api/ExercicioAPI/Listar");

                listExercicios = JsonConvert.DeserializeObject<List<Exercicios>>(json);

                //ViewBag.Professor =
                //    new SelectList(_professorDAO.ListarTodos(),
                //    "ProfessorId", "Nome");
            }



        }

        public void ListaBanco()
        {
            List<Exercicios> obj = new List<Exercicios>();
            obj.AddRange(_exercicioDAO.ListarTodos());
            if (obj.Count > 0)
            {
                foreach (var itemApi in listExercicios)
                {
                    if (!obj.Exists(x => x.NomeExercicio.Equals(itemApi.NomeExercicio)))
                    {
                        _exercicioDAO.Cadastrar(itemApi);
                    }

                }
            }
            else
            {
                foreach (var item in listExercicios)
                {
                    _exercicioDAO.Cadastrar(item);
                }

            }

        }



    }
}
