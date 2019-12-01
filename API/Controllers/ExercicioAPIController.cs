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
    public class ExercicioAPIController : ControllerBase
    {
        public readonly ExercicioDAO _exercicioDAO;

        public ExercicioAPIController(ExercicioDAO exercicioDAO)
        {
            _exercicioDAO = exercicioDAO;
        }

        //GET: /api/Treino/ListarTodos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_exercicioDAO.ListarTodos());
        }
        //GET:
        [HttpGet]
        [Route("BuscarPorId/{id}")]///{} parametros
        public IActionResult BuscarPorId([FromRoute]int id)
        {
            Exercicios e = _exercicioDAO.BuscarPorId(id);
            if (e != null)
            {
                return Ok(e);
            }
            return NotFound(new { msg = "Não encontrado" });
        }

        [HttpGet]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] Exercicios exercicios)
        {
            _exercicioDAO.Cadastrar(exercicios);
            return Created("", exercicios);
        }
    }
}