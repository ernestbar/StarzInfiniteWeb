using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class emision_offline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("ingreso.aspx",false);
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                }
            }
        }

        protected void btnEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                string resultado = LocalBD.PUT_PAGO_EMISION("EM", lblUsuario.Text, txtPNR.Text, "");
                string[] mesaje = resultado.Split('|');
                lblAviso.Text = mesaje[1];
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_emision_offline_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, revise los log o consulte con el administrador.";
            }
           
        }
    }
}