using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um TipoEstado
    /// </summary>
    [Serializable()]
    public class EntTipoEtapa
    {
        public const int TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_EMPRESA = 10;
        public const int TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_ADMINISTRATIVO = 11;
        public const int TIPO_ETAPA_MPE_CLASSIFICACAO_ESTADUAL = 9;
        public const int TIPO_ETAPA_MPE_AVALIACAO_ESTADUAL = 12;
        public const int TIPO_ETAPA_MPE_JULGAMENTO_FINALISTAS_ESTADUAL = 13;
        public const int TIPO_ETAPA_MPE_ENCERRAMENTO_ESTADUAL = 14;
        public const int TIPO_ETAPA_MPE_CLASSIFICACAO_NACIONAL = 15;
        public const int TIPO_ETAPA_MPE_AVALIACAO_NACIONAL = 16;
        public const int TIPO_ETAPA_MPE_JULGAMENTO_FINALISTAS_NACIONAL = 17;
        public const int TIPO_ETAPA_MPE_ENCERRAMENTO_NACIONAL = 18;

        public const int TIPO_ETAPA_FGA_INSCRICAO_AUTODIAGNOSTICO_EMPRESA = 3;
        public const int TIPO_ETAPA_FGA_INSCRICAO_AUTODIAGNOSTICO_ADMINISTRATIVO = 4;
        public const int TIPO_ETAPA_FGA_VALIDACAO_RESPOSTAS = 5;
        public const int TIPO_ETAPA_FGA_PRE_CLASSIFICADAS = 6;
        public const int TIPO_ETAPA_FGA_FASE_4 = 7;
        public const int TIPO_ETAPA_FGA_ENCERRAMENTO = 8;

        public const int TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_EMPRESA = 19;
        public const int TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_ADMINISTRATIVO = 20;
        public const int TIPO_ETAPA_PEG_VALIDACAO_RESPOSTAS = 21;
        public const int TIPO_ETAPA_PEG_PRE_CLASSIFICADAS = 22;
        public const int TIPO_ETAPA_PEG_FASE_2 = 23;
        public const int TIPO_ETAPA_PEG_FASE_3 = 24;
        public const int TIPO_ETAPA_PEG_FASE_4 = 25;
        public const int TIPO_ETAPA_PEG_ENCERRAMENTO = 26;

        public Int32 IdTipoEtapa { get; set; }

        public String TipoEtapa { get; set; }

        public Int32 OrdemFluxo { get; set; }

        public Boolean InativaEtapasAnteriores { get; set; }

        public Boolean EtapaNacional { get; set; }

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
