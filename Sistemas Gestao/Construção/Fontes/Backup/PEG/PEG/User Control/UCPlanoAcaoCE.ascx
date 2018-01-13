<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPlanoAcaoCE.ascx.cs"
    Inherits="PEG.User_Controls.UCPlanoAcaoCE" %>
<%@ Register Src="/PEG/User Control/UCPlanoAcaoIA.ascx" TagName="UCPlanoAcaoIA" TagPrefix="uc5" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="600px" Height="300px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%; font-size: 11px;">
        <br />
        <asp:HiddenField ID="HddnFldIdEmpresaCadastro" runat="server" />
        <asp:HiddenField ID="HddnFldIdTurma" runat="server" />
        <asp:HiddenField ID="HddnFldEtapa" runat="server" />
        <asp:HiddenField ID="HddnFldNumFase" runat="server" />
        <table width="100%">
            <tr>
                <td align="left">
                    <asp:Label ID="LblPlanoAcao" runat="server" Text="Planos de Ação:"></asp:Label>
                </td>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnIncluir" runat="server" ImageUrl="~/Image/_file_add2.png" onclick="ImgBttnIncluir_Click" />    
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="grdPlanoAcao" runat="server" AllowPaging="True" AllowSorting="True"
            PageSize="10" Width="100%" DataKeyNames="IdPlanoAcao" AutoGenerateColumns="False"
            OnPageIndexChanging="grdPlanoAcao_PageIndexChanging" OnRowDeleting="grdPlanoAcao_RowDeleting"
            OnRowDataBound="grdPlanoAcao_RowDataBound" 
            OnRowUpdating="grdPlanoAcao_RowUpdating" 
            onrowediting="grdPlanoAcao_RowEditing" 
             OnRowCommand="grdPlanoAcao_RowCommand">
            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
            <AlternatingRowStyle BackColor="White" />
            <EmptyDataTemplate>
                <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="Código" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIdPlanoAcao" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdPlanoAcao")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Identificação">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "PlanoAcao")%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data de Inclusão">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "DtCadastro")%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Última Alteração">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "DtAlteracao")%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alterar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgBttnAlterar" runat="server" ImageUrl="~/Image/file_edit2.png"
                            CommandName="Update" CausesValidation="false"  />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Evolução?" Visible="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgBttnEvolucao" runat="server" CommandName="Evolucao"
                            CommandArgument="<%# Container.DataItemIndex %>"
                            ImageUrl="~/Image/_file_download2.png" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnVoltar" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnVoltar_Click"/>
        </div>
    </asp:Panel>

        <uc5:UCPlanoAcaoIA ID="UCPlanoAcaoIA1" runat="server" />

</div>
