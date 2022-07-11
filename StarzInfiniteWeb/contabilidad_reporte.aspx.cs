using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class contabilidad_reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("ingreso.aspx");
            }
            else
            {
                hfFecha1.Value = DateTime.Now.ToShortDateString();
                hfFecha2.Value = DateTime.Now.ToShortDateString();

                lblUsuario.Text = Session["usuario"].ToString();
                MultiView1.ActiveViewIndex = 0;
            }
            

        }

        protected void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            Repeater1.DataBind();
        }
    }
}