using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Categoria
    /// </summary>
    [Serializable()]
    public class EntCategoria
    {
        public Int32 IdCategoria { get; set; }

        public String Categoria { get; set; }

        public Boolean Ativo { get; set; }

        public Boolean AceitaCpf { get; set; }
    }
}
