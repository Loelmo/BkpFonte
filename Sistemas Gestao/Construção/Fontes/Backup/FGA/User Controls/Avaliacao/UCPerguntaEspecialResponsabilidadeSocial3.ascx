<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaEspecialResponsabilidadeSocial3.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.Avaliacao.UCPerguntaEspecialResponsabilidadeSocial3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:HiddenField ID="HdnIdQuestionarioEmpresa" runat="server" />
<asp:HiddenField ID="HdnIdEmpresaCadastro" runat="server" />
<asp:HiddenField ID="HdnIdQuestionario" runat="server" />
<asp:HiddenField ID="HdnIdTurma" runat="server" />
<asp:HiddenField ID="HdnIdPergunta" runat="server" />
<div class="divPerguntas" id="divPerguntas" style="display: block;" runat="server">
    <table width="100%" cellpadding="10" cellspacing="0" border="0">
        <tr>
            <td colspan="5">
                <asp:Label ID="LblPergunta3" runat="server" Text="O fundamento da Responsabilidade Social é o relacionamento da empresa com as partes interessadas (stakeholders) - proprietários, público interno (colaboradores), fornecedores, consumidores, cliente, concorrentes, comunidade, organizações da sociedade civil, órgãos governamentais, entre outros. A existência de ações planejadas indica o nível de adesão e estágio de desenvolvimento em Responsabilidade Social da empresa, como por exemplo, a atenção na seleção de fornecedores que não comprometam produtos e serviços ou a própria imagem da empresa; escuta atenta e ações junto aos clientes fortalecendo os vínculos de confiança; existência de ações preventivas ou corretivas sobre o impacto ambiental do negócio; contribuição para sanar as necessidades da comunidade; monitoramento e retorno aos colaboradores sobre as atividades desenvolvidas de forma respeitosa e propositiva, entre outros." />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="LblMarcarComX" runat="server" Text="(marcar a coluna correspondente a resposta correta para cada parte interessada)" />
            </td>
        </tr>
        <tr>
            <td style="width:120px;">Parte interessada
            </td>
            <td>a) Não desenvolve ações.
            </td>
            <td>b) Desenvolve ações ocasionais.
            </td>
            <td>c) Possui articulação e ações planejadas, ainda não executadas com a parte interessada.
            </td>
            <td>d) Possui articulação e ações planejadas e executadas com a parte interessada. 
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label1_1" runat="server" Text="1. Colaboradores (Público interno)" />
            </td>
            <td>
                <asp:RadioButton TabIndex="1" ID="resposta1_1" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="2" ID="resposta1_2" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="3" ID="resposta1_3" GroupName="1" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="4" ID="resposta1_4" GroupName="1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label1" runat="server" Text="2. Clientes" />
            </td>
            <td>
                <asp:RadioButton TabIndex="5" ID="resposta2_1" GroupName="2" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="6" ID="resposta2_2" GroupName="2" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="7" ID="resposta2_3" GroupName="2" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="8" ID="resposta2_4" GroupName="2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label2" runat="server" Text="3. Consumidores" />
            </td>
            <td>
                <asp:RadioButton TabIndex="9" ID="resposta3_1" GroupName="3" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="10" ID="resposta3_2" GroupName="3" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="11" ID="resposta3_3" GroupName="3" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="12" ID="resposta3_4" GroupName="3" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label3" runat="server" Text="4. Fornecedores" />
            </td>
            <td>
                <asp:RadioButton TabIndex="13" ID="resposta4_1" GroupName="4" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="14" ID="resposta4_2" GroupName="4" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="15" ID="resposta4_3" GroupName="4" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="16" ID="resposta4_4" GroupName="4" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label4" runat="server" Text="5. Instituições governamentais" />
            </td>
            <td>
                <asp:RadioButton TabIndex="17" ID="resposta5_1" GroupName="5" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="18" ID="resposta5_2" GroupName="5" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="19" ID="resposta5_3" GroupName="5" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="20" ID="resposta5_4" GroupName="5" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label5" runat="server" Text="6. Concorrentes" />
            </td>
            <td>
                <asp:RadioButton TabIndex="21" ID="resposta6_1" GroupName="6" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="22" ID="resposta6_2" GroupName="6" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="23" ID="resposta6_3" GroupName="6" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="24" ID="resposta6_4" GroupName="6" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label6" runat="server" Text="7. Terceiro Setor" />
            </td>
            <td>
                <asp:RadioButton TabIndex="25" ID="resposta7_1" GroupName="7" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="26" ID="resposta7_2" GroupName="7" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="27" ID="resposta7_3" GroupName="7" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="28" ID="resposta7_4" GroupName="7" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label7" runat="server" Text="8. Comunidade" />
            </td>
            <td>
                <asp:RadioButton TabIndex="29" ID="resposta8_1" GroupName="8" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="30" ID="resposta8_2" GroupName="8" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="31" ID="resposta8_3" GroupName="8" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="32" ID="resposta8_4" GroupName="8" runat="server" />
            </td>
        </tr>
    </table>
</div>
