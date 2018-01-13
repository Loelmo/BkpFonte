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
    public partial class UCPlanoAcaoIA : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

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

        public void Editar(Int32 IdPlanoAcao, Boolean permiteEdicao)
        {
            this.Clear();

            EntPlanoAcao objPlanoAcao = new BllPlanoAcao().ObterPorId(IdPlanoAcao);
            this.ObjectToPage(objPlanoAcao, permiteEdicao);
            this.Show();
        }

        public void Inserir(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            this.HddnFldIdEmpresaCadastro.Value = IntUtils.ToString(IdEmpresaCadastro);
            this.HddnFldIdTurma.Value = IntUtils.ToString(IdTurma);
//            this.HddnFldIdPlanoAcao.Value = IntUtils.ToString(IdPlanoAcao);
            this.HddnFldIdPlanoAcao.Value = "0";
            this.TxtBxAcaoCorrespondente.Text = "";
            this.TxtBxPlanoAcao.Text = "";
            this.TxtBxPontoMelhoria.Text = "";
            this.TxtBxPrazo.Text = "";
            this.TxtBxResponsavel.Text = "";

            this.Show();
        }

        private void PageToObject(EntPlanoAcao objPlanoAcao)
        {
            objPlanoAcao.IdPlanoAcao = StringUtils.ToInt(this.HddnFldIdPlanoAcao.Value);
            objPlanoAcao.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(this.HddnFldIdEmpresaCadastro.Value);
            objPlanoAcao.Turma.IdTurma = StringUtils.ToInt(this.HddnFldIdTurma.Value);
            objPlanoAcao.Usuario.IdUsuario = UsuarioLogado.IdUsuario;
            objPlanoAcao.AcaoCorrespondente = this.TxtBxAcaoCorrespondente.Text;
            objPlanoAcao.PlanoAcao = this.TxtBxPlanoAcao.Text;
            objPlanoAcao.PontoMelhoria = this.TxtBxPontoMelhoria.Text;
            objPlanoAcao.Prazo = this.TxtBxPrazo.Text;
            objPlanoAcao.Responsavel = this.TxtBxResponsavel.Text;
            objPlanoAcao.Ativo = true;
            objPlanoAcao.DtCadastro = DateTime.Now;
            objPlanoAcao.DtAlteracao = DateTime.Now;

        }

        private void ObjectToPage(EntPlanoAcao objPlanoAcao, Boolean permiteEdicao)
        {
            this.HddnFldIdPlanoAcao.Value = objPlanoAcao.IdPlanoAcao.ToString();
            this.HddnFldIdEmpresaCadastro.Value = objPlanoAcao.EmpresaCadastro.IdEmpresaCadastro.ToString();
            this.HddnFldIdTurma.Value = objPlanoAcao.Turma.IdTurma.ToString();
            this.TxtBxPlanoAcao.Text = objPlanoAcao.PlanoAcao;
            this.TxtBxAcaoCorrespondente.Text = objPlanoAcao.AcaoCorrespondente;
            this.TxtBxPontoMelhoria.Text = objPlanoAcao.PontoMelhoria;
            this.TxtBxPrazo.Text = objPlanoAcao.Prazo;
            this.TxtBxResponsavel.Text = objPlanoAcao.Responsavel;

            if (!permiteEdicao)
            {
                this.TxtBxPlanoAcao.Enabled = false;
                this.TxtBxAcaoCorrespondente.Enabled = false;
                this.TxtBxPontoMelhoria.Enabled = false;
                this.TxtBxPrazo.Enabled = false;
                this.TxtBxResponsavel.Enabled = false;
            }
            else
            {
                this.TxtBxPlanoAcao.Enabled = true;
                this.TxtBxAcaoCorrespondente.Enabled = true;
                this.TxtBxPontoMelhoria.Enabled = true;
                this.TxtBxPrazo.Enabled = true;
                this.TxtBxResponsavel.Enabled = true;
            }
        }

        private void Gravar()
        {
            EntPlanoAcao objPlanoAcao = new EntPlanoAcao();

            this.PageToObject(objPlanoAcao);
            
            try
            {
                //Verifica se é Insert ou Update
                if (objPlanoAcao.IdPlanoAcao == 0)
                {
                    objPlanoAcao = new BllPlanoAcao().Inserir(objPlanoAcao);
                    MessageBox(this.Page, "Plano de Ação inserido com sucesso!");
                }
                else
                {
                    new BllPlanoAcao().Alterar(objPlanoAcao);
                    MessageBox(this.Page, "Plano de Ação alterado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar o Plano de Ação!");
            }
        }

    }
}