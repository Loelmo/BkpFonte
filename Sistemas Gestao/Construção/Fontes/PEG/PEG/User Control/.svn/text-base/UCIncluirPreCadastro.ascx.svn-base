<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCIncluirPreCadastro.ascx.cs" Inherits="PEG.FGA.User_Controls.UCIncluirPreCadastro" %>



  <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



  <div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldTurma" runat="server" />
       
        <fieldset>
            <legend style="font-size: large">Pré-Cadastro da Empresa</legend>
            <br />
            <table cellspacing="1" cellpadding="1" width="100%" border="0" style="text-align: left;">
                <tr>
                    <td>
                        <asp:Label ID="lblCnpjCpf" runat="server" Text="CNPJ/CPF:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtCnpjCpf" runat="server" Width="300" onKeyDown="Mascara(this,CpfCnpj);" onKeyPress="Mascara(this,CpfCnpj);" onKeyUp="Mascara(this,CpfCnpj);"
                                MaxLength="18" onBlur="Verifica_campo_CPF_CNPJ(this)"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblNome" runat="server" Text="Razão Social:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtNome" runat="server" Width="300"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" DataTextField="Estado" 
                            DataValueField="IdEstado" Height="22px" Width="300px">
                        </asp:DropDownList>
                        <span class="obrigatorio">*</span></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblResponsavel" runat="server" Text="Nome Responsavél:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtResponsavel" runat="server" Width="300"></asp:TextBox>
                        <span class="obrigatorio">*</span></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEMail" runat="server" Text="E-Mail:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtEmail" runat="server" Width="300"></asp:TextBox><span
                            class="obrigatorio">*</span>
                        </td>
                </tr>
                
            </table>
           
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnGravar" runat="server" 
                ImageUrl="~/Image/_file_save.png" onclick="ImgBttnGravar_Click" />
            <asp:ImageButton ID="ImgBttnCancelar1" runat="server" 
                ImageUrl="~/Image/_file_back2.png" onclick="ImgBttnCancelar_Click1" />
        </div>
      
      </asp:Panel>
</div>


<asp:HiddenField ID="HddnFldEstado" runat="server" />



