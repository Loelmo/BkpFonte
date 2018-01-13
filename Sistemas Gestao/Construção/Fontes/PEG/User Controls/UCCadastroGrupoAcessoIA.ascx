<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroGrupoAcessoIA.ascx.cs"
    Inherits="PEG.User_Controls.UCCadastroGrupoAcessoIA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 10px;
    }
    
</style>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundoIA" CssClass="panelUC" runat="server" Width="900">
        <asp:HiddenField ID="HddnFldIdAdmGrupo" runat="server" />
        <fieldset class="fieldsetUC">
            <legend style="font-weight: bold;">Cadastro de Grupo de Acesso </legend>
            <div id="divUC" runat="server" class="divUC">
                <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                    border="0">
                  
                    <tr>
                        <td class="style1" align="left">
                            <asp:Label ID="LblNome" runat="server" Text="Nome:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxNome" runat="server" Width="650px" ></asp:TextBox><span
                            class="obrigatorio">*</span>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="left">
                            <asp:Label ID="Label1" runat="server" Text="Descrição:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxDescricao" runat="server" Width="650px"></asp:TextBox>
                        </td>
                    </tr>
                    <caption>
                        <br />
                        <tr>
                            <td style="vertical-align:top;">
                                <asp:Label ID="Label2" runat="server" Text="Permissões:"></asp:Label>
                            </td>
                            <td>
                                <div align="center">
                                    <asp:GridView ID="grdGrupoAcesso" runat="server" AllowSorting="True" 
                                        AutoGenerateColumns="False" DataKeyNames="IdFuncionalidade" 
                                        OnRowDataBound="grdGrupoAcesso_RowDataBound" 
                                        OnRowDeleting="grdGrupoAcesso_RowDeleting" 
                                        OnRowUpdating="grdGrupoAcesso_RowUpdating" Width="100%">
                                        <RowStyle BackColor="#dddddd" Font-Size="11px" ForeColor="#333333" 
                                            HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                        <HeaderStyle BackColor="#004a91" Font-Size="11px" ForeColor="White" 
                                            HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Funcionalidade">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtBxIdFuncionalidade" runat="server" 
                                                        Text=' <%# DataBinder.Eval(Container.DataItem, "IdFuncionalidade") %> ' 
                                                        Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="TxtBxIdGrupo" runat="server" 
                                                        Text=' <%# DataBinder.Eval(Container.DataItem, "AdmGrupo.IdGrupo") %> ' 
                                                        Visible="false"></asp:TextBox>
                                                    <%# DataBinder.Eval(Container.DataItem, "Funcionalidade")%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="50%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Visualizar">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBxVisualizar" runat="server" 
                                                        Checked='<%# DataBinder.Eval(Container.DataItem,"Visualizar") %>' 
                                                        CssClass="noborder" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inserir">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBxInserir" runat="server" 
                                                        Checked='<%# DataBinder.Eval(Container.DataItem,"Inserir") %>' 
                                                        CssClass="noborder" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Atualizar">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBxAtualizar" runat="server" 
                                                        Checked='<%# DataBinder.Eval(Container.DataItem,"Atualizar") %>' 
                                                        CssClass="noborder" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Excluir">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBxExcluir" runat="server" 
                                                        Checked='<%# DataBinder.Eval(Container.DataItem,"Excluir") %>' 
                                                        CssClass="noborder" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </caption>
                </table>
            </div>
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
