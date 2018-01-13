using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa uma Turma Empresa
    /// </summary>
    [Serializable()]
    public class EntTurmaEmpresa
    {
        public DateTime Cadastro { get; set; }

        public Int32 NumeroFuncionario { get; set; }

        public String CEP { get; set; }

        public String CEPContato { get; set; }

        public String Endereco { get; set; }

        public String Complemento { get; set; }

        public String NumeroEndereco { get; set; }

        public Boolean Ativo { get; set; }

        public DateTime UltimaAlteracao { get; set; }

        public String AtividadeEconomicaComplemento { get; set; }

        public Boolean ParticipaPrograma { get; set; }

        public Boolean Pergunta1 { get; set; }

        public Boolean Pergunta2 { get; set; }

        public Boolean Pergunta3 { get; set; }

        public Boolean Pergunta4 { get; set; }

        public String NomeContato { get; set; }

        public String TelefoneContato { get; set; }

        public String CelularContato { get; set; }

        public String EmailContato { get; set; }

        public String MensagemContato { get; set; }

        public String CPFContato { get; set; }

        private DateTime _NascimentoContato;

        public DateTime NascimentoContato
        {
            get { 
                if (_NascimentoContato == new DateTime())
                {
                     _NascimentoContato = new DateTime(1753, 1, 1);
                }
                return _NascimentoContato;
            
            }
            set { _NascimentoContato = value; }
        } 

        public String EnderecoContato { get; set; }

        public String ComplementoContato { get; set; }

        public String NumeroEnderecoContato { get; set; }

        public String SexoContato { get; set; }

        public Int32 Status { get; set; }

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

        private EntCargo _Cargo;
        public EntCargo Cargo
        {
            get
            {
                if (_Cargo == null)
                {
                    _Cargo = new EntCargo();
                }
                return _Cargo;
            }

            set { _Cargo = value; }
        }

        private EntCategoria _Categoria;
        public EntCategoria Categoria
        {
            get
            {
                if (_Categoria == null)
                {
                    _Categoria = new EntCategoria();
                }
                return _Categoria;
            }

            set { _Categoria = value; }
        }

        private EntAtividadeEconomica _AtividadeEconomica;
        public EntAtividadeEconomica AtividadeEconomica
        {
            get
            {
                if (_AtividadeEconomica == null)
                {
                    _AtividadeEconomica = new EntAtividadeEconomica();
                }
                return _AtividadeEconomica;
            }

            set { _AtividadeEconomica = value; }
        }

        private EntFaturamento _Faturamento;
        public EntFaturamento Faturamento
        {
            get
            {
                if (_Faturamento == null)
                {
                    _Faturamento = new EntFaturamento();
                }
                return _Faturamento;
            }

            set { _Faturamento = value; }
        }

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

        private EntPais _Pais;
        public EntPais Pais
        {
            get
            {
                if (_Pais == null)
                {
                    _Pais = new EntPais();
                }
                return _Pais;
            }

            set { _Pais = value; }
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

        private EntCidade _Cidade;
        public EntCidade Cidade
        {
            get
            {
                if (_Cidade == null)
                {
                    _Cidade = new EntCidade();
                }
                return _Cidade;
            }

            set { _Cidade = value; }
        }

        private EntBairro _Bairro;
        public EntBairro Bairro
        {
            get
            {
                if (_Bairro == null)
                {
                    _Bairro = new EntBairro();
                }
                return _Bairro;
            }

            set { _Bairro = value; }
        }

        private EntEstado _EstadoContato;
        public EntEstado EstadoContato
        {
            get
            {
                if (_EstadoContato == null)
                {
                    _EstadoContato = new EntEstado();
                }
                return _EstadoContato;
            }

            set { _EstadoContato = value; }
        }

        private EntCidade _CidadeContato;
        public EntCidade CidadeContato
        {
            get
            {
                if (_CidadeContato == null)
                {
                    _CidadeContato = new EntCidade();
                }
                return _CidadeContato;
            }

            set { _CidadeContato = value; }
        }

        private EntBairro _BairroContato;
        public EntBairro BairroContato
        {
            get
            {
                if (_BairroContato == null)
                {
                    _BairroContato = new EntBairro();
                }
                return _BairroContato;
            }

            set { _BairroContato = value; }
        }

        private EntTipoEmpresa _TipoEmpresa;
        public EntTipoEmpresa TipoEmpresa
        {
            get
            {
                if (_TipoEmpresa == null)
                {
                    _TipoEmpresa = new EntTipoEmpresa();
                }
                return _TipoEmpresa;
            }

            set { _TipoEmpresa = value; }
        }

        private EntContatoNivelEscolaridade _ContatoNivelEscolaridade;
        public EntContatoNivelEscolaridade ContatoNivelEscolaridade
        {
            get
            {
                if (_ContatoNivelEscolaridade == null)
                {
                    _ContatoNivelEscolaridade = new EntContatoNivelEscolaridade();
                }
                return _ContatoNivelEscolaridade;
            }

            set { _ContatoNivelEscolaridade = value; }
        }

        private EntContatoFaixaEtaria _FaixaEtaria;
        public EntContatoFaixaEtaria FaixaEtaria
        {
            get
            {
                if (_FaixaEtaria == null)
                {
                    _FaixaEtaria = new EntContatoFaixaEtaria();
                }
                return _FaixaEtaria;
            }

            set { _FaixaEtaria = value; }
        }

        private List<EntQuestionarioEmpresa> _ListQuestionarioEmpresa;
        public List<EntQuestionarioEmpresa> ListQuestionarioEmpresa
        {
            get
            {
                if (_ListQuestionarioEmpresa == null)
                {
                    _ListQuestionarioEmpresa = new List<EntQuestionarioEmpresa>();
                }
                return _ListQuestionarioEmpresa;
            }

            set { _ListQuestionarioEmpresa = value; }
        }

        public Boolean ParticipaEmpreendedorismo { get; set; }
        public Boolean ParticipaResponsabilidadeSocial { get; set; }
        public Boolean EtapaAtiva { get; set; }
    }
}
