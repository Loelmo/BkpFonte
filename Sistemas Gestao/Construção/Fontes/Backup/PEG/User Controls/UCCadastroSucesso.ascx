﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroSucesso.ascx.cs"
    Inherits="PEG.User_Controls.UCCadastroSucesso" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<td>
    <asp:Panel ID="PnlFundo" runat="server" Width="825px" Height="210px" BackColor="Transparent"
        BorderColor="Black" Style="position: relative; top: 10%;">
                <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                    border="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblTitulo" runat="server" Text="A partir de agora você inicia o preenchimento das 32 questões, realizando o autodiagnóstico da gestão da sua empresa."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="Ao longo do preenchimento você poderá esclarecer dúvidas conceituais sobre as questões e os critérios e incluirá informações adicionais para algumas das alternativas escolhidas. Estas informações auxiliarão na seleção das empresas para o Programa PEG."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Veja mais informações nos menus acima “Como preencher” e “Glossário”."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" Text="As empresas que já preencheram o autodiagnóstico anteriormente, poderão acessar os relatórios através da seta “Histórico de Relatórios” e acompanhar a evolução da pontuação da sua empresa."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label4" runat="server" Text="Não se esqueça de enviar o autodiagnóstico assim que finalizar todo o preenchimento, que pode ser acompanhado através da seta “Enviar Questionário”."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="Após o envio você poderá gerar o Relatório de autoavaliação, com os pontos fortes e oportunidades de melhorias da sua empresa, através da seta “Histórico de Relatórios”."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Button ID="BtnHome" OnClick="BtnHome_Click" runat="server" Text="Ir para Home"
                                Width="40%" />
                        </td>
                    </tr>
                </table>
    </asp:Panel>
</td>
