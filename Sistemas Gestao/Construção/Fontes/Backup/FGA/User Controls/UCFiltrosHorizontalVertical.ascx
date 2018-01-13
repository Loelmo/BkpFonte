<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFiltrosHorizontalVertical.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCFiltrosHorizontalVertical" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
    <tr>
        <td runat="server" id="tdLblTurma">
            <asp:Label ID="lblTurma" runat="server" Text="Turma:"></asp:Label>
        </td>
        <td align="left" runat="server" id="tdDdlTurma">
            <asp:DropDownList ID="DrpDwnLstTurma" runat="server" Width="195px" DataValueField="IdTurma"
                DataTextField="Turma" OnSelectedIndexChanged="DrpDwnLstTurma_SelectedIndexChanged"
                AutoPostBack="True">
                <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <span class="obrigatorio" runat="server" id="spTurma">*</span>
        </td>
        <asp:Literal ID="ltrTabela" runat="server"></asp:Literal>
        <td runat="server" id="tdLblEstado">
            <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
        </td>
        <td align="left" runat="server" id="tdDdlEstado">
            <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="105px" DataValueField="IdEstado"
                DataTextField="Estado" >
                <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <span class="obrigatorio" runat="server" id="spEstado">*</span>
        </td>
    </tr>
</table>
