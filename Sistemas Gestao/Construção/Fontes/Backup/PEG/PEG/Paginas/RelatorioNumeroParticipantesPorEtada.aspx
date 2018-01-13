<%@ Page Title="Relação de Participantes por Etapa" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="RelatorioNumeroParticipantesPorEtada.aspx.cs"
    Inherits="PEG.MPE.Paginas.RelatorioNumeroParticipantesPorEtada" %>

<%@ Register Src="../User Control/UCFiltroRanking.ascx" TagName="UCFiltroRanking"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Relatório de Estatísticas - Participantes por Etapa
    </h3>
    <fieldset style="width: 950px; font-size: 12px; white-space: nowrap;">
        <legend>Pesquisa </legend>
        <div id="filtro">
            <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <uc1:ucfiltroranking id="UCFiltroRanking1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="ImgBttnPesquisar" OnClick="ImgBttnPesquisar_Click" runat="server"
                            ImageUrl="~/Image/pesquisar16.gif" />
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <br />
    <div align="center">
        <fieldset>
            <legend>Etapa por Estado</legend>
            <asp:GridView ID="grdEtapaEstado" runat="server" AllowPaging="True" AllowSorting="True"
                PageSize="27" CssClass="Text_grid" Width="100%" AutoGenerateColumns="false">
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Small" />
                <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                <HeaderStyle BackColor="#8B8989" ForeColor="White" HorizontalAlign="Center" Font-Size="Smaller" />
                <AlternatingRowStyle BackColor="White" />
                <EmptyDataTemplate>
                    <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lblEstado" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inscritas">
                        <ItemTemplate>
                            <asp:Label ID="lblInscritas" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container.DataItem, "TotalInscritas")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Candidatas">
                        <ItemTemplate>
                            <asp:Label ID="lblCandidatas" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalCandidatas")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Classificadas">
                        <ItemTemplate>
                            <asp:Label ID="lblClassificadas" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalClassificadas")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finalista Gestão">
                        <ItemTemplate>
                            <asp:Label ID="lblFinalistaGestao" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalFinalistasGestao")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finalista Responsabilidade Social">
                        <ItemTemplate>
                            <asp:Label ID="lblFinalistaRespSocial" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalFinalistasRespSocial")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finalista Inovação">
                        <ItemTemplate>
                            <asp:Label ID="lblFinalistaInovacao" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalFinalistasInovacao")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vencedora Gestão">
                        <ItemTemplate>
                            <asp:Label ID="lblVencedoraGestao" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalVencedoraGestao")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vencedora Responsabilidade Social">
                        <ItemTemplate>
                            <asp:Label ID="lblVencedoraRespSocial" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalVencedoraRespSocial")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vencedora Inovação">
                        <ItemTemplate>
                            <asp:Label ID="lblVencedoraInovacao" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalVencedoraInovacao")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <br />
    <div align="center">
        <fieldset>
            <legend>Percentual das Empresas por Estado</legend>
            <asp:Label ID="lblMsgGrafico1" runat="server" Font-Bold="True" Text="Nenhum registro encontrado para geração do grafico."></asp:Label>
            <br />
            <asp:PlaceHolder ID="phGraficoPercentualEstado" runat="server"></asp:PlaceHolder>
        </fieldset>
    </div>
    <br />
    <div>
        <fieldset>
            <legend>Etapa por Categoria</legend>
            <asp:GridView ID="grdCategoria" runat="server" AllowPaging="True" AllowSorting="True"
                PageSize="27" CssClass="Text_grid" Width="100%" AutoGenerateColumns="false">
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Small" />
                <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                <HeaderStyle BackColor="#8B8989" ForeColor="White" HorizontalAlign="Center" Font-Size="Smaller" />
                <AlternatingRowStyle BackColor="White" />
                <EmptyDataTemplate>
                    <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lblCategoria" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container.DataItem, "Categoria.Categoria")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inscritas">
                        <ItemTemplate>
                            <asp:Label ID="lblInscritas" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container.DataItem, "TotalInscritas")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Candidatas">
                        <ItemTemplate>
                            <asp:Label ID="lblCandidatas" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalCandidatas")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Classificadas">
                        <ItemTemplate>
                            <asp:Label ID="lblClassificadas" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalClassificadas")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finalista Gestão">
                        <ItemTemplate>
                            <asp:Label ID="lblFinalistaGestao" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalFinalistasGestao")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finalista Responsabilidade Social">
                        <ItemTemplate>
                            <asp:Label ID="lblFinalistaRespSocial" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalFinalistasRespSocial")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finalista Inovação">
                        <ItemTemplate>
                            <asp:Label ID="lblFinalistaInovacao" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalFinalistasInovacao")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vencedora Gestão">
                        <ItemTemplate>
                            <asp:Label ID="lblVencedoraGestao" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalVencedoraGestao")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vencedora Responsabilidade Social">
                        <ItemTemplate>
                            <asp:Label ID="lblVencedoraRespSocial" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalVencedoraRespSocial")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vencedora Inovação">
                        <ItemTemplate>
                            <asp:Label ID="lblVencedoraInovacao" runat="server" Visible="true" Text='  <%# DataBinder.Eval(Container.DataItem, "TotalVencedoraInovacao")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <br />
    <div align="center">
        <fieldset>
            <legend>Percentual das Empresas por Categoria</legend>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Nenhum registro encontrado para geração do grafico."></asp:Label>
            <br />
            <asp:PlaceHolder ID="phGraficoPercentualCategoria" runat="server"></asp:PlaceHolder>
        </fieldset>
    </div>
    

</asp:Content>
