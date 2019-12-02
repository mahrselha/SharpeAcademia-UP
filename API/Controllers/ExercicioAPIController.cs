using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioAPIController : ControllerBase
    {
        
        [HttpGet]
        [Route("Listar")]
        public string Listar() {

            List<Exercicios> exercicio = ListaExercicios.CarregaLista();
            string lista = JsonConvert.SerializeObject(exercicio);

            return lista;

        }
                     
    }
}