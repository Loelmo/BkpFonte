<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaEspecialGestao32.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.Avaliacao.UCPerguntaEspecialGestao32" %>
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
    <br clear="all" />
    <table cellSpacing="0" cellPadding="1"  border="0" style="width:800px; margin-top:20px;">
        <tr>
            <td class="">
                <b>  Resultados relativos a: </b>
            </td>
            <td>
                <b> 2008 </b>
            </td>
            <td>
                <b> 2009 </b>
            </td>
            <td>
                <b> 2010 </b>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblTabela" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:TextBox TabIndex="123" ID="tx1_31" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="124" ID="tx2_31" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="125" ID="tx3_31" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>
