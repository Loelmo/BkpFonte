using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using PEG.Utilitarios;

namespace PEG.User_Controls
{
    public partial class UCConfirmaEmail : UCBase
    {
        public delegate void EnviarEmail(String email);
        public EnviarEmail enviarEmail { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show()
        {
            this.Show("");
        }

        public void Show(String Url)
        {
            this.Clear();
            hddUrl.Value = Url;
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

        protected void ImgBttnEnviar_Click(object sender, EventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
            {
                enviarEmail(this.TxtBxEmail.Text);
                this.Close();
                MessageBox(this.Page, "Email enviado com sucesso!");
            }
            else
            {
                MessageBox(this.Page, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        private Boolean VerificaCamposObrigatoriosCadastro()
        {
            Boolean res = true;
            res &= Valida_TextBox(TxtBxEmail);

            return res;
        }
    }
}