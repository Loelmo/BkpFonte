<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaMultiplaEscolha4Opcoes.ascx.cs"
    Inherits="PEG.User_Controls.UCPerguntaMultiplaEscolha4Opcoes" %>
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
    <asp:HiddenField ID="respostaSelecionada" runat="server"></asp:HiddenField>
    <table border="0" cellspacing="0" cellpadding="0" class="quiz">
        <tr onclick="selecionaResposta('A');" style="cursor: pointer;">
            <td class="opcao" id="coluna1RespostaA" runat="server">
                A
            </td>
            <td width="680px" id="coluna2RespostaA" style="background-color: #E1EEEE;" runat="server">
                <asp:Label ID="lblRespostaA" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hdnRespostaA_Just" runat="server" />
            </td>
            <td class="selecao" id="respostaA" runat="server">
                <img runat="server" src="/Image/visto.png" id="tickRespA" width="25" height="22"
                    alt="visto" style="margin-left:12px;"/>
            </td>
        </tr>
        <tr onclick="selecionaResposta('B');" style="cursor: pointer;">
            <td class="opcao" id="coluna1RespostaB" runat="server">
                B
            </td>
            <td id="coluna2RespostaB" style="background-color: #E1EEEE;" runat="server">
                <asp:Label ID="lblRespostaB" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hdnRespostaB_Just" runat="server" />
            </td>
            <td class="selecao" id="respostaB" runat="server">
                <img runat="server" src="/Image/visto.png" id="tickRespB" width="25" height="22"
                    alt="visto" style="margin-left:12px;"/>
            </td>
        </tr>
        <tr onclick="selecionaResposta('C');" style="cursor: pointer;">
            <td class="opcao" id="coluna1RespostaC" runat="server">
                C
            </td>
            <td id="coluna2RespostaC" style="background-color: #E1EEEE;" runat="server">
                <asp:Label ID="lblRespostaC" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hdnRespostaC_Just" runat="server" />
            </td>
            <td class="selecao" id="respostaC" runat="server">
                <img runat="server" src="/Image/visto.png" id="tickRespC" width="25" height="22"
                    alt="visto" style="margin-left:12px;"/>
            </td>
        </tr>
        <tr onclick="selecionaResposta('D');" style="cursor: pointer;">
            <td class="opcao" id="coluna1RespostaD" runat="server">
                D
            </td>
            <td id="coluna2RespostaD" style="background-color: #E1EEEE;" runat="server">
                <asp:Label ID="lblRespostaD" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hdnRespostaD_Just" runat="server" />
            </td>
            <td class="selecao" id="respostaD" runat="server">
                <img runat="server" src="/Image/visto.png" id="tickRespD" width="25" height="22"
                    alt="visto" style="margin-left:12px;"/>
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
                <div id="botaoJustificativa" runat="server">
                    <asp:ImageButton ImageUrl="/Image/_file_just2.png" ID="BtnJustificativa" runat="server" OnClientClick="javascript:return mostraJustificativa();" />
                </div>
            </td>
            <td width="20%" valign="top" align="center">
                <div id="botaoProximo" runat="server">
                    <asp:ImageButton ImageUrl="/Image/_file_next2.png" ID="BtnProximo" runat="server" OnClick="BtnProximo_Click" />
                </div>
            </td>
        </tr>
    </table>
    <div id="divJustificativa" class="ajudaJustificativa" style="display: none;z-index:1000;" runat="server">
        <asp:Label ID="LblJustificativa" runat="server" Text="Insira uma Justificativa:"></asp:Label>
        <asp:TextBox ID="TxtJustificativa" Rows="5" TextMode="MultiLine" runat="server" Width="294px" Font-Names="Arial" Font-Size="12px"/>
        <asp:HiddenField ID="HddnFldJustificativa" runat="server" />
        <br clear="all" />
        <table width="300px">
            <tr>
                <td align="center">
                    <asp:ImageButton ImageUrl="/Image/_file_save.png" ID="btnSalvaJustificativa" runat="server" OnClientClick="javascript:return salvaJustificativa();" OnClick="BtnJustificativaSalvar_Click"/>
                </td>
                <td align="center">
                    <asp:ImageButton ImageUrl="/Image/_file_back2.png" ID="btnCancelaJustificativa" runat="server" OnClientClick="javascript:return cancelaJustificativa();" />
                </td>
            </tr>
        </table>
    <uc1:UCEnviaQuestionarioEmpresa ID="UCEnviaQuestionarioEmpresa1" runat="server" />
    </div>
</div>
