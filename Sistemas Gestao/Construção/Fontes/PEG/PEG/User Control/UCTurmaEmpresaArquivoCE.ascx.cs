using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using System.IO.Compression;
using Ionic.Zip;
using Vinit.SG.BLL;
using Vinit.SG.Ent;

namespace PEG.User_Controls
{
    public partial class UCTurmaEmpresaArquivoCE : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCTurmaEmpresaArquivoIA1.atualizaGrid += this.PopulaGridPlanosAcao;
        }

        protected void ImgBttnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        public void Show(Int32 IdEmpresaCadastro, Int32 IdTurma, Int32 IdEtapa, Int32 NumFase)
        {
            this.HddnFldIdEmpresaCadastro.Value = IntUtils.ToString(IdEmpresaCadastro);
            this.HddnFldIdTurma.Value = IntUtils.ToString(IdTurma);
            this.HddnFldEtapa.Value = IntUtils.ToString(IdEtapa);
            this.HddnFldNumFase.Value = NumFase.ToString();

            if (NumFase == 3)
            {
                ImgBttnIncluir.Visible = false;
                this.grdTurmaEmpresaArquivo.Columns[3].Visible = false;
                this.grdTurmaEmpresaArquivo.Columns[4].Visible = false;
            }

            divUserControl.Visible = true;

            this.PopulaGridPlanosAcao();
        }

        private void PopulaGridPlanosAcao()
        {
            ListaGrid = new BllTurmaEmpresaArquivo().ObterPorEmpresaCadastroTurma(int.Parse(this.HddnFldIdEmpresaCadastro.Value), int.Parse(this.HddnFldIdTurma.Value));

            this.AtualizaGridTurmaEmpresaArquivo();
        }

        private void AtualizaGridTurmaEmpresaArquivo()
        {
            this.grdTurmaEmpresaArquivo.DataSource = ListaGrid;
            this.grdTurmaEmpresaArquivo.DataBind();
            this.grdTurmaEmpresaArquivo.SelectedIndex = -1;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Close()
        {
            divUserControl.Visible = false;
        }

        protected void grdTurmaEmpresaArquivo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTurmaEmpresaArquivo.PageIndex = e.NewPageIndex;
            AtualizaGridTurmaEmpresaArquivo();
        }

        protected void grdTurmaEmpresaArquivo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hyperLink1 = ((HyperLink)e.Row.FindControl("HyperLink1"));
                Label lblIdTurmaEmpresaArquivo = ((Label)e.Row.FindControl("lblIdTurmaEmpresaArquivo"));
                EntTurmaEmpresaArquivo TurmaEmpresaArquivo = new BllTurmaEmpresaArquivo().ObterPorId(int.Parse(lblIdTurmaEmpresaArquivo.Text));
                String Url = this.PathDownloadArquivos + TurmaEmpresaArquivo.Arquivo;
                hyperLink1.NavigateUrl = Url;
            }
        }

        protected void grdTurmaEmpresaArquivo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdTurmaEmpresaArquivo = ObjectUtils.ToInt(e.CommandArgument);
            this.grdTurmaEmpresaArquivo.SelectedIndex = -1;

            if (e.CommandName == "Excluir")
            {
                EntTurmaEmpresaArquivo TurmaEmpresaArquivo = new BllTurmaEmpresaArquivo().ObterPorId(IdTurmaEmpresaArquivo);
                TurmaEmpresaArquivo.Ativo = false;
                new BllTurmaEmpresaArquivo().Alterar(TurmaEmpresaArquivo);
            }
            else if (e.CommandName == "Atualizar")
            {
                this.UCTurmaEmpresaArquivoIA1.Editar(IdTurmaEmpresaArquivo);
            }
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCTurmaEmpresaArquivoIA1.Inserir(StringUtils.ToInt(this.HddnFldIdEmpresaCadastro.Value), int.Parse(this.HddnFldIdTurma.Value));
        }

    }
}