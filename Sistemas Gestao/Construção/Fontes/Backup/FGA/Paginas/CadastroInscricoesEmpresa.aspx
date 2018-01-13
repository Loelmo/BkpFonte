<%@ Page Title="Cadastro Inscrição Empresa" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="CadastroInscricoesEmpresa.aspx.cs" Inherits="Sistema_de_Gestao.Paginas.CadastroInscricoesEmpresa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="..\User Controls\UCSelecionaCNAE.ascx" TagName="UCSelecionaCNAE"
    TagPrefix="uc2" %>
<%@ Register Src="../User Controls/UCStatus.ascx" TagName="UCStatus" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <uc1:UCStatus ID="UCStatus1" runat="server" />
    </div>
    <h3>
        Ficha de Cadastro</h3>
    <asp:HiddenField ID="HddnFldIdInscricaoEmpresa" runat="server" />
    <asp:HiddenField ID="HddnFldIdProgramaEmpresa" runat="server" />
    <asp:HiddenField ID="HddnFldSenha" runat="server" />
    <asp:HiddenField ID="HddnFldCepAnterior" runat="server" />
    <asp:HiddenField ID="HddnFldCepAnteriorContato" runat="server" />
    <div align="right">
        <asp:Button ID="ImgBttnBaixar" runat="server" Text="Importar Dados" OnClick="ImgBttnBaixar_Click"
            Visible="false" CausesValidation="false" />
    </div>
    <fieldset runat="server" id="Etapa1">
        <legend>Dados da Empresa </legend>
        <table cellspacing="1" cellpadding="1" align="center" border="0" class="tabFiltros">
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Razão Social:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxRazaoSocial" TabIndex="1" runat="server" Width="250" Font-Names="Verdana"
                        Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Tipo de Empresa:"></asp:Label>
                </td>
                <td colspan="2">
                    <ajaxToolkit:ComboBox ID="CmbBxTipoEmpresa" runat="server" TabIndex="14" AutoPostBack="False" DropDownStyle="DropDownList"
                         AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" DataTextField="TipoEmpresa" 
                         DataValueField="IdTipoEmpresa" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Nome Fantasia:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxNomeFantasia" runat="server" TabIndex="2" Width="250" Font-Names="Verdana"
                        Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Faturamento Anual (2010):"></asp:Label>
                </td>
                <td colspan="2">
                    <ajaxToolkit:ComboBox ID="CmbBxFaturamento" runat="server" TabIndex="15" AutoPostBack="False" DropDownStyle="DropDownList"
                         AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" DataTextField="Faturamento" 
                         DataValueField="IdFaturamento" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblCPF_CNPJ" runat="server" Text="CNPJ:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxCNPJCPF" runat="server" Width="250" TabIndex="3" MaxLength="18"
                        onKeyDown="Mascara(this,CpfCnpj);" onKeyPress="Mascara(this,CpfCnpj);" onKeyUp="Mascara(this,CpfCnpj);"
                        onBlur="Verifica_campo_CPF_CNPJ(this)" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Setor:"></asp:Label>
                </td>
                <td colspan="2">
                    <ajaxToolkit:ComboBox ID="CmbBxCategoria" runat="server" TabIndex="16" AutoPostBack="False" DropDownStyle="DropDownList"
                         AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" DataTextField="Categoria" 
                         DataValueField="IdCategoria" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Dt Abertura da empresa:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxDataAbertura" TabIndex="4" runat="server" Width="80" Font-Names="Verdana"
                        Font-Size="08"></asp:TextBox>
                    <asp:ImageButton ID="ImgBttnCalendario" runat="server" ImageUrl="~/Image/Calendario.gif"
                        CausesValidation="false" TabIndex="99" />
                    <span class="obrigatorio">*</span>
                    <cc1:MaskedEditExtender ID="MskdEdtExtndrCalendario" runat="server" MaskType="Date"
                        Mask="99/99/9999" TargetControlID="TxtBxDataAbertura">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="ClndrExtndrCalendario" runat="server" Format="dd/MM/yyyy"
                        PopupButtonID="ImgBttnCalendario" TargetControlID="TxtBxDataAbertura">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Atividade Econômica:"></asp:Label>
                </td>
                <td align="left" style="vertical-align: top;" colspan="2">
                    <asp:LinkButton ID="LnkBttnSelecionaAtividadeEconomica" TabIndex="17" runat="server"
                        OnClick="LnkBttnSelecionaAtividadeEconomica_Click">Clique aqui para selecionar</asp:LinkButton>
                    <br />
                    <asp:TextBox ID="TxtBoxAtividadeEconomica" runat="server" Width="245px" ReadOnly="true"
                        TabIndex="40" MaxLength="300"></asp:TextBox><span class="obrigatorio"> *</span>
                    <asp:HiddenField ID="HddnIdAtividadeEconomica" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Número de Colaboradores:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxNumeroEmpregados" TabIndex="5" runat="server" Width="125" MaxLength="10"
                        onKeyDown="Mascara(this,Integer);" onKeyPress="Mascara(this,Integer);" onKeyUp="Mascara(this,Integer);"
                        Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Descreva a principal atividade:"></asp:Label>
                </td>
                <td rowspan="4" colspan="2">
                    <asp:TextBox ID="TxtBxPrincipalAtividade" TabIndex="18" runat="server" Height="100"
                        Width="250" TextMode="MultiLine" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label18" runat="server" Text="CEP:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxCEP" runat="server" TabIndex="6" Width="125" MaxLength="9"
                        onKeyDown="Mascara(this,Cep);" onKeyPress="Mascara(this,Cep);" onKeyUp="Mascara(this,Cep);"
                        onBlur="Verifica_CEP(this)" Font-Names="Verdana" Font-Size="08" ></asp:TextBox>
                    <span class="obrigatorio">*</span>
                    <asp:Button runat="server" ID="HlnkBuscaCep" TabIndex="7" CssClass="linkBotao" OnClick="ImgBttnBuscarCep_Click" Text="Buscar Endereço" CausesValidation="false"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Estado:"></asp:Label>
                </td>
                <td>
                    <ajaxToolkit:ComboBox ID="CmbBxEstado" runat="server" TabIndex="8" AutoPostBack="true" DropDownStyle="DropDownList" 
                         AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" OnSelectedIndexChanged="DrpDwnLstEstado_SelectedIndexChanged" DataTextField="Estado"
                        DataValueField="IdEstado" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label17" runat="server" Text="Cidade:"></asp:Label>
                </td>
                <td>
                    <ajaxToolkit:ComboBox ID="CmbBxCidade" runat="server" TabIndex="9" AutoPostBack="true" DropDownStyle="DropDownList" 
                         AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" OnSelectedIndexChanged="DrpDwnLstCidade_SelectedIndexChanged" 
                        DataTextField="Cidade" DataValueField="IdCidade"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label16" runat="server" Text="Bairro:"></asp:Label>
                </td>
                <td>
                    <ajaxToolkit:ComboBox ID="CmbBxBairro" runat="server" TabIndex="10" AutoPostBack="false" DropDownStyle="DropDownList" 
                         AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" 
                        DataTextField="Bairro" DataValueField="IdBairro"   Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="Endereço:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxEndereco" TabIndex="11" runat="server" Width="250" Font-Names="Verdana"
                        Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label51" runat="server" Text="Número:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxNumero" runat="server" TabIndex="12" Width="125" Font-Names="Verdana"
                        Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label52" runat="server" Text="Complemento:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxComplemento" runat="server" TabIndex="13" Width="125" Font-Names="Verdana"
                        Font-Size="08"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="right">
                    <asp:Button ID="BtnProximo" TabIndex="22" runat="server" Text="Próximo" 
                        OnClick="BtnProximo_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset runat="server" id="Etapa2" visible="false">
        <legend>Dados do Contato </legend>
        <table cellspacing="1" cellpadding="1" align="center" border="0">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nome Completo:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxNomeCompleto" TabIndex="20" runat="server" Width="250" Font-Names="Verdana"
                        Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td width="20px">
                </td>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="Telefone Fixo (DDD+Número):"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxTelefoneFixo" TabIndex="31" runat="server" Width="125" MaxLength="14" onBlur="Verifica_Telefone(this)"
                        onKeyDown="Mascara(this,Telefone);" onKeyPress="Mascara(this,Telefone);" onKeyUp="Mascara(this,Telefone);"
                        Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="CPF:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxCPF" TabIndex="21" runat="server" Width="250" MaxLength="14"
                        onKeyDown="Mascara(this,Cpf);" onKeyPress="Mascara(this,Cpf);" onKeyUp="Mascara(this,Cpf);"
                        onBlur="Verifica_campo_CPF(this)" Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td width="20px">
                </td>
                <td>
                    <asp:Label ID="Label20" runat="server" Text="Celular (DDD+Número):"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtBxCelular" TabIndex="32" runat="server" Width="125" MaxLength="14" onBlur="Verifica_Telefone(this)"
                        onKeyDown="Mascara(this,Telefone);" onKeyPress="Mascara(this,Telefone);" onKeyUp="Mascara(this,Telefone);"
                        Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Cargo:"></asp:Label>
                </td>
                <td>
                    <ajaxToolkit:ComboBox ID="CmbBxCargo" runat="server" TabIndex="22" AutoPostBack="false" DropDownStyle="DropDownList" 
                         AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" 
                        DataTextField="Cargo" DataValueField="IdCargo"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td width="20px">
                </td>
                <td>
                    <asp:Label ID="Label21" runat="server" Text="E-mail:"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtBxEmail" TabIndex="33" runat="server" Width="250" onBlur="ValidaEmail(this)"
                        Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label31" runat="server" Text="CEP:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxCEPContato" TabIndex="23" runat="server" Width="125" MaxLength="9" onBlur="Verifica_CEP(this)"
                        onKeyDown="Mascara(this,Cep);" onKeyPress="Mascara(this,Cep);" onKeyUp="Mascara(this,Cep);"
                        Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                    <asp:Button runat="server" ID="Button1" TabIndex="24" CssClass="linkBotao" OnClick="ImgBttnBuscarCepContato_Click" Text="Buscar Endereço" CausesValidation="false"/>
                </td>
                <td width="20px">
                </td>
                <td>
                    <asp:Label ID="Label22" runat="server" Text="Data Nascimento:"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtBxDtNascimento" TabIndex="34" runat="server" Width="80" Font-Names="Verdana"
                        Font-Size="08"></asp:TextBox>
                    <asp:ImageButton ID="ImgBttnDtNascimento" runat="server" ImageUrl="~/Image/Calendario.gif"
                        TabIndex="100" />
                    <span class="obrigatorio">*</span>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date" Mask="99/99/9999"
                        TargetControlID="TxtBxDtNascimento">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImgBttnDtNascimento"
                        TargetControlID="TxtBxDtNascimento">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label27" runat="server" Text="Estado:"></asp:Label>
                </td>
                <td>
                    <ajaxToolkit:ComboBox ID="CmbBxEstadoContato" runat="server" TabIndex="25" AutoPostBack="true" DropDownStyle="DropDownList" 
                         AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220"  OnSelectedIndexChanged="DrpDwnLstEstadoContato_SelectedIndexChanged"
                        DataTextField="Estado" DataValueField="IdEstado"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td width="20px">
                </td>
                <td>
                    <asp:Label ID="Label24" runat="server" Text="Sexo:"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RdBttnLstSexo" TabIndex="35" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                        <asp:ListItem Value="F">Feminino</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label29" runat="server" Text="Cidade:"></asp:Label>
                </td>
                <td>
                    <ajaxToolkit:ComboBox ID="CmbBxCidadeContato" runat="server" TabIndex="26" AutoPostBack="true" DropDownStyle="DropDownList" 
                            AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" OnSelectedIndexChanged="DrpDwnLstCidadeContato_SelectedIndexChanged" 
                        DataTextField="Cidade" DataValueField="IdCidade"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td width="20px">
                </td>
                <td>
                    <asp:Label ID="Label26" runat="server" Text="Nível de escolaridade:"></asp:Label>
                </td>
                <td colspan="2">
                    <ajaxToolkit:ComboBox ID="CmbBxNivelEscolaridade" runat="server" TabIndex="36" AutoPostBack="true" DropDownStyle="DropDownList" 
                            AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" 
                        DataTextField="ContatoNivelEscolaridade" DataValueField="IdContatoNivelEscolaridade" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="Bairro:"></asp:Label>
                </td>
                <td>
                    <ajaxToolkit:ComboBox ID="CmbBxBairroContato" runat="server" TabIndex="27" AutoPostBack="true" DropDownStyle="DropDownList" 
                            AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" 
                        DataTextField="Bairro" DataValueField="IdBairro"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle" style="z-index:2000;">
                    </ajaxToolkit:ComboBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td width="20px">
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label23" runat="server" Text="Endereço Completo:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxEnderecoCompleto" TabIndex="28" runat="server" Width="250"
                        Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td width="20px">
                </td>
                <td>
                    <asp:Label ID="Label30" runat="server" Text="Senha:"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtBxSenha" TabIndex="37" runat="server" Width="250" TextMode="Password"
                        Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio" id="spSenha" runat="server">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label53" runat="server" Text="Número:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxNumeroContato" runat="server" TabIndex="29" Width="125" Font-Names="Verdana"
                        Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio">*</span>
                </td>
                <td width="20px">
                </td>
                <td>
                    <asp:Label ID="Label32" runat="server" Text="Confirma Senha:"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtBxConfSenha" TabIndex="38" runat="server" Width="250" TextMode="Password"
                        Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    <span class="obrigatorio" id="spConfSenha" runat="server">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label54" runat="server" Text="Complemento:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBxComplementoContato" runat="server" TabIndex="30" Width="125"
                        Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Button ID="BtnVoltar2" runat="server" Text="Voltar" CausesValidation="false"
                        OnClick="BtnVoltar2_Click" />
                </td>
                <td colspan="3" align="right">
                    <asp:Button ID="BtnProximo2" runat="server" TabIndex="39" Text="Salvar" 
                        OnClick="BtnConfirmar_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <uc2:UCSelecionaCNAE ID="UCSelecionaCNAE1" runat="server" />
</asp:Content>
