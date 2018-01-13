using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using System.IO;
using Sistema_de_Gestao.Utilitarios;

namespace Sistema_de_Gestao.MPE.User_Controls
{
    public partial class UCFiltroRanking : UCBase
    {
        public EnumType.EtapaRanking EtapaRanking { get; set; }
        public Boolean IsEstadual { get; set; }
        public enum enumRelatorio
        {
            RelatorioEstatisticoInscritas = 0,
            RelatorioParticipantesPorEtapa
        }
        public enumRelatorio Relatorio { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // parametros do User Control
            this.UCEstado1.EscritorioRegional = true;
            this.UCEstado1.Regiao = true;

            if (!IsPostBack)
            {
                WebUtils.PopulaDropDownList(this.DrpDwnLstCategoria, EnumType.TipoDropDownList.Categoria, "Todos");
                WebUtils.PopulaDropDownList(this.DrpDwnLstFaixaFaturamento, EnumType.TipoDropDownList.Faturamento, "Todos");
                WebUtils.PopulaDropDownList(this.DrpDwnLstEscolaridade, EnumType.TipoDropDownList.Escolaridade, "Todos");
                WebUtils.PopulaDropDownList(this.DrpDwnLstTipoEmpresa, EnumType.TipoDropDownList.TipoEmpresa, "Todos");
                WebUtils.PopulaDropDownList(this.DrpDwnLstFaixaEtaria, EnumType.TipoDropDownList.FaixaEtaria, "Todos");

                switch (EtapaRanking)
                {
                    case EnumType.EtapaRanking.Candidata:
                        this.lblPremiosEspeciais.Visible = true;
                        this.ChckBxPremiosEspeciais.Visible = true;

                        this.lblRelatorios.Visible = false;
                        this.DrpDwnLstRelatorio.Visible = false;
                        break;

                    default:
                        this.lblPremiosEspeciais.Visible = false;
                        this.ChckBxPremiosEspeciais.Visible = false;

                        this.lblRelatorios.Visible = true;
                        this.DrpDwnLstRelatorio.Visible = true;
                        break;
                }
            }

            switch (Relatorio)
            {
                case enumRelatorio.RelatorioEstatisticoInscritas:

                    RdBttnLstTipoRelatorio.Enabled = false;
                    DrpDwnLstStatusB.Visible = true;
                    DrpDwnLstStatus.Visible = false;

                    break;
                case enumRelatorio.RelatorioParticipantesPorEtapa:

                    RdBttnLstTipoRelatorio.Enabled = false;
                    DrpDwnLstStatusB.Visible = false;
                    DrpDwnLstStatus.Visible = false;

                    break;
                default:
                    break;
            }

        }

        public RelFiltroRanking GetFiltro()
        {
            RelFiltroRanking RelFiltroRanking = new RelFiltroRanking();

            RelFiltroRanking.RazaoSocial = TxtBxNome.Text;
            RelFiltroRanking.NomeFantasia = TxtBxNome.Text;
            RelFiltroRanking.CPF_CNPJ = StringUtils.OnlyNumbers(TxtBxCNPJ_CPF.Text);
            RelFiltroRanking.Turma = UCEstado1.IdTurma;
            RelFiltroRanking.Estado = UCEstado1.IdEstado;
            RelFiltroRanking.EscritorioRegional = UCEstado1.IdEscritorioRegional;
            RelFiltroRanking.Regiao = UCEstado1.IdRegiao;
            RelFiltroRanking.Cidade = UCEstado1.IdCidade;
            RelFiltroRanking.Grupo = UCEstado1.IdGrupo;
            RelFiltroRanking.FaixaFaturamento = StringUtils.ToInt(DrpDwnLstFaixaFaturamento.SelectedValue);
            RelFiltroRanking.TipoRelatorio = StringUtils.ToEnum<EnumType.TipoRelatorio>(RdBttnLstTipoRelatorio.SelectedValue);
            RelFiltroRanking.Categoria = StringUtils.ToInt(DrpDwnLstCategoria.SelectedValue);
            RelFiltroRanking.TipoEmpresa = StringUtils.ToInt(DrpDwnLstTipoEmpresa.SelectedValue);
            RelFiltroRanking.FaixaEtariaRepresentante = StringUtils.ToInt(DrpDwnLstFaixaEtaria.SelectedValue);
            RelFiltroRanking.EscolaridadeRepresentante = StringUtils.ToInt(DrpDwnLstEscolaridade.SelectedValue);
            RelFiltroRanking.SexoRepresentante = DrpDwnLstSexoRepresentante.SelectedValue;
            RelFiltroRanking.NumeroFuncionarios = StringUtils.ToInt(TxtBxNumeroFuncionario.Text);
            RelFiltroRanking.Protocolo = TxtBxProtocolo.Text;
            RelFiltroRanking.PremioEspecial = ChckBxPremiosEspeciais.Checked;
            RelFiltroRanking.Status = StringUtils.ToInt(DrpDwnLstStatus.SelectedValue);
            if (this.Relatorio == enumRelatorio.RelatorioEstatisticoInscritas)
            {
                RelFiltroRanking.Status = StringUtils.ToInt(DrpDwnLstStatusB.SelectedValue);
            }
            RelFiltroRanking.Inicio = StringUtils.ToDate(TxtBxDataDe.Text);
            RelFiltroRanking.Fim = StringUtils.ToDateFim(TxtBxDataAte.Text);
            RelFiltroRanking.Questionario = StringUtils.ToEnum<EnumType.Questionario>(DrpDwnLstRelatorio.SelectedValue);

            switch (this.EtapaRanking)
            {
                case EnumType.EtapaRanking.Candidata:
                    if (IsEstadual)
                    {
                        RelFiltroRanking.TipoEtapaMpe = EnumType.TipoEtapaMpe.ClassificaçãoEstadual;
                    }
                    else
                    {
                        RelFiltroRanking.TipoEtapaMpe = EnumType.TipoEtapaMpe.ClassificacaoNacional;
                    }
                    break;

                case EnumType.EtapaRanking.Classificada:
                    if (IsEstadual)
                    {
                        RelFiltroRanking.TipoEtapaMpe = EnumType.TipoEtapaMpe.AvaliacaoEstadual;
                    }
                    else
                    {
                        RelFiltroRanking.TipoEtapaMpe = EnumType.TipoEtapaMpe.AvaliacaoNacional;
                    }

                    break;

                case EnumType.EtapaRanking.Finalista:
                    if (IsEstadual)
                    {
                        RelFiltroRanking.TipoEtapaMpe = EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais;
                    }
                    else
                    {
                        RelFiltroRanking.TipoEtapaMpe = EnumType.TipoEtapaMpe.JulgamentoFinalistasNacionais;
                    }
                    break;
                case EnumType.EtapaRanking.Fase2Peg:
                    RelFiltroRanking.TipoEtapaPeg = EnumType.TipoEtapaPeg.PlanoEmpresarialFase2;
                    break;
                case EnumType.EtapaRanking.Fase3Peg:
                    RelFiltroRanking.TipoEtapaPeg = EnumType.TipoEtapaPeg.GestãoDoResultadoFase3;
                    break;
            }

            return RelFiltroRanking;
        }

        protected void RdBttnLstTipoRelatorio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}