<%@ Page Title="Sistemas de Gestão" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="RespondePerguntaQuestionario.aspx.cs" Inherits="PEG.Paginas.Empresa.RespondePerguntaQuestionario" %>

    <%@ Register Src="/User Controls/Questionario/UCAdministrativoEmpreendedorismo.ascx" TagName="UCAdministrativoEmpreendedorismo" TagPrefix="uc1" %>
    <%@ Register Src="/User Controls/Questionario/UCAdministrativoGestao.ascx" TagName="UCAdministrativoGestao" TagPrefix="uc2" %>
    <%@ Register Src="/User Controls/Questionario/UCAdministrativoResponsabilidadeSocial.ascx" TagName="UCAdministrativoResponsabilidadeSocial" TagPrefix="uc3" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaEspecialGestao31.ascx" TagName="UCPerguntaEspecialGestao31" TagPrefix="uc4" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaMultiplaEscolha4Opcoes.ascx" TagName="UCPerguntaMultiplaEscolha4Opcoes" TagPrefix="uc5" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaSimNao.ascx" TagName="UCPerguntaSimNao" TagPrefix="uc6" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaTexto.ascx" TagName="UCPerguntaTexto" TagPrefix="uc7" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaEspecialResponsabilidadeSocial1.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial1" TagPrefix="uc8" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaEspecialResponsabilidadeSocial6.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial6" TagPrefix="uc9" %>
    <%@ Register Src="/User Controls/Questionario/UCAdministrativoGestao2011.ascx" TagName="UCAdministrativoGestao2011" TagPrefix="uc10" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaEspecialGestao32.ascx" TagName="UCPerguntaEspecialGestao32" TagPrefix="uc11" %>
    <%@ Register Src="/User Controls/Questionario/UCAdministrativoInovacao.ascx" TagName="UCAdministrativoInovacao" TagPrefix="uc12" %>
    <%@ Register Src="/User Controls/Questionario/UCAdministrativoResponsabilidadeSocial2011.ascx" TagName="UCAdministrativoResponsabilidadeSocial2011" TagPrefix="uc13" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaEspecialResponsabilidadeSocial3.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial3" TagPrefix="uc14" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaEspecialResponsabilidadeSocial7a.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial7a" TagPrefix="uc15" %>
    <%@ Register Src="/User Controls/Questionario/UCPerguntaEspecialResponsabilidadeSocial8b.ascx" TagName="UCPerguntaEspecialResponsabilidadeSocial8b" TagPrefix="uc16" %>

    <%@ Register src="../../User Controls/UCStatus.ascx" tagname="UCStatus" tagprefix="uc17" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc17:UCStatus ID="UCStatus1" runat="server" />
    <fieldset style="margin-left:-30px;">
        <legend><asp:Label ID="lblNomeQuestionario" runat="server" />
            
        </legend>
        <table>
        <tr>
        <asp:Panel ID="PnlQuestionario" runat="server">
            <uc1:UCAdministrativoEmpreendedorismo ID="UCAdministrativoEmpreendedorismo1" runat="server" Visible="false"/>
            <uc2:UCAdministrativoGestao ID="UCAdministrativoGestao1" runat="server"  Visible="false"/>
            <uc3:UCAdministrativoResponsabilidadeSocial ID="UCAdministrativoResponsabilidadeSocial1" runat="server"  Visible="false"/>
            <uc4:UCPerguntaEspecialGestao31 ID="UCPerguntaEspecialGestao311" runat="server"  Visible="false"/>
            <uc5:UCPerguntaMultiplaEscolha4Opcoes ID="UCPerguntaMultiplaEscolha4Opcoes1" runat="server"  Visible="false"/>
            <uc6:UCPerguntaSimNao ID="UCPerguntaSimNao1" runat="server"  Visible="false"/>
            <uc7:UCPerguntaTexto ID="UCPerguntaTexto1" runat="server"  Visible="false"/>
            <uc8:UCPerguntaEspecialResponsabilidadeSocial1 ID="UCPerguntaEspecialResponsabilidadeSocial11" runat="server"  Visible="false"/>
            <uc9:UCPerguntaEspecialResponsabilidadeSocial6 ID="UCPerguntaEspecialResponsabilidadeSocial61" runat="server"  Visible="false"/>
            <uc10:UCAdministrativoGestao2011 ID="UCAdministrativoGestao2011_1" runat="server"  Visible="false"/>
            <uc11:UCPerguntaEspecialGestao32 ID="UCPerguntaEspecialGestao32_1" runat="server"  Visible="false"/>
            <uc12:UCAdministrativoInovacao ID="UCAdministrativoInovacao1" runat="server"  Visible="false"/>
            <uc13:UCAdministrativoResponsabilidadeSocial2011 ID="UCAdministrativoResponsabilidadeSocial2011_1" runat="server"  Visible="false"/>
            <uc14:UCPerguntaEspecialResponsabilidadeSocial3 ID="UCPerguntaEspecialResponsabilidadeSocial3_1" runat="server"  Visible="false"/>
            <uc15:UCPerguntaEspecialResponsabilidadeSocial7a ID="UCPerguntaEspecialResponsabilidadeSocial7a_1" runat="server"  Visible="false"/>
            <uc16:UCPerguntaEspecialResponsabilidadeSocial8b ID="UCPerguntaEspecialResponsabilidadeSocial8b_1" runat="server"  Visible="false"/>
        </asp:Panel>
        </tr>
        </table>
    </fieldset>
</asp:Content>
