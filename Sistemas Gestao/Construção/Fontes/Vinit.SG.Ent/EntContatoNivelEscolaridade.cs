using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um ContatoNivelEscolaridade
    /// </summary>
    [Serializable()]
    public class EntContatoNivelEscolaridade
    {
        public Int32 IdContatoNivelEscolaridade { get; set; }

        public String ContatoNivelEscolaridade { get; set; }

        public Int32 Ordem { get; set; }
    }
}
