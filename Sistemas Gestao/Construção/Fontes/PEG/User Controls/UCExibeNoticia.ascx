<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCExibeNoticia.ascx.cs"
    Inherits="PEG.User_Controls.UCExibeNoticia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UCConfirmaEmail.ascx" TagName="UCConfirmaEmail" TagPrefix="uc1" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="878px" BackColor="White" BorderColor="Black"
        BorderStyle="Outset" BorderWidth="1" Style="position: relative; top: 10%;">
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;">Notícia </legend>
            <asp:Label ID="LblTitulo" runat="server" />
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="left"
                border="0">
                <tr>
                    <td align="left">
                        <asp:Image ID="ImgNoticia" runat="server" Width="200px" />
                        <asp:Label ID="LblNoticia" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="10%" align="right">
                        <asp:ImageButton ID="ImgBtnNoticiaEmail" runat="server" ImageUrl="~/Image/_file_mail2.png"
                            OnClick="ImgBtnNoticiaEmail_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="right" style="margin-right: 20px; margin-bottom: 20px;">
            <br />
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click" />
        </div>
    </asp:Panel>
    <uc1:UCConfirmaEmail ID="UCConfirmaEmail1" runat="server" />
</div>
