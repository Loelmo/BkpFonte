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
    public partial class EnviaQuestionario : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaDados();
            }
        }

        private void CarregaDados()
        {
            EntEtapa etapaInscricao = verificaEtapaAberta();
            if (!etapaInscricao.Ativo)
            {
                this.BtnEnviar.Enabled = false;
                this.LblEtapaDesabilitada.Visible = true;
            }
            this.PopulaQuestionarios(etapaInscricao);
        }

        private EntEtapa verificaEtapaAberta()
        {
            EntEtapa etapaInscricao = null;
            if (IdUsuarioLogado > 0)
            {
                etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_ADMINISTRATIVO, objTurma.IdTurma, this.EmpresaLogada.Estado.IdEstado);
            }
            else
            {
                etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_EMPRESA, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
            }
            return etapaInscricao;
        }

        private void PopulaQuestionarios(EntEtapa etapaInscricao)
        {
            List<EntQuestionario> listaQuestionariosEnviados = new BllQuestionario().ObterEnviadosPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
            if (listaQuestionariosEnviados.Count > 0)
            {
                EntTurmaEmpresaSatisfacao turmaEmpresaSatisfacao = new BllTurmaEmpresaSatisfacao().ObterPorTurmaEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
                if (turmaEmpresaSatisfacao == null)
                {
                    avaliacaoProcesso.Style.Add("display", "block");
                    PnlQuestionarios.Style.Add("display", "none");
                    BtnEnviar.Style.Add("display", "none");
                }
                else
                {
                    avaliacaoProcesso.Style.Add("display", "none");
                    PnlQuestionarios.Style.Add("display", "block");
                    BtnEnviar.Style.Add("display", "block");
                    relatorioJaEnviado.Style.Add("display", "block");
                    LblJaEnviado.Text = "Sua autoavaliação já foi enviada. O número do Protocolo é " + listaQuestionariosEnviados[0].Protocolo + ". Selecione a opção abaixo para fazer seu download:";
                    //Encaminha para página com pdf de RAA
                    String Url = "/MPE/Paginas/DownloadPDF.aspx?protocolo=" + listaQuestionariosEnviados[0].Protocolo + "&comentarios=false&programaId=" + objPrograma.IdPrograma;
                    HyperLink1.NavigateUrl = Url;

                    /*BtnEnviar.ImageUrl = "/Image/reenviar.gif";*/
                }
            }

            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
            int i = 1;
            foreach(EntQuestionario eq in listaQuestionarios){
                if (eq.EmpresaParticipa)
                {
                    object[] temp = new object[8];
                    temp[0] = eq.IdQuestionario;
                    temp[1] = i;
                    temp[2] = eq.Questionario;
                    temp[3] = eq.PorcentagemPreenchida;
                    temp[4] = eq.Obrigatorio;
                    temp[5] = this.EmpresaLogada.IdEmpresaCadastro;
                    temp[6] = this.objTurma.IdTurma;
                    temp[7] = etapaInscricao.Ativo;
                    Control QuestionarioControlTemp = LoadControl("~/User Controls/Questionario/UCEnviaQuestionarioEmpresa.ascx", temp);
                    if (i < 4)
                    {
                        i++;
                    }
                    else
                    {
                        i = 1;
                    }
                    if (eq.PorcentagemPreenchida < 100)
                    {
                        BtnEnviar.Enabled = false;
                    }

                    this.PnlQuestionarios.Controls.Add(QuestionarioControlTemp);
                }
            }
            while (i < 4)
            {
                Control QuestionarioControlTemp;
                object[] temp = new object[8];
                temp[0] = -1;
                temp[1] = i;
                temp[2] = "";
                temp[3] = -1;
                temp[4] = false;
                temp[5] = -1;
                temp[6] = -1;
                temp[7] = false;
                QuestionarioControlTemp = LoadControl("~/User Controls/Questionario/UCEnviaQuestionarioEmpresa.ascx", temp);
                this.PnlQuestionarios.Controls.Add(QuestionarioControlTemp);
                i++;
            }
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            //realiza cálculo de questionário e envia o mesmo
            String Protocolo = new BllQuestionarioEmpresaCalculoPontuacao().CalculaPontuacoes(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro, UsuarioLogado.IdUsuario);
            MessageBox(this.Page, "Questionário enviado com sucesso! Seu número de protocolo é " + Protocolo);
            CarregaDados();
        }

        protected void BtnEnviarPesquisa_Click(object sender, EventArgs e)
        {
            //Encaminha para página com pdf de RAA
            EntTurmaEmpresaSatisfacao sat = new EntTurmaEmpresaSatisfacao();
            sat.Turma.IdTurma = this.objTurma.IdTurma;
            sat.EmpresaCadastro.IdEmpresaCadastro = this.EmpresaLogada.IdEmpresaCadastro;
            if (pergunta1respostaA.Checked)
            {
                sat.Resposta1 = Label1.Text;
            }
            else if (pergunta1respostaB.Checked)
            {
                sat.Resposta1 = Label2.Text;
            }
            else if (pergunta1respostaC.Checked)
            {
                sat.Resposta1 = Label3.Text;
            }

            if (pergunta2respostaA.Checked)
            {
                sat.Resposta2 = Label1.Text;
            }
            else if (pergunta2respostaB.Checked)
            {
                sat.Resposta2 = Label2.Text;
            }
            else if (pergunta2respostaC.Checked)
            {
                sat.Resposta2 = Label3.Text;
            }
            if (pergunta3respostaA.Checked)
            {
                sat.Resposta3 = Label1.Text;
            }
            else if (pergunta3respostaB.Checked)
            {
                sat.Resposta3 = Label2.Text;
            }
            else if (pergunta3respostaC.Checked)
            {
                sat.Resposta3 = Label3.Text;
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

    }
}