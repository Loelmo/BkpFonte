using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Chamado
    /// </summary>
    [Serializable()]
    public class EntChamado
    {
        public Int32 IdChamado { get; set; }

        public enum EnumStatus
        {
            Novo = 1,
            Iniciado = 2,
            Finalizado = 3,
            Cancelado = 4
        }

        public EnumStatus Status { get; set; }

        public String Chamado { get; set; }

        public DateTime Cadastro { get; set; }

        public DateTime Alteracao { get; set; }

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
