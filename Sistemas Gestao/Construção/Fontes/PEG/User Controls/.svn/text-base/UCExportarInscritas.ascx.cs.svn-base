using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using System.Data;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Web.UI.HtmlControls;

namespace PEG.User_Controls
{
    public partial class UCExportarInscritas : UCBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Show()
        {
            this.divUserControl.Visible = true;
        }

        private void Close()
        {
            this.divUserControl.Visible = false;
        }

        public void Exportar()
        {
            this.Clear();
            this.Show();
        }

        protected void ImgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
            {
                //Excel
                if (this.rdList.Items[0].Selected)
                {
                    this.ExportarExcel();
                }
                //OpenDocument
                else if (this.rdList.Items[1].Selected)
                {
                    this.ExportarOpenDocument();
                }
            }
            else
            {
                MessageBox(this.Page, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        private Boolean VerificaCamposObrigatoriosCadastro()
        {
            Boolean res = true;
            res &= Valida_RadioButtonList(rdList);

            return res;
        }

        private void ExportarExcel()
        {
            VerificarCamposSelecionados();
            this.UCUCConfirmaExportarInscritas1.ExportarExcel(this.chkZip.Checked);
        }

        private void ExportarOpenDocument()
        {
            VerificarCamposSelecionados();
            this.UCUCConfirmaExportarInscritas1.ExportarOpenDocument(this.chkZip.Checked);
        }

        private void VerificarCamposSelecionados()
        {
            this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.DataSource = ListaGrid;
            this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.DataBind();

            //"Razão Social"
            if (!chkListCampos.Items.FindByValue("TX_RAZAO_SOCIAL").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[0].Visible = false;
            //"Nome Fantasia">
            if (!chkListCampos.Items.FindByValue("TX_NOME_FANTASIA").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[1].Visible = false;
            //"CPF/CNPJ">
            if (!chkListCampos.Items.FindByValue("TX_CPF_CNPJ").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[2].Visible = false;
            //"Data de Abertura da Empresa">
            if (!chkListCampos.Items.FindByValue("DT_ABERTURA_EMPRESA").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[3].Visible = false;
            //"Número de Funcionarios">
            if (!chkListCampos.Items.FindByValue("NU_FUNCIONARIO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[4].Visible = false;
            //"Endereço">
            if (!chkListCampos.Items.FindByValue("TX_ENDERECO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[5].Visible = false;
            //Bairro Empresa
            if (!chkListCampos.Items.FindByValue("CEA_BAIRRO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[6].Visible = false;
            //"Cidade">
            if (!chkListCampos.Items.FindByValue("CEA_CIDADE").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[7].Visible = false;
            //"Estado">
            if (!chkListCampos.Items.FindByValue("CEA_ESTADO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[8].Visible = false;
            //"CEP">
            if (!chkListCampos.Items.FindByValue("TX_CEP").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[9].Visible = false;
            //"Tipo de Empresa">
            if (!chkListCampos.Items.FindByValue("CEA_TIPO_EMPRESA").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[10].Visible = false;
            //"Faturamento">
            if (!chkListCampos.Items.FindByValue("CEA_FATURAMENTO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[11].Visible = false;
            //"Categoria">
            if (!chkListCampos.Items.FindByValue("CEA_CATEGORIA").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[12].Visible = false;
            //"Atividade">
            if (!chkListCampos.Items.FindByValue("CEA_ATIVIDADE_ECONOMICA").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[13].Visible = false;
            //"Descrição da Atividade">
            if (!chkListCampos.Items.FindByValue("TX_ATIVIDADE_ECONOMICA").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[14].Visible = false;
            //"Nome Completo">
            if (!chkListCampos.Items.FindByValue("TX_NOME_CONTATO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[15].Visible = false;
            //"Cargo">
            if (!chkListCampos.Items.FindByValue("TX_CARGO_CONTATO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[16].Visible = false;
            //Cpf Contato
            if (!chkListCampos.Items.FindByValue("TX_CPF_CONTATO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[17].Visible = false;
            //"Endereço Completo">
            if (!chkListCampos.Items.FindByValue("TX_ENDERECO_CONTATO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[18].Visible = false;
            //Bairro Contato
            if (!chkListCampos.Items.FindByValue("BairroContato").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[19].Visible = false;
            //Cidade Contato
            if (!chkListCampos.Items.FindByValue("CidadeContato").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[20].Visible = false;
            //Estado Contato
            if (!chkListCampos.Items.FindByValue("EstadoContato").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[21].Visible = false;
            //CEP Contato
            if (!chkListCampos.Items.FindByValue("CEPContato").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[22].Visible = false;
            //"Telefone Fixo">
            if (!chkListCampos.Items.FindByValue("TX_TELEFONE_CONTATO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[23].Visible = false;
            //"Celular">
            if (!chkListCampos.Items.FindByValue("TX_CELULAR_CONTATO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[24].Visible = false;
            //"E-mail">
            if (!chkListCampos.Items.FindByValue("TX_EMAIL_CONTATO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[25].Visible = false;
            //"Data de Nascimento">
            if (!chkListCampos.Items.FindByValue("DT_DATA_NASCIMENTO_CONTATO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[26].Visible = false;
            //"Sexo">
            if (!chkListCampos.Items.FindByValue("TX_SEXO_CONTATO").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[27].Visible = false;
            //"Nivel de Escolaridade">
            if (!chkListCampos.Items.FindByValue("CEA_NIVEL_ESCOLARIDADE").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[28].Visible = false;
            //"Faixa Etária">
            if (!chkListCampos.Items.FindByValue("CEA_FAIXA_ETARIA").Selected)
                this.UCUCConfirmaExportarInscritas1.grdEmpresasExport.Columns[29].Visible = false;
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

        protected void rdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdList.SelectedValue == "OpenDocument")
            {
                chkZip.Checked = true;
                chkZip.Enabled = false;
            }
            else
            {
                chkZip.Checked = false;
                chkZip.Enabled = true;
            }
        }
    }
}