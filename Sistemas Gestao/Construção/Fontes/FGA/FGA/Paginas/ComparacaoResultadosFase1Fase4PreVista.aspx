<%@ Page Title="Comparação Resultados Fase 1 e Fase 4, Pre-Vista" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="ComparacaoResultadosFase1Fase4PreVista.aspx.cs" Inherits="FGA.FGA.Paginas.ComparacaoResultadosFase1Fase4PreVista" %>

<%@ Register Src="/User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/User Controls/UCFiltroRanking.ascx" TagName="UCFiltroRanking"
    TagPrefix="uc2" %>
<%@ Register Src="~/MPE/User Control/UCJustificativaRanking.ascx" TagName="UCJustificativaRanking"
    TagPrefix="uc3" %>
<%@ Register src="~/User Controls/UCExportarPreClassificadas.ascx" tagname="UCExportarPreClassificadas" tagprefix="uc5" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
       <asp:Label ID="lblTitulo" runat="server" Text='Comparação Resultados Fase 1 e Fase 4, Pre-Vista'></asp:Label> 
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
    <fieldset id="Fieldset1" runat="server">
        <legend runat="server" id="TituloBoxSimplificado" visible="false">Lista de Empresas </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td colspan="2">
                    <div style="width: 911px; overflow: auto">
                            <asp:GridView ID="grdPreVisita" runat="server" AllowPaging="True" AllowSorting="True"
                                PageSize="15" Width="2000" AutoGenerateColumns="False" OnRowDataBound="grdPreVisita_RowDataBound"
                                OnRowCommand="grdPreVisita_RowCommand">
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
                                            <asp:Label ID="lblIdEmpresaCadastro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fase1.IdEmpresaCadastro")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IdQuestionarioEmpresa" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdQuestionarioEmpresa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fase1.IdQuestionarioEmpresa")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FlEtapaAtiva" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlEtapaAtiva" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fase1.EtapaAtiva")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FlPassaProximaEtapa" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlPassaProximaEtapa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fase1.PassaProximaFase")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IdEtapa" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdEtapa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fase1.IdEtapa")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CNPJ">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "Fase1.CpfCnpj")))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="180px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Razão Social" >
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Fase1.RazaoSocial")%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="250px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Liderança Fase 1 [15%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase1.CriterioLiderancaPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Liderança Fase 4 [15%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase4.CriterioLiderancaPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Gold" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Estratégias Fase 1 [9%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase1.CriterioEstrategiaPlanosPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estratégias Fase 4 [9%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase4.CriterioEstrategiaPlanosPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Gold" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cliente Fase 1 [9%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase1.CriterioClientePreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cliente Fase 4 [9%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase4.CriterioClientePreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Gold" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sociedade Fase 1 [6%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase1.CriterioSociedadePreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sociedade Fase 4 [6%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase4.CriterioSociedadePreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Gold" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Informações Fase 1 [6%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase1.CriterioInformacoesConhecimentoPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Informações Fase 4 [6%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase4.CriterioInformacoesConhecimentoPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Gold" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Pessoas Fase 1 [9%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase1.CriterioPessoasPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pessoas Fase 4 [9%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase4.CriterioPessoasPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Gold" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Processos Fase 1 [16%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase1.CriterioProcessosPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Processos Fase 4 [16%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase4.CriterioProcessosPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Gold" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Resultados Fase 1 [30%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase1.ResultadoControlePreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Resultados Fase 4 [30%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase4.ResultadoControlePreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px" BackColor="Gold" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Fase 1 [100%]">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase1.PontuacaoRankingPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Fase 4 [100%]" >
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "Fase4.PontuacaoRankingPreVisita"))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" BackColor="Gold" />
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>        
                        
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <uc3:UCJustificativaRanking ID="UCJustificativaRanking1" runat="server" />
    <uc5:UCExportarPreClassificadas ID="UCExportarPreClassificadas1" 
                runat="server" />
</asp:Content>

