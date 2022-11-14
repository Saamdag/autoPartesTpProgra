using Ddl.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddl.Datos.interfaces
{
    public interface IDAO
    {
        List<AutoParte> obtenerProductos(string nombre,string activo);
        List<AutoParte> obtenerProductos();
        List<Factura> obtenerFacturas();
        List<Factura> obtenerFacturas(DateTime desde, DateTime hasta);

        List<DetalleFactura> obtenerDetalles(int id);


        List<Modelo> obtenerModelos();
        List<Marca> obtenerMarcas();

        List<Cliente> obtenerClientes();
        List<Vendedor> obtenerVendedores();
        List<TipoCliente> obtenerTipoCliente();



        bool guardarMa(Marca ma);
        bool guardarAp(AutoParte ap);
        bool guardarFac(Factura f);

        List<tipoProduccion> obtenerTipoProduccion();
    }
}
