<%@ Page Title="Turma" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroTurmaCE.aspx.cs" Inherits="Sistema_de_Gestao.FGA.Paginas.CadastroTurmaCE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../User Controls/UCCadastroTurmaIA.ascx" TagName="UCCadastroTurmaIA" TagPrefix="uc1" %>
<%@ Register Src="../User Controls/UCVisualizaEmpresaTurmaCE.ascx" TagName="UCVisualizaEmpresaTurmaCE" TagPrefix="uc2" %>



<%@ Register src="../../User Controls/UCGerenciarEtapaIA.ascx" tagname="UCGerenciarEtapaIA" tagprefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Turmas </h3>
    <fieldset>
        <legend>Pesquisa </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td width="30px">
                    <asp:Label ID="lblNome" runat="server" Text="Nome:"> </asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtNome" runat="server" Width="307px"></asp:TextBox>
                   
                </td>

                <td width="30px">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:"> </asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlTipo" runat="server" >
                        <asp:ListItem Text="Abertas" Value="0"></asp:ListItem>
                        <asp:ListItem Value="1">Fechadas</asp:ListItem>
                        <asp:ListItem Selected="True" Value="2">Todas</asp:ListItem>
                    </asp:DropDownList>
                </td>

                 <td width="30px">
                     &nbsp;</td>
                <td>
                    &nbsp;</td>

            <td>
                &nbsp;</td>
            


            </tr>
            <tr>
                <td width="30px">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado:"> </asp:Label>
                </td>
                <td class="style1">
                    <asp:DropDownList ID="ddlEstado" runat="server" DataValueField="IdEstado" DataTextField="Estado">
                        <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                   
                </td>

                <td width="30px">
                <asp:Label ID="lblDataInicio" runat="server" Text="Período de:"></asp:Label>
                </td>
                <td class="style2">
                <asp:TextBox ID="txtDataInicio" runat="server" Width="80px"></asp:TextBox>
                <cc1:MaskedEditExtender ID="MskdEdtExtndrCalendario" runat="server" MaskType="Date"
                    Mask="99/99/9999" TargetControlID="txtDataInicio">
                </cc1:MaskedEditExtender>
                <cc1:CalendarExtender ID="ClndrExtDataInicio" runat="server" Format="dd/MM/yyyy"
                    PopupButtonID="ImgBtnDataInicio" TargetControlID="txtDataInicio">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImgBtnDataInicio" runat="server" ImageUrl="~/Image/Calendario.gif" />
                </td>

                 <td width="30px">
                <asp:Label ID="lblDataFim" runat="server" Text="Até:"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtDataFim" runat="server" Width="80px"></asp:TextBox>
                <cc1:maskededitextender ID="MskdEdtExtndrCalendario2" runat="server" MaskType="Date"
                    Mask="99/99/9999" TargetControlID="txtDataFim">
                </cc1:maskededitextender>
                <cc1:calendarextender ID="ClndrExtDataFim" runat="server" Format="dd/MM/yyyy"
                    PopupButtonID="ImgBtnDataFim" TargetControlID="txtDataFim">
                </cc1:calendarextender>

                <asp:ImageButton ID="ImgBtnDataFim" runat="server" ImageUrl="~/Image/Calendario.gif" />
                </td>

            <td>
              <asp:ImageButton ID="ImgBttnPesquisar" runat="server" 
                    ImageUrl="~/Image/file_search2.png" Style="width: 20px" 
                    onclick="ImgBttnPesquisar_Click" />
            </td>
            


            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
        <legend>Lista de Turmas</legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td align="right">
                    <asp:ImageButton ID="ImgBtnIncluir" runat="server" 
                        ImageUrl="~/Image/_file_add2.png" onclick="ImgBtnIncluir_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <asp:GridView ID="grdTurmas" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" CssClass="Text_grid" Width="100%" DataKeyNames="IdTurma"
                            AutoGenerateColumns="false" onrowdatabound="grdTurmas_RowDataBound" 
                            onrowdeleting="grdTurmas_RowDeleting" 
                            onrowupdating="grdTurmas_RowUpdating" onrowcommand="grdTurmas_RowCommand" 
                            onpageindexchanging="grdTurmas_PageIndexChanging">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px"/>
                            <AlternatingRowStyle BackColor="White" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                             <asp:TemplateField HeaderText="IdTurma" Visible = "false">
                                    <ItemTemplate>
                                      <asp:Label ID="lblIdTurma" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "IdTurma")%>'></asp:Label>  
                                    </ItemTemplate>
                             </asp:TemplateField>


                                <asp:TemplateField HeaderText="Nome">
                                    <ItemTemplate>
                                     <asp:Label ID="lblNomeTurma" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "Turma")%>'></asp:Label>  
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="55%" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Tipo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipo" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container.DataItem, "Privada")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:TemplateField>
                               
                              
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                     <asp:Label ID="lblEstado" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="IdEstado" Visible = "false">
                                    <ItemTemplate>
                                     <asp:Label ID="lblIdEstado" runat="server" Visible="false" Text='  <%# DataBinder.Eval(Container.DataItem, "Estado.IdEstado")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Data Criação">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.DateUtils.ToString(Vinit.SG.Common.ObjectUtils.ToDate(DataBinder.Eval(Container.DataItem, "DtCadastro")))%>  
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Empresas">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAssociar" runat="server" ImageUrl="~/Image/_file_resume2.png"
                                         CommandName="VizualizaEmpresas" CommandArgument="<%# Container.DataItemIndex %>" CausesValidation="false"  />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Etapas">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAssociar2" runat="server" ImageUrl="~/Image/_file_resume2.png"
                                         CommandName="GerenciarEtapas" CommandArgument="<%# Container.DataItemIndex %>" CausesValidation="false"  />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ativar/Inativar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAcao" runat="server" ImageUrl="~/Image/file_delete.png" CommandName="Delete" Width="20px" CausesValidation="false" />
                                        <asp:Label ID="LblAcao" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Ativo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" ImageUrl="~/Image/file_edit2.png" Text="Editar" HeaderText="Editar"
                                            runat="server" CommandName="Update" />
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
  <uc1:UCCadastroTurmaIA ID="UCCadastroTurmaIA" runat="server" />   
  <uc2:UCVisualizaEmpresaTurmaCE ID="UCVisualizaEmpresaTurmaCE" runat="server" />  
    <uc3:UCGerenciarEtapaIA ID="UCGerenciarEtapaIA1" runat="server" />
    </asp:Content>
