<%@ Page Title="Classificada Estadual" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true"
    CodeBehind="RankingClassificadaEstadual.aspx.cs" Inherits="PEG.MPE.Paginas.RankingClassificadaEstadual" %>

<%@ Register Src="/User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/User Controls/UCFiltroRanking.ascx" TagName="UCFiltroRanking"
    TagPrefix="uc2" %>
<%@ Register Src="~/MPE/User Control/UCJustificativaRanking.ascx" TagName="UCJustificativaRanking"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Ranking Classificada Estadual
    </h3>
    <fieldset>
        <legend>Pesquisa </legend>
        <div id="filtro">
            <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <uc2:UCFiltroRanking ID="UCFiltroRanking1" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="ImgBttnPesquisar" OnClick="ImgBttnPesquisar_Click" runat="server"
                            ImageUrl="~/Image/file_search2.png" />
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <br />
    <fieldset style="width: 950px;" id="boxRanking" runat="server">
        <legend runat="server" id="TituloBoxSimplificado" visible="false">Lista de Empresas
            Simplificado</legend><legend runat="server" id="TituloBoxDetalhado" visible="false">
                Lista de Empresas Detalhado</legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td colspan="2">
                    <div style="width: 929px; overflow: auto">
                        <asp:GridView ID="grdRanking" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grdRanking_RowDataBound"
                            OnRowCommand="grdRanking_RowCommand">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                Não existem dados*
                            </EmptyDataTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="IdEmpresaCadastro" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEmpresaCadastro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEmpresaCadastro")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdQuestionarioEmpresa" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQuestionarioEmpresa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdQuestionarioEmpresa")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FlEtapaAtiva" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlEtapaAtiva" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EtapaAtiva")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdEtapa" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEtapa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEtapa")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Protocolo" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProtocolo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Protocolo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Finalista">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnFinalista" runat="server" CommandName="FinalistaGestao"
                                            CommandArgument="<%# Container.DataItemIndex %>"
                                            ImageUrl="~/Image/_file_download2.png" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Devolver Para Avaliador">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnDevolver" runat="server" CommandName="Devolver" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdQuestionarioEmpresa")%>'
                                            ImageUrl="~/Image/_file_download2.png" />
                                        <asp:Label ID="lblParaAvaliacao" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ParaAvaliacao")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ranking">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRanking" runat="server" Text="0"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CPF/CNPJ">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CpfCnpj")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Razão Social">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Total">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoTotalPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Cliente">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioClientePosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Sociedade">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioSociedadePosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Liderança">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioLiderancaPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Estratégias e Planos">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlanosPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Pessoas">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioPessoasPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Processos">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioProcessosPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Informações e Conhecimento">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioInformacoesConhecimentoPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Enfoque">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EnfoquePosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Resultados(Controle)">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "ResultadoControlePosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Resultados(Tendência)">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "ResultadoTendenciaPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Empreendedorismo">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "TotalEmpreendendorismoPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Relação com Melhor da Categoria">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "RelacaoMelhorCategoriaPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Ranking">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoRankingPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Cliente">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioClientePreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Sociedade">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioSociedadePreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Liderança">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioLiderancaPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Estratégias e Planos">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlanosPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Pessoas">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioPessoasPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Processos">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioProcessosPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Informações e Conhecimento">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioInformacoesConhecimentoPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Enfoque">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EnfoquePreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Resultados(Controle)">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "ResultadoControlePreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Resultados(Tendência)">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "ResultadoTendenciaPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Total">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoTotalPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Relação com Melhor da Categoria">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "RelacaoMelhorCategoriaPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Responsabilidade Social">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnFinalistaResponsabilidadeSocial" runat="server" CommandName="FinalistaResponsabilidadeSocial"
                                            CommandArgument="<%# Container.DataItemIndex %>"
                                            ImageUrl="~/Image/_file_download2.png" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inovação">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnFinalistaInovacao" runat="server" CommandName="FinalistaInovacao"
                                            CommandArgument="<%# Container.DataItemIndex %>"
                                            ImageUrl="~/Image/_file_download2.png" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RAA">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnDownload" runat="server" ImageUrl="~/Image/_file_download2.png"
                                            CommandName="Download" CausesValidation="false" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <uc3:UCJustificativaRanking ID="UCJustificativaRanking1" runat="server" />
</asp:Content>
