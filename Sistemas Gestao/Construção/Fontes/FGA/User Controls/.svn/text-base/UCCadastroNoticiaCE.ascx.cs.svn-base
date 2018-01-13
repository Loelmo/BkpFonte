using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Ent;
using Sistema_de_Gestão_de_Treinamento.User_Control;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCCadastroNoticiaCE : UCBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void AtualizaGrid()
        {
            this.grdNoticia.DataSource = ListaGrid;
            this.grdNoticia.DataBind();
            this.grdNoticia.SelectedIndex = -1;
        }

        public void Visualizar()
        {
            this.PopulaGridNoticia();
            this.Show();
        }

        private void Show()
        {
            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridNoticia();
        }

        private void PopulaGridNoticia()
        {
            this.ObjectToPage();
            this.AtualizaGrid();
        }

        private void ObjectToPage()
        {
            EntNoticia objNoticia = new EntNoticia();
            objNoticia.Noticia = TxtBxTitulo.Text;
            objNoticia.DataCadastroFiltroInicial = StringUtils.ToDate(this.TxtBxDataInicio.Text);
            objNoticia.DataCadastroFiltroFinal = StringUtils.ToDateFim(this.TxtBxDataFim.Text);

            if (this.EmpresaLogada.IdEmpresaCadastro > 0)
            {
                ListaGrid = new BllNoticia().ObterPorEmpresa(EmpresaLogada.Estado.IdEstado, objPrograma.IdPrograma, objTurma.IdTurma, objNoticia.Noticia, objNoticia.DataCadastroFiltroInicial, objNoticia.DataCadastroFiltroFinal);
            }
            else if (UsuarioLogado.IdUsuario > 0)
            {
                ListaGrid = new BllNoticia().ObterPorFiltrosAdministrativo(UsuarioLogado.IdUsuario, UsuarioLogado.Estado.IdEstado, objPrograma.IdPrograma, objTurma.IdTurma, objNoticia.Noticia, objNoticia.DataCadastroFiltroInicial, objNoticia.DataCadastroFiltroFinal);
            }
        }

        protected void grdNoticia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNoticia.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdNoticia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdNoticia.DataKeys[e.RowIndex];
            this.grdNoticia.SelectedIndex = -1;
            this.UCExibeNoticia1.Visualizar(ObjectUtils.ToInt(dk.Value));
        }
         
    }
}