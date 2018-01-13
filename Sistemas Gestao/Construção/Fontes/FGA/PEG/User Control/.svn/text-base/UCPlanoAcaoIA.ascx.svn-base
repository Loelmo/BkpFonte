<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPlanoAcaoIA.ascx.cs" Inherits="Sistema_de_Gestao.User_Controls.UCPlanoAcaoIA" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="divUserControl" runat="server"  visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="800px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%;">

        <asp:HiddenField ID="HddnFldIdPlanoAcao" runat="server" />
        <asp:HiddenField ID="HddnFldIdEmpresaCadastro" runat="server" />
        <asp:HiddenField ID="HddnFldIdTurma" runat="server" />
        
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;"> Plano de Ação </legend>
            <div id="divUC" runat="server" class="divUC">
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0">
                <tr>
                    <td width="20%">
                        <asp:Label ID="LblPlanoAcao" runat="server" Text="Identificação:"></asp:Label>
                    </td>
                    <td width="1%"></td>
                    <td width="80%">
                        <asp:TextBox ID="TxtBxPlanoAcao" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label1" runat="server" Text="Pontos de Melhoria:"></asp:Label>
                    </td>
                    <td width="1%"></td>
                    <td width="80%">
                        <asp:TextBox ID="TxtBxPontoMelhoria" runat="server" Width="500" Height="180px" TextMode="MultiLine" Font-Names="Arial" Font-Size="12px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label2" runat="server" Text="Ações Correspondentes:"></asp:Label>
                    </td>
                    <td width="1%"></td>
                    <td width="80%">
                        <asp:TextBox ID="TxtBxAcaoCorrespondente" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label3" runat="server" Text="Responsáveis:"></asp:Label>
                    </td>
                    <td width="1%"></td>
                    <td width="80%">
                        <asp:TextBox ID="TxtBxResponsavel" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label4" runat="server" Text="Prazos:"></asp:Label>
                    </td>
                    <td width="1%"></td>
                    <td width="80%">
                        <asp:TextBox ID="TxtBxPrazo" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
            </table>
            </div>
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png"
                OnClick="ImgBttnGravar_Click" />
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnCancelar_Click"/>
        </div>
    </asp:Panel>
</div>
