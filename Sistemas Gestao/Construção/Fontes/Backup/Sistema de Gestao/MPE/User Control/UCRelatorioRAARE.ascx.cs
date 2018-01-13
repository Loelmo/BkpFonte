using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using System.IO;

namespace Sistema_de_Gestao.MPE.User_Controls
{
    public partial class UCRelatorioRAARE : UCBase
    {
        public Boolean Avaliador { get; set; }
        public Int32 IdEmpresaCadastro { get; set; }
        public Int32 IdTurma { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Show()
        {
            this.divUserControl.Visible = true;

            try
            {
                ConectaRelatorioDB();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void AbreRelatorio()
        {

        }

        void ConectaRelatorioDB()
        {
            //try
            //{
            //    foreach (CrystalDecisions.CrystalReports.Engine.Table table in Crs.ReportDocument.Database.Tables)
            //    {
            //        CrystalDecisions.Shared.TableLogOnInfo logon;

            //        logon = table.LogOnInfo;
            //        logon.ConnectionInfo.ServerName = @"Carmenere\sqlexpress";
            //        logon.ConnectionInfo.DatabaseName = "Sistema Gestao";
            //        logon.ConnectionInfo.Password = "vinit2010";
            //        logon.ConnectionInfo.UserID = "vinit";
            //        table.ApplyLogOnInfo(logon);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }
    }
}