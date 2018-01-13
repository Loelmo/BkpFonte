using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Questionario Empresa Avaliador
    /// </summary>
    [Serializable()]
    public class EntQuestionarioEmpresaAvaliador
    {
        public Int32 IdQuestionarioEmpresaAvaliador { get; set; }

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

        public String MotivoDevolucao { get; set; }

        public String MelhorPratica { get; set; }

        public String Banca { get; set; }

        public Boolean Avaliado { get; set; }

        public Boolean Primario { get; set; }
    }
}
