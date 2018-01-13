<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaEspecialResponsabilidadeSocial1.ascx.cs"
    Inherits="PEG.User_Controls.UCPerguntaEspecialResponsabilidadeSocial1" %>
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
    <table width="100%" cellpadding="10" cellspacing="0" border="0">
        <tr>
            <td style="width:120px;">
            </td>
            <td>
                <asp:RadioButton ID="pergunta1respostaNao" GroupName="11" runat="server"
                    Text="Não" />
            </td>
            <td>
                <asp:RadioButton ID="pergunta1respostaSim" GroupName="11" runat="server"
                    Text="Sim" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <div id="tabela1" runat="server" style="display:none;">
                    <table>
                        <tr>
                            <td colspan="5" style="text-align:center;">Neste caso, cite exemplos de ações de incentivos:
                            </td>
                        </tr>
                        <tr style="font-weight:bold;font-size:11px;">
                            <td>Tipos de Ações
                            </td>
                            <td>
                                No de Pessoas e/ou Instituições Beneficiadas
                            </td>
                            <td style="width:200px;">
                                 Se as Ações Foram Desenvolvidas Utilizando Algum Tipo de Parceria, Indique o Nome do Parceiro
                            </td>
                            <td>
                               Tipo de Ação - Pontual
                            </td>
                            <td>
                               Tipo de Ação - Contínua 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <img src="/Image/divisoria.png" width="100%" height="2" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_1" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta1_1" runat="server" TabIndex="1"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta1_2" runat="server" TabIndex="2"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="3" ID="resposta1_P" GroupName="1" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="4" ID="resposta1_C" GroupName="1" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_2" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta2_1" runat="server" TabIndex="5"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta2_2" runat="server" TabIndex="6"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="7" ID="resposta2_P" GroupName="2" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="8" ID="resposta2_C" GroupName="2" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_3" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta3_1" runat="server" TabIndex="9"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta3_2" runat="server" TabIndex="10"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="11" ID="resposta3_P" GroupName="3" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="12" ID="resposta3_C" GroupName="3" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_4" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta4_1" runat="server" TabIndex="13"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta4_2" runat="server" TabIndex="14"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="15" ID="resposta4_P" GroupName="4" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="16" ID="resposta4_C" GroupName="4" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_5" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta5_1" runat="server" TabIndex="17"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta5_2" runat="server" TabIndex="18"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="19" ID="resposta5_P" GroupName="5" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="20" ID="resposta5_C" GroupName="5" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_6" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta6_1" runat="server" TabIndex="21"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta6_2" runat="server" TabIndex="22"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="23" ID="resposta6_P" GroupName="6" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="24" ID="resposta6_C" GroupName="6" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_7" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta7_1" runat="server" TabIndex="25"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta7_2" runat="server" TabIndex="26"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="27" ID="resposta7_P" GroupName="7" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="28" ID="resposta7_C" GroupName="7" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_8" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta8_1" runat="server" TabIndex="29"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta8_2" runat="server" TabIndex="30"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="31" ID="resposta8_P" GroupName="8" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="32" ID="resposta8_C" GroupName="8" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_9" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta9_1" runat="server" TabIndex="33"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta9_2" runat="server" TabIndex="34"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="35" ID="resposta9_P" GroupName="9" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="36" ID="resposta9_C" GroupName="9" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label1_10" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="resposta10_1" runat="server" TabIndex="37"/>
                            </td>
                            <td>
                                <asp:TextBox ID="resposta10_2" runat="server" TabIndex="38"/>
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="39" ID="resposta10_P" GroupName="10" runat="server"
                                    Text="P" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="40" ID="resposta10_C" GroupName="10" runat="server"
                                    Text="C" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br clear="all" />
    <table border="0" cellspacing="0" cellpadding="0" width="850px">
        <tr>
            <td width="20%" valign="top" align="center">
                <div id="botaoAnterior" runat="server">
                    <asp:ImageButton ImageUrl="/Image/_file_prev2.png" ID="BtnAnterior" runat="server" 
                        OnClick="BtnAnterior_Click" Height="16px" />
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
