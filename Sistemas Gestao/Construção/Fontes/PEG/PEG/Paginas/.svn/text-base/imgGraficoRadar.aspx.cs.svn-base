using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PEG.Utilitarios;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

public partial class relatorio_imgGraficoRadar : System.Web.UI.Page
{
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    #region Objetos
    private GraficoRadar graficoRadar;
    #endregion

    #region Load
    private void Page_Load(object szender, System.EventArgs e)
    {
        string[,] arrValor = new string[8, 2];
        string[,] arrValorMax = new string[8, 2];

        for (int i = 0; i < 8; i++)
        {
            arrValor[i, 0] = (i + 1).ToString();
            arrValor[i, 1] = "1";

            arrValorMax[i, 0] = (i + 1).ToString();
            arrValorMax[i, 1] = "1";
        }

        string valor = "";

        if (Request.QueryString["valor"] != null)
        {
            try { valor = Request.QueryString["valor"]; }
            catch { }
        }

        if (valor != "")
        {
            for (int i = 0; i < valor.Split(',').Length; i++)
            {
                arrValor[i, 0] = (i + 1).ToString();
                arrValor[i, 1] = valor.Split(',')[i];
            }
        }

        // Valor Máximo
        if (Request.QueryString["valorMax"] != null)
        {
            try { valor = Request.QueryString["valorMax"]; }
            catch { }

            if (valor == "")
            {
                try { valor = Request.QueryString["valor"]; }
                catch { }
            }
        }

        if (valor != "")
        {
            for (int i = 0; i < valor.Split(',').Length; i++)
            {
                arrValorMax[i, 0] = (i + 1).ToString();
                arrValorMax[i, 1] = valor.Split(',')[i];
            }
        }

        Response.ContentType = "image/jpeg";

        graficoRadar = new GraficoRadar();

        graficoRadar.Gerar(arrValor, arrValorMax, true).Save(Response.OutputStream, ImageFormat.Jpeg);

        Response.End();
    }
    #endregion
}
