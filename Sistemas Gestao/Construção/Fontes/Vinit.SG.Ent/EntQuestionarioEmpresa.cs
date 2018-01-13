using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um QuestionarioEmpresa
    /// Questionario Aberto: FL_ATIVO = 0 e TX_PROTOCOLO IS NULL (respostas do questionário atual, ainda não enviado)
    /// Questionario Ativo: FL_ATIVO = 1 e TX_PROTOCOLO IS NOT NULL (relatório corrente)
    /// Questionario Histórico: FL_ATIVO = 0 e TX_PROTOCOLO IS NULL (histórico)
    /// </summary>
    [Serializable()]
    public class EntQuestionarioEmpresa
    {
        public Int32 IdQuestionarioEmpresa { get; set; }

        public DateTime DtCadastro { get; set; }

        public DateTime DtAlteracao { get; set; }

        public Boolean Ativo { get; set; }

        public Boolean Leitura { get; set; }

        public Boolean PreencheQuestionario { get; set; }

        public Boolean MarcaQuestoesEspeciais { get; set; }

        public String Protocolo { get; set; }

        public String MotivoVenceu { get; set; }

        public String Resumo { get; set; }

        public String MotivoExcluiu { get; set; }

        public Decimal TotalPontuacao { get; set; }

        public Decimal TotalPontuacaoAvaliacao { get; set; }

        public Boolean SincronizadoSiac { get; set; }

        public Boolean PassaProximaEtapa { get; set; }

        public Boolean ParaAvaliador { get; set; }

        public Boolean Excluido { get; set; }

        public Boolean EnviaQuestionario { get; set; }

        public Boolean RelatorioGerado { get; set; }

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

        private EntQuestionario _Questionario;
        public EntQuestionario Questionario
        {
            get
            {
                if (_Questionario == null)
                {
                    _Questionario = new EntQuestionario();
                }
                return _Questionario;
            }

            set { _Questionario = value; }
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

        private EntEtapa _Etapa;
        public EntEtapa Etapa
        {
            get
            {
                if (_Etapa == null)
                {
                    _Etapa = new EntEtapa();
                }
                return _Etapa;
            }

            set { _Etapa = value; }
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

        private List<EntQuestionarioEmpresaResposta> _ListQuestionarioEmpresaResposta;
        public List<EntQuestionarioEmpresaResposta> ListQuestionarioEmpresaResposta
        {
            get
            {
                if (_ListQuestionarioEmpresaResposta == null)
                {
                    _ListQuestionarioEmpresaResposta = new List<EntQuestionarioEmpresaResposta>();
                }
                return _ListQuestionarioEmpresaResposta;
            }

            set { _ListQuestionarioEmpresaResposta = value; }
        }

        private List<EntQuestionarioPontuacao> _ListQuestionarioPontuacao;
        public List<EntQuestionarioPontuacao> ListQuestionarioPontuacao
        {
            get
            {
                if (_ListQuestionarioPontuacao == null)
                {
                    _ListQuestionarioPontuacao = new List<EntQuestionarioPontuacao>();
                }
                return _ListQuestionarioPontuacao;
            }

            set { _ListQuestionarioPontuacao = value; }
        }

        private List<EntQuestionarioEmpresaAvaliador> _ListQuestionarioEmpresaAvaliador;
        public List<EntQuestionarioEmpresaAvaliador> ListQuestionarioEmpresaAvaliador
        {
            get
            {
                if (_ListQuestionarioEmpresaAvaliador == null)
                {
                    _ListQuestionarioEmpresaAvaliador = new List<EntQuestionarioEmpresaAvaliador>();
                }
                return _ListQuestionarioEmpresaAvaliador;
            }

            set { _ListQuestionarioEmpresaAvaliador = value; }
        }

    }
}
