using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddl.Dominio
{
    public class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Int64 telefono { get; set; }
        public string direccion { get; set; }
        public Barrio barrio { get; set; }
        public Provincia provincia { get; set; }
        public Ciudad ciudad { get; set; }



        public Persona()
        {
            barrio = new Barrio();
            provincia = new Provincia();
            ciudad = new Ciudad();
        }
    }
}
