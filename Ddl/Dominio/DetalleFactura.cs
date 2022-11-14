using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddl.Dominio
{
    public class DetalleFactura
    {
        public int idDetalleNro { get; set; }
        public AutoParte AutoParte { get; set; }
        public int cantidad { get; set; }
        public int bonificacion { get; set; }
        public int descuento { get; set; }

        public DetalleFactura()
        {
            AutoParte = new AutoParte();
        }

        public decimal subTotal()
        {
            if (bonificacion == 1)
            {
                decimal sub = (cantidad * AutoParte.precio);
                return sub - ((sub * descuento) / 100);
            }
            else
            {
                return cantidad * AutoParte.precio;
            }
        }
    }
}
