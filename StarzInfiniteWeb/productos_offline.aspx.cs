using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class productos_offline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    hfFecha1.Value = DateTime.Now.ToShortDateString();
                    hfFecha2.Value = DateTime.Now.ToShortDateString();

                    lblUsuario.Text = Session["usuario"].ToString();
                    MultiView1.ActiveViewIndex = 0;
                }


            }

        }

        protected void lbtnVer_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            lblPNR.Text = obj.CommandArgument.ToString();
            Repeater2.DataBind();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbtnEditar_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            lblCodClienteTicket.Text = obj.CommandArgument.ToString();
            DataTable dt = new DataTable();
            dt = LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_MANUAL_IND(lblCodClienteTicket.Text);

            foreach (DataRow dr in dt.Rows)
            {
                ddlProducto.SelectedValue = dr["producto"].ToString();
                ddlProovedor.DataBind();
                ddlProovedor.SelectedValue = dr["proveedor"].ToString();
                txtPNR.Text = dr["nro_pnr"].ToString();
                txtTourCode.Text = dr["tourcode"].ToString();
                txtDatosFacturacion.Text = dr["datosfacturacion"].ToString();
                txtEmailFact.Text = dr["emailfact"].ToString();
                txtFonoFact.Text = dr["telefonofact"].ToString();
                ddlOrigenIda.SelectedValue = dr["origenida"].ToString();
                ddlDestinoIda.SelectedValue = dr["producto"].ToString();
            }

            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            Repeater1.DataBind();
        }

        protected void btnVoler_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnVolverEstABM_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lblCodClienteTicket.Text == "")
            {

            }
            else
            {

            }
        }

        protected void rbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            odsProducto.DataBind();
            ddlProducto.DataBind();
        }

        protected void ddlOrigenIda_DataBound(object sender, EventArgs e)
        {
            ddlOrigenIda.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlDestinoIda_DataBound(object sender, EventArgs e)
        {
            ddlDestinoIda.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlOrigenVuelta_DataBound(object sender, EventArgs e)
        {
            ddlOrigenVuelta.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlDestinoVuelta_DataBound(object sender, EventArgs e)
        {
            ddlDestinoVuelta.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlMoneda_DataBound(object sender, EventArgs e)
        {
            ddlMoneda.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlBroker_DataBound(object sender, EventArgs e)
        {
            ddlBroker.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoVenta_DataBound(object sender, EventArgs e)
        {
            ddlTipoVenta.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoVuelo_DataBound(object sender, EventArgs e)
        {
            ddlTipoVuelo.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            lblCodClienteTicket.Text = "";
        }

        protected void ddlProducto_DataBound(object sender, EventArgs e)
        {
            ddlProducto.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlProovedor_DataBound(object sender, EventArgs e)
        {
            ddlProovedor.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlProovedor.DataBind();
            ddlBroker.DataBind();
            ddlBroker.DataBind();
        }
    }
}