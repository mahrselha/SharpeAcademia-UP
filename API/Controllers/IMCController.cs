using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IMCController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get(double peso, double altura)
        {
            string stg = "";
            //os parametros devem ser passados pela url.
            // EX:  api/values?peso=75&altura=1.69
            if (peso != 0 && altura != 0)
            {
                double valor = peso / (altura * altura);
                stg = valor.ToString();
            }
            else
            {
                stg = "0";
            }

            string json = "{ imc: " + double.Parse(stg).ToString("0.00") + "}";

            return json;
        }
    }
}