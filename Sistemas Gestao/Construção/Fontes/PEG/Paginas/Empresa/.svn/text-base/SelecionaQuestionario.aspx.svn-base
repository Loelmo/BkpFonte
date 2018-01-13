<%@ Page Title="Sistemas de Gestão" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="SelecionaQuestionario.aspx.cs" Inherits="PEG.Paginas.Empresa.SelecionaQuestionario" %>
    <%@ Register Src="~/User Controls/Questionario/UCSelecionaQuestionarioEmpresa.ascx" TagName="UCSelecionaQuestionarioEmpresa" TagPrefix="uc1" %>
<%@ Register src="~/User Controls/UCStatus.ascx" tagname="UCStatus" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div align="center">
    <uc2:UCStatus ID="UCStatus1" runat="server" />
</div>

<fieldset>
        <legend>Questionários<asp:Label ID="LblEmpresaDigitador" runat="server" Text=""/></legend>
        <table>
        <tr>
            <td colspan="4">
                 <asp:Label runat="server" ID="lblAvisoPreenchimentoMpe" Text="Clique em 'Responder' para iniciar seu autodiagnóstico:" />
            </td>
        </tr>
        <tr >
            <asp:Panel ID="PnlQuestionarios" runat="server">
            </asp:Panel>
        </tr>
    </table>
</fieldset>
<fieldset>
        <legend>Resumo do Preenchimento:<asp:Label ID="Label1" runat="server" Text=""/></legend>
        <table>
        <tr>
            <td>
                 <asp:Label runat="server" ID="Label3" Text="Antes de enviar o seu autodiagnóstico você precisa concluir o preenchimento de todo o questionário. Visualize o resumo abaixo e responda as questões." />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Repeater id="cdcatalog" runat="server">
                    <ItemTemplate>
                        <b><%# DataBinder.Eval(Container.DataItem, "Questionario")%>:</b>
                        <table>
                            <tr>
                                <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem,"ListPergunta") %>'>
                                    <ItemTemplate>
                                        <td style="width:18px;text-align:center;border-color:Gray;border-style:solid;border-width:1px;background-color:<%# Vinit.SG.Common.FormatUtils.FormatCell(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta")))%>;"><a style="text-decoration:none;color:#000000;" href="RespondePerguntaQuestionario.aspx?IdQuestionario=<%# DataBinder.Eval(Container.DataItem, "QuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario")%>&IdQuestionarioEmpresa=<%# DataBinder.Eval(Container.DataItem, "QuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa")%>&IdEmpresaCadastro=<%# DataBinder.Eval(Container.DataItem, "QuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro")%>&IdTurma=<%# DataBinder.Eval(Container.DataItem, "QuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma")%>&IdPergunta=<%# DataBinder.Eval(Container.DataItem, "IdPergunta")%>"><%# DataBinder.Eval(Container.DataItem, "NumeroQuestao")%></a></td>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        </table>
</fieldset>
<fieldset>
        <legend>Envio do Questionário:<asp:Label ID="Label2" runat="server" Text=""/></legend>
        <table>
        <tr>
            <td colspan="4">
                <asp:Label runat="server" ID="LblJaEnviado" Text="O Questionário de Autoavaliação já foi enviado." />
                <asp:Label ID="LblEtapaDesabilitada" runat="server" Text="A etapa de inscrição via interface de digitador para este estado já se encontra encerrada." Visible="false"/>
                <asp:Label ID="LblEnviaQuestionario" Text="Para reenviar o questionário, selecione a opção: " runat="server" Font-Bold="true"/>
                <asp:Label ID="LblEnviaQuestionario2" Text="Para reenviar o questionário, selecione a opção: " runat="server" Font-Bold="true" Visible="false"/><br />
                <asp:ImageButton ImageUrl="/Image/_file_send2.png" ID="BtnEnviar" onclick="BtnEnviar_Click" runat="server" OnClientClick="javascript:return confirm('Confirma envio de questionário?');"/>
            </td>
        </tr>
        </table>
    </fieldset>
</asp:Content>
