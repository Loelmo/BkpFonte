using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Atendimento
    /// </summary>
    [Serializable()]
    public class EntAtendimento
    {
        public Int32 IdAtendimento { get; set; }

        public String Titulo { get; set; }

        public String Descricao { get; set; }

        public Boolean Ativo { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public DateTime DataCadastroFiltroInicial { get; set; }

        public DateTime DataCadastroFiltroFinal { get; set; }

        public Int32 IdEstado { get; set; }

        private EntAtendimentoStatus _AtendimentoStatus;
        public EntAtendimentoStatus AtendimentoStatus
        {
            get
            {
                if (_AtendimentoStatus == null)
                {
                    _AtendimentoStatus = new EntAtendimentoStatus();
                }
                return _AtendimentoStatus;
            }

            set { _AtendimentoStatus = value; }
        }

        private EntAtendimentoTipo _AtendimentoTipo;
        public EntAtendimentoTipo AtendimentoTipo
        {
            get
            {
                if (_AtendimentoTipo == null)
                {
                    _AtendimentoTipo = new EntAtendimentoTipo();
                }
                return _AtendimentoTipo;
            }

            set { _AtendimentoTipo = value; }
        }

        private EntAtendimentoSistema _AtendimentoSistema;
        public EntAtendimentoSistema AtendimentoSistema
        {
            get
            {
                if (_AtendimentoSistema == null)
                {
                    _AtendimentoSistema = new EntAtendimentoSistema();
                }
                return _AtendimentoSistema;
            }

            set { _AtendimentoSistema = value; }
        }

        private EntAdmUsuario _UsuarioResponsavel;
        public EntAdmUsuario UsuarioResponsavel
        {
            get
            {
                if (_UsuarioResponsavel == null)
                {
                    _UsuarioResponsavel = new EntAdmUsuario();
                }
                return _UsuarioResponsavel;
            }

            set { _UsuarioResponsavel = value; }
        }

        private EntAdmUsuario _UsuarioOrigem;
        public EntAdmUsuario UsuarioOrigem
        {
            get
            {
                if (_UsuarioOrigem == null)
                {
                    _UsuarioOrigem = new EntAdmUsuario();
                }
                return _UsuarioOrigem;
            }

            set { _UsuarioOrigem = value; }
        }

        private EntEmpresaCadastro _EmpresaOrigem;
        public EntEmpresaCadastro EmpresaOrigem
        {
            get
            {
                if (_EmpresaOrigem == null)
                {
                    _EmpresaOrigem = new EntEmpresaCadastro();
                }
                return _EmpresaOrigem;
            }

            set { _EmpresaOrigem = value; }
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
