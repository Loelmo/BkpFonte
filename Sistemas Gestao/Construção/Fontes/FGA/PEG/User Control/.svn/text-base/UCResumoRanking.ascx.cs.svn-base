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
    public partial class UCResumoRanking : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImgBttnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            Gravar();

            this.Clear();
            this.Close();
        }

        private void Gravar()
        {
            Int32 IdQuestionarioEmpresa = int.Parse(this.HddnFldIdQuestionarioEmpresa.Value);

            new BllQuestionarioEmpresa().AlterarSomenteResumo(IdQuestionarioEmpresa, this.TxtBxResumo.Text);
        }

        public void Show(Int32 IdQuestionarioEmpresa)
        {
            this.HddnFldIdQuestionarioEmpresa.Value = IntUtils.ToString(IdQuestionarioEmpresa);
            this.TxtBxResumo.Text = new BllQuestionarioEmpresa().ObterResumoPorId(IdQuestionarioEmpresa);

            divUserControl.Visible = true;

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

        public void Close()
        {
            divUserControl.Visible = false;
        }
    }
}