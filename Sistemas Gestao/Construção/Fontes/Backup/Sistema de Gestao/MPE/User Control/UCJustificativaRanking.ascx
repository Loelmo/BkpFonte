<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCJustificativaRanking.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCJustificativaRanking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="600px" Height="260px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%; font-size: 11px;">
        <br />
        <asp:HiddenField ID="HddnFldIdQuestionarioEmpresa" runat="server" />
        <asp:HiddenField ID="HddnFldIdQuestionario" runat="server" />
        <asp:HiddenField ID="HddnFldProximaEtapa" runat="server" />
        <table cellspacing="1" cellpadding="1" border="0" style="text-align: left;">
            <tr>
                <td>
                    <asp:Label ID="lblJustificativa" runat="server" Text="Justificativa:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxJustificativa" runat="server" Width="500" Height="180px" TabIndex="1" TextMode="MultiLine" Font-Names="Arial" Font-Size="12px"></asp:TextBox>
                </td>
            </tr>
            <br />
            <tr>
                <td align="right" colspan="2">
                    <asp:ImageButton ID="ImgBttnSalvar" runat="server" ImageUrl="~/Image/_file_save.png"
                        OnClick="ImgBttnSalvar_Click" ValidationGroup="EncaminharProximaEtapa" />&nbsp;&nbsp;
                    <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                        OnClick="ImgBttnCancelar_Click" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
