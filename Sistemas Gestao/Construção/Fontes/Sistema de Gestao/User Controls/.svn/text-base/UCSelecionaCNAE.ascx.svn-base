<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSelecionaCNAE.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCSelecionaCNAE" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" CssClass="panelUC">
        <div style="height: 500px; overflow: auto">
            <asp:HiddenField ID="HddnFldGrupo" runat="server" />
            <fieldset>
                <legend style="font-size: large">Busca de Atividade Econômica</legend>

                <asp:Panel ID="PnlPesquisa" runat="server" DefaultButton="ImgBttnPesquisar">
                
                <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblMensagemExplicativa" runat="server" Text="Digite um Código ou uma palavra chave para Atividade Econômica e clique na Lupa para pesquisar."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblCodigo" runat="server" Text="Código:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtCodigoPesquisa" runat="server" Width="185px" MaxLength="4" onKeyDown="Mascara(this,Integer);"
                                onKeyPress="Mascara(this,Integer);" onKeyUp="Mascara(this,Integer);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAtividadEconomica" runat="server" Text="Atividade Econômica:"> </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAtividadeEconomicaPesquisa" runat="server" Width="400px" MaxLength="200"></asp:TextBox>
                        </td>
                        <td align="left" width="200px">
                            <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                                OnClick="ImgBttnPesquisar_Click" />&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <br />
                <br />
                <fieldset style="height:300px">
                    <legend>Lista de Atividade Econômica</legend>
                    <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                        <tr>
                            <td>
                                <div align="center">
                                    <asp:GridView ID="grdAtividadeEconomica" runat="server" AllowPaging="True" PageSize="10" 
                                        CssClass="Text_grid" Width="100%" DataKeyNames="IdAtividadeEconomica,AtividadeEconomica"
                                        AutoGenerateColumns="False" OnRowUpdating="grdAtividadeEconomica_RowUpdating"
                                        OnPageIndexChanging="grdAtividadeEconomica_PageIndexChanging" 
                                        onrowdatabound="grdAtividadeEconomica_RowDataBound">
                                        <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                                        <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                        <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <EmptyDataTemplate>
                                            Não existem dados*
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Classe">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "Classe")%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Atividade Econômica">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "AtividadeEconomica")%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="79%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selecionar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImagBttnSelecionar" runat="server" ImageUrl="~/Image/_file_Ok2.png"
                                                        CommandName="Update" CausesValidation="false" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </fieldset>
            <div align="Center">
                <br />
                <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                    OnClick="ImgBttnCancelar_Click" />
            </div>
        </div>
    </asp:Panel>
</div>
