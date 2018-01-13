<%@ Page Title="Preenchimento de Inscrições" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="RelatorioEstatisticoInscritas.aspx.cs" Inherits="Sistema_de_Gestao.RelatorioEstatisticoInscritas" %>

<%@ Register Src="../User Control/UCFiltroRanking.ascx" TagName="UCFiltroRanking"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Relatório de Estatísticas - Preenchimento de Inscrições
    </h3>
    <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
        <tr>
            <td>
                <fieldset style="width: 911px; font-size: 12px; white-space: nowrap;">
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
                                        ImageUrl="~/Image/file_search2.png" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div align="center" style="overflow: auto; width: 980px">
                    <asp:Panel ID="pnTotal" runat="server">
                        <asp:Repeater ID="repTotal" runat="server" OnItemDataBound="repTotal_ItemDataBound">
                            <HeaderTemplate>
                                <p>
                                    <strong>Total de empresas inscritas no Prêmio: </strong>
                                </p>
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tr>
                                        <td valign="top">
                                            <table height="220" cellspacing="2" cellpadding="2" width="100%" align="center" border="0">
                                                <tr>
                                                    <td bgcolor="#e2e9f1" align="center">
                                                        Categoria
                                                    </td>
                                                    <td bgcolor="#e2e9f1" align="center">
                                                        Inscrições realizadas por meio de digitadores
                                                    </td>
                                                    <td bgcolor="#e2e9f1" align="center">
                                                        Inscrições realizadas pelas próprias empresas
                                                    </td>
                                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr bgcolor="#adcce1">
                                    <td>
                                        <asp:Label ID="lblCategoria" runat="server" Font-Size="11px">Nonono nononon oonon</asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblQtdDigitador" runat="server" Font-Size="11px">00</asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblQtdEmpresa" runat="server" Font-Size="11px">00</asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr bgcolor="#c7dceb">
                                    <td>
                                        <asp:Label ID="lblCategoria" runat="server" Font-Size="11px">Nonono nononon oonon</asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblQtdDigitador" runat="server" Font-Size="11px">00</asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblQtdEmpresa" runat="server" Font-Size="11px">00</asp:Label>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                <tr bgcolor="#e2e9f1">
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Font-Size="11px">Total:</asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblTotDigitador" runat="server" Font-Size="11px">00</asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblTotEmpresa" runat="server" Font-Size="11px">00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#e2e9f1">
                                        <div align="right">
                                            <font color="#ffffff"><strong></strong></font>
                                        </div>
                                    </td>
                                    <td bgcolor="#044267" colspan="2">
                                        <div align="center">
                                            <font color="#ffffff"><strong>
                                                <asp:Label ID="lblTotalGeral" runat="server" Font-Size="11px">00</asp:Label></strong></font></div>
                                    </td>
                                </tr>
                                </table> </td> </tr> </table>
                                <br>
                                <br>
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tr>
                                        <td valign="top" align="center">
                                            <asp:PlaceHolder ID="phGrafico" runat="server">Aqui vai o gráfico</asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tr>
                                        <td valign="top" align="center">
                                            <asp:PlaceHolder ID="phGraficoRealizada" runat="server">Aqui vai o gráfico de percentual
                                                realizadas</asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                    <strong>
                        <asp:Label ID="lblMensagemEstado" runat="server" Visible="False">Nenhuma inscrição encontrada para o filtro informado</asp:Label></strong>
                    <asp:Repeater ID="repEstado" runat="server" OnItemDataBound="repEstado_ItemDataBound">
                        <HeaderTemplate>
                            <table cellspacing="2" cellpadding="2" width="100%" border="0">
                                <tr>
                                    <td height="10">
                                        <img height="1" src="/admin/images/dot_transparent.gif" width="1">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" height="0">
                                        <img height="1" src="/admin/images/relatorio/img_linha.gif" width="570">
                                    </td>
                                </tr>
                            </table>
                            <p>
                                <strong>Total de empresas inscritas no Prêmio por Estado: </strong>
                            </p>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <p>
                                <strong>
                                    <asp:Label ID="lblEstado" runat="server">Estado</asp:Label></strong></p>
                            <asp:Repeater ID="repEstadoItem" runat="server">
                                <HeaderTemplate>
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tr>
                                            <td valign="top">
                                                <table height="220" cellspacing="2" cellpadding="2" width="100%" align="center" border="0">
                                                    <tr>
                                                        <td bgcolor="#e2e9f1" align="center">
                                                            Categoria
                                                        </td>
                                                        <td bgcolor="#e2e9f1" align="center">
                                                            Inscrições realizadas por meio de digitadores
                                                        </td>
                                                        <td bgcolor="#e2e9f1" align="center">
                                                            Inscrições realizadas pelas próprias empresas
                                                        </td>
                                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr bgcolor="#adcce1">
                                        <td>
                                            <asp:Label ID="lblCategoria" runat="server" Font-Size="11px">Nonono nononon oonon</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblQtdDigitador" runat="server" Font-Size="11px">00</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblQtdEmpresa" runat="server" Font-Size="11px">00</asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr bgcolor="#c7dceb">
                                        <td>
                                            <asp:Label ID="lblCategoria" runat="server" Font-Size="11px">Nonono nononon oonon</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblQtdDigitador" runat="server" Font-Size="11px">00</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblQtdEmpresa" runat="server" Font-Size="11px">00</asp:Label>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <FooterTemplate>
                                    <tr bgcolor="#e2e9f1">
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" Font-Size="11px">Total:</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblTotDigitador" runat="server" Font-Size="11px">00</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblTotEmpresa" runat="server" Font-Size="11px">00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#e2e9f1">
                                            <div align="right">
                                                <font color="#ffffff"><strong></strong></font>
                                            </div>
                                        </td>
                                        <td bgcolor="#044267" colspan="2">
                                            <div align="center">
                                                <font color="#ffffff"><strong>
                                                    <asp:Label ID="lblTotalGeral" runat="server" Font-Size="11px">00</asp:Label></strong></font></div>
                                        </td>
                                    </tr>
                                    </table> </td> </tr> </table>
                                    <br>
                                    <br>
                                    <table cellspacing="1" cellpadding="3" class="tdAzulEscuro" width="100%" align="center"
                                        border="0">
                                        <tr>
                                            <td align="center" class="tdAzulEscuro">
                                                Percentual de Empresas Inscritas por Categoria
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#F0F0F0" valign="top" align="center">
                                                <asp:PlaceHolder ID="phGrafico" runat="server">Aqui vai o gráfico</asp:PlaceHolder>
                                            </td>
                                        </tr>
                                    </table>
                                    <br>
                                    <table cellspacing="1" cellpadding="3" class="tdAzulEscuro" width="100%" align="center"
                                        border="0">
                                        <tr>
                                            <td align="center" class="tdAzulEscuro">
                                                Percentual de Empresas Inscritas por meio de Digitadores e pelas próprias Empresas
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#F0F0F0" valign="top" align="center">
                                                <asp:PlaceHolder ID="phGraficoRealizada" runat="server">Aqui vai o gráfico de percentual
                                                    realizadas</asp:PlaceHolder>
                                            </td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                            <p>
                                &nbsp;</p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
