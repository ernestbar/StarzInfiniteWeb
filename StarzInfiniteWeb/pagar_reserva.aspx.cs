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
    public partial class pagar_reserva : System.Web.UI.Page
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
                    try
                    {
                        Session.Remove("datos_iniciales");
                        Session.Remove("datos_vuelo_ida");
                        Session.Remove("datos_ida");
                        Session.Remove("idDato");
                        Session.Remove("datos_vuelta");
                        Session.Remove("datos_vuelo_retorno");
                        Session.Remove("feeSZI");
                        Session.Remove("feeBroker");
                        Session.Remove("pasajeros");
                        MultiView1.ActiveViewIndex = 0;
                        string[] datos_iframe = Session["datos_iframe"].ToString().Split('|');
                        lblPNR.Text = datos_iframe[0];
                        //lblPNR.Text = "279PH2";
                        //lblTotalTit.Text = "Elige una de las opciones de pago  Total a pagar:   Bs." + datos_iframe[1];
                        txtTotalPagar.Text = datos_iframe[1].Replace(",",".");
                        lblMoneda.Text = datos_iframe[2];
                        lblEmail.Text = datos_iframe[3];
                        lblCorreoFin.Text = datos_iframe[3];
                        lblCodTicket.Text = datos_iframe[4];
                        lblGds.Text = datos_iframe[5];
                        lblUsuario.Text = Session["usuario"].ToString();
                        string[] datos = LocalBD.PR_OBTIENE_HOME_VENTAS(lblUsuario.Text).Split('|');
                        //lblSaldo.Text = datos[3];

                        DataTable dt = LocalBD.PR_GET_DATOSPASARELAPAGO(lblPNR.Text);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                //lblTotalPagar.Text = Math.Round(decimal.Parse(dr["MONTOPAGO"].ToString()),2).ToString();
                                lblTotalPagar.Text = Math.Round(decimal.Parse(dr["MONTOPAGO"].ToString().Replace(",", ".")), 2).ToString();
                                lblTotalTit.Text = "Elige una de las opciones de pago  Total a pagar en " + dr["MONEDA"].ToString() + ": " + lblTotalPagar.Text;

                            }

                        }

                        if (LocalBD.PR_GET_PREPAGO(lblUsuario.Text) == "1")
                        {
                            Panel_billetera.Visible = true;
                            string[] datos_billetra = LocalBD.PR_OBTIENE_HOME_VENTAS(lblUsuario.Text).Split('|');
                            lblSaldo.Text = datos_billetra[3];
                            if (decimal.Parse(lblSaldo.Text) < decimal.Parse(lblTotalPagar.Text))
                            {
                                btnPagarSaldo.Enabled = false;
                                lblAviso.Text = "Saldo insuficiente!";
                            }
                            else
                            {
                                btnPagarSaldo.Enabled = true;
                                lblAviso.Text = "";
                            }

                        }
                        else
                            Panel_billetera.Visible = false;
                        //Session["datos_reserva"] = lblAdultosResumen.Text + "|" + lblNinosResumen.Text + "|" + lblInfanteResumen.Text + "|" +//
                        //                                0                                  1                           2
                        //lblFechaIdaRes.Text + "|" +lblOrgDestIdaRes.Text + "|" +lblHorarioIdaRes.Text + "|" + lblVueloIdaRes.Text;
                        //          3                         4                         5                               6
                        //+ "|" + lblTotalRes.Text + "|" +lblTarifaBaseRes.Text + "|" +lblTotalImpuestosRes.Text + "|" +lblGananciaRes.Text + "|" +lblIdaTitulo.Text;
                        //            7                              8                        9                               10                            11
                        // + "|" + lblOrgDestVueltaRes.Text + "|" + lblHorarioVueltaRes.Text + "|" + lblVueloVueltaRes.Text + "|" +lblVueltaTitulo.Text;
                        //                         12                      13                              14                              15
                        if (Request.QueryString["admin"] == "SI")
                        {
                            Panel_reserva.Visible = false;
                            lblFechaLimite.Text = datos_iframe[6];

                        }
                        else
                        {
                            Panel_reserva.Visible = true;
                            string[] datos_res = Session["datos_reserva"].ToString().Split('|');
                            panel_ida.Visible = true;
                            lblAdultosResumen.Text = datos_res[0];
                            lblNinosResumen.Text = datos_res[1];
                            lblInfanteResumen.Text = datos_res[2];
                            lblFechaIdaRes.Text = datos_res[3];
                            lblOrgDestIdaRes.Text = datos_res[4];
                            lblHorarioIdaRes.Text = datos_res[5];
                            lblVueloIdaRes.Text = datos_res[6];
                            panel_total_res.Visible = true;
                            lblTotalRes.Text = datos_res[7];
                            lblTarifaBaseRes.Text = datos_res[8];
                            lblTotalImpuestosRes.Text = datos_res[9];
                            lblGananciaRes.Text = datos_res[10];
                            lblIdaTitulo.Text = datos_res[11];

                            lblOrgDestVueltaRes.Text = datos_res[12];
                            lblHorarioVueltaRes.Text = datos_res[13];
                            lblVueloVueltaRes.Text = datos_res[14];
                            lblVueltaTitulo.Text = datos_res[15];
                            lblFechaLimite.Text = datos_res[16];

                            if (datos_res[14] == "")
                            {
                                panel_vuelta.Visible = false;
                            }
                            else
                            { panel_vuelta.Visible = true; }
                        }
                    }
                    catch (Exception ex)
                    {
                        string nombre_archivo = "error_pagar_reserva_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                        string directorio2 = Server.MapPath("~/Logs");
                        StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                        writer5.WriteLine(ex.ToString());
                        writer5.Close();
                        lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
                    }




                }
            }


        }

        protected void btnPagarSaldo_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            txtClave.Text = "";
            txtClave.Focus();

        }

        protected void btnOtrasFormasPago_Click(object sender, EventArgs e)
        {
            try
            {
                //Session["datos_facturacion"] = txtRazonSocial.Text + "|" + txtNit.Text + "|" + txtEmailTit.Text + "|" + txtTelefonoTit.Text + "|" + txtCodFrec.Text;
                //string[] datos_facturadcion = Session["datos_facturacion"].ToString().Split('|');

                DataTable dt = LocalBD.PR_GET_DATOSPASARELAPAGO(lblPNR.Text);

                string Pusuario = "";
                string PcorreoElectronico = "";
                string PmontoPago = "";
                string Pmoneda = "";
                string Pdescripcion = "";
                string PnombreComprador = "";
                string PapellidoComprador = "";
                string PdocumentoIdentidadComprador = "";
                string PfechaHoraRegistro = "";
                string PfechaHoraVencimiento = "";
                string PcodigoOperacion = "";
                string PurlRespuesta = "";
                string PPNR = "";
                string Pgds = "";

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Pusuario = dr["USUARIO"].ToString();
                        PcorreoElectronico = dr["CORREOELECTRONICO"].ToString();
                        PmontoPago = dr["MONTOPAGO"].ToString();
                        Pmoneda = dr["MONEDA"].ToString();
                        Pdescripcion = dr["DESCRIPCION"].ToString();
                        PnombreComprador = dr["NOMBRECOMPRADOR"].ToString();
                        PapellidoComprador = dr["APELLIDOCOMPRADOR"].ToString();
                        PdocumentoIdentidadComprador = dr["DOCUMENTOIDENTIDADCOMPRADOR"].ToString();
                        PfechaHoraRegistro = dr["FECHAHORAREGISTRO"].ToString();
                        PfechaHoraVencimiento = dr["FECHAHORAVENCIMIENTO"].ToString();
                        PcodigoOperacion = dr["CODIGOOPERACION"].ToString();
                        PurlRespuesta = dr["URL_RESPUESTA"].ToString();
                        PPNR = dr["PNR"].ToString();
                        Pgds = lblGds.Text;

                    }

                }
                //string monto_pagar = PmontoPago.Replace(",", ".");
                decimal monto_pagar_i = decimal.Parse(PmontoPago.Replace(",", "."));
                decimal monto_pagar_t = decimal.Parse(PmontoPago.Replace(",", "."));
                //decimal monto_pagar_i = decimal.Parse(PmontoPago.Replace(".", ","));
                //decimal monto_pagar_t = decimal.Parse(PmontoPago.Replace(".", ","));
                if (Pmoneda == "USD")
                {
                    monto_pagar_t = monto_pagar_i * decimal.Parse("6.97");
                    //monto_pagar_t = monto_pagar_i * decimal.Parse("6,97");
                    Pmoneda = "BOB";
                }

                string porcentaje = "";
                DataTable dt_porcentaje = new DataTable();
                dt_porcentaje = Dominios.Lista("COMISION PASARELA");
                foreach (DataRow dr_porcentaje in dt_porcentaje.Rows)
                {
                    porcentaje = dr_porcentaje["valor_numerico"].ToString();
                }

                string[] url_aux = PurlRespuesta.Split('|');
                SolicitudPago obj_sp = new SolicitudPago
                {
                    usuario = "web",
                    correoElectronico = PcorreoElectronico,
                    montoPago = monto_pagar_t.ToString().Replace(",", "."),
                    moneda = Pmoneda,
                    descripcion = Pdescripcion,
                    nombreComprador = PnombreComprador,
                    apellidoComprador = PapellidoComprador,
                    documentoIdentidadComprador = PdocumentoIdentidadComprador,
                    fechaHoraRegistro = PfechaHoraRegistro,
                    fechaHoraVencimiento = PfechaHoraVencimiento,
                    codigoOperacion = PcodigoOperacion,
                    urlRespuesta = url_aux[0],
                    PNR = lblPNR.Text,
                    gds = Pusuario,
                    montoPagoDos = ((decimal.Parse(monto_pagar_t.ToString().Replace(",", ".")) * (decimal.Parse(porcentaje) / 100)) + decimal.Parse(monto_pagar_t.ToString().Replace(",", "."))).ToString().Replace(",",".")
                    //montoPagoDos = ((decimal.Parse(monto_pagar_t.ToString().Replace(".", ",")) * (decimal.Parse(porcentaje) / 100)) + decimal.Parse(monto_pagar_t.ToString().Replace(".", ","))).ToString().Replace(",",".")
                };
                DBApi obj = new DBApi();
                string json = JsonConvert.SerializeObject(obj_sp);
                dynamic respuesta = obj.Post("http://backendstarz.eastus.cloudapp.azure.com/paginapagospro/solicitud_pago.php", json, "Basic MDQ4NjQxMjRzZGY0NTIzZjA2ODZjZmZmZDcwYTg5NTMzY2Q5ZmE6ZWUyZWMzY2MzNDUzdHNzODk0NDk1MDY4MjIyYTg=");
                string respuestaJson = respuesta.ToString();

                RespuestaSP resp = new RespuestaSP();
                resp = JsonConvert.DeserializeObject<RespuestaSP>(respuestaJson);
                MultiView1.ActiveViewIndex = 3;
                string url = "https://psp.starzinfinite.com/psp/?IdTransaccion=" + resp.IdTransaccion;
                //Response.Redirect(url,false);
                //Response.Write("<script> window.open('" + url + "','_blank'); </script>");
                myIframe.ResolveUrl(url);
                myIframe.Src = url;
                myIframe.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_pagar_reserva_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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

                string[] datos = Usuarios.setValidaCredenciales(lblUsuario.Text, txtClave.Text).Split('|');

                if (datos[1].ToUpper() == "LOGIN CORRECTO")
                {
                    ////////////////////////////////SOLICITAR LINK DE PAGO//////////////////////////
                    DataTable dt = LocalBD.PR_GET_DATOSPASARELAPAGO(lblPNR.Text);

                    string Pusuario = "";
                    string PcorreoElectronico = "";
                    string PmontoPago = "";
                    string Pmoneda = "";
                    string Pdescripcion = "";
                    string PnombreComprador = "";
                    string PapellidoComprador = "";
                    string PdocumentoIdentidadComprador = "";
                    string PfechaHoraRegistro = "";
                    string PfechaHoraVencimiento = "";
                    string PcodigoOperacion = "";
                    string PurlRespuesta = "";
                    string PPNR = "";
                    string Pgds = "";

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Pusuario = dr["USUARIO"].ToString();
                            PcorreoElectronico = dr["CORREOELECTRONICO"].ToString();
                            PmontoPago = dr["MONTOPAGO"].ToString();
                            Pmoneda = dr["MONEDA"].ToString();
                            Pdescripcion = dr["DESCRIPCION"].ToString();
                            PnombreComprador = dr["NOMBRECOMPRADOR"].ToString();
                            PapellidoComprador = dr["APELLIDOCOMPRADOR"].ToString();
                            PdocumentoIdentidadComprador = dr["DOCUMENTOIDENTIDADCOMPRADOR"].ToString();
                            PfechaHoraRegistro = dr["FECHAHORAREGISTRO"].ToString();
                            PfechaHoraVencimiento = dr["FECHAHORAVENCIMIENTO"].ToString();
                            PcodigoOperacion = dr["CODIGOOPERACION"].ToString();
                            PurlRespuesta = dr["URL_RESPUESTA"].ToString();
                            PPNR = dr["PNR"].ToString();
                            Pgds = lblGds.Text;

                        }

                    }
                    ////string monto_pagar = PmontoPago.Replace(",", ".");
                    //decimal monto_pagar_i = decimal.Parse(PmontoPago.Replace(",", "."));
                    //decimal monto_pagar_t = decimal.Parse(PmontoPago.Replace(",", "."));
                    ////decimal monto_pagar_i = decimal.Parse(PmontoPago.Replace(".", ","));
                    ////decimal monto_pagar_t = decimal.Parse(PmontoPago.Replace(".", ","));
                    //if (Pmoneda == "USD")
                    //{
                    //    monto_pagar_t = monto_pagar_i * decimal.Parse("6.97");
                    //    //monto_pagar_t = monto_pagar_i * decimal.Parse("6,97");
                    //    Pmoneda = "BOB";
                    //}

                    //string porcentaje = "";
                    //DataTable dt_porcentaje = new DataTable();
                    //dt_porcentaje = Dominios.Lista("COMISION PASARELA");
                    //foreach (DataRow dr_porcentaje in dt_porcentaje.Rows)
                    //{
                    //    porcentaje = dr_porcentaje["valor_numerico"].ToString();
                    //}

                    //string[] url_aux = PurlRespuesta.Split('|');

                    //pagar_reserva.SolicitudPago obj_sp = new pagar_reserva.SolicitudPago
                    //{
                    //    usuario = "web",
                    //    correoElectronico = PcorreoElectronico,
                    //    montoPago = Math.Round(monto_pagar_t, 2).ToString().Replace(",", "."),
                    //    moneda = Pmoneda,
                    //    descripcion = Pdescripcion,
                    //    nombreComprador = PnombreComprador,
                    //    apellidoComprador = PapellidoComprador,
                    //    documentoIdentidadComprador = PdocumentoIdentidadComprador,
                    //    fechaHoraRegistro = PfechaHoraRegistro,
                    //    fechaHoraVencimiento = PfechaHoraVencimiento,
                    //    codigoOperacion = PcodigoOperacion,
                    //    urlRespuesta = url_aux[0],
                    //    PNR = lblPNR.Text,
                    //    gds = Pusuario,
                    //    montoPagoDos = Math.Round(((decimal.Parse(monto_pagar_t.ToString().Replace(",", ".")) * (decimal.Parse(porcentaje) / 100)) + decimal.Parse(monto_pagar_t.ToString().Replace(",", "."))), 2).ToString().Replace(",", ".")
                    //    //montoPagoDos = ((decimal.Parse(monto_pagar_t.ToString().Replace(".", ",")) * (decimal.Parse(porcentaje) / 100)) + decimal.Parse(monto_pagar_t.ToString().Replace(".", ","))).ToString().Replace(",",".")
                    //};
                    //DBApi obj_pago = new DBApi();
                    //string json_pago = JsonConvert.SerializeObject(obj_sp);
                    //dynamic respuesta_pago = obj_pago.Post("http://backendstarz.eastus.cloudapp.azure.com/paginapagospro/solicitud_pago.php", json_pago, "Basic MDQ4NjQxMjRzZGY0NTIzZjA2ODZjZmZmZDcwYTg5NTMzY2Q5ZmE6ZWUyZWMzY2MzNDUzdHNzODk0NDk1MDY4MjIyYTg=");
                    //string respuestaJson_pago = respuesta_pago.ToString();

                    //pagar_reserva.RespuestaSP resp = new pagar_reserva.RespuestaSP();
                    //resp = JsonConvert.DeserializeObject<pagar_reserva.RespuestaSP>(respuestaJson_pago);
                    ////MultiView1.ActiveViewIndex = 3;
                    //string url = "https://psp.starzinfinite.com/psp/?IdTransaccion=" + resp.IdTransaccion;
                    ////lblLinkPago.Text = url;

                    MetodoPago obj_mp = new MetodoPago
                    {
                        gds=Pusuario,
                        mediopago = "CA",
                        marca = "",
                        numero = "",
                        codigoautorizacion = "",
                        reserva = lblPNR.Text
                    };

                    DataTable dt_pasajeros = new DataTable();
                    if (dt_pasajeros.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        dt_pasajeros.Columns.Add("nombre", typeof(string));
                        dt_pasajeros.Columns.Add("tipo", typeof(string));
                        dt_pasajeros.Columns.Add("sessionId", typeof(string));
                        dt_pasajeros.Columns.Add("token", typeof(string));
                        dt_pasajeros.Columns.Add("ticket", typeof(string));
                        dt_pasajeros.Columns.Add("correo", typeof(string));
                    }



                    DBApi obj = new DBApi();
                    string json = JsonConvert.SerializeObject(obj_mp);
                    dynamic respuesta = obj.Post("http://20.39.32.111/api/Emitir.php", json, "Basic MDQ4NjQwNjY4c3R6cmVycjg2Y2Q3MGE4OTVjZDlmYTowNHdlcndld2V3NjhzdHpyZXJyODZjZDcwYTg5NWNkOWZh");

                    string respuestaJson = respuesta.ToString();
                    //string error = respuesta.First().Error.ToString();
                    if (Pusuario.ToUpper() == "KIU")
                    {
                        Reservas_kiu.Application respuesta_res = new Reservas_kiu.Application();
                        string detalle_aux = "";
                        respuesta_res = JsonConvert.DeserializeObject<Reservas_kiu.Application>(respuestaJson);
                        if (respuesta_res.error == "00")
                        {
                            string nombre, tipo, sesionId, token, ticket, ticket_g, correo, nombre_g;
                            nombre = ""; ticket = ""; tipo = "";
                            sesionId = respuesta_res.datos.SessionId;
                            token = respuesta_res.datos.SecurityToken;
                            correo = respuesta_res.datos.correo_titular;
                            for (int x = 0; x < respuesta_res.datos.pasajeros.Count; x++)
                            {
                                if (x == 0)
                                {
                                    detalle_aux = lblPNR.Text + "," + respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido + "," + respuesta_res.datos.pasajeros[x].ticket;
                                    nombre = respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido;
                                    ticket = respuesta_res.datos.pasajeros[x].ticket;

                                }
                                else
                                {
                                    detalle_aux = detalle_aux + "|" + lblPNR.Text + "," + respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido + "," + respuesta_res.datos.pasajeros[x].ticket;
                                    nombre = nombre + "|" + respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido;
                                    ticket = ticket + "|" + respuesta_res.datos.pasajeros[x].ticket;
                                }
                                nombre_g = respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido;
                                tipo = respuesta_res.datos.pasajeros[x].tipo;
                                ticket_g = respuesta_res.datos.pasajeros[x].ticket;
                                dt_pasajeros.Rows.Add(nombre_g, tipo, sesionId, token, ticket_g, correo);
                            }
                            string detalle = detalle_aux;
                            string resultado = LocalBD.PUT_PAGO_EMISION("BI", lblUsuario.Text, lblPNR.Text, detalle);
                            string[] mesaje = resultado.Split('|');
                            lblAviso.Text = mesaje[1];
                            Repeater1.DataSource = dt_pasajeros;
                            Repeater1.DataBind();
                            MultiView1.ActiveViewIndex = 2;
                        }
                        else
                        {
                            lblAviso.Text = "El servicio dio el siguiente error: " + respuesta_res.error;
                        }
                    }

                    else
                    {
                        Reservas.Application respuesta_res = new Reservas.Application();
                        string detalle_aux = "";
                        respuesta_res = JsonConvert.DeserializeObject<Reservas.Application>(respuestaJson);
                        if (respuesta_res.error == "00")
                        {
                            string nombre, tipo, sesionId, token, ticket, ticket_g, correo, nombre_g;
                            nombre = ""; ticket = ""; tipo = "";
                            sesionId = respuesta_res.datos.SessionId;
                            token = respuesta_res.datos.SecurityToken;
                            correo = respuesta_res.datos.correo_titular;
                            for (int x = 0; x < respuesta_res.datos.pasajeros.Count; x++)
                            {
                                if (x == 0)
                                {
                                    detalle_aux = lblPNR.Text + "," + respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido + "," + respuesta_res.datos.pasajeros[x].ticket;
                                    nombre = respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido;
                                    ticket = respuesta_res.datos.pasajeros[x].ticket;

                                }
                                else
                                {
                                    detalle_aux = detalle_aux + "|" + lblPNR.Text + "," + respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido + "," + respuesta_res.datos.pasajeros[x].ticket;
                                    nombre = nombre + "|" + respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido;
                                    ticket = ticket + "|" + respuesta_res.datos.pasajeros[x].ticket;
                                }
                                nombre_g = respuesta_res.datos.pasajeros[x].nombre + " " + respuesta_res.datos.pasajeros[x].apellido;
                                tipo = respuesta_res.datos.pasajeros[x].tipo;
                                ticket_g = respuesta_res.datos.pasajeros[x].ticket;
                                dt_pasajeros.Rows.Add(nombre_g, tipo, sesionId, token, ticket_g, correo);
                            }
                            string detalle = detalle_aux;
                            string resultado = LocalBD.PUT_PAGO_EMISION("BI", lblUsuario.Text, lblPNR.Text, detalle);
                            string[] mesaje = resultado.Split('|');
                            lblAviso.Text = mesaje[1];
                            Repeater1.DataSource = dt_pasajeros;
                            Repeater1.DataBind();
                            MultiView1.ActiveViewIndex = 2;
                        }
                        else
                        {
                            lblAviso.Text = "El servicio dio el siguiente error: " + respuesta_res.error;
                        }
                    }
                       

                    

                }
                else
                {
                    lblAviso.Text = "Usuario o Contraseña incorrecta";
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_pagar_reserva_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }


        }

        protected void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("ventas.aspx",false);
        }

        protected void btnIrReservas_Click(object sender, EventArgs e)
        {
            Response.Redirect("reserva_admin.aspx",false);
        }

        protected void btnCanelarIframe_Click(object sender, EventArgs e)
        {
            Response.Redirect("reserva_admin.aspx", false);
        }

        protected void ibtnCompartir_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtnVer_Click(object sender, ImageClickEventArgs e)
        {
            //lblAviso.Text = "";
            //ImageButton obj = (ImageButton)sender;
            //string id = obj.CommandArgument.ToString();
            ////DataTable dt = clases.LocalBD.PR_OBTIENE_BOLETOS_TODOS(lblUsuario.Text);
            //string[] datos1 = id.Split('|');
            //string[] paterno = datos1[0].Split(' ');
            //string url = "";
            //url = "https://www.amaszonas.com/scripts/reservas/atc_portal.php?pnr=" + lblPNR.Text + "&lastname=" + paterno[1] + "&home=BO";
            //myIframe.Src = url;
            //MultiView1.ActiveViewIndex = 3;
        }

        public class MetodoPago
        {
            public string gds { get; set; }
            public string mediopago { get; set; }
            public string marca { get; set; }
            public string numero { get; set; }
            public string codigoautorizacion { get; set; }
            public string reserva { get; set; }

        }
        public class SolicitudPago
        {
            public string usuario { get; set; }
            public string correoElectronico { get; set; }
            public string montoPago { get; set; }
            public string moneda { get; set; }
            public string descripcion { get; set; }
            public string nombreComprador { get; set; }
            public string apellidoComprador { get; set; }
            public string documentoIdentidadComprador { get; set; }
            public string fechaHoraRegistro { get; set; }
            public string fechaHoraVencimiento { get; set; }
            public string codigoOperacion { get; set; }
            public string urlRespuesta { get; set; }
            public string PNR { get; set; }
            public string gds { get; set; }
            public string montoPagoDos { get; set; }
        }


        public class RespuestaSP
        {
            public string error { get; set; }
            public string IdTransaccion { get; set; }
        }

    }
}