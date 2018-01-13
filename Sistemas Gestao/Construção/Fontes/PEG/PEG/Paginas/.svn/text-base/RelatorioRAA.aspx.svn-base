<%@ Page Title="Relatórios de Autoavaliação" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="RelatorioRAA.aspx.cs" Inherits="PEG.RelatorioRAA" %>
<%@ Register Src="~/User Controls/UCConfirmaEmail.ascx" TagName="UCConfirmaEmail" TagPrefix="uc1" %>

<%@ Register src="../../User Controls/UCStatus.ascx" tagname="UCStatus" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function WindowOpen(url) {
            window.open(url);
        }


    </script>

<div align="center">
    <uc2:UCStatus ID="UCStatus1" runat="server" />
</div>
<fieldset>
        <legend>Histórico de Relatórios da Empresa</legend>
    <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
        <tr>
            <td>
                <span>Acompanhe abaixo a evolução das práticas de gestão da sua empresa, em cada um dos oito Critérios do Modelo de Excelência da Gestão (MEG®).</span><br />
                <span>A avaliação permanente da sua empresa auxiliará na melhoria contínua das suas práticas de gestão.</span><br />
                <span>Verifique a data de envio e clique no” Visualizar” ou “Enviar por e-mail” para emitir o Relatório.</span><br /><br />
            </td>
        </tr>
        <tr>
            <td>
                <div align="center" style="overflow:auto; height:100%; width: 911px">
                    <asp:GridView ID="grdRelatorioRAA" runat="server" AllowPaging="True" AllowSorting="True"
                        PageSize="10" Width="1500px" AutoGenerateColumns="False" OnPageIndexChanging="grdRelatorioRAA_PageIndexChanging"
                        OnRowDataBound="grdRelatorioRAA_RowDataBound" OnRowCommand="grdRelatorioRAA_RowCommand">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                        <EmptyDataTemplate>
                            <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font></EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImagBttnDownload" runat="server" ImageUrl="~/Image/_file_download2.png" CommandName="Download" CommandArgument='<%# Container.DataItemIndex %>'
                                        CausesValidation="false" />
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Visualizar</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImagBttnEnviarEmail" runat="server" ImageUrl="~/Image/_file_mail2.png" CommandName="Email" CommandArgument="<%# Container.DataItemIndex %>"
                                        CausesValidation="false" />
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Enviar por Email</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de Relatório">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoRelatorio" runat="server"></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>Tipo de Relatório</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ano">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Ano")%>
                                </ItemTemplate>
                                <HeaderTemplate>Ano</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Envio">
                                <ItemTemplate>
                                    <%#  DataBinder.Eval(Container.DataItem, "DataEnvio") %>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Data Envio
                                </HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioLideranca")) %>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Liderança<br />
                                    [15,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlano"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Estratégias e Planos<br />
                                    [9,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                     <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioCliente"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Clientes<br />
                                    [9,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioSociedade"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Sociedade<br />
                                    [6,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioInformacaoConhecimento"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Informações e Conhecimento<br />
                                    [6,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioPessoa"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Pessoas<br />
                                    [9,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioProcesso"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Processos<br />
                                    [16,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioResultadoControle"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Resultados<br />
                                    [30,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioResultadoTendencia"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Resultados - Tendência<br />
                                    [21,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "TotalGestao"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    TOTAL Gestão<br />
                                    [100,00%]</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblProtocolo" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "Protocolo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Protocolo</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrograma" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "Programa") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Programa</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblAvaliador" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "Avaliador") %>'></asp:Label>
                                    <asp:Label ID="lblTipoEtapa" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "TipoEtapa") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Programa</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</fieldset>
    <asp:HiddenField ID="hddRowIndex" runat="server" />
    <uc1:UCConfirmaEmail ID="UCConfirmaEmail1" runat="server" />
</asp:Content>
