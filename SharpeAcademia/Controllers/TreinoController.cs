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
using System.Data;

namespace SharpeAcademia.Controllers
{

    public class TreinoController : Controller
    {

        public static List<Exercicios> listExercicios = new List<Exercicios>();
        public static List<Cliente> listCliente = new List<Cliente>();
        public static List<Professor> listProfessor = new List<Professor>();
        public static Treino treinolist = new Treino();
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
        [HttpGet]
        public IActionResult Cadastrar()
        {
            ListaExercicio();
            ListaBanco();

            ViewBag.Exercicios = new SelectList(_exercicioDAO.ListarTodos(), "ExercicioId", "Nome");
            ViewBag.Cliente = new SelectList(_clienteDAO.ListarTodos(), "ClienteId", "Nome");
            ViewBag.Professor = new SelectList(_professorDAO.ListarTodos(), "ProfessorId", "Nome");

            //listExercicios = _exercicioDAO.ListarTodos();
            //listProfessor = _professorDAO.ListarTodos();
            //listCliente = _clienteDAO.ListarTodos();

            
            return View();
        }
       
        [HttpPost]
        public IActionResult Cadastrar(Treino treinolist, int drpCliente, int drpProfessor,
            int drpExercicios)
        {
            

            treinolist.Cliente = _clienteDAO.BuscarPorId(drpCliente);
                treinolist.Professor = _professorDAO.BuscarPorId(drpProfessor);
                treinolist.Exercicio = _exercicioDAO.BuscarPorId(drpExercicios);

                if (_treinoDAO.Cadastrar(treinolist))
                {
                    return RedirectToAction("Index");
                }
               
            return View(treinolist);
        }


        public IActionResult Index()
        {

            List<Treino> objTemp = _treinoDAO.BuscarTreino();
            if (objTemp != null && objTemp.Count > 0 )
            {
                return View(objTemp);
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

                    if (!obj.Exists(x => x.Nome.Equals(itemApi.Nome)))
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
