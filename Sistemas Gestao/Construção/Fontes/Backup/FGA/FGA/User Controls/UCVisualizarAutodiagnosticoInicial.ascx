<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCVisualizarAutodiagnosticoInicial.ascx.cs" Inherits="Sistema_de_Gestao.FGA.User_Controls.UCVisualizarAutodiagnosticoInicial" %>


<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldTurma" runat="server" />
        <fieldset>
              <legend id="LegEmpresa" style="font-size: large">Autodiagnóstico Inicial</legend>
            <br />
               <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
        <tr>
            <td>
                <div align="center" style="overflow:auto; width: 980px">
                    <asp:GridView ID="grdRelatorioRAA" runat="server" AllowPaging="True" AllowSorting="True"
                        PageSize="15" Width="1700px" AutoGenerateColumns="False" OnPageIndexChanging="grdRelatorioRAA_PageIndexChanging"
                        OnRowDataBound="grdRelatorioRAA_RowDataBound">
                        <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                        <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                        <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                        <AlternatingRowStyle BackColor="White" />
                        <EmptyDataTemplate>
                            <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font></EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="Ano">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Ano")%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Ano<br />
                                    Pontuação Máxima</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Envio">
                                <ItemTemplate>
                                    <%#  DataBinder.Eval(Container.DataItem, "DataEnvio") %>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Data Envio<br />
                                    &nbsp;
                                </HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                     <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioCliente"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Clientes<br />
                                    9,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioSociedade"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Sociedade<br />
                                    6,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioLideranca")) %>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Liderança<br />
                                    15,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlano"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Estratégias e Planos<br />
                                    9,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioPessoa"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Pessoas<br />
                                    9,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioProcesso"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Processos<br />
                                    16,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioInformacaoConhecimento"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Informações e Conhecimento<br />
                                    6,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioResultadoControle"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Resultados - Controle<br />
                                    9,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "CriterioResultadoTendencia"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Resultados - Tendência<br />
                                    21,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "TotalGestao"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Total Gestão<br />
                                    100,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "AvaliacaoEmpreendedor"))%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Avaliação do Empreendedor<br />
                                    100,00</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImagBttnDownload" runat="server" ImageUrl="~/Image/ico_download.gif" CommandName="Download" CommandArgument='<%#Eval("Avaliador")%>'
                                        CausesValidation="false" />
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Download<br />
                                    &nbsp;</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImagBttnEnviarEmail" runat="server" ImageUrl="~/Image/_file_mail2.png" CommandName="Email" CommandArgument='<%#Eval("Avaliador")%>'
                                        CausesValidation="false" />
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Enviar por Email<br />
                                    &nbsp;</HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    &nbsp;</fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnGravar_Click1"  />
        </div>
    </asp:Panel>
    <script>
        function WindowOpen(url) {
            window.open(url);
        }
    </script>
</div>