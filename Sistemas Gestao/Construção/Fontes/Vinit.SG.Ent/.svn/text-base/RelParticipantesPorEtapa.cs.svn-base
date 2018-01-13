using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    public class RelParticipantesPorEtapa
    {
        public Int32 TotalInscritas { get; set; }
        public Int32 TotalCandidatas { get; set; }
        public Int32 TotalClassificadas { get; set; }
        public Int32 TotalFinalistasGestao { get; set; }
        public Int32 TotalFinalistasRespSocial { get; set; }
        public Int32 TotalFinalistasInovacao { get; set; }
        public Int32 TotalVencedoraGestao { get; set; }
        public Int32 TotalVencedoraRespSocial { get; set; }
        public Int32 TotalVencedoraInovacao { get; set; }

        /*public Double PercTotalInscritas { get; set; }
        public Double PercTotalCandidatas { get; set; }
        public Double PercTotalClassificadas { get; set; }
        public Double PercTotalFinalistasGestao { get; set; }
        public Double PercTotalFinalistasRespSocial { get; set; }
        public Double PercTotalFinalistasInovacao { get; set; }
        public Double PercTotalVencedoraGestao { get; set; }
        public Double PercTotalVencedoraRespSocial { get; set; }
        public Double PercTotalVencedoraInovacao { get; set; }*/

        public Int32 TotalInscritasPorTurma { get; set; }
        public Int32 TotalCandidatasPorTurma { get; set; }
        public Int32 TotalClassificadasPorTurma { get; set; }
        public Int32 TotalFinalistasGestaoPorTurma { get; set; }
        public Int32 TotalFinalistasRespSocialPorTurma { get; set; }
        public Int32 TotalFinalistasInovacaoPorTurma { get; set; }
        public Int32 TotalVencedoraGestaoPorTurma { get; set; }
        public Int32 TotalVencedoraRespSocialPorTurma { get; set; }
        public Int32 TotalVencedoraInovacaoPorTurma { get; set; }
        

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
    }
}
