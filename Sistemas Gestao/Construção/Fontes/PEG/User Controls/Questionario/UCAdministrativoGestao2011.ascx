<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAdministrativoGestao2011.ascx.cs"
    Inherits="PEG.User_Controls.UCAdministrativoGestao2011" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <asp:HiddenField ID="HdnIdQuestionarioEmpresa" runat="server" />
    <asp:HiddenField ID="HdnIdEmpresaCadastro" runat="server" />
    <asp:HiddenField ID="HdnIdQuestionario" runat="server" />
    <asp:HiddenField ID="HdnIdTurma" runat="server" />
<br clear="all" />
<div class="divPerguntas" id="divPerguntas" style="display: block;" runat="server">
    <table width="100%" cellpadding="10" cellspacing="0" border="0">
        <tr>
            <td colspan="5" class="titulo_azul" style="padding:0 0 0 0;text-align:center;font-weight:bold;">
                LIDERANÇA
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td style="width:250px;"> 01.
            </td>
            <td>
                <asp:RadioButton TabIndex="1" ID="pergunta1respostaA" GroupName="1" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="2" ID="pergunta1respostaB" GroupName="1" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="3" ID="pergunta1respostaC" GroupName="1" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="4" ID="pergunta1respostaD" GroupName="1" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar a Missão da empresa e os meios utilizados para a sua comunicação aos colaboradores: <asp:TextBox TabIndex="5" ID="justificativa1" Height="42px" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"  Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 02.
            </td>
            <td>
                <asp:RadioButton TabIndex="5" ID="pergunta2respostaA" GroupName="2" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="6" ID="pergunta2respostaB" GroupName="2" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="7" ID="pergunta2respostaC" GroupName="2" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="8" ID="pergunta2respostaD" GroupName="2" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 03.
            </td>
            <td>
                <asp:RadioButton TabIndex="9" ID="pergunta3respostaA" GroupName="3" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="10" ID="pergunta3respostaB" GroupName="3" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="11" ID="pergunta3respostaC" GroupName="3" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="12" ID="pergunta3respostaD" GroupName="3" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar a periodicidade da análise de desempenho, os participantes e exemplos de informações utilizadas na análise do desempenho e na comparação com outras empresas:<br /> <asp:TextBox TabIndex="12" ID="justificativa3" Height="42px" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 04.
            </td>
            <td>
                <asp:RadioButton TabIndex="13" ID="pergunta4respostaA" GroupName="4" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="14" ID="pergunta4respostaB" GroupName="4" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="15" ID="pergunta4respostaC" GroupName="4" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="16" ID="pergunta4respostaD" GroupName="4" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 05.
            </td>
            <td>
                <asp:RadioButton TabIndex="17" ID="pergunta5respostaA" GroupName="5" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="18" ID="pergunta5respostaB" GroupName="5" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="19" ID="pergunta5respostaC" GroupName="5" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="20" ID="pergunta5respostaD" GroupName="5" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 06.
            </td>
            <td>
                <asp:RadioButton TabIndex="21" ID="pergunta6respostaA" GroupName="6" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="22" ID="pergunta6respostaB" GroupName="6" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="23" ID="pergunta6respostaC" GroupName="6" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="24" ID="pergunta6respostaD" GroupName="6" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 07.
            </td>
            <td>
                <asp:RadioButton TabIndex="25" ID="pergunta7respostaA" GroupName="7" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="26" ID="pergunta7respostaB" GroupName="7" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="27" ID="pergunta7respostaC" GroupName="7" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="28" ID="pergunta7respostaD" GroupName="7" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar o exemplo de inovação implementada: <asp:TextBox TabIndex="28" Height="42px" ID="justificativa7" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="titulo_azul" style="padding:0 0 0 0;text-align:center;font-weight:bold;" style="width: 100%">
                ESTRATÉGIAS E PLANOS
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 08.
            </td>
            <td>
                <asp:RadioButton TabIndex="29" ID="pergunta8respostaA" GroupName="8" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="30" ID="pergunta8respostaB" GroupName="8" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="31" ID="pergunta8respostaC" GroupName="8" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="32" ID="pergunta8respostaD" GroupName="8" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar a Visão e os meios de comunicação desta para os colaboradores: <asp:TextBox TabIndex="33" Height="42px" ID="justificativa8" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 09.
            </td>
            <td>
                <asp:RadioButton TabIndex="33" ID="pergunta9respostaA" GroupName="9" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="34" ID="pergunta9respostaB" GroupName="9" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="35" ID="pergunta9respostaC" GroupName="9" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="36" ID="pergunta9respostaD" GroupName="9" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar as estratégias definidas pela empresa: <asp:TextBox TabIndex="37" Height="42px" ID="justificativa9" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 10.
            </td>
            <td>
                <asp:RadioButton TabIndex="37" ID="pergunta10respostaA" GroupName="10" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="38" ID="pergunta10respostaB" GroupName="10" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="39" ID="pergunta10respostaC" GroupName="10" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="40" ID="pergunta10respostaD" GroupName="10" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 11.
            </td>
            <td>
                <asp:RadioButton TabIndex="41" ID="pergunta11respostaA" GroupName="11" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="42" ID="pergunta11respostaB" GroupName="11" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="43" ID="pergunta11respostaC" GroupName="11" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="44" ID="pergunta11respostaD" GroupName="11" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="titulo_azul" style="padding:0 0 0 0;text-align:center;font-weight:bold;" style="width: 100%">
                CLIENTES
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 12.
            </td>
            <td>
                <asp:RadioButton TabIndex="45" ID="pergunta12respostaA" GroupName="12" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="46" ID="pergunta12respostaB" GroupName="12" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="47" ID="pergunta12respostaC" GroupName="12" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="48" ID="pergunta12respostaD" GroupName="12" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar as estratégias definidas pela empresa: <asp:TextBox TabIndex="49" Height="42px" ID="justificativa12" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 13.
            </td>
            <td>
                <asp:RadioButton TabIndex="50" ID="pergunta13respostaA" GroupName="13" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="51" ID="pergunta13respostaB" GroupName="13" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="52" ID="pergunta13respostaC" GroupName="13" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="53" ID="pergunta13respostaD" GroupName="13" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 14.
            </td>
            <td>
                <asp:RadioButton TabIndex="54" ID="pergunta14respostaA" GroupName="14" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="55" ID="pergunta14respostaB" GroupName="14" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="56" ID="pergunta14respostaC" GroupName="14" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="57" ID="pergunta14respostaD" GroupName="14" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 15.
            </td>
            <td>
                <asp:RadioButton TabIndex="58" ID="pergunta15respostaA" GroupName="15" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="59" ID="pergunta15respostaB" GroupName="15" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="60" ID="pergunta15respostaC" GroupName="15" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="61" ID="pergunta15respostaD" GroupName="15" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 16.
            </td>
            <td>
                <asp:RadioButton TabIndex="62" ID="pergunta16respostaA" GroupName="16" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="63" ID="pergunta16respostaB" GroupName="16" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="64" ID="pergunta16respostaC" GroupName="16" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="65" ID="pergunta16respostaD" GroupName="16" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="titulo_azul" style="padding:0 0 0 0;text-align:center;font-weight:bold;" style="width: 100%">
                SOCIEDADE
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 17.
            </td>
            <td>
                <asp:RadioButton TabIndex="66" ID="pergunta17respostaA" GroupName="17" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="67" ID="pergunta17respostaB" GroupName="17" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="68" ID="pergunta17respostaC" GroupName="17" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="69" ID="pergunta17respostaD" GroupName="17" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 18.
            </td>
            <td>
                <asp:RadioButton TabIndex="70" ID="pergunta18respostaA" GroupName="18" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="71" ID="pergunta18respostaB" GroupName="18" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="72" ID="pergunta18respostaC" GroupName="18" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="73" ID="pergunta18respostaD" GroupName="18" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar os principais impactos negativos causados pelas atividades da empresa ao meio ambiente: <asp:TextBox TabIndex="74" Height="42px" ID="justificativa18" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 19.
            </td>
            <td>
                <asp:RadioButton TabIndex="75" ID="pergunta19respostaA" GroupName="19" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="76" ID="pergunta19respostaB" GroupName="19" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="77" ID="pergunta19respostaC" GroupName="19" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="78" ID="pergunta19respostaD" GroupName="19" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar as principais ações e projetos sociais desenvolvidos pela empresa com foco nas necessidades da comunidade: <asp:TextBox TabIndex="79" Height="42px" ID="justificativa19" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="titulo_azul" style="padding:0 0 0 0;text-align:center;font-weight:bold;" style="width: 100%">
                INFORMAÇÕES E CONHECIMENTO
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 20.
            </td>
            <td>
                <asp:RadioButton TabIndex="80" ID="pergunta20respostaA" GroupName="20" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="81" ID="pergunta20respostaB" GroupName="20" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="82" ID="pergunta20respostaC" GroupName="20" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="83" ID="pergunta20respostaD" GroupName="20" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar as principais informações utilizadas pela empresa para a análise e execução de suas atividades e para a tomada de decisão: <asp:TextBox TabIndex="84" Height="42px" ID="justificativa20" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 21.
            </td>
            <td>
                <asp:RadioButton TabIndex="85" ID="pergunta21respostaA" GroupName="21" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="86" ID="pergunta21respostaB" GroupName="21" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="87" ID="pergunta21respostaC" GroupName="21" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="88" ID="pergunta21respostaD" GroupName="21" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 22.
            </td>
            <td>
                <asp:RadioButton TabIndex="89" ID="pergunta22respostaA" GroupName="22" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="90" ID="pergunta22respostaB" GroupName="22" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="91" ID="pergunta22respostaC" GroupName="22" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="92" ID="pergunta22respostaD" GroupName="22" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="titulo_azul" style="padding:0 0 0 0;text-align:center;font-weight:bold;" style="width: 100%">
                PESSOAS
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 23.
            </td>
            <td>
                <asp:RadioButton TabIndex="93" ID="pergunta23respostaA" GroupName="23" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="94" ID="pergunta23respostaB" GroupName="23" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="95" ID="pergunta23respostaC" GroupName="23" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="96" ID="pergunta23respostaD" GroupName="23" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 24.
            </td>
            <td>
                <asp:RadioButton TabIndex="97" ID="pergunta24respostaA" GroupName="24" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="98" ID="pergunta24respostaB" GroupName="24" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="99" ID="pergunta24respostaC" GroupName="24" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="100" ID="pergunta24respostaD" GroupName="24" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 25.
            </td>
            <td>
                <asp:RadioButton TabIndex="101" ID="pergunta25respostaA" GroupName="25" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="102" ID="pergunta25respostaB" GroupName="25" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="103" ID="pergunta25respostaC" GroupName="25" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="104" ID="pergunta25respostaD" GroupName="25" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 26.
            </td>
            <td>
                <asp:RadioButton TabIndex="105" ID="pergunta26respostaA" GroupName="26" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="106" ID="pergunta26respostaB" GroupName="26" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="107" ID="pergunta26respostaC" GroupName="26" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="108" ID="pergunta26respostaD" GroupName="26" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 27.
            </td>
            <td>
                <asp:RadioButton TabIndex="109" ID="pergunta27respostaA" GroupName="27" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="110" ID="pergunta27respostaB" GroupName="27" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="111" ID="pergunta27respostaC" GroupName="27" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="112" ID="pergunta27respostaD" GroupName="27" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar as principais ações adotadas para promover o bem-estar e a satisfação das pessoas: <asp:TextBox TabIndex="113" Height="42px" ID="justificativa27" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="titulo_azul" style="padding:0 0 0 0;text-align:center;font-weight:bold;" style="width: 100%">
                PROCESSOS
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 28.
            </td>
            <td>
                <asp:RadioButton TabIndex="114" ID="pergunta28respostaA" GroupName="28" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="115" ID="pergunta28respostaB" GroupName="28" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="116" ID="pergunta28respostaC" GroupName="28" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="117" ID="pergunta28respostaD" GroupName="28" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Apresentar os processos principais do negócio: <asp:TextBox TabIndex="118" Height="42px" ID="justificativa28" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 29.
            </td>
            <td>
                <asp:RadioButton TabIndex="119" ID="pergunta29respostaA" GroupName="29" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="120" ID="pergunta29respostaB" GroupName="29" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="121" ID="pergunta29respostaC" GroupName="29" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="122" ID="pergunta29respostaD" GroupName="29" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 30.
            </td>
            <td>
                <asp:RadioButton TabIndex="123" ID="pergunta30respostaA" GroupName="30" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="124" ID="pergunta30respostaB" GroupName="30" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="125" ID="pergunta30respostaC" GroupName="30" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="126" ID="pergunta30respostaD" GroupName="30" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 31.
            </td>
            <td>
                <asp:RadioButton TabIndex="127" ID="pergunta31respostaA" GroupName="31" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="128" ID="pergunta31respostaB" GroupName="31" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="129" ID="pergunta31respostaC" GroupName="31" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="130" ID="pergunta31respostaD" GroupName="31" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="titulo_azul" style="padding:0 0 0 0;text-align:center;font-weight:bold;" style="width: 100%">
                RESULTADOS
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td colspan="5"> 32.
            </td>
        </tr>
        <tr>
            <td> Satisfação dos clientes?
            </td>
            <td>
                <asp:RadioButton TabIndex="131" ID="pergunta32respostaA" GroupName="32" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="132" ID="pergunta32respostaB" GroupName="32" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="133" ID="pergunta32respostaC" GroupName="32" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="134" ID="pergunta32respostaD" GroupName="32" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> Reclamações de clientes?
            </td>
            <td>
                <asp:RadioButton TabIndex="135" ID="pergunta33respostaA" GroupName="33" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="136" ID="pergunta33respostaB" GroupName="33" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="137" ID="pergunta33respostaC" GroupName="33" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="138" ID="pergunta33respostaD" GroupName="33" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> Capacitações ministradas para os colaboradores?
            </td>
            <td>
                <asp:RadioButton TabIndex="139" ID="pergunta34respostaA" GroupName="34" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="140" ID="pergunta34respostaB" GroupName="34" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="141" ID="pergunta34respostaC" GroupName="34" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="142" ID="pergunta34respostaD" GroupName="34" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> Acidentes com colaboradores?
            </td>
            <td>
                <asp:RadioButton TabIndex="143" ID="pergunta35respostaA" GroupName="35" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="144" ID="pergunta35respostaB" GroupName="35" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="145" ID="pergunta35respostaC" GroupName="35" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="146" ID="pergunta35respostaD" GroupName="35" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> Produtividade no trabalho? 
            </td>
            <td>
                <asp:RadioButton TabIndex="147" ID="pergunta36respostaA" GroupName="36" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="148" ID="pergunta36respostaB" GroupName="36" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="149" ID="pergunta36respostaC" GroupName="36" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="150" ID="pergunta36respostaD" GroupName="36" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> Margem de lucro?
            </td>
            <td>
                <asp:RadioButton TabIndex="151" ID="pergunta37respostaA" GroupName="37" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="152" ID="pergunta37respostaB" GroupName="37" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="153" ID="pergunta37respostaC" GroupName="37" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="154" ID="pergunta37respostaD" GroupName="37" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
    </table>
    <br />
        <table cellSpacing="0" cellPadding="1"  border="0" class="quiz" style="width:900px; margin-top:20px;">
                        <tr>
                            <td class="opcao">Tabela de apresentação dos resultados.
                            </td>
                            <td align="center" colspan="3" class="opcao">
                                Ano
                            </td>
                        </tr>
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
                                Satisfação dos clientes
                            </td>
                            <td>
                                <asp:TextBox TabIndex="155" ID="tx1_32" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="156" ID="tx2_32" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="157" ID="tx3_32" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Reclamações de clientes
                            </td>
                            <td>
                                <asp:TextBox TabIndex="158" ID="tx1_33" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="159" ID="tx2_33" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="160" ID="tx3_33" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Capacitações ministradas para os colaboradores
                            </td>
                            <td>
                                <asp:TextBox TabIndex="161" ID="tx1_34" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="162" ID="tx2_34" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="163" ID="tx3_34" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Acidentes com colaboradores
                            </td>
                            <td>
                                <asp:TextBox TabIndex="164" ID="tx1_35" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="165" ID="tx2_35" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="166" ID="tx3_35" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                            Produtividade no trabalho
                            </td>
                            <td>
                                <asp:TextBox TabIndex="167" ID="tx1_36" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="168" ID="tx2_36" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="169" ID="tx3_36" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                    </table>
    <br clear="all" />
    <table border="0" cellspacing="0" cellpadding="0" width="850px">
        <tr>
            <td width="20%" valign="top" align="center">
                <asp:ImageButton TabIndex="99" ImageUrl="/Image/_file_back2.png" ID="ImageButton1" runat="server" OnClick="BtnVoltar_Click" />
            </td>
            <td class="justificativa" width="60%" align="center">
            </td>
            <td width="20%" valign="top" align="center">
                <div id="botaoProximo" runat="server">
                    <asp:ImageButton ImageUrl="/Image/_file_save.png" ID="BtnSalvar" runat="server" OnClick="BtnSalvar_Click" TabIndex="170"/>
                </div>
            </td>
        </tr>
    </table>
</div>
