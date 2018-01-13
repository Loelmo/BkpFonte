using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Pagina_Base;
using Sistema_de_Gestao.Utilitarios;
using System.Web.UI.HtmlControls;
using Vinit.SG.Ent;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.Paginas
{
    public partial class SessaoExpirada : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.FindControl("UCMenu").Visible = false;

            EntPrograma objPrograma = new EntPrograma();
            objPrograma = WebUtils.VerificaProgramaPorURL(getDominio(this.Page));
            Session["objPrograma"] = objPrograma;
            IdProgramaSessao.Value = ((EntPrograma)Session["objPrograma"]).IdPrograma.ToString();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            EntPrograma objPrograma = new EntPrograma();
            objPrograma.IdPrograma = StringUtils.ToInt(IdProgramaSessao.Value);
            String url = WebUtils.VerificaUrlPorPrograma(objPrograma);

            Response.Redirect(url);
        }
    }
}