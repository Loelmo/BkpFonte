<%@ Page Title="Classificada Estadual" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true"
    CodeBehind="RankingClassificadaEstadual.aspx.cs" Inherits="Sistema_de_Gestao.MPE.Paginas.RankingClassificadaEstadual" %>
<%@ Register Src="/User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/User Controls/UCFiltroRanking.ascx" TagName="UCFiltroRanking"
    TagPrefix="uc2" %>
<%@ Register Src="~/MPE/User Control/UCJustificativaRanking.ascx" TagName="UCJustificativaRanking"
    TagPrefix="uc3" %>
<%@ Register src="~/User Controls/UCExportarClassificadas.ascx" tagname="UCExportarClassificadas" tagprefix="uc5" %>
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
    <fieldset id="boxRanking" runat="server">
        <legend runat="server" id="TituloBoxSimplificado" visible="false">Lista de Empresas
            Simplificado</legend><legend runat="server" id="TituloBoxDetalhado" visible="false">
                Lista de Empresas Detalhado</legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td align="right" colspan="2">
                    <asp:ImageButton ID="ImgBttnExportar" runat="server" 
                        ImageUrl="~/Image/_file_export2.png" Visible="false" 
                        onclick="ImgBttnExportar_Click"/>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <div runat="server" id="divLegenda" visible="false">
                        <table>
                            <tr>
                                <td style="width:15px;background-color:#FFFFB5;">
                                </td>
                                <td> Empresas que selecionaram A ou B nas Questões Especiais
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="width: 911px; overflow: auto">
                        <asp:GridView ID="grdRanking" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" Width="1500" AutoGenerateColumns="False" OnRowDataBound="grdRanking_RowDataBound"
                            OnRowCommand="grdRanking_RowCommand">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
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
                                <asp:TemplateField HeaderText="FlPassaProximaEtapa" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlPassaProximaEtapa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassaProximaFase")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdEtapa" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEtapa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEtapa")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CPF/CNPJ">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CpfCnpj")))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Razão Social">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="250px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Protocolo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProtocolo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Protocolo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="220px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aderiu ao FGA">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnFinalista" runat="server" CommandName="FinalistaGestao"
                                            CommandArgument="<%# Container.DataItemIndex %>"
                                            ImageUrl="~/Image/_file_download2.png" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Devolver Para Consultor">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnDevolver" runat="server" CommandName="Devolver" CommandArgument="<%# Container.DataItemIndex %>"
                                            ImageUrl="~/Image/_file_download2.png" />
                                        <asp:Label ID="lblParaAvaliacao" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ParaAvaliacao")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RAA">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnDownloadRaa" runat="server" ImageUrl="~/Image/_file_download2.png"
                                            CommandName="Download" CausesValidation="false" CommandArgument='<%# Container.DataItemIndex %>'/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RA">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnDownloadRa" runat="server" ImageUrl="~/Image/_file_download2.png"
                                            CommandName="DownloadRa" CausesValidation="false" CommandArgument='<%# Container.DataItemIndex %>'/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ranking">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRanking" runat="server" Text="0"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Desistente">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChckBxDesclassificar" runat="server" Visible="false" Checked='<%# Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "Excluido"))%>'/>
                                        <asp:ImageButton ID="imgBttnDesclassificar" runat="server" CommandName="Desclassificar" CommandArgument="<%# Container.DataItemIndex %>"/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selecionou A ou B nas Questões Especiais?">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMarcaQuestoesEspeciais" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatBoolean(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "MarcaQuestoesEspeciais")))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Total [100%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double) DataBinder.Eval(Container.DataItem, "PontuacaoTotalPosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Liderança [15%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioLiderancaPosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Estratégias e Planos [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlanosPosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Cliente [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioClientePosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Sociedade [6%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioSociedadePosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Informações e Conhecimento [6%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioInformacoesConhecimentoPosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Pessoas [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioPessoasPosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Processos [16%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioProcessosPosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Enfoque [70%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "EnfoquePosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RA Resultados [30%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "ResultadoControlePosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Relação com Melhor da Turma RA">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "RelacaoMelhorCategoriaPosVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Total [100%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "PontuacaoRankingPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Empreendedorismo">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "TotalEmpreendendorismoPosVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Liderança [15%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioLiderancaPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Estratégias e Planos [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlanosPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Cliente [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioClientePreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Sociedade [6%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioSociedadePreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Informações e Conhecimento [6%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioInformacoesConhecimentoPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Pessoas [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioPessoasPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Processos [16%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioProcessosPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Enfoque [70%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "EnfoquePreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Resultados [30%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "ResultadoControlePreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação RAA Total [100%]" Visible="false">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "PontuacaoTotalPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Relação com Melhor da Turma RAA">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "RelacaoMelhorCategoriaPreVisita"))%>
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
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <uc3:UCJustificativaRanking ID="UCJustificativaRanking1" runat="server" />
    <uc5:UCExportarClassificadas ID="UCExportarClassificadas1" 
                runat="server" />
</asp:Content>
