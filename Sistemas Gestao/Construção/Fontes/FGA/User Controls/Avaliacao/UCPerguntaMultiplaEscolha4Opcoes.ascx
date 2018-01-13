<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaMultiplaEscolha4Opcoes.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.Avaliacao.UCPerguntaMultiplaEscolha4Opcoes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:HiddenField ID="HdnIdQuestionarioEmpresa" runat="server" />
<asp:HiddenField ID="HdnIdEmpresaCadastro" runat="server" />
<asp:HiddenField ID="HdnIdQuestionario" runat="server" />
<asp:HiddenField ID="HdnIdTurma" runat="server" />
<asp:HiddenField ID="HdnIdPergunta" runat="server" />
<br clear="all" />
<div class="divPerguntas" id="divPerguntas" style="display: block;" runat="server">
    <asp:HiddenField ID="respostaSelecionada" runat="server"></asp:HiddenField>
    <table border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <asp:RadioButton ID="radioA" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblRespostaA" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="radioB" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblRespostaB" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="radioC" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblRespostaC" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="radioD" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblRespostaD" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</div>
