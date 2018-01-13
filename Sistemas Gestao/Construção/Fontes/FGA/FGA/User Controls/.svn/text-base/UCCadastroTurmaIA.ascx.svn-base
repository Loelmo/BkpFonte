<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroTurmaIA.ascx.cs" 
Inherits="Sistema_de_Gestao.FGA.User_Control.UCCadastroTurmaIA" %>

  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
  <%@ Register Src="UCCadastroTurmaIAAddQuestionario.ascx" TagName="UCCadastroTurmaIAAddQuestionario" TagPrefix="uc1" %>
  <style type="text/css">
    .style1
    {
        width: 10px;
    }
    
</style>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldTurma" runat="server" />
        <fieldset>
            <legend style="font-size: large">Nova Turma</legend>
            <br />
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td>
                        <asp:Label ID="LblNome" runat="server" Text="Nome:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtNome" runat="server" Width="300"></asp:TextBox><span class="obrigatorio">*</span>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtDescricao" runat="server" Height="78px" 
                            TextMode="MultiLine" Width="300px" Font-Names="Arial" Font-Size="12px"></asp:TextBox><span class="obrigatorio">*</span>

                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Estado:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" DataTextField="Estado" 
                            DataValueField="IdEstado" Height="22px" Width="300px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
                    </td>
                     <td align="left"> 
                        <asp:RadioButtonList ID="rbTipo" runat="server" 
                            RepeatDirection="Horizontal" Width="300px">
                            <asp:ListItem Selected="True" Value="0">Aberta</asp:ListItem>
                            <asp:ListItem Value="1">Fechada</asp:ListItem>
                        </asp:RadioButtonList>
                         <asp:Button ID="btnGerarEtapas" runat="server" onclick="btnGerarEtapas_Click" 
                             Text="Gerar Etapas" Visible="False" />
                    </td>
                </tr>
                
            </table>
            <fieldset>
                <legend>Questionários</legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                  <tr>
                    <td align="right"> 
                         <asp:ImageButton ID="ImgBtnIncluir" runat="server" 
                             ImageUrl="~/Image/_file_add2.png" onclick="ImgBttnIncluir_Click" />
                    </td>
                 </tr>
                    <tr>
                    
                        <td>
                            <div align="center">
                                <asp:GridView ID="grdTurmaQuestionario" runat="server" AllowPaging="True" AllowSorting="True"
                                    PageSize="6" CssClass="Text_grid" Width="100%"  
                                    AutoGenerateColumns="False" 
                                    onrowdeleting="grdTurmaQuestionario_RowDeleting" 
                                    onrowdatabound="grdTurmaQuestionario_RowDataBound" 
                                    onrowupdating="grdTurmaQuestionario_RowUpdating" 
                                    onpageindexchanging="grdTurmaQuestionario_PageIndexChanging">
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
                                                <asp:Label ID="lblIdQuestionario" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Questionario.IdQuestionario")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Ordem de Aplicação" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrdem" runat="server" Text='<%# "0" %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Ordem" Visible ="false">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "Ordem")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Questionário">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "Questionario.Questionario")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Alterar Ordem">
                                         <ItemTemplate>
                                             <asp:ImageButton ID="ImagBttnOrdem" runat="server" ImageUrl="~/Image/_file_assoc2.png"
                                              CommandName="Update" Width="20px" CausesValidation="false" />
                                             
                                          </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                       </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Obrigatório?">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkObrigatorio" runat="server" CssClass="noborder"  Checked='<%# DataBinder.Eval(Container.DataItem,"Obrigatorio") %>'>
                                                </asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Excluir">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgExcluir" ImageUrl="~/Image/file_delete2.png" Text="Excluir"
                                                    HeaderText="Excluir" Width="20px" runat="server" CommandName="Delete" />
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
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server"
                ImageUrl="~/Image/_file_save.png" onclick="ImgBttnGravar_Click1" />
            <asp:ImageButton ID="ImgBttnCancelar1" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnCancelar_Click1" />
        </div>
          <uc1:UCCadastroTurmaIAAddQuestionario ID="UCCadastroTurmaIAAddQuestionario" runat="server" />   
    </asp:Panel>
</div>

