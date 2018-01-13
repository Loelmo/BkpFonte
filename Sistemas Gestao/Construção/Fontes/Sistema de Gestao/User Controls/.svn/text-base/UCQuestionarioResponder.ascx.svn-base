<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCQuestionarioResponder.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCQuestionarioResponder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="/User Controls/Avaliacao/UCAdministrativoEmpreendedorismo.ascx" TagName="UCAdministrativoEmpreendedorismo" TagPrefix="uc1" %>
<%@ Register Src="/User Controls/Avaliacao/UCAdministrativoGestao.ascx" TagName="UCAdministrativoGestao" TagPrefix="uc2" %>
<%@ Register Src="/User Controls/Avaliacao/UCAdministrativoGestao2011.ascx" TagName="UCAdministrativoGestao2011" TagPrefix="uc3" %>
<%@ Register Src="/User Controls/Avaliacao/UCAdministrativoInovacao.ascx" TagName="UCAdministrativoInovacao" TagPrefix="uc4" %>
<%@ Register Src="/User Controls/Avaliacao/UCAdministrativoResponsabilidadeSocial.ascx" TagName="UCAdministrativoResponsabilidadeSocial" TagPrefix="uc5" %>
<%@ Register Src="/User Controls/Avaliacao/UCAdministrativoResponsabilidadeSocial2011.ascx" TagName="UCAdministrativoResponsabilidadeSocial2011" TagPrefix="uc6" %>

<div id="divUserControl" runat="server" visible="false" valign="middle" align="center" 
    style="background-image: url('/Image/BGLocked.png'); width: 950px; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px;">
    <asp:Panel ID="PnlFundo" runat="server" Width="950px" Style="position: relative; top: 10%;" BackColor="White" BorderColor="Black" BorderStyle="Outset" BorderWidth="1">
        <asp:HiddenField ID="HddnFldIdQuestionarioEmpresa" runat="server" />
        <uc1:UCAdministrativoEmpreendedorismo ID="UCAdministrativoEmpreendedorismo1" runat="server" Visible="false"/>
        <uc2:UCAdministrativoGestao ID="UCAdministrativoGestao1" runat="server" Visible="false"/>
        <uc3:UCAdministrativoGestao2011 ID="UCAdministrativoGestao20111" runat="server" Visible="false"/>
        <uc4:UCAdministrativoInovacao ID="UCAdministrativoInovacao1" runat="server" Visible="false"/>
        <uc5:UCAdministrativoResponsabilidadeSocial ID="UCAdministrativoResponsabilidadeSocial1" runat="server" Visible="false"/>
        <uc6:UCAdministrativoResponsabilidadeSocial2011 ID="UCAdministrativoResponsabilidadeSocial20111" runat="server" Visible="false"/>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png"
                OnClick="ImgBttnGravar_Click" OnClientClick="javascript:return verificaComentariosAvaliador();" />
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click" />
        </div>
    </asp:Panel>
</div>
