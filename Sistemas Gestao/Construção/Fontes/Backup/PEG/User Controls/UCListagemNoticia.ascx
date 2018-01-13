<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCListagemNoticia.ascx.cs"
    Inherits="PEG.User_Controls.UCListagemNoticia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="/User Controls/UCExibeNoticia.ascx" TagName="UCExibeNoticia" TagPrefix="uc2" %>
<%@ Register Src="/User Controls/UCCadastroNoticiaCE.ascx" TagName="UCCadastroNoticiaCE" TagPrefix="uc3" %>
<asp:Panel ID="PnlFundo" runat="server" Width="578px" BackColor="White">
    <fieldset style="margin-top: 5px; margin-right: 5px; margin-bottom: 5px;">
        <legend style="font-size: 12px;">Últimas Notícias </legend>
        <table runat="server" class="Text_grid" cellspacing="0" rules="all" border="1" id="tabelaSemDados" style="font-size:11px;width:100%;border-collapse:collapse;display:none;">
			<tr>
				<td style="border:0;">
                    Não existem dados*
                </td>
			</tr>
        </table>
        <table style="font-size: 12px; width: 525px; min-height: 200px;">
            <tr id="linha1a" runat="server" style="background-color: #dddddd">
                <td style="max-width: 105px; border-bottom-width: thin; border-bottom-style: dotted;">
                    <asp:Image ID="ImgNoticia1" runat="server" Width="100px" />
                </td>
                <td style="width: 445px; vertical-align: top; border-bottom-width: thin; border-bottom-style: dotted;">
                    <asp:Label ID="LblNoticia1" runat="server" Font-Size="13px" Font-Italic="true" />
                    <br />
                    <asp:Label ID="LblCorpoNoticia1" runat="server" Font-Size="11px" />
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">continua ...</asp:LinkButton>
                    <br />
                    <asp:ImageButton ID="ImgBtnNoticia1" runat="server" ImageUrl="~/Image/_file_mail2.png"
                        OnClick="ImgBtnNoticia1_Click" ImageAlign="Right" />
                    <asp:HiddenField ID="HdnNoticia1Id" runat="server" />
                </td>
            </tr>
            <tr id="linha2a" runat="server">
                <td style="max-width: 105px; border-bottom-width: thin; border-bottom-style: dotted;">
                    <asp:Image ID="ImgNoticia2" runat="server" Width="100px" />
                </td>
                <td style="width: 445px; vertical-align: top; border-bottom-width: thin; border-bottom-style: dotted;">
                    <asp:Label ID="LblNoticia2" runat="server" Font-Size="13px" Font-Italic="true" />
                    <br />
                    <asp:Label ID="LblCorpoNoticia2" runat="server" Font-Size="11px" /><br />
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">continua ...</asp:LinkButton>
                    <br />
                    <asp:ImageButton ID="ImgBtnNoticia2" runat="server" ImageUrl="~/Image/_file_mail2.png"
                        OnClick="ImgBtnNoticia2_Click" ImageAlign="Right" />
                    <asp:HiddenField ID="HdnNoticia2Id" runat="server" />
                </td>
            </tr>
            <tr id="linha3a" runat="server" style="background-color: #dddddd">
                <td style="max-width: 105px; border-bottom-width: thin; border-bottom-style: dotted;">
                    <asp:Image ID="ImgNoticia3" runat="server" Width="100px" Font-Size="12px" />
                </td>
                <td style="width: 445px; vertical-align: top; border-bottom-width: thin; border-bottom-style: dotted;">
                    <asp:Label ID="LblNoticia3" runat="server" Font-Size="13px" Font-Italic="true" />
                    <br />
                    <asp:Label ID="LblCorpoNoticia3" runat="server" Font-Size="11px" />
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">continua ...</asp:LinkButton>
                    <br />
                    <asp:ImageButton ID="ImgBtnNoticia3" runat="server" ImageUrl="~/Image/_file_mail2.png"
                        OnClick="ImgBtnNoticia3_Click" ImageAlign="Right" />
                    <asp:HiddenField ID="HdnNoticia3Id" runat="server" />
                </td>
            </tr>
            <tr id="linha4a" runat="server">
                <td style="max-width: 105px; border-bottom-width: thin; border-bottom-style: dotted;">
                    <asp:Image ID="ImgNoticia4" runat="server" Width="100px" Font-Size="12px" />
                </td>
                <td style="width: 445px; vertical-align: top; border-bottom-width: thin; border-bottom-style: dotted;">
                    <asp:Label ID="LblNoticia4" runat="server" Font-Size="13px" Font-Italic="true" />
                    <br />
                    <asp:Label ID="LblCorpoNoticia4" runat="server" Font-Size="11px" />
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">continua ...</asp:LinkButton>
                    <br />
                    <asp:ImageButton ID="ImgBtnNoticia4" runat="server" ImageUrl="~/Image/_file_mail2.png"
                        OnClick="ImgBtnNoticia4_Click" ImageAlign="Right" />
                    <asp:HiddenField ID="HdnNoticia4Id" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                <br />
                    <asp:LinkButton ID="HlkMais" runat="server" Font-Size="12px" onclick="ImgBtnVejaMais_Click">Ver Mais</asp:LinkButton>
                </td>
            </tr>
        </table>
    </fieldset>
    <uc2:UCExibeNoticia ID="UCExibeNoticia1" runat="server" />
    <uc3:UCCadastroNoticiaCE ID="UCCadastroNoticiaCE1" runat="server" />
</asp:Panel>
