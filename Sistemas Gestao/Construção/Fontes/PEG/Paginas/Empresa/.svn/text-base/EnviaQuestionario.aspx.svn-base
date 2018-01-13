<%@ Page Title="Sistemas de Gestão" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="EnviaQuestionario.aspx.cs" Inherits="PEG.Paginas.Empresa.EnviaQuestionario" %>

    <%@ Register Src="/User Controls/Questionario/UCSelecionaQuestionarioEmpresa.ascx" TagName="UCSelecionaQuestionarioEmpresa" TagPrefix="uc1" %>

<%@ Register src="../../User Controls/UCStatus.ascx" tagname="UCStatus" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div align="center">
    <uc2:UCStatus ID="UCStatus1" runat="server" />
</div>


    <fieldset>
        <legend>Questionários</legend>
        <table style="width:900px;">
            <tr>
                <asp:Panel ID="PnlQuestionarios" runat="server">
                </asp:Panel>
            </tr>
            <tr>
                <td>
                    <div id="avaliacaoProcesso" runat="server" style="display:none;width:900px;">
                        <asp:Label Font-Bold="true" runat="server" ID="LblIntroducao" Text="Prezado(a) Empresário(a), você acabou de preencher o questionário de autoavaliação do MPE Brasil. Antes que você tenha acesso a seu Relatório com os Pontos Fortes e Oportunidades para Melhoria, com base em suas respostas, pedimos a gentileza de responder a seguinte pesquisa." />
                        <br />
                        <br />
                        <asp:Label runat="server" ID="LblAvaliacaoProcesso" Text="PESQUISA DE SATISFAÇÃO COM O PROCESSO DE CANDIDATURA AO MPE BRASIL – Assinale a opção que melhor responde às afirmações abaixo:" />
                        <br />
                        <br />
                        <table style="width:900px;">
                            <tr>
                                <td>
                                    <asp:Label Font-Bold="true" ID="LblAfirmacoes" runat="server" Text="Afirmações sobre sua candidatura no MPE Brasil" />
                                </td>
                                <td>
                                    <asp:Label Font-Bold="true" ID="Label1" runat="server" Text="Concordo Totalmente" />
                                </td>
                                <td>
                                    <asp:Label Font-Bold="true" ID="Label2" runat="server" Text="Concordo Parcialmente" />
                                </td>
                                <td>
                                    <asp:Label Font-Bold="true" ID="Label3" runat="server" Text="Discordo Totalmente" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Todas as informações necessárias para participar do MPE Brasil estão disponíveis e apresentadas de forma clara e fácil de serem encontradas no Site do Prêmio." />
                                </td>
                                <td>
                                    <asp:RadioButton TabIndex="1" ID="pergunta1respostaA" GroupName="1" runat="server" />
                                </td>
                                <td>
                                    <asp:RadioButton TabIndex="2" ID="pergunta1respostaB" GroupName="1" runat="server" />
                                </td>
                                <td>
                                    <asp:RadioButton TabIndex="3" ID="pergunta1respostaC" GroupName="1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Todas as informações e resultados solicitados no Questionário de Autoavaliação da Gestão são de fácil compreensão por empresários em geral. " />
                                </td>
                                <td>
                                    <asp:RadioButton TabIndex="4" ID="pergunta2respostaA" GroupName="2" runat="server" />
                                </td>
                                <td>
                                    <asp:RadioButton TabIndex="5" ID="pergunta2respostaB" GroupName="2" runat="server" />
                                </td>
                                <td>
                                    <asp:RadioButton TabIndex="6" ID="pergunta2respostaC" GroupName="2" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Todas as informações e resultados solicitados no Questionário de Autoavaliação da Gestão são passíveis de serem respondidas por empresários de micro e pequenas empresas (MPEs)." />
                                </td>
                                <td>
                                    <asp:RadioButton TabIndex="7" ID="pergunta3respostaA" GroupName="3" runat="server" />
                                </td>
                                <td>
                                    <asp:RadioButton TabIndex="8" ID="pergunta3respostaB" GroupName="3" runat="server" />
                                </td>
                                <td>
                                    <asp:RadioButton TabIndex="9" ID="pergunta3respostaC" GroupName="3" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:ImageButton ImageUrl="/Image/_file_save.png" ID="Button1" onclick="BtnEnviarPesquisa_Click" runat="server" />
                        <br />
                    </div>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <div id="relatorioJaEnviado" runat="server" style="display:none;">
                        <asp:Label runat="server" ID="LblJaEnviado" Text="Sua autoavaliação já foi enviada. Selecione a opção abaixo para fazer seu download:" />
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">
                            <asp:Image ID="Image1" ImageUrl="/Image/_file_download.png" runat="server" BorderStyle="None" /></asp:HyperLink>
                        <br />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                    <asp:Label ID="LblEtapaDesabilitada" runat="server" Text="A etapa de inscrição para empresas do seu estado já se encontra encerrada." Visible="false"/>
                    <asp:ImageButton ImageUrl="/Image/_file_send2.png" ID="BtnEnviar" onclick="BtnEnviar_Click" runat="server" OnClientClick="javascript:return confirm('Confirma envio de questionário?');"/>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
