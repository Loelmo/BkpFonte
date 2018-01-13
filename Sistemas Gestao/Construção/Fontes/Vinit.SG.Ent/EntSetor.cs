using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Setor
    /// </summary>
    [Serializable()]
    public class EntSetor
    {
        public Int32 IdSetor { get; set; }

        public String Setor { get; set; }

        public Boolean Ativo { get; set; }

    }
}
