<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEnviaQuestionarioEmpresa.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCEnviaQuestionarioEmpresa" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="400px" Height="160px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 25%; font-size: 11px;">
        <br />
        <table cellspacing="1" cellpadding="1" border="0" style="text-align: left;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="LblEnviaQuestionario" Text=" Para enviar o seu autodiagnóstico selecione o botão Enviar." runat="server" />
                    <br />
                    <asp:Label ID="Label1" Text="Após o envio para acessar o Relatório de Autodiagnóstico com os pontos fortes e oportunidades de melhorias para sua empresa, clique na seta “Histórico de Relatórios”." runat="server" />
                    <br />
                    <br />
                </td>
            </tr>
            <br />
            <tr>
                <td align="center">
                    <asp:ImageButton ImageUrl="/Image/_file_send2.png" ID="BtnEnviar" onclick="ImgBttnSalvar_Click" runat="server"/>
                </td>
                <td align="center">
                    <asp:ImageButton ImageUrl="/Image/_file_back2.png" ID="ImageButton1" onclick="ImgBttnCancelar_Click" runat="server"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
