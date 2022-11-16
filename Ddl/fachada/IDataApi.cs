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
        int proxId(); 

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
        bool saveMp(Modelo m);

        bool saveAp(AutoParte ap);
        bool saveFac(Factura f);

        bool updateVen(Vendedor v);
        bool updateCli(Cliente c);
        bool updateAp(AutoParte ap);

        bool deleteAp(int id);
        bool deleteCli(int id);
        bool deleteVen(int id);



        List<Barrio> getBarrios();
        List<Provincia> getProvincias();
        List<Ciudad> getCiudades();

        List<Cliente> getClientes();
        List<Cliente> getClientes(string apellido);

        List<Vendedor> getVendedores();
        List<Vendedor> getVendedores(string apellido);

        List<TipoCliente> getTipoCliente();
        List<tipoProduccion> getTipoProd();
    }
}
