<%@ Page Title="Escritório Regional" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="CadastroEscritorioRegionalCE.aspx.cs" Inherits="Sistema_de_Gestao.CadastroEscritorioRegionalCE" %>

<%@ Register Src="/User Controls/UCCadastroEscritorioRegionalIA.ascx" TagName="UCCadastroEscritorioRegionalIA"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Cadastro de Escritório Regional</h3>
    <fieldset>
        <legend>Pesquisa </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNome" runat="server" Width="150" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Turma:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DrpDwnLstTurma" runat="server" Width="120px" TabIndex="9" DataValueField="IdTurma"
                        DataTextField="Turma" Font-Names="Verdana" Font-Size="08" 
                        AutoPostBack="True" 
                        onselectedindexchanged="DrpDwnLstTurma_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Estado:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="120px" TabIndex="9"
                        DataValueField="IdEstado" DataTextField="Estado" Font-Names="Verdana" Font-Size="08">
                        <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Ativo:"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChckBxAtivo" Checked="true" runat="server" Font-Names="Verdana" Font-Size="08" />
                </td>
                <td>
                    <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                        Style="width: 20px" OnClick="ImgBttnPesquisar_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
        <legend>Lista de Escritório Regional </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td align="right">
                    <asp:ImageButton ID="ImgBtnIncluir" runat="server" ImageUrl="~/Image/_file_add2.png"
                        OnClick="ImgBtnIncluir_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <asp:GridView ID="grdEscritorioRegional" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" CssClass="Text_grid" Width="100%" DataKeyNames="IdEscritorioRegional"
                            AutoGenerateColumns="False" OnPageIndexChanging="grdEscritorioRegional_PageIndexChanging"
                            OnRowDeleting="grdEscritorioRegional_RowDeleting" OnSelectedIndexChanged="grdEscritorioRegional_SelectedIndexChanged"
                            OnRowDataBound="grdEscritorioRegional_RowDataBound" OnRowUpdating="grdEscritorioRegional_RowUpdating"
                            OnRowEditing="grdEscritorioRegional_RowEditing">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Escritório Regional">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EscritorioRegional")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Turma">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Turma.Turma")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" ImageUrl="~/Image/file_edit2.png" Text="Editar" HeaderText="Editar"
                                            runat="server" CommandName="Update" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ativo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgExcluir" ImageUrl="~/Image/file_delete2.png" Text="Excluir"
                                            HeaderText="Excluir" runat="server" CommandName="delete" />
                                        <asp:Label ID="LblAtivo" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Ativo")%>'></asp:Label>
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
        <asp:HiddenField ID="hddMensagem" runat="server" />
    </fieldset>
    <uc1:UCCadastroEscritorioRegionalIA ID="UCCadastroEscritorioRegionalIA1" runat="server" />
</asp:Content>
