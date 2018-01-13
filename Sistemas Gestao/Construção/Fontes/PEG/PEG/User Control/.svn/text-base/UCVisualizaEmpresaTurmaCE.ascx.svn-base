<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCVisualizaEmpresaTurmaCE.ascx.cs" Inherits="PEG.FGA.User_Controls.UCVisualizaEmpresaTurmaIA" %>



  <%@ Register src="UCAlteraTurmaIA.ascx" tagname="UCAlteraTurmaIA" tagprefix="uc1" %>



  <%@ Register src="UCCadastroEmpresaTurmaIA.ascx" tagname="UCCadastroEmpresaTurmaIA" tagprefix="uc2" %>



  <div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldTurma" runat="server" />
        <asp:HiddenField ID="HddnFldNomeTurma" runat="server" />
        <fieldset>
            <legend style="font-size: large">Filtros</legend>
            <br />
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;" class="tabFiltros">
                <tr>
                    <td>
                        <asp:Label ID="lblCnpjCpf" runat="server" Text="CNPJ/CPF:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtCnpjCpf" runat="server" Width="300" MaxLength="18" onKeyDown="Mascara(this,CpfCnpj);"
                            onKeyPress="Mascara(this,CpfCnpj);" onKeyUp="Mascara(this,CpfCnpj);"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblNome" runat="server" Text="Nome:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtNome" runat="server" Width="300"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblCategoria" runat="server" Text="Categoria:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategoria" runat="server" DataTextField="Categoria" 
                            DataValueField="IdCategoria" Height="22px" Width="300px">
                        </asp:DropDownList>
                    </td>
                    <td align = "right">
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" DataTextField="Estado" 
                            DataValueField="IdEstado" Height="22px" Width="300px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="ImgBttnPesquisar" runat="server" 
                            ImageUrl="~/Image/file_search2.png" onclick="ImgBttnPesquisar_Click" 
                            Style="width: 20px" />
                    </td>
                </tr>
                
            </table>
            <fieldset>
                <legend>Empresas</legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                  <tr>
                    <td align="right"> 
                         <asp:ImageButton ID="ImgBtnIncluir" runat="server" 
                             ImageUrl="~/Image/file_edit2.png" onclick="ImgBttnIncluir_Click" />
                    </td>
                 </tr>
                    <tr>
                    
                        <td>
                            <div align="center">
                                <asp:GridView ID="grdEmpresasCadastradas" runat="server" AllowPaging="True" 
                                    AllowSorting="True" CssClass="Text_grid" Width="100%"  
                                    AutoGenerateColumns="False" 
                                    onrowcommand="grdEmpresasCadastradas_RowCommand" 
                                    onrowdeleting="grdEmpresasCadastradas_RowDeleting" 
                                    onrowdatabound="grdEmpresasCadastradas_RowDataBound" 
                                    onpageindexchanging="grdEmpresasCadastradas_PageIndexChanging">
                                    <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                                    <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                    <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <EmptyDataTemplate>
                                        Não existem dados*
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdEmpresaCadastro" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdEmpresaCadastro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.IdEmpresaCadastro")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="CNPJ/CPF" Visible ="true">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.CPF_CNPJ")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Razão Social">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.RazaoSocial")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                                        </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNomeEmpresa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.NomeFantasia")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Categoria">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "Categoria.Categoria")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        </asp:TemplateField>


                                       <asp:TemplateField HeaderText="Trocar Turma">
                                         <ItemTemplate>
                                             <asp:ImageButton ID="ImagBttnOrdem" runat="server" ImageUrl="~/Image/_file_assoc2.png"
                                              CommandName="AlterarTurma" CommandArgument="<%# Container.DataItemIndex %>"  Width="20px" CausesValidation="false" />
                                          </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                       </asp:TemplateField>
                                        
                                       
                                        <asp:TemplateField HeaderText="Inativar na Turma">
                                           <ItemTemplate>
                                            <asp:ImageButton ID="ImagBttnAcao" runat="server" ImageUrl="~/Image/file_delete2.png" CommandName="Delete" Width="20px" CausesValidation="false" />
                                            <asp:Label ID="LblAcao" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Ativo")%>'></asp:Label>
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
           
            <asp:ImageButton ID="ImgBttnCancelar1" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnCancelar_Click1" />
        </div>
      <uc1:UCAlteraTurmaIA ID="UCAlteraTurmaIA1" runat="server" />
       <uc2:UCCadastroEmpresaTurmaIA ID="UCCadastroEmpresaTurmaIA1" runat="server" />
    </asp:Panel>
</div>


        <asp:HiddenField ID="HddnFldExibeEstado" runat="server" />
        


