using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using System.Web.Security;
using Sistema_de_Gestao.Utilitarios;

namespace Sistema_de_Gestao.Master_Page
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
                Logout();

            if (Session["objPrograma"] == null)
                Logout();

            lnkStyleSheet.Href = WebUtils.AplicaEstilo((EntPrograma)Session["objPrograma"]);
            lnkFavIcon.Href = WebUtils.AplicaFavIcon((EntPrograma)Session["objPrograma"]);

            Response.CacheControl = "no-cache";

            if (!IsPostBack)
            {
                EntAdmUsuario objUsuarioLogado = (EntAdmUsuario)Session["objUsuarioLogado"];

                if ((objUsuarioLogado != null) && (objUsuarioLogado.IdUsuario > 0))
                {
                    this.lblUsuarioLogado.Text = objUsuarioLogado.Usuario;
                }
                else
                {
                    EntEmpresaCadastro objEmpresaLogada = (EntEmpresaCadastro)Session["objEmpresaLogada"];

                    if ((objEmpresaLogada != null) && (objEmpresaLogada.IdEmpresaCadastro > 0))
                    {
                        this.lblUsuarioLogado.Text = objEmpresaLogada.RazaoSocial;
                    }
                    else
                    {
                        lblBemVindo.Visible = false;
                    }
                }
            }

        }

        private void Logout()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Paginas/Principal.aspx");
        }

        protected void ImgBttnSair_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Paginas/Logout.aspx");
        }

    }
}