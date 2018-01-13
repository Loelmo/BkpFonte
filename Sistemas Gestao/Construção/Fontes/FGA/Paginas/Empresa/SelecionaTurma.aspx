<%@ Page Title="Sistemas de Gestão" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="SelecionaTurma.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.Empresa.SelecionaTurma" %>

    <%@ Register Src="/User Controls/UCSelecionaTurma.ascx" TagName="UCSelecionaTurma" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Home
    </h3>
    <fieldset class="FieldInterno">
        <legend>Selecione uma Turma</legend>
        <table>
        <tr>
        <asp:Panel ID="PnlQuestionarios" runat="server">
        </asp:Panel>
        </tr>
        </table>
    </fieldset>
</asp:Content>
