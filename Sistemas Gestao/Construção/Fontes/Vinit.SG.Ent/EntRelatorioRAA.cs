using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de relatorio que representa uma RAA
    /// </summary>
    [Serializable()]
    public class EntRelatorioRAA
    {
        public Int32 Ano { get; set; }
        public DateTime DataEnvio { get; set; }
        public Double CriterioCliente { get; set; }
        public Double CriterioSociedade { get; set; }
        public Double CriterioLideranca { get; set; }
        public Double CriterioEstrategiaPlano { get; set; }
        public Double CriterioPessoa { get; set; }
        public Double CriterioProcesso { get; set; }
        public Double CriterioInformacaoConhecimento { get; set; }
        public Double CriterioResultadoControle { get; set; }
        public Double CriterioResultadoTendencia { get; set; }
        public Double TotalGestao { get; set; }
        public Double AvaliacaoEmpreendedor { get; set; }
        public Double AvaliacaoResponsabilidadeSocial { get; set; }
        public Double AvaliacaoInovacao { get; set; }
        public Boolean Avaliador { get; set; }
        public String Protocolo { get; set; }
        public Int32 Programa { get; set; }
        public Int32 TipoEtapa { get; set; }

        public String Categoria { get; set; }
        public String AtividadeEconomica { get; set; }
        public String Faturamento { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public String Cargo { get; set; }
        public String EmailContato { get; set; }

    }
}
