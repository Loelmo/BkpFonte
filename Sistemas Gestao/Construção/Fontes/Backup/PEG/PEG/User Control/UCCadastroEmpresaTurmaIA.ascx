<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroEmpresaTurmaIA.ascx.cs" Inherits="PEG.FGA.User_Controls.UCCadastroEmpresaTurmaIA" %>


  <%@ Register src="UCIncluirPreCadastro.ascx" tagname="UCIncluirPreCadastro" tagprefix="uc1" %>


  <div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldTurma" runat="server" />
       
        <fieldset>
            <legend style="font-size: large">Filtros</legend>
            <br />
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
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
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" DataTextField="Estado" 
                            DataValueField="IdEstado" Height="22px" Width="300px" Visible="False">
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
                             ImageUrl="~/Image/_file_add2.png" onclick="ImgBtnIncluir_Click" 
                             Width="62px" />
                      </td>
                 </tr>
                    <tr>
                    
                        <td>
                            <div align="center">
                                <asp:GridView ID="grdEmpresasNaoInscritas" runat="server" AllowPaging="True" AllowSorting="True"
                                    PageSize="20" CssClass="Text_grid" Width="100%"  
                                    AutoGenerateColumns="False" 
                                    onpageindexchanging="grdEmpresasNaoInscritas_PageIndexChanging">
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
                                                <asp:Label ID="lblIdEmpresaCadastro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEmpresaCadastro")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Incluir">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkIncluir" runat="server" CssClass="noborder"  Checked='false'>
                                                </asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="CNPJ/CPF" Visible ="true">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "CPF_CNPJ")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Razão Social">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                                        </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNomeEmpresa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NomeFantasia")%>'></asp:Label>
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
                ImageUrl="~/Image/_file_save.png" onclick="ImgBttnGravar_Click" />
            <asp:ImageButton ID="ImgBttnCancelar1" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnCancelar_Click1" />
        </div>
      <uc1:UCIncluirPreCadastro ID="UCIncluirPreCadastro1" runat="server" />
    </asp:Panel>
</div>




<asp:HiddenField ID="HddnFldEstado" runat="server" />





