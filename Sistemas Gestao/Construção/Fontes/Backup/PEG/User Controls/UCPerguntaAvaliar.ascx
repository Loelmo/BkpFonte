<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaAvaliar.ascx.cs"
    Inherits="PEG.User_Controls.UCPerguntaAvaliar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="/User Controls/Avaliacao/UCPerguntaEspecialGestao31.ascx" TagName="UCPerguntaEspecialGestao31" TagPrefix="uc4" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaMultiplaEscolha4Opcoes.ascx" TagName="UCPerguntaMultiplaEscolha4Opcoes" TagPrefix="uc5" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaSimNao.ascx" TagName="UCPerguntaSimNao" TagPrefix="uc6" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaTexto.ascx" TagName="UCPerguntaTexto" TagPrefix="uc7" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaEspecialResponsabilidadeSocial1.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial1" TagPrefix="uc8" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaEspecialResponsabilidadeSocial6.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial6" TagPrefix="uc9" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaMultiplaEscolha3Opcoes.ascx" TagName="UCPerguntaMultiplaEscolha3Opcoes" TagPrefix="uc10" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaEspecialGestao32.ascx" TagName="UCPerguntaEspecialGestao32" TagPrefix="uc11" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaEspecialResponsabilidadeSocial3.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial3" TagPrefix="uc12" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaEspecialResponsabilidadeSocial7a.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial7a" TagPrefix="uc13" %>
<%@ Register Src="/User Controls/Avaliacao/UCPerguntaEspecialResponsabilidadeSocial8b.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial8b" TagPrefix="uc14" %>

<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px;">
    <asp:Panel ID="PnlFundo" runat="server" Width="910px" BackColor="White" BorderColor="Black"
        BorderStyle="Outset" BorderWidth="1" Style="position: relative; top: 10%;">
        <asp:HiddenField ID="HddnFldIdPergunta" runat="server" />
        <asp:HiddenField ID="HddnFldIdTipoPergunta" runat="server" />
        <asp:HiddenField ID="HddnFldIdQuestionarioEmpresa" runat="server" />
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;"><asp:Label ID="LblTituloPergunta" runat="server"></asp:Label> </legend>
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0">
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="PnlQuestionario" runat="server">
                            <uc4:UCPerguntaEspecialGestao31 ID="UCPerguntaEspecialGestao311" runat="server" Visible="false"/>
                            <uc5:UCPerguntaMultiplaEscolha4Opcoes ID="UCPerguntaMultiplaEscolha4Opcoes1" runat="server" Visible="false"/>
                            <uc6:UCPerguntaSimNao ID="UCPerguntaSimNao1" runat="server" Visible="false"/>
                            <uc7:UCPerguntaTexto ID="UCPerguntaTexto1" runat="server" Visible="false"/>
                            <uc8:UCPerguntaEspecialResponsabilidadeSocial1 ID="UCPerguntaEspecialResponsabilidadeSocial11" runat="server" Visible="false"/>
                            <uc9:UCPerguntaEspecialResponsabilidadeSocial6 ID="UCPerguntaEspecialResponsabilidadeSocial61" runat="server" Visible="false"/>
                            <uc10:UCPerguntaMultiplaEscolha3Opcoes ID="UCPerguntaMultiplaEscolha3Opcoes1" runat="server" Visible="false"/>
                            <uc11:UCPerguntaEspecialGestao32 ID="UCPerguntaEspecialGestao32_1" runat="server" Visible="false"/>
                            <uc12:UCPerguntaEspecialResponsabilidadeSocial3 ID="UCPerguntaEspecialResponsabilidadeSocial3_1" runat="server" Visible="false"/>
                            <uc13:UCPerguntaEspecialResponsabilidadeSocial7a ID="UCPerguntaEspecialResponsabilidadeSocial7a_1" runat="server" Visible="false"/>
                            <uc14:UCPerguntaEspecialResponsabilidadeSocial8b ID="UCPerguntaEspecialResponsabilidadeSocial8b_1" runat="server" Visible="false"/>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;">Pontos Fortes: </legend>
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td width="10%" align="right">
                        <asp:TextBox ID="TxtPontoForte" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;">Oportunidades de Melhoria: </legend>
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td width="10%" align="right">
                        <asp:TextBox ID="TxtOportunidade" Rows="5" TextMode="MultiLine" runat="server" Width="99%" Font-Names="Arial" Font-Size="12px"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png"
                OnClick="ImgBttnGravar_Click" OnClientClick="javascript:return verificaComentariosAvaliador();" />
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click" />
        </div>
    </asp:Panel>
</div>
