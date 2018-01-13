<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRelatorioRAARE.ascx.cs"
    Inherits="PEG.MPE.User_Controls.UCRelatorioRAARE" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="800px" BackColor="White" BorderColor="Black"
        BorderStyle="Outset" BorderWidth="1" Style="position: relative; top: 10%;">
        <fieldset>
            <legend style="font-size: large">Relatorio RA/RAA</legend>
            <br />
            <table>
                <tr>
                    <td>
                        <CR:CrystalReportSource ID="Crs" runat="server">
                        </CR:CrystalReportSource>
                        <CR:CrystalReportViewer ID="Crv" runat="server" HasRefreshButton="True" AutoDataBind="true" 
                            ReportSourceID="Crs" HyperlinkTarget="_new" HasCrystalLogo="False" ToolbarStyle-BackColor="#C0FFFF"
                            ToolbarStyle-BorderColor="White" EnableDrillDown="False" HasDrillUpButton="False"
                            HasToggleGroupTreeButton="False" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/cancelar16.gif"
                OnClick="ImgBttnCancelar_Click" />
        </div>
    </asp:Panel>
</div>
