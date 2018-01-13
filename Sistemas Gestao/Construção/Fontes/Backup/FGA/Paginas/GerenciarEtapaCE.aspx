<%@ Page Title="Gerenciar Etapa" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="GerenciarEtapaCE.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.GerenciarEtapaCE" %>

<%@ Register Src="/User Controls/UCGerenciarEtapaIA.ascx" TagName="UCGerenciarEtapaIA"
    TagPrefix="uc1" %>
<%@ Register Src="/User Controls/UCGerenciarEtapaResumo.ascx" TagName="UCGerenciarEtapaResumo"
    TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Gerenciar Etapas
    </h3>
    <fieldset id="fieldPesquisa" runat="server">
        <legend>Pesquisa </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
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
                <div id="divEstado" runat="server">
                <td>
                    <asp:Label ID="LblEstado" runat="server" Text="Estado:"></asp:Label>
                </td>
                <td Style="width: 20px">
                    <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="200px" TabIndex="9"
                        DataValueField="IdEstado" DataTextField="Estado" Font-Names="Verdana" Font-Size="08">
                        <asp:ListItem Selected="True" Text="<< Selecione um Estado >>" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td Style="width: 200px">
                    
                        <span class="obrigatorio" runat="server" id="spEstado">*</span>
                                           
                </td>
                 </div>
                <td>
                    <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                        Style="width: 20px" OnClick="ImgBttnPesquisar_Click"  />
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
<%--                    <div align="center">
                        <asp:GridView ID="grdEtapa" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" CssClass="Text_grid" Width="100%" DataKeyNames="IdEtapa" AutoGenerateColumns="False"
                            OnPageIndexChanging="grdEtapa_PageIndexChanging" onrowdatabound="grdEtapaEstadual_RowDataBound" 
                            OnRowUpdating="grdEtapa_RowUpdating" OnRowCommand="grdEtapa_RowCommand" OnSelectedIndexChanged="grdEtapa_SelectedIndexChanged">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                Não existem dados*
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Estado" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEstado" runat="server" Text='<%# Eval("Estado.IdEstado")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Etapa Atual">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Etapa")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="70%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ativo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" ImageUrl="~/Image/file_delete2.png" Text="Editar" 
                                            runat="server" Width="20px" CommandName="Update" />
                                            <asp:Label ID="LblAcaoEstadual" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Ativo")%>'></asp:Label>
                                            <asp:Label ID="LblIdEtapaEstadual" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "IdEtapa")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Resumo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgResumo" ImageUrl="~/Image/_file_resume2.png" Text="Resumo"
                                            runat="server" CommandName="Resumo" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdEtapa") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>--%>
                    <div align="center">
                        <asp:GridView ID="grdEtapaNacional" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" CssClass="Text_grid" Width="100%" DataKeyNames="IdEtapa" AutoGenerateColumns="False"
                            OnPageIndexChanging="grdEtapaNacional_PageIndexChanging" 
                            onrowdatabound="grdEtapaNacional_RowDataBound" OnRowCommand="grdEtapaNacional_RowCommand"
                            onrowupdating="grdEtapaNacional_RowUpdating1">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Etapa">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Etapa")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Ativo">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImagBttnAcao" runat="server" ImageUrl="~/Image/file_delete2.png"
                                                CommandName="Update" Width="20px" CausesValidation="false" />
                                            <asp:Label ID="LblAcao" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Ativo")%>'></asp:Label>
                                            <asp:Label ID="LblIdEtapa" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "IdEtapa")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="1%" />
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Resumo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgResumo2" ImageUrl="~/Image/_file_resume2.png" Text="Resumo"
                                            runat="server" CommandName="Resumo"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdEtapa") %>' />
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
    <uc1:UCGerenciarEtapaIA ID="UCGerenciarEtapaIA1" runat="server" />
    <uc2:UCGerenciarEtapaResumo ID="UCGerenciarEtapaResumo1" runat="server" />
</asp:Content>
