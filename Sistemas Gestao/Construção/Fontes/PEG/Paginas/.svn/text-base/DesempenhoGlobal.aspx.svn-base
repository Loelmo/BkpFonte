<%@ Page Title="Desempenho Global e Respostas dos Questionários" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="DesempenhoGlobal.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.DesempenhoGlobal" %>

<%@ Register Src="/User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="width: 900px; font-size: 12px; white-space: nowrap;">
        <legend>Pesquisa </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="CNPJ / CPF:"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxCNPJ_CPF" runat="server" Width="250" MaxLength="18" onKeyDown="Mascara(this,CpfCnpj);"
                        onKeyPress="Mascara(this,CpfCnpj);" onKeyUp="Mascara(this,CpfCnpj);" onBlur="Verifica_campo_CPF_CNPJ(this)"
                        TabIndex="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nome:"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxNome" runat="server" Width="250" TabIndex="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Turma:"> </asp:Label>
                </td>
                <td rowspan="6">
                    <uc1:UCEstado ID="UCEstado1" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="08" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Estado:"> </asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Escritório Regional:"> </asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Região:"> </asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Cidade:"> </asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Grupo:"> </asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Categoria:"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DrpDwnLstCategoria" runat="server" Width="255" DataValueField="IdCategoria"
                        DataTextField="Categoria" TabIndex="10">
                        <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Status:"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DrpDwnLstStatus" runat="server" Width="255" TabIndex="19">
                        <asp:ListItem Value="9" Selected="true">Classificada Estadual </asp:ListItem>
                        <asp:ListItem Value="12">Avaliação Estadual</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Prêmio Especiais:"> </asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChckBxPremiosEspeciais" runat="server" Text="Destaque de Boas Práticas de Responsabilidade Social	" />
                </td>
                <td>
                    <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/btn_processar.png"
                        OnClick="ImgBttnPesquisar_Click" TabIndex="24" />
                </td>
            </tr>
        </table>
        <div align="center" id="divGrafico" runat="server" visible="false">
            <table>
                <tr>
                    <td align="center" bgcolor="#8B8989" style="font-size: 12px; color: white">
                        Autoavaliação da Gestão - Desempenho Global das Empresas
                    </td>
                </tr>
                <tr>
                    <td align="center" bgcolor="#f0f0f0">
                        <asp:Image ID="imgGraficoRadarCorrente" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdDesempenhoGlobal2011" runat="server" AllowPaging="True" AllowSorting="True"
                            Width="100%" AutoGenerateColumns="False" ShowFooter="true">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <FooterStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                Não existem dados*
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="Critério">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Criterio")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotal" runat="server" ForeColor="White" Font-Bold="true" Text="Total"></asp:Label></FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Máxima">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoMaxima")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="130px" />
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalPontuacaoMaxima" runat="server" ForeColor="White" Font-Bold="true"
                                            Text="100,00%"></asp:Label></FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Obtida">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.DoubleUtils.ToString(Vinit.SG.Common.ObjectUtils.ToDouble(DataBinder.Eval(Container.DataItem, "PontuacaoObtida"))) + "%"%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="130px" />
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalPontuacaoObtida" ForeColor="White" Font-Bold="true" runat="server"></asp:Label></FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <asp:Panel ID="Panel1" runat="server" BackColor="White">
        <asp:Literal ID="ltrPerguntas" runat="server"></asp:Literal>
    </asp:Panel>
    <div style="background-color: White; color: White">
    </div>






</asp:Content>
