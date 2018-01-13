<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSelecionaQuestionarioEmpresa.ascx.cs" Inherits="Sistema_de_Gestao.User_Controls.UCSelecionaQuestionarioEmpresa" %>


    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="divQuestionarioControl" runat="server"  visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="800px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%;">

        <asp:HiddenField ID="HddnFldIdQuestionario" runat="server" />
        
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;"> <asp:Label ID="LblTipo" runat="server" /> </legend>
            <div id="divUC" runat="server" class="divUC">
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0">
                <tr>
                    <td width="20%">
                        <asp:Label ID="LblNome" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="1%"></td>
                </tr>
                <tr>
                    <td width="80%">
                        <asp:Label ID="LblPorcentagem" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td width="1%"></td>
                </tr>
                <tr>
                    <td width="80%">
                        <asp:Button ID="BtnResponder" onclick="BtnResponder_Click" runat="server" CommandName="Responder" CausesValidation="false" Width="15px" />
                    </td>
                </tr>
            </table>
            </div>
        </fieldset>
    </asp:Panel>
</div>
