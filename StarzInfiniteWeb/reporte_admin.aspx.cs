using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class reporte_admin : System.Web.UI.Page
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
                    MultiView1.ActiveViewIndex = 0;
                }


            }

        }

        protected void lbtnVoletosVendidos_Click(object sender, EventArgs e)
        {
            odsObtieneGanancias.DataBind();
            Repeater1.DataBind();
        }

        protected void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            odsObtieneGanancias.DataBind();
            Repeater1.DataBind();
        }

        protected void btnDetalle1_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            lblBroker.Text = id;
            MultiView1.ActiveViewIndex = 2;
            Repeater2.DataBind();

        }

        protected void btnDetalle2_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            lblPnr.Text = id;
            MultiView1.ActiveViewIndex = 3;
            Repeater3.DataBind();
        }

        protected void btnVolver1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnVolver2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnCambiarEstados_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            odsObtieneEstados.DataBind();
            Repeater1.DataBind();
        }

        protected void ddlEstado_DataBound(object sender, EventArgs e)
        {
            ddlEstado.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnVolverEstado_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }



        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            string[] datos = LocalBD.abm_cambia_tickets("I", lblPNRestado.Text, ddlEstado.SelectedValue, lblUsuario.Text).Split('|');
            lblAviso.Text = datos[1];
        }

        protected void btnVolverEstABM_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            Repeater4.DataBind();
        }

        protected void btnSeleccionarEst_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            lblPNRestado.Text = id;
            MultiView1.ActiveViewIndex = 5;
        }

        protected void btnOtraConsulta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}