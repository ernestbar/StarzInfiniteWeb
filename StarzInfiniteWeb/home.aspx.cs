using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("ingreso.aspx");
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                    lblCalendario.Text = Request.QueryString["calendario"];
                }
                   
                

            }
        }

        protected void ddlOrigen_DataBound(object sender, EventArgs e)
        {
            ddlOrigen.Items.Insert(0, "ORIGEN");
        }

        protected void ddlDestino_DataBound(object sender, EventArgs e)
        {
            ddlDestino.Items.Insert(0, "DESTINO");
        }

        protected void ddlLineArea_DataBound(object sender, EventArgs e)
        {
            ddlLineArea.Items.Insert(0, "TODAS");
        }

        protected void btnVuelos_Click(object sender, EventArgs e)
        {
            string fecha1 = hfFechaSalida.Value;
            string fecha2 = hfFechaRetorno.Value;
            string vuelos_directos = "";
            if (cbVueloDirecto.Checked == false)
                vuelos_directos = "0";
            else
                vuelos_directos = "1";
            string vuelos_incluyenequipaje = "";
            if (cbEquipaje.Checked == false)
                vuelos_incluyenequipaje = "0";
            else
                vuelos_incluyenequipaje = "1";
            //   0         1        2      3          4         5       6    7       8      9    10     11     12       13       14          15         16
            //TIPO RUTA|ORIGEN|DESSTINO|FECHAIDA|FECHAVUELTA|ADULTOS|NINOS|INFANTE|SENIOR|LINEA|TURNO|CABINA|EQUIPAJE|DIRECTO|NOMBORIGEN|NOMBDESTINO|TIPOVENTA
            Session["DATOSINI"] = hfTipoRuta.Value+"|"+ddlOrigen.SelectedValue + "|" +ddlDestino.SelectedValue + "|" +hfFechaSalida.Value + "|" +hfFechaRetorno.Value
                 + "|" + txtAdultos.Text + "|" +txtNinos.Text + "|" +txtInfante.Text + "|" +txtSenior.Text + "|" +ddlLineArea.SelectedValue + "|" +ddlTurnos.SelectedValue
                  + "|" +ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" +ddlOrigen.SelectedItem.Text 
                  + "|" +ddlDestino.SelectedItem.Text + "|" +rblTipoVenta.SelectedValue;
            if (lblCalendario.Text=="SI")
                Response.Redirect("calendario.aspx");
            else
                Response.Redirect("vuelos.aspx");
        }

        protected void btnMatriz_Click(object sender, EventArgs e)
        {
            string fecha1 = hfFechaSalida.Value;
            string fecha2 = hfFechaRetorno.Value;
            string vuelos_directos = "";
            if (cbVueloDirecto.Checked == false)
                vuelos_directos = "0";
            else
                vuelos_directos = "1";
            string vuelos_incluyenequipaje = "";
            if (cbEquipaje.Checked == false)
                vuelos_incluyenequipaje = "0";
            else
                vuelos_incluyenequipaje = "1";
            //   0         1        2      3          4         5       6    7       8      9    10     11     12       13       14          15         16
            //TIPO RUTA|ORIGEN|DESSTINO|FECHAIDA|FECHAVUELTA|ADULTOS|NINOS|INFANTE|SENIOR|LINEA|TURNO|CABINA|EQUIPAJE|DIRECTO|NOMBORIGEN|NOMBDESTINO|TIPOVENTA
            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + hfFechaSalida.Value + "|" + hfFechaRetorno.Value
                 + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                  + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                  + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;
                Response.Redirect("calendario.aspx");
        }
    }
}