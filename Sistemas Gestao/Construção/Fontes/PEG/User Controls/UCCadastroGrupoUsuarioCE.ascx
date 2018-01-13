<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroGrupoUsuarioCE.ascx.cs" Inherits="PEG.User_Controls.UCCadastroGrupoUsuarioCE" EnableViewState="true"%>
<%@ Register Src="/User Controls/UCCadastroGrupoUsuarioIA.ascx" TagName="UCCadastroGrupoUsuarioIA" TagPrefix="uc1" %>

<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldIdAdmGrupo" runat="server" />
        <fieldset class="fieldsetUC">
            <legend style="font-weight: bold;">Associar Usuário ao Grupo de Acesso </legend>
            <%--<div id="divUC" runat="server" class="divUC">--%>
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblGrupo" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">
                            <asp:ImageButton ID="ImgBttnIncluir" runat="server" ImageUrl="~/Image/_file_add2.png" onclick="ImgBttnIncluir_Click" />    
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="grdGrupoUsuario" runat="server" AllowPaging="True" AllowSorting="True"
                    PageSize="10" Width="100%" DataKeyNames="IdGrupoUsuario" AutoGenerateColumns="False"
                    OnPageIndexChanging="grdGrupoUsuario_PageIndexChanging" OnRowDeleting="grdGrupoUsuario_RowDeleting"
                    OnRowDataBound="grdGrupoUsuario_RowDataBound" 
                    OnRowUpdating="grdGrupoUsuario_RowUpdating" 
                    onrowediting="grdGrupoUsuario_RowEditing">
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
                                <%# DataBinder.Eval(Container.DataItem, "IdGrupoUsuario")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Turma">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Turma.Turma")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Escritório Regional">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "EscritorioRegional.EscritorioRegional")%>
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

                        <asp:TemplateField HeaderText="Excluir">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBttnExcluir" ImageUrl="~/Image/file_delete2.png" Text="Excluir" HeaderText="Excluir"
                                    runat="server" CommandName="delete" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
           <%-- </div>--%>
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnVoltar" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnVoltar_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </asp:Panel>

    <uc1:UCCadastroGrupoUsuarioIA ID="UCCadastroGrupoUsuarioIA1" runat="server" />

</div>
