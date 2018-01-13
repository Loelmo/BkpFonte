<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroGrupoUsuarioIA.ascx.cs" Inherits="PEG.User_Controls.UCCadastroGrupoUsuarioIA" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="divUserControl" runat="server"  visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundoIA" runat="server" Width="800px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%;">

        <asp:HiddenField ID="HddnFldIdGrupo" runat="server" />
        <asp:HiddenField ID="HddnFldIdGrupoUsuario" runat="server" />
        
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;" runat="server" id="legendaAssociacao"> Nova Associação </legend>
            <div id="divUC" class="divUC">
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0">
                <tr>
                    <td width="20%">
                        <asp:Label ID="LblNome" runat="server" Text="Turma:"></asp:Label>
                    </td>
                    <td width="1%"></td>
                    <td width="80%">
                        <asp:DropDownList ID="DrpDwnLstTurma" runat="server" Width="200px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="DrpDwnLstTurma_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label1" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td width="1%"></td>
                    <td width="80%">
                        <asp:DropDownList ID="DrpDwnLstEstado" runat="server"  Width="200px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="DrpDwnLstEstado_SelectedIndexChanged"
                            DataTextField="Estado" DataValueField="IdEstado">
                            <asp:ListItem Selected="True" Text="Nacional" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label2" runat="server" Text="Escritório Regional:"></asp:Label>
                    </td>
                    <td width="1%"></td>
                    <td width="80%">
                        <asp:DropDownList ID="DrpDwnLstEscritorioRegional" runat="server"  Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Usuários disponiveis:"></asp:Label>
                    </td>
                    <td width="1%">&nbsp;</td>
                    <td>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Coloque aqui os Usuários escolhidos:"></asp:Label>                        
                    </td>
                </tr>
                <tr>
                    <td width="50%">
                        <asp:ListBox ID="LstBxUsuariosDisponiveis" runat="server" Width="100%" 
                            Height="280px" SelectionMode="Multiple"></asp:ListBox>
                    </td>
                    <td width="1%">
                        <asp:Button ID="BttnParaAssociados" runat="server" Text=">>" 
                            onclick="BttnParaAssociados_Click" />
                        <asp:Button ID="BttnParaDisponiveis" runat="server" Text="<<" 
                            onclick="BttnParaDisponiveis_Click" /> <br />
                    </td>
                    <td>
                        <asp:ListBox ID="LstBxUsuariosAssociados" runat="server" Width="100%" 
                                Height="280px" SelectionMode="Multiple"></asp:ListBox>
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
