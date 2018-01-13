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
    public class EntRanking
    {
        public Int32 IdEmpresaCadastro { get; set; }
        public Int32 IdQuestionarioEmpresa { get; set; }
        public String CpfCnpj { get; set; }
        public String RazaoSocial { get; set; }
        public Double PontuacaoTotalPosVisita { get; set; } //- pontuação da Avaliação da Gestão.
        public Double EnfoquePosVisita { get; set; } //– pontuação da Avaliação da Gestão sem a pontuação do Critério Resultados.
        public Double ResultadoControlePosVisita { get; set; } //– pontuação da Avaliação da Gestão relativa ao Controle do Critério Resultados.
        public Double ResultadoTendenciaPosVisita { get; set; } //– pontuação da Avaliação da Gestão relativa à Tendência do Critério Resultados.
        public Double TotalEmpreendendorismoPosVisita { get; set; } //– pontuação total do Questionário de Empreendedorismo.
        public Double RelacaoMelhorCategoriaPosVisita { get; set; }//– relação percentual entre a pontuação da Avaliação da Gestão empresa e a melhor das empresas selecionadas.
        public Double PontuacaoRankingPreVisita { get; set; }//– pontuação do Total de Enfoque mais Total Resultados (Controle).
        public Double EnfoquePreVisita { get; set; }//– pontuação do Questionário de Gestão sem a pontuação do Critério Resultados.
        public Double ResultadoControlePreVisita { get; set; }//– pontuação do Questionário de Gestão relativa ao Controle do Critério Resultados.
        public Double ResultadoTendenciaPreVisita { get; set; }//– pontuação do Questionário de Gestão relativa à Tendência do Critério Resultados.
        public Double PontuacaoTotalPreVisita { get; set; }//– pontuação total do Questionário de Gestão.
        public Double RelacaoMelhorCategoriaPreVisita { get; set; } //– relação percentual entre a pontuação da empresa e a melhor das empresas selecionadas.
    }
}
