<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroArquivoIA.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCCadastroArquivoIA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="880px" BackColor="White" BorderColor="Black"
        BorderStyle="Outset" BorderWidth="1" Style="position: relative; top: 10%;">
        <asp:HiddenField ID="HddnFldIdArquivo" runat="server" />
        <asp:HiddenField ID="HddnFldArquivo" runat="server" />
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;">Cadastro Documento </legend>
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0" class="tabFiltros">
                <tr>
                    <td width="1%" align="right">
                        <asp:Label ID="Label5" runat="server" Text="Ativo:"></asp:Label>
                    </td>
                    <td width="50%" align="left">
                        <asp:CheckBox ID="ChckBxAtivo" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="LblNome" runat="server" Text="Título:"></asp:Label>
                    </td>
                    <td width="20%" align="left">
                        <asp:TextBox ID="TxtBxNome" runat="server" Width="300px" MaxLength="30" TabIndex="1"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td width="10%" align="right">
                        <asp:Label ID="Label1" runat="server" Text="Conteúdo:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" clientIdMode="AutoID" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" />
                        <span class="obrigatorio">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label7" runat="server" Text="Prioridade:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:DropDownList ID="DrpDwnLstPrioridade" runat="server" Width="205px" TabIndex="9"
                            DataValueField="IdPrioridade" DataTextField="Prioridade">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label4" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="205px" TabIndex="9"
                            DataValueField="IdEstado" DataTextField="Estado">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label3" runat="server" Text="Turma:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:DropDownList ID="DrpDwnLstTurma" runat="server" Width="205px" TabIndex="9" DataValueField="IdTurma"
                            DataTextField="Turma">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="1%" align="right">
                        <asp:Label ID="Label2" runat="server" Text="Tipo de Usuário:"></asp:Label>
                    </td>
                    <td width="50%" align="left">
                        <asp:RadioButton GroupName="tipoUsuario" ID="rdTipoUsuarioEmpresa" runat="server"
                            Text="Empresas" Checked="true" OnClick="ExibeOcultaListaGruposCadastroArquivo()" />
                        <asp:RadioButton GroupName="tipoUsuario" ID="rdTipoUsuarioAdministrativo" runat="server"
                            Text="Administrativos" OnClick="ExibeOcultaListaGruposCadastroArquivo()" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <div id="lblGrupoDiv" runat="server" style="display: none;">
                            <asp:Label ID="Label6" runat="server" Text="Grupos de Usuários:"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div align="center" runat="server" id="grdGrupoDiv" style="display: none;">
                            <asp:GridView ID="grdGrupoIncluir" runat="server" CssClass="Text_grid" Width="100%" OnRowDataBound="grdGrupo_RowDataBound" AutoGenerateColumns="False">
                                <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                                <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                <AlternatingRowStyle BackColor="White" />
                                <EmptyDataTemplate>
                                    Não existem dados*
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="IdGrupo" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdGrupo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdGrupo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FlSelecionado" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlSelecionado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Selecionado")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Grupo">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Grupo")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descrição">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Descricao")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Incluir">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkIncluir" runat="server" CssClass="noborder" Checked='false'>
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png"
                OnClick="ImgBttnGravar_Click" />&nbsp;&nbsp;
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click" />&nbsp;&nbsp;
        </div>
    </asp:Panel>
</div>
