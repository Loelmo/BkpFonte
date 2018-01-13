<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroGrupoEmpresaIncluir.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCCadastroGrupoEmpresaIncluir" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="800px" Height="530px" BackColor="White" 
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative; 
        top: 0%;">
        <asp:HiddenField ID="HddnFldTurma" runat="server" />
        
        <div style="height: 520px; overflow: auto" >
        <fieldset>

            <legend style="font-size: large">Filtros</legend>
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td>
                        <asp:Label ID="LblNome" runat="server" Text="Nome:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtNome" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCpfCnpj" runat="server" Text="CNPJ / CPF:"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="TxtBxCNPJCPF" runat="server" Width="150" MaxLength="18" ></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Estado:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DrpDwnLstEstado" runat="server" DataValueField="IdEstado" DataTextField="Estado" AutoPostBack="true" Width="200px"
                        onselectedindexchanged="DrpDwnLstEstado_SelectedIndexChanged">  
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblER" runat="server" Text="Escritório Regional:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEscritorioRegional" runat="server" DataValueField="IdEscritorioRegional" Width="200px"
                            DataTextField="EscritorioRegional">
                            <asp:ListItem Text="<< Selecione um Estado >>" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCategoria" runat="server" Text="Categoria:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategoria" runat="server" DataValueField="IdCategoria" DataTextField="Categoria" Width="200px">
                            <asp:ListItem Text="<< Selecione uma Categoria >>" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                            OnClick="ImgBttnPesquisar_Click" />
                    </td>
                </tr>
            </table>
            <fieldset>
                <legend>Lista de Empresas</legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                    <tr>
                        <td>
                            <div align="center">
                                <asp:GridView ID="grdEmpresa" runat="server" AllowPaging="True" AllowSorting="True"
                                    PageSize="10" CssClass="Text_grid" Width="100%" DataKeyNames="IdEmpresaCadastro"
                                    AutoGenerateColumns="False" 
                                    onpageindexchanging="grdEmpresa_PageIndexChanging">
                                    <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                                    <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                    <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <EmptyDataTemplate>
                                        Não existem dados*
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdEmpresa" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdEmpresa" runat="server" Text='<%# Eval("IdEmpresaCadastro")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Incluir">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="incluirEmpresa" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CNPJ/CPF">
                                            <ItemTemplate>
                                                <%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CPF_CNPJ")))%> 
                                            </ItemTemplate>
                                            <HeaderStyle Width="80px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Razão Social">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nome Fantasia">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "NomeFantasia")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </fieldset>
        <div align="center">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" 
                ImageUrl="~/Image/_file_save.png" onclick="ImgBttnGravar_Click1" />
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnCancelar_Click1" />
                <br />
        </div>
        </div>
    </asp:Panel>
</div>
