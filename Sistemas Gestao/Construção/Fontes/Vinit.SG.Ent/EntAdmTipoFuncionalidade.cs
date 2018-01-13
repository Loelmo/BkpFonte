using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Tipo de Funcionalidade
    /// </summary>
    [Serializable()]
    public class EntAdmTipoFuncionalidade
    {
        public Int32 IdTipoFuncionalidade
        {
            get;
            set;
        }

        public String TipoFuncionalidade
        {
            get;
            set;
        }
    }
}
