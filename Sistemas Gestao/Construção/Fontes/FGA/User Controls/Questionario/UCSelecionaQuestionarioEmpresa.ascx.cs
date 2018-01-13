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

namespace Sistema_de_Gestao.User_Controls.Questionario
{
    public partial class UCSelecionaQuestionarioEmpresa : UCBase
    {
        private int IdQuestionario { get; set; }

        private int IdEmpCadastro { get; set; }

        private int IdTurma { get; set; }

        private int NuOrdem { get; set; }

        private String LblTitulo { get; set; }

        private int NuPorcentagem { get; set; }

        private bool FlObrigatorio { get; set; }

        private bool FlParticipa { get; set; }

        private bool FlInscricaoAberta { get; set; }

        public UCSelecionaQuestionarioEmpresa()
        {
        }

        public UCSelecionaQuestionarioEmpresa(int IdQuestionario, int NuOrdem, String LblTitulo, int NuPorcentagem, bool FlObrigatorio, bool FlParticipa, int IdEmpCadastro, int IdTurma, bool FlInscricaoAberta)
        {
            this.IdQuestionario = IdQuestionario;
            this.NuOrdem = NuOrdem;
            this.LblTitulo = LblTitulo;
            this.NuPorcentagem = NuPorcentagem;
            this.FlObrigatorio = FlObrigatorio;
            this.FlParticipa = FlParticipa;
            this.IdEmpCadastro = IdEmpCadastro;
            this.IdTurma = IdTurma;
            this.FlInscricaoAberta = FlInscricaoAberta;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (IdQuestionario == -1)
                {
                    PnlFundo.Visible = false;
                }
                else
                {
                    if (FlObrigatorio)
                    {
                        this.LblTipo.Text = "Obrigatório";
                        this.BtnParticipar.Visible = false;
                    }
                    else
                    {
                        this.LblTipo.Text = "Opcional";
                    }
                    this.LblNome.Text = LblTitulo;
                    this.LblPorcentagem.Text = NuPorcentagem + " % Concluído";
                    this.BtnResponder.Attributes.Add("IdQuestionario", IdQuestionario.ToString());
                    this.BtnParticipar.Attributes.Add("IdQuestionario", IdQuestionario.ToString());

                    if (FlParticipa)
                    {
                        this.BtnParticipar.ImageUrl = "/Image/queroPreencher_selecionado.png";
                        this.BtnParticipar.PostBackUrl = "~/Paginas/Empresa/SelecionaQuestionario.aspx?IdQuestionario=" + this.IdQuestionario + "&QueroParticipar=0";
                        EntQuestionarioEmpresa questionarioAberto = new BllQuestionarioEmpresa().ObterQuestionarioAberto(this.IdQuestionario, this.IdEmpCadastro, this.IdTurma);
                        EntPergunta proximaPergunta = new BllPergunta().ObterProximaPerguntaQuestionario(questionarioAberto.IdQuestionarioEmpresa, this.IdQuestionario);
                        this.BtnResponder.PostBackUrl = "~/Paginas/Empresa/RespondePerguntaQuestionario.aspx?IdQuestionario=" + this.IdQuestionario + "&IdQuestionarioEmpresa=" + questionarioAberto.IdQuestionarioEmpresa + "&IdEmpresaCadastro=" + IdEmpCadastro + "&IdTurma=" + IdTurma + "&IdPergunta=" + proximaPergunta.IdPergunta;
                    }
                    else
                    {
                        this.BtnParticipar.ImageUrl = "/Image/queroPreencher_nao_selecionado.png";
                        this.BtnParticipar.PostBackUrl = "~/Paginas/Empresa/SelecionaQuestionario.aspx?IdQuestionario=" + this.IdQuestionario + "&QueroParticipar=1";
                        this.BtnResponder.Enabled = false;
                    }
                    if (FlObrigatorio)
                    {
                        this.BtnParticipar.Enabled = false;
                    }

                    if (!FlInscricaoAberta)
                    {
                        this.BtnResponder.Enabled = false;
                        this.BtnResponder.Style.Add("cursor", "default");
                        this.BtnParticipar.Enabled = false;
                        this.BtnParticipar.Style.Add("cursor", "default");
                    }
                }

                if (NuOrdem == 1)
                {
                    this.LtrQuebraLinhaInicio.Text = "<tr>";
                }
                else if (NuOrdem == 4)
                {
                    this.LtrQuebraLinhaFim.Text = "</tr>";
                }
            }
        }


        protected void BtnParticipar_Click(object sender, EventArgs e)
        {
        }

        protected void BtnResponder_Click(object sender, EventArgs e)
        {
       }

    }
}