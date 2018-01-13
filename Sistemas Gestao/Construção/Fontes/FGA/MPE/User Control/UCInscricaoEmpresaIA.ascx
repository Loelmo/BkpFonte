<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCInscricaoEmpresaIA.ascx.cs"
    Inherits="Sistema_de_Gestao.MPE.User_Control.UCInscricaoEmpresaIA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px;">
    <asp:Panel ID="PnlFundo" runat="server" Width="800px" Height="500px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%;">
        <div style="overflow: auto; width: 790px; height: 490px;">
            <asp:HiddenField ID="HddnFldEmpresaCadastro" runat="server" />
            <h3>
                Ficha de Cadastro</h3>
            <fieldset runat="server" id="DadosEmpresa">
                <legend>Dados da Empresa </legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                    <tr>
                        <td style="width: 400px;" align="right">
                            <asp:Label ID="Label8" runat="server" Text="CNPJ / CPF:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxCNPJCPF" runat="server" Width="150" TabIndex="1" MaxLength="18"></asp:TextBox><span
                                class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvCNPJCPF" runat="server" ControlToValidate="TxtBxCNPJCPF"
                                Display="None" ErrorMessage="CNPJ / CPF Obrigatório!" ValidationGroup="vgCPF"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvCNPJCPF">
                            </cc1:ValidatorCalloutExtender>
                            <asp:Button ID="btnValidar" runat="server" Text="Validar" OnClick="btnValidar_Click"
                                ValidationGroup="vgCPF" />
                        </td>
                    </tr>
                </table>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" id="tblDadosEmpresa"
                    runat="server">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Razão Social:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxRazaoSocial" runat="server" Width="250" TabIndex="2"></asp:TextBox><span
                                class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvRazaoSocial" runat="server" ControlToValidate="TxtBxRazaoSocial"
                                ErrorMessage="Razào Social Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvRazaoSocial">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="Nome Fantasia:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxNomeFantasia" runat="server" Width="250" TabIndex="3"></asp:TextBox><span
                                class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvNomeFantasia" runat="server" ControlToValidate="TxtBxNomeFantasia"
                                Display="None" ErrorMessage="Nome Fantasia Obrigatória!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvNomeFantasia">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label10" runat="server" Text="Data Abertura da empresa:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxDataAbertura" runat="server" Width="100" TabIndex="4"></asp:TextBox>
                            <asp:ImageButton ID="ImgBttnCalendario" runat="server" TabIndex="8" ImageUrl="~/Image/Calendario.gif" /><span
                                class="obrigatorio">*</span>
                            <cc1:MaskedEditExtender ID="MskdEdtExtndrCalendario" runat="server" MaskType="Date"
                                Mask="99/99/9999" TargetControlID="TxtBxDataAbertura">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="ClndrExtndrCalendario" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="ImgBttnCalendario" TargetControlID="TxtBxDataAbertura">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfvDataAbertura" runat="server" ControlToValidate="TxtBxDataAbertura"
                                Display="None" ErrorMessage="Data Abertura Obrigatória!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvDataAbertura">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" Text="Número de empregados:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxNumeroEmpregados" runat="server" Width="80" MaxLength="10"
                                TabIndex="5" onKeyDown="Mascara(this,Integer);" onKeyPress="Mascara(this,Integer);"
                                onKeyUp="Mascara(this,Integer);"></asp:TextBox><span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvNumeroEmpregados" runat="server" ControlToValidate="TxtBxNumeroEmpregados"
                                Display="None" ErrorMessage="Número de Empregados Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="rfvNumeroEmpregados">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" Text="Endereço:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxEndereco" runat="server" Width="250" TabIndex="6"></asp:TextBox><span
                                class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvEndereco" runat="server" ControlToValidate="TxtBxEndereco"
                                Display="None" ErrorMessage="Endereço Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="rfvEndereco">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label16" runat="server" Text="Bairro:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstBairro" runat="server" Width="205px" TabIndex="7">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvBairro" runat="server" ControlToValidate="DrpDwnLstBairro"
                                InitialValue="" ErrorMessage="Bairro Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server" TargetControlID="rfvBairro">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label15" runat="server" Text="Estado:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstEstado" runat="server" Width="205px" TabIndex="8"
                                AutoPostBack="True" OnSelectedIndexChanged="DrpDwnLstEstado_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="DrpDwnLstEstado"
                                InitialValue="0" ErrorMessage="Estado Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server" TargetControlID="rfvEstado">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label17" runat="server" Text="Cidade:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstCidade" runat="server" Width="205px" TabIndex="9"
                                AutoPostBack="True" OnSelectedIndexChanged="DrpDwnLstCidade_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvCidade" runat="server" ControlToValidate="DrpDwnLstCidade"
                                InitialValue="" ErrorMessage="Cidade Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" TargetControlID="rfvCidade">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label18" runat="server" Text="CEP:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxCEP" runat="server" Width="100" TabIndex="17" MaxLength="10"
                                onKeyDown="Mascara(this,Cep);" onKeyPress="Mascara(this,Cep);" onKeyUp="Mascara(this,Cep);"
                                onBlur="Verifica_CEP(this)"></asp:TextBox><span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvCEP" runat="server" ControlToValidate="TxtBxCEP"
                                Display="None" ErrorMessage="CEP Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="rfvCEP">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Tipo de Empresa:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstTipoEmpresa" runat="server" Width="245px" TabIndex="11">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvTipoEmpresa" runat="server" ControlToValidate="DrpDwnLstTipoEmpresa"
                                InitialValue="0" ErrorMessage="Tipo Empresa Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="rfvTipoEmpresa">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" Text="Faturamento Anual em 2010 (R$):"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstFaturamento" runat="server" Width="245px" TabIndex="12">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvFaturamento" runat="server" ControlToValidate="DrpDwnLstFaturamento"
                                InitialValue="0" ErrorMessage="Faturamento Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" TargetControlID="rfvFaturamento">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" Text="Categoria:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstCategoria" runat="server" Width="245px" TabIndex="13">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="DrpDwnLstCategoria"
                                InitialValue="0" ErrorMessage="Categoria Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="rfvCategoria">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label19" runat="server" Text="Grupo:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstGrupo" runat="server" Width="245px" TabIndex="14">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvGrupo" runat="server" ControlToValidate="DrpDwnLstGrupo"
                                InitialValue="0" ErrorMessage="Categoria Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="rfvGrupo">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" Text="Atividade Economica:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstAtividadeEconomica" runat="server" Width="245px" TabIndex="15">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvAtividadeEconomica" runat="server" ControlToValidate="DrpDwnLstAtividadeEconomica"
                                InitialValue="0" ErrorMessage="Atividade Economica Obrigatória!" ValidationGroup="vgCadastroEmpresa"
                                Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" TargetControlID="rfvAtividadeEconomica">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" Text="Descreva sua principal atividade:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxPrincipalAtividade" runat="server" Height="100" Width="238px"
                                TextMode="MultiLine" TabIndex="16"></asp:TextBox><span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvPrincipalAtividade" runat="server" ControlToValidate="TxtBxPrincipalAtividade"
                                Display="None" ErrorMessage="Principal Atividade Obrigatória!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rfvPrincipalAtividade">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 400px;" align="right">
                            <asp:Label ID="Label42" runat="server" Text="Você deseja concorrer ao Destaque de Boas Práticas de Responsabilidade Social?:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="RdBttnLstPergunta" runat="server" TabIndex="17" RepeatDirection="Vertical">
                                <asp:ListItem Value="1">Sim</asp:ListItem>
                                <asp:ListItem Value="0">Não</asp:ListItem>
                            </asp:RadioButtonList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvPergunta" runat="server" ControlToValidate="RdBttnLstPergunta"
                                InitialValue="" ErrorMessage="Resposta Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" TargetControlID="rfvPergunta">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset runat="server" id="DadosContato">
                <legend>Dados do Contato </legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                    <tr>
                        <td style="width: 400px;" align="right">
                            <asp:Label ID="Label1" runat="server" Text="Nome Completo:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxNomeCompleto" runat="server" Width="250" TabIndex="18"></asp:TextBox><span
                                class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvNomeCompleto" runat="server" ControlToValidate="TxtBxNomeCompleto"
                                Display="None" ErrorMessage="Nome Completo Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" TargetControlID="rfvNomeCompleto">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label20" runat="server" Text="Celular:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxCelular" runat="server" Width="100" TabIndex="29" MaxLength="14"
                                onKeyDown="Mascara(this,Telefone);" onKeyPress="Mascara(this,Telefone);" onKeyUp="Mascara(this,Telefone);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="CPF:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxCPF" runat="server" Width="150" TabIndex="20" MaxLength="14"
                                onKeyDown="Mascara(this,Cpf);" onKeyPress="Mascara(this,Cpf);" onKeyUp="Mascara(this,Cpf);"
                                onBlur="Verifica_campo_CPF(this)"></asp:TextBox><span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvCPF" runat="server" ControlToValidate="TxtBxCPF"
                                Display="None" ErrorMessage="CPF Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="server" TargetControlID="rfvCPF">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label21" runat="server" Text="E-mail:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxEmail" runat="server" Width="250" TabIndex="21" onBlur="ValidaEmail(this)"></asp:TextBox><span
                                class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="TxtBxEmail"
                                Display="None" ErrorMessage="E-Mail Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server" TargetControlID="rfvEmail">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Cargo:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstCargo" runat="server" Width="205px" TabIndex="22">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvCargo" runat="server" ControlToValidate="DrpDwnLstCargo"
                                Display="None" InitialValue="0" ErrorMessage="Cargo Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="server" TargetControlID="rfvCargo">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label22" runat="server" Text="Data Nascimento:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxDtNascimento" runat="server" Width="100" TabIndex="23"></asp:TextBox>
                            <asp:ImageButton ID="ImgBttnDtNascimento" runat="server" ImageUrl="~/Image/Calendario.gif" /><span
                                class="obrigatorio">*</span>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date" Mask="99/99/9999"
                                TargetControlID="TxtBxDtNascimento">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImgBttnDtNascimento"
                                TargetControlID="TxtBxDtNascimento">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfvDataNascimento" runat="server" ControlToValidate="TxtBxDtNascimento"
                                Display="None" ErrorMessage="Data Nascimento Obrigatória!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="rfvDataNascimento">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label27" runat="server" Text="Estado:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstEstadoContato" runat="server" Width="205px" InitialValue="0"
                                TabIndex="24" AutoPostBack="True" OnSelectedIndexChanged="DrpDwnLstEstadoContato_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvEstadoContato" runat="server" ControlToValidate="DrpDwnLstEstadoContato"
                                Display="None" ErrorMessage="Estado Contato Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server" TargetControlID="rfvEstadoContato">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label24" runat="server" Text="Sexo:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="RdBttnLstSexo" runat="server" TabIndex="25" RepeatDirection="Horizontal">
                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                <asp:ListItem Value="F">Feminino</asp:ListItem>
                            </asp:RadioButtonList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="RdBttnLstSexo"
                                Display="None" InitialValue="" ErrorMessage="Sexo Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender26" runat="server" TargetControlID="rfvSexo">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label29" runat="server" Text="Cidade:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstCidadeContato" runat="server" Width="205px" TabIndex="26"
                                AutoPostBack="True" OnSelectedIndexChanged="DrpDwnLstCidadeContato_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvCidadeContato" runat="server" ControlToValidate="DrpDwnLstCidadeContato"
                                Display="None" InitialValue="" ErrorMessage="Cidade Contato Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender27" runat="server" TargetControlID="rfvCidadeContato">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label26" runat="server" Text="Nível de escolaridade:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstNivelEscolaridade" runat="server" Width="205px" TabIndex="27">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvNivelEscolaridade" runat="server" ControlToValidate="DrpDwnLstNivelEscolaridade"
                                Display="None" ErrorMessage="Nível Escolaridade Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender28" runat="server" TargetControlID="rfvNivelEscolaridade">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label25" runat="server" Text="Bairro:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstBairroContato" runat="server" Width="205px" TabIndex="28">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvBairroContato" runat="server" ControlToValidate="DrpDwnLstBairroContato"
                                Display="None" ErrorMessage="Bairro Contato Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender29" runat="server" TargetControlID="rfvBairroContato">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label28" runat="server" Text="Faixa Etária:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpDwnLstFaixaEtaria" runat="server" Width="205px" TabIndex="29">
                            </asp:DropDownList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvFaixaEtaria" runat="server" ControlToValidate="DrpDwnLstFaixaEtaria"
                                Display="None" ErrorMessage="Faixa Etária Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender30" runat="server" TargetControlID="rfvFaixaEtaria">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label23" runat="server" Text="Endereço Completo:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxEnderecoCompleto" runat="server" Width="250" TabIndex="30"></asp:TextBox><span
                                class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvEnderecoCompleto" runat="server" ControlToValidate="TxtBxEnderecoCompleto"
                                Display="None" ErrorMessage="Endereço Completo Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender31" runat="server" TargetControlID="rfvEnderecoCompleto">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label31" runat="server" Text="CEP:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxCEPContato" runat="server" Width="100" TabIndex="31" MaxLength="9"
                                onKeyDown="Mascara(this,Cep);" onKeyPress="Mascara(this,Cep);" onKeyUp="Mascara(this,Cep);"></asp:TextBox><span
                                    class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvCEPContato" runat="server" ControlToValidate="TxtBxCEPContato"
                                Display="None" ErrorMessage="CEP Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender33" runat="server" TargetControlID="rfvCEPContato">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label33" runat="server" Text="Telefone Fixo:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtBxTelefoneFixo" runat="server" Width="100" TabIndex="32" MaxLength="14"
                                onKeyDown="Mascara(this,Telefone);" onKeyPress="Mascara(this,Telefone);" onKeyUp="Mascara(this,Telefone);"></asp:TextBox><span
                                    class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvTelefoneFixo" runat="server" ControlToValidate="TxtBxTelefoneFixo"
                                Display="None" ErrorMessage="Telefone Fixo Obrigatório!" ValidationGroup="vgCadastroEmpresa"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender35" runat="server" TargetControlID="rfvTelefoneFixo">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset runat="server" id="TesteAutoavaliacao">
                <legend>Teste de Autoavaliação </legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                    <tr>
                        <td>
                            <asp:Label ID="Label36" runat="server" Text="Pergunta 1:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label34" runat="server" Text="Os dirigentes têm clareza do que a empresa deverá ser no futuro?:"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RdBttnLstPergunta1" runat="server" RepeatDirection="Horizontal"
                                TabIndex="33">
                                <asp:ListItem Value="1">Sim</asp:ListItem>
                                <asp:ListItem Value="0">Não</asp:ListItem>
                            </asp:RadioButtonList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvPergunta1" runat="server" ControlToValidate="RdBttnLstPergunta1"
                                Display="None" ErrorMessage="Pergunta 1 Obrigatório!" ValidationGroup="vgEtapa3"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender36" runat="server" TargetControlID="rfvPergunta1">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label35" runat="server" Text="Pergunta 2:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="80%">
                            <asp:Label ID="Label37" runat="server" Text="Existem ações definidas para alcançar o que a empresa quer ser no futuro?:"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RdBttnLstPergunta2" runat="server" RepeatDirection="Horizontal"
                                TabIndex="34">
                                <asp:ListItem Value="1">Sim</asp:ListItem>
                                <asp:ListItem Value="0">Não</asp:ListItem>
                            </asp:RadioButtonList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvPergunta2" runat="server" ControlToValidate="RdBttnLstPergunta2"
                                Display="None" ErrorMessage="Pergunta 2 Obrigatório!" ValidationGroup="vgEtapa3"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender37" runat="server" TargetControlID="rfvPergunta2">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label38" runat="server" Text="Pergunta 3:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="80%">
                            <asp:Label ID="Label39" runat="server" Text="As necessidades dos clientes são conhecidas e atendidas?:"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RdBttnLstPergunta3" runat="server" RepeatDirection="Horizontal"
                                TabIndex="35">
                                <asp:ListItem Value="1">Sim</asp:ListItem>
                                <asp:ListItem Value="0">Não</asp:ListItem>
                            </asp:RadioButtonList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvPergunta3" runat="server" ControlToValidate="RdBttnLstPergunta3"
                                Display="None" ErrorMessage="Pergunta 3 Obrigatório!" ValidationGroup="vgEtapa3"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender38" runat="server" TargetControlID="rfvPergunta3">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label40" runat="server" Text="Pergunta 4:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="80%">
                            <asp:Label ID="Label41" runat="server" Text="As receitas e despesas são controladas para garantir a permanência da empresa no mercado?:"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RdBttnLstPergunta4" runat="server" RepeatDirection="Horizontal"
                                TabIndex="36">
                                <asp:ListItem Value="1">Sim</asp:ListItem>
                                <asp:ListItem Value="0">Não</asp:ListItem>
                            </asp:RadioButtonList>
                            <span class="obrigatorio">*</span>
                            <asp:RequiredFieldValidator ID="rfvPergunta4" runat="server" ControlToValidate="RdBttnLstPergunta4"
                                Display="None" ErrorMessage="Pergunta 4 Obrigatório!" ValidationGroup="vgEtapa3"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender39" runat="server" TargetControlID="rfvPergunta4">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset runat="server" id="DadosSenha">
                <legend>Senha</legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                    <tr>
                        <td style="width: 400px;" align="right">
                            <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
                        </td>
                        <td align="left">
                            <div id="divSenha" runat="server">
                                <asp:TextBox ID="TxtBxSenha" runat="server" Width="200px" MaxLength="37" TabIndex="4"
                                    TextMode="Password"></asp:TextBox><span class="obrigatorio">*</span>
                                <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="TxtBxSenha"
                                    Display="None" ErrorMessage="Senha Obrigatório!" ValidationGroup="vgCadastroUsuario"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="rfvSenha">
                                </cc1:ValidatorCalloutExtender>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblConfSenha" runat="server" Text="Confirma Senha:"></asp:Label>
                        </td>
                        <td align="left">
                            <div id="divConfSenha" runat="server">
                                <asp:TextBox ID="TxtBxConfSenha" runat="server" Width="200px" MaxLength="38" TabIndex="5"
                                    TextMode="Password"></asp:TextBox><span class="obrigatorio">*</span>
                                <asp:RequiredFieldValidator ID="rfvConfSenha" runat="server" ControlToValidate="TxtBxConfSenha"
                                    Display="None" ErrorMessage="Confirma Senha Obrigatório!" ValidationGroup="vgCadastroUsuario"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender40" runat="server" TargetControlID="rfvConfSenha">
                                </cc1:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="As Senhas estão diferente!"
                                    ControlToCompare="txtbxSenha" ControlToValidate="TxtBxConfSenha" ValidationGroup="vgCadastroUsuario"
                                    Text="*"></asp:CompareValidator>
                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender41" runat="server" TargetControlID="CompareValidator1">
                                </cc1:ValidatorCalloutExtender>
                            </div>
                        </td>
                    </tr>
                </table>
                <div align="right">
                    <asp:ImageButton ID="ImgBttnConfirma" runat="server" TabIndex="39" ValidationGroup="vgEtapa3"
                        ImageUrl="~/Image/gravar16.gif" OnClick="ImgBttnConfirma_Click" />
                    <asp:ImageButton ID="ImgBttnCancelar" runat="server" TabIndex="40" ImageUrl="~/Image/cancelar16.gif"
                        OnClick="ImgBttnCancelar_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
</div>
