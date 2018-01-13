using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de relatorio que representa uma Estrutura de relatorio
    /// </summary>
    [Serializable()]
    public class RelRelatorioQuestoesEspeciais
    {

        public Int32 IdQuestionarioEmpresa { get; set; }
        public Int32 IdEmpresaCadastro { get; set; }
        public Int32 IdEtapa { get; set; }
        public Int32 IdEstado { get; set; }
        public String CpfCnpj { get; set; }
        public String RazaoSocial { get; set; }
        public String Protocolo { get; set; }
        public Double PontuacaoTotal { get; set; } //- pontuação da Avaliação da Gestão.
        public Double CriterioCliente { get; set; }
        public Double CriterioSociedade { get; set; }
        public Double CriterioLideranca { get; set; }
        public Double CriterioEstrategiaPlanos { get; set; }
        public Double CriterioPessoas { get; set; }
        public Double CriterioProcessos { get; set; }
        public Double CriterioInformacoesConhecimento { get; set; }
        public Double CriterioResultado { get; set; }

        public Double PontuacaoQuestoesEspeciais { get; set; } //- pontuação das Questoes especiais da Avaliação da Gestão.
        public Int32 RespostaQuestao9 { get; set; }
        public Double PontuacaoQuestao9 { get; set; }
        public Int32 RespostaQuestao10 { get; set; }
        public Double PontuacaoQuestao10 { get; set; }
        public Int32 RespostaQuestao11 { get; set; }
        public Double PontuacaoQuestao11 { get; set; }
        public Int32 RespostaQuestao16 { get; set; }
        public Double PontuacaoQuestao16 { get; set; }
        public Int32 RespostaQuestao20 { get; set; }
        public Double PontuacaoQuestao20 { get; set; }
        public Int32 RespostaQuestao23 { get; set; }
        public Double PontuacaoQuestao23 { get; set; }
        public Int32 RespostaQuestao31 { get; set; }
        public Double PontuacaoQuestao31 { get; set; }

    }
}
