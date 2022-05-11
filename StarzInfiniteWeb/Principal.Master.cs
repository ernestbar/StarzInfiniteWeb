using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null || Session["usuario"] == "")
                {
                    //Response.Redirect("ingreso.aspx", false);
                    lbtnLogin.Text = "Ingresar";
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                    lbtnLogin.Text = Session["usuario"].ToString();
                    //string[] datos = obj.ABM().Split('|');
                    //if (String.IsNullOrEmpty(Session["token"].ToString()))
                    //    lblToken.Text = "";
                    //else
                    //    lblToken.Text = Session["token"].ToString();
                    //if (clases.usuario.PR_VALIDA_TOKEN(lblUsuario.Text, Session["token"].ToString()) == "NOK")
                    //{
                    //    Session.Abandon();
                    //    Response.Redirect("login.aspx");

                    //}
                    //Int64 not_nro = usuario.PR_OBTIENE_CANTIDAD_NOTIFICACION(lblUsuario.Text);
                    //if (not_nro == 0)
                    //    lblNotiNro.Text = "";
                    //else
                    //    lblNotiNro.Text = "(new " + not_nro.ToString() + ")";

                    //clases.Referidos objRef = new clases.Referidos("O", "", "", lblUsuario.Text);
                    //string[] dataRef = objRef.ABM().Split('|');
                    //if (dataRef[1] == "1")
                    //    lbtnReferido.Visible = false;
                    //else
                    //    lbtnReferido.Visible = true;


                }
            }
            
        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            if (lbtnLogin.Text == "Ingresar")
            {
                Session.Abandon();
                Response.Redirect("ingreso.aspx", false);
            }
            else
            { 
                
            }
        }
    }
}