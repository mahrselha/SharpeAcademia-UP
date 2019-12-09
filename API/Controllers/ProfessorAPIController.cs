using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;

namespace API.Controllers
{
    [Route("api/Professor")]
    [ApiController]

    public class ProfessorAPIController : ControllerBase
    {
       
            public readonly ProfessorDAO _professorDAO;

            public ProfessorAPIController(ProfessorDAO professorDAO)
            {
                _professorDAO = professorDAO;
            }

            //GET: /api/ProfessorAPI/ListarTodos
            [HttpGet]
            [Route("ListarTodos")]
            public string ListarTodos()
            {
                List<Professor> professores = _professorDAO.ListarTodos();
                string lista = JsonConvert.SerializeObject(professores);

                return lista;
        }
            //GET:
            [HttpGet]
            [Route("BuscarPorId/{id}")]///{} parametros
            public string BuscarPorId([FromRoute]int id)
            {
                Professor e = _professorDAO.BuscarPorId(id);
            
                string lista = JsonConvert.SerializeObject(e);

                return lista;
        }

        }
    }
