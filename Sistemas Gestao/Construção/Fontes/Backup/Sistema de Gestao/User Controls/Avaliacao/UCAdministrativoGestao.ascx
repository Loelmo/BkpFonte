<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAdministrativoGestao.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.Avaliacao.UCAdministrativoGestao" %>
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
                CLIENTES
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 01.
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
            <td colspan="5" style="text-align:center;">Principais grupos de clientes e as suas necessidades: <asp:TextBox TabIndex="5" ID="justificativa1" Height="42px" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
            <td colspan="5" style="text-align:center;">Principais impactos negativos causados pelas atividades da empresa ao meio ambiente: <asp:TextBox TabIndex="25" Height="42px" ID="justificativa6" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
            <td colspan="5" style="text-align:center;">Principais ações sociais desenvolvidas pela empresa com foco nas necessidades da comunidade: <asp:TextBox TabIndex="33" Height="42px" ID="justificativa8" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="titulo_azul" style="padding:0 0 0 0;text-align:center;font-weight:bold;" style="width: 100%">
                LIDERANÇA
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
            <td colspan="5" style="text-align:center;">Descreva a Missão e os Valores e os meios de divulgação destes para os colaboradores: <asp:TextBox TabIndex="37" Height="42px" ID="justificativa9" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
            <td colspan="5" style="text-align:center;">Periodicidade da análise de desempenho, quem participa e exemplos de informações e indicadores utilizados: <asp:TextBox TabIndex="45" Height="42px" ID="justificativa11" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
            <td colspan="5">
                <img src="/Image/divisoria.png" width="100%" height="2" />
            </td>
        </tr>
        <tr>
            <td> 13.
            </td>
            <td>
                <asp:RadioButton TabIndex="49" ID="pergunta13respostaA" GroupName="13" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="50" ID="pergunta13respostaB" GroupName="13" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="51" ID="pergunta13respostaC" GroupName="13" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="52" ID="pergunta13respostaD" GroupName="13" runat="server"
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
                <asp:RadioButton TabIndex="53" ID="pergunta14respostaA" GroupName="14" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="54" ID="pergunta14respostaB" GroupName="14" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="55" ID="pergunta14respostaC" GroupName="14" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="56" ID="pergunta14respostaD" GroupName="14" runat="server"
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
                ESTRATÉGIAS E PLANOS
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
                <asp:RadioButton TabIndex="57" ID="pergunta15respostaA" GroupName="15" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="58" ID="pergunta15respostaB" GroupName="15" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="59" ID="pergunta15respostaC" GroupName="15" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="60" ID="pergunta15respostaD" GroupName="15" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Descreva a Visão e os meios de divulgação desta para os colaboradores: <asp:TextBox TabIndex="61" Height="42px" ID="justificativa15" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
                <asp:RadioButton TabIndex="61" ID="pergunta16respostaA" GroupName="16" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="62" ID="pergunta16respostaB" GroupName="16" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="63" ID="pergunta16respostaC" GroupName="16" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="64" ID="pergunta16respostaD" GroupName="16" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Estratégias estabelecidas pela empresa: <asp:TextBox TabIndex="65" Height="42px" ID="justificativa16" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
                <asp:RadioButton TabIndex="65" ID="pergunta17respostaA" GroupName="17" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="66" ID="pergunta17respostaB" GroupName="17" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="67" ID="pergunta17respostaC" GroupName="17" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="68" ID="pergunta17respostaD" GroupName="17" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Principais metas da empresa, sua relação com as estratégias estabelecidas e os indicadores de desempenho utilizados: <asp:TextBox TabIndex="69" Height="42px" ID="justificativa17" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
                <asp:RadioButton TabIndex="69" ID="pergunta18respostaA" GroupName="18" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="70" ID="pergunta18respostaB" GroupName="18" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="71" ID="pergunta18respostaC" GroupName="18" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="72" ID="pergunta18respostaD" GroupName="18" runat="server"
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
            <td> 19.
            </td>
            <td>
                <asp:RadioButton TabIndex="73" ID="pergunta19respostaA" GroupName="19" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="74" ID="pergunta19respostaB" GroupName="19" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="75" ID="pergunta19respostaC" GroupName="19" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="76" ID="pergunta19respostaD" GroupName="19" runat="server"
                    Text="d" />
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
                <asp:RadioButton TabIndex="77" ID="pergunta20respostaA" GroupName="20" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="78" ID="pergunta20respostaB" GroupName="20" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="79" ID="pergunta20respostaC" GroupName="20" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="80" ID="pergunta20respostaD" GroupName="20" runat="server"
                    Text="d" />
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
                <asp:RadioButton TabIndex="81" ID="pergunta21respostaA" GroupName="21" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="82" ID="pergunta21respostaB" GroupName="21" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="83" ID="pergunta21respostaC" GroupName="21" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="84" ID="pergunta21respostaD" GroupName="21" runat="server"
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
                <asp:RadioButton TabIndex="85" ID="pergunta22respostaA" GroupName="22" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="86" ID="pergunta22respostaB" GroupName="22" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="87" ID="pergunta22respostaC" GroupName="22" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="88" ID="pergunta22respostaD" GroupName="22" runat="server"
                    Text="d" />
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
                <asp:RadioButton TabIndex="89" ID="pergunta23respostaA" GroupName="23" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="89" ID="pergunta23respostaB" GroupName="23" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="90" ID="pergunta23respostaC" GroupName="23" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="91" ID="pergunta23respostaD" GroupName="23" runat="server"
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
                PROCESSOS
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
                <asp:RadioButton TabIndex="92" ID="pergunta24respostaA" GroupName="24" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="93" ID="pergunta24respostaB" GroupName="24" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="94" ID="pergunta24respostaC" GroupName="24" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="95" ID="pergunta24respostaD" GroupName="24" runat="server"
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
                <asp:RadioButton TabIndex="96" ID="pergunta25respostaA" GroupName="25" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="97" ID="pergunta25respostaB" GroupName="25" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="98" ID="pergunta25respostaC" GroupName="25" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="99" ID="pergunta25respostaD" GroupName="25" runat="server"
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
                <asp:RadioButton TabIndex="100" ID="pergunta26respostaA" GroupName="26" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="101" ID="pergunta26respostaB" GroupName="26" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="102" ID="pergunta26respostaC" GroupName="26" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="103" ID="pergunta26respostaD" GroupName="26" runat="server"
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
                <asp:RadioButton TabIndex="104" ID="pergunta27respostaA" GroupName="27" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="105" ID="pergunta27respostaB" GroupName="27" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="106" ID="pergunta27respostaC" GroupName="27" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="107" ID="pergunta27respostaD" GroupName="27" runat="server"
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
                INFORMAÇÃO E CONHECIMENTO
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
                <asp:RadioButton TabIndex="108" ID="pergunta28respostaA" GroupName="28" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="109" ID="pergunta28respostaB" GroupName="28" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="110" ID="pergunta28respostaC" GroupName="28" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="111" ID="pergunta28respostaD" GroupName="28" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Principais informações utilizadas pela empresa para a execução de suas atividades, tomada de decisão e análise do negócio: <asp:TextBox TabIndex="112" Height="42px" ID="justificativa28" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
                <asp:RadioButton TabIndex="112" ID="pergunta29respostaA" GroupName="29" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="113" ID="pergunta29respostaB" GroupName="29" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="114" ID="pergunta29respostaC" GroupName="29" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="115" ID="pergunta29respostaD" GroupName="29" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Principais meios de divulgação das informações importantes para os colaboradores e desde quando eles são utilizados: <asp:TextBox TabIndex="116" Height="42px" ID="justificativa29" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
                <asp:RadioButton TabIndex="116" ID="pergunta30respostaA" GroupName="30" runat="server"
                    Text="a" />
            </td>
            <td>
                <asp:RadioButton TabIndex="117" ID="pergunta30respostaB" GroupName="30" runat="server"
                    Text="b" />
            </td>
            <td>
                <asp:RadioButton TabIndex="118" ID="pergunta30respostaC" GroupName="30" runat="server"
                    Text="c" />
            </td>
            <td>
                <asp:RadioButton TabIndex="119" ID="pergunta30respostaD" GroupName="30" runat="server"
                    Text="d" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;">Informações comparativas utilizadas, o nome das empresas usadas como referenciais comparativos e algumas melhorias obtidas a partir das comparações e estudos realizados, citando em que ano isso aconteceu: <asp:TextBox TabIndex="120" Height="42px" ID="justificativa30" TextMode="MultiLine" runat="server" Width="650px" Font-Names="Arial" Font-Size="12px"/>
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
    </table>
    <br />
        <table cellSpacing="0" cellPadding="1"  border="0" class="quiz" style="width:900px; margin-top:20px;">
                        <tr>
                            <td class="opcao">31.
                            </td>
                            <td align="center" colspan="2" class="opcao">
                                Controla</td>
                            <td align="center" colspan="3" class="opcao">
                                Ano
                            </td>
                            <td align="center" class="opcao" >&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="">
                                <b>  Indicadores </b>
                            </td>
                            <td>
                                <b> Sim </b>
                            </td>
                            <td>
                                <b> Não </b>
                            </td>
                            <td>
                                <b> 2007 </b>
                            </td>
                            <td>
                                <b> 2008 </b>
                            </td>
                            <td>
                                <b> 2009 </b>
                            </td>
                            <td>
                                <b>  Desempenho</b></td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Receita Total (R$)
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="121" GroupName="receita"  ID="rdSim31" runat="server" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="122"  GroupName="receita"  ID="rdNao31" runat="server" />
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
                            <td>
                                      
                                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto maior melhor</span></td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Despesa Total (R$)
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="126" GroupName="despesa"  ID="rdSim32" runat="server" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="127" GroupName="despesa"  ID="rdNao32" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox TabIndex="128" ID="tx1_32" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="129" ID="tx2_32" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="130" ID="tx3_32" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                      
                                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto menor melhor</span></td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Índice de satisfação
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="131" GroupName="Satisfacao"   ID="rdSim33" runat="server" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="132" GroupName="Satisfacao"   ID="rdNao33" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox TabIndex="133" ID="tx1_33" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="134" ID="tx2_33" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="135" ID="tx3_33" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                      
                                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto maior melhor</span></td>
                        </tr>
                        <tr>
                            <td class="style3">
                            Nº de reclamações 
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="136" GroupName="Reclamaca"   ID="rdSim34" runat="server" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="137" GroupName="Reclamaca"  ID="rdNao34" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox TabIndex="138" ID="tx1_34" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="139" ID="tx2_34" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="140" ID="tx3_34" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                      
                                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto menor melhor</span></td>
                        </tr>
                                
                        <tr>
                            <td class="style3">
                            Nº de colaboradores 
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="141" GroupName="colaboradores"    ID="rdSim35" runat="server" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="142" GroupName="colaboradores"   ID="rdNao35" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox TabIndex="143" ID="tx1_35" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="144" ID="tx2_35" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="145" ID="tx3_35" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                      
                                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto maior melhor</span></td>
                        </tr>
                                
                        <tr>
                            <td class="style3">
                            Rotatividade
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="146" GroupName="Rotatividade"   ID="rdSim36" runat="server" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="147" GroupName="Rotatividade"  ID="rdNao36" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox TabIndex="148" ID="tx1_36" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="149" ID="tx2_36" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="150" ID="tx3_36" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                      
                                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto menor melhor</span></td>
                        </tr>
                                
                        <tr>
                            <td class="style3">
                            Nº de acidentes com afastamento
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="151" GroupName="acidadente"  ID="rdSim37" runat="server" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="152" GroupName="acidadente"   ID="rdNao37" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox TabIndex="153" ID="tx1_37" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="154" ID="tx2_37" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="155" ID="tx3_37" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                      
                                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto menor melhor</span></td>
                        </tr>
                                
                        <tr>
                            <td class="style3">
                            Produção 
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="156" GroupName="Producao" ID="rdSim38" runat="server" />
                            </td>
                            <td>
                                <asp:RadioButton TabIndex="157" GroupName="Producao" ID="rdNao38" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox TabIndex="158" ID="tx1_38" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="159" ID="tx2_38" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox TabIndex="160" ID="tx3_38" runat="server" Text="" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                      
                                <span lang="EN-US" style="font-size:9.0pt;font-family:
                                ;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
                                EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto maior melhor</span></td>
                        </tr>
                    </table>
    <br clear="all" />
</div>
