using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddl.Datos
{
    public class Parametro
    {
        public string clave { get; set; }
        public string valor { get; set; }

        public Parametro(string clave, string valor)
        {
            this.clave = clave;
            this.valor = valor;
        }
    }
}
