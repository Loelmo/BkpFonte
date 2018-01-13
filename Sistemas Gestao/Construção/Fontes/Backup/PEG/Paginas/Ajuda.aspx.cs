using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PEG.Pagina_Base;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using System.Text.RegularExpressions;

namespace PEG.Paginas
{
    public partial class Ajuda : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void BtnAjuda_Click(object sender, EventArgs e)
        {
            divGestorEstadual.Visible = !divGestorEstadual.Visible;
        }

        protected void ImgBttnFechar_Click(object sender, ImageClickEventArgs e)
        {
            this.divGestorEstadual.Visible = false;
        }

    }
}