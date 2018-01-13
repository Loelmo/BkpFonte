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

namespace PEG.User_Controls
{
    public partial class UCListagemNoticia : UCBase
    {

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObjectToPage();
            }
        }

        private void ObjectToPage()
        {
            List<EntNoticia> listNoticia = null;
            if (EmpresaLogada.IdEmpresaCadastro > 0)
            {
                listNoticia = new BllNoticia().ObterPorEmpresa(EmpresaLogada.Estado.IdEstado, objPrograma.IdPrograma, 0, "", StringUtils.ToDate(""), StringUtils.ToDateFim(""));
            }
            else if (UsuarioLogado.IdUsuario > 0)
            {
                listNoticia = new BllNoticia().ObterPorFiltrosAdministrativo(UsuarioLogado.IdUsuario, UsuarioLogado.Estado.IdEstado, objPrograma.IdPrograma, 0, "", StringUtils.ToDate(""), StringUtils.ToDateFim(""));
            }
            if (listNoticia == null || listNoticia.Count == 0)
            {
                tabelaSemDados.Style.Add("display", "block");
            }
            if (listNoticia != null && listNoticia.Count > 0)
            {
                ImgNoticia1.ImageUrl = PathDownloadArquivos + listNoticia[0].UrlImagem;
                LblNoticia1.Text = listNoticia[0].Titulo;
                LblCorpoNoticia1.Text = CortaTexto(listNoticia[0].Noticia);
                HdnNoticia1Id.Value = listNoticia[0].IdNoticia.ToString();
            }
            else
            {
                linha1a.Visible = false;
            }
            if (listNoticia != null && listNoticia.Count > 1)
            {
                ImgNoticia2.ImageUrl = "/DownloadArquivos/" + listNoticia[1].UrlImagem;
                LblNoticia2.Text = listNoticia[1].Titulo;
                LblCorpoNoticia2.Text = CortaTexto(listNoticia[1].Noticia);
                HdnNoticia2Id.Value = listNoticia[1].IdNoticia.ToString();
            }
            else
            {
                linha2a.Visible = false;
            }
            if (listNoticia != null && listNoticia.Count > 2)
            {
                ImgNoticia3.ImageUrl = "/DownloadArquivos/" + listNoticia[2].UrlImagem;
                LblNoticia3.Text = listNoticia[2].Titulo;
                LblCorpoNoticia3.Text = CortaTexto(listNoticia[2].Noticia);
                HdnNoticia3Id.Value = listNoticia[2].IdNoticia.ToString();
            }
            else
            {
                linha3a.Visible = false;
            }
            if (listNoticia != null && listNoticia.Count > 3)
            {
                ImgNoticia4.ImageUrl = "/DownloadArquivos/" + listNoticia[3].UrlImagem;
                LblNoticia4.Text = listNoticia[3].Titulo;
                LblCorpoNoticia4.Text = CortaTexto(listNoticia[3].Noticia);
                HdnNoticia4Id.Value = listNoticia[3].IdNoticia.ToString();
            }
            else
            {
                linha4a.Visible = false;
            }
        }

        private String CortaTexto(String texto)
        {
            String res = "";
            try
            {
                while (res.Length < 400)
                {
                    res = res + texto.Substring(0, texto.IndexOf(" ")) + " ";
                    texto = texto.Substring(texto.IndexOf(" ") + 1);
                }
            }
            catch { }
            return res + "...";
        }

        protected void ImgBtnNoticia1_Click(object sender, ImageClickEventArgs e)
        {
            this.UCExibeNoticia1.Visualizar(int.Parse(HdnNoticia1Id.Value));
        }

        protected void ImgBtnNoticia2_Click(object sender, ImageClickEventArgs e)
        {
            this.UCExibeNoticia1.Visualizar(int.Parse(HdnNoticia2Id.Value));
        }

        protected void ImgBtnNoticia3_Click(object sender, ImageClickEventArgs e)
        {
            this.UCExibeNoticia1.Visualizar(int.Parse(HdnNoticia3Id.Value));
        }

        protected void ImgBtnNoticia4_Click(object sender, ImageClickEventArgs e)
        {
            this.UCExibeNoticia1.Visualizar(int.Parse(HdnNoticia4Id.Value));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.UCExibeNoticia1.Visualizar(int.Parse(HdnNoticia1Id.Value));
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            this.UCExibeNoticia1.Visualizar(int.Parse(HdnNoticia2Id.Value));
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            this.UCExibeNoticia1.Visualizar(int.Parse(HdnNoticia3Id.Value));
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.UCExibeNoticia1.Visualizar(int.Parse(HdnNoticia4Id.Value));
        }

        protected void ImgBtnVejaMais_Click(object sender, EventArgs e)
        {
            this.UCCadastroNoticiaCE1.Visualizar();
        }

    }
}