using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCListaQuestionariosDigitador : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCQuestionarioResponder1.atualizaGrid += this.AtualizaGridPerguntas;
        }

        private void Show()
        {
            this.divUserControl.Visible = true;

            if (!ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar))
            {
                EnableControl(this.PnlFundo.Controls, false);
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, true);
            }
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        public void Editar(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            this.HddnFldIdEmpresaCadastro.Value = IdEmpresaCadastro.ToString();
            this.HddnFldIdTurma.Value = IdTurma.ToString();
            AtualizaGridPerguntas();
            if (VerificaQuestionariosPreenchidos())
            {
                ImageButton1.Visible = true;
            }
            else
            {
                ImageButton1.Visible = false;
            }
            this.Show();
        }

        private Boolean VerificaQuestionariosPreenchidos()
        {
            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(int.Parse(HddnFldIdTurma.Value), int.Parse(HddnFldIdEmpresaCadastro.Value));
            Boolean preenchimentoFinalizado = true;
            foreach (EntQuestionario eq in listaQuestionarios)
            {
                if (eq.EmpresaParticipa)
                {
                    if (eq.PorcentagemPreenchida < 100)
                    {
                        preenchimentoFinalizado = false;
                    }
                }
            }
            return preenchimentoFinalizado;
        }

        private void AtualizaGridPerguntas()
        {
            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(int.Parse(HddnFldIdTurma.Value), int.Parse(HddnFldIdEmpresaCadastro.Value));
            this.grdPerguntas.DataSource = listaQuestionarios;
            this.grdPerguntas.DataBind();
            this.grdPerguntas.SelectedIndex = -1;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        protected void grdPerguntas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPerguntas.PageIndex = e.NewPageIndex;
            AtualizaGridPerguntas();
        }

        protected void ImgBttnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            this.Close();
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            //realiza cálculo de questionário e envia o mesmo
            String Protocolo = new BllQuestionarioEmpresaCalculoPontuacao().CalculaPontuacoes(int.Parse(HddnFldIdTurma.Value), int.Parse(HddnFldIdEmpresaCadastro.Value), UsuarioLogado.IdUsuario);
            MessageBox(this.Page, "Questionário enviado com sucesso! O número de protocolo é " + Protocolo);
        }

        protected void grdPerguntas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void grdPerguntas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Index = ObjectUtils.ToInt(e.CommandArgument) - (grdPerguntas.PageIndex * grdPerguntas.PageSize);

            if (e.CommandName == "Responder")
            {
                Label lblIdQuestionario = ((Label)grdPerguntas.Rows[Index].FindControl("lblIdQuestionario"));
                int IdQuestionario = StringUtils.ToInt(lblIdQuestionario.Text);
                this.grdPerguntas.SelectedIndex = -1;
                EntQuestionarioEmpresa objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioAberto(IdQuestionario, int.Parse(HddnFldIdEmpresaCadastro.Value), int.Parse(HddnFldIdTurma.Value));
                this.UCQuestionarioResponder1.Editar(objQuestionarioEmpresa.IdQuestionarioEmpresa);
            }
        }
    }
}