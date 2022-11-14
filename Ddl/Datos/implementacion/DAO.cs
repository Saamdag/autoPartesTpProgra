using Ddl.Datos.interfaces;
using Ddl.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Ddl.Datos.implementacion
{
    public class DAO : IDAO
    {
        public bool guardarMa(Marca m)
        {
            DataTable d = helper.Instancia().querySqlParam($"insert into Marca values({m.nombre})",null);
            if (d.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool guardarAp(AutoParte ap)
        {
            return helper.Instancia().EjecutarSQLAP("sp_auto_partes",ap);
        }

        public List<Marca> obtenerMarcas()
        {
            DataTable dt = helper.Instancia().ConsultaSQL("spMarcas", null);
            List<Marca> lst = new List<Marca>();
            foreach (DataRow fila in dt.Rows)
            {
                Marca marca = new Marca();
                marca.id = (int)fila[0];
                marca.nombre = fila[1].ToString();
                lst.Add(marca);
            }
            return lst;
        }

        public List<Modelo> obtenerModelos()
        {
            DataTable dt = helper.Instancia().ConsultaSQL("spModelo", null);
            List<Modelo> lsts = new List<Modelo>();
            foreach (DataRow fila in dt.Rows)
            {
                Modelo modelo = new Modelo();
                modelo.id = (int)fila[0];
                modelo.nombre = fila[1].ToString();
                lsts.Add(modelo);
            }


            return lsts;
        }

        public List<AutoParte> obtenerProductos()
        {
            DataTable dt = helper.Instancia().listarProductos();
            List<AutoParte> result = new List<AutoParte>();

            foreach (DataRow fila in dt.Rows)
            {
                AutoParte autoParte = new AutoParte();
                tipoProduccion tp = new tipoProduccion();
                Marca marca = new Marca();
                Modelo modelo = new Modelo();
                autoParte.Marca = marca;
                autoParte.Modelo = modelo;
                autoParte.tipoProduccion = tp;
                autoParte.idArticulo =(int)fila[0];
                autoParte.descripcion = fila[1].ToString();
                autoParte.fechaFabricacion = (DateTime)fila[2];
                autoParte.tipoProduccion.tipo = (string)fila[3].ToString();
                bool act = (bool)fila[4];
                autoParte.activo = 0;
                if (act)
                    autoParte.activo = 1; 
                autoParte.precio = (decimal)fila[5];
                autoParte.Marca.nombre = fila[6].ToString();
                autoParte.Modelo.nombre = fila[7].ToString();

                result.Add(autoParte);
            }
            return result;
        }

        public List<AutoParte> obtenerProductos(string nombre,string activo)
        {

            List<AutoParte> autoPartes = new List<AutoParte> ();

            DataTable dt=new DataTable();

            if(activo == string.Empty || activo=="null")
               dt= helper.Instancia().querySql($"exec listarAutoparteNombre '{nombre}',null", null);
            if (activo=="True")
                dt = helper.Instancia().querySql($"exec listarAutoparteNombre '{nombre}',1", null);
            if (activo == "False")
                dt = helper.Instancia().querySql($"exec listarAutoparteNombre '{nombre}',0", null);


            foreach (DataRow fila in dt.Rows)
            {
                AutoParte autoParte = new AutoParte();
                autoParte.idArticulo = (int)fila[0];
                autoParte.descripcion = fila[1].ToString();
                autoParte.fechaFabricacion = (DateTime)fila[2];
                autoParte.tipoProduccion.tipo = fila[3].ToString();
                bool aaux = (bool)fila[4];
                autoParte.activo = 0;
                if(aaux)
                    autoParte.activo = 1;
                autoParte.precio = (decimal)fila[5];
                autoParte.Marca.nombre = fila[6].ToString();
                autoParte.Modelo.nombre = fila[7].ToString();
                autoPartes.Add(autoParte);
            }
            return autoPartes;

        }

        public List<Cliente> obtenerClientes()
        {
            DataTable dt = helper.Instancia().querySql("select * from VisClientes", null);
            List<Cliente> result = new List<Cliente>();

            foreach (DataRow fila in dt.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = (int)fila[0];
                cliente.nombre = (string)fila[1];
                cliente.telefono = Convert.ToInt64(fila[2]);
                cliente.direccion = fila[3].ToString();
                cliente.idBarrio = (int)fila[4];
                result.Add(cliente);
            }

            return result;
        }

        public List<Vendedor> obtenerVendedores()
        {
            DataTable dt = helper.Instancia().querySql("select * from VisVendedores", null);
            List<Vendedor> result = new List<Vendedor>();

            foreach (DataRow fila in dt.Rows)
            {
                Vendedor v = new Vendedor();
                v.idVendedor = (int)fila[0];
                v.nombre = (string)fila[1];
                v.telefono = Convert.ToInt64(fila[2]);
                v.direccion = fila[3].ToString();
                v.idBarrio = (int)fila[4];
                result.Add(v);
            }

            return result;
        }

        public List<TipoCliente> obtenerTipoCliente()
        {
            DataTable dt = helper.Instancia().ConsultaSQL("spVerTipoCliente",null);
            List<TipoCliente> result = new List<TipoCliente>();

            foreach (DataRow fila in dt.Rows)
            {
                TipoCliente tipoCliente = new TipoCliente();
                tipoCliente.idTipo = (int)fila[0];
                tipoCliente.tipoCliente = fila[1].ToString();

                result.Add(tipoCliente);
            }

            return result;
        }

        public List<tipoProduccion> obtenerTipoProduccion()
        {
            DataTable dt = helper.Instancia().querySql("select * from VisTipoProd", null);
            List<tipoProduccion> lst = new List<tipoProduccion>();
            foreach (DataRow fila in dt.Rows)
            {
                tipoProduccion tp = new tipoProduccion();
                tp.id = (int)fila[0];
                tp.tipo = fila[1].ToString();
                lst.Add(tp);
            }
            return lst;
        }

        public bool guardarFac(Factura f)
        {
            return helper.Instancia().insertFactura(f);
        }

        public List<Factura> obtenerFacturas()
        {
            DataTable dt = helper.Instancia().querySql("select * from VisFact", null);
            List<Factura> result = new List<Factura>();

            foreach (DataRow fila in dt.Rows)
            {
               Factura f = new Factura();
                f.idFactura = (int)fila[0];
                f.fechaFactura = (DateTime)fila[1];
                f.cliente.nombre = (string)fila[2];
                f.vendedor.nombre = (string)fila[3];

                result.Add(f);

            }

            return result;
        }

        public List<Factura> obtenerFacturas(DateTime desde, DateTime hasta)
        {
            List <SqlParameter> ls= new List<SqlParameter>();
            ls.Add(new SqlParameter("@desde", desde));
            ls.Add(new SqlParameter("@hasta", hasta));

            DataTable dt = helper.Instancia().querySqlParam("spFacturasEntre", ls);
            List<Factura> result = new List<Factura>();

            foreach (DataRow fila in dt.Rows)
            {
                Factura f = new Factura();
                f.idFactura = (int)fila[0];
                f.fechaFactura = (DateTime)fila[1];
                f.cliente.nombre = (string)fila[2];
                f.vendedor.nombre = (string)fila[3];

                result.Add(f);

            }

            return result;
        }
        public List<DetalleFactura> obtenerDetalles(int id)
        {
            DataTable dt = helper.Instancia().querySql($"select * from VisDetFac where id_factura={id}", null);
            List<DetalleFactura> result = new List<DetalleFactura>();

            foreach (DataRow fila in dt.Rows)
            {
               DetalleFactura det = new DetalleFactura();
                AutoParte ap = new AutoParte();
                det.AutoParte = ap;
               det.idDetalleNro = (int)fila[0];
               det.AutoParte.descripcion = fila[2].ToString();
                det.cantidad = (int)fila[3];
                bool bon = (bool)fila[4];
                det.bonificacion = 0;
                if (bon)
                    det.bonificacion = 1;

                det.descuento = (int)fila[5];
                result.Add(det);

            }

            return result;
        }

        
    }
}
