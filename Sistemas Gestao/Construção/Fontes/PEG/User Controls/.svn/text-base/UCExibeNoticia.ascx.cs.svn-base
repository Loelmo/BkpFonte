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
using PEG.Utilitarios;

namespace PEG.User_Controls
{
    public partial class UCExibeNoticia : UCBase
    {

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCConfirmaEmail1.enviarEmail += this.EnviarEmail;
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

        public void Visualizar(Int32 IdNoticia)
        {
            EntNoticia objNoticia = new BllNoticia().ObterPorId(IdNoticia);
            this.ObjectToPage(objNoticia);
            this.Show();
        }

        private void ObjectToPage(EntNoticia objNoticia)
        {
            this.LblTitulo.Text = objNoticia.Titulo;
            this.LblNoticia.Text = objNoticia.Noticia;
            this.ImgNoticia.ImageUrl = "/DownloadArquivos/" + objNoticia.UrlImagem;

        }

        private void PageToObject(EntNoticia objNoticia)
        {
            objNoticia.Titulo = this.LblTitulo.Text;
            objNoticia.Noticia = this.LblNoticia.Text;
            objNoticia.UrlImagem = "/DownloadArquivos/" + this.ImgNoticia.ImageUrl;

        }

        protected void ImgBtnNoticiaEmail_Click(object sender, ImageClickEventArgs e)
        {
            this.UCConfirmaEmail1.Show();
        }

        public void EnviarEmail(String email)
        {
            EntNoticia objNoticia = new EntNoticia();
            PageToObject(objNoticia);
            WebUtils.EnviaEmailNoticia(email, objNoticia);
        }

    }
}