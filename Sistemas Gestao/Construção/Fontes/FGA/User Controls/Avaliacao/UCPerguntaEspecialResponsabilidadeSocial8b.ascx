<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaEspecialResponsabilidadeSocial8b.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.Avaliacao.UCPerguntaEspecialResponsabilidadeSocial8b" %>
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
            <td colspan="3">
                <asp:Label ID="LblPergunta3" runat="server" Text="Quando, para definir o público atendido, a empresa busca informações sobre as necessidades locais e escolhe a que possui alguma interação com o negócio ou, ainda, pela proximidade física (vizinhança), as chances de obter os resultados e metas planejados e efetivamente contribuir com este público se ampliam." />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="Label6" runat="server" Text="Seu atendimento pode ser direto, junto ao público selecionado (executora), ou indireto (promotora), por meio de uma organização ou projeto social e, também, de outros parceiros." />
            </td>
        </tr>
        <tr>
            <td style="width:120px;">Forma de atendimento
            </td>
            <td style="width:240px;">Público beneficiário da ação social
            </td>
            <td>Quantidade
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label1" runat="server" Text="Atendimento Direto"/>
            </td>
            <td>
                <asp:TextBox TabIndex="1" ID="resposta1_1" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="1" ID="resposta1_2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label2" runat="server" Text="Atendimento Indireto"/>
            </td>
            <td>
                <asp:TextBox TabIndex="1" ID="resposta2_1" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="1" ID="resposta2_2" runat="server" />
            </td>
        </tr>
    </table>
</div>
