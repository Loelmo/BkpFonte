using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa uma Funcionalidade
    /// </summary>
    [Serializable()]
    public class EntAdmFuncionalidade
    {
        public Int32 IdFuncionalidade
        {
            get;
            set;
        }

        private EntAdmTipoFuncionalidade _AdmTipoFuncionalidade;
        public EntAdmTipoFuncionalidade AdmTipoFuncionalidade
        {
            get
            {
                if (_AdmTipoFuncionalidade == null)
                {
                    _AdmTipoFuncionalidade = new EntAdmTipoFuncionalidade();
                }
                return _AdmTipoFuncionalidade;
            }

            set { _AdmTipoFuncionalidade = value; }
        }

        private EntAdmFuncionalidade _AdmFuncionalidadeOrigem;
        public EntAdmFuncionalidade AdmFuncionalidadeOrigem
        {
            get
            {
                if (_AdmFuncionalidadeOrigem == null)
                {
                    _AdmFuncionalidadeOrigem = new EntAdmFuncionalidade();
                }
                return _AdmFuncionalidadeOrigem;
            }

            set { _AdmFuncionalidadeOrigem = value; }
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

        public String Funcionalidade
        {
            get;
            set;
        }

        public String URL
        {
            get;
            set;
        }

        public String Table
        {
            get;
            set;
        }

        public Boolean MostraMenu
        {
            get;
            set;
        }
    }
}
