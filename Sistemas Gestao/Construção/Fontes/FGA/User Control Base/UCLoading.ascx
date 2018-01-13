<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLoading.ascx.cs" Inherits="Sistema_de_Gestão_de_Treinamento.User_Control_Base.UCLoading" %>

<div valign="middle" 
    style="BACKGROUND-IMAGE: url('/Image/BGLocked.png'); WIDTH: 100%; BACKGROUND-REPEAT: repeat; POSITION: absolute; z-index:1000; HEIGHT: 100%;LEFT: 0px; TOP: 0px">
    <asp:Panel ID="PnlAguardando" runat="server" style="POSITION: absolute; top: 35%; left: 45%; height: 65px; width: 135px;z-index:1000;" 
        BackColor="White" BorderColor="Lime">
       <table cellspacing="1" cellpadding="1" border="2" BORDERCOLOR="#000066">
	     <tr>
	       <td >
	          <table bgcolor="#ffffff">
		          <tr>
			        <td valign="middle" style="HEIGHT: 52px; width: 20px">
				        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/ico_carregando.gif" />
			        </td>
			        <td valign="middle" style="HEIGHT: 52px; width: 100px">
				        <asp:Label id="lblAguradando"  runat="server" font-size="14pt" text="Aguarde..."></asp:Label>
			        </td>
		          </tr>
	          </table>
		    </td>
	      </tr>
      </table>
    </asp:Panel>
</div>


