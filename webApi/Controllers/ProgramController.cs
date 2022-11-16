using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ddl.fachada;
using Ddl.Dominio;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private IDataApi dataApi;

        public ProgramController()
        {
            dataApi = new DataApi();
        }

        [HttpGet("/ControllerMarca")]
        public IActionResult getMarca()
        {
            List<Marca> list = null;
            try
            {
                list = dataApi.getMarca();
                return Ok(list);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/ControllerModelo")]
        public IActionResult getModelo()
        {
            List<Modelo> lsts = null;
            try
            {
                lsts = dataApi.getModelo();
                return Ok(lsts);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/ControllerTipo")]
        public IActionResult getTipoProd()
        {
            List<tipoProduccion> lsts = null;
            try
            {
                lsts = dataApi.getTipoProd();
                return Ok(lsts);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/ControllerTipoClie")]
        public IActionResult getTipoClie()
        {
            List<TipoCliente> lsts = null;
            try
            {
                lsts = dataApi.getTipoCliente();
                return Ok(lsts);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/BARRIOS")]
        public IActionResult getBarrio()
        {
            List<Barrio> lsts = null;
            try
            {
                lsts = dataApi.getBarrios();
                return Ok(lsts);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/PROVINCIAS")]
        public IActionResult getProvincia()
        {
            List<Provincia> lsts = null;
            try
            {
                lsts = dataApi.getProvincias();
                return Ok(lsts);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/CIUDADES")]
        public IActionResult getCiudades()
        {
            List<Ciudad> lsts = null;
            try
            {
                lsts = dataApi.getCiudades();
                return Ok(lsts);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/ADDMARCA")]
        public IActionResult PostMarca(Marca marca)
        {
            try
            {
                if (marca == null)
                {
                    return BadRequest("Datos de Modelo incorrectos!");
                }

                return Ok(dataApi.saveMa(marca));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno! Intente luego: {ex.Message}");
            }
        }

        [HttpPost("/ADDMODELO")]
        public IActionResult PostModelo(Modelo modelo)
        {
            try
            {
                if (modelo == null)
                {
                    return BadRequest("Datos de Modelo incorrectos!");
                }

                return Ok(dataApi.saveMp(modelo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno! Intente luego: {ex.Message}");
            }
        }

    }
}
