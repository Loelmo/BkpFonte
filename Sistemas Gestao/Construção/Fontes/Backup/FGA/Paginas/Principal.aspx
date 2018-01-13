<%@ Page Title="Sistemas de Gestão" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.Principal" %>

<%@ Register Src="/User Controls/UCListagemNoticia.ascx" TagName="UCListagemNoticia" TagPrefix="uc1" %>
<%@ Register Src="/User Controls/UCListagemArquivo.ascx" TagName="UCListagemArquivo" TagPrefix="uc2" %>

<%@ Register src="../User Controls/UCStatus.ascx" tagname="UCStatus" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc3:UCStatus ID="UCStatus1" runat="server" />
<div style="font-family: Arial, Helvetica, sans-serif;font-size:11px;margin-left:55px;">
<asp:Label ID="Label1" runat="server" />
<asp:Label ID="LblTitulo1" runat="server" />
 <br />
</div>
<div style="font-family: Arial, Helvetica, sans-serif;font-size:11px;margin-left:55px;">
<asp:Label ID="LblDescricao1" runat="server" />
 <br /><br />
<asp:Label ID="LblDescricao2" runat="server" />
<br />
<br />
<asp:Button ID="Button1" runat="server" OnClick="BtnFase1_Click" Text="Objetivo do Programa" CssClass="botaoFase"/>
<div id="texto1" runat="server" visible="false">
O propósito maior do programa é que empresários como você desenvolvam, de fato, não apenas o pensamento estratégico, mas também a prática do estabelecimento de estratégias para suas empresas, de modo a direcioná-las e guiá-las para tomar decisões mais acertadas, que sejam fruto da reflexão, pesquisa e conhecimento de seu ambiente de atuação.
</div>
<br />
<asp:Button ID="Button2" runat="server" OnClick="BtnFase2_Click" Text="Para quem é destinado o Programa?" CssClass="botaoFase"/>
<div id="texto2" runat="server" visible="false">
O programa é destinado para empresas avançadas:
<br />
• Que já tenham ultrapassado a fase inicial de estabelecimento no mercado. Tenham dois ou mais anos de vida e acima de 9 funcionários.
<br />
• Que já tenham suprida sua necessidade de instrumentos básicos de gestão nas áreas financeira, de recursos humanos, marketing e vendas, e operações/processos.
<br />
• Que tenham estrutura gerencial e operacional de maior sofisticação na gestão, como: atividades departamentalizadas, funcionários alocados para cada função, etc.
<br />
• Que tenham determinado como objetivo estratégico a mudança de patamar, buscando forte evolução no seu crescimento e nos seus resultados.
<br />
• Que busquem a implementação de modelos avançados de gestão empresarial ou uma substancial evolução dos modelos existentes nas empresas.
<br />
• Em que exista um forte enfoque na melhoria de resultados.
</div>
<br />
<asp:Button ID="Button3" runat="server" OnClick="BtnFase3_Click" Text="Conheça os benefícios em participar" CssClass="botaoFase"/>
<div id="texto3" runat="server" visible="false">
Com este programa, você poderá: 
<br />
<br />
• Melhorar o desempenho da empresa, impulsionando o crescimento e a obtenção de resultados diferenciados;
<br />
• Implantar modelos avançados de gestão empresarial;
<br />
• Acompanhar sistematicamente os indicadores e as metas do plano empresarial.
</div>
<br />
<asp:Button ID="Button4" runat="server" OnClick="BtnFase4_Click" Text="Saiba como funciona o Programa" CssClass="botaoFase"/>
<div id="texto4" runat="server" visible="false">
• Fase 1 - Diagnóstico Empresarial - duas semanas
<br />
• Fase 2 - Plano Empresarial - prazo previsto - dois meses
<br />
• Fase 3 - Gestão do Resultado - prazo previsto - oito meses
<br />
• Fase 4 - Novo Ciclo do Plano Empresarial - prazo previsto - dois meses
<br />
• 127 horas de consultoria em cada empresa participante do programa
<br />
• 76 horas em workshops 
<br />
• 8 horas em encontros empresariais
<br />
• Total de 211 horas
<br />
<br />
<asp:Image ID="ImageFases" ImageUrl="~/Image/Fga/Fases.png" runat="server" />
</div>
<br />
<br />
<asp:Label Text="Para iniciar, clique na seta 'Preencher Cadastro'." ID="LblSetaCadastro" runat="server"></asp:Label>
    <div id="divSetasEmpresa" runat="server" style="display:block;">
        <br />
        <br />
        As setas acima indicam a sequência de passos para finalizar o processo: 
        <br />
        Em verde - passo concluído. 
        <br />
        Em azul - passo em andamento. 
        <br />
        Em vermelho - passo pendente. 
        <br />
        Em cinza - passo ainda não disponível.
    </div>
</div>
</asp:Content>
