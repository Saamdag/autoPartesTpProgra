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

        List<Barrio> obtenerBarrios();
        List<Provincia> obtenerProvincias();
        List<Ciudad> obtenerCiudades();


        List<Cliente> obtenerClientes();
        List<Vendedor> obtenerVendedores();


        List<TipoCliente> obtenerTipoCliente();

        bool guardarCli(Cliente c);
        bool guardarVen(Vendedor v);
        bool deleteAp(int id);
        bool updateAp(AutoParte ap);
        bool guardarMa(Marca ma);
        bool guardarAp(AutoParte ap);
        bool guardarFac(Factura f);

        List<tipoProduccion> obtenerTipoProduccion();
    }
}
