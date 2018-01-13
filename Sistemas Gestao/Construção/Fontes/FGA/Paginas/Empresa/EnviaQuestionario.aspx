<%@ Page Title="Sistemas de Gestão" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="EnviaQuestionario.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.Empresa.EnviaQuestionario" %>

    <%@ Register Src="/User Controls/Questionario/UCSelecionaQuestionarioEmpresa.ascx" TagName="UCSelecionaQuestionarioEmpresa" TagPrefix="uc1" %>

<%@ Register src="../../User Controls/UCStatus.ascx" tagname="UCStatus" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div align="center">
    <uc2:UCStatus ID="UCStatus1" runat="server" />
</div>


    <fieldset>
        <legend>Questionários</legend>
        <table style="width:900px;">
            <tr>
                <asp:Panel ID="PnlQuestionarios" runat="server">
                </asp:Panel>
            </tr>
            <tr>
                <td>
                    <div id="relatorioJaEnviado" runat="server" style="display:none;">
                        <asp:Label runat="server" ID="LblJaEnviado" Text="Sua autoavaliação já foi enviada. Selecione a opção abaixo para fazer seu download:" />
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">
                            <asp:Image ID="Image1" ImageUrl="/Image/_file_download.png" runat="server" BorderStyle="None" /></asp:HyperLink>
                        <br />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                    <asp:Label ID="LblEtapaDesabilitada" runat="server" Text="A etapa de inscrição para empresas do seu estado já se encontra encerrada." Visible="false"/>
                    <asp:ImageButton ImageUrl="/Image/_file_send2.png" ID="BtnEnviar" onclick="BtnEnviar_Click" runat="server" OnClientClick="javascript:return confirm('Confirma envio de questionário?');"/>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
