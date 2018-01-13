<%@ Page Title="Ajuda" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="Ajuda.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.Ajuda" %>

<%@ Register Src="../User Control Base/UCLoading.ascx" TagName="UCLoading" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <fieldset >
        <legend style="font-weight: bold;">Ajuda </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td>
Se você tem alguma dúvida, sugestão ou deseja informações adicionais sobre o Programa Ferramentas de Gestão Avançada, entre em contato por e-mail com o
<asp:Button ID="BtnGestores" runat="server" Text="Gestor do seu Estado" OnClick="BtnAjuda_Click" CssClass="botaoFase"/>.
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/_file_back2.png"
                        OnClientClick="history.back(-1);" />
                </td>
            </tr>
        </table>
        <div id="divGestorEstadual" runat="server" visible="false" valign="middle" align="center"
            style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
            background-repeat: repeat; position: absolute; left: 0px; top: 0px">
            <asp:Panel ID="Panel1" runat="server" Width="800px" BackColor="White" BorderColor="Black"
                BorderStyle="Outset" BorderWidth="1" Style="position: relative; top: 10%; align: left">
                <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
                    <legend style="font-weight: bold;">Gestores Estaduais do FGA 2011 </legend>
                    <br />
                    <div id="divUC" runat="server" style="padding:8px;">
                        <table style="border:1px;border-color:Gray;border-style:outset;border-collapse:collapse;" width="100%" class="DivTable">
                            <tr>
                                <td style="background-color:#004A91;color:#FFFFFF;font-weight:bold;" width="30">
                                    UF
                                </td>
                                <td style="background-color:#004A91;color:#FFFFFF;font-weight:bold;" width="170">
                                    Gestor Estadual
                                </td>
                                <td style="background-color:#004A91;color:#FFFFFF;font-weight:bold;" width="200">
                                    E-mail
                                </td>
                            </tr>
                            <tr style="color:#333333;background-color:#DDDDDD;">
                                <td style="border:1px;border-color:Gray;">
                                    CE
                                </td>
                                <td>
                                    Mônica Arruda Lima
                                </td>
                                <td>
                                    monicalima@ce.sebrae.com.br
                                </td>
                            </tr>
                            <tr style="color:#333333;background-color:#FFFFFF;">
                                <td>
                                    PE
                                </td>
                                <td>
                                    Isabel Noblat
                                </td>
                                <td>
                                    inoblat@pe.sebrae.com.br
                                </td>
                            </tr>
                            <tr style="color:#333333;background-color:#DDDDDD;">
                                <td>
                                    PR
                                </td>
                                <td>
                                    Rosângela Angonese
                                </td>
                                <td>
                                    rangonese@sebraepr.com.br
                                </td>
                            </tr>
                            <tr style="color:#333333;background-color:#FFFFFF;">
                                <td>
                                    RS
                                </td>
                                <td>
                                    Carlos Eduardo Aranha
                                </td>
                                <td>
                                    carlosa@sebrae-rs.com.br
                                </td>
                            </tr>
                            <tr style="color:#333333;background-color:#DDDDDD;">
                                <td>
                                    SC
                                </td>
                                <td>
                                    Paulo Teixeira
                                </td>
                                <td>
                                    paulot@sc.sebrae.com.br
                                </td>
                            </tr>
                            <tr style="color:#333333;background-color:#FFFFFF;">
                                <td>
                                    SP
                                </td>
                                <td>
                                    Marcos Evandro Galini
                                </td>
                                <td>
                                    marcoseg@sebraesp.com.br
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center">
                        <asp:ImageButton ID="ImgBttnFechar" runat="server" ImageUrl="~/Image/_file_back2.png"
                            OnClick="ImgBttnFechar_Click" />
                    </div>
                </fieldset>
                <br />
            </asp:Panel>
        </div>
    </fieldset>
</asp:Content>