<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaTexto.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.Avaliacao.UCPerguntaTexto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:HiddenField ID="HdnIdQuestionarioEmpresa" runat="server" />
<asp:HiddenField ID="HdnIdEmpresaCadastro" runat="server" />
<asp:HiddenField ID="HdnIdQuestionario" runat="server" />
<asp:HiddenField ID="HdnIdTurma" runat="server" />
<asp:HiddenField ID="HdnIdPergunta" runat="server" />
<br clear="all" />
<div class="divPerguntas" id="divPerguntas" style="display: block;" runat="server">
    <table border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="2">
                <asp:TextBox ID="TxtResposta" Rows="5" TextMode="MultiLine" runat="server" Width="850px" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
    </table>
</div>
