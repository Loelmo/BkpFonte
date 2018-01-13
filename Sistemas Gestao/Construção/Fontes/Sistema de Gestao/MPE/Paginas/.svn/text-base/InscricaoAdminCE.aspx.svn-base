<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true"
    CodeBehind="InscricaoAdminCE.aspx.cs" Inherits="Sistema_de_Gestao.MPE.Paginas.InscricaoAdminCE" %>

<%@ Register Src="~/User Controls/UCExportarInscritas.ascx" TagName="UCExportarInscritas"
    TagPrefix="uc1" %>
    <%@ Register Src="~/MPE/User Control/UCInscricaoEmpresaIA.ascx" TagName="UCInscricaoEmpresaIA"
    TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function LimpaCombo(idCombo) {
            var combo = document.getElementById(idCombo);
            for (var i = 0; i < combo.options.length; i++) {
                combo.options[i].selected = '';
                if (combo.options[i].value == "0") {
                    combo.options[i].selected = 'selected';
                }
            }
        } 
    </script>
    <h3>
        Inscrições</h3>
    <fieldset style="width: 950px; font-size: 12px; white-space: nowrap;">
        <legend>Pesquisa </legend>
        <div id="filtroSimples">
            <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                <tr>
                    <td style="width: 20%;">
                        <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
                    </td>
                    <td style="width: 30%;">
                        <asp:TextBox ID="TxtBxNomePesquisa" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 20%;">
                        <asp:Label ID="Label1" runat="server" Text="CPF/CNPJ:"></asp:Label>
                    </td>
                    <td style="width: 30%;">
                        <asp:TextBox ID="txtCpfCnpj" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 5%;">
                        <asp:Image id="imgMais" ImageUrl="~/Image/ico_add.png" onclick="AbrirFiltros('block')"
                            style="display: block" runat="server"/>
                        <asp:Image id="imgMenos" ImageUrl="~/Image/ico_remove.png" onclick="AbrirFiltros('none')"
                            style="display: none" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" DataValueField="IdEstado" DataTextField="Estado"
                            OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblES" runat="server" Text="Escritório Regional:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEscritorioRegional" runat="server" DataValueField="IdEscritorioRegional"
                            DataTextField="EscritorioRegional">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Protocolo:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProtocolo" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Status:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" DataValueField="IdStatus" DataTextField="Status">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Ano:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAno" runat="server" DataTextField="Ciclo" DataValueField="IdTurma">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Grupo:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGrupo" runat="server" DataValueField="IdGrupo" DataTextField="Grupo">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Categoria:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategoria" runat="server" DataValueField="IdCategoria" DataTextField="Categoria">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/pesquisar.gif"
                            Style="width: 16px" OnClick="ImgBttnPesquisar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="filtroCompleto" runat="server">
            <table cellspacing="1" cellpadding="1" align="center" border="0" width="100%">
                <tr style="width: 20%;">
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Município:"> </asp:Label>
                    </td>
                    <td style="width: 30%;">
                        <asp:DropDownList ID="ddlMunicipio" runat="server" DataValueField="IdCidade" DataTextField="Cidade">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 20%;">
                        <asp:Label ID="Label11" runat="server" Text="Região:"> </asp:Label>
                    </td>
                    <td style="width: 30%;">
                        <asp:DropDownList ID="ddlRegiao" runat="server" DataValueField="IdEstadoRegiao" DataTextField="EstadoRegiao">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Faturamento:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFaturamento" runat="server" DataValueField="IdFaturamento"
                            DataTextField="Faturamento">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Tipo de Empresa:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoEmpresa" runat="server" DataValueField="IdTipoEmpresa"
                            DataTextField="TipoEmpresa">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Tipo de Relatório:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoRelatorio" runat="server">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Prêmios Especiais:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPremiosEspeciaos" runat="server">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Número de Funcionários:"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumeroFuncionarios" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Sexo dos representantes:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSexo" runat="server">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                            <asp:ListItem Selected="False" Text="Masculino" Value="M"></asp:ListItem>
                            <asp:ListItem Selected="False" Text="Feminino" Value="F"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="Escolaridade dos representantes:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNivelEscolaridade" runat="server" DataValueField="IdContatoNivelEscolaridade"
                            DataTextField="ContatoNivelEscolaridade">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Faixa Etária dos Representantes:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFaixaEtaria" runat="server" DataValueField="IdContatoFaixaEtaria"
                            DataTextField="ContatoFaixaEtaria">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Período:"> </asp:Label>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="De:"> </asp:Label>
                                    <asp:TextBox ID="txtDe" runat="server" Width="100"></asp:TextBox>
                                    <cc1:CalendarExtender ID="ceCalendar" runat="server" PopupButtonID="ibtnCalendar"
                                        TargetControlID="txtDe">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ibtnCalendar" ImageUrl="~/Image/calendar.png" Width="20px" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Até:"> </asp:Label>
                                    <asp:TextBox ID="txtAte" runat="server" Width="100"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="btnAte"
                                        TargetControlID="txtAte">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="btnAte" ImageUrl="~/Image/calendar.png" Width="20px" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text="Teste de AutoAvaliação:"> </asp:Label>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text="1:"> </asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rd1Sim" runat="server" GroupName="1" Text="Sim" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rd1Nao" runat="server" GroupName="1" Text="Não" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Text="2:"> </asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rd2Sim" runat="server" GroupName="2" Text="Sim" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rd2Nao" runat="server" GroupName="2" Text="Não" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Text="3:"> </asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rd3Sim" runat="server" GroupName="3" Text="Sim" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rd3Nao" runat="server" GroupName="3" Text="Não" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Text="4:"> </asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rd4Sim" runat="server" GroupName="4" Text="Sim" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rd4Nao" runat="server" GroupName="4" Text="Não" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <br />
    <fieldset style="width: 950px;">
        <legend>Lista de Empresas</legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnExportar" runat="server" ImageUrl="~/Image/excel_icon.png"
                        OnClick="ImgBttnExportar_Click" />
                        &nbsp;
                    <asp:ImageButton ID="ImgBttnIncluir" runat="server" ImageUrl="~/Image/btn_editar16.gif" 
                        OnClick="ImgBttnIncluir_Click"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div align="center">
                        <asp:GridView ID="grdEmpresas" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="15" Width="100%" AutoGenerateColumns="False" OnPageIndexChanging="grdEmpresas_PageIndexChanging"
                            OnRowUpdating="grdEmpresas_RowUpdating">
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Small" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#8B8989" ForeColor="White" HorizontalAlign="Center" Font-Size="Smaller" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                Não existem dados*
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Razão Social">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.IdEmpresaCadastro")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Razão Social">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.RazaoSocial")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nome Fantasia">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.NomeFantasia")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.Estado.Estado")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CPF/CNPJ">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.CPF_CNPJ")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2006">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.BooleanUtils.ToString(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "EmpresaCadastro.ParticipouMPE2006")))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2007">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.BooleanUtils.ToString(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "EmpresaCadastro.ParticipouMPE2007")))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2008">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.BooleanUtils.ToString(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "EmpresaCadastro.ParticipouMPE2008")))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2009">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.BooleanUtils.ToString(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "EmpresaCadastro.ParticipouMPE2009")))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2010">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.BooleanUtils.ToString(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "EmpresaCadastro.ParticipouMPE2010")))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2011">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.BooleanUtils.ToString(Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "EmpresaCadastro.ParticipouMPE2011")))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ação">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnAcao" runat="server" ImageUrl="~/Image/button_cancel.gif"
                                            CommandName="Delete" CausesValidation="false" Width="15px" />
                                        <asp:Label ID="LblAcao" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Ativo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Questionário">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnQuestionario" runat="server" ImageUrl="~/Image/ico_editar.gif"
                                            CommandName="Questionario" CausesValidation="false" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnEditar" runat="server" ImageUrl="~/Image/ico_editar.gif"
                                            CommandName="Update" CausesValidation="false" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <uc1:UCExportarInscritas ID="UCExportarInscritas1" runat="server" />
    <uc2:ucinscricaoempresaia ID="UCInscricaoEmpresaIA1" runat="server" />
</asp:Content>
