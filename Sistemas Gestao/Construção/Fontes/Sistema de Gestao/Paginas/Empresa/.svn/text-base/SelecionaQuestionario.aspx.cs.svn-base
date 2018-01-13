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
                if (objPrograma.IdPrograma == EntPrograma.PROGRAMA_MPE)
                {
                    lblAvisoPreenchimentoMpe.Visible = true;
                }
                else
                {
                    lblAvisoPreenchimentoMpe.Visible = false;
                }
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
                LblJaEnviado.Text = "A autoavaliação desta empresa já foi enviada. O número do Protocolo é " + listaQuestionariosEnviados[0].Protocolo + ". Selecione a opção abaixo para fazer seu download:";
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
                EntTurmaEmpresaSatisfacao turmaEmpresaSatisfacao = new BllTurmaEmpresaSatisfacao().ObterPorTurmaEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
                if (turmaEmpresaSatisfacao == null && UsuarioLogado.IdUsuario == 0)
                {
                    avaliacaoProcesso.Style.Add("display", "block");
                    PnlQuestionarios.Style.Add("display", "none");
                    BtnEnviar.Style.Add("display", "none");
                    LblEnviaQuestionario.Style.Add("display", "none");
                    BtnEnviar.Style.Add("display", "none");
                }
                else
                {
                    avaliacaoProcesso.Style.Add("display", "none");
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

        protected void BtnEnviarPesquisa_Click(object sender, EventArgs e)
        {
            //Encaminha para página com pdf de RAA
            EntTurmaEmpresaSatisfacao sat = new EntTurmaEmpresaSatisfacao();
            sat.Turma.IdTurma = this.objTurma.IdTurma;
            sat.EmpresaCadastro.IdEmpresaCadastro = this.EmpresaLogada.IdEmpresaCadastro;
            if (pergunta1respostaA.Checked)
            {
                sat.Resposta1 = Label31.Text;
            }
            else if (pergunta1respostaB.Checked)
            {
                sat.Resposta1 = Label32.Text;
            }
            else if (pergunta1respostaC.Checked)
            {
                sat.Resposta1 = Label33.Text;
            }

            if (pergunta2respostaA.Checked)
            {
                sat.Resposta2 = Label31.Text;
            }
            else if (pergunta2respostaB.Checked)
            {
                sat.Resposta2 = Label32.Text;
            }
            else if (pergunta2respostaC.Checked)
            {
                sat.Resposta2 = Label33.Text;
            }
            if (pergunta3respostaA.Checked)
            {
                sat.Resposta3 = Label31.Text;
            }
            else if (pergunta3respostaB.Checked)
            {
                sat.Resposta3 = Label32.Text;
            }
            else if (pergunta3respostaC.Checked)
            {
                sat.Resposta3 = Label33.Text;
            }

            if (sat.Resposta1 == null || sat.Resposta1 == "" || sat.Resposta2 == null || sat.Resposta2 == "" || sat.Resposta3 == null || sat.Resposta3 == "")
            {
                MessageBox(this.Page, "Por favor, selecione uma opção para cada pergunta.");
                return;
            }
            new BllTurmaEmpresaSatisfacao().Excluir(sat);
            new BllTurmaEmpresaSatisfacao().Inserir(sat);
            MessageBox(this.Page, "Pesquisa enviada com sucesso!");
            CarregaDados();
        }

        protected void ImgBttnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Paginas/InscricaoAdminCE.aspx");
        }

    }
}