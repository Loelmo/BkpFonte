<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="PEG.Paginas.FileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:FileUpload ID="fluArquivo" runat="server" Font-Names="Verdana" Font-Size="08"/>&nbsp;&nbsp;
                    <asp:ImageButton ID="imgBttnUpload" runat="server" ValidationGroup="vgUploadArquivo"
                        ImageUrl="~/Image/upload.gif" OnClick="imgBttnUpload_Click" ToolTip="Clique para fazer o upload do arquivo !" /><br />
                    <asp:Label ID="lblArquivoUpload" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
