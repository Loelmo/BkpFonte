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
                    <td width="20%">
                        <asp:Label ID="Label10" runat="server" Text="Data de Abertura da empresa:"></asp:Label>
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="TxtBxDataAbertura" runat="server" Width="100" TabIndex="7" Font-Names="Verdana" Font-Size="08" ></asp:TextBox>
                        <asp:ImageButton ID="ImgBttnCalendario" runat="server" TabIndex="99" ImageUrl="~/Image/Calendario.gif" /><span class="obrigatorio">*</span>
                        <cc1:MaskedEditExtender ID="MskdEdtExtndrCalendario" runat="server" MaskType="Date"
                            Mask="99/99/9999" TargetControlID="TxtBxDataAbertura">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="ClndrExtndrCalendario" runat="server" Format="dd/MM/yyyy"
                            PopupButtonID="ImgBttnCalendario" TargetControlID="TxtBxDataAbertura">
                        </cc1:CalendarExtender>
                    </td>
                </tr> 
                <tr>
                    <td >
                        <asp:Label ID="Label6" runat="server" Text="Nome Fantasia:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxNomeFantasia" runat="server" Width="250" TabIndex="3" Font-Names="Verdana" Font-Size="08"></asp:TextBox><span class="obrigatorio">*</span>
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
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Número de Colaboradores:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxNumeroEmpregados" TabIndex="13" runat="server" Width="125" MaxLength="10"
                            onKeyDown="Mascara(this,Integer);" onKeyPress="Mascara(this,Integer);" onKeyUp="Mascara(this,Integer);"
                            Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                        <span class="obrigatorio">*</span>
                    </td>
                </tr> 
            </table>
        </fieldset>

        <fieldset runat="server" id="Etapa2">
        <legend> Dados do Contato </legend>
             <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label1" runat="server" Text="Nome Completo:"></asp:Label>
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
                        <asp:Label ID="Label21" runat="server" Text="E-mail:"></asp:Label>
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
            <div id="divJustificativa" class="ajudaJustificativa" style="display: none;z-index:1000;" runat="server">
                <asp:Label ID="LblJustificativa" runat="server" Text="Neste momento não estão abertas inscrições no programa Ferramentas de Gestão Avançada no seu Estado. Acesse o Portal do SEBRAE MAIS (<a href='http://www.sebraemais.com.br' target='_blank'>www.sebraemais.com.br</a>) e encontre outras soluções disponíveis para a sua empresa."></asp:Label>
                <br clear="all" />
                <table width="300px">
                    <tr>
                        <td align="center">
                        </td>
                        <td align="center">
                            <asp:ImageButton ImageUrl="/Image/_file_back2.png" ID="btnCancelaJustificativa" runat="server" OnClientClick="javascript:return fechaAlerta();" />
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
</asp:Content>
    