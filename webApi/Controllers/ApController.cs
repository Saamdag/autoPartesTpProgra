using Ddl.Dominio;
using Ddl.fachada;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApController : ControllerBase
    {
        private IDataApi dataApi=new DataApi();

        [HttpGet("/AUTOPARTES")]
        public IActionResult GetProductos()
        {
            List<AutoParte> lst = null;
            try
            {
                lst = dataApi.getProductos();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/AUTOPARTESNOM")]
        public IActionResult GetProductos(string nombre, string activo)
        {
            List<AutoParte> autoParte = null;
            try
            {
                autoParte = dataApi.getProductos(nombre, activo);

                return Ok(autoParte);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        
        [HttpPost("/ADDAP")]
        public IActionResult PostAutoParte(AutoParte ap)
        {
            try
            {
                if (ap == null)
                {
                    return BadRequest("Datos de autoParte incorrectos!");
                }

                return Ok(dataApi.saveAp(ap));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno! Intente luego: {ex.Message}");
            }
        }




    }
}
