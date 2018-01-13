using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Common;
using System.IO;
using Sistema_de_Gestao.Pagina_Base;

namespace Sistema_de_Gestao.Paginas
{
    public partial class FileUpload : PaginaBase
    {
        private string GetCaminhoFisico(string fileName)
        {
            this.CaminhoFisico = GetMapPathFull(PathUpload) + StringUtils.NewGuidKey() + "+_+" + fileName;
            return CaminhoFisico;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CaminhoFisico.Length > 0)
            {
                string fileName = Session["CaminhoFisico"].ToString().Substring(Session["CaminhoFisico"].ToString().IndexOf("+_+") + 3);
                this.lblArquivoUpload.Text = fileName;
            }
        }

        protected void imgBttnUpload_Click(object sender, EventArgs e)
        {
            this.Upload();
        }

        private void Upload()
        {
            this.fluArquivo.SaveAs(this.GetCaminhoFisico(fluArquivo.FileName));
            this.lblArquivoUpload.Text = fluArquivo.FileName;
        }

        
    }
}