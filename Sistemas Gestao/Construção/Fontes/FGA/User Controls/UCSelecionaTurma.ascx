<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSelecionaTurma.ascx.cs" Inherits="Sistema_de_Gestao.User_Controls.Questionario.UCSelecionaTurma" %>


    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <asp:Literal ID="LtrQuebraLinhaInicio" runat="server" />
<td>
    <asp:Panel ID="PnlFundo" runat="server" Width="225px" Height="180px" BackColor="White"
        BorderColor="Black" Style="position: relative;top: 10%;">

        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-size: 9px;"> <asp:Label ID="LblTipo" runat="server" /> </legend>
            <div id="divUC" runat="server" align="center" style="height:140px;">
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0">
                <tr>
                    <td align="center" style="border:1px solid Black; height:50px;vertical-align:middle;">
                        <asp:Label ID="LblNome" runat="server" Font-Size="12px" ></asp:Label>
                        <br /><asp:Label ID="LblDescricao" runat="server" Font-Size="12px" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="BtnParticipar" runat="server" ToolTip="Quero Participar" OnClick="BtnParticipar_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="BtnAcessar" onclick="BtnAcessar_Click" runat="server" />
                    </td>
                </tr>
            </table>
            </div>
        </fieldset>
    </asp:Panel>
</td>
    <asp:Literal ID="LtrQuebraLinhaFim" runat="server" />
