using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class reporte_counter_adm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("ingreso.aspx", false);
                }
                else
                {
                    hfFecha1.Value = "";
                    hfFecha2.Value = "";
                    lblUsuario.Text = Session["usuario"].ToString();
                    MultiView1.ActiveViewIndex = 0;
                }


            }
        }

        protected void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            odsReporteCounter.DataBind();
            Repeater1.DataBind();
        }

        protected void btnOtraConsulta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}