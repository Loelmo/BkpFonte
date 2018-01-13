<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGerenciarEtapaEstadualIA.ascx.cs" Inherits="Sistema_de_Gestao.User_Controls.UCGerenciarEtapaEstadualIA" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="800px" Height="300px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%;">
        <asp:HiddenField ID="HddnFldIdEtapa" runat="server" />
        <fieldset>
            <legend style="font-size: large">Alterar Etapa Estadual</legend>
            <br />
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td>
                        <div align="center">
                        <asp:GridView ID="grdEtapaEstadual" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" CssClass="Text_grid" Width="100%" DataKeyNames="IdEtapa"
                            AutoGenerateColumns="False" OnPageIndexChanging="grdEtapaEstadual_PageIndexChanging"
                            OnRowDeleting="grdEtapaEstadual_RowDeleting" OnSelectedIndexChanged="grdEtapaEstadual_SelectedIndexChanged"
                            OnRowDataBound="grdEtapaEstadual_RowDataBound" OnRowUpdating="grdEtapaEstadual_RowUpdating"
                            OnRowEditing="grdEtapaEstadual_RowEditing">
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Small" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#8B8989" ForeColor="White" HorizontalAlign="Center" Font-Size="Smaller"/>
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Escritório Regional">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Etapa")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ação">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAcao" runat="server" ImageUrl="~/Image/button_cancel.gif"
                                         CommandName="Update" CausesValidation="false" Width="15px" />
                                        <asp:Label ID="LblAcao" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Ativo")%>'></asp:Label>
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
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/gravar16.gif"
                OnClick="ImgBttnGravar_Click" />
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/cancelar16.gif"
                OnClick="ImgBttnCancelar_Click" />
        </div>
    </asp:Panel>
</div>

