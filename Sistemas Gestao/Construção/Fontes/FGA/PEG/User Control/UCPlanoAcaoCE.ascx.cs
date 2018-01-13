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

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCPlanoAcaoCE : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

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
                this.grdPlanoAcao.Columns[5].Visible = true;
                this.grdPlanoAcao.Columns[4].HeaderText = "Visualizar";
            }

            divUserControl.Visible = true;

            this.PopulaGridPlanosAcao(IdEmpresaCadastro, IdTurma);
        }

        private void PopulaGridPlanosAcao(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            ListaGrid = new BllPlanoAcao().ObterPorEmpresaCadastroTurma(IdEmpresaCadastro, IdTurma);

            this.AtualizaGridPlanoAcao();
        }

        private void AtualizaGridPlanoAcao()
        {
            this.grdPlanoAcao.DataSource = ListaGrid;
            this.grdPlanoAcao.DataBind();
            this.grdPlanoAcao.SelectedIndex = -1;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Close()
        {
            divUserControl.Visible = false;
        }

        protected void grdPlanoAcao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPlanoAcao.PageIndex = e.NewPageIndex;
            AtualizaGridPlanoAcao();
        }

        protected void grdPlanoAcao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblIdPlanoAcao = ((Label)e.Row.FindControl("lblIdPlanoAcao"));
                EntPlanoAcao objPlanoAcao = new BllPlanoAcao().ObterPorId(int.Parse(lblIdPlanoAcao.Text));
                Boolean isEvolucao = false;
                if (objPlanoAcao.Evolucao)
                {
                    isEvolucao = true;
                }

                ImageButton imgBttn = ((ImageButton)e.Row.FindControl("imgBttnEvolucao"));
                this.AlterarCheck(imgBttn, isEvolucao, true);

                if (int.Parse(this.HddnFldNumFase.Value) == 3)
                {
                    imgBttn = ((ImageButton)e.Row.FindControl("ImgBttnAlterar"));
                    imgBttn.ImageUrl = "~/Image/_file_assoc2.png";
                }
            }
        }

        protected void AlterarCheck(ImageButton imgBttn, Boolean isMarcado, Boolean isEtapaAtiva)
        {
            if (isMarcado)
            {
                imgBttn.ImageUrl = "~/Image/checked.gif";
            }
            else
            {
                imgBttn.ImageUrl = "~/Image/unchecked.gif";
            }
            if (isEtapaAtiva)
            {
                imgBttn.Enabled = true;
            }
            else
            {
                imgBttn.Enabled = false;
            }
        }

        protected void grdPlanoAcao_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataKey dk = this.grdPlanoAcao.DataKeys[e.RowIndex];
            this.grdPlanoAcao.SelectedIndex = -1;
            EntPlanoAcao planoAcao = new BllPlanoAcao().ObterPorId(ObjectUtils.ToInt(dk.Value));
            planoAcao.Ativo = false;
            new BllPlanoAcao().Alterar(planoAcao);
        }

        protected void grdPlanoAcao_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdPlanoAcao.DataKeys[e.RowIndex];
            this.grdPlanoAcao.SelectedIndex = -1;
            Boolean permiteEditar = true;
            if (int.Parse(this.HddnFldNumFase.Value) == 3)
            {
                permiteEditar = false;
            }
            this.UCPlanoAcaoIA1.Editar(ObjectUtils.ToInt(dk.Value), permiteEditar);
        }

        protected void grdPlanoAcao_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void grdPlanoAcao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ObjectUtils.ToInt(e.CommandArgument);

            if (e.CommandName == "Evolucao")
            {
                int IdPlanoAcao = StringUtils.ToInt(((Label)this.grdPlanoAcao.Rows[index].Cells[0].FindControl("lblIdPlanoAcao")).Text);
                EntPlanoAcao objPlanoAcao = new BllPlanoAcao().ObterPorId(IdPlanoAcao);
                objPlanoAcao.Evolucao = !objPlanoAcao.Evolucao;
                new BllPlanoAcao().Alterar(objPlanoAcao);
            }
        }

        protected void grdPlanoAcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCPlanoAcaoIA1.Inserir(StringUtils.ToInt(this.HddnFldIdEmpresaCadastro.Value), int.Parse(this.HddnFldIdTurma.Value));
        }

    }
}