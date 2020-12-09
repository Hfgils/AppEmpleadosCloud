using AppEmpleadosCloud.App.packages.Controler;
using AppEmpleadosCloud.App.packages.Entity;
using AppEmpleadosCloud.App.packages.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEmpleadosCloud
{
    public partial class Formulario : System.Web.UI.Page
    {
        ValidarFormulario validar = new ValidarFormulario();
        EmpleadosControler datos = new EmpleadosControler();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Cuando se carga el formulario 
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {

                    InCodigo.Text = Request.QueryString["id"];

                    Empleados myEmpleado = datos.consultaEmpleado(InCodigo.Text);

                    InNombre.Text = myEmpleado.Nombre;
                    InApellido.Text = myEmpleado.Apellido;
                    InCargo.Text = myEmpleado.Cargo;
                    InSalario.Text = myEmpleado.Salario;
                    InArea.Text = myEmpleado.Area;
                    InCiudad.Text = myEmpleado.Ciudad;
                    btnAgregarEmpleado.Visible = false;
                    btnBorrarEmpleado.Visible = true;
                    btnEditarEmpleado.Visible = true;
                    InCodigo.Enabled = false;

                }
                else
                {
                    InCodigo.Enabled = true;
                    btnAgregarEmpleado.Visible = true;
                    btnBorrarEmpleado.Visible = false;
                    btnEditarEmpleado.Visible = false;
                    return;
                }
            }
        }

        private void InsertarDatosBD()
        {

            Empleados myEmpleado = new Empleados();
            myEmpleado.Codigo = InCodigo.Text;
            myEmpleado.Nombre = InNombre.Text;
            myEmpleado.Apellido = InApellido.Text;
            myEmpleado.Cargo = InCargo.Text;
            myEmpleado.Salario = InSalario.Text;
            myEmpleado.Area = InArea.Text;
            myEmpleado.Ciudad = InCiudad.Text;

            if (!datos.ExisteEmpleado(InCodigo.Text))
            {
                if (datos.SetEmpleado(myEmpleado))
                {
                    LabelRta.Text = "El registro fue insertado correctamente";
                }
                else
                {
                    LabelRta.Text = "Error al insertar " + datos.Error;
                }
            }
            else
            {
                ErrorCodigo.Text = "El codigo  " + InCodigo.Text + " ya existe";
            }



        }

        protected void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            //Enviar daos
            if (!validar.Vacio(InCodigo, ErrorCodigo, "No puede ser vacio"))
                if (!validar.Vacio(InNombre, ErrorNombre, "No puede ser vacio"))
                    if (!validar.Vacio(InApellido, ErrorApellido, "No puede ser vacio"))
                        if (!validar.Vacio(InCargo, ErrorCargo, "No puede ser vacio"))
                            if (!validar.Vacio(InSalario, ErrorSalario, "No puede ser vacio"))
                                if (!validar.Vacio(InArea, ErrorArea, "No puede ser vacio"))
                                    if (!validar.Vacio(InCiudad, ErrorCiudad, "No puede ser vacio"))
                                    {
                                        InsertarDatosBD();
                                    }

        }

        private void LimpiarCampos()
        {
            InCodigo.Text = "";
            InNombre.Text = "";
            InApellido.Text = "";
            InCargo.Text = "";
            InSalario.Text = "";
            InArea.Text = "";
            InCiudad.Text = "";


        }

        protected void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            // codigo para editar el empleado

            Empleados myEmpleado = new Empleados();
            myEmpleado.Codigo = InCodigo.Text;
            myEmpleado.Nombre = InNombre.Text;
            myEmpleado.Apellido = InApellido.Text;
            myEmpleado.Cargo = InCargo.Text;
            myEmpleado.Salario = InSalario.Text;
            myEmpleado.Area = InArea.Text;
            myEmpleado.Ciudad = InCiudad.Text;

            if (datos.EditarEmpleado(myEmpleado))
            {
                LabelRta.Text = "El registro fue actualizado correctamente";
                //Response.Redirect("Datos.aspx");

            }
            else
            {
                LabelRta.Text = "Error al actualizar" + datos.Error;
            }
        }

        protected void btnBorrarEmpleado_Click(object sender, EventArgs e)
        {
            // codigo para eliminar el empleado

            if (datos.DeleteEmpleado(InCodigo.Text))
            {
                LabelRta.Text = "El registro fue borrado correctamente";
                LimpiarCampos();
            }
            else
            {
                LabelRta.Text = "Error al actualizar" + datos.Error;
            }

        }
    }
}