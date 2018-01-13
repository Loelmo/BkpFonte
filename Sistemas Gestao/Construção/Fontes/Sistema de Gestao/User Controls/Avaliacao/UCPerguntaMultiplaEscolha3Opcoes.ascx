<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaMultiplaEscolha3Opcoes.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.Avaliacao.UCPerguntaMultiplaEscolha3Opcoes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:HiddenField ID="HdnIdQuestionarioEmpresa" runat="server" />
<asp:HiddenField ID="HdnIdEmpresaCadastro" runat="server" />
<asp:HiddenField ID="HdnIdQuestionario" runat="server" />
<asp:HiddenField ID="HdnIdTurma" runat="server" />
<asp:HiddenField ID="HdnIdPergunta" runat="server" />
<br clear="all" />
<div class="divPerguntas" id="divPerguntas" style="display: block;" runat="server">
    <asp:Label ID="lblNumeroPergunta" runat="server" Text="" CssClass="ajuda_pergunta"></asp:Label>
    <asp:Label ID="lblPergunta" runat="server" Text="" Width="700px"></asp:Label>
    <br clear="all" />
    <asp:HiddenField ID="respostaSelecionada" runat="server"></asp:HiddenField>
    <table border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <asp:RadioButton ID="radioA" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblRespostaA" runat="server" Text="Nunca"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="radioB" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblRespostaB" runat="server" Text="As Vezes"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="radioC" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblRespostaC" runat="server" Text="Sempre"></asp:Label>
            </td>
        </tr>
    </table>
</div>
