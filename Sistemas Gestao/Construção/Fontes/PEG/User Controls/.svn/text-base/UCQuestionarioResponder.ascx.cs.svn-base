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
    public partial class UCQuestionarioResponder : UCBase
    {

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UCAdministrativoGestao1.Dispose();
                this.UCAdministrativoGestao20111.Dispose();
                this.UCAdministrativoResponsabilidadeSocial20111.Dispose();
                this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                this.UCAdministrativoInovacao1.Dispose();
                this.UCAdministrativoEmpreendedorismo1.Dispose();
            }
        }

        private void Show()
        {
            this.divUserControl.Visible = true;

            if (!ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar))
            {
                EnableControl(this.PnlFundo.Controls, false);
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, true);
            }
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Editar(Int32 IdQuestionarioEmpresa)
        {
            ObjectToPage(IdQuestionarioEmpresa);

            this.Show();
        }

        private void ObjectToPage(Int32 IdQuestionarioEmpresa)
        {
            OcultaUserControls();
            this.HddnFldIdQuestionarioEmpresa.Value = IdQuestionarioEmpresa.ToString();
            EntQuestionarioEmpresa objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(IdQuestionarioEmpresa);

            switch (objQuestionarioEmpresa.Questionario.IdQuestionario)
            {
                case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2009:
                case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2011:
                    this.UCAdministrativoEmpreendedorismo1.SetValores(objQuestionarioEmpresa.Questionario.IdQuestionario, IdQuestionarioEmpresa, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objTurma.IdTurma);

                    this.UCAdministrativoEmpreendedorismo1.Visible = true;

                    this.UCAdministrativoGestao1.Dispose();
                    this.UCAdministrativoGestao20111.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial20111.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                    this.UCAdministrativoInovacao1.Dispose();
                    break;
                case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2009:
                    this.UCAdministrativoResponsabilidadeSocial1.SetValores(objQuestionarioEmpresa.Questionario.IdQuestionario, IdQuestionarioEmpresa, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objTurma.IdTurma);

                    this.UCAdministrativoResponsabilidadeSocial1.Visible = true;

                    this.UCAdministrativoGestao1.Dispose();
                    this.UCAdministrativoGestao20111.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial20111.Dispose();
                    this.UCAdministrativoEmpreendedorismo1.Dispose();
                    this.UCAdministrativoInovacao1.Dispose();
                    break;
                case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2011:
                    this.UCAdministrativoResponsabilidadeSocial20111.SetValores(objQuestionarioEmpresa.Questionario.IdQuestionario, IdQuestionarioEmpresa, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objTurma.IdTurma);

                    this.UCAdministrativoResponsabilidadeSocial20111.Visible = true;

                    this.UCAdministrativoGestao1.Dispose();
                    this.UCAdministrativoGestao20111.Dispose();
                    this.UCAdministrativoEmpreendedorismo1.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                    this.UCAdministrativoInovacao1.Dispose();
                    break;
                case EntQuestionario.QUESTIONARIO_GESTAO_2009:
                    this.UCAdministrativoGestao1.SetValores(objQuestionarioEmpresa.Questionario.IdQuestionario, IdQuestionarioEmpresa, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objTurma.IdTurma);

                    this.UCAdministrativoGestao1.Visible = true;

                    this.UCAdministrativoEmpreendedorismo1.Dispose();
                    this.UCAdministrativoGestao20111.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial20111.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                    this.UCAdministrativoInovacao1.Dispose();
                    break;
                case EntQuestionario.QUESTIONARIO_GESTAO_2011:
                    this.UCAdministrativoGestao20111.SetValores(objQuestionarioEmpresa.Questionario.IdQuestionario, IdQuestionarioEmpresa, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objTurma.IdTurma);

                    this.UCAdministrativoGestao20111.Visible = true;

                    this.UCAdministrativoGestao1.Dispose();
                    this.UCAdministrativoEmpreendedorismo1.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial20111.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                    this.UCAdministrativoInovacao1.Dispose();
                    break;
                case EntQuestionario.QUESTIONARIO_INOVACAO_2011:
                    this.UCAdministrativoInovacao1.SetValores(objQuestionarioEmpresa.Questionario.IdQuestionario, IdQuestionarioEmpresa, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objTurma.IdTurma);

                    this.UCAdministrativoInovacao1.Visible = true;

                    this.UCAdministrativoGestao1.Dispose();
                    this.UCAdministrativoGestao20111.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial20111.Dispose();
                    this.UCAdministrativoResponsabilidadeSocial1.Dispose();
                    this.UCAdministrativoEmpreendedorismo1.Dispose();
                    break;
            }
        }

        private void PageToObject()
        {
            EntQuestionarioEmpresa objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(int.Parse(HddnFldIdQuestionarioEmpresa.Value));

            switch (objQuestionarioEmpresa.Questionario.IdQuestionario)
            {
                case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2009:
                    this.UCAdministrativoEmpreendedorismo1.Gravar();
                    break;
                case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2011:
                    this.UCAdministrativoEmpreendedorismo1.Gravar();
                    break;
                case EntQuestionario.QUESTIONARIO_GESTAO_2009:
                    this.UCAdministrativoGestao1.Gravar();
                    break;
                case EntQuestionario.QUESTIONARIO_GESTAO_2011:
                    this.UCAdministrativoGestao20111.Gravar();
                    break;
                case EntQuestionario.QUESTIONARIO_INOVACAO_2011:
                    this.UCAdministrativoInovacao1.Gravar();
                    break;
                case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2009:
                    this.UCAdministrativoResponsabilidadeSocial1.Gravar();
                    break;
                case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2011:
                    this.UCAdministrativoResponsabilidadeSocial20111.Gravar();
                    break;
            }
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            this.PageToObject();
            this.Clear();
            this.Close();

            if (atualizaGrid != null)
            {
                this.atualizaGrid();
            }
        }


        private void OcultaUserControls()
        {
            this.UCAdministrativoEmpreendedorismo1.Visible = false;
            this.UCAdministrativoGestao1.Visible = false;
            this.UCAdministrativoGestao20111.Visible = false;
            this.UCAdministrativoInovacao1.Visible = false;
            this.UCAdministrativoResponsabilidadeSocial1.Visible = false;
            this.UCAdministrativoResponsabilidadeSocial20111.Visible = false;
        }

    }
}