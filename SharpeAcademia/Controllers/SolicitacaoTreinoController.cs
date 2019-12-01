using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SharpeAcademia.Utils;

namespace SharpeAcademia.Controllers
{
    public class SolicitacaoTreinoController : Controller { 

    private readonly ProfessorDAO _professorDAO;
    private readonly ClienteDAO _clienteDAO;
    private readonly TreinoDAO _treinoDAO;
    private readonly UtilsSession _utilsSession;

    public SolicitacaoTreinoController(ProfessorDAO professorDAO,
    ClienteDAO clienteDAO,
    TreinoDAO treinoDAO,
    UtilsSession utilsSession)
    {
        _professorDAO = professorDAO;
        _clienteDAO = clienteDAO;
        _treinoDAO = treinoDAO;
        _utilsSession = utilsSession;
    }
    
        public IActionResult Index()
        {
            return View();
        }
    }
}