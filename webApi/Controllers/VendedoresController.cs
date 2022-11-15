using Ddl.Dominio;
using Ddl.fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        private IDataApi dataApi = new DataApi();

        [HttpGet("/VENDEDORES")]
        public IActionResult GetVendedores()
        {
            List<Vendedor> lst = null;
            try
            {
                lst = dataApi.getVendedores();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/ADDVEN")]
        public IActionResult PostVendedor(Vendedor v)
        {
            try
            {
                if (v == null)
                {
                    return BadRequest("Datos de autoParte incorrectos!");
                }

                return Ok(dataApi.saveVen(v));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno! Intente luego: {ex.Message}");
            }
        }

    }
}
