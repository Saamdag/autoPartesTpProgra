using Ddl.Datos.interfaces;
using Ddl.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddl.fachada
{
    public interface IDataApi
    {

        List<AutoParte> getProductos();
        List<AutoParte> getProductos(string nombre, string activo);
        List<Marca> getMarca();
        List<Modelo> getModelo();
        List<Factura>getFacturas();
        List<Factura> getFacturas(DateTime desde, DateTime hasta);
        List<DetalleFactura> getDetalle(int id);

        bool saveVen(Vendedor v);
        bool saveCli(Cliente c);
        bool saveMa(Marca m);
        bool saveAp(AutoParte ap);
        bool saveFac(Factura f);

        bool updateAp(AutoParte ap);

        bool deleteAp(int id);

        List<Barrio> getBarrios();
        List<Provincia> getProvincias();
        List<Ciudad> getCiudades();

        List<Cliente> getClientes();
        List<Vendedor> getVendedores();
        List<TipoCliente> getTipoCliente();
        List<tipoProduccion> getTipoProd();
    }
}
