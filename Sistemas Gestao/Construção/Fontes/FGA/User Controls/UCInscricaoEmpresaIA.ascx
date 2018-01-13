<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCInscricaoEmpresaIA.ascx.cs"
    Inherits="Sistema_de_Gestao.MPE.User_Control.UCInscricaoEmpresaIA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<%@ Register Src="UCSelecionaCNAE.ascx" TagName="UCSelecionaCNAE" TagPrefix="uc2" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="940px" Height="550px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%;">
        <asp:HiddenField ID="HddnFldEmpresaCadastro" runat="server" />
        <asp:HiddenField ID="HddnFldTurma" runat="server" />
        <asp:HiddenField ID="HddnFldSenha" runat="server" />
        <asp:HiddenField ID="HddnFldCepAnterior" runat="server" />
        <asp:HiddenField ID="HddnFldCepAnteriorContato" runat="server" />
        <fieldset class="fieldsetUC">
            <legend style="font-weight: bold;">Ficha de Cadastro </legend>
            <div id="divUC" runat="server" style="overflow: auto; height: 480px;">
                <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px" runat="server"
                    id="fsValidar">
                    <legend>Dados da Empresa </legend>
                                <table cellspacing="1" cellpadding="1" width="100%" align="left" border="0">
                                    <tr>
                                        <td align="left" width="160">
                                            <asp:Label ID="Label8" runat="server" Text="CNPJ:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TxtBxCNPJCPF" runat="server" Width="150" TabIndex="24" MaxLength="18"
                                                onKeyDown="Mascara(this,CpfCnpj);" onKeyPress="Mascara(this,CpfCnpj);" onKeyUp="Mascara(this,CpfCnpj);"
                                                onBlur="Verifica_campo_CPF_CNPJ(this)"></asp:TextBox><span class="obrigatorio">*</span>
                                            <asp:Button ID="btnValidar" runat="server" Text="Validar" OnClick="btnValidar_Click"
                                                TabIndex="25" />
                                        </td>
                                    </tr>
                                </table>
                </fieldset>
            <div id="divDados" runat="server">
                <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px" >
                    <legend>Dados da Empresa </legend>

                <table cellspacing="1" cellpadding="1" align="left" width="100%" border="0" >

                    <tr>
                        <td width="150" align="left">
                            <asp:Label ID="Label4" runat="server" Text="Razão Social:"></asp:Label>
                        </td>
                        <td align="left" width="270">
                            <asp:TextBox ID="TxtBxRazaoSocial" runat="server" Width="230" TabIndex="26"></asp:TextBox><span
                                class="obrigatorio">*</span>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label10" runat="server" Text="Data Abertura da empresa:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxDataAbertura" runat="server" Width="100" TabIndex="38"></asp:TextBox>
                            <asp:ImageButton TabIndex="999" ID="ImgBttnCalendario" runat="server" ImageUrl="~/Image/Calendario.gif" /><span
                                class="obrigatorio">*</span>
                            <cc1:MaskedEditExtender ID="MskdEdtExtndrCalendario" runat="server" MaskType="Date"
                                Mask="99/99/9999" TargetControlID="TxtBxDataAbertura">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="ClndrExtndrCalendario" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="ImgBttnCalendario" TargetControlID="TxtBxDataAbertura">
                            </cc1:CalendarExtender>
                        </td>                    
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label6" runat="server" Text="Nome Fantasia:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxNomeFantasia" runat="server" Width="230" TabIndex="27"></asp:TextBox><span
                                class="obrigatorio">*</span>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label12" runat="server" Text="Número de Colaboradores:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxNumeroEmpregados" runat="server" Width="80" MaxLength="10"
                                TabIndex="39" onKeyDown="Mascara(this,Integer);" onKeyPress="Mascara(this,Integer);"
                                onKeyUp="Mascara(this,Integer);"></asp:TextBox><span class="obrigatorio">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="160">
                            <asp:Label ID="LblCNPJCPFValido" runat="server" Text="CNPJ:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxCNPJCPFValido" runat="server" Width="150" TabIndex="28" MaxLength="18" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="left" width="150">
                            <asp:Label ID="Label5" runat="server" Text="Tipo de Empresa:"></asp:Label>
                        </td>
                        <td align="left" width="270">
                            <ajaxToolkit:ComboBox ID="CmbBxTipoEmpresa" runat="server" TabIndex="40" AutoPostBack="False" DropDownStyle="DropDownList"
                                 AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" DataTextField="TipoEmpresa" 
                                 DataValueField="IdTipoEmpresa" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                            </ajaxToolkit:ComboBox>
                            <span class="obrigatorio">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td width="160" align="left" style="height:22px;">
                            <asp:Label ID="Label30" runat="server" Text="Turma:"></asp:Label>
                        </td>
                        <td align="left">
                            <ajaxToolkit:ComboBox ID="CmbBxTurma" runat="server" TabIndex="29" AutoPostBack="true" DropDownStyle="DropDownList" 
                                 AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" OnSelectedIndexChanged="DrpDwnLstTurma_SelectedIndexChanged" DataTextField="Turma"
                                DataValueField="IdTurma" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                            </ajaxToolkit:ComboBox>
                            <span class="obrigatorio">*</span>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label7" runat="server" Text="Faturamento Anual 2010:"></asp:Label>
                        </td>
                        <td align="left">
                            <ajaxToolkit:ComboBox ID="CmbBxFaturamento" runat="server" TabIndex="41" AutoPostBack="False" DropDownStyle="DropDownList"
                                 AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" DataTextField="Faturamento" 
                                 DataValueField="IdFaturamento" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                            </ajaxToolkit:ComboBox>
                            <span class="obrigatorio">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label18" runat="server" Text="CEP:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxCEP" runat="server" Width="100" TabIndex="30" MaxLength="9"
                                onKeyDown="Mascara(this,Cep);" onKeyPress="Mascara(this,Cep);" onKeyUp="Mascara(this,Cep);"
                                onBlur="Verifica_CEP(this)"></asp:TextBox><span class="obrigatorio">*</span>
                            <asp:Button runat="server" ID="HlnkBuscaCep" TabIndex="31" CssClass="linkBotao" OnClick="ImgBttnBuscarCep_Click" Text="Buscar Endereço" CausesValidation="false"/>
                        </td>                                    
                        <td align="left">
                            <asp:Label ID="Label9" runat="server" Text="Setor:"></asp:Label>
                        </td>
                        <td align="left">
                            <ajaxToolkit:ComboBox ID="CmbBxCategoria" runat="server" TabIndex="42" AutoPostBack="False" DropDownStyle="DropDownList"
                                 AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" DataTextField="Categoria" 
                                 DataValueField="IdCategoria" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                            </ajaxToolkit:ComboBox>
                            <span class="obrigatorio">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height:22px;">
                            <asp:Label ID="Label16" runat="server" Text="Estado:"></asp:Label>
                        </td>
                        <td align="left">
                            <ajaxToolkit:ComboBox ID="CmbBxEstado" runat="server" TabIndex="32" AutoPostBack="true" DropDownStyle="DropDownList" 
                                 AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" OnSelectedIndexChanged="DrpDwnLstEstado_SelectedIndexChanged" DataTextField="Estado"
                                DataValueField="IdEstado" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                            </ajaxToolkit:ComboBox>
                            <span class="obrigatorio">*</span>
                        </td>
                        <td valign="top" align="left">
                            <asp:Label ID="Label11" runat="server" Text="Atividade Econômica:"></asp:Label>
                        </td>
                        <td align="left" style="vertical-align: top;">
                            <asp:LinkButton TabIndex="43" ID="LnkBttnSelecionaAtividadeEconomica" runat="server" 
                                OnClick="LnkBttnSelecionaAtividadeEconomica_Click">Clique aqui para selecionar</asp:LinkButton><br />
                            <asp:TextBox ID="TxtBoxAtividadeEconomica" runat="server" Width="230px" ReadOnly="true"
                                TabIndex="999" MaxLength="300"></asp:TextBox><span class="obrigatorio"> *</span>
                            <asp:HiddenField ID="HddnIdAtividadeEconomica" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height:22px;">
                            <asp:Label ID="Label43" runat="server" Text="Cidade:"></asp:Label>
                        </td>
                        <td align="left">
                            <ajaxToolkit:ComboBox ID="CmbBxCidade" runat="server" TabIndex="33" AutoPostBack="true" DropDownStyle="DropDownList" 
                                 AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" OnSelectedIndexChanged="DrpDwnLstCidade_SelectedIndexChanged" 
                                DataTextField="Cidade" DataValueField="IdCidade"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                            </ajaxToolkit:ComboBox>
                            <span class="obrigatorio">*</span>
                        </td>
                        <td valign="top" align="left" rowspan="4">
                            <asp:Label ID="Label13" runat="server" Text="Descreva sua principal atividade:"></asp:Label>
                        </td>
                        <td align="left" rowspan="4">
                            <asp:TextBox ID="TxtBxPrincipalAtividade" runat="server" Height="70" Width="240px"
                                TextMode="MultiLine" TabIndex="44" Font-Names="Arial" Font-Size="12px"></asp:TextBox><span
                                    class="obrigatorio">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height:22px;">
                            <asp:Label ID="Label45" runat="server" Text="Bairro:"></asp:Label>
                        </td>
                        <td align="left">
                            <ajaxToolkit:ComboBox ID="CmbBxBairro" runat="server" TabIndex="34" AutoPostBack="false" DropDownStyle="DropDownList" 
                                 AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" 
                                DataTextField="Bairro" DataValueField="IdBairro"   Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                            </ajaxToolkit:ComboBox>
                            <span class="obrigatorio">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label14" runat="server" Text="Endereço:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxEndereco" runat="server" Width="230" TabIndex="35"></asp:TextBox><span
                                class="obrigatorio">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label17" runat="server" Text="Número:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxNumero" runat="server" Width="230" TabIndex="36"></asp:TextBox><span
                                class="obrigatorio">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label19" runat="server" Text="Complemento:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxComplemento" runat="server" Width="230" TabIndex="37"></asp:TextBox>
                        </td>

                    </tr>
                </table>
                </fieldset>
                <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px" >
                    <legend>Dados do Contato </legend>
                    <table cellspacing="1" cellpadding="1" width="100%" align="left" border="0">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Text="Nome Completo:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxNomeCompleto" runat="server" Width="250" TabIndex="47"></asp:TextBox><span
                                    class="obrigatorio">*</span>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label33" runat="server" Text="Complemento:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxComplementoContato" runat="server" Width="100" TabIndex="56"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Text="CPF:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxCPF" runat="server" Width="150" TabIndex="48" MaxLength="14"
                                    onKeyDown="Mascara(this,Cpf);" onKeyPress="Mascara(this,Cpf);" onKeyUp="Mascara(this,Cpf);"
                                    onBlur="Verifica_campo_CPF(this)"></asp:TextBox><span class="obrigatorio">*</span>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label44" runat="server" Text="Telefone Fixo (DDD+Número):"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxTelefoneFixo" runat="server" Width="100" TabIndex="57" MaxLength="14"
                                    onKeyDown="Mascara(this,Telefone);" onKeyPress="Mascara(this,Telefone);" onKeyUp="Mascara(this,Telefone);"></asp:TextBox><span
                                        class="obrigatorio">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label31" runat="server" Text="CEP:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxCEPContato" runat="server" Width="100" TabIndex="49" MaxLength="9"
                                    onKeyDown="Mascara(this,Cep);" onKeyPress="Mascara(this,Cep);" onKeyUp="Mascara(this,Cep);"></asp:TextBox><span
                                        class="obrigatorio">*</span>
                                <asp:Button runat="server" ID="Button1" TabIndex="50" CssClass="linkBotao" OnClick="ImgBttnBuscarCepContato_Click" Text="Buscar Endereço" CausesValidation="false"/>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label20" runat="server" Text="Celular (DDD+Número):"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxCelular" runat="server" Width="100" TabIndex="58" MaxLength="14"
                                    onKeyDown="Mascara(this,Telefone);" onKeyPress="Mascara(this,Telefone);" onKeyUp="Mascara(this,Telefone);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label27" runat="server" Text="Estado:"></asp:Label>
                            </td>
                            <td align="left">
                                <ajaxToolkit:ComboBox ID="CmbBxEstadoContato" runat="server" TabIndex="51" AutoPostBack="true" DropDownStyle="DropDownList" 
                                     AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220"  OnSelectedIndexChanged="DrpDwnLstEstadoContato_SelectedIndexChanged"
                                    DataTextField="Estado" DataValueField="IdEstado"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                                </ajaxToolkit:ComboBox>
                                <span class="obrigatorio">*</span>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label21" runat="server" Text="E-mail:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxEmail" runat="server" Width="250" TabIndex="59" onBlur="ValidaEmail(this)"></asp:TextBox><span
                                    class="obrigatorio">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label29" runat="server" Text="Cidade:"></asp:Label>
                            </td>
                            <td align="left">
                                <ajaxToolkit:ComboBox ID="CmbBxCidadeContato" runat="server" TabIndex="52" AutoPostBack="true" DropDownStyle="DropDownList" 
                                        AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" OnSelectedIndexChanged="DrpDwnLstCidadeContato_SelectedIndexChanged" 
                                    DataTextField="Cidade" DataValueField="IdCidade"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                                </ajaxToolkit:ComboBox>
                                <span class="obrigatorio">*</span>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label22" runat="server" Text="Data Nascimento:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxDtNascimento" TabIndex="60" runat="server" Width="100"></asp:TextBox>
                                <asp:ImageButton ID="ImgBttnDtNascimento" runat="server" ImageUrl="~/Image/Calendario.gif"
                                    TabIndex="998" /><span class="obrigatorio">*</span>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date" Mask="99/99/9999"
                                    TargetControlID="TxtBxDtNascimento">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImgBttnDtNascimento"
                                    TargetControlID="TxtBxDtNascimento">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label25" runat="server" Text="Bairro:"></asp:Label>
                            </td>
                            <td align="left">
                                <ajaxToolkit:ComboBox ID="CmbBxBairroContato" runat="server" TabIndex="53" AutoPostBack="true" DropDownStyle="DropDownList" 
                                        AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" 
                                    DataTextField="Bairro" DataValueField="IdBairro"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                                </ajaxToolkit:ComboBox>
                                <span class="obrigatorio">*</span>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label24" runat="server" Text="Sexo:"></asp:Label>
                            </td>
                            <td align="left">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList ID="RdBttnLstSexo" runat="server" TabIndex="61" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                <asp:ListItem Value="F">Feminino</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <span class="obrigatorio">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label23" runat="server" Text="Endereço:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxEnderecoCompleto" runat="server" Width="250" TabIndex="54"></asp:TextBox><span
                                    class="obrigatorio">*</span>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label3" runat="server" Text="Cargo:"></asp:Label>
                            </td>
                            <td align="left">
                                <ajaxToolkit:ComboBox ID="CmbBxCargo" runat="server" TabIndex="62" AutoPostBack="false" DropDownStyle="DropDownList" 
                                     AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" 
                                    DataTextField="Cargo" DataValueField="IdCargo"  Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                                </ajaxToolkit:ComboBox>
                                <span class="obrigatorio">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label28" runat="server" Text="Número:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtBxNumeroContato" runat="server" Width="250" TabIndex="55"></asp:TextBox><span
                                    class="obrigatorio">*</span>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label26" runat="server" Text="Nível de escolaridade:"></asp:Label>
                            </td>
                            <td align="left">
                                <ajaxToolkit:ComboBox ID="CmbBxNivelEscolaridade" runat="server" TabIndex="63" AutoPostBack="true" DropDownStyle="DropDownList" 
                                        AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="220" 
                                    DataTextField="ContatoNivelEscolaridade" DataValueField="IdContatoNivelEscolaridade" Font-Names="Verdana" Font-Size="08" CssClass="WindowsStyle2" style="z-index:2000;">
                                </ajaxToolkit:ComboBox>
                                <span class="obrigatorio">*</span>
                            </td>
                        </tr>
                    </table>
                </fieldset>

                <div id="divSenha" runat="server">
                    <fieldset style="margin-top: 5px; margin-left: 10px; margin-right: 10px" >
                        <legend>Senha</legend>
                        <table cellspacing="1" cellpadding="1" align="left" width="100%" border="0" >
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label15" runat="server" Text="Senha:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtBxSenha" runat="server" Width="230" TabIndex="65"></asp:TextBox><span
                                        class="obrigatorio">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label34" runat="server" Text="Confirma Senha:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtBxConfSenha" runat="server" Width="230" TabIndex="66"></asp:TextBox><span
                                        class="obrigatorio">*</span>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                </div>
            </div>
        </fieldset>
        <div align="right">
            <asp:ImageButton ID="ImgBttnConfirma" runat="server" TabIndex="69" 
                Visible="false" ImageUrl="~/Image/_file_save.png" OnClick="ImgBttnConfirma_Click" />&nbsp;&nbsp;
            <asp:ImageButton ID="ImgBttnCancelar" runat="server" TabIndex="70" ImageUrl="~/Image/_file_back2.png"
                OnClick="ImgBttnCancelar_Click" />&nbsp;&nbsp;
        </div>
        <%--</div>--%>
    </asp:Panel>
    <uc2:UCSelecionaCNAE ID="UCSelecionaCNAE1" runat="server" />
</div>
