<%@ Page Title="Importação" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="Importacao.aspx.cs" Inherits="PEG.Paginas.Importacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3> Importação de Dados</h3>

    <fieldset>
    <legend> Opções </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
            <tr>
                <td >
                    <asp:Label ID="Label1" runat="server" Text="Dados De Turmas Antigas:"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="TxtBoxPrograma" runat="server" Text="" Font-Names="Verdana" Font-Size="08"/>
                </td>
                <td >
                    <asp:Button ID="Label6" runat="server" Text="Executar" onclick="Label6_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label2" runat="server" Text="SIAC - Estados"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button1" runat="server" Text="Executar" 
                        onclick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label3" runat="server" Text="SIAC - Cidades"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button2" runat="server" Text="Executar" 
                        onclick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label4" runat="server" Text="SIAC - Bairros"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button3" runat="server" Text="Executar" 
                        onclick="Button3_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label5" runat="server" Text="SIAC - Atividades Econômicas"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button4" runat="server" Text="Executar" 
                        onclick="Button4_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label7" runat="server" Text="SIAC - Cargos"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button5" runat="server" Text="Executar" 
                        onclick="Button5_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label8" runat="server" Text="SIAC - Escolaridades"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button6" runat="server" Text="Executar" 
                        onclick="Button6_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label9" runat="server" Text="SIAC - Faturamentos"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button7" runat="server" Text="Executar" 
                        onclick="Button7_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label10" runat="server" Text="SIAC - Portes"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button8" runat="server" Text="Executar" 
                        onclick="Button8_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label11" runat="server" Text="SIAC - Setores"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button9" runat="server" Text="Executar" 
                        onclick="Button9_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label12" runat="server" Text="SIAC - Tipos Empresas"></asp:Label>
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="Button10" runat="server" Text="Executar" 
                        onclick="Button10_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>

