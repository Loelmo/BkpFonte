<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaEspecialResponsabilidadeSocial6.ascx.cs"
    Inherits="PEG.User_Controls.UCPerguntaEspecialResponsabilidadeSocial6" %>
<%@ Register Src="./UCEnviaQuestionarioEmpresa.ascx" TagName="UCEnviaQuestionarioEmpresa"
    TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div class="passos">
    <asp:HiddenField ID="HdnIdQuestionarioEmpresa" runat="server" />
    <asp:HiddenField ID="HdnIdEmpresaCadastro" runat="server" />
    <asp:HiddenField ID="HdnIdQuestionario" runat="server" />
    <asp:HiddenField ID="HdnIdTurma" runat="server" />
    <asp:HiddenField ID="HdnIdPergunta" runat="server" />
    <asp:Label ID="lblTituloQuestionario" runat="server" Text="Critério " />
    <asp:DropDownList ID="cmbCriterios" runat="server" OnSelectedIndexChanged="cmbCriterios_SelectedIndexChanged"
        AutoPostBack="true">
    </asp:DropDownList>
    <a class="ajuda_criterio_link"
        runat="server" id="hrfAjuda" href="javascript:;" onmouseover="mostraAjuda('ajudaCriterio');"
        onmouseout="escondeAjuda('ajudaCriterio');"><span class="ajuda_criterio">Ajuda sobre o critério</span> ?</a> <span class="progresso">Progresso:
        </span>
    <div id="progressbar" class="progressbar" runat="server">
        <span id="barraPercent" runat="server"></span>
        <p id="porcent" runat="server" style="font-weight: normal">
        </p>
    </div>
</div>
<br clear="all" />
<img src="/Image/divisoria.png" width="900" height="2" alt="Divisoria" style="padding: 0 0 0 10px;" />
<br clear="all" />
<br clear="all" />
<div class="divPerguntas" id="divPerguntas" style="display: block;" runat="server">
    <asp:Label ID="lblNumeroPergunta" runat="server" Text="" CssClass="ajuda_pergunta"></asp:Label>
    <asp:Label ID="lblPergunta" runat="server" Text="" Width="720px"></asp:Label>
    <a class="ajuda_criterio_link"
        href="javascript:;" onmouseover="mostraAjuda('ajudaPergunta');" onmouseout="escondeAjuda('ajudaPergunta');"><span class="ajuda_pergunta">Ajuda da pergunta</span> 
        ?</a>
    <div id="ajudaPergunta" class="ajudaCriterio" style="display: none;">
        <asp:Label ID="lblPerguntaAjuda" runat="server" Text=""></asp:Label>
    </div>
    <div id="ajudaCriterio" class="ajudaCriterio" style="display: none">
        <asp:Label ID="lblCriterioAjuda" runat="server"></asp:Label>
    </div>
    <br clear="all" />
    <br clear="all" />
    <img src="/Image/divisoria.png" width="900" height="2" alt="Divisoria" style="padding: 0 0 0 10px;" />
    <br clear="all" />
    <br clear="all" />
    <table border="0" cellspacing="0" cellpadding="0" class="quiz">
        <tr>
            <td style="width:160px;"> <asp:Label ID="label61" runat="server" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="TxtResposta61" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="label62" runat="server" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="TxtResposta62" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="label63" runat="server" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="TxtResposta63" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="label64" runat="server" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="TxtResposta64" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="label65" runat="server" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="TxtResposta65" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="label66" runat="server" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="TxtResposta66" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="label67" runat="server" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="TxtResposta67" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="label68" runat="server" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="TxtResposta68" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="label69" runat="server" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="TxtResposta69" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
    </table>
    <br clear="all" />
    <table border="0" cellspacing="0" cellpadding="0" width="850px">
        <tr>
            <td width="20%" valign="top" align="center">
                <div id="botaoAnterior" runat="server">
                    <asp:ImageButton ImageUrl="/Image/_file_prev2.png" ID="BtnAnterior" runat="server" OnClick="BtnAnterior_Click" />
                </div>
            </td>
            <td class="justificativa" width="60%" align="center">
            </td>
            <td width="20%" valign="top" align="center">
                <div id="botaoProximo" runat="server">
                    <asp:ImageButton ImageUrl="/Image/_file_next2.png" ID="BtnProximo" runat="server" OnClick="BtnProximo_Click" />
                </div>
            </td>
        </tr>
    </table>
    <uc1:UCEnviaQuestionarioEmpresa ID="UCEnviaQuestionarioEmpresa1" runat="server" />
</div>
