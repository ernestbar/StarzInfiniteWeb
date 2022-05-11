using System;
using System.Collections.Generic;
using System.Linq;
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
            string resultado = LocalBD.PUT_PAGO_EMISION("EM", lblUsuario.Text, txtPNR.Text, "");
            string[] mesaje = resultado.Split('|');
            lblAviso.Text = mesaje[1];
        }
    }
}