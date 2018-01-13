using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa uma Funcionalidade x FuncionalidadeGrupo
    /// </summary>
    [Serializable()]
    public class EntAdmFuncionalidadeRelGrupoCustom
    {
        public Int32 IdFuncionalidade
        {
            get;
            set;
        }

        public String Funcionalidade
        {
            get;
            set;
        }


        private EntAdmGrupo _AdmGrupo;
        public EntAdmGrupo AdmGrupo
        {
            get
            {
                if (_AdmGrupo == null)
                {
                    _AdmGrupo = new EntAdmGrupo();
                }
                return _AdmGrupo;
            }

            set { _AdmGrupo = value; }
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

        public Boolean Inserir
        {
            get;
            set;
        }

        public Boolean Atualizar
        {
            get;
            set;
        }

        public Boolean Excluir
        {
            get;
            set;
        }

        public Boolean Visualizar
        {
            get;
            set;
        }

    }
}
