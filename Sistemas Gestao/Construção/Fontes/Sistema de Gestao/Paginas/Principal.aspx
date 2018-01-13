<%@ Page Title="Sistemas de Gestão" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.Principal" %>

<%@ Register Src="/User Controls/UCListagemNoticia.ascx" TagName="UCListagemNoticia" TagPrefix="uc1" %>
<%@ Register Src="/User Controls/UCListagemArquivo.ascx" TagName="UCListagemArquivo" TagPrefix="uc2" %>

<%@ Register src="../User Controls/UCStatus.ascx" tagname="UCStatus" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc3:UCStatus ID="UCStatus1" runat="server" />
<div style="font-family: Arial, Helvetica, sans-serif;font-size:11px;margin-left:55px;">
<asp:Label ID="Label1" runat="server" />
<asp:Label ID="LblTitulo1" runat="server" />
 <br />
</div>
<div style="font-family: Arial, Helvetica, sans-serif;font-size:11px;margin-left:55px;">
<asp:Label ID="LblDescricao1" runat="server" />
 <br /><br />
<asp:Label ID="LblDescricao2" runat="server" />
</div>
<br />
    <div id="divSetasEmpresa" runat="server" style="display:block;font-size:11px;margin-left:55px;">
<asp:Label Text="Para iniciar, clique na seta 'Preencher Cadastro'." ID="LblSetaCadastro" runat="server"></asp:Label>
        <br />
        <br />
        As setas acima indicam a sequência de passos para finalizar o processo: 
        <br />
        Em verde - passo concluído. 
        <br />
        Em azul - passo em andamento. 
        <br />
        Em vermelho - passo pendente. 
        <br />
        Em cinza - passo ainda não disponível.
    </div>
<table style="border-width:1px;vertical-align:top;" class="tabFiltros">
    <tr>
        <td style="vertical-align:top; max-height:400px;min-height:400px;">
            <uc1:UCListagemNoticia ID="UCListagemNoticia1" runat="server" />
        </td>
        <td style="vertical-align:top;max-height:400px;min-height:400px;" >
            <uc2:UCListagemArquivo ID="UCListagemArquivo1" runat="server" />
        </td>
    </tr>
</table>

</asp:Content>
