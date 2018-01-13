<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="RelDesempenhoGlogal.aspx.cs" Inherits="Sistema_de_Gestao.FGA.Paginas.RelDesempenhoGlogal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Chart ID="Chart1" runat="server">
        <Series>
            <asp:Series ChartType="Radar" Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>
