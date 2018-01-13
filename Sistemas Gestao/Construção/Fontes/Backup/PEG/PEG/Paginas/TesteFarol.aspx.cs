using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;

namespace PEG.FGA.Paginas
{
    public partial class TesteFarol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.DataSource = new BllTurma().ObterTodos();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
           
        }
    }
}