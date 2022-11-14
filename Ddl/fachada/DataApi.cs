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
            throw new NotImplementedException();
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
    }
}
