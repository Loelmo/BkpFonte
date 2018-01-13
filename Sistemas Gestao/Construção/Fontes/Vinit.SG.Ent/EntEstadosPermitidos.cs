using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    public class EntEstadosPermitidos : EntEstado
    {
        public EntEstadosPermitidos()
        {

        }

        public EntEstadosPermitidos(Int32 IdEstado, String Nome)
        {
            this.IdEstado = IdEstado;
            this.Estado = Nome;
        }

        public Int32 IdTurma { get; set; }

        public String Funcionalidade { get; set; }

    }
}
