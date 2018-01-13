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
    public partial class UCRelFiltroGeral : UCBase
    {
        //Configura parametros do filtro por relatório
        public EnumType.RelatorioFiltro Relatorio { get; set; }

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


                switch (Relatorio)
                {
                    case EnumType.RelatorioFiltro.NumeroParticipantesPorEtapaFga:
                        this.DrpDwnLstStatus.Visible = false;
                        this.lblStatus.Visible = false;
                        break;

                    default:
                        this.DrpDwnLstStatus.Visible = true;
                        this.lblStatus.Visible = true;
                        break;

                }
            }
        }

        public RelFiltroGeral GetFiltro()
        {
            RelFiltroGeral RelFiltroGeral = new RelFiltroGeral();

            RelFiltroGeral.Programa = this.objPrograma.IdPrograma;
            RelFiltroGeral.Nome = TxtBxNome.Text;
            RelFiltroGeral.CPF_CNPJ = StringUtils.OnlyNumbers(TxtBxCNPJ_CPF.Text);
            RelFiltroGeral.Turma = UCEstado1.IdTurma;
            RelFiltroGeral.Estado = UCEstado1.IdEstado;
            RelFiltroGeral.EscritorioRegional = UCEstado1.IdEscritorioRegional;
            RelFiltroGeral.Regiao = UCEstado1.IdRegiao;
            RelFiltroGeral.Cidade = UCEstado1.IdCidade;
            RelFiltroGeral.Grupo = UCEstado1.IdGrupo;
            RelFiltroGeral.FaixaFaturamento = StringUtils.ToInt(DrpDwnLstFaixaFaturamento.SelectedValue);
           //RelFiltroGeral.TipoRelatorio = StringUtils.ToEnum<EnumType.TipoRelatorio>(RdBttnLstTipoRelatorio.SelectedValue);
            RelFiltroGeral.Categoria = StringUtils.ToInt(DrpDwnLstCategoria.SelectedValue);
            RelFiltroGeral.TipoEmpresa = StringUtils.ToInt(DrpDwnLstTipoEmpresa.SelectedValue);
            RelFiltroGeral.FaixaEtariaRepresentante = StringUtils.ToInt(DrpDwnLstFaixaEtaria.SelectedValue);
            RelFiltroGeral.EscolaridadeRepresentante = StringUtils.ToInt(DrpDwnLstEscolaridade.SelectedValue);
            RelFiltroGeral.SexoRepresentante = DrpDwnLstSexoRepresentante.SelectedValue;
            RelFiltroGeral.NumeroFuncionarios = StringUtils.ToInt(TxtBxNumeroFuncionario.Text);
            RelFiltroGeral.Protocolo = TxtBxProtocolo.Text;
            //RelFiltroGeral.PremioEspecial = ChckBxPremiosEspeciais.Checked;
            RelFiltroGeral.Status = StringUtils.ToInt(DrpDwnLstStatus.SelectedValue);
            RelFiltroGeral.Inicio = StringUtils.ToDate(TxtBxDataDe.Text);
            RelFiltroGeral.Fim = StringUtils.ToDateFim(TxtBxDataAte.Text);
            //RelFiltroGeral.Questionario = StringUtils.ToEnum<EnumType.Questionario>(DrpDwnLstRelatorio.SelectedValue);


            return RelFiltroGeral;
        }

        protected void RdBttnLstTipoRelatorio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}