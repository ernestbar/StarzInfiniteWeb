using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class reserva_admin : System.Web.UI.Page
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
                    hfFecha1.Value = DateTime.Now.ToShortDateString();
                    hfFecha2.Value = DateTime.Now.ToShortDateString();
                    Session.Remove("datos_iniciales");
                    Session.Remove("datos_vuelo_ida");
                    Session.Remove("datos_reserva");
                    Session.Remove("datos_ida");
                    Session.Remove("idDato");
                    Session.Remove("datos_vuelta");
                    Session.Remove("datos_vuelo_retorno");
                    Session.Remove("feeSZI");
                    Session.Remove("feeBroker");
                    Session.Remove("datos_facturacion");
                    Session.Remove("pasajeros");
                    Session.Remove("datos_iframe");
                    lblUsuario.Text = Session["usuario"].ToString();
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }

        protected void rblFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblFiltro.SelectedItem.Text == "Ver Todos")
                {
                    odsReservasTodos.DataBind();
                    Repeater1.DataBind();
                }
                if (rblFiltro.SelectedItem.Text == "Emitido")
                {
                    odsReservasTodos.FilterExpression = "ESTADO='EMITIDO'";
                    odsReservasTodos.DataBind();
                    Repeater1.DataBind();
                }
                if (rblFiltro.SelectedItem.Text == "Pendiente")
                {
                    odsReservasTodos.FilterExpression = "ESTADO='PENDIENTE'";
                    odsReservasTodos.DataBind();
                    Repeater1.DataBind();
                }
                if (rblFiltro.SelectedItem.Text == "Cancelado")
                {
                    odsReservasTodos.FilterExpression = "ESTADO='CANCELADO'";
                    odsReservasTodos.DataBind();
                    Repeater1.DataBind();
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_reserva_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton obj = (LinkButton)sender;
                string[] id = obj.CommandArgument.ToString().Split('|');
                string[] gds = id[5].Split(':');
                DataTable dt = LocalBD.PR_OBTIENE_TICKETS_WEB(lblUsuario.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["NRO_PNR"].ToString() == id[0])
                        {
                            int i = 0;
                            string paterno = "";
                            DataTable dt1 = LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE(id[0]);
                            if (dt1.Rows.Count > 0)
                            {
                                foreach (DataRow dr1 in dt1.Rows)
                                {
                                    if (i == 0)
                                    {
                                        string[] nombre = dr1["Pasajero"].ToString().Split('|');
                                        paterno = nombre[1] + "|" + nombre[0];
                                        i++;
                                    }

                                }
                            }
                            string[] datosfac = id[7].Split('/');
                            //string[] fecha_hora_lim = id[7].Split(' ');
                            Session["datos_facturacion"] = datosfac[0] + "|" + datosfac[1];
                            Session["datos_iframe"] = id[0] + "|" + dr["TOTALCOBRAR"].ToString() + "|" + dr["MONEDA"].ToString() + "|" + dr["EMAILFACT"].ToString() + "|" + id[1] + "|" + gds[1] + "|" + id[7];
                            //Session["datos_iframe"] = txtPNR.Text + "|" + lblTotalRes.Text + "|" + lblMoneda.Text + "|" + lblEmail.Text + "|" + lblCodTiket.Text + "|" + lblGds.Text;
                            
                        }
                    }
                }
                Response.Redirect("pagar_reserva.aspx?admin=SI", false);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_reserva_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }


        }

        protected void lbtnCambiarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton obj = (LinkButton)sender;
                string id = obj.CommandArgument.ToString();
                //DataTable dt = clases.LocalBD.PR_OBTIENE_BOLETOS_TODOS(lblUsuario.Text);
                string url = "";
                DataTable dt = LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE(id);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //if (dr["NRO_PNR"].ToString() == id)
                        //{
                        //Session["datos_iframe"] = id + "|" + dr["TOTALCOBRAR"].ToString() + "|" + dr["MONEDA"].ToString() + "|" + dr["EMAILFACT"].ToString();
                        string[] nob_aux = dr["pasajero"].ToString().Split('|');

                        //Response.Redirect("pagar_reserva.aspx?cambiar_fecha=SI");
                        url = "https://www.amaszonas.com/scripts/reservas/atc_portal.php?pnr=" + id + "&lastname=" + nob_aux[1] + "&home=BO";

                        //}
                    }
                }

                myIframe.Src = url;
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_reserva_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }


        }

        protected void btnCanelarIframe_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbtnVer_Click(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 2;
                lblAdultosResumen.Text = "";
                lblNinosResumen.Text = "";
                lblInfanteResumen.Text = "";
                LinkButton obj = (LinkButton)sender;
                string id = obj.CommandArgument.ToString();
                txtPNR.Text = id;
                //DataTable dt = clases.LocalBD.PR_OBTIENE_BOLETOS_TODOS(lblUsuario.Text);
                DataTable dt_pasajeros = new DataTable();
                if (dt_pasajeros.Rows.Count > 0)
                {
                }
                else
                {
                    dt_pasajeros.Columns.Add("nro", typeof(string));
                    dt_pasajeros.Columns.Add("nombre", typeof(string));
                    dt_pasajeros.Columns.Add("apellido", typeof(string));
                    // dt_pasajeros.Columns.Add("tipo_doc", typeof(string));
                    // dt_pasajeros.Columns.Add("documento", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_pax", typeof(string));
                    // dt_pasajeros.Columns.Add("fecha_nacimiento", typeof(string));
                }
                string url = "";
                int nro = 1;
                int adultos = 0;
                int ninos = 0;
                int infantes = 0;
                DataTable dt = LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE(id);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //if (dr["NRO_PNR"].ToString() == id)
                        //{
                        //Session["datos_iframe"] = id + "|" + dr["TOTALCOBRAR"].ToString() + "|" + dr["MONEDA"].ToString() + "|" + dr["EMAILFACT"].ToString();
                        string[] nob_aux = dr["pasajero"].ToString().Split('|');
                        if (nob_aux[2].ToUpper() == "(ADT)")
                            adultos++;
                        if (nob_aux[2].ToUpper() == "(CHD)")
                            ninos++;
                        if (nob_aux[2].ToUpper() == "(INF)")
                            infantes++;
                        dt_pasajeros.Rows.Add(new string[4] { nro.ToString(), nob_aux[0], nob_aux[1], nob_aux[2] });
                        //Response.Redirect("pagar_reserva.aspx?cambiar_fecha=SI");
                        //url = "https://www.amaszonas.com/scripts/reservas/atc_portal.php?pnr=" + id + "&lastname=" + nob_aux[1] + "&home=BO";
                        nro++;
                        //}
                    }
                }
                if (adultos > 0)
                    lblAdultosResumen.Text = adultos.ToString() + " adultos";
                if (ninos > 0)
                    lblNinosResumen.Text = ninos.ToString() + " niños";
                if (infantes > 0)
                    lblInfanteResumen.Text = infantes.ToString() + " infantes";
                Repeater4.DataSource = dt_pasajeros;
                Repeater4.DataBind();
                DataTable dt1 = LocalBD.PR_OBTIENE_BOLETOS_PNR(id);
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        DateTime fechaIda = DateTime.Parse(dr1["FECHAIDA"].ToString());
                        panel_ida.Visible = true;
                        lblFechaIdaRes.Text = "Fecha de salida: " + fechaIda.Day.ToString() + "-" + fechaIda.Month.ToString() + "-" + fechaIda.Year.ToString();
                        lblOrgDestIdaRes.Text = "Ruta: " + dr1["ORIGENIDA"].ToString() + " - " + dr1["DESTINOIDA"].ToString();
                        lblHorarioIdaRes.Text = "Clase: " + dr1["CLASEIDA"].ToString();
                        lblVueloIdaRes.Text = "NRO. VUELO: " + dr1["NUMEROVUELOIDA"].ToString();
                        string idaOrigen = "";
                        string idaDestino = "";
                        foreach (DataRow drIti in Dominios.Lista("RUTA INDIVIDUAL").Rows)
                        {
                            if (dr1["ORIGENIDA"].ToString() == drIti["codigo"].ToString())
                                idaOrigen = drIti["descripcion"].ToString();
                            if (dr1["DESTINOIDA"].ToString() == drIti["codigo"].ToString())
                                idaDestino = drIti["descripcion"].ToString();
                        }
                        foreach (DataRow dra in Dominios.Lista("AEROLINEA").Rows)
                        {
                            if (dr1["ORIGENIDA"].ToString() == dra["codigo"].ToString())
                                idaOrigen = dra["descripcion"].ToString();

                        }
                        lblIdaTitulo.Text = idaOrigen + " - " + idaDestino;
                        if (String.IsNullOrEmpty(dr1["ORIGENVUELTA"].ToString()))
                        { panel_vuelta.Visible = false; }
                        else
                        {
                            string vueltaOrigen = "";
                            string vueltaDestino = "";
                            foreach (DataRow drIti in Dominios.Lista("RUTA INDIVIDUAL").Rows)
                            {
                                if (dr1["ORIGENVUELTA"].ToString() == drIti["codigo"].ToString())
                                    vueltaOrigen = drIti["descripcion"].ToString();
                                if (dr1["DESITINOVUELTA"].ToString() == drIti["codigo"].ToString())
                                    vueltaDestino = drIti["descripcion"].ToString();
                            }
                            lblVueltaTitulo.Text = vueltaOrigen + " - " + vueltaDestino;
                            panel_vuelta.Visible = true;

                            lblFechaVueltaRes.Text = "Fecha de salida: " + dr1["FECHAVUELTA"].ToString();
                            lblOrgDestVueltaRes.Text = "Ruta: " + dr1["ORIGENVUELTA"].ToString() + " - " + dr1["DESITINOVUELTA"].ToString();
                            lblHorarioVueltaRes.Text = "Clase: " + dr1["CLASEIDA"].ToString();
                            lblVueloVueltaRes.Text = "NRO. VUELO: " + dr1["NUMEROVUELOVUELTA"].ToString();
                        }

                        panel_total_res.Visible = true;

                        lblTotalRes.Text = Math.Round(decimal.Parse(dr1["TOTALCOBRAR"].ToString()), 2).ToString();
                        lblTarifaBaseRes.Text = Math.Round(decimal.Parse(dr1["MONTOSINIMPUESTOS"].ToString()), 2).ToString();
                        lblTotalImpuestosRes.Text = Math.Round(decimal.Parse(dr1["TOTALIMPUESTOS"].ToString()), 2).ToString();
                        lblMonedaRes.Text = dr1["MONEDA"].ToString();

                        if (dr1["ESTADO"].ToString() == "PENDIENTE")
                        {
                            string[] fechHoraLim = dr1["FECHALIMITEEMISION"].ToString().Split(' ');
                            string[] fechLim = fechHoraLim[0].Split('/');
                            string[] horaLim = fechHoraLim[1].Split(':');
                            lblTiempoLimite.Text = "HORA: " + horaLim[0] + ":" + horaLim[1] + " - " + fechLim[0] + " de " + Nombre_mes(int.Parse(fechLim[1])) + ", " + fechLim[2] + " ESTADO: " + dr1["ESTADO"].ToString(); ;
                            //lblTiempoLimite.Text = 
                        }
                        else
                        {
                            lblTiempoLimite.Text = "PASAJE " + dr1["ESTADO"].ToString();
                        }

                    }
                }

                DataTable dt2 = LocalBD.PR_OBTIENE_REPORTE_GANANCIAS(lblUsuario.Text);
                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        if (dr2["CONCEPTO"].ToString().Contains(id))
                        {
                            lblGananciaRes.Text = dr2["MONTO"].ToString().Replace("+", "");
                        }
                    }

                }
                //myIframe.Src = url;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_reserva_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton obj = (LinkButton)sender;
                string id = obj.CommandArgument.ToString();
                ////cancelar en el servicio web
                DBApi obj1 = new DBApi();
                CancelarReserva datos1 = new CancelarReserva
                {
                    id_reserva = id
                };

                string json = JsonConvert.SerializeObject(datos1);
                dynamic respuesta = obj1.Post("http://20.39.32.111/api/Cancelar_itinerario.php", json, "Basic MDQ4NjQwNjY4c3R6cmVycjg2Y2Q3MGE4OTVjZDlmYTowNHdlcndld2V3NjhzdHpyZXJyODZjZDcwYTg5NWNkOWZh");
                //dynamic respuesta = obj1.Post("https://reservas2.amaszonas.com/servicio_a1z8/Cancelar_itinerario.php", json, "Basic MDQ4NjQwNjY4ZGJmZDdmMDY4NmNkNzBhODk1Y2Q5ZmE6ZWUyZWMzY2M2NjQyN2JiNDIyODk0NDk1MDY4MjIyYTg=");

                string respuestaJson = respuesta.ToString();
                respuestaCancelarReserva respCancel = new respuestaCancelarReserva();
                respCancel = JsonConvert.DeserializeObject<respuestaCancelarReserva>(respuestaJson);

                /////canacelar en la BD/////
                if (respCancel.error == "00")
                {
                    string resultado = LocalBD.PUT_PAGO_EMISION("CA", lblUsuario.Text, id, "");
                    string[] mesaje = resultado.Split('|');
                    lblAviso.Text = mesaje[1];
                }
                MultiView1.ActiveViewIndex = 0;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_reserva_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }


        }
        public string Nombre_mes(int mes)
        {
            string nomb_mes = "";
            if (mes == 1)
                nomb_mes = "Enero";
            if (mes == 2)
                nomb_mes = "Febrero";
            if (mes == 3)
                nomb_mes = "Marzo";
            if (mes == 4)
                nomb_mes = "Abril";
            if (mes == 5)
                nomb_mes = "Mayo";
            if (mes == 6)
                nomb_mes = "Junio";
            if (mes == 7)
                nomb_mes = "Julio";
            if (mes == 8)
                nomb_mes = "Agosto";
            if (mes == 9)
                nomb_mes = "Septiembre";
            if (mes == 10)
                nomb_mes = "Octubre";
            if (mes == 11)
                nomb_mes = "Noviembre";
            if (mes == 12)
                nomb_mes = "Diciembre";

            return nomb_mes;

        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label fechaLimAux = (Label)e.Item.FindControl("lblFechaLim2");
                Label fechaLim = (Label)e.Item.FindControl("lblFechaLim");
                Label pnr = (Label)e.Item.FindControl("lblPnr");
                Label lbNombre = (Label)e.Item.FindControl("lblNombres");
                string[] fhAux = fechaLimAux.Text.Split(' ');
                string[] fecha = fhAux[0].Split('/');
                string[] hora = fhAux[1].Split(':');
                fechaLim.Text = hora[0] + ":" + hora[1] + "-" + fecha[0] + " " + Nombre_mes(int.Parse(fecha[1])) + ", " + fecha[2];


                //DataTable dt = clases.LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE(pnr.Text);
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {

                //        string[] nombre = dr["Pasajero"].ToString().Split('|');
                //        lbNombre.Text = lbNombre.Text + nombre[1] + " " + nombre[0] + "/";

                //    }
                //}

                //lbNombre.Text= lbNombre.Text.Remove(lbNombre.Text.Length -1, 1);



            }
        }

        protected void btnFiltrarFechas_Click(object sender, EventArgs e)
        {

            odsReservasTodos.DataBind();
            //Repeater1.DataSource = LocalBD.PR_OBTIENE_TICKETS_WEB_FILTRO(lblUsuario.Text,"","",hfFecha1.Value,hfFecha2.Value);
            Repeater1.DataBind();
            //Repeater1.DataBind();
        }

        public class CancelarReserva
        {
            public string id_reserva { get; set; }
        }

        public class respuestaCancelarReserva
        {
            public string error { get; set; }
            public string datos { get; set; }
        }

        protected void btnVolverReserva_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}