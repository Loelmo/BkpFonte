<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTurmaEmpresaArquivoIA.ascx.cs" Inherits="Sistema_de_Gestao.User_Controls.UCTurmaEmpresaArquivoIA" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="divUserControl" runat="server"  visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="800px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%;">

        <asp:HiddenField ID="HddnFldIdTurmaEmpresaArquivo" runat="server" />
        <asp:HiddenField ID="HddnFldIdEmpresaCadastro" runat="server" />
        <asp:HiddenField ID="HddnFldIdTurma" runat="server" />
        <asp:HiddenField ID="HddnFldArquivo" runat="server" />
        
        <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px">
            <legend style="font-weight: bold;"> Plano de Ação </legend>
            <div id="divUC" runat="server" class="divUC">
            <table class="DivTable" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0">
                <tr>
                    <td width="20%" align="right">
                        <asp:Label ID="LblNome" runat="server" Text="Título:"></asp:Label>
                    </td>
                    <td width="20%" align="left">
                        <asp:TextBox ID="TxtBxNome" runat="server" Width="300px" MaxLength="30"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="TxtBxNome"
                            Display="None" ErrorMessage="Título Obrigatório!" ValidationGroup="vgCadastroArquivo"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="10%" align="right">
                        <asp:Label ID="Label1" runat="server" Text="Conteúdo:"></asp:Label>
                    </td>
                    <td width="60%" align="left">
                        <cc1:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" />
                        <span class="obrigatorio">*</span>
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
