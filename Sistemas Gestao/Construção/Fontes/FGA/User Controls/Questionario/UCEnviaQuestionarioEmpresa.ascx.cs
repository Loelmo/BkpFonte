using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using System.IO.Compression;
using Ionic.Zip;
using Vinit.SG.BLL;
using Vinit.SG.Ent;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCEnviaQuestionarioEmpresa : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImgBttnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            //realiza cálculo de questionário e envia o mesmo
            String Protocolo = new BllQuestionarioEmpresaCalculoPontuacao().CalculaPontuacoes(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro, UsuarioLogado.IdUsuario);
            MessageBox(this.Page, "Questionário enviado com sucesso! O número de protocolo é " + Protocolo);
            Response.Redirect("/Paginas/Empresa/SelecionaQuestionario.aspx?Reenvio=" + Protocolo);

            this.Clear();
            this.Close();
        }

        public void Show()
        {
            divUserControl.Visible = true;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
            Response.Redirect("~/Paginas/Empresa/SelecionaQuestionario.aspx");
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Close()
        {
            divUserControl.Visible = false;
        }
    }
}