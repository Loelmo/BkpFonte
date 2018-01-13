<%@ Page Title="Comparativo de Questões Especiais" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="RelatorioQuestoesEspeciais.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.RelatorioQuestoesEspeciais" %>

<%@ Register Src="/User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/User Controls/UCFiltroRanking.ascx" TagName="UCFiltroRanking"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        <asp:Label ID="lblTitulo" runat="server" Text='Ranking Candidata Estadual'></asp:Label>
    </h3>
    <fieldset>
        <legend>Pesquisa </legend>
        <uc2:UCFiltroRanking ID="UCFiltroRanking1" runat="server" EtapaRanking="Candidata"
            IsEstadual="True" />
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                OnClick="ImgBttnPesquisar_Click" />
        </div>
    </fieldset>
    <fieldset id="RankingSimplificado">
        <legend runat="server" id="TituloBoxSimplificado" visible="false">Lista de Empresas
            Simplificada</legend><legend runat="server" id="TituloBoxDetalhado" visible="false">
                Lista de Empresas Detalhada</legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td colspan="2">
                    <div style="width: 911px; overflow: auto">
                        <asp:GridView ID="grdSimplificado" runat="server" AllowPaging="True" AllowSorting="True" OnRowCommand="grdSimplificado_RowCommand"
                            PageSize="15" Width="2000" AutoGenerateColumns="False" OnRowDataBound="grdSimplificado_RowDataBound"
                            OnPageIndexChanging="grdSimplificado_PageIndexChanging" DataKeyNames="IdQuestionarioEmpresa">
                            <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="CNPJ">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CpfCnpj")))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Razão Social">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Protocolo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProtocolo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Protocolo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="350px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RAA">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnDownload" runat="server" ImageUrl="~/Image/_file_download2.png"
                                            CommandName="Download" CausesValidation="false" CommandArgument='<%# Container.DataItemIndex %>'/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pergunta 9">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatLetraQuestao((Int32)DataBinder.Eval(Container.DataItem, "RespostaQuestao9"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pergunta 10">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatLetraQuestao((Int32)DataBinder.Eval(Container.DataItem, "RespostaQuestao10"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pergunta 11">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatLetraQuestao((Int32)DataBinder.Eval(Container.DataItem, "RespostaQuestao11"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pergunta 16">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatLetraQuestao((Int32)DataBinder.Eval(Container.DataItem, "RespostaQuestao16"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pergunta 20">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatLetraQuestao((Int32)DataBinder.Eval(Container.DataItem, "RespostaQuestao20"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pergunta 23">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatLetraQuestao((Int32)DataBinder.Eval(Container.DataItem, "RespostaQuestao23"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pergunta 31">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatLetraQuestao((Int32)DataBinder.Eval(Container.DataItem, "RespostaQuestao31"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Questões Especiais [16,35%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "PontuacaoQuestoesEspeciais"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ranking Questões Especiais" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRankingQuestoesEspeciais" runat="server" Text="0"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Liderança [15%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioLideranca"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Estratégias e Planos [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlanos"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Cliente [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioCliente"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Sociedade [6%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioSociedade"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Informações e Conhecimento [6%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioInformacoesConhecimento"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Pessoas [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioPessoas"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Processos [16%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioProcessos"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Resultados [30%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioResultado"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Total [100%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "PontuacaoTotal"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ranking">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRanking" runat="server" Text="0"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
