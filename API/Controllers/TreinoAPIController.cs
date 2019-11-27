using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinoAPIController : ControllerBase
    {
        public readonly TreinoDAO _treinoDAO;

        public TreinoAPIController (TreinoDAO treinoDAO)
        {
            _treinoDAO = treinoDAO;
        }

        //GET: /api/Treino/ListarTodos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_treinoDAO.ListarTodos());
        }
        //GET:
        [HttpGet]
        [Route("BuscarPorId/{id}")]///{} parametros
        public IActionResult BuscarPorId([FromRoute]int id)
        {
            Treino t = _treinoDAO.BuscarPorId(id);
            if (t != null)
            {
                return Ok(t);
            }
            return NotFound(new { msg = "Não encontrado" });
        }

        [HttpGet]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] Treino treino)
        {
            _treinoDAO.Cadastrar(treino);
            return Created("", treino);
        }
    }
}