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
using System.IO;

namespace PEG.User_Controls
{
    public partial class UCPerguntaAvaliar : UCBase
    {

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        private void Show()
        {
            this.divUserControl.Visible = true;

            if (!ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar))
            {
                EnableControl(this.PnlFundo.Controls, false);
                this.ImgBttnGravar.Visible = false;
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, true);
                this.ImgBttnGravar.Visible = true;
            }
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Gravar())
            {
                this.Clear();
                this.Close();

                if (atualizaGrid != null)
                {
                    this.atualizaGrid();
                }
            }
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Editar(Int32 IdQuestionarioEmpresa, Int32 IdPergunta)
        {
            EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta = new BllQuestionarioEmpresaResposta().ObterRespostaEmpresaPorQuestionarioEmpresaPergunta(IdQuestionarioEmpresa, IdPergunta);
            objQuestionarioEmpresaResposta.Pergunta = new BllPergunta().ObterPerguntaPorQuestionarioEmpresaPergunta(IdQuestionarioEmpresa, objQuestionarioEmpresaResposta.Pergunta.IdPergunta, true);
            objQuestionarioEmpresaResposta.UsuarioAvaliador.IdUsuario = UsuarioLogado.IdUsuario;
            this.ObjectToPage(objQuestionarioEmpresaResposta);
            this.Show();
        }

        private EntQuestionarioEmpresaResposta PageToObject()
        {
            EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta = new EntQuestionarioEmpresaResposta();
            objQuestionarioEmpresaResposta.Pergunta.PerguntaTipo.IdPerguntaTipo = int.Parse(HddnFldIdTipoPergunta.Value);
            objQuestionarioEmpresaResposta.Pergunta.IdPergunta = int.Parse(HddnFldIdPergunta.Value);
            objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa = int.Parse(HddnFldIdQuestionarioEmpresa.Value);

            switch (objQuestionarioEmpresaResposta.Pergunta.PerguntaTipo.IdPerguntaTipo)
            {
                case EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES:
                    this.UCPerguntaMultiplaEscolha4Opcoes1.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_3_OPCOES:
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_TEXTO:
                    this.UCPerguntaTexto1.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_SIM_NAO:
                    this.UCPerguntaSimNao1.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_31_QUESTIONARIO_GESTAO_2009_2010:
                    this.UCPerguntaEspecialGestao311.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_1_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010:
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_6_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010:
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_3_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011:
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_7A_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011:
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_8B_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011:
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_32_QUESTIONARIO_GESTAO_2011:
                    this.UCPerguntaEspecialGestao32_1.Gravar(this.TxtPontoForte.Text, this.TxtOportunidade.Text);
                    break;
            }

            return objQuestionarioEmpresaResposta;
        }

        private void ObjectToPage(EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta)
        {
            OcultaUserControls();
            HddnFldIdPergunta.Value = objQuestionarioEmpresaResposta.Pergunta.IdPergunta.ToString();
            HddnFldIdQuestionarioEmpresa.Value = objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa.ToString();
            HddnFldIdTipoPergunta.Value = objQuestionarioEmpresaResposta.Pergunta.PerguntaTipo.IdPerguntaTipo.ToString();
            LblTituloPergunta.Text = objQuestionarioEmpresaResposta.Pergunta.NumeroQuestao;
            Label5.Text = objQuestionarioEmpresaResposta.Pergunta.Pergunta;
            TxtOportunidade.Text = objQuestionarioEmpresaResposta.OportunidadeMelhoria;
            TxtPontoForte.Text = objQuestionarioEmpresaResposta.PontoForte;
            objQuestionarioEmpresaResposta.Pergunta = new BllPergunta().ObterPerguntaPorQuestionarioEmpresaPergunta(objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa, objQuestionarioEmpresaResposta.Pergunta.IdPergunta, true);
            if (objQuestionarioEmpresaResposta.Pergunta == null)
            {
                objQuestionarioEmpresaResposta.Pergunta = new BllPergunta().ObterPerguntaPorQuestionarioEmpresaPergunta(objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa, objQuestionarioEmpresaResposta.Pergunta.IdPergunta, false);
            }
            objQuestionarioEmpresaResposta.Pergunta.QuestionarioEmpresaResposta = objQuestionarioEmpresaResposta;

            switch (objQuestionarioEmpresaResposta.Pergunta.PerguntaTipo.IdPerguntaTipo)
            {
                case EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES:
                    this.UCPerguntaMultiplaEscolha4Opcoes1.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario, 
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaMultiplaEscolha4Opcoes1.Visible = true;

                    this.UCPerguntaEspecialGestao311.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_3_OPCOES:
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario, 
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaMultiplaEscolha3Opcoes1.Visible = true;

                    this.UCPerguntaEspecialGestao311.Dispose();
                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_TEXTO:
                    this.UCPerguntaTexto1.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario, 
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaTexto1.Visible = true;

                    this.UCPerguntaEspecialGestao311.Dispose();
                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_SIM_NAO:
                    this.UCPerguntaSimNao1.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario, 
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaSimNao1.Visible = true;

                    this.UCPerguntaEspecialGestao311.Dispose();
                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_31_QUESTIONARIO_GESTAO_2009_2010:
                    this.UCPerguntaEspecialGestao311.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario, 
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaEspecialGestao311.Visible = true;

                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_32_QUESTIONARIO_GESTAO_2011:
                    this.UCPerguntaEspecialGestao32_1.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaEspecialGestao32_1.Visible = true;

                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao311.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_1_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010:
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario, 
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaEspecialResponsabilidadeSocial11.Visible = true;

                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaEspecialGestao311.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_6_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010:
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario, 
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaEspecialResponsabilidadeSocial61.Visible = true;

                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaEspecialGestao311.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_3_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011:
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Visible = true;

                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaEspecialGestao311.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_7A_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011:
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Visible = true;

                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaEspecialGestao311.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
                case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_8B_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011:
                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Editar(objQuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objQuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma,
                        objQuestionarioEmpresaResposta.Pergunta);

                    this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Visible = true;

                    this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                    this.UCPerguntaMultiplaEscolha3Opcoes1.Dispose();
                    this.UCPerguntaSimNao1.Dispose();
                    this.UCPerguntaTexto1.Dispose();
                    this.UCPerguntaEspecialGestao311.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                    this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                    this.UCPerguntaEspecialGestao32_1.Dispose();
                    break;
            }
        }

        private void OcultaUserControls()
        {
            this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Visible = false;
            this.UCPerguntaMultiplaEscolha4Opcoes1.Visible = false;
            this.UCPerguntaMultiplaEscolha3Opcoes1.Visible = false;
            this.UCPerguntaSimNao1.Visible = false;
            this.UCPerguntaTexto1.Visible = false;
            this.UCPerguntaEspecialGestao311.Visible = false;
            this.UCPerguntaEspecialResponsabilidadeSocial61.Visible = false;
            this.UCPerguntaEspecialResponsabilidadeSocial3_1.Visible = false;
            this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Visible = false;
            this.UCPerguntaEspecialResponsabilidadeSocial11.Visible = false;
            this.UCPerguntaEspecialGestao32_1.Visible = false;
        }

        private Boolean Gravar()
        {
            EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta = PageToObject();

            MessageBox(this.Page, "Avaliação inserida com sucesso!");

            return true;
        }

    }
}