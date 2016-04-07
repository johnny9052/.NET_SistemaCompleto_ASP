<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SistemaCompletoASP._Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Table ID="Table1" runat="server" CssClass="contenedorContenido">
        <asp:TableRow>
            <asp:TableCell>
                 <h2>Usuarios</h2>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="txtId" runat="server" CssClass="oculto"></asp:TextBox>                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Table ID="Table2" runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            Nombre usuario
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            Password
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <br />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnGuardar" runat="server" Text="guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnBuscar" runat="server" Text="buscar" OnClick="btnBuscar_Click"/>
                <asp:Button ID="btnModificar" runat="server" Text="modificar" OnClick="btnGuardar_Click"/>
                <asp:Button ID="btnEliminar" runat="server" Text="eliminar" OnClick="btnEliminar_Click"/>
                <asp:Button ID="btnLimpiar" runat="server" Text="limpiar" OnClick="btnLimpiar_Click"/>                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4">
                <asp:Table ID="tblListado" runat="server" BorderWidth="1" BorderStyle="Groove">                    
                    
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>




</asp:Content>
