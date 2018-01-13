using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using PEG.Pagina_Base;
using Vinit.SG.Ent;
using Sistema_de_Gestão_de_Treinamento.User_Control;

namespace PEG.User_Controls
{
    public partial class UCCadastroArquivoCE : UCBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void AtualizaGrid()
        {
            this.grdArquivo.DataSource = ListaGrid;
            this.grdArquivo.DataBind();
            this.grdArquivo.SelectedIndex = -1;
        }

        public void Visualizar()
        {
            this.PopulaGridArquivo();
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
            this.PopulaGridArquivo();
        }

        private void PopulaGridArquivo()
        {
            this.ObjectToPage();
            this.AtualizaGrid();
        }

        private void ObjectToPage()
        {
            EntArquivo objArquivo = new EntArquivo();
            objArquivo.Arquivo = TxtBxTitulo.Text;
            objArquivo.DataCadastroFiltroInicial = StringUtils.ToDate(this.TxtBxDataInicio.Text);
            objArquivo.DataCadastroFiltroFinal = StringUtils.ToDateFim(this.TxtBxDataFim.Text);

            if (this.EmpresaLogada.IdEmpresaCadastro > 0)
            {
                ListaGrid = new BllArquivo().ObterPorEmpresa(EmpresaLogada.Estado.IdEstado, objPrograma.IdPrograma, objTurma.IdTurma, objArquivo.Arquivo, objArquivo.DataCadastroFiltroInicial, objArquivo.DataCadastroFiltroFinal);
            }
            else if (UsuarioLogado.IdUsuario > 0)
            {
                ListaGrid = new BllArquivo().ObterPorFiltrosAdministrativo(UsuarioLogado.IdUsuario, UsuarioLogado.Estado.IdEstado, objPrograma.IdPrograma, objTurma.IdTurma, objArquivo.Arquivo, objArquivo.DataCadastroFiltroInicial, objArquivo.DataCadastroFiltroFinal);
            }
        }

        protected void grdArquivo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdArquivo.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

    }
}