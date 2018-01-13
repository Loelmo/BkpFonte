<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Etiqueta.aspx.cs" Inherits="PEG.MPE.Paginas.Etiqueta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Prêmio MPE - Impressão de Etiquetas</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <style type="text/css">
        BODY
        {
            font-size: 11px;
            margin: 0px;
        }
        .tabela
        {
            margin: -0.5cm 0cm 0px 0.38cm;
        }
        .tabela .td
        {
            padding-left: 0cm;
            width: 10.18cm;
            height: 2.54cm;
        }
        .tabelainterna
        {
            width: 10.18cm;
            height: 2.54cm;
        }
        .tabela .td .etiqueta
        {
            width: 10.16cm;
        }
        .paginacao
        {
            color: #333333;
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: none;
        }
        .npaginastop
        {
            z-index: 10;
            left: 0px;
            width: 100%;
            border-bottom: #cccccc 1px solid;
            font-family: Arial, Helvetica, sans-serif;
            position: absolute;
            top: 0px;
            height: 30px;
            background-color: #ffffff;
            text-align: center;
        }
        .npaginasbot
        {
            border-top: #cccccc 1px solid;
            margin-top: 10px;
            width: 100%;
            color: #333333;
            font-family: Arial, Helvetica, sans-serif;
            height: 15px;
            background-color: #ffffff;
            text-align: center;
        }
        .npaginastop A
        {
            padding-right: 3px;
            padding-left: 3px;
            margin-left: 1px;
            width: 16px;
            color: #333333;
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: none;
        }
        .npaginasbot A
        {
            padding-right: 3px;
            padding-left: 3px;
            margin-left: 1px;
            width: 16px;
            color: #333333;
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: none;
        }
        .npaginastop A:hover
        {
            color: #ffffff;
            background-color: #333333;
            text-decoration: none;
        }
        .npaginasbot A:hover
        {
            color: #ffffff;
            background-color: #333333;
            text-decoration: none;
        }
        .botao
        {
            padding-right: 0px;
            padding-left: 0px;
            padding-bottom: 0px;
            margin: 0px;
            padding-top: 0px;
        }
        A.botao:hover
        {
            background-color: #ffffff;
        }
        @media Print
        {
            .noprint
            {
                display: none;
            }
        }
        @media Screen
        {
            .noscreen
            {
                display: none;
            }
        }
    </style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div class="noprint npaginastop">
        <asp:PlaceHolder ID="phPaginacao" runat="server"></asp:PlaceHolder>
        &nbsp;<a href="javascript:self.print();"><img src="~/Image/print2.png" border="0"
            align="absMiddle"></a>
    </div>
    <div style="height: 50px" class="noprint">
    </div>
    <table class="tabela" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <br>
            <br>
        </tr>
        <asp:Repeater ID="repEtiqueta" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="td">
                        <!-- TABELA DE ETIQUETA -->
                        <table class="tabelainterna" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="etiqueta">
                                        <tr>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="lblRazaoSocial" runat="server">Nonono nononon oonon</asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>A/C </strong>
                                                <asp:Label ID="lblContato" runat="server">Nonono nononon oonon</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Endereço: </strong>
                                                <asp:Label ID="lblEndereco" runat="server">Nonono nononon oonon</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                CEP
                                                <asp:Label ID="lblCEP" runat="server">Nonono nononon oonon</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCidade" runat="server">Nonono nononon oonon</asp:Label>
                                                /
                                                <asp:Label ID="lblEstado" runat="server">Nonono nononon oonon</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <!-- FIM TABELA DE ETIQUETA -->
                    </td>
                    <!--td class="td"-->
                    <!--/td-->
            </ItemTemplate>
            <AlternatingItemTemplate>
                <td class="td">
                    <!-- TABELA DE ETIQUETA -->
                    <table class="tabelainterna" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="etiqueta">
                                    <tr>
                                        <td>
                                            <strong>
                                                <asp:Label ID="lblRazaoSocial" runat="server">Nonono nononon oonon</asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>A/C </strong>
                                            <asp:Label ID="lblContato" runat="server">Nonono nononon oonon</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Endereço: </strong>
                                            <asp:Label ID="lblEndereco" runat="server">Nonono nononon oonon</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            CEP
                                            <asp:Label ID="lblCEP" runat="server">Nonono nononon oonon</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCidade" runat="server">Nonono nononon oonon</asp:Label>
                                            /
                                            <asp:Label ID="lblEstado" runat="server">Nonono nononon oonon</asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <!-- FIM TABELA DE ETIQUETA -->
                    <!--/td-->
                    <tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
        <!--loop -->
        </TR>
    </table>
    <div class="noprint npaginasbot">
        <asp:PlaceHolder ID="phPaginacaoRodape" runat="server"></asp:PlaceHolder>
        &nbsp;<a href="javascript:self.print();"><img src="../../Image/print2.png" border="0"
            align="absMiddle"></a>
    </div>
    </form>
</body>
</html>
