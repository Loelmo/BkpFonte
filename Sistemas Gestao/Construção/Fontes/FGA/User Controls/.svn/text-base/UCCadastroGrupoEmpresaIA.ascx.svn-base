<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroGrupoEmpresaIA.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCCadastroGrupoEmpresaIA" %>
<%@ Register Src="UCCadastroGrupoEmpresaIncluir.ascx" TagName="UCCadastroGrupoEmpresaIncluir"
    TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="UCFiltrosHorizontalVertical.ascx" TagName="UCFiltrosHorizontalVertical"
    TagPrefix="uc3" %>



<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" CssClass="panelUC">

        <div style="height: 430px; overflow: auto" >

        <asp:HiddenField ID="HddnFldGrupo" runat="server" />
        <fieldset>
            <legend style="font-size: large">Cadastro de Grupo</legend>
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td  >
                        <asp:Label ID="LblNome" runat="server" Text="Nome:"></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="TxtNome" runat="server" Width="185px"></asp:TextBox><span
                                class="obrigatorio">*</span>
                    </td>
                    <td runat="server" id="tdLblTurma">
                        <asp:Label ID="lblTurma" runat="server" Text="Turma:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="DrpDwnLstTurma" runat="server" Width="200px" DataValueField="IdTurma"
                            DataTextField="Turma" OnSelectedIndexChanged="DrpDwnLstTurma_SelectedIndexChanged"
                            AutoPostBack="True">
                            <asp:ListItem Selected="True" Text="<< Seleciona uma Turma >>" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <span class="obrigatorio" runat="server" id="spTurma">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td Width="83px">
                        <asp:Label ID="lblSetor" runat="server"  Text="Setor:"> </asp:Label>
                    </td>
                    <td >
                        <asp:DropDownList ID="ddlSetor" runat="server" DataValueField="IdSetor" DataTextField="Setor">
                            <asp:ListItem Selected="True" Text="Selecione" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td runat="server" id="tdLblEstado">
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="200px" DataValueField="IdEstado"
                            DataTextField="Estado" >
                            <asp:ListItem Selected="True" Text="<< Seleciona uma Turma >>" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <span class="obrigatorio" runat="server" id="spEstado">*</span>
                        

                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtDescricao" runat="server" Rows="5" TextMode="MultiLine" Width="500" Height="50"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <fieldset>
                <legend>Lista de Empresas</legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="ImgBttnIncluir" runat="server" ImageUrl="~/Image/file_edit2.png"
                                OnClick="ImgBttnIncluir_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <asp:GridView ID="grdEmpresa" runat="server" AllowPaging="True" AllowSorting="True"
                                    PageSize="10" CssClass="Text_grid" Width="100%" DataKeyNames="IdEmpresaCadastro"
                                    AutoGenerateColumns="False" OnRowDeleting="grdEmpresa_RowDeleting" 
                                    onrowdatabound="grdEmpresa_RowDataBound">
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
                                        <asp:TemplateField HeaderText="Excluir">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgExcluir" ImageUrl="~/Image/button_cancel.gif" Text="Excluir" Width="18"
                                                    HeaderText="Excluir" runat="server" CommandName="Delete" />
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
        <div align="Center">
            <br />
            <%--<a href="javascript: void(document.getElementById('<%= divUserControl.ClientID%>').style.display = 'none');"><img src="/Image/cancelar16.gif" border="0" /></a>--%>
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png"
                OnClick="ImgBttnGravar_Click1" />&nbsp;&nbsp;
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click1" />
        </div>
        <uc2:UCCadastroGrupoEmpresaIncluir ID="UCCadastroGrupoEmpresaIncluir1" runat="server" />
        </div>
    </asp:Panel>
</div>
