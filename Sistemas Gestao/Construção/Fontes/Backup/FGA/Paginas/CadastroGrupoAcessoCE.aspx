<%@ Page Title="Grupo de Acesso" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="CadastroGrupoAcessoCE.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.CadastroGrupoAcessoCE" %>

<%@ Register Src="/User Controls/UCCadastroGrupoAcessoIA.ascx" TagName="UCCadastroGrupoAcessoIA"
    TagPrefix="uc1" %>
<%@ Register Src="/User Controls/UCCadastroGrupoUsuarioCE.ascx" TagName="UCCadastroGrupoUsuarioCE"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Cadastro de Grupo de Acesso</h3>
    <fieldset>
        <legend>Pesquisa </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td width="30px">
                    <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxNomePesquisa" runat="server" Width="250" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                        Style="width: 20px" OnClick="ImgBttnPesquisar_Click"  />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
        <legend>Lista de Grupo de Acesso </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnIncluir" runat="server" ImageUrl="~/Image/_file_add2.png"
                        OnClick="ImgBttnIncluir_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <asp:GridView ID="grdGrupoAcesso" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="9" Width="100%" DataKeyNames="IdGrupo" AutoGenerateColumns="False"
                            OnPageIndexChanging="grdGrupoAcesso_PageIndexChanging" OnRowUpdating="grdGrupoAcesso_RowUpdating"
                            OnRowEditing="grdGrupoAcesso_RowEditing">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Grupo">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Grupo")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descrição">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Descricao")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="80%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alterar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAlterar" runat="server" ImageUrl="~/Image/file_edit2.png"
                                            CommandName="Update" CausesValidation="false" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Associar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAssociar" runat="server" ImageUrl="~/Image/_file_assoc2.png"
                                            CommandName="Edit" CausesValidation="false" />
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
    <uc1:UCCadastroGrupoAcessoIA ID="UCCadastroGrupoAcessoIA1" runat="server" />
    <uc2:UCCadastroGrupoUsuarioCE ID="UCCadastroGrupoUsuarioCE1" runat="server" />
</asp:Content>
