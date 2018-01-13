using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using PEG.Pagina_Base;

namespace PEG.Paginas.Empresa
{
    public partial class SelecionaQuestionario : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Reenvio"] != null)
            {
                MessageBox(this.Page, "Questionário enviado com sucesso! O número de protocolo é " + Request["Reenvio"] + ". Para visualizá-lo, clique na seta Histórico de Relatórios.");
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
                LblJaEnviado.Text = "O autodiagnóstico já foi enviado. O número do protocolo é " + listaQuestionariosEnviados[0].Protocolo + ".";
                LblEnviaQuestionario.Text = "Para acessar o Relatório de Autodiagnóstico com os pontos fortes e oportunidades de melhorias para sua empresa, clique na seta \"Histórico de Relatórios\".";
                LblEnviaQuestionario2.Text = "Para reenviar o seu autodiagnóstico, caso tenha feito alguma alteração, selecione a opção REENVIAR.";
                BtnEnviar.ImageUrl = "/Image/_file_send3.png";
            }
            else
            {
                LblJaEnviado.Visible = false;
                LblEnviaQuestionario.Text = "Para enviar o seu autodiagnóstico selecione a opção ENVIAR.";
                LblEnviaQuestionario2.Text = "Após o envio para acessar o Relatório de Autodiagnóstico com os pontos fortes e oportunidades de melhorias para sua empresa, clique na seta \"Histórico de Relatórios\".";
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
                EntTurmaEmpresaSatisfacao turmaEmpresaSatisfacao = new BllTurmaEmpresaSatisfacao().ObterPorTurmaEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
                if (turmaEmpresaSatisfacao == null && UsuarioLogado.IdUsuario == 0)
                {
                    PnlQuestionarios.Style.Add("display", "none");
                    BtnEnviar.Style.Add("display", "none");
                    LblEnviaQuestionario.Style.Add("display", "none");
                    BtnEnviar.Style.Add("display", "none");
                }
                else
                {
                    PnlQuestionarios.Style.Add("display", "block");
                    BtnEnviar.Style.Add("display", "block");
                    LblEnviaQuestionario.Style.Add("display", "block");
                    BtnEnviar.Style.Add("display", "block");
                }

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
            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
            EntEtapa etapaInscricao = verificaEtapaInscricaoAberta();
            int i = 1;
            foreach(EntQuestionario eq in listaQuestionarios){
                object[] temp = new object[9];
                temp[0] = eq.IdQuestionario;
                temp[1] = i;
                temp[2] = eq.Questionario;
                temp[3] = eq.PorcentagemPreenchida;
                temp[4] = eq.Obrigatorio;
                temp[5] = eq.EmpresaParticipa;
                temp[6] = this.EmpresaLogada.IdEmpresaCadastro;
                temp[7] = this.objTurma.IdTurma;
                temp[8] = etapaInscricao.Ativo;
                Control QuestionarioControlTemp = LoadControl("~/User Controls/Questionario/UCSelecionaQuestionarioEmpresa.ascx", temp);
                if (i < 4)
                {
                    i++;
                }
                else
                {
                    i = 1;
                }
                this.PnlQuestionarios.Controls.Add(QuestionarioControlTemp);
            }
            while (i < 4)
            {
                Control QuestionarioControlTemp;
                object[] temp = new object[9];
                temp[0] = -1;
                temp[1] = i;
                temp[2] = "";
                temp[3] = -1;
                temp[4] = false;
                temp[5] = false;
                temp[6] = -1;
                temp[7] = -1;
                temp[8] = false;
                QuestionarioControlTemp = LoadControl("~/User Controls/Questionario/UCSelecionaQuestionarioEmpresa.ascx", temp);
                this.PnlQuestionarios.Controls.Add(QuestionarioControlTemp);
                i++;
            }

            listaQuestionarios = new BllQuestionario().ObterResumoPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
            i = 0;
            while (i < listaQuestionarios.Count)
            {
                if (listaQuestionarios[i].EmpresaParticipa)
                {
                    i++;
                }
                else
                {
                    listaQuestionarios.RemoveAt(i);
                }
            }
            cdcatalog.DataSource = listaQuestionarios;
            cdcatalog.DataBind();

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            //realiza cálculo de questionário e envia o mesmo
            String Protocolo = new BllQuestionarioEmpresaCalculoPontuacao().CalculaPontuacoes(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro, UsuarioLogado.IdUsuario);
            MessageBox(this.Page, "Questionário enviado com sucesso! O número de protocolo é " + Protocolo + ". Para visualizá-lo, clique na seta Histórico de Relatórios.");
            CarregaDados();
            Response.Redirect("/Paginas/Empresa/SelecionaQuestionario.aspx?Reenvio=" + Protocolo);
        }

        protected void ImgBttnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Paginas/InscricaoAdminCE.aspx");
        }

    }
}