<%@ Page Title="Número de Participantes por Etapa" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="RelNumParticipantesPorEtapa.aspx.cs" Inherits="Sistema_de_Gestao.FGA.Paginas.RelNumParticipantesInscritosEtapa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/User Controls/UCRelFiltroGeral.ascx" TagName="UCFiltro" TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Numero de Participantes por Etapa
    </h3>
    <fieldset style="width: 100%; font-size: 12px; white-space: nowrap;">
        <legend>Pesquisa </legend>
        <div id="filtro">
            <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <uc1:UCFiltro ID="UCFiltro1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                            OnClick="ImgBttnPesquisar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
        <tr>
            <td>
                <div id="Div1" runat="server" align="center" style="overflow: auto; width: 980px;display:none;">
                    <fieldset>
                        <legend>Empresas participantes do programa FGA por estado</legend>
                        <asp:GridView ID="grdEtapaEstado" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="27" CssClass="Text_grid" Width="100%" AutoGenerateColumns="false">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "Estado")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Autodiagnóstico Inicial">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAutodiagnosticoInicial" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container.DataItem, "QtdAutodiagnosticoInicial")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Indicadas para Visita">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIndicadas" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdIndicadasParaVisita")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliação Inicial" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvaliacaoInicial" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdAvaliacaoInicial")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selecionadas para o FGA" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSelecionadas" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdSelecionadasParaPrograma")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Autodiagnóstico Final" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAutodiagnosticoFinal" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdAutodiagnosticoFinal")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliação Final" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvaliacaoFinal" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdAvaliaçãoFinal")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </fieldset>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="Div2" runat="server" align="center" style="overflow: auto; width: 980px;display:none;">
                <fieldset>
                    <legend>Percentual das empresas por estado</legend>
                    <asp:Label ID="lblMsgGrafico1" runat="server" Font-Bold="True" Text="Nenhum registro encontrado para geração do grafico!"></asp:Label>
                    <br />
                    <asp:Chart ID="grafEstado" runat="server" Width="900px" Height="400px">
                        <Series>
                            <asp:Series ChartArea="chartarea1" Name="Autodiagnóstico Inicial" Legend="Legend1"
                                XValueMember="Estado" YValueMembers="PercEstadoAutodiagnosticoInicial">
                            </asp:Series>
                            <asp:Series ChartArea="chartarea1" Name="Indicadas para Visita" Legend="Legend1"
                                XValueMember="Estado" YValueMembers="PercEstadoIndicadasParaVisita">
                            </asp:Series>
                            <asp:Series ChartArea="chartarea1" Name="Avaliação Inicial" Legend="Legend1" XValueMember="Estado"
                                YValueMembers="PercEstadoAvaliacaoInicial">
                            </asp:Series>
                            <asp:Series ChartArea="chartarea1" Name="Selecionadas para o FGA" Legend="Legend1"
                                XValueMember="Estado" YValueMembers="PercEstadoSelecionadasParaPrograma">
                            </asp:Series>
                            <asp:Series ChartArea="chartarea1" Name="Autodiagnóstico Final" Legend="Legend1"
                                XValueMember="Estado" YValueMembers="PercEstadoAutodiagnosticoFinal">
                            </asp:Series>
                            <asp:Series ChartArea="chartarea1" Name="Avaliação Final" Legend="Legend1" XValueMember="Estado"
                                YValueMembers="PercEstadoAvaliaçãoFinal">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="chartarea1">
                                <AxisY IntervalAutoMode="VariableCount" Maximum="1" Minimum="0" Interval="0.1">
                                    <LabelStyle Format="p" />
                                </AxisY>
                                <AxisX IntervalAutoMode="FixedCount" Interval="1" />
                                <Area3DStyle Enable3D="True" Inclination="60" IsClustered="True" Rotation="40" WallWidth="10" />
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1">
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
                </fieldset>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="Div3" runat="server" align="center" style="overflow: auto; width: 980px;display:none;">
                    <fieldset>
                        <legend>Empresas participantes do programa FGA por categoria</legend>
                        <asp:GridView ID="grdCategoriaEtapa" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="27" CssClass="Text_grid" Width="100%" AutoGenerateColumns="false">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "Categoria")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Autodiagnóstico Inicial">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAutodiagnosticoInicial" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container.DataItem, "QtdAutodiagnosticoInicial")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Indicadas para Visita">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIndicadas" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdIndicadasParaVisita")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliação Inicial" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvaliacaoInicial" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdAvaliacaoInicial")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selecionadas para o FGA" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSelecionadas" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdSelecionadasParaPrograma")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Autodiagnóstico Final" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAutodiagnosticoFinal" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdAutodiagnosticoFinal")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliação Final" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvaliacaoFinal" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "QtdAvaliaçãoFinal")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </fieldset>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="Div4" runat="server" align="center" style="overflow: auto; width: 980px;display:none;">
                    <fieldset>
                        <legend>Percentual das empresas por categoria</legend>
                        <asp:Label ID="lblMsgGrafico" runat="server" Font-Bold="True" Text="Nenhum registro encontrado para geração do grafico!"></asp:Label>
                        <asp:Chart ID="grafCategoria" runat="server" Width="900px" Height="600px">
                            <Series>
                                <asp:Series ChartArea="chartarea1" Name="Autodiagnóstico Inicial" Legend="Legend1"
                                    XValueMember="Categoria" YValueMembers="PercCategoriaAutodiagnosticoInicial"
                                    XValueType="String">
                                    <EmptyPointStyle IsVisibleInLegend="False" />
                                </asp:Series>
                                <asp:Series ChartArea="chartarea1" Name="Indicadas para Visita" Legend="Legend1"
                                    XValueMember="Categoria" YValueMembers="PercCategoriaIndicadasParaVisita" XValueType="String">
                                    <EmptyPointStyle IsVisibleInLegend="False" />
                                </asp:Series>
                                <asp:Series ChartArea="chartarea1" Name="Avaliação Inicial" Legend="Legend1" XValueMember="Categoria"
                                    YValueMembers="PercCategoriaAvaliacaoInicial" XValueType="String">
                                    <EmptyPointStyle IsVisibleInLegend="False" />
                                </asp:Series>
                                <asp:Series ChartArea="chartarea1" Name="Selecionadas para o FGA" Legend="Legend1"
                                    XValueMember="Categoria" YValueMembers="PercCategoriaSelecionadasParaPrograma"
                                    XValueType="String">
                                    <EmptyPointStyle IsVisibleInLegend="False" />
                                </asp:Series>
                                <asp:Series ChartArea="chartarea1" Name="Autodiagnóstico Final" Legend="Legend1"
                                    XValueMember="Categoria" YValueMembers="PercCategoriaAutodiagnosticoFinal" XValueType="String">
                                    <EmptyPointStyle IsVisibleInLegend="False" />
                                </asp:Series>
                                <asp:Series ChartArea="chartarea1" Name="Avaliação Final" Legend="Legend1" XValueMember="Categoria"
                                    YValueMembers="PercCategoriaAvaliaçãoFinal" XValueType="String">
                                    <EmptyPointStyle IsVisibleInLegend="False" />
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="chartarea1">
                                    <AxisY IntervalAutoMode="VariableCount" Maximum="1" Minimum="0" Interval="0.1">
                                        <LabelStyle Format="p" />
                                    </AxisY>
                                    <Area3DStyle Enable3D="True" Inclination="60" IsClustered="True" Rotation="40" WallWidth="10" />
                                </asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                                <asp:Legend Name="Legend1">
                                </asp:Legend>
                            </Legends>
                        </asp:Chart>
                    </fieldset>
                </div>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
