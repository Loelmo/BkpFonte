using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using System.IO.Compression;
using Ionic.Zip;
using Vinit.SG.BLL;
using Vinit.SG.Ent;

namespace PEG.User_Controls
{
    public partial class UCJustificativaRanking : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImgBttnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatorios())
            {
                EncaminharProximaEtapa();

                this.Clear();
                this.Close();

                if (atualizaGrid != null)
                {
                    this.atualizaGrid();
                }
            }
            else
            {
                MessageBox(this.Page, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        private Boolean VerificaCamposObrigatorios()
        {
            Boolean res = true;
            res &= Valida_TextBox(TxtBxJustificativa);

            return res;
        }

        private void EncaminharProximaEtapa()
        {
            EntQuestionarioEmpresa objQuestionarioEmpresa;
            EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador;

            switch (StringUtils.ToEnum<EnumType.TipoEtapaMpe>(HddnFldProximaEtapa.Value))
            {
                case EnumType.TipoEtapaMpe.ClassificaçãoEstadual:
                    objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                    objQuestionarioEmpresa.IdQuestionarioEmpresa = StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value);
                    objQuestionarioEmpresa.MotivoExcluiu = TxtBxJustificativa.Text.ToString();
                    objQuestionarioEmpresa.Excluido = true;
                    objQuestionarioEmpresa.ParaAvaliador = true;
                    new BllQuestionarioEmpresa().AlterarSomenteDesclassificar(objQuestionarioEmpresa);
                    break;
                case EnumType.TipoEtapaMpe.AvaliacaoEstadual:
                case EnumType.TipoEtapaMpe.AvaliacaoNacional:
                    objQuestionarioEmpresaAvaliador = new EntQuestionarioEmpresaAvaliador();
                    objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.IdQuestionarioEmpresa = StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value);
                    objQuestionarioEmpresaAvaliador.MotivoDevolucao = TxtBxJustificativa.Text.ToString();
                    objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.ParaAvaliador = true;
                    new BllRelatorioRanking().DevolverParaAvaliador(objQuestionarioEmpresaAvaliador);
                    break;
                case EnumType.TipoEtapaMpe.EncerramentoNacional:
                case EnumType.TipoEtapaMpe.ClassificacaoNacional:
                case EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais:
                case EnumType.TipoEtapaMpe.JulgamentoFinalistasNacionais:
                    objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                    objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value));
                    objQuestionarioEmpresa.Questionario.IdQuestionario = StringUtils.ToInt(HddnFldIdQuestionario.Value);
                    objQuestionarioEmpresa.Etapa.TipoEtapa.IdTipoEtapa = StringUtils.ToInt(HddnFldProximaEtapa.Value);
                    objQuestionarioEmpresa.MotivoVenceu = TxtBxJustificativa.Text.ToString();
                    new BllRelatorioRanking().EncaminharProximaEtapa(objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objQuestionarioEmpresa.Questionario.IdQuestionario, objQuestionarioEmpresa.Etapa.IdEtapa, true);
                    break;
            }
            switch (StringUtils.ToEnum<EnumType.TipoEtapaPeg>(HddnFldProximaEtapa.Value))
            {
                case EnumType.TipoEtapaPeg.ValidacaoAnaliseRespostas:
                    objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                    objQuestionarioEmpresa.IdQuestionarioEmpresa = StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value);
                    objQuestionarioEmpresa.MotivoExcluiu = TxtBxJustificativa.Text.ToString();
                    objQuestionarioEmpresa.Excluido = true;
                    objQuestionarioEmpresa.ParaAvaliador = true;
                    new BllQuestionarioEmpresa().AlterarSomenteDesclassificar(objQuestionarioEmpresa);
                    break;
                case EnumType.TipoEtapaPeg.VisitaPreviaPreClassificadas:
                case EnumType.TipoEtapaPeg.PlanoEmpresarialFase2:
                case EnumType.TipoEtapaPeg.GestãoDoResultadoFase3:
                case EnumType.TipoEtapaPeg.NovoCicloFase4:
                    objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                    objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value));
                    objQuestionarioEmpresa.Questionario.IdQuestionario = StringUtils.ToInt(HddnFldIdQuestionario.Value);
                    objQuestionarioEmpresa.Etapa.TipoEtapa.IdTipoEtapa = StringUtils.ToInt(HddnFldProximaEtapa.Value);
                    objQuestionarioEmpresa.MotivoVenceu = TxtBxJustificativa.Text.ToString();
                    new BllRelatorioRanking().EncaminharProximaEtapa(objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objQuestionarioEmpresa.Questionario.IdQuestionario, objQuestionarioEmpresa.Etapa.IdEtapa, false);

                    break;
            }
            switch (StringUtils.ToEnum<EnumType.TipoEtapaFga>(HddnFldProximaEtapa.Value))
            {
                case EnumType.TipoEtapaFga.ValidacaoAnaliseRespostas:
                    objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                    objQuestionarioEmpresa.IdQuestionarioEmpresa = StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value);
                    objQuestionarioEmpresa.MotivoExcluiu = TxtBxJustificativa.Text.ToString();
                    objQuestionarioEmpresa.Excluido = true;
                    objQuestionarioEmpresa.ParaAvaliador = true;
                    new BllQuestionarioEmpresa().AlterarSomenteDesclassificar(objQuestionarioEmpresa);
                    break;
                case EnumType.TipoEtapaFga.VisitaPreviaPreClassificadas:
                case EnumType.TipoEtapaFga.NovoCicloFase4:
                    objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                    objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value));
                    objQuestionarioEmpresa.Questionario.IdQuestionario = StringUtils.ToInt(HddnFldIdQuestionario.Value);
                    objQuestionarioEmpresa.Etapa.TipoEtapa.IdTipoEtapa = StringUtils.ToInt(HddnFldProximaEtapa.Value);
                    objQuestionarioEmpresa.MotivoVenceu = TxtBxJustificativa.Text.ToString();
                    new BllRelatorioRanking().EncaminharProximaEtapa(objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objQuestionarioEmpresa.Questionario.IdQuestionario, objQuestionarioEmpresa.Etapa.IdEtapa, false);
                    break;
            }
        }

        public void Show(Int32 IdQuestionarioEmpresa, Int32 ProximaEtapa, EnumType.Questionario Questionario)
        {
            this.HddnFldIdQuestionario.Value = IntUtils.ToString((Int32)Questionario);
            this.HddnFldIdQuestionarioEmpresa.Value = IntUtils.ToString(IdQuestionarioEmpresa);
            this.HddnFldProximaEtapa.Value = IntUtils.ToString(ProximaEtapa);

            divUserControl.Visible = true;

            this.ObjectToPage();
        }

        private void ObjectToPage()
        {
            String Justificativa = String.Empty;
            EntQuestionarioEmpresa objQuestionarioEmpresa;
            EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador;

            switch (StringUtils.ToEnum<EnumType.TipoEtapaMpe>(HddnFldProximaEtapa.Value))
            {
                case EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa:

                    break;
                case EnumType.TipoEtapaMpe.InscriçãoCandidaturaAdministrativo:

                    break;
                case EnumType.TipoEtapaMpe.ClassificaçãoEstadual:

                    objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value));

                    Justificativa = objQuestionarioEmpresa.MotivoExcluiu;

                    break;
                case EnumType.TipoEtapaMpe.AvaliacaoEstadual:

                    objQuestionarioEmpresaAvaliador = new BllQuestionarioEmpresaAvaliador().ObterPorIdQuestionarioEmpresa(StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value))[0];

                    Justificativa = objQuestionarioEmpresaAvaliador.MotivoDevolucao;

                    break;
                case EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais:

                    break;
                case EnumType.TipoEtapaMpe.EncerramentoEstadual:


                    break;
                case EnumType.TipoEtapaMpe.ClassificacaoNacional:

                    objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value));

                    Justificativa = objQuestionarioEmpresa.MotivoVenceu;

                    break;
                case EnumType.TipoEtapaMpe.AvaliacaoNacional:

                    break;
                case EnumType.TipoEtapaMpe.JulgamentoFinalistasNacionais:

                    break;
                case EnumType.TipoEtapaMpe.EncerramentoNacional:

                    objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(StringUtils.ToInt(HddnFldIdQuestionarioEmpresa.Value));

                    Justificativa = objQuestionarioEmpresa.MotivoVenceu;

                    break;
            }

            this.TxtBxJustificativa.Text = Justificativa;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Close()
        {
            divUserControl.Visible = false;
        }
    }
}