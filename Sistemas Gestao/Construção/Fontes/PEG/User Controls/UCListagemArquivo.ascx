<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCListagemArquivo.ascx.cs"
    Inherits="PEG.User_Controls.UCListagemArquivo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="/User Controls/UCCadastroArquivoCE.ascx" TagName="UCCadastroArquivoCE" TagPrefix="uc3" %>
<asp:Panel ID="PnlFundo" runat="server" Width="375px" BackColor="White">
    <fieldset style="margin-top: 5px; margin-right: 5px; margin-bottom: 5px;">
        <legend style="font-size: 12px;">Documentos </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" style="margin-top:-2px;">
            <tr>
                <td>
                    <asp:GridView ID="grdArquivos" runat="server" 
                        AllowSorting="True" CssClass="Text_grid" Width="100%" Font-Size="11px" AutoGenerateColumns="False"
                        EnableModelValidation="True">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                        <EmptyDataTemplate>
                            Não existem dados*
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="Documento">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Titulo")%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="40%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Baixar">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# "/DownloadArquivos/" + DataBinder.Eval(Container, "DataItem.Arquivo") %>'>
                                        <asp:Image ID="Image1" ImageUrl="~/Image/_file_download2.png" runat="server" BorderStyle="None" /></asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="right">
                            <br />
                            <asp:LinkButton ID="HlkMais" runat="server" Font-Size="12px" onclick="ImgBtnVejaMais_Click">Ver Mais</asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
    </fieldset>
    <uc3:UCCadastroArquivoCE ID="UCCadastroArquivoCE1" runat="server" />
</asp:Panel>
