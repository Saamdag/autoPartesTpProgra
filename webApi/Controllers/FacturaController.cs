using Ddl.Dominio;
using Ddl.fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IDataApi dataApi = new DataApi();

        [HttpPost("/ADDFAC")]
        public IActionResult PostFact(Factura fac)
        {
            try
            {
                if (fac == null)
                {
                    return BadRequest("Datos de autoParte incorrectos!");
                }

                return Ok(dataApi.saveFac(fac));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno! Intente luego: {ex.Message}");
            }
        }


        [HttpGet("/GFACTURAS")]
        public IActionResult getFacturas()
        {
            List<Factura> lst = null;
            try
            {
                lst = dataApi.getFacturas();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/FACTURASENTRE")]
        public IActionResult getFacturas(DateTime desde, DateTime hasta)
        {
            List<Factura> lst = null;
            try
            {
                lst = dataApi.getFacturas(desde, hasta);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }



        [HttpGet("/DETALLE")]
        public IActionResult getDetalle(int id)
        {
            List<DetalleFactura> lst = null;
            try
            {
                lst = dataApi.getDetalle(id);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }


    }
}
