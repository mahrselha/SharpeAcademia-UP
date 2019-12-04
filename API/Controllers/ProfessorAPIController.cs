//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Domain;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Repository;

//namespace API.Controllers
//{
//    [Route("api/Professor")]
//    [ApiController]
//    public class ProfessorAPIController : ControllerBase
//    {
//        public readonly ProfessorDAO _professorDAO;

//        public ProfessorAPIController(ProfessorDAO professorDAO)
//        {
//            _professorDAO = professorDAO;
//        }

//        //GET: /api/Professor/ListarTodos
//        [HttpGet]
//        [Route("ListarTodos")]
//        public IActionResult ListarTodos()
//        {
//            return Ok(_professorDAO.ListarTodos());
//        }
//        //GET:
//        [HttpGet]
//        [Route("BuscarPorId/{id}")]///{} parametros
//        public IActionResult BuscarPorId([FromRoute]int id)
//        {
//            Professor e = _professorDAO.BuscarPorId(id);
//            if (e != null)
//            {
//                return Ok(e);
//            }
//            return NotFound(new { msg = "Não encontrado" });
//        }

//        [HttpPost]
//        [Route("Cadastrar")]
//        public IActionResult Cadastrar([FromBody] Professor professor)
//        {
//            _professorDAO.Cadastrar(professor);
//            return Created("", professor);
//        }
//    }
//}