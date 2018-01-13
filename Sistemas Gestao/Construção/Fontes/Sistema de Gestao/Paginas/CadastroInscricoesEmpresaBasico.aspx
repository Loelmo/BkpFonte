<%@ Page Title="Cadastro Inscrição Empresa - Dados Básicos" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroInscricoesEmpresaBasico.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.CadastroInscricoesEmpresaBasico" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h3> Ficha de Cadastro</h3>
        <asp:HiddenField ID="HddnFldIdInscricaoEmpresa" runat="server" />
        
        <fieldset runat="server" id="Etapa1">
        <legend> Dados da Empresa </legend>
            <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label4" runat="server" Text="Razão Social:"></asp:Label>
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="TxtBxRazaoSocial" runat="server" Width="250" TabIndex="1" Font-Names="Verdana" Font-Size="08"></asp:TextBox><span class="obrigatorio">*</span>
                    </td>
                    <td >
                        <asp:Label ID="Label15" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="205px" 
                            TabIndex="12" Font-Names="Verdana" Font-Size="08">
                        </asp:DropDownList><span class="obrigatorio">*</span>
                    </td>
                </tr> 
                <tr>
                    <td >
                        <asp:Label ID="Label8" runat="server" Text="CNPJ / CPF:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxCNPJCPF" runat="server" Width="150" TabIndex="5" maxlength="18" onKeyDown="Mascara(this,CpfCnpj);" 
                        onFocus="javascript:Mascara(this,CpfCnpj);" onKeyPress="Mascara(this,CpfCnpj);" onKeyUp="Mascara(this,CpfCnpj);" onBlur="Verifica_campo_CPF_CNPJ(this)" Font-Names="Verdana" Font-Size="08"></asp:TextBox><span class="obrigatorio">*</span>
                    </td>
                </tr> 
                <tr>
                    
                    <td >
                    </td>
                    <td>
                    </td>
                </tr> 
            </table>
        </fieldset>

        <fieldset runat="server" id="Etapa2">
        <legend> Dados do Contato </legend>
             <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label1" runat="server" Text="Nome do Contato:"></asp:Label>
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="TxtBxNomeCompleto" runat="server" Width="250" TabIndex="19" Font-Names="Verdana" Font-Size="08"></asp:TextBox><span class="obrigatorio">*</span>
                    </td>
                    <td width="20%">
                        <asp:Label ID="Label30" runat="server" Text="Senha (de 6 a 20 caracteres):"></asp:Label>
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="TxtBxSenha" runat="server" MaxLength="20" Width="250" TabIndex="32" TextMode="Password" Font-Names="Verdana" Font-Size="08"></asp:TextBox><span class="obrigatorio">*</span>
                    </td>
                </tr> 
                <tr>
                    <td >
                        <asp:Label ID="Label21" runat="server" Text="E-mail do Contato:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxEmail" runat="server" Width="250" TabIndex="22" onBlur="ValidaEmail(this)" Font-Names="Verdana" Font-Size="08"></asp:TextBox><span class="obrigatorio">*</span>
                    </td>
                    <td >
                        <asp:Label ID="Label32" runat="server" Text="Confirma Senha:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxConfSenha" runat="server" MaxLength="20" Width="250" TabIndex="34" TextMode="Password" Font-Names="Verdana" Font-Size="08"></asp:TextBox><span class="obrigatorio">*</span>
                    </td>
                </tr> 
             </table>
             <div align="right">
                <asp:ImageButton ID="ImgBtnProcessar" runat="server"  TabIndex="36" 
                     ImageUrl="~/Image/confirmar.gif" onclick="ImgBtnProcessar_Click"/>
             </div>
        </fieldset>
</asp:Content>
    