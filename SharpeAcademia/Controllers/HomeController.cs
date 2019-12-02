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
        private readonly ExercicioDAO _exercicioDAO;
        private readonly UtilsSession _utilsSession;

        public HomeController(ProfessorDAO professorDAO,
        ClienteDAO clienteDAO,
        TreinoDAO treinoDAO,
        ExercicioDAO exercicioDAO,
        UtilsSession utilsSession)
        {
            _professorDAO = professorDAO;
            _clienteDAO = clienteDAO;
            _treinoDAO = treinoDAO;
            _exercicioDAO = exercicioDAO;
            _utilsSession = utilsSession;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}