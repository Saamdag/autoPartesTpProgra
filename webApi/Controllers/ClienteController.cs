﻿using Ddl.Dominio;
using Ddl.fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IDataApi dataApi = new DataApi();

        [HttpGet("/CLIENTES")]
        public IActionResult GetCliente()
        {
            List<Cliente> lst = null;
            try
            {
                lst = dataApi.getClientes();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

    }
}