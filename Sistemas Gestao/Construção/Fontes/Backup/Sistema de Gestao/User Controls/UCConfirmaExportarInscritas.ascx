<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCConfirmaExportarInscritas.ascx.cs"
    Inherits="Sistema_de_Gestao.User_Controls.UCConfirmaExportarInscritas" %>
<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-image: url('/Image/BGLocked.png'); width: 100%; height: 100%;
    background-repeat: repeat; position: absolute; left: 0px; top: 0px">
    <asp:Panel ID="PnlFundo" runat="server" Width="700px" Height="200px" BackColor="White"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1" Style="position: relative;
        top: 10%; font-size: 11px;">
        <asp:HiddenField ID="HddnTipoArquivo" runat="server" />
        <fieldset>
            <legend style="font-size: large">Exportar</legend>
            <br />
            <table cellspacing="1" cellpadding="1" border="0" style="text-align: left;">
                <tr>
                    <td>
                        <asp:Label ID="lblTamanho" runat="server" Text="Tamanho:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTamanhoValor" runat="server" Text="" Width="300px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Tempo Estimado:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDiscada" runat="server" Text="" Width="300px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblBandaLarga" runat="server" Text="" Width="300px"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
        <div align="center">
            <br />
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImgBttnExportar" runat="server" ImageUrl="~/Image/_file_export2.png" />
                    </td>
                    &nbsp;&nbsp;
                    <td>
                        <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                            OnClick="ImgBttnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="grdEmpresasExport" runat="server" Width="100%" AutoGenerateColumns="False"
            Visible="false" BorderColor="White" OnRowDataBound="grdEmpresasExport_RowDataBound">
            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
            <SelectedRowStyle BackColor="#004a91" ForeColor="Navy" />
            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
            <AlternatingRowStyle BackColor="White" />
            <EmptyDataTemplate>
                Não existem dados*
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="Razão Social">
                    <ItemTemplate>
                        <asp:Label ID="Label0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.RazaoSocial")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nome Fantasia">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmpresaCadastro.NomeFantasia")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CPF/CNPJ">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Vinit.SG.Common.StringUtils.trataCpfCnpj(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "EmpresaCadastro.CPF_CNPJ")))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data de Abertura da Empresa">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}", Vinit.SG.Common.ObjectUtils.ToDate(DataBinder.Eval(Container.DataItem, "EmpresaCadastro.AberturaEmpresa")))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Número de Colaboradoress">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumeroFuncionario")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Endereço">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Endereco")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bairro">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Bairro.Bairro")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cidade">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Cidade.Cidade")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Estado.Estado")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CEP">
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatCEP(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CEP")))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tipo de Empresa">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoEmpresa.TipoEmpresa")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Faturamento Anual em 2010">
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Faturamento.Faturamento")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Setor">
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Categoria.Categoria")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Atividade Econômica">
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AtividadeEconomica.AtividadeEconomica")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Principal Atividade">
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AtividadeEconomicaComplemento")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nome Completo">
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NomeContato")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cargo">
                    <ItemTemplate>
                        <asp:Label ID="Label16" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Cargo.Cargo")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CPF Contato">
                    <ItemTemplate>
                        <asp:Label ID="Label17" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CPFContato")))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Endereço Completo">
                    <ItemTemplate>
                        <asp:Label ID="Label18" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EnderecoContato")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bairro Contato">
                    <ItemTemplate>
                        <asp:Label ID="Label19" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BairroContato.Bairro")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cidade Contato">
                    <ItemTemplate>
                        <asp:Label ID="Label20" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CidadeContato.Cidade")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado Contato">
                    <ItemTemplate>
                        <asp:Label ID="Label21" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EstadoContato.Sigla")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CEP Contato">
                    <ItemTemplate>
                        <asp:Label ID="Label22" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatCEP(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CEPContato")))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telefone Fixo">
                    <ItemTemplate>
                        <asp:Label ID="Label23" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatTelefone(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "TelefoneContato")))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Celular">
                    <ItemTemplate>
                        <asp:Label ID="Label24" runat="server" Text='<%# Vinit.SG.Common.FormatUtils.FormatTelefone(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CelularContato")))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="E-mail">
                    <ItemTemplate>
                        <asp:Label ID="Label25" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailContato")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data de Nascimento">
                    <ItemTemplate>
                        <asp:Label ID="Label26" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}", Vinit.SG.Common.ObjectUtils.ToDate(DataBinder.Eval(Container.DataItem, "NascimentoContato")))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sexo">
                    <ItemTemplate>
                        <asp:Label ID="Label27" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SexoContato")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nivel de Escolaridade">
                    <ItemTemplate>
                        <asp:Label ID="Label28" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContatoNivelEscolaridade.ContatoNivelEscolaridade")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Faixa Etária">
                    <ItemTemplate>
                        <asp:Label ID="Label29" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FaixaEtaria.ContatoFaixaEtaria")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hddnNotColunasSelecionadas" runat="server" />
    </asp:Panel>
</div>
