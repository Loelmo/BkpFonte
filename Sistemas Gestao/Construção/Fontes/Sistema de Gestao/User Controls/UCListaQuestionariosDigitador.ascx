<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCListaQuestionariosDigitador.ascx.cs" Inherits="Sistema_de_Gestao.User_Controls.UCListaQuestionariosDigitador" EnableViewState="true"%>
<%@ Register Src="/User Controls/UCQuestionarioResponder.ascx" TagName="UCQuestionarioResponder" TagPrefix="uc1" %>

<div id="divUserControl" runat="server" visible="false" valign="middle" align="center"
    style="background-color: #FFFFFF; width: 900px; height: 100%;
    background-repeat: repeat; position: absolute; left: 50px; top: 0px">
    <asp:Panel ID="PnlFundo" CssClass="panelUC" runat="server">
        <asp:HiddenField ID="HddnFldIdAdmGrupo" runat="server" />
        <asp:HiddenField ID="HddnFldIdEtapa" runat="server" />
        <asp:HiddenField ID="HddnFldIdEmpresaCadastro" runat="server" />
        <asp:HiddenField ID="HddnFldIdTurma" runat="server" />
        <fieldset class="fieldsetUC">
            <legend style="font-weight: bold;">Questionários </legend>
                <asp:GridView ID="grdPerguntas" runat="server" Width="100%"  onrowcommand="grdPerguntas_RowCommand" AllowPaging="true" PageSize="15"
                OnPageIndexChanging="grdPerguntas_PageIndexChanging" DataKeyNames="Questionario" AutoGenerateColumns="False" OnRowDataBound="grdPerguntas_RowDataBound">
                    <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                    <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                    <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                    <AlternatingRowStyle BackColor="White" />
                    <EmptyDataTemplate>
                        <font style="font-size: 12px; color: red">Nenhum registro encontrado !</font>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="IdQuestionario" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdQuestionario" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdQuestionario")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Questionário">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Questionario")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="15%"  />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Responder">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBttnAvaliar" runat="server" ImageUrl="~/Image/file_search2.png" CommandName="Responder" CommandArgument="<%# Container.DataItemIndex %>"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </fieldset>
        <table>
            <tr>
                <td>Enviar questionário:
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/_file_send2.png"
                        OnClick="BtnEnviar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                </td>
                <td>
                    <asp:ImageButton ID="ImgBttnCancelar" runat="server" ImageUrl="~/Image/_file_back2.png"
                        OnClick="ImgBttnVoltar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>

    <uc1:UCQuestionarioResponder ID="UCQuestionarioResponder1" runat="server" />

</div>
