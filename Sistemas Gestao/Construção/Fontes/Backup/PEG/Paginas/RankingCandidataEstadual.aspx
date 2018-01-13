<%@ Page Title="Candidatas" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="RankingCandidataEstadual.aspx.cs" Inherits="PEG.Paginas.RankingCandidataEstadual" %>

<%@ Register Src="/User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="../User Controls/UCFiltroRanking.ascx" TagName="UCFiltroRanking"
    TagPrefix="uc2" %>
<%@ Register Src="~/PEG/User Control/UCJustificativaRanking.ascx" TagName="UCJustificativaRanking"
    TagPrefix="uc3" %>
<%@ Register Src="~/PEG/User Control/UCVisualizarAutodiagnosticoInicial.ascx" TagName="UCVisualizarAutodiagnosticoInicial"
    TagPrefix="uc4" %>
<%@ Register src="../User Controls/UCExportarCandidataEstadual.ascx" tagname="UCExportarCandidataEstadual" tagprefix="uc5" %>
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
            Simplificado</legend><legend runat="server" id="TituloBoxDetalhado" visible="false">
                Lista de Empresas Detalhado</legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td align="right">
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
                            <tr>
                                <td style="width:15px;background-color:#FC8879;">
                                </td>
                                <td> Empresas não elegíveis a participar do Processo de Avaliação
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="width: 911px; overflow: auto">
                        <asp:GridView ID="grdSimplificado" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" Width="1500" AutoGenerateColumns="False" OnRowDataBound="grdSimplificado_RowDataBound"
                            OnPageIndexChanging="grdSimplificado_PageIndexChanging" DataKeyNames="IdQuestionarioEmpresa,Classificar"
                            OnRowCommand="grdSimplificado_RowCommand" OnRowUpdating="grdSimplificado_RowUpdating">
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
                                <asp:TemplateField HeaderText="IdEmpresaCadastro" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEmpresaCadastro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEmpresaCadastro")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdQuestionarioEmpresa" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQuestionarioEmpresa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdQuestionarioEmpresa")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FlEtapaAtiva" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlEtapaAtiva" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EtapaAtiva")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FlDesclassificado" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlDesclassificado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Excluido")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdEtapa" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEtapa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEtapa")%>'></asp:Label>
                                        <asp:Label ID="lblIdFaturamento" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdFaturamento")%>'></asp:Label>
                                        <asp:Label ID="lblJaAvaliada" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JaAvaliada")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdEstado" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEstado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEstado")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliadores" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdAvaliadorSenior" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdAvaliadorSenior")%>'></asp:Label>
                                        <asp:Label ID="lblIdAvaliadorAcompanhante" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdAvaliadorAcompanhante")%>'></asp:Label>
                                        <asp:Label ID="lblNomeAvaliadorSenior" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NomeAvaliadorSenior")%>'></asp:Label>
                                        <asp:Label ID="lblNomeAvaliadorAcompanhante" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NomeAvaliadorAcompanhante")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CPF/CNPJ">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CpfCnpj")))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" />
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
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pré-Classificar">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChckBxClassificar" runat="server" Visible="false" Checked='<%# Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "Classificar"))%>'/>
                                        <asp:ImageButton ID="ImgBttnClassificar" runat="server" CommandName="Update" CommandArgument="<%# Container.DataItemIndex %>"/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliador">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DrpDwnLstSenior" runat="server" Width="150" DataValueField="IdUsuario"
                                            DataTextField="Usuario">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DrpDwnLstAcompanhante" runat="server" Width="150" DataValueField="IdUsuario"
                                            DataTextField="Usuario">
                                        </asp:DropDownList>
                                        <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png"
                                            CommandName="Gravar" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RAA">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnDownload" runat="server" ImageUrl="~/Image/_file_download2.png"
                                            CommandName="Download" CausesValidation="false" CommandArgument='<%# Container.DataItemIndex %>'/>
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
                                <asp:TemplateField HeaderText="Pontuação Ranking [100%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "PontuacaoTotalPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Enfoque [70%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "EnfoquePreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Resultados [30%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "ResultadoControlePreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Relação com melhor da Turma">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "RelacaoMelhorCategoriaPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Liderança [15%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioLiderancaPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Estratégias e Planos [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlanosPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Cliente [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioClientePreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Sociedade [6%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioSociedadePreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Informações e Conhecimento [6%]" Visible="false">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioInformacoesConhecimentoPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Pessoas [9%]">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioPessoasPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Processos [16%]" Visible="false">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioProcessosPreVisita"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <uc3:UCJustificativaRanking ID="UCJustificativaRanking1" runat="server" />
    <uc4:UCVisualizarAutodiagnosticoInicial ID="UCVisualizarAutodiagnosticoInicial1"
        runat="server" />
    <uc5:UCExportarCandidataEstadual ID="UCExportarCandidataEstadual1" 
                runat="server" />
</asp:Content>
