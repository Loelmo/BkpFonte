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
using PEG.Utilitarios;

namespace PEG.User_Controls
{
    public partial class UCFiltroAvaliacao : UCBase
    {
        int TipoEtapaId;

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

                TipoEtapaId = int.Parse(Request["TipoEtapaId"]);
            }
        }

        public RelFiltroRanking GetFiltro()
        {
            RelFiltroRanking RelFiltroRanking = new RelFiltroRanking();

            RelFiltroRanking.RazaoSocial = TxtBxRazaoSocial.Text;
            RelFiltroRanking.NomeFantasia = TxtBxNomeFantasia.Text;
            RelFiltroRanking.CPF_CNPJ = StringUtils.OnlyNumbers(TxtBxCNPJ_CPF.Text);
            RelFiltroRanking.Turma = UCEstado1.IdTurma;
            RelFiltroRanking.IdUsuario = UsuarioLogado.IdUsuario;
            RelFiltroRanking.Estado = UCEstado1.IdEstado;
            RelFiltroRanking.EscritorioRegional = UCEstado1.IdEscritorioRegional;
            RelFiltroRanking.Regiao = UCEstado1.IdRegiao;
            RelFiltroRanking.Cidade = UCEstado1.IdCidade;
            RelFiltroRanking.Grupo = UCEstado1.IdGrupo;
            RelFiltroRanking.FaixaFaturamento = StringUtils.ToInt(DrpDwnLstFaixaFaturamento.SelectedValue);
            RelFiltroRanking.Categoria = StringUtils.ToInt(DrpDwnLstCategoria.SelectedValue);
            RelFiltroRanking.TipoEmpresa = StringUtils.ToInt(DrpDwnLstTipoEmpresa.SelectedValue);
            RelFiltroRanking.FaixaEtariaRepresentante = StringUtils.ToInt(DrpDwnLstFaixaEtaria.SelectedValue);
            RelFiltroRanking.EscolaridadeRepresentante = StringUtils.ToInt(DrpDwnLstEscolaridade.SelectedValue);
            RelFiltroRanking.SexoRepresentante = DrpDwnLstSexoRepresentante.SelectedValue;
            RelFiltroRanking.NumeroFuncionarios = StringUtils.ToInt(TxtBxNumeroFuncionario.Text);
            RelFiltroRanking.Protocolo = TxtBxProtocolo.Text;
            RelFiltroRanking.Inicio = StringUtils.ToDate(TxtBxDataDe.Text);
            RelFiltroRanking.Fim = StringUtils.ToDateFim(TxtBxDataAte.Text);

            switch (int.Parse(Request["TipoEtapaId"]))
            {
                case EntTipoEtapa.TIPO_ETAPA_MPE_AVALIACAO_ESTADUAL:
                    RelFiltroRanking.TipoEtapaMpe = EnumType.TipoEtapaMpe.AvaliacaoEstadual;
                    RelFiltroRanking.Programa = EntPrograma.PROGRAMA_MPE;
                    break;
                case EntTipoEtapa.TIPO_ETAPA_MPE_AVALIACAO_NACIONAL:
                    RelFiltroRanking.TipoEtapaMpe = EnumType.TipoEtapaMpe.AvaliacaoNacional;
                    RelFiltroRanking.Programa = EntPrograma.PROGRAMA_MPE;
                    break;
                case EntTipoEtapa.TIPO_ETAPA_FGA_PRE_CLASSIFICADAS:
                    RelFiltroRanking.TipoEtapaFga = EnumType.TipoEtapaFga.VisitaPreviaPreClassificadas;
                    RelFiltroRanking.Programa = EntPrograma.PROGRAMA_FGA;
                    break;
                case EntTipoEtapa.TIPO_ETAPA_FGA_FASE_4:
                    RelFiltroRanking.TipoEtapaFga = EnumType.TipoEtapaFga.NovoCicloFase4;
                    RelFiltroRanking.Programa = EntPrograma.PROGRAMA_FGA;
                    break;
                case EntTipoEtapa.TIPO_ETAPA_PEG_PRE_CLASSIFICADAS:
                    RelFiltroRanking.TipoEtapaPeg = EnumType.TipoEtapaPeg.VisitaPreviaPreClassificadas;
                    RelFiltroRanking.Programa = EntPrograma.PROGRAMA_PEG;
                    break;
                case EntTipoEtapa.TIPO_ETAPA_PEG_FASE_4:
                    RelFiltroRanking.TipoEtapaPeg = EnumType.TipoEtapaPeg.NovoCicloFase4;
                    RelFiltroRanking.Programa = EntPrograma.PROGRAMA_PEG;
                    break;
            }

            return RelFiltroRanking;
        }

        public int IdTurma()
        {
            return this.UCEstado1.IdTurma;
        }

        protected void RdBttnLstTipoRelatorio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}