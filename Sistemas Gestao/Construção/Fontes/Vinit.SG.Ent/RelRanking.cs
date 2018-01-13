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
    public class RelRanking
    {
        public Int32 IdEmpresaCadastro { get; set; }
        public Int32 IdQuestionarioEmpresa { get; set; }
        public Int32 IdEtapa { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdFaturamento { get; set; }
        public Int32 NumeroFuncionarios { get; set; }
        public DateTime DataAbertura { get; set; }
        public String CpfCnpj { get; set; }
        public String RazaoSocial { get; set; }
        public String Protocolo { get; set; }
        public Boolean PassaProximaFase { get; set; }
        public Boolean Excluido { get; set; }
        public Boolean EtapaAtiva { get; set; }
        public Boolean MarcaQuestoesEspeciais { get; set; }
        public Double PontuacaoTotalPosVisita { get; set; } //- pontuação da Avaliação da Gestão.
        public Double EnfoquePosVisita { get; set; } //– pontuação da Avaliação da Gestão sem a pontuação do Critério Resultados.
        public Double ResultadoControlePosVisita { get; set; } //– pontuação da Avaliação da Gestão relativa ao Controle do Critério Resultados.
        public Double ResultadoTendenciaPosVisita { get; set; } //– pontuação da Avaliação da Gestão relativa à Tendência do Critério Resultados.
        public Double TotalEmpreendendorismoPosVisita { get; set; } //– pontuação total do Questionário de Empreendedorismo.
        public Double CriterioClientePosVisita { get; set; }
        public Double CriterioSociedadePosVisita { get; set; }
        public Double CriterioLiderancaPosVisita { get; set; }
        public Double CriterioEstrategiaPlanosPosVisita { get; set; }
        public Double CriterioPessoasPosVisita { get; set; }
        public Double CriterioProcessosPosVisita { get; set; }
        public Double CriterioInformacoesConhecimentoPosVisita { get; set; }
        
        public Double PontuacaoRankingPreVisita { get; set; }//– pontuação do Total de Enfoque mais Total Resultados (Controle).
        public Double EnfoquePreVisita { get; set; }//– pontuação do Questionário de Gestão sem a pontuação do Critério Resultados.
        public Double ResultadoControlePreVisita { get; set; }//– pontuação do Questionário de Gestão relativa ao Controle do Critério Resultados.
        public Double ResultadoTendenciaPreVisita { get; set; }//– pontuação do Questionário de Gestão relativa à Tendência do Critério Resultados.
        public Double PontuacaoTotalPreVisita { get; set; }//– pontuação total do Questionário de Gestão.
        public Double CriterioClientePreVisita { get; set; }
        public Double CriterioSociedadePreVisita { get; set; }
        public Double CriterioLiderancaPreVisita { get; set; }
        public Double CriterioEstrategiaPlanosPreVisita { get; set; }
        public Double CriterioPessoasPreVisita { get; set; }
        public Double CriterioProcessosPreVisita { get; set; }
        public Double CriterioInformacoesConhecimentoPreVisita { get; set; }
        public Double PontuacaoTotalResponsabilidadeSocial { get; set; }
        public Double PontuacaoTotalInovacao { get; set; }

        public Double MaiorNotaPreVisita { get; set; }
        public Double MaiorNotaPosVisita { get; set; }

        public Double RelacaoMelhorCategoriaPreVisita
        {
            get
            {
                if (MaiorNotaPreVisita > 0)
                {
                    return (PontuacaoTotalPreVisita * 100) / MaiorNotaPreVisita;
                }
                else
                {
                    return 0;
                }
            }
        } //– relação percentual entre a pontuação da empresa e a melhor das empresas selecionadas.

        public Double RelacaoMelhorCategoriaPosVisita 
        { 
            get
            {
                if (MaiorNotaPosVisita > 0)
                {
                    return (PontuacaoTotalPosVisita * 100) / MaiorNotaPosVisita;
                }
                else
                {
                    return 0;
                }
            }
        }//– relação percentual entre a pontuação da Avaliação da Gestão empresa e a melhor das empresas selecionadas.
        
    }
}
