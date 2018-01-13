<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="TesteFarol.aspx.cs" Inherits="PEG.FGA.Paginas.TesteFarol" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Chart ID="Chart1" runat="server" Height="530px" Width="769px" 
        BackColor="Transparent">
        <series>
            <asp:Series Name="Series1" 
                YValueType="DateTime" XValueMember="Ativo" YValueMembers="DtCadastro" >
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <Area3DStyle Enable3D="True" />
            </asp:ChartArea>
        </chartareas>
    </asp:Chart>
    
    </asp:Content>
