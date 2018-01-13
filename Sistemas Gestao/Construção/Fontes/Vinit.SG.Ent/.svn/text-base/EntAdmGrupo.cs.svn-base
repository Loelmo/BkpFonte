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

        public Boolean Selecionado
        {
            get;
            set;
        }

        private EntPrograma _Programa;
        public EntPrograma Programa
        {
            get
            {
                if (_Programa == null)
                {
                    _Programa = new EntPrograma();
                }
                return _Programa;
            }

            set { _Programa = value; }
        }

    }
}
