using AppEmpleadosCloud.App.packages.Controler;
using AppEmpleadosCloud.App.packages.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEmpleadosCloud.App
{
    public partial class ListarEmpleados : System.Web.UI.Page
    {

        EmpleadosControler empleados = new EmpleadosControler();
        protected void Page_Load(object sender, EventArgs e)
        {
            //gvEmpleados.PageIndex = e.NewPageIndex;
            List<Empleados> listaEmpleados = empleados.GetEmpleados();
            gvEmpleados.DataSource = listaEmpleados;
            gvEmpleados.DataBind();
        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpleados.PageIndex = e.NewPageIndex;
            List<Empleados> listaEmpleados = empleados.GetEmpleados();
            gvEmpleados.DataSource = listaEmpleados;
            gvEmpleados.DataBind();
        }

        protected void btnListartodo_Click(object sender, EventArgs e)
        {
            //invocamos el objeto para listar todos los empleaodos
            List<Empleados> listaEmpleados = empleados.GetEmpleados();
            // volcamos la lista a nuestro gridview
            gvEmpleados.DataSource = listaEmpleados;
            gvEmpleados.DataBind();
        }

        protected void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (empleados.ExisteEmpleado(InCodigoBuscar.Text))
            {
                Response.Redirect("Formulario.aspx?id=" + InCodigoBuscar.Text);
            }
            else
            {
                LabelBuscar.Text = "No existe el codigo en la BD";
            }

        }

        protected void gvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(gvEmpleados.DataKeys[indice].Value);
                //Response.Write("Valor de Fila" + indice);
                //Response.Write("Valor Celda" + valor);
                Response.Redirect("Formulario.aspx?id=" + valor);
            }
        }
    }
}