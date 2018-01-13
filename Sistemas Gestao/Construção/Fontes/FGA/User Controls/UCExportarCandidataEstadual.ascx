<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCExportarCandidataEstadual.ascx.cs" Inherits="Sistema_de_Gestao.User_Controls.UCExportarCandidataEstadual" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="900px"  BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%; font-size: 11px;">
        <asp:HiddenField ID="HddnTipoArquivo" runat="server" />
        <fieldset class="fieldsetUC">
            <legend style="font-size: medium">Formato</legend>
                <table cellspacing="1" cellpadding="1" width="100%;" border="0" style="text-align: left;">
                    <tr>
                        <td valign="top" colspan="2">
                            <asp:RadioButtonList ID="rdList" runat="server" RepeatDirection="Horizontal" 
                                Width="358" onselectedindexchanged="rdList_SelectedIndexChanged" AutoPostBack="true" >
                                <asp:ListItem Text="Excel 2007" Value="Excel" ></asp:ListItem>
                                <asp:ListItem Text="Open Document" Value="OpenDocument"></asp:ListItem>
                            </asp:RadioButtonList>

                        </td>
                        <td valign="top">
                            <asp:CheckBox ID="chkZip" runat="server" Text="Compactar (*.ZIP)"  width="300" 
                                AutoPostBack="True" oncheckedchanged="chkZip_CheckedChanged"/>
                        </td>
                    </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lblTamanho" runat="server" Text="Tamanho:"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:Label ID="lblTamanhoValor" runat="server" Text="" Width="300px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Tempo Estimado:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDiscada" runat="server" Text="" Width="300px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblBandaLarga" runat="server" Text="" Width="300px"></asp:Label>
                    </td>
                </tr>
                </table>
                    
        </fieldset>
        <div align="center">
            <br />
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImgBttnExportar" runat="server" ImageUrl="~/Image/_file_export2.png"
                            OnClick="ImgBttnExportar_Click"  />&nbsp;&nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                            OnClick="ImgBttnCancelar_Click" />&nbsp;&nbsp;

                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>


    <asp:GridView ID="grdCanditadaEstadual" runat="server" AllowPaging="True" AllowSorting="True" Visible="false"
                            PageSize="15" Width="1500" AutoGenerateColumns="False" >
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="CNPJ">
                                    <ItemTemplate>
                                        <asp:Label ID="Label0" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CpfCnpj")))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Razão Social">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Protocolo">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Protocolo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Consultor" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NomeAvaliadorSenior")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pré-Classificar">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatBoolean(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "Classificar")))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ranking" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text="0"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Desistente">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatBoolean(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "Excluido")))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selecionou A ou B nas Questões Especiais?">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatBoolean(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "MarcaQuestoesEspeciais")))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Ranking [100%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "PontuacaoTotalPreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Enfoque [70%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "EnfoquePreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Resultados [30%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "ResultadoControlePreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Relação com melhor da Turma">
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "RelacaoMelhorCategoriaPreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Liderança [15%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioLiderancaPreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Estratégias e Planos [9%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlanosPreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Cliente [9%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioClientePreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Sociedade [6%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioSociedadePreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Informações e Conhecimento [6%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioInformacoesConhecimentoPreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Pessoas [9%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioPessoasPreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Processos [16%]">
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatPontuacaoRanking((double)DataBinder.Eval(Container.DataItem, "CriterioProcessosPreVisita"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
</div>
