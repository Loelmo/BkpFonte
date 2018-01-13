<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCExportarInscritas.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCExportarInscritas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/User Controls/UCConfirmaExportarInscritas.ascx" TagName="UCConfirmaExportarInscritas"
    TagPrefix="uc2" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="900px"  BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%; font-size: 11px;">
        <fieldset class="fieldsetUC">
            <legend style="font-size: medium">Itens</legend>
            <table cellspacing="1" cellpadding="1" width="850px;" border="0" style="text-align: left;">
                <tr>
                    <td width="100%">
                        <asp:CheckBoxList ID="chkListCampos" TextAlign="Right" runat="server" RepeatColumns="2" Width="100%"
                            RepeatDirection="Horizontal" CellPadding="-1" CellSpacing="-1">
                            <asp:ListItem Text="Razão Social" Value="TX_RAZAO_SOCIAL"  Selected="True" />
                            <asp:ListItem Text="Nome Fantasia" Value="TX_NOME_FANTASIA" Selected="True" />
                            <asp:ListItem Text="CPF/CNPJ" Value="TX_CPF_CNPJ" Selected="True" />
                            <asp:ListItem Text="Data da Abertura da Empresa" Value="DT_ABERTURA_EMPRESA" Selected="True" />
                            <asp:ListItem Text="Número de Colaboradores" Value="NU_FUNCIONARIO" Selected="True" />
                            <asp:ListItem Text="Endereço" Value="TX_ENDERECO" Selected="True" />
                            <asp:ListItem Text="Bairro" Value="CEA_BAIRRO" Selected="True" />
                            <asp:ListItem Text="Cidade" Value="CEA_CIDADE" Selected="True" />
                            <asp:ListItem Text="Estado" Value="CEA_ESTADO" Selected="True" />
                            <asp:ListItem Text="CEP" Value="TX_CEP" Selected="True" />
                            <asp:ListItem Text="Tipo de Empresa" Value="CEA_TIPO_EMPRESA" Selected="True" />
                            <asp:ListItem Text="Faturamento Anual em 2010" Value="CEA_FATURAMENTO" Selected="True" />
                            <asp:ListItem Text="Setor" Value="CEA_CATEGORIA" Selected="True" />
                            <asp:ListItem Text="Atividade Econômica" Value="CEA_ATIVIDADE_ECONOMICA" Selected="True" />
                            <asp:ListItem Text="Principal Atividade Ecônomica" Value="TX_ATIVIDADE_ECONOMICA" Selected="True" />
                            <asp:ListItem Text="Nome Completo do Contato" Value="TX_NOME_CONTATO" Selected="True" />
                            <asp:ListItem Text="CPF do Contato" Value="TX_CPF_CONTATO" Selected="True" />
                            <asp:ListItem Text="Bairro do Contato" Value="BairroContato" Selected="True" />
                            <asp:ListItem Text="Cidade do Contato" Value="CidadeContato" Selected="True" />
                            <asp:ListItem Text="Estado do Contato" Value="EstadoContato" Selected="True" />
                            <asp:ListItem Text="CEP do Contato" Value="CEPContato" Selected="True" />
                            <asp:ListItem Text="Cargo do Contato" Value="TX_CARGO_CONTATO" Selected="True" />
                            <asp:ListItem Text="Endereço Completo do Contato" Value="TX_ENDERECO_CONTATO" Selected="True" />
                            <asp:ListItem Text="Telefone Fixo do Contato" Value="TX_TELEFONE_CONTATO" Selected="True" />
                            <asp:ListItem Text="Celular do Contato" Value="TX_CELULAR_CONTATO" Selected="True" />
                            <asp:ListItem Text="Email do Contato" Value="TX_EMAIL_CONTATO" Selected="True" />
                            <asp:ListItem Text="Data de Nascimento do Contato" Value="DT_DATA_NASCIMENTO_CONTATO" Selected="True" />
                            <asp:ListItem Text="Sexo do Contato" Value="TX_SEXO_CONTATO" Selected="True" />
                            <asp:ListItem Text="Nível de Escolaridade do Contato" Value="CEA_NIVEL_ESCOLARIDADE" Selected="True" />
                            <asp:ListItem Text="Faixa Etária do Contato" Value="CEA_FAIXA_ETARIA" Selected="True" />
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <fieldset>
                            <legend style="font-size: medium">Formato</legend>
                            <table cellspacing="1" cellpadding="1" width="100%;" border="0" style="text-align: left;">
                                <tr>
                                    <td valign="top">
                                        <asp:RadioButtonList ID="rdList" runat="server" RepeatDirection="Horizontal" 
                                            Width="358" onselectedindexchanged="rdList_SelectedIndexChanged" AutoPostBack="true" >
                                            <asp:ListItem Text="Excel 2007" Value="Excel" ></asp:ListItem>
                                            <asp:ListItem Text="Open Document" Value="OpenDocument"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td valign="top">
                                        <asp:CheckBox ID="chkZip" runat="server" Text="Compactar (*.ZIP)"  width="300"/>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="center">
            <br />
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImgBttnExportar" runat="server" ImageUrl="~/Image/_file_export2.png"
                            OnClick="ImgBttnExportar_Click"  />&nbsp;&nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                            OnClick="ImgBttnCancelar_Click" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <uc2:UCConfirmaExportarInscritas ID="UCUCConfirmaExportarInscritas1" runat="server"/>
</div>
