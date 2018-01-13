<%@ Page Title="Inscrições" Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="InscricaoAdminCE.aspx.cs" Inherits="Sistema_de_Gestao.MPE.Paginas.InscricaoAdminCE" %>

<%@ Register Src="~/User Controls/UCExportarInscritas.ascx" TagName="UCExportarInscritas"
    TagPrefix="uc1" %>
<%@ Register Src="~/User Controls/UCInscricaoEmpresaIA.ascx" TagName="UCInscricaoEmpresaIA"
    TagPrefix="uc2" %>
<%@ Register Src="~/MPE/User Control/UCHistoricoRAA.ascx" TagName="UCHistoricoRAA"
    TagPrefix="uc3" %>
<%@ Register Src="~/User Controls/UCListaQuestionariosDigitador.ascx" TagName="UCListaQuestionariosDigitador"
    TagPrefix="uc4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc3" %>
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
        function WindowOpen(url) {
            window.open(url);
        }
    </script>
    <h3>
        Inscrições</h3>
    <fieldset style="width: 900px; font-size: 12px; white-space: nowrap;">
        <legend>Pesquisa </legend>
        <div id="filtroSimples">
            <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="tabFiltros">
                <tr>
                    <td width="190px">
                        <asp:Label ID="Label25" runat="server" Text="Ano:"> </asp:Label>
                    </td>
                    <td rowspan="5" width="300px">
                        <uc3:UCEstado ID="UCEstado1" runat="server" EscritorioRegional="True" Regiao="True"
                            Bairro="False" Grupo="True" TabIndex="1" Font-Names="Verdana" Font-Size="08" />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Razão Social:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxRazaoSocial" runat="server" Width="200px" TabIndex="7" Font-Names="Verdana"
                            Font-Size="08"></asp:TextBox>
                    </td>
                    <td rowspan="2">
                        <asp:ImageButton ID="ImgBttnMais" runat="server" ImageUrl="~/Image/ico_add.png" Width="25"
                            OnClick="ImgBttnMais_Click" />
                        <asp:ImageButton ID="ImgBttnMenos" runat="server" Visible="false" Width="25" ImageUrl="~/Image/ico_remove.png"
                            OnClick="ImgBttnMenos_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:"> </asp:Label>
                    </td>
                    <td width="200px">
                        <asp:Label ID="lblNome" runat="server" Text="Nome Fantasia:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBxNomePesquisa" runat="server" Width="200px" TabIndex="8" Font-Names="Verdana"
                            Font-Size="08"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblES" runat="server" Text="Escritório Regional:"> </asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="CNPJ:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCpfCnpj" runat="server" Width="200px" MaxLength="18" onKeyDown="Mascara(this,CpfCnpj);"
                            onKeyPress="Mascara(this,CpfCnpj);" onKeyUp="Mascara(this,CpfCnpj);" TabIndex="9"
                            Font-Names="Verdana" Font-Size="08"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label26" runat="server" Text="Região:"> </asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Protocolo:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtProtocolo" runat="server" TabIndex="10" Width="200px" Font-Names="Verdana"
                            Font-Size="08"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label27" runat="server" Text="Cidade:"> </asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Status:"> </asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="205" DataValueField="IdStatus"
                            DataTextField="Status" TabIndex="11" Font-Names="Verdana" Font-Size="08">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Período"> </asp:Label>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="De:"> </asp:Label>
                                    <asp:TextBox ID="txtDe" runat="server" Width="75" TabIndex="20" Font-Names="Verdana"
                                        Font-Size="08"></asp:TextBox>
                                    <asp:ImageButton ID="ibtnDe" ImageUrl="~/Image/Calendario.gif" runat="server" TabIndex="21" />
                                    <cc1:MaskedEditExtender ID="MskdEdtExtndrDe" runat="server" MaskType="Date" Mask="99/99/9999"
                                        TargetControlID="txtDe">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="ClndrExtndrDe" runat="server" Format="dd/MM/yyyy" PopupButtonID="ibtnDe"
                                        TargetControlID="txtDe">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Até:"> </asp:Label>
                                    <asp:TextBox ID="txtAte" runat="server" Width="75" TabIndex="22" Font-Names="Verdana"
                                        Font-Size="08"></asp:TextBox>
                                    <asp:ImageButton ID="btnAte" ImageUrl="~/Image/Calendario.gif" runat="server" TabIndex="23" />
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date" Mask="99/99/9999"
                                        TargetControlID="txtAte">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnAte"
                                        TargetControlID="txtAte">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Setor:"> </asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlCategoria" runat="server" Width="205" DataValueField="IdCategoria"
                            DataTextField="Categoria" TabIndex="12" Font-Names="Verdana" Font-Size="08">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div id="filtroCompleto" runat="server" visible="false">
            <table cellspacing="1" cellpadding="1" align="center" border="0" width="100%">
                <tr>
                    <td width="180px">
                        <asp:Label ID="Label12" runat="server" Text="Faixa de Faturamento:"> </asp:Label>
                    </td>
                    <td width="292px">
                        <asp:DropDownList ID="ddlFaturamento" runat="server" DataValueField="IdFaturamento"
                            Width="255px" DataTextField="Faturamento" TabIndex="13" Font-Names="Verdana"
                            Font-Size="08">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="182px">
                        <asp:Label ID="Label7" runat="server" Text="Tipo de Empresa:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoEmpresa" runat="server" DataValueField="IdTipoEmpresa"
                            Width="205" DataTextField="TipoEmpresa" TabIndex="17" Font-Names="Verdana" Font-Size="08">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Número de Colaboradores:"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumeroFuncionarios" runat="server" Width="250" TabIndex="14" Font-Names="Verdana"
                            Font-Size="08"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Faixa Etária dos Contatos:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFaixaEtaria" runat="server" DataValueField="IdContatoFaixaEtaria"
                            DataTextField="ContatoFaixaEtaria" Width="205" TabIndex="18" Font-Names="Verdana"
                            Font-Size="08">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="Escolaridade dos Contatos:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNivelEscolaridade" runat="server" DataValueField="IdContatoNivelEscolaridade"
                            DataTextField="ContatoNivelEscolaridade" Width="255" TabIndex="15" Font-Names="Verdana"
                            Font-Size="08">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Sexo dos Contatos:"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSexo" runat="server" Width="205" TabIndex="19" Font-Names="Verdana"
                            Font-Size="08">
                            <asp:ListItem Selected="True" Text="Todos" Value="0"></asp:ListItem>
                            <asp:ListItem Selected="False" Text="Masculino" Value="M"></asp:ListItem>
                            <asp:ListItem Selected="False" Text="Feminino" Value="F"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div align="right">
            <asp:ImageButton ID="ImgBttnPesquisar" runat="server" ImageUrl="~/Image/file_search2.png"
                OnClick="ImgBttnPesquisar_Click" TabIndex="24" />
        </div>
    </fieldset>
    <fieldset style="width: 900px;">
        <legend>Lista de Empresas</legend>
        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnEmitirEtiqueta" ToolTip="Emitir Etiquetas" runat="server"
                        ImageUrl="~/Image/_file_label.png" Visible="false" />
                    &nbsp;
                    <asp:ImageButton ID="ImgBttnExportar" runat="server" ImageUrl="~/Image/_file_export2.png"
                        OnClick="ImgBttnExportar_Click" Visible="false"/>
                    &nbsp;
                    <asp:ImageButton ID="ImgBttnIncluir" runat="server" ImageUrl="~/Image/_file_add2.png"
                        OnClick="ImgBttnIncluir_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div align="center">
                        <asp:GridView ID="grdEmpresas" runat="server" AllowPaging="True" AllowSorting="True"
                            OnRowCommand="grdEmpresas_RowCommand" PageSize="15" Width="100%" AutoGenerateColumns="False"
                            OnPageIndexChanging="grdEmpresas_PageIndexChanging" OnRowUpdating="grdEmpresas_RowUpdating"
                            OnRowDeleting="grdEmpresas_RowDeleting" OnRowDataBound="grdEmpresas_RowDataBound">
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                             <EmptyDataTemplate>
                                A consulta não retornou dados para os filtros utilizados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="IdEmpresaCadastro" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEmpresaCadastro" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.IdEmpresaCadastro")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdTurma" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdTurma" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container.DataItem, "Turma.IdTurma")%>'></asp:Label>
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
                                        <%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CNPJ">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "EmpresaCadastro.CPF_CNPJ")))%>
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
                                <asp:TemplateField HeaderText="Participante" Visible="false">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnParticipaPrograma" runat="server" ImageUrl="~/Image/file_delete2.png"
                                            CommandName="Delete" CausesValidation="false" Width="20px" />
                                        <asp:Label ID="LblParticipaPrograma" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ParticipaPrograma")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnEditar" runat="server" ImageUrl="~/Image/file_edit2.png"
                                            CommandName="Update" CausesValidation="false" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Questionário">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnQuestionario" runat="server" ImageUrl="~/Image/_file_resume2.png"
                                            CommandName="Questionario" CausesValidation="false" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.IdEmpresaCadastro")%>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Histórico">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnResumo" runat="server" ImageUrl="~/Image/_file_resume2.png"
                                            CommandName="ResumoRAA" CausesValidation="false" CommandArgument="<%# Container.DataItemIndex %>"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FlEtapaAtiva" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlEtapaAtiva" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container.DataItem, "EtapaAtiva")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <uc1:UCExportarInscritas ID="UCExportarInscritas1" runat="server" />
    <uc2:UCInscricaoEmpresaIA ID="UCInscricaoEmpresaIA1" runat="server" />
    <uc3:UCHistoricoRAA ID="UCHistoricoRAA1" runat="server" />
    <uc4:UCListaQuestionariosDigitador ID="UCListaQuestionariosDigitador1" runat="server" />
</asp:Content>
