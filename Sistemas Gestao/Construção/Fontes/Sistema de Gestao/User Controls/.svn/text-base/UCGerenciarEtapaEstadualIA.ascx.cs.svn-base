using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCGerenciarEtapaEstadualIA : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Show()
        {
            divUserControl.Visible = true;
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

        public void Editar(int IdEtapa)
        {
            EntEtapa objEtapa = new BllEtapa().ObterPorId(IdEtapa);
            ObjectToPage(objEtapa);
            this.Show();
        }

        public void Incluir()
        {
            this.Clear();
            this.Show();
        }

        private void ObjectToPage(EntEtapa objEtapa)
        {
            this.HddnFldIdEtapa.Value = IntUtils.ToString(objEtapa.IdEtapa);
            List<EntEtapa> lstEtapa = new List<EntEtapa>();
            lstEtapa.Add(objEtapa);
            this.grdEtapaEstadual.DataSource = lstEtapa;
            this.grdEtapaEstadual.DataBind();
        }

        protected void grdUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAcao = ((ImageButton)e.Row.FindControl("ImagBttnAcao"));

                RegistraScriptExcluirGrid(this.Page, btnAcao, "Confirma alteração da Etapa?");

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
            }
        }

        private void CriaResumo(EntEtapaResumo objEtapaResumo, EntEtapa item)
        {
            objEtapaResumo.AdmUsuario = UsuarioLogado;
            objEtapaResumo.DataCadastro = DateTime.Now;
            objEtapaResumo.Etapa = item;
            if (item.Ativo)
            {
                objEtapaResumo.Acao = StringUtils.Concatenar(EnumType.Tabela.EntEtapa, EnumType.TipoAcao.Ativar);
            }
            else
            {
                objEtapaResumo.Acao = StringUtils.Concatenar(EnumType.Tabela.EntEtapa, EnumType.TipoAcao.Inativar);
            }
        }

        private void Gravar()
        {
            EntEtapa objEtapa = new EntEtapa();

            this.PageToObject(objEtapa);
            EntEtapaResumo objEtapResumo = new EntEtapaResumo();
            this.CriaResumo(objEtapResumo, objEtapa);

            try
            {
                new BllEtapa().AtivaDesativaEtapa(objEtapa, objEtapResumo);
                MessageBox(this.Page, "Etapa Alterada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar alterar Etapa!");
                //logger.Error("Erro ao inserir o Usuario!", ex);
            }
        }

        private void PageToObject(EntEtapa objEtapa)
        {
            objEtapa.IdEtapa = StringUtils.ToInt(this.HddnFldIdEtapa.Value);

            if (((Label)this.grdEtapaEstadual.Rows[0].Cells[1].Controls[1]).Text == "True")
            {
                objEtapa.Ativo = true;
            }
            else
            {
                objEtapa.Ativo = false;
            }
        }

        protected void grdEtapaEstadual_RowUpdating(object sender, GridViewDeleteEventArgs e)
        {
            ImageButton btnAcao = ((ImageButton)grdEtapaEstadual.Rows[e.RowIndex].FindControl("ImagBttnAcao"));

            RegistraScriptExcluirGrid(this.Page, btnAcao, "Confirma alteração da Etapa?");

            String imageUrl;
            Label lblAcaoAux = (Label)grdEtapaEstadual.Rows[e.RowIndex].FindControl("LblAcao");

            if (lblAcaoAux.Text == "True")
            {
                imageUrl = "~/Image/button_cancel.gif";
                lblAcaoAux.Text = "False";
            }
            else
            {
                imageUrl = "~/Image/button_ok.gif";
                lblAcaoAux.Text = "True";
            }

            btnAcao.ImageUrl = imageUrl;
        }
    }
}