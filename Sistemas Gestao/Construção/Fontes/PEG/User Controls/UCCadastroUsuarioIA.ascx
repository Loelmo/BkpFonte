<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCadastroUsuarioIA.ascx.cs"
    Inherits="PEG.User_Controls.UCCadastroUsuarioIA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="800px" BackColor="White" BorderColor="Black"
        BorderStyle="Outset" BorderWidth="1" Style="position: relative; top: 10%;">
        <asp:HiddenField ID="HddnFldIdUsuario" runat="server" />
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;">Cadastro Usuário </legend>
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0">
                <tr>
                    <td width="1%" align="right">
                        <asp:Label ID="Label5" runat="server" Text="Ativo:"></asp:Label>
                    </td>
                    <td width="50%" align="left">
                        <asp:CheckBox ID="ChckBxAtivo" runat="server" Checked="true" TabIndex="9"/>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label6" runat="server" Text="CPF:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:TextBox ID="TxtBxCPF" runat="server" Width="150px" MaxLength="14" TabIndex="10"
                            onKeyDown="Mascara(this,Cpf);" onKeyPress="Mascara(this,Cpf);" onKeyUp="Mascara(this,Cpf);"
                            onBlur="Verifica_campo_CPF(this)"></asp:TextBox><span class="obrigatorio">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="LblNome" runat="server" Text="Nome:"></asp:Label>
                    </td>
                    <td width="20%" align="left">
                        <asp:TextBox ID="TxtBxNome" runat="server" Width="300px" MaxLength="30" TabIndex="11"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td width="10%" align="right">
                        <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:TextBox ID="TxtBxLogin" runat="server" Width="200px" MaxLength="40" TabIndex="12"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <div id="divSenha" runat="server">
                            <asp:TextBox ID="TxtBxSenha" runat="server" Width="200px" MaxLength="40" TabIndex="13"
                                TextMode="Password"></asp:TextBox><span class="obrigatorio">*</span>
                            
                        </div>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="lblConfSenha" runat="server" Text="Confirma Senha:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <div id="divConfSenha" runat="server">
                            <asp:TextBox ID="TxtBxConfSenha" runat="server" Width="200px" MaxLength="40" TabIndex="14"
                                TextMode="Password"></asp:TextBox><span class="obrigatorio">*</span>
                            
                        </div>
                    </td>
                </tr>
                
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label7" runat="server" Text="Telefone:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:TextBox ID="TxtBxTelefone" runat="server" Width="150px" MaxLength="14" TabIndex="16"
                            onKeyDown="Mascara(this,Telefone);" onKeyPress="Mascara(this,Telefone);" onKeyUp="Mascara(this,Telefone);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label8" runat="server" Text="E-Mail:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:TextBox ID="TxtBxEmail" runat="server" Width="400px" MaxLength="50" TabIndex="17" onBlur="ValidaEmail(this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="Label4" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="205px" TabIndex="18" DataValueField="IdEstado" DataTextField="Estado">
                        </asp:DropDownList><span class="obrigatorio">*</span>

                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png" TabIndex="19"
                OnClick="ImgBttnGravar_Click" />
                &nbsp;&nbsp; 
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png" TabIndex="20"
                OnClick="ImgBttnCancelar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;  
        </div>
    </asp:Panel>
</div>
