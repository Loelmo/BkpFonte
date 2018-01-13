using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Log Ação
    /// </summary>
    [Serializable()]
    public class EntLogAcao
    {
        public Int32 IdLogAcao { get; set; }

        public String LogAcao { get; set; }

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

        private EntTipoAcao _TipoAcao;
        public EntTipoAcao TipoAcao
        {
            get
            {
                if (_TipoAcao == null)
                {
                    _TipoAcao = new EntTipoAcao();
                }
                return _TipoAcao;
            }

            set { _TipoAcao = value; }
        }
    }
}
