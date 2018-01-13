<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAdministrativoEmpreendedorismo.ascx.cs"
    Inherits="PEG.User_Controls.Avaliacao.UCAdministrativoEmpreendedorismo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <asp:HiddenField ID="HdnIdQuestionarioEmpresa" runat="server" />
    <asp:HiddenField ID="HdnIdEmpresaCadastro" runat="server" />
    <asp:HiddenField ID="HdnIdQuestionario" runat="server" />
    <asp:HiddenField ID="HdnIdTurma" runat="server" />
<br clear="all" />
<div class="divPerguntas" id="divPerguntas" style="display: block;" runat="server">
    <table width="100%" cellpadding="10" cellspacing="4" border="0">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblEmpresa" runat="server">
                    Você irá preencher as questões de 1 a 30, correspondentes às Características de Comportamento Empreendedor.<br />
                    Leia cuidadosamente cada afirmação e decida qual a resposta que melhor se aplica à sua realidade. Marque o número selecionado na linha à direita de cada afirmação.<br />
                    <br />
                    Se você responder, por exemplo, o número 2 nessa afirmação, está indicando que às vezes acontece de você se manter calmo em situações tensas. Essa é sua maneira de se comportar.<br />
                    <br />
                    Todas as questões devem ser preenchidas obrigatoriamente.<br />
                    <br />
                    Algumas afirmações podem ser similares, mas nenhuma é exatamente igual.<br />
                    <br />
                    Seja honesto consigo mesmo. Lembre-se: ninguém faz tudo ou sabe fazer tudo corretamente.<br />
                    <br />
                    Você receberá uma análise de seus resultados com breves explicações sobre cada um dos resultados obtidos, que poderão auxiliá-lo na interpretação dos mesmos e na tomada de melhores decisões em sua empresa.<br />
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Questão</strong></td>
            <td><strong>Dificilmente</strong></td>
            <td><strong>Às Vezes</strong></td>
            <td><strong>Sempre</strong></td>
        </tr>
        <tr>
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="lblPergunta1" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="1" ID="pergunta1respostaA" GroupName="1" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="2" ID="pergunta1respostaB" GroupName="1" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="3" ID="pergunta1respostaC" GroupName="1" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta2" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="5" ID="pergunta2respostaA" GroupName="2" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="6" ID="pergunta2respostaB" GroupName="2" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="7" ID="pergunta2respostaC" GroupName="2" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta3" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="9" ID="pergunta3respostaA" GroupName="3" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="10" ID="pergunta3respostaB" GroupName="3" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="11" ID="pergunta3respostaC" GroupName="3" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta4" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="13" ID="pergunta4respostaA" GroupName="4" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="14" ID="pergunta4respostaB" GroupName="4" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="15" ID="pergunta4respostaC" GroupName="4" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta5" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="17" ID="pergunta5respostaA" GroupName="5" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="18" ID="pergunta5respostaB" GroupName="5" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="19" ID="pergunta5respostaC" GroupName="5" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta6" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="21" ID="pergunta6respostaA" GroupName="6" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="22" ID="pergunta6respostaB" GroupName="6" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="23" ID="pergunta6respostaC" GroupName="6" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta7" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="25" ID="pergunta7respostaA" GroupName="7" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="26" ID="pergunta7respostaB" GroupName="7" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="27" ID="pergunta7respostaC" GroupName="7" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta8" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="29" ID="pergunta8respostaA" GroupName="8" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="30" ID="pergunta8respostaB" GroupName="8" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="31" ID="pergunta8respostaC" GroupName="8" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta9" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="33" ID="pergunta9respostaA" GroupName="9" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="34" ID="pergunta9respostaB" GroupName="9" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="35" ID="pergunta9respostaC" GroupName="9" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta10" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="37" ID="pergunta10respostaA" GroupName="10" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="38" ID="pergunta10respostaB" GroupName="10" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="39" ID="pergunta10respostaC" GroupName="10" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta11" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="41" ID="pergunta11respostaA" GroupName="11" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="42" ID="pergunta11respostaB" GroupName="11" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="43" ID="pergunta11respostaC" GroupName="11" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta12" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="45" ID="pergunta12respostaA" GroupName="12" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="46" ID="pergunta12respostaB" GroupName="12" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="47" ID="pergunta12respostaC" GroupName="12" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta13" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="49" ID="pergunta13respostaA" GroupName="13" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="50" ID="pergunta13respostaB" GroupName="13" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="51" ID="pergunta13respostaC" GroupName="13" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta14" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="53" ID="pergunta14respostaA" GroupName="14" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="54" ID="pergunta14respostaB" GroupName="14" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="55" ID="pergunta14respostaC" GroupName="14" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta15" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="57" ID="pergunta15respostaA" GroupName="15" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="58" ID="pergunta15respostaB" GroupName="15" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="59" ID="pergunta15respostaC" GroupName="15" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta16" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="61" ID="pergunta16respostaA" GroupName="16" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="62" ID="pergunta16respostaB" GroupName="16" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="63" ID="pergunta16respostaC" GroupName="16" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta17" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="65" ID="pergunta17respostaA" GroupName="17" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="66" ID="pergunta17respostaB" GroupName="17" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="67" ID="pergunta17respostaC" GroupName="17" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta18" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="69" ID="pergunta18respostaA" GroupName="18" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="70" ID="pergunta18respostaB" GroupName="18" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="71" ID="pergunta18respostaC" GroupName="18" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta19" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="73" ID="pergunta19respostaA" GroupName="19" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="74" ID="pergunta19respostaB" GroupName="19" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="75" ID="pergunta19respostaC" GroupName="19" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta20" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="77" ID="pergunta20respostaA" GroupName="20" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="78" ID="pergunta20respostaB" GroupName="20" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="79" ID="pergunta20respostaC" GroupName="20" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta21" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="81" ID="pergunta21respostaA" GroupName="21" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="82" ID="pergunta21respostaB" GroupName="21" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="83" ID="pergunta21respostaC" GroupName="21" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta22" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="85" ID="pergunta22respostaA" GroupName="22" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="86" ID="pergunta22respostaB" GroupName="22" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="87" ID="pergunta22respostaC" GroupName="22" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta23" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="89" ID="pergunta23respostaA" GroupName="23" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="89" ID="pergunta23respostaB" GroupName="23" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="90" ID="pergunta23respostaC" GroupName="23" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta24" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="92" ID="pergunta24respostaA" GroupName="24" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="93" ID="pergunta24respostaB" GroupName="24" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="94" ID="pergunta24respostaC" GroupName="24" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta25" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="96" ID="pergunta25respostaA" GroupName="25" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="97" ID="pergunta25respostaB" GroupName="25" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="98" ID="pergunta25respostaC" GroupName="25" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta26" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="100" ID="pergunta26respostaA" GroupName="26" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="101" ID="pergunta26respostaB" GroupName="26" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="102" ID="pergunta26respostaC" GroupName="26" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta27" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="104" ID="pergunta27respostaA" GroupName="27" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="105" ID="pergunta27respostaB" GroupName="27" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="106" ID="pergunta27respostaC" GroupName="27" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta28" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="108" ID="pergunta28respostaA" GroupName="28" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="109" ID="pergunta28respostaB" GroupName="28" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="110" ID="pergunta28respostaC" GroupName="28" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta29" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="112" ID="pergunta29respostaA" GroupName="29" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="113" ID="pergunta29respostaB" GroupName="29" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="114" ID="pergunta29respostaC" GroupName="29" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPergunta30" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="116" ID="pergunta30respostaA" GroupName="30" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="117" ID="pergunta30respostaB" GroupName="30" runat="server"
                    />
            </td>
            <td>
                <asp:RadioButton TabIndex="118" ID="pergunta30respostaC" GroupName="30" runat="server"
                    />
            </td>
        </tr>
        <tr style="height:2px;padding:0 0 0 0;">
            <td colspan="4" style="height:2px;padding:0 0 0 0;">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
    </table>
    <br clear="all" />
</div>
