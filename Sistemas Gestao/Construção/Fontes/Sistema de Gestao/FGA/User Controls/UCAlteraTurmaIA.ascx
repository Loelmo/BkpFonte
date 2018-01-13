<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAlteraTurmaIA.ascx.cs" Inherits="Sistema_de_Gestao.FGA.User_Controls.UCAlteraTurmaIA" %>


<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldTurma" runat="server" />
        <fieldset>
              <legend id="LegEmpresa" style="font-size: large">Alterar Turma</legend>
            <br />
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td>
                        <asp:Label ID="lblTurma" runat="server" Text="Turma Atual:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtTurma" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtEmpresa" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" Text="Tipo da Turma:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipo" runat="server">
                            <asp:ListItem Text="Publicas" Value="0"></asp:ListItem>
                            <asp:ListItem Value="1">Privadas</asp:ListItem>
                            <asp:ListItem Selected="True" Value="2">Todas</asp:ListItem>
                        </asp:DropDownList>
                        <asp:ImageButton ID="ImgBttnPesquisar" runat="server" 
                            ImageUrl="~/Image/file_search2.png" onclick="ImgBttnPesquisar_Click" 
                            Style="width: 16px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblCategoria" runat="server" Text="Turma Destino:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTurma" runat="server" DataTextField="Turma" 
                            DataValueField="IdTurma" Height="22px" Width="300px">
                        </asp:DropDownList>
                    </td>
                </tr>
                
            </table>
            &nbsp;</fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" 
                ImageUrl="~/Image/_file_save.png" onclick="ImgBttnGravar_Click1" />
            <asp:ImageButton ID="ImgBttnCancelar1" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnCancelar_Click" />
        </div>
         
    </asp:Panel>
</div>
        <asp:HiddenField ID="HddnFldEmpresaCadastro" runat="server" />
        
