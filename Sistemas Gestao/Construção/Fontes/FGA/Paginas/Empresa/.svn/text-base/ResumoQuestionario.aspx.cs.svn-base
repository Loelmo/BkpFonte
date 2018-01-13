using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Sistema_de_Gestao.Pagina_Base;

namespace Sistema_de_Gestao.Paginas.Empresa
{
    public partial class ResumoQuestionario : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Reenvio"] != null)
            {
                MessageBox(this.Page, "Questionário enviado com sucesso! O número de protocolo é " + Request["Reenvio"]);
            }
            if (Request["IdTurma"] != null)
            {
                int IdTurma = int.Parse(Request["IdTurma"]);
                objTurma = new BllTurma().ObterPorId(IdTurma);
            }
            if (Request["QueroParticipar"] != null)
            {
                int IdQuestionario = int.Parse(Request["IdQuestionario"]);
                Boolean queroParticipar = false;
                if (Request["QueroParticipar"] == "1")
                {
                    queroParticipar = true;
                }
                AlteraParticipacao(IdQuestionario, queroParticipar);
                Response.Redirect("~/Paginas/Empresa/SelecionaQuestionario.aspx");
            }
            if (!IsPostBack)
            {
                CarregaDados();
            }
        }

        private void CarregaDados()
        {
            if (this.UsuarioLogado.IdUsuario > 0)
            {
                this.ImgBttnVoltar.Visible = true;
                this.LblEmpresaDigitador.Text = "  - Empresa: " + StringUtils.trataCpfCnpj(EmpresaLogada.CPF_CNPJ) + " ";
            }
            this.PopulaQuestionarios();
            this.VerificaEnvioDigitador();
            this.VerificaJaEnviado();
        }

        private void VerificaJaEnviado()
        {
            List<EntQuestionario> listaQuestionariosEnviados = new BllQuestionario().ObterEnviadosPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
            if (listaQuestionariosEnviados.Count > 0)
            {
                PnlQuestionarios.Style.Add("display", "block");
                BtnEnviar.Style.Add("display", "block");
                LblJaEnviado.Text = "O Questionário de Autoavaliação já foi enviado. O número do Protocolo é " + listaQuestionariosEnviados[0].Protocolo + ".";
                BtnEnviar.ImageUrl = "/Image/_file_send3.png";
            }
            else
            {
                LblJaEnviado.Visible = false;
            }
        }

        private void VerificaEnvioDigitador()
        {
            EntEtapa etapaInscricao = verificaEtapaInscricaoAberta();
            this.BtnEnviar.Visible = false;
            this.LblEnviaQuestionario.Visible = false;

            if (!etapaInscricao.Ativo)
            {
                if (UsuarioLogado.IdUsuario == 0)
                {
                    LblEtapaDesabilitada.Text = "A etapa de inscrição de empresas para este estado já se encontra encerrada.";
                }
                this.LblEtapaDesabilitada.Visible = true;
            }
            else
            {
                this.LblEtapaDesabilitada.Visible = false;
            }
            if (etapaInscricao.Ativo && VerificaQuestionariosPreenchidos())
            {
                PnlQuestionarios.Style.Add("display", "block");
                BtnEnviar.Style.Add("display", "block");
                LblEnviaQuestionario.Style.Add("display", "block");
                BtnEnviar.Style.Add("display", "block");

                this.BtnEnviar.Visible = true;
                this.LblEnviaQuestionario.Visible = true;
            }
        }

        private Boolean VerificaQuestionariosPreenchidos()
        {
            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
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

        private void PopulaQuestionarios()
        {
            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterResumoPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
            cdcatalog.DataSource = listaQuestionarios;
            cdcatalog.DataBind();
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            //realiza cálculo de questionário e envia o mesmo
            String Protocolo = new BllQuestionarioEmpresaCalculoPontuacao().CalculaPontuacoes(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro, UsuarioLogado.IdUsuario);
            MessageBox(this.Page, "Questionário enviado com sucesso! O número de protocolo é " + Protocolo);
            CarregaDados();
            Response.Redirect("/Paginas/Empresa/SelecionaQuestionario.aspx?Reenvio=" + Protocolo);
        }

        protected void ImgBttnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Paginas/InscricaoAdminCE.aspx");
        }

    }
}