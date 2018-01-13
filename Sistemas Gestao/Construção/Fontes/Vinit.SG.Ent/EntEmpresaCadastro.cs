using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa uma Empresa Cadastro
    /// </summary>
    [Serializable()]
    public class EntEmpresaCadastro
    {
        public Int32 IdEmpresaCadastro { get; set; }

        public String RazaoSocial { get; set; }

        public String NomeFantasia { get; set; }

        public String CPF_CNPJ { get; set; }

        public Boolean PessoaJuridica { get; set; }

        public Boolean Ativo { get; set; }

        public DateTime AberturaEmpresa { get; set; }

        public Boolean ParticipouMPE2006 { get; set; }

        public Boolean ParticipouMPE2007 { get; set; }

        public Boolean ParticipouMPE2008 { get; set; }

        public Boolean ParticipouMPE2009 { get; set; }

        public Boolean ParticipouMPE2010 { get; set; }

        public Boolean ParticipouMPE2011 { get; set; }

        public Int32 Count { get; set; }

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

        private EntProgramaEmpresa _ProgramaEmpresa;
        public EntProgramaEmpresa ProgramaEmpresa
        {
            get
            {
                if (_ProgramaEmpresa == null)
                {
                    _ProgramaEmpresa = new EntProgramaEmpresa();
                }
                return _ProgramaEmpresa;
            }

            set { _ProgramaEmpresa = value; }
        }

    }
}
