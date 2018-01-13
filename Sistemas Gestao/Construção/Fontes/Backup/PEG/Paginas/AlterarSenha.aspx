<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="AlterarSenha.aspx.cs" Inherits="PEG.Paginas.AlterarSenha" %>

<%@ Register Src="../User Control Base/UCLoading.ascx" TagName="UCLoading" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <fieldset >
        <legend style="font-weight: bold;">Alterar Senha </legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label3" runat="server" Text="Para alterar a sua senha inclua abaixo o seu login e senha anteriores e a sua nova senha, que deve ter de seis a vinte caracteres."></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="30%">
                    <asp:Label ID="LblLogin" runat="server" Text="Login:"></asp:Label>
                </td>
                <td width="80%">
                    <asp:TextBox ID="TxtBxLogin" runat="server" Width="200px" MaxLength="50" Enabled="false"
                        TabIndex="1" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="30%">
                    <asp:Label ID="LblSenha" runat="server" Text="Antiga Senha:"></asp:Label>
                </td>
                <td width="80%">
                    <asp:TextBox ID="TxtBxAntigaSenha" runat="server" Width="200px" MaxLength="50" TabIndex="2"
                        TextMode="Password"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvAntigaSenha" runat="server" ControlToValidate="TxtBxAntigaSenha"
                            Display="None" ErrorMessage="Antiga Senha é Obrigatória!" ValidationGroup="vgAlterarSenha"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <cc2:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvAntigaSenha">
                        </cc2:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td width="30%">
                    <asp:Label ID="Label1" runat="server" Text="Nova Senha (de 6 a 20 caracteres):"></asp:Label>
                </td>
                <td width="80%">
                    <asp:TextBox ID="TxtBxNovaSenha" runat="server" Width="200px" MaxLength="50" TabIndex="2"
                        TextMode="Password"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="rfvNovaSenha" runat="server" ControlToValidate="TxtBxNovaSenha"
                                Display="None" ErrorMessage="Nova Senha Obrigatório!" ValidationGroup="vgAlterarSenha"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc2:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvNovaSenha">
                            </cc2:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td width="30%">
                    <asp:Label ID="Label2" runat="server" Text="Confirma Senha:"></asp:Label>
                </td>
                <td width="80%">
                    <asp:TextBox ID="TxtBxConfirmaSenha" runat="server" Width="200px" MaxLength="50" TabIndex="2"
                        TextMode="Password"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="rfvConfirmaSenha" runat="server" ControlToValidate="TxtBxConfirmaSenha"
                                Display="None" ErrorMessage="Confirma Senha Obrigatório!" ValidationGroup="vgAlterarSenha"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc2:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="rfvConfirmaSenha">
                            </cc2:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="As Senhas estão diferente!"
                                ControlToCompare="TxtBxNovaSenha" ControlToValidate="TxtBxConfirmaSenha" ValidationGroup="vgAlterarSenha"
                                Text="*"></asp:CompareValidator>
                            <cc2:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="CompareValidator1">
                            </cc2:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td width="30%">
                </td>
                <td width="80%">
                    <br />
                    <asp:ImageButton ID="ImgBttnConfirma" runat="server" ImageUrl="~/Image/_file_save.png"
                        TabIndex="3" onclick="ImgBttnConfirma_Click" ValidationGroup="vgAlterarSenha" />&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="ImgBttnCancela" runat="server" ImageUrl="~/Image/_file_back2.png"
                        TabIndex="3" onclick="ImgBttnCancela_Click" />
                </td>
            </tr>
        </table>
    </fieldset>


</asp:Content>