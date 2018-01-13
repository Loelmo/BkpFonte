<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroTurmaIAAddQuestionario.ascx.cs" Inherits="Sistema_de_Gestao.FGA.User_Controls.UCCadastroTurmaIAAddQuestionario" %>

<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
     <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
            <fieldset>
                <legend>Incluir Questionário</legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                  <tr>
                    <td align="right"> 
                         
                    </td>
                 </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <asp:GridView ID="grdQuestionarioIncluir" runat="server" AllowPaging="True" CssClass="Text_grid" Width="100%"  
                                    AutoGenerateColumns="False" 
                                    onpageindexchanging="grdQuestionarioIncluir_PageIndexChanging">
                                    <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                                    <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                    <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <EmptyDataTemplate>
                                        Não existem dados*
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdQuestionario" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdQuestionario" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdQuestionario")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Questionário">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "Questionario")%>
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
                                                <asp:CheckBox ID="ChkIncluir" runat="server" CssClass="noborder"  Checked='false'>
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
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" 
                ImageUrl="~/Image/_file_save.png" onclick="ImgBttnGravar_Click1" />
            <asp:ImageButton ID="ImgBttnCancelar1" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnCancelar_Click1" />
        </div>
    </asp:Panel>
</div>