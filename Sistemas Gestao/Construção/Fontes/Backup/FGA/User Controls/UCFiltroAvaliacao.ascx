<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFiltroAvaliacao.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCFiltroAvaliacao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Razão Social:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtBxRazaoSocial" runat="server" Width="250" TabIndex="1"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Nome Fantasia:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtBxNomeFantasia" runat="server" Width="250" TabIndex="11"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label20" runat="server" Text="Turma:"></asp:Label>
        </td>
        <td rowspan="5">
            <uc1:UCEstado ID="UCEstado1" runat="server" EscritorioRegional="True" Regiao="True"
                TabIndex="2" />
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="CNPJ:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtBxCNPJ_CPF" runat="server" Width="250" MaxLength="18" onKeyDown="Mascara(this,CpfCnpj);"
                onKeyPress="Mascara(this,CpfCnpj);" onKeyUp="Mascara(this,CpfCnpj);" onBlur="Verifica_campo_CPF_CNPJ(this)"
                TabIndex="12"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Estado:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label12" runat="server" Text="Tipo de Empresa:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DrpDwnLstTipoEmpresa" runat="server" Width="255" TabIndex="13"
                DataValueField="IdTipoEmpresa" DataTextField="TipoEmpresa">
                <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Escritório Regional:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label18" runat="server" Text="Faixa etária do Contato:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DrpDwnLstFaixaEtaria" runat="server" Width="255" TabIndex="14"
                DataValueField="IdContatoFaixaEtaria" DataTextField="ContatoFaixaEtaria">
                <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Região:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label19" runat="server" Text="Escolaridade do Contato:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DrpDwnLstEscolaridade" runat="server" Width="255" TabIndex="15"
                DataValueField="IdContatoNivelEscolaridade" DataTextField="ContatoNivelEscolaridade">
                <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label24" runat="server" Text="Cidade:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label17" runat="server" Text="Sexo do Contato:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DrpDwnLstSexoRepresentante" runat="server" Width="255" TabIndex="16">
                <asp:ListItem Selected="True" Value="">Todos</asp:ListItem>
                <asp:ListItem Value="M">Masculino</asp:ListItem>
                <asp:ListItem Value="F">Feminino</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label11" runat="server" Text="Faixa de Faturamento:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DrpDwnLstFaixaFaturamento" runat="server" Width="255" TabIndex="8"
                DataValueField="IdFaturamento" DataTextField="Faturamento">
                <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Nº de Colaboradores:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtBxNumeroFuncionario" runat="server" Width="250" MaxLength="12"
                onKeyDown="Mascara(this,Integer);" onKeyPress="Mascara(this,Integer);" onKeyUp="Mascara(this,Integer);"
                TabIndex="17"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Setor:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DrpDwnLstCategoria" runat="server" Width="255" DataValueField="IdCategoria"
                DataTextField="Categoria" TabIndex="10">
                <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Label ID="Label16" runat="server" Text="Protocolo:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtBxProtocolo" runat="server" Width="250" TabIndex="18"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label21" runat="server" Text="Período para os relatórios? De:"></asp:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="TxtBxDataDe" runat="server" Width="80" TabIndex="20"></asp:TextBox>
            <asp:ImageButton ID="ImgBttnDateDe" runat="server" TabIndex="21" ImageUrl="~/Image/Calendario.gif" />
            <cc2:MaskedEditExtender ID="MskdEdtExtndrCalendario" runat="server" MaskType="Date"
                Mask="99/99/9999" TargetControlID="TxtBxDataDe">
            </cc2:MaskedEditExtender>
            <cc2:CalendarExtender ID="ClndrExtndrCalendario" runat="server" Format="dd/MM/yyyy"
                PopupButtonID="ImgBttnDateDe" TargetControlID="TxtBxDataDe">
            </cc2:CalendarExtender>
            <%--                </td>
                <td>--%>
            <asp:Label ID="Label23" runat="server" Text="Até:"></asp:Label>
            <%--                </td>
                <td>--%>
            <asp:TextBox ID="TxtBxDataAte" runat="server" Width="80" TabIndex="22"></asp:TextBox>
            <asp:ImageButton ID="ImgBttnDateAte" runat="server" TabIndex="23" ImageUrl="~/Image/Calendario.gif" />
            <cc2:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date" Mask="99/99/9999"
                TargetControlID="TxtBxDataAte">
            </cc2:MaskedEditExtender>
            <cc2:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImgBttnDateAte"
                TargetControlID="TxtBxDataAte">
            </cc2:CalendarExtender>
        </td>
    </tr>
</table>
