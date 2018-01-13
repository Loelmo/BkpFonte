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
    public partial class SelecionaTurma : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["QueroParticipar"] != null)
            {
                int IdTurma = int.Parse(Request["IdTurma"]);
                AlteraParticipacao(IdTurma);
                Response.Redirect("~/Paginas/Empresa/SelecionaTurma.aspx");
            }
            if (!IsPostBack)
            {
                this.objTurma = new EntTurma();
                this.PopulaTurmas();
            }
        }

        //Inscreve ou remove inscrição de empresa em questionário
        private void AlteraParticipacao(Int32 IdTurma)
        {

            EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
            objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = this.EmpresaLogada.IdEmpresaCadastro;
            objTurmaEmpresa.Turma.IdTurma = IdTurma;
            objTurmaEmpresa = new BllTurmaEmpresa().ObterPorTurmaEmpresa(objTurmaEmpresa);

            if (Request["QueroParticipar"] == "1")
            {
                //Cria QUESTIONARIO_EMPRESA para o questionario e empresa em questao
                if (objTurmaEmpresa == null)
                {
                    objTurmaEmpresa = new BllTurmaEmpresa().InsereInscricaoTurmaEmpresa(this.objPrograma.IdPrograma, this.EmpresaLogada.IdEmpresaCadastro, IdTurma, EmpresaLogada.Estado.IdEstado, IdUsuarioLogado);
                }
                else
                {
                    objTurmaEmpresa.Ativo = true;
                    objTurmaEmpresa.ParticipaPrograma = true;
                    objTurmaEmpresa.UltimaAlteracao = DateTime.Now;
                    if (IdUsuarioLogado > 0)
                    {
                        objTurmaEmpresa.Usuario.IdUsuario = IdUsuarioLogado;
                    }
                    new BllTurmaEmpresa().ParticiparPrograma(objTurmaEmpresa);
                }
            }
            else
            {
                //Inativa QUESTIONARIO_EMPRESA atual para o questionario e empresa em questao
                objTurmaEmpresa.ParticipaPrograma = false;
                objTurmaEmpresa.UltimaAlteracao = DateTime.Now;
                new BllTurmaEmpresa().ParticiparPrograma(objTurmaEmpresa);
            }
        }

        private void PopulaTurmas()
        {
            List<EntTurma> listaTurma = new BllTurma().ObterAbertasPorProgramaEmpresaEstado(this.objPrograma.IdPrograma, this.EmpresaLogada.IdEmpresaCadastro, this.EmpresaLogada.Estado.IdEstado);
            
            int i = 1;
            foreach (EntTurma t in listaTurma)
            {
                object[] temp = new object[8];
                temp[0] = i;
                temp[1] = t.Turma;
                temp[2] = t.Privada;
                temp[3] = t.EmpresaInscrita;
                temp[4] = this.EmpresaLogada.IdEmpresaCadastro;
                temp[5] = t.IdTurma;
                temp[6] = t.EmpresaInscrita || (t.Ativo && !t.Privada);
                temp[7] = t.Descricao;
                Control TurmaControlTemp = LoadControl("~/User Controls/UCSelecionaTurma.ascx", temp);
                if (i < 4)
                {
                    i++;
                }
                else
                {
                    i = 1;
                }
                this.PnlQuestionarios.Controls.Add(TurmaControlTemp);
            }
            while (i < 4)
            {
                Control TurmaControlTemp;
                object[] temp = new object[8];
                temp[0] = i;
                temp[1] = "";
                temp[2] = false;
                temp[3] = false;
                temp[4] = -1;
                temp[5] = -1;
                temp[6] = false;
                temp[7] = "";
                TurmaControlTemp = LoadControl("~/User Controls/UCSelecionaTurma.ascx", temp);
                this.PnlQuestionarios.Controls.Add(TurmaControlTemp);
                i++;
            }
        }

    }
}