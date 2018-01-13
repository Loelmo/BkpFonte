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
    public partial class RespondePerguntaQuestionario : PaginaBase
    {
        private int IdQuestionario { get; set; }

        private int IdQuestionarioEmpresa { get; set; }

        private int IdEmpresaCadastro { get; set; }

        private int IdTurma { get; set; }

        private int IdPergunta { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.IdQuestionario = int.Parse(Request["IdQuestionario"]);
                this.IdEmpresaCadastro = int.Parse(Request["IdEmpresaCadastro"]);
                this.IdQuestionarioEmpresa = int.Parse(Request["IdQuestionarioEmpresa"]);
                this.IdTurma = int.Parse(Request["IdTurma"]);
                this.IdPergunta = int.Parse(Request["IdPergunta"]);
                this.PopulaPergunta();
            }
        }

        private void PopulaPergunta()
        {
            EntQuestionario questionario = new BllQuestionario().ObterPorId(IdQuestionario);
            this.lblNomeQuestionario.Text = questionario.Questionario;
            if (IdUsuarioLogado > 0)
            {
                String cnpj = new BllEmpresaCadastro().ObterPorId(IdEmpresaCadastro).CPF_CNPJ;
                this.lblNomeQuestionario.Text = this.lblNomeQuestionario.Text + " - Empresa: " + cnpj;
            }

            if (questionario.PreenchimentoRapido || this.IdUsuarioLogado > 0)
            {
                switch (questionario.IdQuestionario)
                {
                    case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2009:
                    case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2011:
                        this.UCAdministrativoEmpreendedorismo1.IdQuestionario = IdQuestionario;
                        this.UCAdministrativoEmpreendedorismo1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCAdministrativoEmpreendedorismo1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCAdministrativoEmpreendedorismo1.IdTurma = IdTurma;

                        this.UCAdministrativoEmpreendedorismo1.Visible = true;

                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2009:
                        this.UCAdministrativoResponsabilidadeSocial1.IdQuestionario = IdQuestionario;
                        this.UCAdministrativoResponsabilidadeSocial1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCAdministrativoResponsabilidadeSocial1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCAdministrativoResponsabilidadeSocial1.IdTurma = IdTurma;

                        this.UCAdministrativoResponsabilidadeSocial1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2011:
                        this.UCAdministrativoResponsabilidadeSocial2011_1.IdQuestionario = IdQuestionario;
                        this.UCAdministrativoResponsabilidadeSocial2011_1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCAdministrativoResponsabilidadeSocial2011_1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCAdministrativoResponsabilidadeSocial2011_1.IdTurma = IdTurma;

                        this.UCAdministrativoResponsabilidadeSocial2011_1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntQuestionario.QUESTIONARIO_GESTAO_2009:
                        this.UCAdministrativoGestao1.IdQuestionario = IdQuestionario;
                        this.UCAdministrativoGestao1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCAdministrativoGestao1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCAdministrativoGestao1.IdTurma = IdTurma;

                        this.UCAdministrativoGestao1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntQuestionario.QUESTIONARIO_GESTAO_2011:
                        this.UCAdministrativoGestao2011_1.IdQuestionario = IdQuestionario;
                        this.UCAdministrativoGestao2011_1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCAdministrativoGestao2011_1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCAdministrativoGestao2011_1.IdTurma = IdTurma;

                        this.UCAdministrativoGestao2011_1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntQuestionario.QUESTIONARIO_INOVACAO_2011:
                        this.UCAdministrativoInovacao1.IdQuestionario = IdQuestionario;
                        this.UCAdministrativoInovacao1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCAdministrativoInovacao1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCAdministrativoGestao2011_1.IdTurma = IdTurma;

                        this.UCAdministrativoInovacao1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                }
            }
            else
            {
                EntPergunta proximaPergunta = new BllPergunta().ObterPerguntaPorQuestionarioEmpresaPergunta(IdQuestionarioEmpresa, IdPergunta, false);

                switch (proximaPergunta.PerguntaTipo.IdPerguntaTipo)
                {
                    case EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES:
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Pergunta = proximaPergunta;
                        this.UCPerguntaMultiplaEscolha4Opcoes1.IdQuestionario = IdQuestionario;
                        this.UCPerguntaMultiplaEscolha4Opcoes1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaMultiplaEscolha4Opcoes1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaMultiplaEscolha4Opcoes1.IdTurma = IdTurma;

                        this.UCPerguntaMultiplaEscolha4Opcoes1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_3_OPCOES:
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Pergunta = proximaPergunta;
                        this.UCPerguntaMultiplaEscolha4Opcoes1.IdQuestionario = IdQuestionario;
                        this.UCPerguntaMultiplaEscolha4Opcoes1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaMultiplaEscolha4Opcoes1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaMultiplaEscolha4Opcoes1.IdTurma = IdTurma;

                        this.UCPerguntaMultiplaEscolha4Opcoes1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntPerguntaTipo.PERGUNTA_TIPO_TEXTO:
                        this.UCPerguntaTexto1.Pergunta = proximaPergunta;
                        this.UCPerguntaTexto1.IdQuestionario = IdQuestionario;
                        this.UCPerguntaTexto1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaTexto1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaTexto1.IdTurma = IdTurma;

                        this.UCPerguntaTexto1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntPerguntaTipo.PERGUNTA_TIPO_SIM_NAO:
                        this.UCPerguntaSimNao1.Pergunta = proximaPergunta;
                        this.UCPerguntaSimNao1.IdQuestionario = IdQuestionario;
                        this.UCPerguntaSimNao1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaSimNao1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaSimNao1.IdTurma = IdTurma;

                        this.UCPerguntaSimNao1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_31_QUESTIONARIO_GESTAO_2009_2010:
                        this.UCPerguntaEspecialGestao311.Pergunta = proximaPergunta;
                        this.UCPerguntaEspecialGestao311.IdQuestionario = IdQuestionario;
                        this.UCPerguntaEspecialGestao311.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaEspecialGestao311.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaEspecialGestao311.IdTurma = IdTurma;

                        this.UCPerguntaEspecialGestao311.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_32_QUESTIONARIO_GESTAO_2011:
                        this.UCPerguntaEspecialGestao32_1.Pergunta = proximaPergunta;
                        this.UCPerguntaEspecialGestao32_1.IdQuestionario = IdQuestionario;
                        this.UCPerguntaEspecialGestao32_1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaEspecialGestao32_1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaEspecialGestao32_1.IdTurma = IdTurma;

                        this.UCPerguntaEspecialGestao32_1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_1_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010:
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Pergunta = proximaPergunta;
                        this.UCPerguntaEspecialResponsabilidadeSocial11.IdQuestionario = IdQuestionario;
                        this.UCPerguntaEspecialResponsabilidadeSocial11.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaEspecialResponsabilidadeSocial11.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaEspecialResponsabilidadeSocial11.IdTurma = IdTurma;

                        this.UCPerguntaEspecialResponsabilidadeSocial11.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_6_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010:
                        this.UCPerguntaEspecialResponsabilidadeSocial61.Pergunta = proximaPergunta;
                        this.UCPerguntaEspecialResponsabilidadeSocial61.IdQuestionario = IdQuestionario;
                        this.UCPerguntaEspecialResponsabilidadeSocial61.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaEspecialResponsabilidadeSocial61.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaEspecialResponsabilidadeSocial61.IdTurma = IdTurma;

                        this.UCPerguntaEspecialResponsabilidadeSocial61.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaSimNao1.Dispose();
                        this.UCPerguntaTexto1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCPerguntaEspecialGestao32_1.Dispose();
                        this.UCPerguntaEspecialGestao311.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial11.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Dispose();
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Dispose();
                        break;
                    case EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_3_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011:
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Pergunta = proximaPergunta;
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.IdQuestionario = IdQuestionario;
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.IdTurma = IdTurma;

                        this.UCPerguntaEspecialResponsabilidadeSocial3_1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
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
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Pergunta = proximaPergunta;
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.IdQuestionario = IdQuestionario;
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.IdTurma = IdTurma;

                        this.UCPerguntaEspecialResponsabilidadeSocial7a_1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
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
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Pergunta = proximaPergunta;
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.IdQuestionario = IdQuestionario;
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.IdEmpresaCadastro = IdEmpresaCadastro;
                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.IdTurma = IdTurma;

                        this.UCPerguntaEspecialResponsabilidadeSocial8b_1.Visible = true;

                        this.UCAdministrativoEmpreendedorismo1.Dispose();
                        this.UCAdministrativoGestao1.Dispose();
                        this.UCAdministrativoGestao2011_1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                        this.UCAdministrativoInovacao1.Dispose();
                        this.UCAdministrativoResponsabilidadeSocial2011_1.Dispose();
                        this.UCPerguntaMultiplaEscolha4Opcoes1.Dispose();
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
        }

    }
}