using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Vinit.SG.Ent;
using PEG.Pagina_Base;

namespace PEG.Paginas
{
    public partial class Logout : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("~/Paginas/Login.aspx");
        }
    }
}