using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Ddl.Dominio;

namespace Ddl.Datos
{
    public class helper
    {
        private static SqlConnection cnn;
        private static string cnnStringg = @"Data Source=.\SQLEXPRESS;Initial Catalog=autoPartes;Integrated Security=True";

       

        private static helper instancia;

        private helper()
        {
            cnn = new SqlConnection(cnnStringg);
        }

        public static helper Instancia()
        {
            if (instancia == null)
            {
                instancia = new helper();
            }
            return instancia;
        }
        public DataTable ConsultaSQL(string spNombre, List<Parametro> values)
        {
            DataTable tabla = new DataTable();

            cnn.Open();
            SqlCommand cmd = new SqlCommand(spNombre, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
            {
                foreach (Parametro oParametro in values)
                {
                    cmd.Parameters.AddWithValue(oParametro.clave, oParametro.valor);
                }
            }
            tabla.Load(cmd.ExecuteReader());

            cnn.Close();

            return tabla;
        }

        public int ConsultaEscalarSQL(string spNombre, string pOutNombre)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand(spNombre, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = pOutNombre;
            pOut.DbType = DbType.Int32;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();
            cnn.Close();

            return (int)pOut.Value;
        }


        public bool EjecutarSQL(string strSql, List<Parametro> values)
        {
            bool ok = true;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Transaction = t;

                if (values != null)
                {
                    foreach (Parametro param in values)
                    {
                        cmd.Parameters.AddWithValue(param.clave, param.valor);
                    }
                }

                cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null) 
                { t.Rollback();
                    ok = false;
                }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }

            return ok;
        }

        public SqlConnection ObtenerConexion()
        {
            return cnn;
        }
        public DataTable listarProductos()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from vis_AutoPartes", cnn);
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;
        }

        public DataTable querySql(string txt, List<Parametro> values)
        {
            DataTable tabla = new DataTable();

            cnn.Open();
            SqlCommand cmd = new SqlCommand(txt, cnn);
            cmd.CommandType = CommandType.Text;
            if (values != null)
            {
                foreach (Parametro oParametro in values)
                {
                    cmd.Parameters.AddWithValue(oParametro.clave, oParametro.valor);
                }
            }
            tabla.Load(cmd.ExecuteReader());

            cnn.Close();

            return tabla;
        }
        public DataTable querySqlParam(string txt, List<SqlParameter> values)
        {
            DataTable tabla = new DataTable();

            cnn.Open();
            SqlCommand cmd = new SqlCommand(txt, cnn);
            cmd.CommandType = CommandType.Text;
            if (values != null)
            {
                foreach (SqlParameter oParametro in values)
                {
                    cmd.Parameters.AddWithValue(oParametro.ParameterName, oParametro.Value);
                }
            }
            tabla.Load(cmd.ExecuteReader());

            cnn.Close();

            return tabla;
        }
        public bool EjecutarSQLAP(string strSql,AutoParte ap)
        {
            bool ok = true;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Transaction = t;
                
                cmd.Parameters.AddWithValue("@descripcion", ap.descripcion.ToString());
                cmd.Parameters.AddWithValue("@fecha_fab", ap.fechaFabricacion.ToShortDateString());
                cmd.Parameters.AddWithValue("@id_tipo_produccion", ap.tipoProduccion.id);
                cmd.Parameters.AddWithValue("@activo", ap.activo);
                cmd.Parameters.AddWithValue("@precio", ap.precio);
                cmd.Parameters.AddWithValue("@idMarca", ap.Marca.id);
                cmd.Parameters.AddWithValue("@idModelo", ap.Modelo.id);

                cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                    ok = false;
                }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }

            return ok;
        }

        public bool insertFactura(Factura f)
        {
            bool ok = true;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_FACTURA",cnn,t);
                cnn.Open();
                t = cnn.BeginTransaction();
      
                cmd.CommandType = CommandType.StoredProcedure;
                

                cmd.Parameters.AddWithValue("@fecha",f.fechaFactura);
                cmd.Parameters.AddWithValue("@idCliente", f.cliente.idCliente);
                cmd.Parameters.AddWithValue("@idVendedor", f.vendedor.idVendedor);

                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@idFactura";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);


                cmd.ExecuteNonQuery();

                int idFactura = Convert.ToInt32(pOut.Value);

                foreach (DetalleFactura dt in f.detalleFactura)
                {
                    SqlCommand command = new SqlCommand("SP_INSERT_DETALLE_FACTURA", cnn, t);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@idFactura", idFactura);
                    command.Parameters.AddWithValue("@idArticulo", dt.AutoParte.idArticulo);

                    command.Parameters.AddWithValue("@cantidad", dt.cantidad);

                    command.Parameters.AddWithValue("@bonificacion", dt.bonificacion);

                    command.Parameters.AddWithValue("@descuento", dt.descuento);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }




                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                    ok = false;
                }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }

            return ok;
        }




    }
}
