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

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCFiltroRanking : UCBase
    {
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
            this.UCEstado1.Grupo = true;

            if (!IsPostBack)
            {
                
                WebUtils.PopulaDropDownList(this.DrpDwnLstCategoria, EnumType.TipoDropDownList.Categoria, "Todos");
                WebUtils.PopulaDropDownList(this.DrpDwnLstFaixaFaturamento, EnumType.TipoDropDownList.Faturamento, "Todos");
                WebUtils.PopulaDropDownList(this.DrpDwnLstEscolaridade, EnumType.TipoDropDownList.Escolaridade, "Todos");
                WebUtils.PopulaDropDownList(this.DrpDwnLstTipoEmpresa, EnumType.TipoDropDownList.TipoEmpresa, "Todos");
                WebUtils.PopulaDropDownList(this.DrpDwnLstFaixaEtaria, EnumType.TipoDropDownList.FaixaEtaria, "Todos");

                this.lblPremiosEspeciais.Visible = false;
                this.ChckBxPremiosEspeciais.Visible = false;
                this.lblRelatorios.Visible = true;
                this.DrpDwnLstRelatorio.Visible = true;

                switch(StringUtils.ToInt(Request["TipoEtapaId"]))
                {
                    case (int)EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa:
                    case (int)EnumType.TipoEtapaMpe.InscriçãoCandidaturaAdministrativo:
                    case (int)EnumType.TipoEtapaFga.ValidacaoAnaliseRespostas:
                    case (int)EnumType.TipoEtapaPeg.ValidacaoAnaliseRespostas:
                        this.lblPremiosEspeciais.Visible = true;
                        this.ChckBxPremiosEspeciais.Visible = true;
                        this.lblRelatorios.Visible = false;
                        this.DrpDwnLstRelatorio.Visible = false;
                        break;
                    case (int)EnumType.TipoEtapaFga.NovoCicloFase4:
                        this.Label10.Visible = false;
                        DrpDwnLstStatus.Visible = false;
                        break;
                }
                if (this.objPrograma.IdPrograma == EntPrograma.PROGRAMA_FGA || this.objPrograma.IdPrograma == EntPrograma.PROGRAMA_PEG)
                {
                    this.lblRelatorios.Visible = false;
                    lblPremiosEspeciais.Visible = false;
                    ChckBxPremiosEspeciais.Visible = false;
                    DrpDwnLstRelatorio.Visible = false;
                }
                if (this.Page.Title == "Comparativo de Questões Especiais Autoavaliação Inicial" || this.Page.Title == "" || this.Page.Title == "Preenchimento de Inscrições" || this.Page.Title == "Comparação de Resultados Pré-Visita e Pós-Visita - Pré-Classificadas" || this.Page.Title == "Comparação de Resultados Pré-Visita e Pós-Visita - Fase 4")
                {
                    LblTipoRelatorio.Visible = false;
                    RdBttnLstTipoRelatorio.Visible = false;
                    Label10.Visible = false;
                    DrpDwnLstStatus.Visible = false;
                    RdBttnLstTipoRelatorio.Visible = false;
                    LblTipoRelatorio.Visible = false;
                }
            }
        }

        public RelFiltroRanking GetFiltro(Int32 IdTipoEtapa)
        {
            RelFiltroRanking RelFiltroRanking = new RelFiltroRanking();

            RelFiltroRanking.RazaoSocial = TxtBxRazaoSocial.Text;
            RelFiltroRanking.NomeFantasia = TxtBxNomeFantasia.Text;
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
            RelFiltroRanking.Inicio = StringUtils.ToDate(TxtBxDataDe.Text);
            RelFiltroRanking.Fim = StringUtils.ToDateFim(TxtBxDataAte.Text);
            RelFiltroRanking.Questionario = StringUtils.ToEnum<EnumType.Questionario>(DrpDwnLstRelatorio.SelectedValue);
            RelFiltroRanking.Programa = this.objPrograma.IdPrograma;

            switch (this.objPrograma.IdPrograma)
            {
                case EntPrograma.PROGRAMA_MPE:
                    RelFiltroRanking.TipoEtapaMpe = (EnumType.TipoEtapaMpe)IdTipoEtapa;
                    break;
                case EntPrograma.PROGRAMA_FGA:
                    RelFiltroRanking.TipoEtapaFga = (EnumType.TipoEtapaFga)IdTipoEtapa;
                    break;
                case EntPrograma.PROGRAMA_PEG:
                    RelFiltroRanking.TipoEtapaPeg = (EnumType.TipoEtapaPeg)IdTipoEtapa;
                    break;
            }

            return RelFiltroRanking;
        }

        protected void RdBttnLstTipoRelatorio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}