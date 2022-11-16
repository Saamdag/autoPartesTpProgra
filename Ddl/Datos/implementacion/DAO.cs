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
        public bool updateCli(Cliente c)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", c.idCliente));
            list.Add(new SqlParameter("@tipo", c.tipoCliente.idTipo));

            list.Add(new SqlParameter("@tel", c.telefono));
            list.Add(new SqlParameter("@direc", c.direccion));
            list.Add(new SqlParameter("@barrio", c.barrio.id));


            return helper.Instancia().EjecutarSQLParam("SpUpClie", list);

        }
        public bool updateVen(Vendedor v)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", v.idVendedor));
            list.Add(new SqlParameter("@tel", v.telefono));
            list.Add(new SqlParameter("@direc", v.direccion));
            list.Add(new SqlParameter("@barrio", v.barrio.id));

            return helper.Instancia().EjecutarSQLParam("SpUpVen", list);
        }

        public bool updateAp(AutoParte ap)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id",ap.idArticulo));
            list.Add(new SqlParameter("@fecha", ap.fechaFabricacion));
            list.Add(new SqlParameter("@idProd", ap.tipoProduccion.id));
            list.Add(new SqlParameter("@activo", ap.activo));
            list.Add(new SqlParameter("@precio", ap.precio));
            list.Add(new SqlParameter("@idMarca", ap.Marca.id));
            list.Add(new SqlParameter("@idModelo", ap.Modelo.id));

            return helper.Instancia().EjecutarSQLParam("SpUpAutoPartes", list); 

        }

        public bool deleteVen(int id)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            return helper.Instancia().EjecutarSQLParam("SpDeleteVen", list);
        }
        public bool deleteCli(int id)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            return helper.Instancia().EjecutarSQLParam("SpDeleteCli", list);
        }
        public bool deleteAp(int id)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            return helper.Instancia().EjecutarSQLParam("SpDeleteAp",list);
        }

        public bool guardarMa(Marca m)
        {
            List<Parametro> values = new List<Parametro>();
            values.Add(new Parametro("@nombre", m.nombre));
            return helper.Instancia().EjecutarSQL("spInsertMarcas", values);
           
        }
        public bool guardarMo(Modelo m)
        {
            List<Parametro> values = new List<Parametro>();
            values.Add(new Parametro("@nombre", m.nombre));
            return helper.Instancia().EjecutarSQL("spInsertModelos", values);

        }
        public bool guardarVen(Vendedor v)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@nobmre", v.nombre));
            list.Add(new SqlParameter("@apellido", v.apellido));
            list.Add(new SqlParameter("@tel", v.telefono));
            list.Add(new SqlParameter("@direc", v.direccion));
            list.Add(new SqlParameter("@idBarrio", v.barrio.id));

            return helper.Instancia().EjecutarSQLParam("SpInsertVend", list);
        }

        public bool guardarCli(Cliente c)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@nobmre", c.nombre));
            list.Add(new SqlParameter("@apellido", c.apellido));
            list.Add(new SqlParameter("@tel", c.telefono));
            list.Add(new SqlParameter("@direc", c.direccion));
            list.Add(new SqlParameter("@idBarrio", c.barrio.id));
            list.Add(new SqlParameter("@tipoClie", c.tipoCliente.idTipo));


            return helper.Instancia().EjecutarSQLParam("SpInsertClie", list);
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

            DataTable dt=null;
            if(nombre == "null")
            {
                if (activo == string.Empty || activo == "null")
                    dt = helper.Instancia().querySql($"exec listarApNom null,null", null);
                if (activo == "true" || activo == "True")
                    dt = helper.Instancia().querySql($"exec listarApNom null,1", null);
                if (activo == "false" || activo == "False")
                    dt = helper.Instancia().querySql($"exec listarApNom null,0", null);
            }
            else
            {
                if (activo == string.Empty || activo == "null")
                    dt = helper.Instancia().querySql($"exec listarApNom '{nombre}',null", null);
                if (activo == "true" || activo == "True")
                    dt = helper.Instancia().querySql($"exec listarApNom '{nombre}',1", null);
                if (activo == "false" || activo == "False")
                    dt = helper.Instancia().querySql($"exec listarApNom '{nombre}',0", null);
            }


            //if(activo == string.Empty || activo=="null")
            //   dt= helper.Instancia().querySql($"exec listarAutoparteNombre '{nombre}',null", null);
            //if (activo=="true")
            //    dt = helper.Instancia().querySql($"exec listarAutoparteNombre '{nombre}',1", null);
            //if (activo == "false")
            //    dt = helper.Instancia().querySql($"exec listarAutoparteNombre '{nombre}',0", null);
            if (dt==null || dt.Rows.Count == 0 )
            {
                return autoPartes;
            }

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
            DataTable dt = helper.Instancia().querySql("select * from VisClie", null);
            List<Cliente> result = new List<Cliente>();

            foreach (DataRow fila in dt.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = (int)fila[0];
                cliente.nombre = (string)fila[1];
                cliente.apellido = (string)fila[2];
                cliente.telefono = Convert.ToInt64(fila[3]);
                cliente.tipoCliente.tipoCliente= fila[4].ToString();
                cliente.direccion = fila[5].ToString();
                cliente.barrio.nombre = (string)fila[6].ToString();
                result.Add(cliente);
            }

            return result;
        }

        public List<Vendedor> obtenerVendedores()
        {
            DataTable dt = helper.Instancia().querySql("select * from VisVen", null);
            List<Vendedor> result = new List<Vendedor>();

            foreach (DataRow fila in dt.Rows)
            {
                Vendedor v = new Vendedor();
                v.idVendedor = (int)fila[0];
                v.nombre = (string)fila[1];
                v.apellido = fila[2].ToString();
                v.telefono = Convert.ToInt64(fila[3]);
                v.direccion = fila[4].ToString();
                v.barrio.nombre= fila[5].ToString();
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

            //DataTable dt = helper.Instancia().querySqlParam("spFacturasEntre", ls);
            DataTable dt = helper.Instancia().spSqlParam($"spFacturasEntre", ls);

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
           // DataTable dt = helper.Instancia().querySql($"select * from VisDetFac where id_factura={id}", null);
            DataTable dt = helper.Instancia().querySql($"select * from VisDet where idFactura={id}", null);

            List<DetalleFactura> result = new List<DetalleFactura>();

            foreach (DataRow fila in dt.Rows)
            {
               DetalleFactura det = new DetalleFactura();
                det.aux = (decimal)fila[6];
                //AutoParte ap = new AutoParte();
                //det.AutoParte = ap;
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

        public List<Barrio> obtenerBarrios()
        {
            DataTable dt = helper.Instancia().querySql("select * from Barrios", null);
            List<Barrio> lst = new List<Barrio>();
            foreach (DataRow fila in dt.Rows)
            {
                Barrio barrio = new Barrio();
                barrio.id = (int)fila[0];
                barrio.nombre = fila[1].ToString();
                lst.Add(barrio);
            }
            return lst;
        }

        public List<Provincia> obtenerProvincias()
        {
            DataTable dt = helper.Instancia().querySql("select * from Provincias", null);
            List<Provincia> lst = new List<Provincia>();
            foreach (DataRow fila in dt.Rows)
            {
                Provincia prov = new Provincia();
                prov.id = (int)fila[0];
                prov.nombre = fila[1].ToString();
                lst.Add(prov);
            }
            return lst;
        }

        public List<Ciudad> obtenerCiudades()
        {
            DataTable dt = helper.Instancia().querySql("select * from Ciudades", null);
            List<Ciudad> lst = new List<Ciudad>();
            foreach (DataRow fila in dt.Rows)
            {
                Ciudad ciudad = new Ciudad();
                ciudad.id = (int)fila[0];
                ciudad.nombre = fila[1].ToString();
                lst.Add(ciudad);
            }
            return lst;
        }

        public List<Cliente> obtenerClientes(string apellido)
        {
            DataTable dt = helper.Instancia().querySql($"select * from VisClie where Apellido like '%{apellido}%' ", null);
            List<Cliente> result = new List<Cliente>();

            foreach (DataRow fila in dt.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = (int)fila[0];
                cliente.nombre = (string)fila[1];
                cliente.apellido = (string)fila[2];
                cliente.telefono = Convert.ToInt64(fila[3]);
                cliente.tipoCliente.tipoCliente = fila[4].ToString();
                cliente.direccion = fila[5].ToString();
                cliente.barrio.nombre = (string)fila[6].ToString();
                result.Add(cliente);
            }

            return result;
        }

        public List<Vendedor> obtenerVendedores(string apellido)
        {
            DataTable dt = helper.Instancia().querySql($"select * from VisVen where Apellido like '%{apellido}%' ", null);
            List<Vendedor> result = new List<Vendedor>();

            foreach (DataRow fila in dt.Rows)
            {
                Vendedor v = new Vendedor();
                v.idVendedor = (int)fila[0];
                v.nombre = (string)fila[1];
                v.apellido = fila[2].ToString();
                v.telefono = Convert.ToInt64(fila[3]);
                v.direccion = fila[4].ToString();
                v.barrio.nombre = fila[5].ToString();
                result.Add(v);
            }

            return result;
        }

        public int proxId()
        {
            return helper.Instancia().ConsultaEscalarSQL("spProxId", "@next");
        }
    }
}
