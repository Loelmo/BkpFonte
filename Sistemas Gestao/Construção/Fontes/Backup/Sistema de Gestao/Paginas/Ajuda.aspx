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
                                        <td colspan="2" style="background-color: Aqua" width="200">
                                            Telefone(s)
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            AC
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Vanessa Melo França
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            vanessa@ac.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            68
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3216-2186 / 9226-5717
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            AL
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Aline Gomes Canabarra
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            aline@al.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            82
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            4009-1611 / 9919-7541
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            AM
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Kátia Maria Santa Cruz Matos
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            katia@am.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            92
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            2121-4948 / 9627-0032
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            AP
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            José Augusto Cantuária Queiroz
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            augusto_queiroz@ap.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            96
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3312-2835 / 8111-2933
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            BA
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Marcelo Andrade de Oliveira
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            marcelo.oliveira@ba.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            71
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3320-4542 / 8716-4878
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            CE
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Joaquim Mendes Cavaleiro
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            cavaleiro@ce.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            85
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3255-6600/68 / 9989-8293
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            DF
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Adrianne Marques Brito Rocha
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            adrianne@df.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            61
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3362-1695 / 8409-0498
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            ES
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Andréa Gama de Oliveira
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            andrea.gama@es.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            27
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3041-5584 / 9979-0500
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            GO
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Lúcia Amélia de Queiroz
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            lucia@sebraego.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            62
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3250-2293 / 8111-0078
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            MA
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Claudia Cristina Sampaio Costa
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            claudiac@ma.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            98
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3216-6125 / 9974-3939
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            MG
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Michelle Chalub Cossenzo
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            michelle.cossenzo@sebraemg.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            31
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3379-9144 / 9194-4902
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            MS
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Assis Luiz de Souza
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            assis.luiz@ms.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            67
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3389-5581 /9954-4343
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            MT
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Edcleide Andrade Nobre
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            edcleide.nobre@mt.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            65
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3648-1270 / 9972-7930
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            PA
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Maria Domingas Ribeiro Paulino
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            domingas@pa.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            91
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3181-9140 / 8182-1901
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            PB
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Claudia do Nascimento Pereira
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            claudia@sebraepb.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            83
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            2108-1142 / 9984-0979
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            PE
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Evelyn Walter Kruppa
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            ekruppa@pe.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            81
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            2101-8458 / 9429-9379
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            PI
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Maurício Mendes Boavista de Castro
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            mauricio@pi.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            86
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3216-1362 / 9991-6666
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            PR
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            André Luis Rossi
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            arossi@pr.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            41
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3330-5841 / 9915-6605
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            RJ
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Juliana D’escoffier di Stasio
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            jstasio@rj.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            21
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            2212-7863
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            RN
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Etelvina Glae Olimpio Costa
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            etelvina@rn.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            84
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3616-7947 / 9985-9554 9979-6087
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            RO
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Cristiane de Cassia Bolonhez – T
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            cristiane@ro.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            69
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3217-3870 / 8113-1669
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            RR
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Andréia Ferreira Neres
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            andreianeres@rr.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            95
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            2121-8032 / 8114-7928
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            RS
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Dario Alberto Henke
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            darioh@sebrae-rs.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            51
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3216-5184 /
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            SC
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Josiane Minuzzi
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            josiane@sc.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            48
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3221-0800R-960/9928-7290
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            SE
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Adeilson Graça Leite
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            adeilson.leite@se.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            79
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            2106-7734 / 9949-3950
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#FFFFFF;">
                                        <td style="border:1px;border-color:Gray;">
                                            SP
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Julia de Gasperi Scarati
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            juliag@sp.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            11
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3177-4929
                                        </td>
                                    </tr>
                                    <tr style="color:#333333;background-color:#DDDDDD;">
                                        <td style="border:1px;border-color:Gray;">
                                            TO
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Izana Assunção Alves
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            Izana.assuncao@to.sebrae.com.br
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            63
                                        </td>
                                        <td style="border:1px;border-color:Gray;">
                                            3219-3335/01 / 8403-1756
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