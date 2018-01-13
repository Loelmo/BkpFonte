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
    public partial class UCSelecionaTurma : UCBase
    {
        private int IdTurma { get; set; }

        private int IdEmpCadastro { get; set; }

        private int NuOrdem { get; set; }

        private String LblTitulo { get; set; }

        private String TxDescricao { get; set; }

        private bool FlPrivado { get; set; }

        private bool FlParticipa { get; set; }

        private bool FlInscricaoAberta { get; set; }

        public UCSelecionaTurma()
        {
        }

        public UCSelecionaTurma(int NuOrdem, String LblTitulo, bool FlPrivado, bool FlParticipa, int IdEmpCadastro, int IdTurma, bool FlInscricaoAberta, String TxDescricao)
        {
            this.NuOrdem = NuOrdem;
            this.LblTitulo = LblTitulo;
            this.TxDescricao = TxDescricao;
            this.FlPrivado = FlPrivado;
            this.FlParticipa = FlParticipa;
            this.IdEmpCadastro = IdEmpCadastro;
            this.IdTurma = IdTurma;
            this.FlInscricaoAberta = FlInscricaoAberta;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (IdTurma == -1)
                {
                    PnlFundo.Visible = false;
                }
                else
                {
                    if (FlPrivado)
                    {
                        this.LblTipo.Text = "Turma Privada";
                    }
                    else
                    {
                        this.LblTipo.Text = "Turma Pública";
                    }
                    this.LblNome.Text = LblTitulo;
                    this.LblDescricao.Text = TxDescricao;
                    this.BtnAcessar.Attributes.Add("IdTurma", IdTurma.ToString());
                    this.BtnParticipar.Attributes.Add("IdTurma", IdTurma.ToString());

                    if (FlParticipa)
                    {
                        this.BtnParticipar.ImageUrl = "/Image/queroParticipar_selecionado.png";
                        this.BtnParticipar.PostBackUrl = "~/Paginas/Empresa/SelecionaTurma.aspx?IdTurma=" + this.IdTurma + "&QueroParticipar=0";
                        this.BtnAcessar.ImageUrl = "/Image/_file_AcessA.png";

                        if (new BllQuestionarioEmpresa().ObterQuestionarioPorTurmaEmpresa(EmpresaLogada.IdEmpresaCadastro, this.IdTurma) != null)
                            this.BtnAcessar.PostBackUrl = "~/Paginas/Empresa/SelecionaQuestionario.aspx?IdTurma=" + this.IdTurma;
                        else
                            this.BtnAcessar.PostBackUrl = "~/Paginas/CadastroInscricoesEmpresa.aspx?IdTurma=" + this.IdTurma + "&CpfCnpj=" + EmpresaLogada.CPF_CNPJ;
                    }
                    else
                    {
                        this.BtnParticipar.ImageUrl = "/Image/queroParticipar_nao_selecionado.png";
                        this.BtnAcessar.ImageUrl = "/Image/_file_AcessI.png";
                        EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
                        objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = EmpresaLogada.IdEmpresaCadastro;
                        objTurmaEmpresa.Turma.IdTurma = this.IdTurma;
                        objTurmaEmpresa = new BllTurmaEmpresa().ObterPorTurmaEmpresa(objTurmaEmpresa);
                        if (objTurmaEmpresa != null && objTurmaEmpresa.ParticipaPrograma)
                        {
                            this.BtnParticipar.PostBackUrl = "~/Paginas/Empresa/SelecionaTurma.aspx?IdTurma=" + this.IdTurma + "&QueroParticipar=0";
                            //this.BtnParticipar.PostBackUrl = "~/Paginas/Principal.aspx";
                        }
                        else
                        {
                            this.EmpresaLogada = new BllEmpresaCadastro().ObterPorId(EmpresaLogada.IdEmpresaCadastro);
                            this.BtnParticipar.PostBackUrl = "~/Paginas/Empresa/SelecionaTurma.aspx?IdTurma=" + this.IdTurma + "&QueroParticipar=1";
                        }
                        this.BtnAcessar.Enabled = false;
                    }

                    if (!FlInscricaoAberta)
                    {
                        this.BtnAcessar.Enabled = false;
                        this.BtnParticipar.Enabled = false;
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


        protected void BtnAcessar_Click(object sender, EventArgs e)
        {
        }

        protected void BtnParticipar_Click(object sender, EventArgs e)
        {
       }

    }
}