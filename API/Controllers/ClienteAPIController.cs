using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Domain;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteAPIController : ControllerBase
    {
        public readonly ClienteDAO _clienteDAO;

        public ClienteAPIController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }
        [HttpGet]
        [Route("ListarTodos")]
        public string ListarTodos()
        {
            List<Cliente> clientes = _clienteDAO.ListarTodos();
            string lista = JsonConvert.SerializeObject(clientes);

            return lista;
        }
        [HttpGet]
        [Route("BuscarPorId/{id}")]///{} parametros
        public string BuscarPorId([FromRoute]int id)
        {
            Cliente e = _clienteDAO.BuscarPorId(id);
            string lista = JsonConvert.SerializeObject(e);

            return lista;

        }
    }
}