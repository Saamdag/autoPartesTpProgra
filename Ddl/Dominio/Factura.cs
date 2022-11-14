using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddl.Dominio
{
    public class Factura
    {
        public int idFactura { get; set; }
        public DateTime fechaFactura { get; set; }
        public Cliente cliente { get; set; }
        public Vendedor vendedor { get; set; }
        public List<DetalleFactura> detalleFactura { get; set; }


        public Factura()
        {
            fechaFactura = DateTime.Now;
            cliente = new Cliente();
            vendedor = new Vendedor();
            detalleFactura = new List<DetalleFactura>();
        }

        public void AgregarDetalle(DetalleFactura oDetalle)
        {
            detalleFactura.Add(oDetalle);
        }

        public void QuitarDetalle(int indice)
        {
            detalleFactura.RemoveAt(indice);
        }

        public decimal total()
        {
            decimal total = 0;
            foreach (DetalleFactura dt in detalleFactura)
            {
                total += dt.subTotal();
            }

            return total;
        }
    }
}
