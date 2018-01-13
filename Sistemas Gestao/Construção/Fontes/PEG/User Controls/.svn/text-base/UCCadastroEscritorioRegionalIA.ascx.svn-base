<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroEscritorioRegionalIA.ascx.cs"
    Inherits="PEG.User_Controls.UCCadastroEscritorioRegionalIA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .style1
    {
        width: 101px;
    }
    .style3
    {
        font-size: small;
    }
    .style2
    {
        width: 186px;
    }
</style>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundoIA" runat="server" Width="800px" Height="360px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%;">
        <asp:HiddenField ID="HddnFldIdEscritorioRegional" runat="server" />
        <fieldset>
            <legend style="font-size: large">Cadastro de Escritório Regional</legend>
            <br />
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblCiclo" runat="server" Text="Turma:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DrpDwnLstTurma" runat="server" Width="200px" DataValueField="IdTurma"
                            DataTextField="Turma" OnSelectedIndexChanged="DrpDwnLstTurma_SelectedIndexChanged"
                            AutoPostBack="True">
                            <asp:ListItem Selected="True" Text="<< Seleciona uma Turma >>" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <span class="obrigatorio" runat="server" id="spTurma">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="200px" DataValueField="IdEstado"
                            DataTextField="Estado" AutoPostBack="True" 
                            onselectedindexchanged="DrpDwnLstEstado_SelectedIndexChanged" >
                            <asp:ListItem Selected="True" Text="<< Seleciona uma Turma >>" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <span class="obrigatorio" runat="server" id="spEstado">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblEscritorioRegional" runat="server" Text="Escritório Regional:"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtEscritorioRegional" Width="400" runat="server"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="Ativo" runat="server" Text="Ativo:"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkAtivo" runat="server" Checked="True" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label runat="server" Text="Cidades" />
                    </td>
                    <td class="style1">
                        <asp:Label class="style3" ID="lblCidadesDisponiveis" runat="server" Text="Disponíveis"></asp:Label>
                        <br />
                        <asp:ListBox ID="lstCidadesDisponiveis" runat="server" DataTextField="Cidade" DataValueField="IdCIdade"
                            Height="100" SelectionMode="Multiple" Width="300"></asp:ListBox>
                    </td>
                    <td align="center" style="width: 50px;">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text=" &gt; " 
                            ToolTip="Mover para direita" CausesValidation="False" />
                        <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text=" &lt; "
                            ToolTip="Mover para esquerda" CausesValidation="False" />
                    </td>
                    <td>
                        <asp:Label class="style3" ID="lblCidadesSelecionadas" runat="server" Text="Selecionadas"></asp:Label>
                        <br />
                        <asp:ListBox ID="lstCidadesSelecionadas" runat="server" DataTextField="Cidade" DataValueField="IdCIdade"
                            Height="100" SelectionMode="Multiple" Width="300"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png"
                OnClick="ImgBttnGravar_Click" />&nbsp;&nbsp;
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click" CausesValidation="False" />&nbsp;&nbsp;
        </div>
    </asp:Panel>
</div>
