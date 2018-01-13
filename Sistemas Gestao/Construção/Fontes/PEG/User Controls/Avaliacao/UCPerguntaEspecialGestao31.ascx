<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerguntaEspecialGestao31.ascx.cs"
    Inherits="PEG.User_Controls.Avaliacao.UCPerguntaEspecialGestao31" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:HiddenField ID="HdnIdQuestionarioEmpresa" runat="server" />
<asp:HiddenField ID="HdnIdEmpresaCadastro" runat="server" />
<asp:HiddenField ID="HdnIdQuestionario" runat="server" />
<asp:HiddenField ID="HdnIdTurma" runat="server" />
<asp:HiddenField ID="HdnIdPergunta" runat="server" />
<br clear="all" />
<div class="divPerguntas" id="divPerguntas" style="display: block;" runat="server">
    <asp:Label ID="lblNumeroPergunta" runat="server" Text="" CssClass="ajuda_pergunta"></asp:Label>
    <asp:Label ID="lblPergunta" runat="server" Text="" Width="720px"></asp:Label>
    <br clear="all" />
    <table cellSpacing="0" cellPadding="1"  border="0" style="width:900px; margin-top:20px;">
        <tr>
            <td class="opcao">
            </td>
            <td align="center" colspan="2" class="opcao">
                Controla</td>
            <td align="center" colspan="3" class="opcao">
                Ano
            </td>
            <td align="center" class="opcao" >&nbsp;
            </td>
        </tr>
        <tr>
            <td class="">
                <b>  Indicadores </b>
            </td>
            <td>
                <b> Sim </b>
            </td>
            <td>
                <b> Não </b>
            </td>
            <td>
                <b> 2008 </b>
            </td>
            <td>
                <b> 2009 </b>
            </td>
            <td>
                <b> 2010 </b>
            </td>
            <td>
                <b>  Desempenho</b></td>
        </tr>
        <tr>
            <td class="style3">
                Receita Total (R$)
            </td>
            <td>
                <asp:RadioButton TabIndex="121" GroupName="receita"  ID="rdSim31" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="122"  GroupName="receita"  ID="rdNao31" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="123" ID="tx1_31" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="124" ID="tx2_31" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="125" ID="tx3_31" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                                      
                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto maior melhor</span></td>
        </tr>
        <tr>
            <td class="style3">
                Despesa Total (R$)
            </td>
            <td>
                <asp:RadioButton TabIndex="126" GroupName="despesa"  ID="rdSim32" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="127" GroupName="despesa"  ID="rdNao32" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="128" ID="tx1_32" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="129" ID="tx2_32" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="130" ID="tx3_32" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                                      
                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto menor melhor</span></td>
        </tr>
        <tr>
            <td class="style3">
                Índice de satisfação
            </td>
            <td>
                <asp:RadioButton TabIndex="131" GroupName="Satisfacao"   ID="rdSim33" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="132" GroupName="Satisfacao"   ID="rdNao33" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="133" ID="tx1_33" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="134" ID="tx2_33" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="135" ID="tx3_33" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                                      
                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto maior melhor</span></td>
        </tr>
        <tr>
            <td class="style3">
            Nº de reclamações 
            </td>
            <td>
                <asp:RadioButton TabIndex="136" GroupName="Reclamaca"   ID="rdSim34" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="137" GroupName="Reclamaca"  ID="rdNao34" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="138" ID="tx1_34" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="139" ID="tx2_34" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="140" ID="tx3_34" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                                      
                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto menor melhor</span></td>
        </tr>
                                
        <tr>
            <td class="style3">
            Nº de colaboradores 
            </td>
            <td>
                <asp:RadioButton TabIndex="141" GroupName="colaboradores"    ID="rdSim35" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="142" GroupName="colaboradores"   ID="rdNao35" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="143" ID="tx1_35" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="144" ID="tx2_35" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="145" ID="tx3_35" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                                      
                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto maior melhor</span></td>
        </tr>
                                
        <tr>
            <td class="style3">
            Rotatividade
            </td>
            <td>
                <asp:RadioButton TabIndex="146" GroupName="Rotatividade"   ID="rdSim36" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="147" GroupName="Rotatividade"  ID="rdNao36" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="148" ID="tx1_36" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="149" ID="tx2_36" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="150" ID="tx3_36" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                                      
                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto menor melhor</span></td>
        </tr>
                                
        <tr>
            <td class="style3">
            Nº de acidentes com afastamento
            </td>
            <td>
                <asp:RadioButton TabIndex="151" GroupName="acidadente"  ID="rdSim37" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="152" GroupName="acidadente"   ID="rdNao37" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="153" ID="tx1_37" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="154" ID="tx2_37" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="155" ID="tx3_37" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                                      
                <span lang="EN-US" style="font-size:9.0pt;font-family:
;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto menor melhor</span></td>
        </tr>
                                
        <tr>
            <td class="style3">
            Produção 
            </td>
            <td>
                <asp:RadioButton TabIndex="156" GroupName="Producao" ID="rdSim38" runat="server" />
            </td>
            <td>
                <asp:RadioButton TabIndex="157" GroupName="Producao" ID="rdNao38" runat="server" />
            </td>
            <td>
                <asp:TextBox TabIndex="158" ID="tx1_38" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="159" ID="tx2_38" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox TabIndex="160" ID="tx3_38" runat="server" Text="" Enabled="false"></asp:TextBox>
            </td>
            <td>
                                      
                <span lang="EN-US" style="font-size:9.0pt;font-family:
                ;Arial;,;sans-serif;;mso-fareast-font-family:;Times New Roman;;mso-ansi-language:
                EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">quanto maior melhor</span></td>
        </tr>
        </tr>
    </table>
</div>
