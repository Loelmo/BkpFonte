<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStatus.ascx.cs" Inherits="PEG.User_Controls.UCStatus" %>


<table aling="center" white="100%" style="margin-left:50px;">
    <tr>
        <td>
            <asp:ImageButton ID="ImgBttnPreencherCadastro" runat="server" ImageUrl="~/Image/PreencherCadastro1-2.png" 
                onclick="ImgBttnPreencherCadastro_Click" />
            <asp:ImageButton ID="ImgBttnResponderQuestionario" runat="server" ImageUrl="~/Image/ResponderQuestionario2-2.png" 
                onclick="ImgBttnResponderQuestionario_Click"/>
            <asp:ImageButton ID="ImgBttnEnviarQuestionario" runat="server" ImageUrl="~/Image/EnviarQuestionario2-2.png" 
                onclick="ImgBttnEnviarQuestionario_Click"/>
            <asp:ImageButton ID="ImgBttnVerificarRelatorios" runat="server" ImageUrl="~/Image/VerificarRelatorios2-2.png" 
                onclick="ImgBttnVerificarRelatorios_Click"/>

 
        </td>
    </tr>
</table>