using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCRevisaoRespostasEmpresa : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Show()
        {
            divUserControl.Visible = true;

            if (!ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar))
            {
                EnableControl(this.PnlFundo.Controls, false);
                this.ImgBttnGravar.Visible = false;
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, true);
                this.ImgBttnGravar.Visible = true;
            }
        }

        private void Close()
        {
            divUserControl.Visible = false;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            this.Gravar();
            this.Clear();
            this.Close();

            if (atualizaGrid != null)
            {
                this.atualizaGrid();
            }
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Editar(int IdEstado, int nTipoEtapa)
        {
            List<EntEtapa> lstEtapa = new BllEtapa().ObterPorIdEstado(IdEstado, nTipoEtapa);
            ObjectToPage(lstEtapa);
            this.Show();
        }

        public void Incluir()
        {
            this.Clear();
            this.Show();
        }

        private void ObjectToPage(List<EntEtapa> lstEtapa)
        {
            //this.HddnFldIdEtapa.Value = IntUtils.ToString(objEtapa.IdEtapa);
            //List<EntEtapa> lstEtapa = new List<EntEtapa>();
            //lstEtapa.Add(objEtapa);
            this.grdEtapaEstadual.DataSource = lstEtapa;
            this.grdEtapaEstadual.DataBind();
        }

        private void Gravar()
        {
            List<EntEtapa> lstEtapa = new List<EntEtapa>();
            this.PageToObject(lstEtapa);
            EntEtapaResumo objEtapResumo = new EntEtapaResumo();
            this.CriaResumo(objEtapResumo, lstEtapa);
            try
            {
                new BllEtapa().AtivaDesativaEtapas(lstEtapa, objEtapResumo);
                MessageBoxAlert(this.Page, "Etapa Alterada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBoxError(this.Page, "Erro ao tentar alterar Etapa!");
                //logger.Error("Erro ao inserir o EntUsuario!", ex);
            }
        }

        private void PageToObject(List<EntEtapa> lstEtapa)
        {
            foreach (GridViewRow row in this.grdEtapaEstadual.Rows)
            {
                EntEtapa objEtapa = new EntEtapa();
                objEtapa.IdEtapa = StringUtils.ToInt(this.grdEtapaEstadual.DataKeys[row.RowIndex].Value.ToString());
                Label lblAcaoAux = (Label)row.FindControl("LblAcao");
                if (lblAcaoAux.Text == "True")
                {
                    objEtapa.Ativo = true;
                }
                else
                {
                    objEtapa.Ativo = false;
                }
                lstEtapa.Add(objEtapa);
            }
        }


        protected void grdEtapaEstadual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Excluir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAcao = ((ImageButton)e.Row.FindControl("ImagBttnAcao"));

                String imageUrl;
                Label lblAcaoAux = (Label)e.Row.FindControl("LblAcao");

                if (lblAcaoAux.Text == "True")
                {
                    imageUrl = "~/Image/button_ok.gif";
                }
                else
                {
                    imageUrl = "~/Image/button_cancel.gif";
                }

                btnAcao.ImageUrl = imageUrl;
                btnAcao.Enabled = PermissaoExcluir;
            }
        }

        protected void grdEtapaEstadual_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            this.AlteraStatusItensGrid();
            ImageButton btnAcao = ((ImageButton)grdEtapaEstadual.Rows[e.RowIndex].FindControl("ImagBttnAcao"));
            String imageUrl;
            Label lblAcaoAux = (Label)grdEtapaEstadual.Rows[e.RowIndex].FindControl("LblAcao");

            imageUrl = "~/Image/button_ok.gif";
            lblAcaoAux.Text = "True";

            btnAcao.ImageUrl = imageUrl;
        }

        private void CriaResumo(EntEtapaResumo objEtapaResumo, List<EntEtapa> lstEtapa)
        {
            foreach (EntEtapa item in lstEtapa)
            {
                if (item.Ativo)
                {
                    objEtapaResumo.Acao = StringUtils.Concatenar(EnumType.Tabela.EntEtapa, EnumType.TipoAcao.Ativar);
                    objEtapaResumo.AdmUsuario = UsuarioLogado;
                    objEtapaResumo.DataCadastro = DateTime.Now;
                    objEtapaResumo.Etapa = item;
                }
            }
        }

        private void AlteraStatusItensGrid()
        {
            foreach (GridViewRow row in this.grdEtapaEstadual.Rows)
            {
                ImageButton btnAcao = ((ImageButton)row.FindControl("ImagBttnAcao"));
                String imageUrl;
                Label lblAcaoAux = (Label)row.FindControl("LblAcao");
                imageUrl = "~/Image/button_cancel.gif";
                lblAcaoAux.Text = "False";
                btnAcao.ImageUrl = imageUrl;
            }
        }
    }
}