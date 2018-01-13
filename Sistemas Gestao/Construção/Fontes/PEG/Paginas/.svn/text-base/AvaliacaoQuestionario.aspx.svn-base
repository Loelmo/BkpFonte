<%@ Page Title="Avaliações" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="AvaliacaoQuestionario.aspx.cs" Inherits="PEG.Paginas.AvaliacaoQuestionario" %>

<%@ Register Src="/User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<%@ Register src="/User Controls/UCFiltroAvaliacao.ascx" tagname="UCFiltroAvaliacao" tagprefix="uc2" %>
<%@ Register src="/User Controls/UCListaQuestionariosAvaliacao.ascx" tagname="UCListaQuestionariosAvaliacao" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3> Avaliação de Empresas  </h3>
    <fieldset>
        <legend>Pesquisa </legend>
            <uc2:UCFiltroAvaliacao ID="UCFiltroAvaliacao1" runat="server" />
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnPesquisar" runat="server" 
                ImageUrl="~/Image/file_search2.png" onclick="ImgBttnPesquisar_Click"/>
        </div>
    </fieldset>
    <fieldset id="RankingSimplificado">
        <legend runat="server" id="TituloBoxSimplificado" visible="false">Lista de Empresas Simplificado</legend>
        <legend runat="server" id="TituloBoxDetalhado" visible="false">Lista de Empresas Detalhado</legend>

        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnExportar" runat="server" ImageUrl="~/Image/_file_export2.png" Visible="false"/>&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
<div style="width: 911px; overflow: auto" >
                        <asp:GridView ID="grdSimplificado" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="10" Width="900" AutoGenerateColumns="False" 
                            OnRowDataBound="grdSimplificado_RowDataBound" 
                            onpageindexchanging="grdSimplificado_PageIndexChanging" DataKeyNames="IdQuestionarioEmpresa"
                            onrowcommand="grdSimplificado_RowCommand" 
                            onrowupdating="grdSimplificado_RowUpdating" >
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="IdEmpresaCadastro" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEmpresaCadastro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEmpresaCadastro")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdEtapa" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEtapa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEtapa")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliado" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvaliado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Avaliado")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Devolvido" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDevolvido" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Devolvido")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdQuestionarioEmpresa" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQuestionarioEmpresa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdQuestionarioEmpresa")%>'></asp:Label>
                                        <asp:Label ID="lblProtocolo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Protocolo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CPF/CNPJ">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CpfCnpj")))%> 
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Razão Social">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Protocolo">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Protocolo")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Data Resposta">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "DtAlteracao")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Estado")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBttnAvaliar" runat="server" ImageUrl="~/Image/file_search2.png" CommandName="Avaliar" CommandArgument="<%# Container.DataItemIndex %>"/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RAA">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBttnFormulario" runat="server" ImageUrl="~/Image/_file_resume2.png" CommandName="Formulario" CommandArgument="<%# Container.DataItemIndex %>"/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motivo Devolução">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBttnDevolucao" runat="server" ImageUrl="~/Image/_file_back.png" CommandName="Devolucao" CommandArgument="<%# Container.DataItemIndex %>"/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px"/>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        </div> 
                </td>
            </tr>
        </table>
    </fieldset>
    <uc3:UCListaQuestionariosAvaliacao ID="UCListaQuestionariosAvaliacao1" runat="server" />
    <div id="divDevolucao" runat="server" class="ajudaCriterio" style="display: none;">
        <asp:Label ID="LblMotivoDevolução" runat="server" Text="Motivo de Devolução:"></asp:Label>
        <asp:TextBox ID="TxtDevolucao" Rows="5" TextMode="MultiLine" runat="server" Width="294px" Font-Names="Arial" Font-Size="12px" ReadOnly="true"/>
        <br clear="all" />
        <asp:ImageButton ID="btnFecharDevolucao" runat="server" ImageUrl="~/Image/_file_back2.png" OnClientClick="javascript:return cancelaDevolucao();"/>
    </div>
</asp:Content>
