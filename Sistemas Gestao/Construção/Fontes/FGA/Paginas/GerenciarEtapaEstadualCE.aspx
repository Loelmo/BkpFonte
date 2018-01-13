<%@ Page Title="Gerenciar Etapas Estaduais" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="GerenciarEtapaEstadualCE.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.GerenciarEtapaEstadualCE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Gerenciar Etapas Estaduais</h3>
    <fieldset>
        <legend>Pesquisa </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td width="30px">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado:"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEstado" runat="server" DataValueField="IdEstado" DataTextField="Estado">
                    </asp:DropDownList>
                    <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/pesquisar.gif"
                        Style="width: 16px" OnClick="ImgBttnPesquisar_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
        <legend>Lista de Etapas</legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td>
                    <div align="center">
                        <asp:GridView ID="grdEtapa" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" CssClass="Text_grid" Width="100%" DataKeyNames="IdEtapa" AutoGenerateColumns="False"
                            OnPageIndexChanging="grdEtapa_PageIndexChanging" OnRowDeleting="grdEtapa_RowDeleting"
                            OnRowUpdating="grdEtapa_RowUpdating">
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Small" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#8B8989" ForeColor="White" HorizontalAlign="Center" Font-Size="Smaller" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                Não existem dados*
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Etapa Atual">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Etapa")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Data de Alteração">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Alterar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" ImageUrl="~/Image/ico_editar.gif" Text="Editar" HeaderText="Editar"
                                            runat="server" CommandName="Update" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Resumo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgResumo" ImageUrl="~/Image/ico_pesquisar.gif" Text="Resumo"
                                            HeaderText="Resumo" runat="server" CommandName="Resumo" />
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
</asp:Content>
