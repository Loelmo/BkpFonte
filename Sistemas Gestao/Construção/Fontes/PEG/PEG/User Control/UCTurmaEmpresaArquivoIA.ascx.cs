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
    public partial class UCTurmaEmpresaArquivoIA : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }

        private void Show()
        {
            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            this.Gravar();
            this.Close();

            if (atualizaGrid != null)
            {
                this.atualizaGrid();
            }

            this.Clear();
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        public void Editar(Int32 IdTurmaEmpresaArquivo)
        {
            this.Clear();

            EntTurmaEmpresaArquivo objTurmaEmpresaArquivo = new BllTurmaEmpresaArquivo().ObterPorId(IdTurmaEmpresaArquivo);
            this.ObjectToPage(objTurmaEmpresaArquivo);
            this.Show();
        }

        public void Inserir(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            this.HddnFldIdEmpresaCadastro.Value = IntUtils.ToString(IdEmpresaCadastro);
            this.HddnFldIdTurma.Value = IntUtils.ToString(IdTurma);
//            this.HddnFldArquivo.Value = IntUtils.ToString(IdTurmaEmpresaArquivo);
//            this.HddnFldIdTurmaEmpresaArquivo.Value = IntUtils.ToString(IdTurmaEmpresaArquivo);
            this.HddnFldIdTurmaEmpresaArquivo.Value = "0";
            this.TxtBxNome.Text = "";

            this.Show();
        }

        private Boolean PageToObject(EntTurmaEmpresaArquivo objTurmaEmpresaArquivo)
        {
            objTurmaEmpresaArquivo.IdTurmaEmpresaArquivo = StringUtils.ToInt(this.HddnFldIdTurmaEmpresaArquivo.Value);
            objTurmaEmpresaArquivo.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(this.HddnFldIdEmpresaCadastro.Value);
            objTurmaEmpresaArquivo.Turma.IdTurma = StringUtils.ToInt(this.HddnFldIdTurma.Value);
            objTurmaEmpresaArquivo.Usuario.IdUsuario = UsuarioLogado.IdUsuario;
            objTurmaEmpresaArquivo.Nome = this.TxtBxNome.Text;
            objTurmaEmpresaArquivo.Ativo = true;
            objTurmaEmpresaArquivo.DtCadastro = DateTime.Now;
            objTurmaEmpresaArquivo.DtAlteracao = DateTime.Now;

            if (Session["flNameArquivo"] != null)
            {
                objTurmaEmpresaArquivo.Arquivo = Session["flNameArquivo"].ToString();
                Session.Remove("flNameArquivo");
                return true;
            }
            return false;
        }

        private void ObjectToPage(EntTurmaEmpresaArquivo objTurmaEmpresaArquivo)
        {
            this.HddnFldIdTurmaEmpresaArquivo.Value = objTurmaEmpresaArquivo.IdTurmaEmpresaArquivo.ToString();
            this.HddnFldIdEmpresaCadastro.Value = objTurmaEmpresaArquivo.EmpresaCadastro.IdEmpresaCadastro.ToString();
            this.HddnFldIdTurma.Value = objTurmaEmpresaArquivo.Turma.IdTurma.ToString();
            this.TxtBxNome.Text = objTurmaEmpresaArquivo.Nome;
            this.HddnFldArquivo.Value = objTurmaEmpresaArquivo.Arquivo;
        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AsyncFileUpload1.HasFile)
            {
                String flNameArquivo = AsyncFileUpload1.FileName.Substring(0, AsyncFileUpload1.FileName.LastIndexOf(".")) + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + AsyncFileUpload1.FileName.Substring(AsyncFileUpload1.FileName.LastIndexOf("."));
                AsyncFileUpload1.SaveAs(Server.MapPath(this.PathDownloadArquivos + flNameArquivo));
                Session.Add("flNameArquivo", flNameArquivo);
            }
        }

        private void Gravar()
        {
            EntTurmaEmpresaArquivo objTurmaEmpresaArquivo = new EntTurmaEmpresaArquivo();

            if (!this.PageToObject(objTurmaEmpresaArquivo))
            {
                objTurmaEmpresaArquivo.Arquivo = HddnFldArquivo.Value;
            }
            
            try
            {
                //Verifica se é Insert ou Update
                if (objTurmaEmpresaArquivo.IdTurmaEmpresaArquivo == 0)
                {
                    objTurmaEmpresaArquivo = new BllTurmaEmpresaArquivo().Inserir(objTurmaEmpresaArquivo);
                    MessageBox(this.Page, "Anexo inserido com sucesso!");
                }
                else
                {
                    new BllTurmaEmpresaArquivo().Alterar(objTurmaEmpresaArquivo);
                    MessageBox(this.Page, "Anexo alterado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar o Anexo!");
            }
        }

    }
}