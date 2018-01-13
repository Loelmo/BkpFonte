<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGerenciarEtapaIA.ascx.cs"
    Inherits="PEG.User_Controls.UCGerenciarEtapaIA" %>
<%@ Register src="UCGerenciarEtapaResumo.ascx" tagname="UCGerenciarEtapaResumo" tagprefix="uc1" %>

<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldIdEtapa" runat="server" />
        <asp:HiddenField ID="HddnFldIdTurma" runat="server" />
        <fieldset>
            <legend style="font-size: large">Alterar Etapa</legend>
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td>
                        <div align="center">
                            <asp:GridView ID="grdEtapaEstadual" runat="server" AllowPaging="True" AllowSorting="True"
                                PageSize="15" CssClass="Text_grid" Width="100%" DataKeyNames="IdEtapa" AutoGenerateColumns="False"
                                OnRowDataBound="grdEtapaEstadual_RowDataBound" OnPageIndexChanging="grdEtapaEstadual_PageIndexChanging" 
                                OnRowUpdating="grdEtapaEstadual_RowUpdating" 
                                onrowcommand="grdEtapaEstadual_RowCommand">
                                <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                                <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="IdEtapa" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="LblIdEtapa" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "IdEtapa")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Etapa">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Etapa")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ativo">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImagBttnAcao" runat="server" ImageUrl="~/Image/file_delete2.png"
                                                CommandName="Update" CausesValidation="false" Width="20px" />
                                            <asp:Label ID="LblAcao" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Ativo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Resumo">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImagBttnResumo" runat="server" ImageUrl="~/Image/_file_resume2.png"
                                                CommandName="Resumo" CausesValidation="false" CommandArgument="<%# Container.DataItemIndex %>"/>
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
        <div align="center">
            <br />
            <%--<a href="javascript: void(document.getElementById('<%= divUserControl.ClientID%>').style.display = 'none');"><img src="/Image/cancelar16.gif" border="0" /></a>--%>
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnGravar_Click" />
        </div>
        <uc1:UCGerenciarEtapaResumo ID="UCGerenciarEtapaResumo1" runat="server" />
    </asp:Panel>
</div>


