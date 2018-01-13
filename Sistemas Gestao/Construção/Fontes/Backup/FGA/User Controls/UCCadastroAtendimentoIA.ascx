<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroAtendimentoIA.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCCadastroAtendimentoIA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="880px" BackColor="White" BorderColor="Black"
        BorderStyle="Outset" BorderWidth="1" Style="position: relative; top: 10%;">
        <asp:HiddenField ID="HddnFldIdAtendimento" runat="server" />
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;">Cadastro Atendimento </legend>
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0" class="tabFiltros">
                <tr>
                    <td width="1%" align="right">
                        <asp:Label ID="Label5" runat="server" Text="Ativo:"></asp:Label>
                    </td>
                    <td width="50%" align="left">
                        <asp:CheckBox ID="ChckBxAtivo" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="LblNome" runat="server" Text="Título:"></asp:Label>
                    </td>
                    <td width="20%" align="left">
                        <asp:TextBox ID="TxtBxNome" runat="server" Width="300px" MaxLength="30" TabIndex="1"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label1" runat="server" Text="Descrição:"></asp:Label>
                    </td>
                    <td width="20%" align="left">
                        <asp:TextBox ID="TxtBxDescricao" runat="server" Width="300px" MaxLength="30" TabIndex="1" TextMode="MultiLine" Rows="6" Font-Names="Arial" Font-Size="12px"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label7" runat="server" Text="Status:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:DropDownList ID="DrpDwnLstStatus" runat="server" Width="205px" TabIndex="9" DataValueField="IdAtendimentoStatus" DataTextField="AtendimentoStatus">
                        </asp:DropDownList><span class="obrigatorio">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label8" runat="server" Text="Tipo:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:DropDownList ID="DrpDwnLstTipo" runat="server" Width="205px" TabIndex="9" DataValueField="IdAtendimentoTipo" DataTextField="AtendimentoTipo">
                        </asp:DropDownList><span class="obrigatorio">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label9" runat="server" Text="Sistema:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:DropDownList ID="DrpDwnLstSistema" runat="server" Width="205px" TabIndex="9" DataValueField="IdAtendimentoSistema" DataTextField="AtendimentoSistema">
                        </asp:DropDownList><span class="obrigatorio">*</span>
                        
                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png"
                OnClick="ImgBttnGravar_Click"  />&nbsp;&nbsp;
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click" />&nbsp;&nbsp;
        </div>
    </asp:Panel>
</div>
