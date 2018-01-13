<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCResumoRanking.ascx.cs"
    Inherits="PEG.User_Controls.UCResumoRanking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="600px" Height="300px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%; font-size: 11px;">
        <br />
        <asp:HiddenField ID="HddnFldIdQuestionarioEmpresa" runat="server" />
        <table cellspacing="1" cellpadding="1" border="0" style="text-align: left;">
            <tr>
                <td>
                    <asp:Label ID="lblResumo" runat="server" Text="Resumo da Fase do PEG:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxResumo" runat="server" Width="500" Height="180px" TabIndex="1" TextMode="MultiLine" Font-Names="Arial" Font-Size="12px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvResumo" runat="server" ControlToValidate="TxtBxResumo"
                        Display="None" ErrorMessage="Campo Obrigatório!" ValidationGroup="EncaminharProximaEtapa"
                        SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="vceResumo" runat="server" TargetControlID="rfvResumo">
                    </cc1:ValidatorCalloutExtender>
                </td>
            </tr>
            <br />
            <tr>
                <td align="right" colspan="2">
                    <asp:ImageButton ID="ImgBttnSalvar" runat="server" ImageUrl="~/Image/_file_save.png"
                        OnClick="ImgBttnSalvar_Click" ValidationGroup="EncaminharProximaEtapa" />
                    <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                        OnClick="ImgBttnCancelar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
