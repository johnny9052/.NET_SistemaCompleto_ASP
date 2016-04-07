<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SistemaCompletoASP.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/css/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="LoginTitulo">
            Identificaci&oacute;n de Usuarios
        </div>

        <asp:Table ID="Table1" runat="server" CssClass="LoginContenedor">
            <asp:TableRow>
                <asp:TableCell>
                    <strong>Usuario</strong>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtUser" runat="server" CssClass="LoginTextField" Text="admin"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <strong>Clave</strong>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="LoginTextField" Text="admin"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesi&oacute;n" OnClick="ValidarUsuario" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>


    </form>
</body>
</html>
