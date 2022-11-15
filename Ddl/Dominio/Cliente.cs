using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddl.Dominio
{
    public class Cliente : Persona
    {
        public int idCliente { get; set; }
        public TipoCliente tipoCliente { get; set; }

        public Cliente() : base()
        {
            tipoCliente = new TipoCliente();
        }
    }
}
