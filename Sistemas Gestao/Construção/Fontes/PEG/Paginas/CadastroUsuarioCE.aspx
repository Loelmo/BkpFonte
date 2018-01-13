<%@ Page Title="Usuário" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="CadastroUsuarioCE.aspx.cs" Inherits="PEG.CadastroUsuarioCE" %>

<%@ Register Src="/User Controls/UCCadastroUsuarioIA.ascx" TagName="UCCadastroUsuarioIA"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Cadastro de Usuário</h3>
    <fieldset>
        <legend class="cssLegend">Pesquisa </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxUsuario" runat="server" Width="238" Font-Names="Verdana" Font-Size="08" TabIndex="1" ></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Login:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxLogin" runat="server" Width="100" Font-Names="Verdana" Font-Size="08" TabIndex="2"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="CPF:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxCPF" runat="server" Width="100" MaxLength="14" onKeyDown="Mascara(this,Cpf);"
                        onKeyPress="Mascara(this,Cpf);" onKeyUp="Mascara(this,Cpf);" Font-Names="Verdana" Font-Size="08" TabIndex="3"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Telefone:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxTelefone" runat="server" Width="100" MaxLength="14" onKeyDown="Mascara(this,Telefone);"
                        onKeyPress="Mascara(this,Telefone);" onKeyUp="Mascara(this,Telefone);" Font-Names="Verdana" Font-Size="08" TabIndex="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="E-mail:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxEmail" runat="server" Width="238" Font-Names="Verdana" Font-Size="08" TabIndex="5"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Estado:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="100px" TabIndex="6"
                        DataValueField="IdEstado" DataTextField="Estado" Font-Names="Verdana" Font-Size="08">
                    </asp:DropDownList>
                </td>
                <td align="left">
                    <asp:Label ID="Label7" runat="server" Text="Ativo:"></asp:Label>
                </td>
                <td align="left">
                    <asp:CheckBox ID="ChckBxAtivo" Checked="true" runat="server" Font-Names="Verdana" Font-Size="08"  TabIndex="7"/>
                </td>
                <td>
                </td>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png" TabIndex="8" 
                        OnClick="ImgBttnPesquisar_Click" Style="width: 20px" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
        <legend class="cssLegend">Lista de Usuário </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnIncluir" runat="server" ImageUrl="~/Image/_file_add2.png" TabIndex="9"
                        OnClick="ImgBttnIncluir_Click" ToolTip="Incluir um novo Usuário" />
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <asp:GridView ID="grdUsuario" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="10" Width="100%" DataKeyNames="IdUsuario" AutoGenerateColumns="False"
                            OnPageIndexChanging="grdUsuario_PageIndexChanging" OnRowDeleting="grdUsuario_RowDeleting"
                            OnRowDataBound="grdUsuario_RowDataBound" OnRowUpdating="grdUsuario_RowUpdating">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Nome">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Usuario")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Login">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Login")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CPF">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatCPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CPF")))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Telefone">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormatTelefone(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "Telefone")))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Email")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alterar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAlterar" runat="server" ImageUrl="~/Image/file_edit2.png"
                                            CommandName="Update" CausesValidation="false" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ativo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAtivo" runat="server" ImageUrl="~/Image/_file_Ok2.png"
                                            CommandName="Delete" CausesValidation="false" Width="20px" />
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
    </fieldset>
    <uc1:UCCadastroUsuarioIA ID="UCCadastroUsuarioIA1" runat="server" />
</asp:Content>
