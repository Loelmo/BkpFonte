<%@ Page Title="Candidatas " Language="C#" MasterPageFile="~/Master Page/Principal.Master"
    AutoEventWireup="true" CodeBehind="RankingCandidataNacional.aspx.cs" Inherits="PEG.Paginas.RankingCandidataNacional" %>

<%@ Register Src="/User Controls/UCEstado.ascx" TagName="UCEstado" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>



<%@ Register Src="~/User Controls/UCFiltroRanking.ascx" TagName="UCFiltroRanking" tagprefix="uc2" %>

<%@ Register Src="~/MPE/User Control/UCJustificativaRanking.ascx" TagName="UCJustificativaRanking"
    TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3> Ranking Candidata Nacional  </h3>
    <fieldset>
        <legend>Pesquisa </legend>



            <uc2:UCFiltroRanking ID="UCFiltroRanking1" runat="server" 
                EtapaRanking="Candidata" IsEstadual="True"  />


        <div align="right">
            <br />
            <asp:ImageButton ID="ImgBttnPesquisar" runat="server" 
                ImageUrl="~/Image/file_search2.png" onclick="ImgBttnPesquisar_Click"/>
        </div>

    </fieldset>

    <fieldset id="RankingSimplificado">

        <legend runat="server" id="TituloBoxSimplificado" visible="false">Lista de Empresas Simplificado</legend>
        <legend runat="server" id="TituloBoxDetalhado" visible="false">Lista de Empresas Detalhado</legend>

        <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td align="right">
                    <asp:ImageButton ID="ImgBttnExportar" runat="server" ImageUrl="~/Image/_file_xls.png" />&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">


<div style="width: 929px; overflow: auto" >



                        <asp:GridView ID="grdSimplificado" runat="server" AllowPaging="True" AllowSorting="True"
                            PageSize="10" Width="1500" AutoGenerateColumns="False" 
                            OnRowDataBound="grdSimplificado_RowDataBound" 
                            onpageindexchanging="grdSimplificado_PageIndexChanging" DataKeyNames="IdQuestionarioEmpresa,Classificar"
                            onrowcommand="grdSimplificado_RowCommand" 
                            onrowupdating="grdSimplificado_RowUpdating" >
                            <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                            <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="IdEmpresaCadastro" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEmpresaCadastro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEmpresaCadastro")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdQuestionarioEmpresa" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQuestionarioEmpresa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdQuestionarioEmpresa")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdEstado" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEstado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEstado")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdQuestionario" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQuestionario" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdQuestionario")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FlEtapaAtiva" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlEtapaAtiva" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EtapaAtiva")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FlPassaProximaEtapa" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlPassaProximaEtapa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassaProximaFase")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdEtapa" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEtapa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdEtapa")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Protocolo" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProtocolo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Protocolo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliadores" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdAvaliadorSenior" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdAvaliadorSenior")%>'></asp:Label>
                                        <asp:Label ID="lblIdAvaliadorAcompanhante" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdAvaliadorAcompanhante")%>'></asp:Label>
                                        <asp:Label ID="lblNomeAvaliadorSenior" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NomeAvaliadorSenior")%>'></asp:Label>
                                        <asp:Label ID="lblNomeAvaliadorAcompanhante" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NomeAvaliadorAcompanhante")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Classificar">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChckBxClassificar" runat="server" Visible="false" Checked='<%# Vinit.SG.Common.ObjectUtils.ToBoolean(DataBinder.Eval(Container.DataItem, "Classificar"))%>'/>
                                        <asp:ImageButton ID="ImgBttnClassificar" runat="server" CommandName="Update"/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Avaliador">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DrpDwnLstSenior" runat="server" Width="150"   DataValueField="IdUsuario" DataTextField="Usuario" >
                                        </asp:DropDownList>

                                        <asp:DropDownList ID="DrpDwnLstAcompanhante" runat="server"  Width="150" DataValueField="IdUsuario" DataTextField="Usuario" >
                                        </asp:DropDownList>

                                        <asp:ImageButton ID="ImgBttnGravar" runat="server" ImageUrl="~/Image/_file_save.png" CommandName="Gravar" CommandArgument="<%# Container.DataItemIndex %>"/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px"/>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Ranking">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRanking" runat="server" Text="0"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CPF CNPJ">
                                    <ItemTemplate>
                                        <%# Vinit.SG.Common.FormatUtils.FormataCNPJ_CPF(Vinit.SG.Common.ObjectUtils.ToString(DataBinder.Eval(Container.DataItem, "CpfCnpj")))%> 
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Razão Social">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px"/>
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:TemplateField>              

                                <asp:TemplateField HeaderText="Pontuação Total (Responsabilidade Social)" Visible="false">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoTotalResponsabilidadeSocial")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Total (Inovação)" Visible="false">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoTotalInovacao")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Total (Gestão)">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoTotalPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total Enfoque">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "EnfoquePreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold"/>
                                </asp:TemplateField>                                                 
                                <asp:TemplateField HeaderText="Total Resultados (Controle)">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "ResultadoControlePreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Resultados (Tendência)">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "ResultadoTendenciaPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Gold"/>
                                </asp:TemplateField>                              
                                
                                <asp:TemplateField HeaderText="Pontuação Total">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoTotalPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod"/>
                                </asp:TemplateField>       
                                
                                <asp:TemplateField HeaderText="Pontuação Total (Responsabilidade Social)">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoTotalResponsabilidadeSocial")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Total (Inovação)">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "PontuacaoTotalInovacao")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" BackColor="Goldenrod" />
                                </asp:TemplateField>   
                                                                                                          
                                <asp:TemplateField HeaderText="Relação com melhor da categoria">
                                    <ItemTemplate>
                                        
                                        <%# Vinit.SG.Common.DoubleUtils.ToString(Vinit.SG.Common.ObjectUtils.ToDouble(DataBinder.Eval(Container.DataItem, "RelacaoMelhorCategoriaPreVisita")))%> 
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod"/>
                                </asp:TemplateField>  

                                <asp:TemplateField HeaderText="Pontuação Cliente">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioClientePreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Sociedade">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioSociedadePreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Liderança">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioLiderancaPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Estratégias e Planos">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioEstrategiaPlanosPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Pessoas">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioPessoasPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Processos">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioProcessosPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pontuação Informações e Conhecimento">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "CriterioInformacoesConhecimentoPreVisita")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" BackColor="Goldenrod" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Gerar RAA">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImagBttnDownload" runat="server" ImageUrl="~/Image/_file_download2.png"
                                            CommandName="Download" CausesValidation="false" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px"/>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        </div> 
                        
                </td>
            </tr>
        </table>
    </fieldset>
    <uc3:UCJustificativaRanking ID="UCJustificativaRanking1" runat="server" />
</asp:Content>
