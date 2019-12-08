using System.Net;
using Domain;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace SharpeAcademia.Controllers
{
    public class ProfessorController : Controller
    {
        public static List<Professor> listProfessor = new List<Professor>();
        private readonly ProfessorDAO _professorDAO; 
        public ProfessorController(ProfessorDAO professorDAO)
        {
            _professorDAO = professorDAO;
        }
        public IActionResult Index()
        {
            List<Professor> professores = new List<Professor>();
            WebClient client = new WebClient();
            string json = client.DownloadString("http://localhost:61822/api/Professor/ListarTodos");
            professores = JsonConvert.DeserializeObject<List<Professor>>(json);
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

        public void ListaProfessor()
        {
            Professor p = new Professor();

            using (var client = new WebClient())
            {
                String json = client.DownloadString("http://localhost:61822/api/ProfessorAPI/Listar");

                listProfessor = JsonConvert.DeserializeObject<List<Professor>>(json);
            }

        }

        public void ListaBanco()
        {
            List<Professor> obj = new List<Professor>();
            obj.AddRange(_professorDAO.ListarTodos());

            if (obj.Count > 0)
            {
                foreach (var itemApi in listProfessor)
                {

                    if (!obj.Exists(x => x.Cpf.Equals(itemApi.Cpf)))
                    {
                        _professorDAO.Cadastrar(itemApi);
                    }

                }
            }
            else
            {
                foreach (var item in listProfessor)
                {
                    _professorDAO.Cadastrar(item);
                }

            }

        }

    }
}