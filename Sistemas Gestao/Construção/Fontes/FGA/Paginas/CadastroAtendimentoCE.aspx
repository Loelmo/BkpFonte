<%@ Page Title="Atendimentos" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroAtendimentoCE.aspx.cs" Inherits="Sistema_de_Gestao.CadastroAtendimentoCE" %>

<%@ Register Src="/User Controls/UCCadastroAtendimentoIA.ascx" TagName="UCCadastroAtendimentoIA" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h3> Cadastro de Atendimentos</h3>

        <fieldset>
        <legend> Pesquisa </legend>
             <table  width="100%" border="0" class="tabFiltros">
                <tr>
                    <td >
                        <asp:Label ID="Label4" runat="server" Text="Título:"></asp:Label>
                    </td>
                     <td>
                        <asp:TextBox ID="TxtBxTitulo" runat="server" Width="140" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    </td>
                    <td >
                        <asp:Label ID="Label1" runat="server" Text="Número de Atendimento:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxNumeroAtendimento" runat="server" Width="140" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    </td>
                    <td >
                        <asp:Label ID="Label2" runat="server" Text="Usuário Responsável:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxUsuarioResponsavel" runat="server" Width="140" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    </td>                             
                </tr>
                
               
                <tr>
                   
                    <td >
                        <asp:Label ID="Label7" runat="server" Text="Sistema:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DrpDwnLstSistema" runat="server" Width="120px" TabIndex="9"  DataValueField="IdAtendimentoSistema" DataTextField="AtendimentoSistema" Font-Names="Verdana" Font-Size="08">
                        </asp:DropDownList>
                    </td>
                    <td >
                        <asp:Label ID="Label8" runat="server" Text="Tipo:"></asp:Label>
                    </td>
                     <td>
                        <asp:DropDownList ID="DrpDwnLstTipo" runat="server" Width="120px" TabIndex="9"  DataValueField="IdAtendimentoTipo" DataTextField="AtendimentoTipo" Font-Names="Verdana" Font-Size="08">
                        </asp:DropDownList>
                    </td>
                    <td >
                        <asp:Label ID="Label3" runat="server" Text="Estado:"></asp:Label>
                    </td>
                     <td>
                        <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="120px" TabIndex="9"  DataValueField="IdEstado" DataTextField="Estado" Font-Names="Verdana" Font-Size="08">
                        </asp:DropDownList>
                    </td>                 
                
                </tr>
               <tr>
                    
                      <td >
                        <asp:Label ID="Label5" runat="server" Text="Status:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DrpDwnLstStatus" runat="server" Width="120px" TabIndex="9"  DataValueField="IdAtendimentoStatus" DataTextField="AtendimentoStatus" Font-Names="Verdana" Font-Size="08">
                        </asp:DropDownList>
                    </td>  
                    <td >
                        <asp:Label ID="Label6" runat="server" Text="Data de Cadastro:"></asp:Label>
                    </td>
                    <td>Início: 
                        <asp:TextBox ID="TxtBxDataInicio" runat="server" Width="70" TabIndex="7" Font-Names="Verdana" Font-Size="08" ></asp:TextBox>
                        <asp:ImageButton ID="ImgBttnCalendarioInicio" runat="server" TabIndex="8" ImageUrl="~/Image/Calendario.gif" />
                        <cc1:MaskedEditExtender ID="MskdEdtExtndrCalendarioInicio" runat="server" MaskType="Date"
                            Mask="99/99/9999" TargetControlID="TxtBxDataInicio">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="ClndrExtndrCalendarioInicio" runat="server" Format="dd/MM/yyyy"
                            PopupButtonID="ImgBttnCalendarioInicio" TargetControlID="TxtBxDataInicio">
                        </cc1:CalendarExtender>
                        </td>
                       <td>Fim: 
                        <asp:TextBox ID="TxtBxDataFim" runat="server" Width="70" TabIndex="7" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                        <asp:ImageButton ID="ImgBttnCalendarioFim" runat="server" TabIndex="8" ImageUrl="~/Image/Calendario.gif" />
                        <cc2:MaskedEditExtender ID="MskdEdtExtndrCalendarioFim" runat="server" MaskType="Date"
                            Mask="99/99/9999" TargetControlID="TxtBxDataFim">
                        </cc2:MaskedEditExtender>
                        <cc2:CalendarExtender ID="ClndrExtndrCalendarioFim" runat="server" Format="dd/MM/yyyy"
                            PopupButtonID="ImgBttnCalendarioFim" TargetControlID="TxtBxDataFim">
                        </cc2:CalendarExtender>
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
         <legend>Lista de Atendimentos </legend>
           <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="ImgBttnIncluir" runat="server" ImageUrl="~/Image/_file_add2.png" onclick="ImgBttnIncluir_Click" ToolTip="Incluir um novo Atendimento" />
                    </td>
                </tr>
               <tr>        
                     <td>
                        <div align="center" >
                        
                        <asp:GridView ID="grdAtendimento" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="10" Width="100%" DataKeyNames="IdAtendimento" AutoGenerateColumns="False"
                            OnPageIndexChanging="grdAtendimento_PageIndexChanging" 
                                onrowdeleting="grdAtendimento_RowDeleting" 
                                onrowdatabound="grdAtendimento_RowDataBound" 
                                onrowupdating="grdAtendimento_RowUpdating">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px"/>
                            <AlternatingRowStyle BackColor="White" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Número">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "IdAtendimento")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Título">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Titulo")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Tipo">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "AtendimentoTipo.AtendimentoTipo")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sistema">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "AtendimentoSistema.AtendimentoSistema")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "AtendimentoStatus.AtendimentoStatus")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Data de Cadastro">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "DataCadastro")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Última Alteração">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "DataAlteracao")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Usuário Responsável">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "UsuarioResponsavel.Usuario")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alterar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAlterar" runat="server" ImageUrl="~/Image/file_edit2.png"
                                         CommandName="Update" CausesValidation="false"  />
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


                            </Columns>
                        </asp:GridView>


                        </div>   
                     </td>
                   </tr>
               </table>
        </fieldset>    
        
        <uc1:UCCadastroAtendimentoIA ID="UCCadastroAtendimentoIA1" runat="server" />
</asp:Content>
