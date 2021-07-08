using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ces.api.gestaoagro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegracaoController : ControllerBase
    {
        // GET: api/<IntegracaoController>
        [HttpGet("ping")]
        public bool Ping()
        {
            return true;
        }

        // POST api/<IntegracaoController>
        [HttpPost]
        public void Post([FromBody] object value)
        {
            object oValue = value;

        }




    }
}
