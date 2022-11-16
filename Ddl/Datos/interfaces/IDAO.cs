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
        int proxId();

        List<Modelo> obtenerModelos();
        List<Marca> obtenerMarcas();

        List<Barrio> obtenerBarrios();
        List<Provincia> obtenerProvincias();
        List<Ciudad> obtenerCiudades();


        List<Cliente> obtenerClientes();
        List<Cliente> obtenerClientes(string apellido);

        List<Vendedor> obtenerVendedores();
        List<Vendedor> obtenerVendedores(string apellido);



        List<TipoCliente> obtenerTipoCliente();

        bool deleteAp(int id);
        bool deleteCli(int id);
        bool deleteVen(int id);

        bool guardarCli(Cliente c);
        bool guardarVen(Vendedor v);
        bool guardarMa(Marca ma);
        bool guardarMo(Modelo modelo);

        bool guardarAp(AutoParte ap);
        bool guardarFac(Factura f);

        bool updateCli(Cliente c);
        bool updateVen(Vendedor v);
        bool updateAp(AutoParte ap);

        List<tipoProduccion> obtenerTipoProduccion();
    }
}
