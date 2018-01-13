using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um FaturamentoTipo
    /// </summary>
    [Serializable()]
    public class EntFaturamentoTipo
    {
        public Int32 IdFaturamentoTipo { get; set; }

        public String FaturamentoTipo { get; set; }

        public Boolean Ativo { get; set; }
    }
}
