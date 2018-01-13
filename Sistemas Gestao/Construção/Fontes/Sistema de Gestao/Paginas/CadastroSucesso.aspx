<%@ Page Title="Sistemas de Gestão" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="CadastroSucesso.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.CadastroSucesso" %>

    <%@ Register Src="/User Controls/UCCadastroSucesso.ascx" TagName="UCCadastroSucesso" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Cadastro realizado com sucesso!
    </h3>
    <fieldset>
        <table>
        <tr>
        <asp:Panel ID="PnlQuestionarios" runat="server">
            <uc1:UCCadastroSucesso ID="UCCadastroSucesso1" runat="server" />
        </asp:Panel>
        </tr>
        </table>
    </fieldset>
</asp:Content>
