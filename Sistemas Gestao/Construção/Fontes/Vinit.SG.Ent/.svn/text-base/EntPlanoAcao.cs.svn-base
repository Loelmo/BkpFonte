using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um PlanoAcao
    /// </summary>
    [Serializable()]
    public class EntPlanoAcao
    {
        public Int32 IdPlanoAcao { get; set; }

        public DateTime DtCadastro { get; set; }

        public DateTime DtAlteracao { get; set; }

        public Boolean Ativo { get; set; }

        public Boolean Evolucao { get; set; }

        public String PlanoAcao { get; set; }

        public String PontoMelhoria { get; set; }

        public String AcaoCorrespondente { get; set; }

        public String Responsavel { get; set; }

        public String Prazo { get; set; }

        private EntAdmUsuario _Usuario;
        public EntAdmUsuario Usuario
        {
            get
            {
                if (_Usuario == null)
                {
                    _Usuario = new EntAdmUsuario();
                }
                return _Usuario;
            }

            set { _Usuario = value; }
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

        private EntEmpresaCadastro _EmpresaCadastro;
        public EntEmpresaCadastro EmpresaCadastro
        {
            get
            {
                if (_EmpresaCadastro == null)
                {
                    _EmpresaCadastro = new EntEmpresaCadastro();
                }
                return _EmpresaCadastro;
            }

            set { _EmpresaCadastro = value; }
        }

    }
}
