using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddl.Dominio
{
    public class AutoParte
    {
        public int idArticulo { get; set; }
        public string descripcion { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public DateTime fechaFabricacion { get; set; }
        public tipoProduccion tipoProduccion { get; set; }
        public int activo { get; set; }
        public decimal precio { get; set; }

        public AutoParte()
        {
            Marca = new Marca();
            Modelo = new Modelo();
            tipoProduccion = new tipoProduccion();
        }
    }
}
