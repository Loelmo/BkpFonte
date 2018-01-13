using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Grupo
    /// </summary>
    [Serializable()]
    public class EntAdmGrupo
    {
        public Int32 IdGrupo
        {
            get;
            set;
        }

        public String Grupo
        {
            get;
            set;
        }

        public String Descricao
        {
            get;
            set;
        }
    }
}
