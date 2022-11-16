using Ddl.Datos.implementacion;
using Ddl.Datos.interfaces;
using Ddl.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddl.fachada
{
    public class DataApi : IDataApi
    {
        private IDAO dao;

        public DataApi()
        {
            dao = new DAO();
        }

        public bool updateCli(Cliente c)
        {
            return dao.updateCli(c);
        }

        public List<Cliente> getClientes()
        {
            return dao.obtenerClientes();
        }

        public List<Marca> getMarca()
        {
            return dao.obtenerMarcas();
        }

        public List<Modelo> getModelo()
        {
            return dao.obtenerModelos();
        }

        public List<tipoProduccion> getTipoProd()
        {
            return dao.obtenerTipoProduccion();
        }


        public List<AutoParte> getProductos()
        {
            return dao.obtenerProductos();
        }
        public List<AutoParte> getProductos(string nombre,string activo)
        {
            return dao.obtenerProductos(nombre,activo);
        }

        public List<TipoCliente> getTipoCliente()
        {
            return dao.obtenerTipoCliente();
        }

        public List<Vendedor> getVendedores()
        {
            return dao.obtenerVendedores();
        }

        public bool saveAp(AutoParte ap)
        {
            return dao.guardarAp(ap);
        }

        public bool saveFac(Factura f)
        {
            return dao.guardarFac(f);
        }

        public List<Factura> getFacturas()
        {
            return dao.obtenerFacturas();
        }

        public List<DetalleFactura> getDetalle(int id)
        {
            return dao.obtenerDetalles(id);
        }

        public List<Factura> getFacturas(DateTime desde, DateTime hasta)
        {
            return dao.obtenerFacturas(desde,hasta);
        }

        public bool saveMa(Marca m)
        {
            return dao.guardarMa(m);
        }
        public bool saveMp(Modelo m)
        {
            return dao.guardarMo(m);
        }

        public bool updateVen(Vendedor v)
        {
            return dao.updateVen(v);
        }

        public bool updateAp(AutoParte ap)
        {
            return dao.updateAp(ap);
        }

        public bool deleteAp(int id)
        {
            return dao.deleteAp(id);
        }
        public bool deleteVen(int id)
        {
            return dao.deleteVen(id);
        }

        public bool deleteCli(int id)
        {
            return dao.deleteCli(id);
        }

        public List<Barrio> getBarrios()
        {
            return dao.obtenerBarrios();
        }

        public List<Provincia> getProvincias()
        {
            return dao.obtenerProvincias();
        }

        public List<Ciudad> getCiudades()
        {
            return dao.obtenerCiudades();
        }

        public bool saveVen(Vendedor v)
        {
            return dao.guardarVen(v);
        }

        public bool saveCli(Cliente c)
        {
            return dao.guardarCli(c);
        }

        public List<Cliente> getClientes(string apellido)
        {
            return dao.obtenerClientes(apellido);
        }

        public List<Vendedor> getVendedores(string apellido)
        {
            return dao.obtenerVendedores(apellido);
        }

        public int proxId()
        {
            return dao.proxId();
        }
    }
}
