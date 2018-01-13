<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCListaQuestionariosAvaliacao.ascx.cs" Inherits="Sistema_de_Gestao.User_Controls.UCListaQuestionariosAvaliacao" EnableViewState="true"%>
<%@ Register Src="/User Controls/UCPerguntaAvaliar.ascx" TagName="UCPerguntaAvaliar" TagPrefix="uc1" %>

<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-color: #FFFFFF; width: 900px; height: 100%;
    background-repeat: repeat; position: absolute; left: 100px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldIdAdmGrupo" runat="server" />
        <asp:HiddenField ID="HddnFldIdEtapa" runat="server" />
        <asp:HiddenField ID="HddnFldIdEmpresaCadastro" runat="server" />
        <asp:HiddenField ID="HddnFldIdTurma" runat="server" />
        <fieldset class="fieldsetUC">
            <legend style="font-weight: bold;">Avaliação </legend>
                <asp:GridView ID="grdPerguntas" runat="server" Width="100%"  onrowcommand="grdPerguntas_RowCommand" AllowPaging="true" PageSize="15"
                OnPageIndexChanging="grdPerguntas_PageIndexChanging" DataKeyNames="Pergunta" AutoGenerateColumns="False" OnRowDataBound="grdPerguntas_RowDataBound">
                    <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                    <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                    <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                    <AlternatingRowStyle BackColor="White" />
                    <EmptyDataTemplate>
                        <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="IdPergunta" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdPergunta" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Pergunta.IdPergunta")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IdQuestionarioEmpresa" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdQuestionarioEmpresa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuestionarioEmpresa.IdQuestionarioEmpresa")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IdAvaliador" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="IdAvaliador" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UsuarioAvaliador.IdUsuario")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Questionário">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "QuestionarioEmpresa.Questionario.Questionario")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="15%"  />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pergunta">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Pergunta.NumeroQuestao")%> <%# DataBinder.Eval(Container.DataItem, "Pergunta.Pergunta")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" Width="75%"  />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Avaliar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBttnAvaliar" runat="server" ImageUrl="~/Image/file_search2.png" CommandName="Avaliar" CommandArgument="<%# Container.DataItemIndex %>"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </fieldset>
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="LblJustificativa" runat="server" Text="Conclusão:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TxtJustificativa" Rows="5" TextMode="MultiLine" runat="server" Width="450px" Font-Names="Arial" Font-Size="12px"/>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:ImageButton ID="ImgBttnEnviar" runat="server" ImageUrl="~/Image/_file_save.png"  OnClientClick="javascript:return confirm('Confirma Envio de Avaliação?');"
                        OnClick="ImgBttnEnviar_Click"  />&nbsp;&nbsp;
                    <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                        OnClick="ImgBttnVoltar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>

    <uc1:UCPerguntaAvaliar ID="UCPerguntaAvaliar1" runat="server" />

</div>
