using Ddl.Dominio;
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
        [HttpGet("/CLIENTESAPE")]
        public IActionResult GetCliente(string apellido)
        {
            List<Cliente> lst = null;
            try
            {
                lst = dataApi.getClientes(apellido);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/ADDCLI")]
        public IActionResult PostCliente(Cliente c)
        {
            try
            {
                if (c == null)
                {
                    return BadRequest("Datos de autoParte incorrectos!");
                }

                return Ok(dataApi.saveCli(c));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno! Intente luego: {ex.Message}");
            }
        }

        [HttpPut("/UPCLI")]
        public IActionResult PutCliente(Cliente c)
        {
            try
            {
                if (c == null)
                {
                    return BadRequest("Datos de autoParte incorrectos!");
                }

                return Ok(dataApi.updateCli(c));

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
