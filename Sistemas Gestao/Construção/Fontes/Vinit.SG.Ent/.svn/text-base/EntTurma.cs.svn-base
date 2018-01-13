using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Turma
    /// </summary>
    [Serializable()]
    public class EntTurma
    {
        public Int32 IdTurma { get; set; }

        public Boolean Ativo { get; set; }

        public String Turma { get; set; }

        public DateTime DtCadastro { get; set; }

        public String Descricao { get; set; }
       
        public Boolean Privada { get; set; }

        public Boolean EmpresaInscrita { get; set; }

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


        private List<EntEtapa> _Etapas;
        public List<EntEtapa> Etapas
        {
            get
            {
                if (_Etapas == null)
                {
                    _Etapas = new List<EntEtapa>();
                }
                return _Etapas;
            }

            set { _Etapas = value; }
        }

        private List<EntEmpresaCadastro> _Empresas;
        public List<EntEmpresaCadastro> Empresas
        {
            get
            {
                if (_Empresas == null)
                {
                    _Empresas = new List<EntEmpresaCadastro>();
                }
                return _Empresas;
            }

            set { _Empresas = value; }
        }

        private List<EntTurmaQuestionario> _Questionarios;
        public List<EntTurmaQuestionario> Questionarios
        {
            get
            {
                if (_Questionarios == null)
                {
                    _Questionarios = new List<EntTurmaQuestionario>();
                }
                return _Questionarios;
            }

            set { _Questionarios = value; }
        }
    }
}
