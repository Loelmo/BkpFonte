<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGerenciarEtapaResumo.ascx.cs"
    Inherits="PEG.User_Controls.UCGerenciarEtapaResumo" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
   <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldIdEtapa" runat="server" />
        <fieldset>
            <legend style="font-size: large">Resumo Etapa</legend>
            <br />
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td>
                        <div align="center">
                            <asp:GridView ID="grdEtapa" runat="server" AllowPaging="True" AllowSorting="True"
                                PageSize="10" CssClass="Text_grid" Width="100%" DataKeyNames="IdEtapaResumo"
                                AutoGenerateColumns="False" OnPageIndexChanging="grdEtapa_PageIndexChanging"
                                OnRowDataBound="grdEtapa_RowDataBound">
                                <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                                <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                <AlternatingRowStyle BackColor="White" />
                                <EmptyDataTemplate>
                                    Não existem dados*
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Etapa">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Etapa.Etapa")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="40%"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Etapa.Estado.Estado")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Usuário">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "AdmUsuario.Usuario")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ação">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAcao" Text='<%# Eval("Acao")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Data/Hora">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "DataCadastro")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnGravar_Click" />&nbsp;&nbsp;
        </div>
    </asp:Panel>
</div>
