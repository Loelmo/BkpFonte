<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaSimNao.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.Avaliacao.UCPerguntaSimNao" %>
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
            <td>
                <asp:RadioButton TabIndex="2" ID="respostaNao" GroupName="1" runat="server"
                    Text="Não" />
            </td>
            <td>
                <asp:RadioButton TabIndex="1" ID="respostaSim" GroupName="1" runat="server"
                    Text="Sim" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="botaoJustificativa" runat="server">
                    <asp:Label ID="LblJustificativa" runat="server" Text="Insira a Justificativa:"></asp:Label>
                    <asp:TextBox ID="TxtJustificativa" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
                </div>
            </td>
        </tr>
    </table>
</div>
