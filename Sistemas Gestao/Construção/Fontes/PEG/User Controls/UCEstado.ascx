<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEstado.ascx.cs" Inherits="PEG.User_Controls.UCEstado" %>
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
            <asp:RequiredFieldValidator ID="rfvTurma" runat="server" ControlToValidate="DrpDwnLstTurma"
                ErrorMessage="Turma Obrigatória!" ValidationGroup="vgInserir" Display="None" InitialValue="0"
                SetFocusOnError="true"></asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="vcTurma" runat="server" TargetControlID="rfvTurma">
            </cc1:ValidatorCalloutExtender>
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
            <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="DrpDwnLstEstado"
                ErrorMessage="Estado Obrigatório!" ValidationGroup="vgInserir" Display="None" InitialValue="0"
                SetFocusOnError="true"></asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="vcEstado" runat="server" TargetControlID="rfvEstado">
            </cc1:ValidatorCalloutExtender>

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
            <asp:RequiredFieldValidator ID="rfvEscritorioRegional" runat="server" ControlToValidate="DrpDwnLstEscritorioRegional"
                ErrorMessage="Escritório Regional Obrigatório!" ValidationGroup="vgInserir" Display="None" InitialValue="0"
                SetFocusOnError="true"></asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="vcEscritorioRegional" runat="server" TargetControlID="rfvEscritorioRegional">
            </cc1:ValidatorCalloutExtender>
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
            <asp:RequiredFieldValidator ID="rfvRegiao" runat="server" ControlToValidate="DrpDwnLstRegiao"
                ErrorMessage="Região Obrigatório!" ValidationGroup="vgInserir" Display="None" InitialValue="0"
                SetFocusOnError="true"></asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="vcRegiao" runat="server" TargetControlID="rfvRegiao">
            </cc1:ValidatorCalloutExtender>                       
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
            <asp:RequiredFieldValidator ID="rfvCidade" runat="server" ControlToValidate="DrpDwnLstCidade"
                ErrorMessage="Cidade Obrigatório!" ValidationGroup="vgInserir" Display="None" InitialValue="0"
                SetFocusOnError="true"></asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="vcCidade" runat="server" TargetControlID="rfvCidade">
            </cc1:ValidatorCalloutExtender>                   
        </td>
    </tr>
    <tr>     
        <td align="left">
            <asp:DropDownList ID="DrpDwnLstBairro" runat="server" Width="255px" 
                TabIndex="9" DataValueField="IdBairro" DataTextField="Bairro">
                <asp:ListItem Selected="True" Text="<< Selecione o Bairro >>" Value="0"></asp:ListItem>
            </asp:DropDownList>

            <span class="obrigatorio" runat="server" id="spBairro">*</span>
            <asp:RequiredFieldValidator ID="rfvBairro" runat="server" ControlToValidate="DrpDwnLstBairro"
                ErrorMessage="Bairro Obrigatório!" ValidationGroup="vgInserir" Display="None" InitialValue="0"
                SetFocusOnError="true"></asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="vcBairro" runat="server" TargetControlID="rfvBairro">
            </cc1:ValidatorCalloutExtender> 
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:DropDownList ID="DrpDwnLstGrupo" runat="server" Width="255px" DataValueField="IdGrupo" DataTextField="Grupo">
                <asp:ListItem Selected="True" Text="<< Selecione o Grupo >>" Value="0"></asp:ListItem>
            </asp:DropDownList>

            <span class="obrigatorio" runat="server" id="spGrupo">*</span>
            <asp:RequiredFieldValidator ID="rfvGrupo" runat="server" ControlToValidate="DrpDwnLstGrupo"
                ErrorMessage="Grupo Obrigatório!" ValidationGroup="vgInserir" Display="None" InitialValue="0"
                SetFocusOnError="true"></asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="vcGrupo" runat="server" TargetControlID="rfvGrupo">
            </cc1:ValidatorCalloutExtender> 
        </td>    
    </tr>

</table>