using System;
using System.Collections.Generic;
using System.Globalization;
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

            altura.ToString("N2", CultureInfo.CreateSpecificCulture("en-US"));

            if (peso != 0 && altura != 0)
            {
                double valor = peso / (altura * altura);
                valor = valor * 10000;
                stg = valor.ToString();
            }
            else
            {
                stg = "0";
            }

            string json = "{ imc: " + double.Parse(stg).ToString("0.00") + "}";
            //string json = "{ imc: " + double.Parse("2.45").ToString("0.00") + "}";
            return json;
        }
    }
}