<%@ Page Title="Documentos" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="CadastroArquivoCE.aspx.cs" Inherits="PEG.CadastroArquivoCE" %>

<%@ Register Src="/User Controls/UCCadastroArquivoIA.ascx" TagName="UCCadastroArquivoIA"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Cadastro de Documentos</h3>
    <fieldset>
        <legend>Pesquisa</legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Título:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Data de Cadastro:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Prioridade:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Tipo de Usuário:"></asp:Label>
                </td>
                <td style="width:50px;">
                    <div id="lblGrupoAcesso" runat="server" style="display:none;">
                        <asp:Label ID="Label3" runat="server" Text="Grupo de Acesso:"></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Ativo:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TxtBxTitulo" runat="server" Width="320" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                Início:
                            </td>
                            <td align="right">
                                <asp:TextBox ID="TxtBxDataInicio" runat="server" Width="100" TabIndex="7" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                                <asp:ImageButton ID="ImgBttnCalendarioInicio" runat="server" TabIndex="8" ImageUrl="~/Image/Calendario.gif" />
                                <cc1:MaskedEditExtender ID="MskdEdtExtndrCalendarioInicio" runat="server" MaskType="Date"
                                    Mask="99/99/9999" TargetControlID="TxtBxDataInicio">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="ClndrExtndrCalendarioInicio" runat="server" Format="dd/MM/yyyy"
                                    PopupButtonID="ImgBttnCalendarioInicio" TargetControlID="TxtBxDataInicio">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fim:
                            </td>
                            <td align="right">
                                <asp:TextBox ID="TxtBxDataFim" runat="server" Width="100" TabIndex="7" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                                <asp:ImageButton ID="ImgBttnCalendarioFim" runat="server" TabIndex="8" ImageUrl="~/Image/Calendario.gif" />
                                <cc2:MaskedEditExtender ID="MskdEdtExtndrCalendarioFim" runat="server" MaskType="Date"
                                    Mask="99/99/9999" TargetControlID="TxtBxDataFim">
                                </cc2:MaskedEditExtender>
                                <cc2:CalendarExtender ID="ClndrExtndrCalendarioFim" runat="server" Format="dd/MM/yyyy"
                                    PopupButtonID="ImgBttnCalendarioFim" TargetControlID="TxtBxDataFim">
                                </cc2:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:DropDownList ID="DrpDwnLstPrioridade" runat="server" Width="120px" TabIndex="9"
                        DataValueField="Prioridade" DataTextField="Prioridade" Font-Names="Verdana" Font-Size="08">
                    </asp:DropDownList>
                </td>
                <td align="left">
                    <asp:RadioButton GroupName="tipoUsuario" ID="rdTipoUsuarioEmpresa" runat="server" Checked="true"
                        Text="Empresas" onclick="javascript:ExibeOcultaListaGruposCadastroFiltro();"/><br />
                    <asp:RadioButton GroupName="tipoUsuario" ID="rdTipoUsuarioAdministrativo" runat="server"
                        Text="Administrativos" onclick="javascript:ExibeOcultaListaGruposCadastroFiltro();"/>
                </td>
                <td>
                    <div id="drpDwnGrupoAcesso" runat="server" style="display:none;">
                    <asp:DropDownList ID="DrpDwnLstGrupo" runat="server" Width="120px" TabIndex="9" DataValueField="IdGrupo"
                        DataTextField="Grupo" Font-Names="Verdana" Font-Size="08">
                    </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <asp:CheckBox ID="chkBoxAtivo" runat="server" Checked="true"/>
                </td>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                        OnClick="ImgBttnPesquisar_Click" Style="width: 20px" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
        <legend>Lista de Documentos </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnIncluir" runat="server" ImageUrl="~/Image/_file_add2.png"
                        OnClick="ImgBttnIncluir_Click" ToolTip="Incluir um novo Documento" />
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <asp:GridView ID="grdArquivo" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="10" Width="100%" DataKeyNames="IdArquivo" AutoGenerateColumns="False"
                            OnPageIndexChanging="grdArquivo_PageIndexChanging" OnRowDeleting="grdArquivo_RowDeleting"
                            OnRowDataBound="grdArquivo_RowDataBound" OnRowUpdating="grdArquivo_RowUpdating">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Título">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Titulo")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Turma">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Turma.Turma")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Data de Cadastro">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "DataCadastro")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo de Usuário">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.StringUtils.TrataNoticiaTipoUsuario(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "UsuarioAdministrativo")))%>
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
                                        <asp:ImageButton ID="ImagBttnAtivo" runat="server" ImageUrl="~/Image/file_delete2.png"
                                            CommandName="Delete" CausesValidation="false" Width="20px" />
                                        <asp:Label ID="LblAtivo" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Ativo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Baixar">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# "/DownloadArquivos/" + DataBinder.Eval(Container, "DataItem.Arquivo") %>'>
                                            <asp:Image ID="Image1" ImageUrl="~/Image/_file_download2.png" runat="server" BorderStyle="None" /></asp:HyperLink>
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
    <uc1:UCCadastroArquivoIA ID="UCCadastroArquivoIA1" runat="server" />
</asp:Content>
