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
            ListaBanco();
                       
            ViewBag.Exercicios = _exercicioDAO.ListarTodos();
            ViewBag.Cliente = new SelectList(_clienteDAO.ListarTodos(), "ClienteId", "Nome");
            ViewBag.Professor = new SelectList(_professorDAO.ListarTodos(), "ProfessorId", "Nome");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Treino t, int drpCliente, 
            int drpProfessor)
        {
            Treino treino = new Treino();

            List<Exercicios> listatreino = new List<Exercicios>();

            foreach (Exercicios item in ViewBag.Exercicios)
            {
                if (item.Ckb == true)
                {
                    listatreino.Add(item);
                }
            }
            treino.Professor = t.Professor;
            treino.Cliente = t.Cliente;
            treino.NomeExercicio = listatreino;

            _treinoDAO.Cadastrar(treino);
                      

            return View();
        }


        public IActionResult Index()
        {
            if(_treinoDAO.ListarTodos() != null)
            {
                return View(_treinoDAO.ListarTodos());
            }
            return View(new List<Treino>());

        }

        public void ListaExercicio()
        {
            Exercicios e = new Exercicios();

            using (var client = new WebClient())
            {
                String json = client.DownloadString("http://localhost:61822/api/ExercicioAPI/Listar");

                listExercicios = JsonConvert.DeserializeObject<List<Exercicios>>(json);
            }

        }

        public IActionResult Remover(int id)
        {
            _treinoDAO.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int id)
        {
            return View
                (_treinoDAO.BuscarPorId(id));
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
