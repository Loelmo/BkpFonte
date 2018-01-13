<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEstado.ascx.cs" Inherits="Sistema_de_Gestao.User_Controls.UCEstado" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
    <tr>
        <td align="left">
            <asp:DropDownList ID="DrpDwnLstTurma" runat="server" Width="255px" TabIndex="1" DataValueField="IdTurma" DataTextField="Turma"
                onselectedindexchanged="DrpDwnLstTurma_SelectedIndexChanged" 
                AutoPostBack="True" >
                <asp:ListItem Selected="True" Text="<< Selecione a Turma >>" Value="0"></asp:ListItem>
            </asp:DropDownList>

            <span class="obrigatorio" runat="server" id="spTurma">*</span>
            
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="255px" DataValueField="IdEstado" DataTextField="Estado"
                TabIndex="2" onselectedindexchanged="DrpDwnLstEstado_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Selected="True" Text="<< Selecione o Estado >>" Value="0"></asp:ListItem>
            </asp:DropDownList>

            <span class="obrigatorio" runat="server" id="spEstado">*</span>
            

        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:DropDownList ID="DrpDwnLstEscritorioRegional" runat="server" Width="255px" DataValueField="IdEscritorioRegional" DataTextField="EscritorioRegional"
                TabIndex="3" AutoPostBack="True" 
                onselectedindexchanged="DrpDwnLstEscritorioRegional_SelectedIndexChanged">
                <asp:ListItem Selected="True" Text="<< Selecione o Escritório Regional >>" Value="0"></asp:ListItem>
            </asp:DropDownList>

            <span class="obrigatorio" runat="server" id="spEscritorioRegional">*</span>
            
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:DropDownList ID="DrpDwnLstRegiao" runat="server" Width="255px" DataValueField="IdEstadoRegiao" DataTextField="EstadoRegiao"
                TabIndex="4" AutoPostBack="True" 
                onselectedindexchanged="DrpDwnLstRegiao_SelectedIndexChanged" >   
                <asp:ListItem Selected="True" Text="<< Selecione a Regiao >>" Value="0"></asp:ListItem>
            </asp:DropDownList> 
            
            <span class="obrigatorio" runat="server" id="spRegiao">*</span>
            
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:DropDownList ID="DrpDwnLstCidade" runat="server" Width="255px"  
                DataValueField="IdCidade" DataTextField="Cidade"
                TabIndex="5"  AutoPostBack="True" 
                onselectedindexchanged="DrpDwnLstCidade_SelectedIndexChanged" >
                <asp:ListItem Selected="True" Text="<< Selecione a Cidade >>" Value="0"></asp:ListItem>
            </asp:DropDownList>   
            
            <span class="obrigatorio" runat="server" id="spCidade">*</span>
            
        </td>
    </tr>
    <tr>     
        <td align="left">
            <asp:DropDownList ID="DrpDwnLstBairro" runat="server" Width="255px" 
                TabIndex="9" DataValueField="IdBairro" DataTextField="Bairro">
                <asp:ListItem Selected="True" Text="<< Selecione o Bairro >>" Value="0"></asp:ListItem>
            </asp:DropDownList>

            <span class="obrigatorio" runat="server" id="spBairro">*</span>
            
        </td>
    </tr>
</table>