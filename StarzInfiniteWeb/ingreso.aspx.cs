using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUsuario.Focus();
                MultiView1.ActiveViewIndex = 0;
                Page.Form.DefaultButton = btnLogin.UniqueID;
            }
        }

        protected void lbtnCambiar_Click(object sender, EventArgs e)
        {
            string[] datos = Usuarios.PR_CAMBIO_PASSWORD("I", txtUsuario.Text, txtCI.Text, txtPasswordA.Text, txtPasswordN.Text, "").Split('|');
            lblAviso.Text = datos[1];
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbtnReset1_Click(object sender, EventArgs e)
        {
            string[] datos = Usuarios.setValidaCredenciales("CC|" + txtUsuario.Text, txtPassword.Text).Split('|');
            if (datos[1] == "Reset Correcto....")
            {
                lblAviso.Text = "Su password fue reseteado a 123 temporalmente, ingrese y cambie su password.";
                MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void lbtnReset_Click(object sender, EventArgs e)
        {
            txtUsuarioC.Text = txtUsuario.Text;
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string[] datos = Usuarios.setValidaCredenciales(txtUsuario.Text, txtPassword.Text).Split('|');

            if (datos[1].ToUpper() == "LOGIN CORRECTO")
            {
                Session["usuario"] = txtUsuario.Text;

                if (datos[2] == "1")
                {
                    MultiView1.ActiveViewIndex = 1;
                    txtCI.Text = "";
                    txtPasswordA.Text = "";
                    txtPasswordN.Text = "";
                    txtUsuarioC.Text = txtUsuario.Text;
                }
                else
                {
                    Session["token"] = Usuarios.PR_OBTIENE_TOKEN(txtUsuario.Text);
                    lblAviso.Text = "";
                    Response.Redirect("home.aspx");
                }

            }
            else
            {
                Session["usuario"] = null;
                lblAviso.Text = "Usuario o Contraseña incorrecta";
                txtUsuario.Focus();
            }
        }
    }
}