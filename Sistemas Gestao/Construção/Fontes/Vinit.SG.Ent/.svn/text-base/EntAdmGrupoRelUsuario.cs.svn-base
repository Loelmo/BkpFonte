using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa uma Relação de Grupo com EntUsuario
    /// </summary>
    [Serializable()]
    public class EntAdmGrupoRelUsuario
    {

        public Int32 IdGrupoUsuario { get; set; }

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

        private EntEscritorioRegional _EscritorioRegional;
        public EntEscritorioRegional EscritorioRegional
        {
            get
            {
                if (_EscritorioRegional == null)
                {
                    _EscritorioRegional = new EntEscritorioRegional();
                }
                return _EscritorioRegional;
            }

            set { _EscritorioRegional = value; }
        }

        private EntEstado _Estado;
        public EntEstado Estado
        {
            get
            {
                if (_Estado == null)
                {
                    _Estado = new EntEstado();
                }
                return _Estado;
            }

            set { _Estado = value; }
        }

        private EntTurma _Turma;
        public EntTurma Turma
        {
            get
            {
                if (_Turma == null)
                {
                    _Turma = new EntTurma();
                }
                return _Turma;
            }

            set { _Turma = value; }
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

        private List<EntAdmUsuario> _lstUsuarioAssociados;
        public List<EntAdmUsuario> lstUsuarioAssociados
        {
            get
            {
                if (_lstUsuarioAssociados == null)
                {
                    _lstUsuarioAssociados = new List<EntAdmUsuario>();
                }
                return _lstUsuarioAssociados;
            }

            set { _lstUsuarioAssociados = value; }
        }

        private List<EntAdmUsuario> _lstUsuarioDisponiveis;
        public List<EntAdmUsuario> lstUsuarioDisponiveis
        {
            get
            {
                if (_lstUsuarioDisponiveis == null)
                {
                    _lstUsuarioDisponiveis = new List<EntAdmUsuario>();
                }
                return _lstUsuarioDisponiveis;
            }

            set { _lstUsuarioDisponiveis = value; }
        }

    }
}
