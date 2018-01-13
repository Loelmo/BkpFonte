using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Cargo
    /// </summary>
    [Serializable()]
    public class EntCargo
    {
        public Int32 IdCargo { get; set; }

        public Int32 Codigo { get; set; }

        public String Cargo { get; set; }

    }
}
