<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroArquivoCE.ascx.cs"
    Inherits="PEG.User_Controls.UCCadastroArquivoCE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="800px" Height="510px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%;">
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
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtBxTitulo" runat="server" Width="240" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    </td>
                    <td>
                        <table style="width:350px;">
                            <tr>
                                <td>
                                    Início:&nbsp;&nbsp;
                                    <asp:TextBox ID="TxtBxDataInicio" runat="server" Width="100" TabIndex="7" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                                    <asp:ImageButton ID="ImgBttnCalendarioInicio" runat="server" TabIndex="8" ImageUrl="~/Image/Calendario.gif" />
                                    <cc1:MaskedEditExtender ID="MskdEdtExtndrCalendarioInicio" runat="server" MaskType="Date"
                                        Mask="99/99/9999" TargetControlID="TxtBxDataInicio">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="ClndrExtndrCalendarioInicio" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="ImgBttnCalendarioInicio" TargetControlID="TxtBxDataInicio">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    Fim:&nbsp;&nbsp;
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
                    <td align="right">
                        <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                            OnClick="ImgBttnPesquisar_Click" Style="width: 16px" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <fieldset>
            <legend>Lista de Documentos</legend>
            <br />
            <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <div align="center">
                            <asp:GridView ID="grdArquivo" runat="server" AllowPaging="True" AllowSorting="True"
                                PageSize="10" Width="100%" DataKeyNames="IdArquivo" AutoGenerateColumns="False"
                                OnPageIndexChanging="grdArquivo_PageIndexChanging" >
                                <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                                <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                <AlternatingRowStyle BackColor="White" />
                                <EmptyDataTemplate>
                                    <font style="font-size: 12px; color: red;">Nenhum registro encontrado !</font>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Título">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Titulo")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Data de Cadastro">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "DataCadastro")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="30%" />
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
        <div align="right" style="margin-right:20px;">
            <br />
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click" />
        </div>
    </asp:Panel>
</div>
