using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Questionario Empresa Resposta
    /// </summary>
    [Serializable()]
    public class EntQuestionarioEmpresaResposta
    {

        private EntQuestionarioEmpresa _QuestionarioEmpresa;
        public EntQuestionarioEmpresa QuestionarioEmpresa
        {
            get
            {
                if (_QuestionarioEmpresa == null)
                {
                    _QuestionarioEmpresa = new EntQuestionarioEmpresa();
                }
                return _QuestionarioEmpresa;
            }

            set { _QuestionarioEmpresa = value; }
        }

        private EntPergunta _Pergunta;
        public EntPergunta Pergunta
        {
            get
            {
                if (_Pergunta == null)
                {
                    _Pergunta = new EntPergunta();
                }
                return _Pergunta;
            }

            set { _Pergunta = value; }
        }

        private EntPerguntaResposta _Resposta;
        public EntPerguntaResposta Resposta
        {
            get
            {
                if (_Resposta == null)
                {
                    _Resposta = new EntPerguntaResposta();
                }
                return _Resposta;
            }

            set { _Resposta = value; }
        }

        private EntAdmUsuario _UsuarioDigitador;
        public EntAdmUsuario UsuarioDigitador
        {
            get
            {
                if (_UsuarioDigitador == null)
                {
                    _UsuarioDigitador = new EntAdmUsuario();
                }
                return _UsuarioDigitador;
            }

            set { _UsuarioDigitador = value; }
        }

        private EntAdmUsuario _UsuarioAvaliador;
        public EntAdmUsuario UsuarioAvaliador
        {
            get
            {
                if (_UsuarioAvaliador == null)
                {
                    _UsuarioAvaliador = new EntAdmUsuario();
                }
                return _UsuarioAvaliador;
            }

            set { _UsuarioAvaliador = value; }
        }

        public String RespostaTexto { get; set; }

        public String Justificativa { get; set; }

        public String OportunidadeMelhoria { get; set; }

        public String PontoForte { get; set; }

        public Boolean RespostaBool { get; set; }

        public String Valor01 { get; set; }

        public String Valor02 { get; set; }

        public String Valor03 { get; set; }

        public String Valor04 { get; set; }

        public String Valor05 { get; set; }

        public String Valor06 { get; set; }

        public String Valor07 { get; set; }

        public String Valor08 { get; set; }

        public String Valor09 { get; set; }

        public String Valor10 { get; set; }

    }
}
