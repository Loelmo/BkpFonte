using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCListagemArquivo : UCBase
    {

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid {get; set;}
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObjectToPage();
            }
        }
         
        private void ObjectToPage()
        {
            List<EntArquivo> listArquivo = null;
            if(EmpresaLogada.IdEmpresaCadastro > 0){
                listArquivo = new BllArquivo().ObterPorEmpresa(EmpresaLogada.Estado.IdEstado, objPrograma.IdPrograma, 0, "", StringUtils.ToDate(""), StringUtils.ToDateFim(""));
            }
            else if (UsuarioLogado.IdUsuario > 0)
            {
                listArquivo = new BllArquivo().ObterPorFiltrosAdministrativo(UsuarioLogado.IdUsuario, UsuarioLogado.Estado.IdEstado, objPrograma.IdPrograma, 0, "", StringUtils.ToDate(""), StringUtils.ToDateFim(""));
            }
            if (listArquivo != null && listArquivo.Count > 8)
            {
                listArquivo = listArquivo.GetRange(0, 8);
            }
            this.grdArquivos.DataSource = listArquivo;
            this.grdArquivos.DataBind();

        }

        protected void ImgBtnVejaMais_Click(object sender, EventArgs e)
        {
            this.UCCadastroArquivoCE1.Visualizar();
        }

    }
}