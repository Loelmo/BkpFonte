using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.BLL;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCStatus : UCBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateControls();
        }

        public void UpdateControls()
        {
            this.ImgBttnVerificarRelatorios.Enabled = false;
            this.ImgBttnVerificarRelatorios.Style.Add("cursor", "default");

            // Preencher Cadastro
            EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
            objTurmaEmpresa.Turma.IdTurma = objTurma.IdTurma;
            objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = EmpresaLogada.IdEmpresaCadastro;
            objTurmaEmpresa = new BllTurmaEmpresa().ObterPorTurmaEmpresa(objTurmaEmpresa);
            this.ImgBttnPreencherCadastro.Enabled = true;
            if (this.Page.Title == "Cadastro Inscrição Empresa")
            {
                this.ImgBttnPreencherCadastro.ImageUrl = "~/Image/PreencheCadastro-Az.png";
            }
            else if ((EmpresaLogada.IdEmpresaCadastro == 0 || objTurmaEmpresa.CPFContato == "") && this.Page.Title != "Cadastro Inscrição Empresa")
            {
                this.ImgBttnPreencherCadastro.ImageUrl = "~/Image/PreencheCadastro.png";
            }
            else
            {
                this.ImgBttnPreencherCadastro.ImageUrl = "~/Image/PreencheCadastro-Vd.png";
            }


            // Responder Questionário
            List<EntQuestionarioEmpresa> lstQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioPorTurmaEmpresa(this.EmpresaLogada.IdEmpresaCadastro, this.objTurma.IdTurma);

            if (lstQuestionarioEmpresa == null)
            {
                this.ImgBttnResponderQuestionario.Enabled = false;
                this.ImgBttnResponderQuestionario.Style.Add("cursor", "default");
                this.ImgBttnResponderQuestionario.ImageUrl = "~/Image/ResponderQuest-C.png";

                // Enviar Questionário
                this.ImgBttnEnviarQuestionario.Enabled = false;
                this.ImgBttnEnviarQuestionario.Style.Add("cursor", "default");
                this.ImgBttnEnviarQuestionario.ImageUrl = "~/Image/EnviaQuestionario-C.png";
            }
            else
            {
                List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);

                Boolean bHistorico = false;
                Boolean bParticipa = false;

                foreach (EntQuestionario eq in listaQuestionarios)
                {
                    if (eq.EmpresaParticipa)
                    {
                        bParticipa = true;
                        if (eq.Obrigatorio)
                        {
                            if (eq.PorcentagemPreenchida > 0 && eq.PorcentagemPreenchida < 100)
                            {
                                bHistorico = true;
                                break;
                            }
                        }
                        else
                        {
                            if (eq.PorcentagemPreenchida >= 0 && eq.PorcentagemPreenchida < 100)
                            {
                                bHistorico = true;
                                break;
                            }
                        }
                    }
                }

                if (bHistorico && bParticipa)
                {
                    this.ImgBttnResponderQuestionario.Enabled = true;
                    this.ImgBttnResponderQuestionario.Style.Add("cursor", "pointer");
                    this.ImgBttnResponderQuestionario.ImageUrl = "~/Image/ResponderQuest-A.png";

                    // Enviar Questionário
                    this.ImgBttnEnviarQuestionario.Enabled = false;
                    this.ImgBttnEnviarQuestionario.Style.Add("cursor", "default");
                    this.ImgBttnEnviarQuestionario.ImageUrl = "~/Image/EnviaQuestionario-C.png";
                }
                else
                {


                    bHistorico = listaQuestionarios.Count > 0;
                    bParticipa = false;
                    foreach (EntQuestionario eq in listaQuestionarios)
                    {
                        if (eq.EmpresaParticipa)
                        {
                            bParticipa = true;
                            if (eq.PorcentagemPreenchida < 100)
                            {
                                bHistorico = false;
                                break;
                            }
                        }
                    }


                    if (bHistorico && bParticipa)
                    {
                        this.ImgBttnResponderQuestionario.Enabled = true;
                        this.ImgBttnResponderQuestionario.Style.Add("cursor", "pointer");
                        this.ImgBttnResponderQuestionario.ImageUrl = "~/Image/ResponderQuest-Vd.png";

                        // Enviar Questionário
                        this.ImgBttnEnviarQuestionario.Enabled = true;
                        this.ImgBttnEnviarQuestionario.Style.Add("cursor", "pointer");
                        this.ImgBttnEnviarQuestionario.ImageUrl = "~/Image/EnviaQuestionario-Vm.png";

                        // Gerar Relatório

                        EntEtapa objEtapa = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_FGA_INSCRICAO_AUTODIAGNOSTICO_EMPRESA, this.objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);

                        lstQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioEmpresaAtivoPorEmpresaEtapa(this.EmpresaLogada.IdEmpresaCadastro, objEtapa.IdEtapa);



                        //


                        Int32 nEmpresaParticipa = 0;
                        foreach (EntQuestionario eq in listaQuestionarios)
                        {
                            if (eq.EmpresaParticipa)
                            {
                                nEmpresaParticipa++;
                            }
                        }

                        Boolean bRelatorioGerado = false;
                        Int32 nEnviaQuestionario = 0;
                        foreach (EntQuestionarioEmpresa eq in lstQuestionarioEmpresa)
                        {
                            if (eq.EnviaQuestionario)
                            {
                                nEnviaQuestionario++;
                            }

                            bRelatorioGerado = eq.RelatorioGerado;
                        }

                        if (nEmpresaParticipa != nEnviaQuestionario)
                        {
                            this.ImgBttnVerificarRelatorios.Enabled = false;
                            this.ImgBttnVerificarRelatorios.Style.Add("cursor", "default");
                            this.ImgBttnVerificarRelatorios.ImageUrl = "~/Image/GerarRelatorio-C.png";
                        }
                        else
                        {
                            this.ImgBttnVerificarRelatorios.Enabled = true;
                            this.ImgBttnVerificarRelatorios.Style.Add("cursor", "pointer");
                            this.ImgBttnVerificarRelatorios.ImageUrl = "~/Image/GerarRelatorio-Vm.png";

                            // Enviar Questionário
                            this.ImgBttnEnviarQuestionario.Enabled = true;
                            this.ImgBttnEnviarQuestionario.Style.Add("cursor", "pointer");
                            this.ImgBttnEnviarQuestionario.ImageUrl = "~/Image/EnviaQuestionario-Vd.png";
                        }

                        if (bRelatorioGerado)
                        {
                            this.ImgBttnVerificarRelatorios.Enabled = true;
                            this.ImgBttnVerificarRelatorios.Style.Add("cursor", "pointer");
                            this.ImgBttnVerificarRelatorios.ImageUrl = "~/Image/GerarRelatorio-Vd.png";
                        }

                    }
                    else
                    {
                        this.ImgBttnResponderQuestionario.Enabled = true;
                        this.ImgBttnResponderQuestionario.Style.Add("cursor", "pointer");
                        this.ImgBttnResponderQuestionario.ImageUrl = "~/Image/ResponderQuest-Vm.png";

                        // Enviar Questionário
                        this.ImgBttnEnviarQuestionario.Enabled = false;
                        this.ImgBttnEnviarQuestionario.Style.Add("cursor", "default");
                        this.ImgBttnEnviarQuestionario.ImageUrl = "~/Image/EnviaQuestionario-C.png";
                    }

                }
            }
        }

        protected void ImgBttnPreencherCadastro_Click(object sender, ImageClickEventArgs e)
        {
            if (EmpresaLogada.IdEmpresaCadastro > 0)
            {
                Response.Redirect("/Paginas/CadastroInscricoesEmpresa.aspx");
            }
            else
            {
                Response.Redirect("/Paginas/CadastroInscricoesEmpresa.aspx?IdEmpresaCadastro=0&CpfCnpj=" + Session["CpfCnpj"]);
            }
        }

        protected void ImgBttnResponderQuestionario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Paginas/Empresa/SelecionaQuestionario.aspx");
        }

        protected void ImgBttnEnviarQuestionario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Paginas/Empresa/SelecionaQuestionario.aspx");
        }

        protected void ImgBttnVerificarRelatorios_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/FGA/Paginas/RelatorioRAA.aspx");
        }
    }
}