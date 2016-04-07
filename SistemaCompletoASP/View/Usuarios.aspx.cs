using Newtonsoft.Json.Linq;
using SistemaCompletoASP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCompletoASP
{
    public partial class _Inicio : System.Web.UI.Page
    {

        UsuariosController obj;

        protected void Page_Load(object sender, EventArgs e)
        {

            /*Si no se ha iniciado sesion, entonces se va a login*/
            if (Session.Count == 0)
            {
                Response.Redirect("~/LogIn.aspx");
            }       

            obj = new UsuariosController();
            listar();
        }

        public void limpiar()
        {
            txtId.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }


        public void listar()
       {
            IList<String> data = (IList<String>)obj.ListInfo();

            int registros = (Convert.ToInt32(data.ElementAt(data.Count-1)));
            int atributos = (Convert.ToInt32(data.ElementAt(data.Count-2)));
            int total = registros * atributos;

            construirCabecera();

            for (int x = 0; x < total; x = x + atributos)
            {
                // Create new row and add it to the table.
                TableRow tRow = new TableRow();
                tblListado.Rows.Add(tRow);
                for (int y = 0; y < atributos; y++)
                {
                    // Create a new cell and add it to the row.
                    TableCell tCell = new TableCell();
                    tCell.Text = data.ElementAt(x+y);
                    tRow.Cells.Add(tCell);
                }
            }                       
        }


        public void construirCabecera()
        {
            /*LIMPIA LOS ELEMENTOS DE LA TABLA*/
            tblListado.Rows.Clear();

            /*SE AÑADE UN TR*/
            TableRow tRowTitulo = new TableRow();
            tblListado.Rows.Add(tRowTitulo);

            /*SE AÑADE UN TH*/
            TableHeaderCell tCell1 = new TableHeaderCell();
            tCell1.Text = "ID";
            tRowTitulo.Cells.Add(tCell1);

            /*SE AÑADE UN TH*/
            TableHeaderCell tCell2 = new TableHeaderCell();
            tCell2.Text = "USUARIO";
            tRowTitulo.Cells.Add(tCell2);

            /*SE AÑADE UN TH*/
            TableHeaderCell tCell3 = new TableHeaderCell();
            tCell3.Text = "PASSWORD";
            tRowTitulo.Cells.Add(tCell3);
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            int id = (txtId.Text != "") ? Convert.ToInt32(txtId.Text) : -1;
            string usuario = txtUsuario.Text;
            string pass = txtPassword.Text;

            bool respuesta = obj.SaveInfo(id: id, usu: usuario, pass: pass);

            if (respuesta)
            {
                string script = "alert(\"Operacion exitosa!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                limpiar();
                listar();
            }
            else
            {
                string script = "alert(\"Error en la operacion!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            IList<String> data = (IList<String>)obj.SearchInfo(usu: usuario);
            if (data.Count > 0)
            {
                txtId.Text = data[0];
                txtUsuario.Text = data[1];
                txtPassword.Text = data[2];
            }
            else
            {
                string script = "alert(\"No existe!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }

        }



        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (txtId.Text != "") ? Convert.ToInt32(txtId.Text) : -1;
            bool status = false;

            if (id != -1)
            {
                status = obj.DeleteInfo(id: id);
            }
            else
            {
                string script = "alert(\"Busque elemento a eliminar!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }

            if (status)
            {
                string script = "alert(\"Operacion exitosa!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);

                limpiar();
                listar();
            }
            else
            {
                string script = "alert(\"Error en la operacion!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }                        
        }


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }





    }
}