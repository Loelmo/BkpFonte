<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCConfirmaEmail.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCConfirmaEmail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <br />
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server" style="left: 0%; top: 50%;width:360px;">
        <fieldset>
        <legend>Enviar por Email</legend>
        <asp:HiddenField ID="hddUrl" runat="server" />
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="E-mail:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxEmail" TabIndex="1" runat="server" Width="250" onBlur="ValidaEmail(this)"
                            Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                        <span class="obrigatorio">*</span>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <div align="center">
            <br />
            <asp:ImageButton ID="ImgBttnEnviar" runat="server" ImageUrl="~/Image/_file_mail3.png" 
                OnClick="ImgBttnEnviar_Click" TabIndex="2" />
            &nbsp;&nbsp;
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click" />
        </div>
    </asp:Panel>
</div>
