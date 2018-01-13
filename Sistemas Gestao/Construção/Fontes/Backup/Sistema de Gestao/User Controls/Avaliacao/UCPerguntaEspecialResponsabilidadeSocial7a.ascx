<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaEspecialResponsabilidadeSocial7a.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.Avaliacao.UCPerguntaEspecialResponsabilidadeSocial7a" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:HiddenField ID="HdnIdQuestionarioEmpresa" runat="server" />
<asp:HiddenField ID="HdnIdEmpresaCadastro" runat="server" />
<asp:HiddenField ID="HdnIdQuestionario" runat="server" />
<asp:HiddenField ID="HdnIdTurma" runat="server" />
<asp:HiddenField ID="HdnIdPergunta" runat="server" />
<asp:HiddenField ID="HdnIdResposta" runat="server" />
<div class="divPerguntas" id="divPerguntas" style="display: block;" runat="server">
    <table width="100%" cellpadding="10" cellspacing="0" border="0">
        <tr>
            <td colspan="2">
                <asp:Label ID="LblPergunta3" runat="server" Text="Insira informações referentes ao total de ações executadas (atendimento direto ao público beneficiário) ou promovidas (atendimento ao publico beneficiário por meio de apoio a organizações ou projetos sociais ou atividades de parceiros)." />
            </td>
        </tr>
        <tr>
            <td style="width:120px;">Atividade
            </td>
            <td>Quantidade
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label1" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="1" ID="resposta1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label2" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="2" ID="resposta2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label3" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="3" ID="resposta3" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label4" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="4" ID="resposta4" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label5" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="5" ID="resposta5" runat="server" />
            </td>
        </tr>
    </table>
</div>
