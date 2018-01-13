<%@ Page Title="Grupo Empresa" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="CadastroGrupoEmpresaCE.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.CadastroGrupoEmpresaCE" %>

<%@ Register Src="../User Controls/UCCadastroGrupoEmpresaIA.ascx" TagName="UCCadastroGrupoEmpresaIA"
    TagPrefix="uc1" %>
<%@ Register Src="../User Controls/UCFiltrosHorizontalVertical.ascx" TagName="UCFiltrosHorizontalVertical"
    TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Grupo de Empresas
    </h3>
    <fieldset>
        <legend>Pesquisa </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td width="30px">
                    <asp:Label ID="lblcampo" runat="server" Text="Nome:"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPesquisa" Columns="30" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                </td>
                <td width="30px">
                    <asp:Label ID="lblSetor" runat="server" Text="Setor:"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSetor" runat="server" DataValueField="IdSetor" DataTextField="Setor">
                        <asp:ListItem Selected="True" Text="Todos" Value="0" Font-Names="Verdana" Font-Size="08"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td runat="server" id="tdLblTurma">
                    <asp:Label ID="lblTurma" runat="server" Text="Turma:"></asp:Label>
                </td>
                <td>
        
                    <asp:DropDownList ID="DrpDwnLstTurma" runat="server" Width="195px" DataValueField="IdTurma"
                        DataTextField="Turma" OnSelectedIndexChanged="DrpDwnLstTurma_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
       
                    
                </td>
                <td runat="server" id="tdLblEstado">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                </td>
                <td align="left" runat="server" id="tdDdlEstado">
                    <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="105px" DataValueField="IdEstado"
                        DataTextField="Estado" >
                        <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td >
                    <asp:Label ID="Label1" runat="server" Text="Ativo:"> </asp:Label>
                </td>
                <td align="center">
                    <asp:CheckBox ID="ChckBxAtivo" Checked="true" runat="server" />                
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
        <legend>Lista de Grupos</legend>
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
                        <asp:GridView ID="grdGrupo" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="10" CssClass="Text_grid" Width="100%" DataKeyNames="IdGrupoEmpresa"
                            AutoGenerateColumns="False" OnPageIndexChanging="grdGrupo_PageIndexChanging"
                            OnRowDeleting="grdGrupo_RowDeleting" OnRowUpdating="grdGrupo_RowUpdating" OnRowCommand="grdGrupo_RowCommand"
                            OnRowDataBound="grdGrupo_RowDataBound">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="IdGrupo" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdGrupo" runat="server" Text='<%# Eval("Grupo.IdGrupo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left"  />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nome">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Grupo.Grupo")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="400" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Número de Empresas">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.Count")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="150"  />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Setor">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Grupo.Setor.Setor")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="110" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Turma">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Grupo.Turma.Turma")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="110" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Grupo.Estado.Estado")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="110" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Copiar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnCopiar" ImageUrl="~/Image/_file_copy2.png" Text="Copiar" HeaderText="Copiar"
                                            runat="server" CommandName="Copiar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Grupo.IdGrupo")%>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" ImageUrl="~/Image/file_edit2.png" Text="Editar" HeaderText="Editar"
                                            runat="server" CommandName="Update" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ativo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAcao" runat="server" ImageUrl="~/Image/file_delete2.png"
                                            CommandName="Delete" CausesValidation="false" Width="20px" />
                                        <asp:Label ID="LblAcao" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Grupo.Ativo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1" />
                                </asp:TemplateField>



                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <uc1:UCCadastroGrupoEmpresaIA ID="UCCadastroGrupoEmpresaIA1" runat="server" />
</asp:Content>
