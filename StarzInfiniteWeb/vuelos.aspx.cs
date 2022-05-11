using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace StarzInfiniteWeb
{
    public partial class vuelos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //   0         1        2      3          4         5       6    7       8      9    10     11     12       13       14          15         16
                //TIPO RUTA|ORIGEN|DESSTINO|FECHAIDA|FECHAVUELTA|ADULTOS|NINOS|INFANTE|SENIOR|LINEA|TURNO|CABINA|EQUIPAJE|DIRECTO|NOMBORIGEN|NOMBDESTINO|TIPOVENTA
                string[] datos = Session["DATOSINI"].ToString().Split('|');
                MultiView1.ActiveViewIndex = 0;
                
                //lblTipoRuta.Text = hfTipoRuta.Value;
                //if (rblTipoVenta.SelectedValue == "1")
                //    panel_rango.Visible = false;
                //else
                //{
                //    panel_rango.Visible = true;
                //}
                //panel_seccion_vuelos.Visible = true;

                ddlDestino.SelectedValue = datos[2];
                ddlOrigen.SelectedValue = datos[1];
                txtAdultos.Text = datos[5];
                txtNinos.Text = datos[6];
                txtInfante.Text = datos[7];
                txtSenior.Text = datos[8];
                hfFechaSalida.Value = datos[3];
                hfFechaRetorno.Value = datos[4];

                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);

                lblNroAdultos.Text = txtAdultos.Text;
                lblNroNinos.Text = txtNinos.Text;
                lblNroInfante.Text = txtInfante.Text;
                lblNroSeniors.Text = txtSenior.Text;

                lblDtSegmentos.Text = "";
                lblDtDatosRTAll.Text = "";
                lblDtOpciones.Text = "";
                lblDtOpcionesRT.Text = "";
                lblDtSegmentosRT.Text = "";
                lblTipoRuta.Text = datos[0];
                int adultos = 0;
                int senior = 0;
                int ninos = 0;

                int infantes = 0;
                adultos = int.Parse(datos[5]);
                ninos = int.Parse(datos[6]);
                infantes = int.Parse(datos[7]);
                senior = int.Parse(datos[8]);
                int total_pasajeros = adultos + ninos + senior + infantes;
                //lblNroAdultos.Text = txtAdultos.Text;
                //lblNroNinos.Text = txtNinos.Text;
                //lblNroInfante.Text = txtInfante.Text;
                //lblNroSeniors.Text = txtSenior.Text;
                //lblOrigen.Text = ddlOrigen.SelectedValue;
                //lblDestino.Text = ddlDestino.SelectedValue;
                //if (adultos > 0)
                //    lblAdultosResumen.Text = adultos + " adulto(s) ";
                //if (ninos > 0)
                //    lblNinosResumen.Text = ninos + " niño(s) ";
                //if (infantes > 0)
                //    lblInfanteResumen.Text = infantes + " infante(s) ";
                //if (senior > 0)
                //    lblSeniorsResumen.Text = senior + " adulto(s) mayor(es) ";

                if (infantes + ninos + adultos + senior > 9)
                {
                    lblAviso.Text = "El numero maximo de pasajeros es 9.";
                }
                else
                {
                    string vuelos_directos = datos[13];
                    
                    string vuelos_incluyenequipaje = datos[12];
                    string gds1 = "A1";
                    string linea_aerea = "";// datos[9];
                    string convenio_adt = "";
                    string convenio_menor = "";
                    string convenio_inf = "";
                    string turno = "";// datos[10];

                    string[] fecha_inf_desde, fecha_inf_hasta;

                    string cabina = "";// datos[11];
                    string fecha_flex = "0";
                    string fecha_sal = datos[3];
                    string fecha_reg = datos[4];
                    string id_session = "111111";
                    if (lblTipoRuta.Text == "OW")
                        fecha_reg = fecha_sal;
                    //lblOrigen.Text = ddlOrigen.SelectedValue;
                    //lblDestino.Text = ddlDestino.SelectedValue;
                    //lblOrigenDes.Text = ddlOrigen.SelectedItem.Text;
                    //lblDestinoDes.Text = ddlDestino.SelectedItem.Text;

                    string moneda1 = LocalBD.PR_GET_INTERNACIONAL_NACIONAL(datos[1], datos[2]);
                    //lblMoneda.Text = moneda1;
                    fecha_inf_desde = fecha_sal.Split('-');
                    fecha_inf_hasta = fecha_reg.Split('-');
                    //lblInfoAddFecha.Text = "* Cotización para viajar del " + fecha_inf_desde[2] + "-" + fecha_inf_desde[1] + "-" + fecha_inf_desde[0] + " al " + fecha_inf_hasta[2] + "-" + fecha_inf_hasta[1] + "-" + fecha_inf_hasta[0];
                    //lblInfoAddFechaGeneracion.Text = "Cotización creada el " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    //lblInfoAddMail.Text = "Mail del agente/operador " + lblUsuario.Text;
                    //////////////////////////TRAE LOS VUELOS DISPONIBLES OW////////////////////////////////
                    DBApi obj = new DBApi();
                    DsiponabilidadIda vuelos = new DsiponabilidadIda();
                    string fechaIda, fechaVuelta;
                    string[] auxfechaIda = fecha_sal.Split('-');
                    string[] auxfechaVuelta = fecha_reg.Split('-');

                    fechaIda = auxfechaIda[2] + auxfechaIda[1] + auxfechaIda[0].Remove(0, 2);
                    fechaVuelta = auxfechaVuelta[2] + auxfechaVuelta[1] + auxfechaVuelta[0].Remove(0, 2);
                    //lblTitTipoVuelo.Text = "Seleccionar viaje de Ida";
                    Datos datos1 = new Datos
                    {
                        gds = gds1,
                        adultos = adultos.ToString(),
                        senior = senior.ToString(),
                        infante = infantes.ToString(),
                        menor = ninos.ToString(),
                        origen = datos[1],
                        destino = datos[2],
                        fecha_ida = fechaIda,
                        fecha_vuelta = fechaVuelta,
                        tipo_busqueda = lblTipoRuta.Text,
                        fechaFlexible = fecha_flex,
                        vuelos_directos = vuelos_directos,
                        vuelos_incluyenequipaje = vuelos_incluyenequipaje,
                        tipo_cabina = cabina,
                        aerolinea = linea_aerea,
                        hora_salida = turno,
                        hora_regreso = turno,
                        convenio_adt = convenio_adt,
                        convenio_menor = convenio_menor,
                        convenio_inf = convenio_inf,
                        moneda = moneda1,
                        id_session = id_session
                    };

                    string json = JsonConvert.SerializeObject(datos1);
                    dynamic respuesta = obj.Post("http://20.39.32.111/api/GetDisponibilidad_v2.php", json, "Basic MDQ4NjQwNjY4c3R6cmVycjg2Y2Q3MGE4OTVjZDlmYTowNHdlcndld2V3NjhzdHpyZXJyODZjZDcwYTg5NWNkOWZh");

                    string respuestaJson = respuesta.ToString();


                    vuelos = JsonConvert.DeserializeObject<DsiponabilidadIda>(respuestaJson);


                    DataTable dt_datos = new DataTable();
                    dt_datos.Columns.AddRange(new DataColumn[19] {
                            new DataColumn("id_datos", typeof(int)),
                            new DataColumn("precio", typeof(string)),
                            new DataColumn("moneda", typeof(string)),
                            new DataColumn("gds", typeof(string)),
                            new DataColumn("boardAirport",typeof(string)),
                            new DataColumn("offAirport",typeof(string)),
                            new DataColumn("depDate",typeof(string)),
                            new DataColumn("ArrivalDate",typeof(string)),
                            new DataColumn("depTime",typeof(string)),
                            new DataColumn("hora_llegada",typeof(string)),
                            new DataColumn("duracion",typeof(string)),
                            new DataColumn("flightNumber",typeof(string)),
                            new DataColumn("bookClass",typeof(string)),
                                new DataColumn("segment",typeof(string)),
                                new DataColumn("marketCompany",typeof(string)),
                                new DataColumn("leg",typeof(string)),
                                new DataColumn("ORIGEN",typeof(string)),
                                new DataColumn("DESTINO",typeof(string)),
                                new DataColumn("gds1",typeof(string))

                            });
                    DataTable dt_datosRT = new DataTable();
                    dt_datosRT.Columns.AddRange(new DataColumn[19] {
                            new DataColumn("id_datos", typeof(int)),
                            new DataColumn("precio", typeof(string)),
                            new DataColumn("moneda", typeof(string)),
                            new DataColumn("gds", typeof(string)),
                            new DataColumn("boardAirport",typeof(string)),
                            new DataColumn("offAirport",typeof(string)),
                             new DataColumn("depDate",typeof(string)),
                            new DataColumn("ArrivalDate",typeof(string)),
                            new DataColumn("depTime",typeof(string)),
                            new DataColumn("hora_llegada",typeof(string)),
                              new DataColumn("duracion",typeof(string)),
                               new DataColumn("flightNumber",typeof(string)),
                                new DataColumn("bookClass",typeof(string)),
                                  new DataColumn("segment",typeof(string)),
                                   new DataColumn("marketCompany",typeof(string)),
                                    new DataColumn("leg",typeof(string)),
                                    new DataColumn("ORIGEN",typeof(string)),
                                    new DataColumn("DESTINO",typeof(string)),
                                    new DataColumn("gds1",typeof(string))

                            });





                    if (vuelos.error == "00")
                    {
                        List<ListItem> vuelosDisponibles = new List<ListItem>();
                        for (int i = 0; i < vuelos.datos.Count; i++)
                        {
                            decimal monto_total = 0;
                            decimal monto_totalR = 0;
                            //if (vuelos.datos[i].estado == 1)
                            //{
                            string monto, clase, moneda, lugares_disponibles, escalas, leg, origen, destino,
                                fecha_partida, fecha_llegada, hora_salida, hora_llegada, duracion, numero_vuelo, carrier;
                            string ORIGEN_NOM, DESTINO_NOM, AEROLINEA, gds, FeeTotal;
                            AEROLINEA = "";
                            ORIGEN_NOM = datos[14];
                            DESTINO_NOM = datos[15];
                            if (String.IsNullOrEmpty(vuelos.datos[i].precio))
                                monto = "0";
                            else
                                monto = vuelos.datos[i].precio.ToString();

                            clase = "";
                            gds = vuelos.datos[i].gds;
                            moneda = vuelos.datos[i].moneda;
                            escalas = "1";
                            leg = "";
                            FeeTotal = "0";

                            duracion = "0";
                            hora_salida = ""; hora_llegada = ""; fecha_partida = ""; fecha_llegada = ""; origen = ""; destino = ""; numero_vuelo = ""; carrier = "";
                            for (int x = 0; x < vuelos.datos[i].opciones.ida.Count; x++)
                            {
                                //if (x == 0)
                                //{


                                for (int y = 0; y < vuelos.datos[i].opciones.ida[x].Count; y++)
                                {
                                    DataTable DT_dom = new DataTable();
                                    DT_dom = Dominios.Lista("AEROLINEA");
                                    if (DT_dom.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in DT_dom.Rows)
                                        {
                                            if (dr["codigo"].ToString() == vuelos.datos[i].opciones.ida[x][y].operCompany)
                                                AEROLINEA = dr["descripcion"].ToString();
                                        }
                                    }
                                    escalas = vuelos.datos[i].opciones.ida[x][y].segment.ToString();
                                    origen = vuelos.datos[i].opciones.ida[x][y].boardAirport;
                                    fecha_partida = vuelos.datos[i].opciones.ida[x][y].depDate;
                                    hora_salida = vuelos.datos[i].opciones.ida[x][y].depTime;
                                    numero_vuelo = vuelos.datos[i].opciones.ida[x][y].flightNumber;
                                    carrier = vuelos.datos[i].opciones.ida[x][y].marketCompany;
                                    lugares_disponibles = vuelos.datos[i].opciones.ida[x][y].lugres_disponibles;
                                    destino = vuelos.datos[i].opciones.ida[x][y].offAirport;
                                    fecha_llegada = vuelos.datos[i].opciones.ida[x][y].ArrivalDate;
                                    hora_llegada = vuelos.datos[i].opciones.ida[x][y].hora_llegada;
                                    duracion = vuelos.datos[i].opciones.ida[x][y].duracion;
                                    clase = vuelos.datos[i].opciones.ida[x][y].bookClass;
                                    leg = vuelos.datos[i].opciones.ida[x][y].leg.ToString();

                                    string feetotal_aux = LocalBD.PR_GET_FEE_WEB_ITINERARIO(carrier, moneda, datos[16], origen, destino, lblTipoRuta.Text, total_pasajeros);
                                    if (decimal.Parse(feetotal_aux) > 0)
                                        FeeTotal = feetotal_aux;

                                    //SERVIDOR: monto_total = decimal.Parse(monto.Replace(",",".")) + decimal.Parse(FeeTotal.Replace(",", "."));
                                    //monto_total = Math.Round(( decimal.Parse(monto.Replace(".",",")) + decimal.Parse(FeeTotal.Replace(".", ","))),2);
                                    monto_total = decimal.Parse(monto.Replace(",", ".")) + decimal.Parse(FeeTotal.Replace(",", "."));
                                    //duracion = dur_aux[0] + "h" + dur_aux[1] + "m";
                                    lblDtSegmentos.Text = lblDtSegmentos.Text + y + "&" + i + "&" + vuelos.datos[i].opciones.ida[x][y].segment.ToString() + "&" + vuelos.datos[i].opciones.ida[x][y].leg + "&" +
                                            vuelos.datos[i].opciones.ida[x][y].flightNumber + "&" + vuelos.datos[i].opciones.ida[x][y].boardAirport + "&" + vuelos.datos[i].opciones.ida[x][y].offAirport + "&" +
                                            vuelos.datos[i].opciones.ida[x][y].depDate + "&" + vuelos.datos[i].opciones.ida[x][y].ArrivalDate + "&" + vuelos.datos[i].opciones.ida[x][y].depTime + "&" +
                                            vuelos.datos[i].opciones.ida[x][y].hora_llegada + "&" + vuelos.datos[i].opciones.ida[x][y].marketCompany + "&" + vuelos.datos[i].opciones.ida[x][y].operCompany + "&" +
                                            vuelos.datos[i].opciones.ida[x][y].bookClass + "&" + vuelos.datos[i].opciones.ida[x][y].lugres_disponibles + "&" + vuelos.datos[i].opciones.ida[x][y].duracion + "&" +
                                            vuelos.datos[i].opciones.ida[x][y].equipaje + "&" + vuelos.datos[i].opciones.ida[x][y].ld + "&" + monto_total.ToString() + "&" + AEROLINEA + "&" + gds + "&" + x + "&" + moneda +
                                        "|";

                                    //dt_segmentos.Rows.Add(y, i, vuelos.datos[i].opciones.ida[x][y].segment.ToString(), vuelos.datos[i].opciones.ida[x][y].leg,
                                    //        vuelos.datos[i].opciones.ida[x][y].flightNumber, vuelos.datos[i].opciones.ida[x][y].boardAirport, vuelos.datos[i].opciones.ida[x][y].offAirport,
                                    //        vuelos.datos[i].opciones.ida[x][y].depDate, vuelos.datos[i].opciones.ida[x][y].ArrivalDate, vuelos.datos[i].opciones.ida[x][y].depTime,
                                    //        vuelos.datos[i].opciones.ida[x][y].hora_llegada, vuelos.datos[i].opciones.ida[x][y].marketCompany, vuelos.datos[i].opciones.ida[x][y].operCompany,
                                    //        vuelos.datos[i].opciones.ida[x][y].bookClass, vuelos.datos[i].opciones.ida[x][y].lugres_disponibles, vuelos.datos[i].opciones.ida[x][y].duracion,
                                    //        vuelos.datos[i].opciones.ida[x][y].equipaje, vuelos.datos[i].opciones.ida[x][y].ld, monto, AEROLINEA, gds, x, moneda);

                                }

                                lblDtOpciones.Text = lblDtOpciones.Text + x + "&" + i + "&" + monto_total.ToString() + "&" + moneda + "&" + AEROLINEA + "|";
                                //dt_opciones.Rows.Add(x, i, monto, moneda, AEROLINEA);

                            }
                            //monto_total = Math.Round((decimal.Parse(monto.Replace(".", ",")) + decimal.Parse(FeeTotal.Replace(".", ","))), 2);
                            monto_total = Math.Round((decimal.Parse(monto.Replace(",", ".")) + decimal.Parse(FeeTotal.Replace(",", "."))), 2);
                            lblDtDatosAll.Text = lblDtDatosAll.Text + i + "&" + monto_total.ToString() + "&" + vuelos.datos[i].moneda + "&" + vuelos.datos[i].gds + "&" + origen + "&" + destino + "&" + fecha_partida + "&" + fecha_llegada + "&" +
                                    hora_salida + "&" + hora_llegada + "&" + duracion + "&" + numero_vuelo + "&" + clase + "&" + escalas + "&" + carrier + "&" + leg + "&" + ORIGEN_NOM + "&" + DESTINO_NOM + "&" + gds + "|";
                            dt_datos.Rows.Add(i, monto_total, vuelos.datos[i].moneda, vuelos.datos[i].gds, origen, destino, fecha_partida, fecha_llegada,
                                hora_salida, hora_llegada, duracion, numero_vuelo, clase, escalas, carrier, leg, ORIGEN_NOM, DESTINO_NOM, gds);

                            if (lblTipoRuta.Text == "RT")
                            {
                                string montoR, claseR, monedaR, lugares_disponiblesR, escalasR, legR, origenR, destinoR,
                                    fecha_partidaR, fecha_llegadaR, hora_salidaR, hora_llegadaR, duracionR, numero_vueloR, carrierR;
                                string ORIGEN_NOMR, DESTINO_NOMR, AEROLINEAR, gdsR;
                                AEROLINEAR = "";
                                ORIGEN_NOMR = datos[15];
                                DESTINO_NOMR = datos[14];
                                if (String.IsNullOrEmpty(vuelos.datos[i].precio))
                                    montoR = "0";
                                else
                                    montoR = vuelos.datos[i].precio.ToString();
                                claseR = "";
                                gdsR = vuelos.datos[i].gds;
                                monedaR = vuelos.datos[i].moneda;
                                escalasR = "1";
                                legR = "";


                                duracionR = "0";
                                hora_salidaR = ""; hora_llegadaR = ""; fecha_partidaR = ""; fecha_llegadaR = ""; origenR = ""; destinoR = ""; numero_vueloR = ""; carrierR = "";
                                for (int x = 0; x < vuelos.datos[i].opciones.vuelta.Count; x++)
                                {
                                    //if (x == 0)
                                    //{


                                    for (int y = 0; y < vuelos.datos[i].opciones.vuelta[x].Count; y++)
                                    {
                                        DataTable DT_dom = new DataTable();
                                        DT_dom = Dominios.Lista("AEROLINEA");
                                        if (DT_dom.Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in DT_dom.Rows)
                                            {
                                                if (dr["codigo"].ToString() == vuelos.datos[i].opciones.vuelta[x][y].operCompany)
                                                    AEROLINEAR = dr["descripcion"].ToString();
                                            }
                                        }
                                        escalasR = vuelos.datos[i].opciones.vuelta[x][y].segment.ToString();
                                        origenR = vuelos.datos[i].opciones.vuelta[x][y].boardAirport;
                                        fecha_partidaR = vuelos.datos[i].opciones.vuelta[x][y].depDate;
                                        hora_salidaR = vuelos.datos[i].opciones.vuelta[x][y].depTime;
                                        numero_vueloR = vuelos.datos[i].opciones.vuelta[x][y].flightNumber;
                                        carrierR = vuelos.datos[i].opciones.vuelta[x][y].marketCompany;
                                        lugares_disponiblesR = vuelos.datos[i].opciones.vuelta[x][y].lugres_disponibles;
                                        destinoR = vuelos.datos[i].opciones.vuelta[x][y].offAirport;
                                        fecha_llegadaR = vuelos.datos[i].opciones.vuelta[x][y].ArrivalDate;
                                        hora_llegadaR = vuelos.datos[i].opciones.vuelta[x][y].hora_llegada;
                                        duracionR = vuelos.datos[i].opciones.vuelta[x][y].duracion;
                                        claseR = vuelos.datos[i].opciones.vuelta[x][y].bookClass;
                                        legR = vuelos.datos[i].opciones.vuelta[x][y].leg.ToString();



                                        lblDtSegmentosRT.Text = lblDtSegmentosRT.Text + y + "&" + i + "&" + vuelos.datos[i].opciones.vuelta[x][y].segment.ToString() + "&" + vuelos.datos[i].opciones.vuelta[x][y].leg + "&" +
                                                vuelos.datos[i].opciones.vuelta[x][y].flightNumber + "&" + vuelos.datos[i].opciones.vuelta[x][y].boardAirport + "&" + vuelos.datos[i].opciones.vuelta[x][y].offAirport + "&" +
                                                vuelos.datos[i].opciones.vuelta[x][y].depDate + "&" + vuelos.datos[i].opciones.vuelta[x][y].ArrivalDate + "&" + vuelos.datos[i].opciones.vuelta[x][y].depTime + "&" +
                                                vuelos.datos[i].opciones.vuelta[x][y].hora_llegada + "&" + vuelos.datos[i].opciones.vuelta[x][y].marketCompany + "&" + vuelos.datos[i].opciones.vuelta[x][y].operCompany + "&" +
                                                vuelos.datos[i].opciones.vuelta[x][y].bookClass + "&" + vuelos.datos[i].opciones.vuelta[x][y].lugres_disponibles + "&" + vuelos.datos[i].opciones.vuelta[x][y].duracion + "&" +
                                                vuelos.datos[i].opciones.vuelta[x][y].equipaje + "&" + vuelos.datos[i].opciones.vuelta[x][y].ld + "&" + monto_total.ToString() + "&" + AEROLINEAR + "&" + gdsR + "&" + x + "&" + monedaR + "|";
                                        //dt_segmentosRT.Rows.Add(y, i, vuelos.datos[i].opciones.vuelta[x][y].segment.ToString(), vuelos.datos[i].opciones.vuelta[x][y].leg,
                                        //        vuelos.datos[i].opciones.vuelta[x][y].flightNumber, vuelos.datos[i].opciones.vuelta[x][y].boardAirport, vuelos.datos[i].opciones.vuelta[x][y].offAirport,
                                        //        vuelos.datos[i].opciones.vuelta[x][y].depDate, vuelos.datos[i].opciones.vuelta[x][y].ArrivalDate, vuelos.datos[i].opciones.vuelta[x][y].depTime,
                                        //        vuelos.datos[i].opciones.vuelta[x][y].hora_llegada, vuelos.datos[i].opciones.vuelta[x][y].marketCompany, vuelos.datos[i].opciones.vuelta[x][y].operCompany,
                                        //        vuelos.datos[i].opciones.vuelta[x][y].bookClass, vuelos.datos[i].opciones.vuelta[x][y].lugres_disponibles, vuelos.datos[i].opciones.vuelta[x][y].duracion,
                                        //        vuelos.datos[i].opciones.vuelta[x][y].equipaje, vuelos.datos[i].opciones.vuelta[x][y].ld, montoR, AEROLINEAR, gdsR, x, monedaR);

                                    }
                                    lblDtOpcionesRT.Text = lblDtOpcionesRT.Text + x + "&" + i + "&" + monto_total.ToString() + "&" + monedaR + "&" + AEROLINEAR + "|";
                                    //dt_opcionesRT.Rows.Add(x, i, montoR, monedaR, AEROLINEAR);

                                }
                                lblDtDatosRTAll.Text = lblDtDatosRTAll.Text + i + "&" + monto_total.ToString() + "&" + vuelos.datos[i].moneda + "&" + vuelos.datos[i].gds + "&" + origenR + "&" + destinoR + "&" + fecha_partidaR + "&" + fecha_llegadaR + "&" +
                                    hora_salidaR + "&" + hora_llegadaR + "&" + duracionR + "&" + numero_vueloR + "&" + claseR + "&" + escalasR + "&" + carrierR + "&" + legR + "&" + ORIGEN_NOMR + "&" + DESTINO_NOMR + "&" + gdsR + "|";
                                dt_datosRT.Rows.Add(i, monto_total.ToString(), vuelos.datos[i].moneda, vuelos.datos[i].gds, origenR, destinoR, fecha_partidaR, fecha_llegadaR,
                                    hora_salidaR, hora_llegadaR, duracionR, numero_vueloR, claseR, escalasR, carrierR, legR, ORIGEN_NOMR, DESTINO_NOMR, gdsR);

                            }


                        }
                        lblVueloIdaNoDisponible.Text = "";
                    }
                    else
                    {
                        lblVueloIdaNoDisponible.Text = "El servicio web no devuelve datos, consulte con el administrador.";
                    }
                    Repeater1.DataSource = dt_datos;
                    Repeater1.DataBind();

                    


                }

            }


        }


        #region busquedas
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
            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + hfFechaSalida.Value + "|" + hfFechaRetorno.Value
                 + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                  + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                  + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }
        #endregion

        #region repeaters
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item ||
                 e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Label id = (Label)e.Item.FindControl("lblIdDato");
                    Label lblAero = (Label)e.Item.FindControl("lblAreolineaNomb");
                   
                    //Button elegir = (Button)e.Item.FindControl("btnElegir");
                    if (id != null)
                    {
                        string consulta = "id_datos='" + id.Text + "'";
                        Repeater rOpciones = (Repeater)e.Item.FindControl("Repeater2");
                        //rOpciones.DataBind();
                        DataTable dt_opciones = new DataTable();
                        dt_opciones.Columns.AddRange(new DataColumn[5] {
                    new DataColumn("id_opcion",typeof(int)),
                    new DataColumn("id_datos", typeof(int)),
                        new DataColumn("precio", typeof(string)),
                         new DataColumn("moneda",typeof(string)),
                         new DataColumn("AEROLINEA",typeof(string))
                        });

                        string[] datosRT_aux = lblDtOpciones.Text.Split('|');
                        int i = 0;
                        for (i = 0; i < datosRT_aux.Count() - 1; i++)
                        {
                            string[] datosRT = datosRT_aux[i].Split('&');

                            dt_opciones.Rows.Add(new string[5] { datosRT[0], datosRT[1], datosRT[2], datosRT[3], datosRT[4] });

                        }


                        DataTable dt1 = dt_opciones.Select(consulta).CopyToDataTable();
                        rOpciones.DataSource = dt1;
                        rOpciones.DataBind();
                        if (lblTipoRuta.Text == "RT")
                        {
                            string consulta2 = "id_datos='" + id.Text + "'";
                            Repeater rOpciones2 = (Repeater)e.Item.FindControl("Repeater5");

                            DataTable dt_opciones2 = new DataTable();
                            dt_opciones2.Columns.AddRange(new DataColumn[5] {
                    new DataColumn("id_opcion",typeof(int)),
                    new DataColumn("id_datos", typeof(int)),
                        new DataColumn("precio", typeof(string)),
                         new DataColumn("moneda",typeof(string)),
                         new DataColumn("AEROLINEA",typeof(string))
                        });

                            string[] datosRT_aux2 = lblDtOpcionesRT.Text.Split('|');
                            int x = 0;
                            for (x = 0; x < datosRT_aux2.Count() - 1; x++)
                            {
                                string[] datosRT = datosRT_aux2[x].Split('&');

                                dt_opciones2.Rows.Add(new string[5] { datosRT[0], datosRT[1], datosRT[2], datosRT[3], datosRT[4] });

                            }


                            DataTable dt2 = dt_opciones2.Select(consulta2).CopyToDataTable();
                            rOpciones2.DataSource = dt2;
                            rOpciones2.DataBind();
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_repeater1_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }

        }
        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    string aux = "";
                    CheckBox cbIda = (CheckBox)e.Item.FindControl("cbElegirIda");
                    Label id = (Label)e.Item.FindControl("lblIdopcion");
                    Label id2 = (Label)e.Item.FindControl("lblIdDatos");
                    //Label resumen = (Label)e.Item.FindControl("lblResumenCab");
                    Image imLogo=(Image)e.Item.FindControl("imgIda");
                    Label escalaslbl = (Label)e.Item.FindControl("lblEscalas");
                    Button elegir = (Button)e.Item.FindControl("btnElegir");
                    if (id != null)
                    {
                        string consulta = "id_opcion='" + id.Text + "' AND id_datos='" + id2.Text + "'";
                        Repeater rSegmentos = (Repeater)e.Item.FindControl("Repeater3");
                        //rSegmentos.DataBind();
                        DataTable dt_segmentos = new DataTable();
                        dt_segmentos.Columns.AddRange(new DataColumn[23] {
                    new DataColumn("id_segmento",typeof(int)),
                    new DataColumn("id_datos", typeof(int)),
                        new DataColumn("segment",typeof(string)),
                        new DataColumn("leg",typeof(string)),
                        new DataColumn("flightNumber",typeof(string)),
                        new DataColumn("boardAirport",typeof(string)),
                        new DataColumn("offAirport",typeof(string)),
                        new DataColumn("depDate",typeof(string)),
                        new DataColumn("ArrivalDate",typeof(string)),
                        new DataColumn("depTime",typeof(string)),
                        new DataColumn("hora_llegada",typeof(string)),
                        new DataColumn("marketCompany",typeof(string)),
                        new DataColumn("operCompany",typeof(string)),
                        new DataColumn("bookClass",typeof(string)),
                        new DataColumn("lugres_disponibles",typeof(string)),
                        new DataColumn("duracion",typeof(string)),
                        new DataColumn("equipaje",typeof(string)),
                        new DataColumn("ld",typeof(string)),
                        new DataColumn("precio", typeof(string)),
                         new DataColumn("AEROLINEA",typeof(string)),
                         new DataColumn("gds1",typeof(string)),
                         new DataColumn("id_opcion",typeof(string)),
                         new DataColumn("moneda",typeof(string))
                        });

                        string[] datosRT_aux = lblDtSegmentos.Text.Split('|');
                        int i = 0;
                        for (i = 0; i < datosRT_aux.Count() - 1; i++)
                        {
                            string[] datosRT = datosRT_aux[i].Split('&');

                            dt_segmentos.Rows.Add(new string[23] { datosRT[0], datosRT[1], datosRT[2], datosRT[3], datosRT[4], datosRT[5],
                     datosRT[6], datosRT[7], datosRT[8], datosRT[9], datosRT[10], datosRT[11], datosRT[12], datosRT[13], datosRT[14],
                     datosRT[15], datosRT[16], datosRT[17], datosRT[18], datosRT[19], datosRT[20], datosRT[21], datosRT[22]});
                        }


                        DataTable dt1 = dt_segmentos.Select(consulta).CopyToDataTable();
                        rSegmentos.DataSource = dt1;
                        rSegmentos.DataBind();
                        string origen_ida = "";
                        string destino_ida = "";
                        string vuelo_salida = "";
                        string vuelo_llegada = "";
                        string hora_salida = "";
                        string fecha_salida = "";
                        string hora_llegada = "";
                        string fecha_llegada = "";
                        string clase_salida = "";
                        string clase_llegada = "";
                        string disponibles_I = "";
                        string disponibles_V = "";
                        string equipaje_I = "";
                        string equipaje_V = "";
                        string duracion_aux = "";
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            string consulta2 = "id_opcion='" + dr1["id_opcion"] + "'";
                            DataTable dt2 = dt1.Select(consulta2).CopyToDataTable();
                            int escalas = 0;

                            foreach (DataRow dr in dt2.Rows)
                            {
                                //new DataColumn("id_segmento", typeof(int)),
                                //new DataColumn("id_datos", typeof(int)),
                                //new DataColumn("segment", typeof(string)),
                                //new DataColumn("leg", typeof(string)),
                                //new DataColumn("flightNumber", typeof(string)),
                                //new DataColumn("boardAirport", typeof(string)),
                                //new DataColumn("offAirport", typeof(string)),
                                //new DataColumn("depDate", typeof(string)),
                                //new DataColumn("ArrivalDate", typeof(string)),
                                //new DataColumn("depTime", typeof(string)),
                                //new DataColumn("hora_llegada", typeof(string)),
                                //new DataColumn("marketCompany", typeof(string)),
                                //new DataColumn("operCompany", typeof(string)),
                                //new DataColumn("bookClass", typeof(string)),
                                //new DataColumn("lugres_disponibles", typeof(string)),
                                //new DataColumn("duracion", typeof(string)),
                                //new DataColumn("equipaje", typeof(string)),
                                //new DataColumn("ld", typeof(string)),
                                //new DataColumn("precio", typeof(string)),
                                //new DataColumn("AEROLINEA", typeof(string)),
                                //new DataColumn("gds1", typeof(string))
                                if (escalas == 0)
                                {
                                    origen_ida = dr["boardAirport"].ToString();
                                    vuelo_salida = dr["flightNumber"].ToString();
                                    hora_salida = dr["depTime"].ToString();
                                    clase_salida = dr["bookClass"].ToString();
                                    fecha_salida = dr["depDate"].ToString();
                                    disponibles_I = dr["lugres_disponibles"].ToString();
                                    equipaje_I = dr["equipaje"].ToString();
                                    imLogo.ImageUrl = "~/Logos/" + dr["operCompany"].ToString() + ".png";
                                }
                                //else
                                //{

                                //}
                                destino_ida = dr["offAirport"].ToString();
                                vuelo_llegada = dr["flightNumber"].ToString();
                                hora_llegada = dr["hora_llegada"].ToString();
                                clase_llegada = dr["bookClass"].ToString();
                                fecha_llegada = dr["ArrivalDate"].ToString();
                                disponibles_V = dr["lugres_disponibles"].ToString();
                                equipaje_V = dr["equipaje"].ToString();
                                escalas++;
                                aux = aux + "&" + dr["boardAirport"].ToString() + "|" + dr["offAirport"].ToString() + "|" + dr["depTime"].ToString() + "|" + dr["depDate"].ToString()
                                      + "|" + dr["bookClass"].ToString() + "|" + dr["operCompany"].ToString() + "|" + dr["flightNumber"].ToString() + "|" + "ida"
                                      + "|" + dr["leg"].ToString() + "|" + dr["ld"].ToString() + "|" + dr["gds1"].ToString() + "|" + dr["moneda"].ToString() + "|" + dr["precio"].ToString()
                                      + "|" + dr["id_opcion"].ToString() + "|" + dr["id_datos"].ToString() + "|" + dr["duracion"].ToString() + "|" + dr["hora_llegada"].ToString() + "|" +
                                      dr["ArrivalDate"].ToString() + "|" + dr["lugres_disponibles"].ToString();


                                //resumen.Text = resumen.Text + " " + dr["boardAirport"].ToString() + "-" + dr["offAirport"].ToString() + "-" + dr["depTime"].ToString() + " " + dr["depDate"].ToString();

                            }

                            if (DateTime.Parse(fecha_llegada) > DateTime.Parse(fecha_salida))
                                duracion_aux = "+1";
                            else
                                duracion_aux = "";
                            Label origenI = (Label)e.Item.FindControl("lblOrigenI");
                            Label vueloI = (Label)e.Item.FindControl("lblNroVueloI");
                            Label claseI = (Label)e.Item.FindControl("lblClaseI");
                            Label fechaSalidaI = (Label)e.Item.FindControl("lblFechaSalidaI");
                            Label horaSalidaI = (Label)e.Item.FindControl("lblHoraSalidaI");
                            Label disponiblesI = (Label)e.Item.FindControl("lblDisponiblesI");
                            Label equipajeI = (Label)e.Item.FindControl("lblEquipajeI");
                            Label indicador = (Label)e.Item.FindControl("lblnIndicador");
                            Label destinoV = (Label)e.Item.FindControl("lblDestinoV");
                            Label vueloV = (Label)e.Item.FindControl("lblNroVueloV");
                            Label claseV = (Label)e.Item.FindControl("lblClaseV");
                            Label fechaLlegadaV = (Label)e.Item.FindControl("lblFechaLlegadaV");
                            Label horaLlegadaV = (Label)e.Item.FindControl("lblHoraLlegadaV");
                            Label disponiblesV = (Label)e.Item.FindControl("lblDisponiblesV");
                            Label equipajeV = (Label)e.Item.FindControl("lblEquipajeV");
                            Image equiBodega = (Image)e.Item.FindControl("imgEBodega");
                            origenI.Text = origen_ida;
                            vueloI.Text = vuelo_salida;
                            claseI.Text = clase_salida;
                            fechaSalidaI.Text = fecha_salida;
                            horaSalidaI.Text = hora_salida;
                            disponiblesI.Text = disponibles_I;
                            equipajeI.Text = equipaje_I.Trim();
                            destinoV.Text = destino_ida;
                            vueloV.Text = vuelo_llegada;
                            claseV.Text = clase_llegada;
                            fechaLlegadaV.Text = fecha_llegada;
                            horaLlegadaV.Text = hora_llegada;
                            disponiblesV.Text = disponibles_V;
                            equipajeV.Text = equipaje_V.Trim();
                            indicador.Text = duracion_aux;
                            if (equipajeI.Text.Trim() == "0" || equipajeI.Text.Trim() == "")
                            {
                                equiBodega.Visible = false;
                                equiBodega.ToolTip = equipajeI.Text;

                            }
                            else
                            {
                                equiBodega.Visible = true;
                                equiBodega.ToolTip = equipajeI.Text;
                            }

                            //resumen.Text ="Origen: "+ origen_ida+ " Nro.Vuelo: " + vuelo_salida + " Clase: " + clase_salida  + " Fecha: " + fecha_salida + " Hora: " + hora_salida + 
                            //    "----------->" + "Origen: "+destino_ida + " Nro.Vuelo: " + vuelo_llegada + " Clase: " + clase_llegada  + " Fecha: " + fecha_llegada + " Hora: " + hora_llegada;
                            escalaslbl.Text = " - Nro Escalas: " + (escalas - 1).ToString();
                            elegir.ToolTip = aux;
                            elegir.CommandArgument = aux;
                            cbIda.ToolTip = aux;
                            aux = "";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_repeater2_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }

        }

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        protected void Repeater4_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item ||
            //     e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Label id = (Label)e.Item.FindControl("lblIdDato");
            //    Label lblAero = (Label)e.Item.FindControl("lblAreolineaNomb");
            //    if (id.Text != null || id.Text != "")
            //    {

            //        string consulta = "id_datos='" + id.Text + "'";
            //        Repeater rOpciones = (Repeater)e.Item.FindControl("Repeater5");

            //        DataTable dt_opcionesRT = new DataTable();
            //        dt_opcionesRT.Columns.AddRange(new DataColumn[5] {
            //        new DataColumn("id_opcion",typeof(int)),
            //        new DataColumn("id_datos", typeof(int)),
            //            new DataColumn("precio", typeof(string)),
            //             new DataColumn("moneda",typeof(string)),
            //             new DataColumn("AEROLINEA",typeof(string))
            //            });

            //        string[] datosRT_aux = lblDtOpcionesRT.Text.Split('|');
            //        int i = 0;
            //        for (i = 0; i < datosRT_aux.Count() - 1; i++)
            //        {
            //            string[] datosRT = datosRT_aux[i].Split('&');

            //            dt_opcionesRT.Rows.Add(new string[5] { datosRT[0], datosRT[1], datosRT[2], datosRT[3], datosRT[4] });
            //            // }
            //        }

            //        DataTable dt1 = dt_opcionesRT.Select(consulta).CopyToDataTable();
            //        rOpciones.DataSource = dt1;
            //        rOpciones.DataBind();
            //    }
            //    else
            //    {
            //        Repeater rOpciones = (Repeater)e.Item.FindControl("Repeater5");

            //        DataTable dt_opcionesRT = new DataTable();
            //        dt_opcionesRT.Columns.AddRange(new DataColumn[5] {
            //        new DataColumn("id_opcion",typeof(int)),
            //        new DataColumn("id_datos", typeof(int)),
            //            new DataColumn("precio", typeof(string)),
            //             new DataColumn("moneda",typeof(string)),
            //             new DataColumn("AEROLINEA",typeof(string))
            //            });

            //        string[] datosRT_aux = lblDtOpcionesRT.Text.Split('|');
            //        int i = 0;
            //        for (i = 0; i < datosRT_aux.Count() - 1; i++)
            //        {
            //            string[] datosRT = datosRT_aux[i].Split('&');

            //            dt_opcionesRT.Rows.Add(new string[5] { datosRT[0], datosRT[1], datosRT[2], datosRT[3], datosRT[4] });
            //            // }
            //        }

            //        rOpciones.DataSource = dt_opcionesRT;
            //        rOpciones.DataBind();
            //    }

            //}
        }

        protected void Repeater5_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    string aux = "";
                    Label id = (Label)e.Item.FindControl("lblIdopcion");
                    Label id2 = (Label)e.Item.FindControl("lblIdDatos");
                    CheckBox cbVuelta = (CheckBox)e.Item.FindControl("cbElegirVuelta");
                    Label escalaslbl = (Label)e.Item.FindControl("lblEscalas");
                    Button elegir = (Button)e.Item.FindControl("btnElegirRT");
                    Image imLogo = (Image)e.Item.FindControl("imgVuelta");
                    if (id != null)
                    {
                        string consulta = "id_opcion='" + id.Text + "' AND id_datos='" + id2.Text + "'";
                        Repeater rSegmentos = (Repeater)e.Item.FindControl("Repeater6");
                        //rSegmentos.DataBind();
                        DataTable dt_segmentosRT = new DataTable();
                        dt_segmentosRT.Columns.AddRange(new DataColumn[23] {
                    new DataColumn("id_segmento",typeof(int)),
                    new DataColumn("id_datos", typeof(int)),
                        new DataColumn("segment",typeof(string)),
                        new DataColumn("leg",typeof(string)),
                        new DataColumn("flightNumber",typeof(string)),
                        new DataColumn("boardAirport",typeof(string)),
                        new DataColumn("offAirport",typeof(string)),
                        new DataColumn("depDate",typeof(string)),
                        new DataColumn("ArrivalDate",typeof(string)),
                        new DataColumn("depTime",typeof(string)),
                        new DataColumn("hora_llegada",typeof(string)),
                        new DataColumn("marketCompany",typeof(string)),
                        new DataColumn("operCompany",typeof(string)),
                        new DataColumn("bookClass",typeof(string)),
                        new DataColumn("lugres_disponibles",typeof(string)),
                        new DataColumn("duracion",typeof(string)),
                        new DataColumn("equipaje",typeof(string)),
                        new DataColumn("ld",typeof(string)),
                        new DataColumn("precio", typeof(string)),
                         new DataColumn("AEROLINEA",typeof(string)),
                         new DataColumn("gds1",typeof(string)),
                         new DataColumn("id_opcion",typeof(string)),
                         new DataColumn("moneda",typeof(string))
                        });

                        string[] datosRT_aux = lblDtSegmentosRT.Text.Split('|');
                        int i = 0;
                        for (i = 0; i < datosRT_aux.Count() - 1; i++)
                        {
                            string[] datosRT = datosRT_aux[i].Split('&');

                            dt_segmentosRT.Rows.Add(new string[23] { datosRT[0], datosRT[1], datosRT[2], datosRT[3], datosRT[4], datosRT[5],
                     datosRT[6], datosRT[7], datosRT[8], datosRT[9], datosRT[10], datosRT[11], datosRT[12], datosRT[13], datosRT[14],
                     datosRT[15], datosRT[16], datosRT[17], datosRT[18], datosRT[19], datosRT[20], datosRT[21], datosRT[22]});
                            
                            // }
                        }

                        DataTable dt1 = dt_segmentosRT.Select(consulta).CopyToDataTable();
                        rSegmentos.DataSource = dt1;
                        rSegmentos.DataBind();
                        string origen_ida = "";
                        string destino_ida = "";
                        string vuelo_salida = "";
                        string vuelo_llegada = "";
                        string hora_salida = "";
                        string fecha_salida = "";
                        string hora_llegada = "";
                        string fecha_llegada = "";
                        string clase_salida = "";
                        string clase_llegada = "";
                        string disponibles_I = "";
                        string disponibles_V = "";
                        string equipaje_I = "";
                        string equipaje_V = "";

                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            string consulta2 = "id_opcion='" + dr1["id_opcion"] + "'";
                            DataTable dt2 = dt1.Select(consulta2).CopyToDataTable();
                            int escalas = 0;

                            foreach (DataRow dr in dt2.Rows)
                            {
                                if (escalas == 0)
                                {
                                    origen_ida = dr["boardAirport"].ToString();
                                    vuelo_salida = dr["flightNumber"].ToString();
                                    hora_salida = dr["depTime"].ToString();
                                    clase_salida = dr["bookClass"].ToString();
                                    fecha_salida = dr["depDate"].ToString();
                                    disponibles_I = dr["lugres_disponibles"].ToString();
                                    equipaje_I = dr["equipaje"].ToString();
                                    imLogo.ImageUrl = "~/Logos/" + dr["operCompany"].ToString() + ".png";
                                }
                                //else
                                //{

                                //}
                                destino_ida = dr["offAirport"].ToString();
                                vuelo_llegada = dr["flightNumber"].ToString();
                                hora_llegada = dr["hora_llegada"].ToString();
                                clase_llegada = dr["bookClass"].ToString();
                                fecha_llegada = dr["ArrivalDate"].ToString();
                                disponibles_V = dr["lugres_disponibles"].ToString();
                                equipaje_V = dr["equipaje"].ToString();
                                escalas++;
                                aux = aux + "&" + dr["boardAirport"].ToString() + "|" + dr["offAirport"].ToString() + "|" + dr["depTime"].ToString() + "|" + dr["depDate"].ToString()
                                      + "|" + dr["bookClass"].ToString() + "|" + dr["operCompany"].ToString() + "|" + dr["flightNumber"].ToString() + "|" + "vuelta"
                                      + "|" + dr["leg"].ToString() + "|" + dr["ld"].ToString() + "|" + dr["gds1"].ToString() + "|" + dr["moneda"].ToString() + "|" + dr["precio"].ToString()
                                      + "|" + dr["id_opcion"].ToString() + "|" + dr["id_datos"].ToString() + "|" + dr["duracion"].ToString() + "|" + dr["hora_llegada"].ToString() + "|" +
                                      dr["ArrivalDate"].ToString() + "|" + dr["lugres_disponibles"].ToString();


                                //resumen.Text = resumen.Text + " " + dr["boardAirport"].ToString() + "-" + dr["offAirport"].ToString() + "-" + dr["depTime"].ToString() + " " + dr["depDate"].ToString();

                            }
                            string duracion_aux = "";
                            if (DateTime.Parse(fecha_llegada) > DateTime.Parse(fecha_salida))
                                duracion_aux = "+1";
                            else
                                duracion_aux = "";

                            Label origenI = (Label)e.Item.FindControl("lblOrigenI");
                            Label vueloI = (Label)e.Item.FindControl("lblNroVueloI");
                            Label claseI = (Label)e.Item.FindControl("lblClaseI");
                            Label fechaSalidaI = (Label)e.Item.FindControl("lblFechaSalidaI");
                            Label horaSalidaI = (Label)e.Item.FindControl("lblHoraSalidaI");
                            Label disponiblesI = (Label)e.Item.FindControl("lblDisponiblesI");
                            Label indicador = (Label)e.Item.FindControl("lblnIndicador");
                            Label equipajeI = (Label)e.Item.FindControl("lblEquipajeI");

                            Label destinoV = (Label)e.Item.FindControl("lblDestinoV");
                            Label vueloV = (Label)e.Item.FindControl("lblNroVueloV");
                            Label claseV = (Label)e.Item.FindControl("lblClaseV");
                            Label fechaLlegadaV = (Label)e.Item.FindControl("lblFechaLlegadaV");
                            Label horaLlegadaV = (Label)e.Item.FindControl("lblHoraLlegadaV");
                            Label disponiblesV = (Label)e.Item.FindControl("lblDisponiblesV");
                            Label equipajeV = (Label)e.Item.FindControl("lblEquipajeV");
                            Image equiBodega = (Image)e.Item.FindControl("imgEBodega");


                            indicador.Text = duracion_aux;

                            origenI.Text = origen_ida;
                            vueloI.Text = vuelo_salida;
                            claseI.Text = clase_salida;
                            fechaSalidaI.Text = fecha_salida;
                            horaSalidaI.Text = hora_salida;
                            disponiblesI.Text = disponibles_I;
                            equipajeI.Text = equipaje_I;
                            destinoV.Text = destino_ida;
                            vueloV.Text = vuelo_llegada;
                            claseV.Text = clase_llegada;
                            fechaLlegadaV.Text = fecha_llegada;
                            horaLlegadaV.Text = hora_llegada;
                            disponiblesV.Text = disponibles_V;
                            equipajeV.Text = equipaje_V;


                            if (equipajeI.Text.Trim() == "0" || equipajeI.Text.Trim() == "")
                            {
                                equiBodega.Visible = false;
                                equiBodega.ToolTip = equipajeI.Text;

                            }
                            else
                            {
                                equiBodega.Visible = true;
                                equiBodega.ToolTip = equipajeI.Text;
                            }

                            //resumen.Text = "Origen: " + origen_ida + " Nro.Vuelo: " + vuelo_salida + " Clase: " + clase_salida + " Fecha: " + fecha_salida + " Hora: " + hora_salida +
                            //    "----------->" + "Destino: " + destino_ida + " Nro.Vuelo: " + vuelo_llegada + " Clase: " + clase_llegada + " Fecha: " + fecha_llegada + " Hora: " + hora_llegada;
                            escalaslbl.Text = " - Nro Escalas: " + (escalas - 1).ToString();
                            cbVuelta.ToolTip = aux;
                            elegir.CommandArgument = aux;
                            elegir.Enabled = false;
                            aux = "";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_repeater5_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }

        }

        protected void Repeater6_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }


        #endregion

        #region funciones ayuda
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
        public void GenerarGanancias(string cadena)
        {
            try
            {
                int adultos = 0;
                int senior = 0;
                int ninos = 0;

                int infantes = 0;

                adultos = int.Parse(lblNroAdultos.Text);
                ninos = int.Parse(lblNroNinos.Text);
                infantes = int.Parse(lblNroInfante.Text);
                senior = int.Parse(lblNroSeniors.Text);
                int total_pasajeros = adultos + ninos + senior + infantes;

                //0 dr["boardAirport"].ToString() + "|" +
                //1 dr["offAirport"].ToString() + "|" +
                //2 dr["depTime"].ToString() + "|" +
                //3 dr["depDate"].ToString()
                //4 dr["bookClass"].ToString() + "|" +
                //5 dr["operCompany"].ToString() + "|" +
                //6 dr["flightNumber"].ToString() + "|" +
                //7 "ida"
                //8 dr["leg"].ToString() + "|" +
                //9 dr["ld"].ToString() + "|" +
                //10 dr["gds1"].ToString() + "|" +
                //11 dr["moneda"].ToString() + "|" +
                //12 dr["precio"].ToString();
                //13 id_opcion
                //14 id_datos
                //string[] datos_vuelo_ida = cadena.Split('|');
                //string clase = datos_vuelo_ida[4];
                //string carrier = datos_vuelo_ida[5];
                string gds = "";
                string moneda = "";
                string operador = "";
                DataTable dt_itinerario = new DataTable();
                if (dt_itinerario.Rows.Count > 0)
                {
                }
                else
                {
                    dt_itinerario.Columns.Add("origen", typeof(string));
                    dt_itinerario.Columns.Add("destino", typeof(string));
                    dt_itinerario.Columns.Add("hora", typeof(string));
                    dt_itinerario.Columns.Add("fecha", typeof(string));
                    dt_itinerario.Columns.Add("clase", typeof(string));
                    dt_itinerario.Columns.Add("carrier", typeof(string));
                    dt_itinerario.Columns.Add("numero_vuelo", typeof(string));
                    dt_itinerario.Columns.Add("tipo", typeof(string));
                    dt_itinerario.Columns.Add("leg", typeof(string));
                    dt_itinerario.Columns.Add("ld", typeof(string));

                }
                //string[] fecha_aux = datos_vuelo_ida[2].ToString().Split('-');

                //string fecha = fecha_aux[2] + fecha_aux[1] + fecha_aux[0].Remove(0, 2);
                string[] aux_ida = lblItiIda.Text.Split('&');
                for (int i = 1; i < aux_ida.Length; i++)
                {

                    string[] iti_ida = aux_ida[i].Split('|');
                    string[] fecha_aux = iti_ida[3].ToString().Split('-');
                    gds = iti_ida[10];
                    lblGds.Text = gds;
                    moneda = iti_ida[11];
                    lblMoneda.Text = moneda;
                    lblMonedaIda.Text = moneda;
                    operador = iti_ida[5];
                    string fecha = fecha_aux[2] + fecha_aux[1] + fecha_aux[0].Remove(0, 2);
                    dt_itinerario.Rows.Add(new string[10] { iti_ida[0], iti_ida[1], iti_ida[2], fecha, iti_ida[4], iti_ida[5], iti_ida[6], iti_ida[7], iti_ida[8], iti_ida[9] });//lblFechaSalidaTab.Text
                }


                if (lblTipoRuta.Text == "RT")
                {
                    string[] aux_ida_v = lblItiVuelta.Text.Split('&');
                    for (int i = 1; i < aux_ida_v.Length; i++)
                    {

                        string[] iti_ida = aux_ida_v[i].Split('|');
                        string[] fecha_aux = iti_ida[3].ToString().Split('-');

                        string fecha = fecha_aux[2] + fecha_aux[1] + fecha_aux[0].Remove(0, 2);
                        dt_itinerario.Rows.Add(new string[10] { iti_ida[0], iti_ida[1], iti_ida[2], fecha, iti_ida[4], iti_ida[5], iti_ida[6], iti_ida[7], iti_ida[8], iti_ida[9] });//lblFechaSalidaTab.Text
                    }
                }



                List<itinerario_datos> itinerarioList = new List<itinerario_datos>();
                for (int i = 0; i < dt_itinerario.Rows.Count; i++)
                {
                    itinerario_datos item_itinerario = new itinerario_datos();
                    item_itinerario.origen = dt_itinerario.Rows[i]["origen"].ToString();
                    item_itinerario.destino = dt_itinerario.Rows[i]["destino"].ToString();
                    item_itinerario.hora = dt_itinerario.Rows[i]["hora"].ToString().Replace(":", "");
                    item_itinerario.fecha = dt_itinerario.Rows[i]["fecha"].ToString();
                    item_itinerario.clase = dt_itinerario.Rows[i]["clase"].ToString();
                    item_itinerario.carrier = dt_itinerario.Rows[i]["carrier"].ToString();
                    item_itinerario.numero_vuelo = dt_itinerario.Rows[i]["numero_vuelo"].ToString();
                    item_itinerario.tipo = dt_itinerario.Rows[i]["tipo"].ToString();
                    item_itinerario.leg = dt_itinerario.Rows[i]["leg"].ToString();
                    item_itinerario.ld = dt_itinerario.Rows[i]["ld"].ToString();
                    itinerarioList.Add(item_itinerario);
                }
                //0 dr["boardAirport"].ToString() + "|" +
                //1 dr["offAirport"].ToString() + "|" +
                //2 dr["depTime"].ToString() + "|" +
                //3 dr["depDate"].ToString()
                //4 dr["bookClass"].ToString() + "|" +
                //5 dr["operCompany"].ToString() + "|" +
                //6 dr["flightNumber"].ToString() + "|" +
                //7 "ida"
                //8 dr["leg"].ToString() + "|" +
                //9 dr["ld"].ToString() + "|" +
                //10 dr["gds1"].ToString() + "|" +
                //11 dr["moneda"].ToString() + "|" +
                //12 dr["precio"].ToString();
                //13 id_opcion
                //14 id_datos
                DBApi obj11 = new DBApi();
                Datos_sin_PNR datos1 = new Datos_sin_PNR
                {
                    gds = gds,
                    adultos = lblNroAdultos.Text,
                    senior = lblNroSeniors.Text,
                    infantes = lblNroInfante.Text,
                    menores = lblNroNinos.Text,
                    convenio_adt = "",
                    convenio_inf = "",
                    convenio_menor = "",
                    moneda = moneda,
                    id_session = "",
                    itinerario = itinerarioList
                };
                string json = JsonConvert.SerializeObject(datos1);
                dynamic respuesta = obj11.Post("http://20.39.32.111/api/GetPrecioSinPnr.php", json, "Basic MDQ4NjQwNjY4c3R6cmVycjg2Y2Q3MGE4OTVjZDlmYTowNHdlcndld2V3NjhzdHpyZXJyODZjZDcwYTg5NWNkOWZh=");
                ///////////AQUI DEVUELTE LAS REGLAS ///////////////////////////////////
                string respuestaJson = respuesta.ToString();

                precio_sin_pnr vuelos = new precio_sin_pnr();

                string json2 = JsonConvert.SerializeObject(vuelos);

                vuelos = JsonConvert.DeserializeObject<precio_sin_pnr>(respuestaJson);

                if (vuelos.error == "00")
                {
                    lblMonedaPasajero.Text = vuelos.datos.moneda;

                    lblTotalReservaPasajero.Text = vuelos.datos.monto_total.ToString();
                    lblMontoTotalReserva.Text = vuelos.datos.monto_total.ToString();
                    lblTotalImpuestosRes.Text = vuelos.datos.monto_total_impuestos.ToString();
                    lblTotalImpPasajeros.Text = vuelos.datos.monto_total_impuestos.ToString();
                    lblTotalImpRserva.Text = vuelos.datos.monto_total_impuestos.ToString();
                    lblTarifaBaseRes.Text = vuelos.datos.monto_total_sin_impuestos.ToString();
                    lblTarifaBasePasajeros.Text = vuelos.datos.monto_total_sin_impuestos.ToString();
                    lblTarifaBaseReserva.Text = vuelos.datos.monto_total_sin_impuestos.ToString();
                    string[] datos = LocalBD.PR_GET_FEE_WEB_ITINERARIO_ENVIO(operador, moneda, rblTipoVenta.SelectedValue, lblOrigen.Text, lblDestino.Text, lblTipoRuta.Text, total_pasajeros).Split('|');
                    lblFeeEmisionRes.Text = Math.Round(decimal.Parse(datos[2]), 2).ToString();
                    lblOtrosCargos.Text = Math.Round(decimal.Parse(datos[3]), 2).ToString();
                    lblFeeSZI.Text = Math.Round((decimal.Parse(datos[2]) / total_pasajeros), 2).ToString();
                    lblFeeBroker.Text = Math.Round((decimal.Parse(datos[3]) / total_pasajeros), 2).ToString();
                    lblTotalRes.Text = (double.Parse(datos[1]) + vuelos.datos.monto_total).ToString();
                    if (adultos > 0)
                    {

                        if (vuelos.datos.detalle.ADT != null)
                        {
                            lblAdultosPrecios.Text = "<strong>Total: " + vuelos.datos.detalle.ADT.monto_total_por_tipo_pax + "</strong> - Tarifa Base:" + vuelos.datos.detalle.ADT.monto_sin_impuestos_tipo_pax + " - Impuestos: " + vuelos.datos.detalle.ADT.monto_impuestos_tipo_pax;
                        }
                        else
                        {
                            lblAdultosPrecios.Text = "";
                        }

                    }
                    if (ninos > 0)
                    {
                        if (vuelos.datos.detalle.CHD != null)
                        {
                            lblNinosPrecios.Text = "<strong>Total: " + vuelos.datos.detalle.CHD.monto_total_por_tipo_pax + "</strong> - Tarifa Base:" + vuelos.datos.detalle.CHD.monto_sin_impuestos_tipo_pax + " - Impuestos: " + vuelos.datos.detalle.CHD.monto_impuestos_tipo_pax;
                        }
                        else
                        {
                            lblNinosPrecios.Text = "";
                        }


                    }
                    if (infantes > 0)
                    {
                        if (vuelos.datos.detalle.INF != null)
                        {
                            lblInfantePrecios.Text = "<strong>Total: " + vuelos.datos.detalle.INF.monto_total_por_tipo_pax + "</strong> - Tarifa Base:" + vuelos.datos.detalle.INF.monto_sin_impuestos_tipo_pax + " - Impuestos: " + vuelos.datos.detalle.INF.monto_impuestos_tipo_pax;
                        }
                        else
                        {
                            lblInfantePrecios.Text = "";
                        }




                    }
                    if (rblTipoVenta.SelectedItem.Text == "NORMAL")
                    {
                        panel_rango.Visible = true;
                        lblComisionDesde.Text = Math.Round(decimal.Parse(datos[4]), 2).ToString();
                        lblComisionHasta.Text = Math.Round(decimal.Parse(datos[5]), 2).ToString();

                    }
                    else
                    {
                        panel_rango.Visible = false;
                    }

                    Panel_total_desglose.Visible = true;
                    lblMsgGetPrecioSinPNR.Text = "";
                }
                else
                {
                    lblMsgGetPrecioSinPNR.Text = "Tarifario no disponible.";
                }
                //panel_seccion_vuelos.Visible = false;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_fun_genera_ganacias_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }

        }
        public void reinicio_combos()
        {
            lblItiVuelta.Text = "";
            lblItiIda.Text = "";
            //odsRutaInd.DataBind();
            ddlCabina.DataBind();
            //ddlDestino.DataBind();
            ddlLineArea.DataBind();
            //ddlOrigen.DataBind();
            ddlTurnos.DataBind();
            txtAdultos.Text = "1";
            txtNinos.Text = "0";
            txtInfante.Text = "0";
            txtSenior.Text = "0";
            lblDtSegmentos.Text = "";
            lblDtDatosAll.Text = "";
            lblDtDatosRTAll.Text = "";
            lblDtOpciones.Text = "";
            lblDtOpcionesRT.Text = "";
            lblDtSegmentosRT.Text = "";
            panel_ida.Visible = false;
            panel_vuelta.Visible = false;
            panel_total_res.Visible = false;
            lblAdultosPrecios.Text = "";
            lblNinosPrecios.Text = "";
            lblInfantePrecios.Text = "";
            lblSeniorPrecios.Text = "";
        }

        #endregion

        #region clases
        public class Pasajero
        {

            public string nombre { get; set; }
            public string apellido { get; set; }
            public string tipo_doc { get; set; }
            public string documento { get; set; }

            public string tipo_pax { get; set; }
            public string fecha_nacimiento { get; set; }

        }

        public class Itinerario
        {

            public string origen { get; set; }
            public string destino { get; set; }
            public string fecha { get; set; }
            public string clase { get; set; }
            public string carrier { get; set; }
            public string numero_vuelo { get; set; }
            public string ld { get; set; }

        }
        public class ReservasL
        {
            public string tourcode { get; set; }
            public string comision { get; set; }
            public string gds { get; set; }
            public string datosFacturacion { get; set; }
            public string email { get; set; }
            public string telefono { get; set; }
            public string origen { get; set; }
            public string destino { get; set; }
            public string moneda { get; set; }
            public string codigo_ff { get; set; }
            public string convenio_adt { get; set; }
            public string convenio_menor { get; set; }
            public string convenio_inf { get; set; }
            public List<Itinerario> itinerario_ida { get; set; }
            public List<Itinerario> itinerario_vuelta { get; set; }
            public List<Pasajero> pasajeros { get; set; }


            //    public List<Itinerario> itinerarios= new List<Itinerario>();

            //  public List<Pasajero> pasajeros=new List<Pasajero>();
        }
        public class Datos_sin_PNR
        {
            public string gds { get; set; }
            public string adultos { get; set; }
            public string senior { get; set; }
            public string infantes { get; set; }
            public string menores { get; set; }
            public string convenio_adt { get; set; }
            public string convenio_menor { get; set; }
            public string convenio_inf { get; set; }
            public string moneda { get; set; }
            public string id_session { get; set; }

            public List<itinerario_datos> itinerario = new List<itinerario_datos>();


        }
        public class Datos
        {
            public string gds { get; set; }
            public string adultos { get; set; }
            public string senior { get; set; }
            public string infante { get; set; }
            public string menor { get; set; }
            public string origen { get; set; }
            public string destino { get; set; }
            public string fecha_ida { get; set; }
            public string fecha_vuelta { get; set; }
            public string tipo_busqueda { get; set; }
            public string fechaFlexible { get; set; }
            public string vuelos_directos { get; set; }
            public string vuelos_incluyenequipaje { get; set; }
            public string tipo_cabina { get; set; }
            public string aerolinea { get; set; }
            public string hora_salida { get; set; }
            public string hora_regreso { get; set; }
            public string convenio_adt { get; set; }
            public string convenio_menor { get; set; }
            public string convenio_inf { get; set; }
            public string moneda { get; set; }
            public string id_session { get; set; }

        }
        public class itinerario_datos
        {
            public string origen { get; set; }
            public string destino { get; set; }
            public string hora { get; set; }
            public string fecha { get; set; }
            public string clase { get; set; }
            public string carrier { get; set; }
            public string numero_vuelo { get; set; }
            public string tipo { get; set; }
            public string leg { get; set; }
            public string ld { get; set; }

        }
        #endregion

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {

                lblPasajerosAux.Text = "";

                if (lblPasajerosAux.Text != "")
                {
                    DataTable dt_pasajeros = new DataTable();
                    if (dt_pasajeros.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        dt_pasajeros.Columns.Add("nro", typeof(string));
                        dt_pasajeros.Columns.Add("nombre", typeof(string));
                        dt_pasajeros.Columns.Add("apellido", typeof(string));
                        dt_pasajeros.Columns.Add("tipo_doc", typeof(string));
                        dt_pasajeros.Columns.Add("documento", typeof(string));
                        dt_pasajeros.Columns.Add("tipo_pax", typeof(string));
                        dt_pasajeros.Columns.Add("fecha_nacimiento", typeof(string));
                    }
                    string[] pasajeros_filas = lblPasajerosAux.Text.Split('|');
                    int i = 0;
                    for (i = 0; i < pasajeros_filas.Count() - 1; i++)
                    {
                        string[] pasajeros = pasajeros_filas[i].Split('&');
                        dt_pasajeros.Rows.Add(new string[7] { i.ToString(), pasajeros[0], pasajeros[1], pasajeros[2], pasajeros[3], pasajeros[4], pasajeros[5] });
                        // }
                    }
                    Repeater7.DataSource = dt_pasajeros;
                    Repeater7.DataBind();

                }
                lblCountSen.Text = lblNroSeniors.Text;
                lblCountAdl.Text = lblNroAdultos.Text;
                lblNinosCount.Text = lblNroNinos.Text;
                lblInfaneCount.Text = lblNroInfante.Text;
                if (lblCountSen.Text == "0")
                    panel_seniors.Visible = false;
                if (lblCountAdl.Text == "0")
                    Panel_adl.Visible = false;
                if (lblNinosCount.Text == "0")
                    Panel_chl.Visible = false;
                if (lblInfaneCount.Text == "0")
                    Panel_inf.Visible = false;

                panel_continuar_pasajero.Visible = false;
                btnAgregarInfante.Enabled = true;
                btnAgregarNino.Enabled = true;
                btnAgregarPasajero.Enabled = true;
                btnAgregarPasajeroSen.Enabled = true;

                if (lblCountSen.Text == "0")
                    if (lblCountAdl.Text == "0")
                        if (lblNinosCount.Text == "0")
                            if (lblInfaneCount.Text == "0")
                                panel_continuar_pasajero.Visible = true;

                MultiView1.ActiveViewIndex = 2;
                decimal FeeSZI, FeeBroker;
                FeeSZI = decimal.Parse(lblFeeSZI.Text);

                //if (txtComision.Text == "0" || txtComision.Text.Trim() == "")
                //{ FeeBroker = decimal.Parse(lblFeeBroker.Text.Replace(',', '.')); }
                //else { FeeBroker = decimal.Parse(txtComision.Text.Replace(',', '.')); }
                //lblFeeBrokerReserva.Text = FeeBroker.ToString().Replace(',', '.');
                //lblFeeBrokerPasjeros.Text = FeeBroker.ToString().Replace(',', '.');
                //lblFeeSZIReserva.Text = FeeSZI.ToString().Replace(',', '.');
                //lblFeeSZIPasajeros.Text = FeeSZI.ToString().Replace(',', '.');

                lblTotalReservaPasajero.Text = lblTotalRes.Text;
                //if (txtComision.Text == "0" || txtComision.Text.Trim() == "")
                //{ FeeBroker = decimal.Parse(lblFeeBroker.Text); }
                //else { FeeBroker = decimal.Parse(txtComision.Text); }
                lblOtrosCargosPasajeros.Text = lblOtrosCargos.Text;
                lblFeeEmisionPasajeros.Text = lblFeeEmisionRes.Text;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_continuar_resumen" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }


        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            //MultiView1.ActiveViewIndex = 1;


            lblNroAdultos.Text=txtAdultos.Text;
            lblNroNinos.Text = txtNinos.Text;
            lblNroInfante.Text = txtInfante.Text;
            lblNroSeniors.Text = txtSenior.Text;
            lblAviso.Text = "";
            int checkIda = 0;
            string toolTipIda = "";
            int checkVuelta = 0;
            string toolTipVuelta = "";

            foreach (RepeaterItem ri1 in Repeater1.Items)
            {
                Repeater rep2 = (Repeater)ri1.FindControl("Repeater2");
                foreach (RepeaterItem ri2 in rep2.Items)
                {
                    CheckBox cbIda = (CheckBox)ri2.FindControl("cbElegirIda");
                    if (cbIda.Checked)
                    {
                        toolTipIda = cbIda.ToolTip;
                        checkIda += 1;
                    }
                }
            }

            if (lblTipoRuta.Text == "RT")
            {
                foreach (RepeaterItem ri1 in Repeater1.Items)
                {
                    Repeater rep5 = (Repeater)ri1.FindControl("Repeater5");
                    foreach (RepeaterItem ri5 in rep5.Items)
                    {
                        CheckBox cbVuelta = (CheckBox)ri5.FindControl("cbElegirVuelta");
                        if (cbVuelta.Checked)
                        {
                            toolTipVuelta = cbVuelta.ToolTip;
                            checkVuelta += 1;
                        }
                    }
                }
            }

            if (lblTipoRuta.Text == "OW")
            {
                if (checkIda > 0 )
                {
                    lblItiVuelta.Text = "";
                    lblItiIda.Text = "";
                    Button obj = (Button)sender;
                    string[] datos1 = toolTipIda.Split('&');
                    lblItiIda.Text = toolTipIda;



                    //aux + "&" +
                    //0 dr["boardAirport"].ToString() + "|" +
                    //1 dr["offAirport"].ToString() + "|" +
                    //2 dr["depTime"].ToString() + "|" +
                    //3 dr["depDate"].ToString()  + "|" +
                    //4 dr["bookClass"].ToString() + "|" +
                    //5 dr["operCompany"].ToString() + "|" +
                    //6 dr["flightNumber"].ToString() + "|" +
                    //7 "ida"     + "|" +
                    //8 dr["leg"].ToString() + "|" +
                    //9 dr["ld"].ToString() + "|" +
                    //10 dr["gds1"].ToString() + "|" +
                    //11 dr["moneda"].ToString() + "|" +
                    //12 dr["precio"].ToString()   + "|" +
                    //13 dr["id_opcion"].ToString() + "|" +
                    //14 dr["id_datos"].ToString() + "|" +
                    //15 dr["duracion"].ToString() + "|" +
                    //16 dr["hora_llegada"].ToString() + "|" +
                    //17 dr["ArrivalDate"].ToString() + "|" +
                    //18 dr["lugres_disponibles"].ToString();
                    DataTable dt_ida = new DataTable();
                    dt_ida.Columns.Add("boardAirport", typeof(string));
                    dt_ida.Columns.Add("offAirport", typeof(string));
                    dt_ida.Columns.Add("depTime", typeof(string));
                    dt_ida.Columns.Add("depDate", typeof(string));
                    dt_ida.Columns.Add("bookClass", typeof(string));
                    dt_ida.Columns.Add("operCompany", typeof(string));
                    dt_ida.Columns.Add("flightNumber", typeof(string));
                    dt_ida.Columns.Add("ida", typeof(string));
                    dt_ida.Columns.Add("leg", typeof(string));
                    dt_ida.Columns.Add("ld", typeof(string));
                    dt_ida.Columns.Add("gds1", typeof(string));
                    dt_ida.Columns.Add("moneda", typeof(string));
                    dt_ida.Columns.Add("precio", typeof(string));
                    dt_ida.Columns.Add("id_opcion", typeof(string));
                    dt_ida.Columns.Add("id_datos", typeof(string));
                    dt_ida.Columns.Add("duracion", typeof(string));
                    dt_ida.Columns.Add("hora_llegada", typeof(string));
                    dt_ida.Columns.Add("ArrivalDate", typeof(string));
                    dt_ida.Columns.Add("lugres_disponibles", typeof(string));
                    string[] datos = datos1[1].Split('|');

                    int ida = 0;
                    for (ida = 1; ida < datos1.Length; ida++)
                    {

                        string[] datosIda = datos1[ida].Split('|');
                        lblGds.Text = datosIda[10];
                        DataTable DT_dom = new DataTable();
                        DT_dom = Dominios.Lista("AEROLINEA");
                        if (DT_dom.Rows.Count > 0)
                        {
                            foreach (DataRow dr in DT_dom.Rows)
                            {
                                if (dr["codigo"].ToString() == datosIda[5])
                                    lblAreolineaNombResIda.Text = dr["descripcion"].ToString() + " (" + datos[5] + ")";
                            }
                        }
                        //if (ida == 1)
                        //{
                        //    lblOrigenIResIda.Text = datosIda[0];
                        //    lblNroVueloIResIda.Text = datosIda[6];
                        //    lblClaseIResIda.Text = datosIda[4];
                        //    lblFechaSalidaIResIda.Text = datosIda[3];
                        //    lblHoraSalidaIResIda.Text = datosIda[2];
                        //}
                        //lblDestinoVResIda.Text = datosIda[1];
                        //lblNroVueloVResIda.Text = datosIda[6];
                        //lblClaseVResIda.Text = datosIda[4];
                        //lblFechaLlegadaVResIda.Text = datosIda[3];
                        //lblHoraLlegadaVResIda.Text = datosIda[2];
                        dt_ida.Rows.Add(new string[18] { datosIda[0], datosIda[1], datosIda[2], datosIda[3], datosIda[4],
                    datosIda[5], datosIda[6], datosIda[7], datosIda[8], datosIda[9],datosIda[10],datosIda[11],
                    datosIda[12],datosIda[13],datosIda[14],datosIda[15],datosIda[16],datosIda[17] });//lblFechaSalidaTab.Text
                    }

                    Repeater9.DataSource = dt_ida;
                    Repeater9.DataBind();


                    string cadena = "";
                    lblDatosVueloIda.Text = datos[0] + "|" + datos[1] + "|" + datos[2] + "|" + datos[3] + "|" + datos[4] + "|" + datos[5] + "|" + datos[6] + "|" + datos[7] + "|" + datos[8] + "|" + datos[9] + "|" + datos[10] + "|" + datos[11] + "|" + datos[12] + "|" + datos[13] + "|" + datos[14];
                    cadena = datos[0] + "|" + datos[1] + "|" + datos[2] + "|" + datos[3] + "|" + datos[4] + "|" + datos[5] + "|" + datos[6] + "|" + datos[7] + "|" + datos[8] + "|" + datos[9] + "|" + datos[10] + "|" + datos[11] + "|" + datos[12] + "|" + datos[12] + "|" + datos[13] + "|" + datos[14];
                    //lblOrgDestIdaRes.Text = lblOrigen.Text + " - " + lblDestino.Text;
                    //lblHorarioIdaRes.Text = datos[2] + " - " + datos[3];
                    //lblVueloIdaRes.Text = "Vuelo " + datos[6] + " - " + datos[4] + " - " + datos[5];
                    lblMonedaIda.Text = datos[11];


                    lblTotalImpuestosRes.Text = "0";
                    lblTarifaBaseRes.Text = "0";
                    panel_ida.Visible = true;
                    panel_total_res.Visible = true;
                    panel_ida.Visible = true;
                    panel_total_res.Visible = true;

                    GenerarGanancias(cadena);
                    panel_continuar.Visible = true;
                    btnContinuar.Text = "Continuar";

                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    lblAviso.Text = "Debe seleccionar una ida.";
                }
            }
            else
            {
                if (checkIda > 0 && checkVuelta > 0)
                {
                    lblItiVuelta.Text = "";
                    lblItiIda.Text = "";
                    Button obj = (Button)sender;
                    string[] datos1 = toolTipIda.Split('&');
                    lblItiIda.Text = toolTipIda;



                    //aux + "&" +
                    //0 dr["boardAirport"].ToString() + "|" +
                    //1 dr["offAirport"].ToString() + "|" +
                    //2 dr["depTime"].ToString() + "|" +
                    //3 dr["depDate"].ToString()  + "|" +
                    //4 dr["bookClass"].ToString() + "|" +
                    //5 dr["operCompany"].ToString() + "|" +
                    //6 dr["flightNumber"].ToString() + "|" +
                    //7 "ida"     + "|" +
                    //8 dr["leg"].ToString() + "|" +
                    //9 dr["ld"].ToString() + "|" +
                    //10 dr["gds1"].ToString() + "|" +
                    //11 dr["moneda"].ToString() + "|" +
                    //12 dr["precio"].ToString()   + "|" +
                    //13 dr["id_opcion"].ToString() + "|" +
                    //14 dr["id_datos"].ToString() + "|" +
                    //15 dr["duracion"].ToString() + "|" +
                    //16 dr["hora_llegada"].ToString() + "|" +
                    //17 dr["ArrivalDate"].ToString() + "|" +
                    //18 dr["lugres_disponibles"].ToString();
                    DataTable dt_ida = new DataTable();
                    dt_ida.Columns.Add("boardAirport", typeof(string));
                    dt_ida.Columns.Add("offAirport", typeof(string));
                    dt_ida.Columns.Add("depTime", typeof(string));
                    dt_ida.Columns.Add("depDate", typeof(string));
                    dt_ida.Columns.Add("bookClass", typeof(string));
                    dt_ida.Columns.Add("operCompany", typeof(string));
                    dt_ida.Columns.Add("flightNumber", typeof(string));
                    dt_ida.Columns.Add("ida", typeof(string));
                    dt_ida.Columns.Add("leg", typeof(string));
                    dt_ida.Columns.Add("ld", typeof(string));
                    dt_ida.Columns.Add("gds1", typeof(string));
                    dt_ida.Columns.Add("moneda", typeof(string));
                    dt_ida.Columns.Add("precio", typeof(string));
                    dt_ida.Columns.Add("id_opcion", typeof(string));
                    dt_ida.Columns.Add("id_datos", typeof(string));
                    dt_ida.Columns.Add("duracion", typeof(string));
                    dt_ida.Columns.Add("hora_llegada", typeof(string));
                    dt_ida.Columns.Add("ArrivalDate", typeof(string));
                    dt_ida.Columns.Add("lugres_disponibles", typeof(string));
                    string[] datos = datos1[1].Split('|');

                    int ida = 0;
                    for (ida = 1; ida < datos1.Length; ida++)
                    {

                        string[] datosIda = datos1[ida].Split('|');
                        lblGds.Text = datosIda[10];
                        DataTable DT_dom1 = new DataTable();
                        DT_dom1 = Dominios.Lista("AEROLINEA");
                        if (DT_dom1.Rows.Count > 0)
                        {
                            foreach (DataRow dr in DT_dom1.Rows)
                            {
                                if (dr["codigo"].ToString() == datosIda[5])
                                    lblAreolineaNombResIda.Text = dr["descripcion"].ToString() + " (" + datos[5] + ")";
                            }
                        }
                        //if (ida == 1)
                        //{
                        //    lblOrigenIResIda.Text = datosIda[0];
                        //    lblNroVueloIResIda.Text = datosIda[6];
                        //    lblClaseIResIda.Text = datosIda[4];
                        //    lblFechaSalidaIResIda.Text = datosIda[3];
                        //    lblHoraSalidaIResIda.Text = datosIda[2];
                        //}
                        //lblDestinoVResIda.Text = datosIda[1];
                        //lblNroVueloVResIda.Text = datosIda[6];
                        //lblClaseVResIda.Text = datosIda[4];
                        //lblFechaLlegadaVResIda.Text = datosIda[3];
                        //lblHoraLlegadaVResIda.Text = datosIda[2];
                        dt_ida.Rows.Add(new string[18] { datosIda[0], datosIda[1], datosIda[2], datosIda[3], datosIda[4],
                    datosIda[5], datosIda[6], datosIda[7], datosIda[8], datosIda[9],datosIda[10],datosIda[11],
                    datosIda[12],datosIda[13],datosIda[14],datosIda[15],datosIda[16],datosIda[17] });//lblFechaSalidaTab.Text
                    }

                    Repeater9.DataSource = dt_ida;
                    Repeater9.DataBind();


                    string cadena = "";
                    lblDatosVueloIda.Text = datos[0] + "|" + datos[1] + "|" + datos[2] + "|" + datos[3] + "|" + datos[4] + "|" + datos[5] + "|" + datos[6] + "|" + datos[7] + "|" + datos[8] + "|" + datos[9] + "|" + datos[10] + "|" + datos[11] + "|" + datos[12] + "|" + datos[13] + "|" + datos[14];
                    cadena = datos[0] + "|" + datos[1] + "|" + datos[2] + "|" + datos[3] + "|" + datos[4] + "|" + datos[5] + "|" + datos[6] + "|" + datos[7] + "|" + datos[8] + "|" + datos[9] + "|" + datos[10] + "|" + datos[11] + "|" + datos[12] + "|" + datos[12] + "|" + datos[13] + "|" + datos[14];
                    //lblOrgDestIdaRes.Text = lblOrigen.Text + " - " + lblDestino.Text;
                    //lblHorarioIdaRes.Text = datos[2] + " - " + datos[3];
                    //lblVueloIdaRes.Text = "Vuelo " + datos[6] + " - " + datos[4] + " - " + datos[5];
                    lblMonedaIda.Text = datos[11];


                    lblTotalImpuestosRes.Text = "0";
                    lblTarifaBaseRes.Text = "0";
                    panel_ida.Visible = true;
                    panel_total_res.Visible = true;
                    panel_ida.Visible = true;
                    panel_total_res.Visible = true;

                    lblItiVuelta.Text = toolTipVuelta;
                    string[] datos2 = toolTipVuelta.Split('&');


                    

                    
                    //aux + "&" +
                    //0 dr["boardAirport"].ToString() + "|" +
                    //1 dr["offAirport"].ToString() + "|" +
                    //2 dr["depTime"].ToString() + "|" +
                    //3 dr["depDate"].ToString()  + "|" +
                    //4 dr["bookClass"].ToString() + "|" +
                    //5 dr["operCompany"].ToString() + "|" +
                    //6 dr["flightNumber"].ToString() + "|" +
                    //7 "ida"     + "|" +
                    //8 dr["leg"].ToString() + "|" +
                    //9 dr["ld"].ToString() + "|" +
                    //10 dr["gds1"].ToString() + "|" +
                    //11 dr["moneda"].ToString() + "|" +
                    //12 dr["precio"].ToString()   + "|" +
                    //13 dr["id_opcion"].ToString() + "|" +
                    //14 dr["id_datos"].ToString() + "|" +
                    //15 dr["duracion"].ToString() + "|" +
                    //16 dr["hora_llegada"].ToString() + "|" +
                    //17 dr["ArrivalDate"].ToString() + "|" +
                    //18 dr["lugres_disponibles"].ToString();
                    DataTable dt_vuelta = new DataTable();
                    dt_vuelta.Columns.Add("boardAirport", typeof(string));
                    dt_vuelta.Columns.Add("offAirport", typeof(string));
                    dt_vuelta.Columns.Add("depTime", typeof(string));
                    dt_vuelta.Columns.Add("depDate", typeof(string));
                    dt_vuelta.Columns.Add("bookClass", typeof(string));
                    dt_vuelta.Columns.Add("operCompany", typeof(string));
                    dt_vuelta.Columns.Add("flightNumber", typeof(string));
                    dt_vuelta.Columns.Add("ida", typeof(string));
                    dt_vuelta.Columns.Add("leg", typeof(string));
                    dt_vuelta.Columns.Add("ld", typeof(string));
                    dt_vuelta.Columns.Add("gds1", typeof(string));
                    dt_vuelta.Columns.Add("moneda", typeof(string));
                    dt_vuelta.Columns.Add("precio", typeof(string));
                    dt_vuelta.Columns.Add("id_opcion", typeof(string));
                    dt_vuelta.Columns.Add("id_datos", typeof(string));
                    dt_vuelta.Columns.Add("duracion", typeof(string));
                    dt_vuelta.Columns.Add("hora_llegada", typeof(string));
                    dt_vuelta.Columns.Add("ArrivalDate", typeof(string));
                    dt_vuelta.Columns.Add("lugres_disponibles", typeof(string));

                    string[] datos3 = datos2[1].Split('|');

                    int vuelta = 0;
                    for (vuelta = 1; vuelta < datos2.Length; vuelta++)
                    {
                        string[] datosIda = datos2[vuelta].Split('|');
                        dt_vuelta.Rows.Add(new string[18] { datosIda[0], datosIda[1], datosIda[2], datosIda[3], datosIda[4],
                    datosIda[5], datosIda[6], datosIda[7], datosIda[8], datosIda[9],datosIda[10],datosIda[11],
                    datosIda[12],datosIda[13],datosIda[14],datosIda[15],datosIda[16],datosIda[17] });//lblFechaSalidaTab.Text
                    }
                    Repeater10.DataSource = dt_vuelta;
                    Repeater10.DataBind();
                    DataTable DT_dom = new DataTable();
                    DT_dom = Dominios.Lista("AEROLINEA");
                    if (DT_dom.Rows.Count > 0)
                    {
                        foreach (DataRow dr in DT_dom.Rows)
                        {
                            if (dr["codigo"].ToString() == datos[5])
                                lblAreolineaNombResVuelta.Text = dr["descripcion"].ToString() + " (" + datos[5] + ")";
                        }
                    }
                    lblTotalRes.Text = datos[12];
                    lblTotalImpuestosRes.Text = "0";
                    lblTarifaBaseRes.Text = "0";
                    panel_vuelta.Visible = true;
                    panel_ida.Visible = true;
                    panel_total_res.Visible = true;

                    GenerarGanancias(cadena);
                    panel_continuar.Visible = true;
                    btnContinuar.Text = "Continuar";

                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    lblAviso.Text = "Debe seleccionar una ida y un retorno.";
                }
            }

            
        }

        protected void btnVerVuelos_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnContinuarPasajero_Click(object sender, EventArgs e)
        {
            try
            {
                //string[] gds = Session["datos_vuelo_ida"].ToString().Split('|');
                //string pasajeros = "";
                //foreach (DataRow dr in dt_pasajeros.Rows)
                //{
                //    pasajeros = pasajeros + dr["nombre"].ToString() + "&" + dr["apellido"].ToString() + "&" + dr["tipo_doc"].ToString() + "&" + dr["documento"].ToString() + "&" + dr["tipo_pax"].ToString() + "&" + dr["fecha_nacimiento"].ToString() + "|";
                //}
                string datos_facturacion = txtRazonSocial.Text + "|" + txtNit.Text + "|" + txtEmailTit.Text + "|" + txtTelefonoTit.Text + "|" + "";
                decimal FeeSZI, FeeBroker;
                FeeSZI = decimal.Parse(lblFeeSZI.Text);

                if (txtComision.Text == "0" || txtComision.Text.Trim() == "")
                { FeeBroker = decimal.Parse(lblFeeBroker.Text.Replace(',', '.')); }
                else { FeeBroker = decimal.Parse(txtComision.Text.Replace(',', '.')); }

                //if (txtComision.Text == "0" || txtComision.Text.Trim() == "")
                //{ FeeBroker = decimal.Parse(lblFeeBroker.Text); }
                //else { FeeBroker = decimal.Parse(txtComision.Text); }

                lblMontoTotalReserva.Text = lblTotalReservaPasajero.Text;
                lblMonedaReserva.Text = lblMonedaPasajero.Text;
                lblTarifaBaseReserva.Text = lblTarifaBasePasajeros.Text;
                lblTotalImpRserva.Text = lblTotalImpPasajeros.Text;
                lblFeeEmisionReserva.Text = lblFeeEmisionPasajeros.Text;
                lblOtrosCargosReserva.Text = lblOtrosCargosPasajeros.Text;

                //FeeSZI = decimal.Parse(lblFeeEmisionReserva.Text.Replace(",","."));
                //FeeBroker = decimal.Parse(lblOtrosCargos.Text.Replace(',', '.'));
                //FeeSZI = decimal.Parse(lblFeeEmisionReserva.Text);
                //FeeBroker = decimal.Parse(lblOtrosCargos.Text);
                string securitytoken = "TipoVenta:" + rblTipoVenta.SelectedValue + "|feeSZI:" + Math.Round(FeeSZI, 2) + "|feeBroker:" + Math.Round(FeeBroker, 2) + "|gds:" + lblGds.Text;

                MultiView1.ActiveViewIndex = 3;





                lblUsuario.Text = Session["usuario"].ToString();

                /////////////DATOS UTILIZADOS PARA LA RESERVA//////////////////////////

                DBApi obj = new DBApi();
                List<Pasajero> pas = new List<Pasajero>();
                string[] pasajeros_filas = lblPasajerosAux.Text.Split('|');
                int i = 0;
                DataTable dt_pasajeros = new DataTable();
                if (dt_pasajeros.Rows.Count > 0)
                {
                }
                else
                {
                    dt_pasajeros.Columns.Add("nombre", typeof(string));
                    dt_pasajeros.Columns.Add("apellido", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_doc", typeof(string));
                    dt_pasajeros.Columns.Add("documento", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_pax", typeof(string));
                    dt_pasajeros.Columns.Add("fecha_nacimiento", typeof(string));
                }
                for (i = 0; i < pasajeros_filas.Count() - 1; i++)
                {
                    string[] pasajeros = pasajeros_filas[i].Split('&');
                    //int j = 0;
                    //for (j = 0; j < pasajeros_filas.Count(); j++)
                    //{
                    Pasajero obj_p = new Pasajero();
                    obj_p.nombre = pasajeros[0];
                    obj_p.apellido = pasajeros[1];
                    obj_p.tipo_doc = pasajeros[2];
                    obj_p.documento = pasajeros[3];
                    obj_p.tipo_pax = pasajeros[4];
                    obj_p.fecha_nacimiento = pasajeros[5];
                    pas.Add(obj_p);

                    dt_pasajeros.Rows.Add(new string[6] { pasajeros[0], pasajeros[1], pasajeros[2], pasajeros[3], pasajeros[4], pasajeros[5] });
                    // }
                }



                Repeater8.DataSource = dt_pasajeros;
                Repeater8.DataBind();

                List<Itinerario> it_i = new List<Itinerario>();
                List<Itinerario> it_v = new List<Itinerario>();


                //DATOS INICIALES
                //0 "gds": "A1",
                //1 "adultos": "1",
                //2 "senior": "0",
                //3 "infante": "0",
                //4 "menor":"0",
                //5 "origen": "LPB",
                //6 "destino":"ASU",
                //7 "fecha_ida":"170222",
                //8 "fecha_vuelta":"100322",
                //9 "tipo_busqueda":"OW", 
                //10 "fechaFexible":"0",
                //11 "vuelos_directos":"0",
                //12 "vuelos_incluyenequipaje":"0",
                //13 "tipo_cabina":"Business",
                //14 "aerolinea":"",
                //15 "hora_salida":"",
                //16 "hora_regreso":"",
                //17 "convenio_adt":"",
                //18 "convenio_menor":"",
                //19 "convenio_inf":"",
                //20 "moneda": "BOB",
                //21 "id_session":"111111"
                //22 "ORIGEN_IDA"
                //23 "DESCTINO_VUELTA"



                lblIdaTitulo.Text = "IDA: " + lblOrigenDes.Text + " - " + lblDestinoDes.Text;
                lblVueltaTitulo.Text = "VUELTA: " + lblDestinoDes.Text + " - " + lblOrigenDes.Text;
                string[] fecha_aux = hfFechaSalida.Value.Split('-');
                string fecha = fecha_aux[2] + fecha_aux[1] + fecha_aux[0].Remove(0, 2);

                ///VERIFICAR LA FECHA DEL SERVIDOR FORMATO
                //ACTUAL SERVIDOR FINAL: string fecha_ida = fecha_aux[1] + "/" + fecha_aux[2] + "/" + fecha_aux[0].Remove(0, 2);
                //MAQUINA DE DESARROLLO: string fecha_ida = fecha_aux[2]+"/" + fecha_aux[1] +"/"+ fecha_aux[0].Remove(0, 2);
                string fecha_ida = fecha_aux[1] + "/" + fecha_aux[2] + "/" + fecha_aux[0].Remove(0, 2);


                //0 Eval("boardAirport") +"|"+
                //1 Eval("offAirport")+"|"+
                //2 Eval("depDate")+"|"+
                //3 Eval("depTime")+"|"+
                //4 Eval("ArrivalDate")+"|"+
                //5 Eval("hora_llegada")+"|"+
                //6 Eval("duracion")+"|"+
                //7 Eval("flightNumber")+"|"+
                //8 Eval("bookClass")+"|"+
                //9 Eval("precio")+"|"+
                //10 Eval("marketCompany") + "|" +
                //11 Eval("segment") %>'
                //12 Eval("leg") %>'

                string[] datos_ida = lblDatosVueloIda.Text.Split('|');
                string[] datos_vuelta = lblDatosVueloIda.Text.Split('|');
                //dt_itinerario.Columns.Add("origen", typeof(string));0
                //dt_itinerario.Columns.Add("destino", typeof(string));1
                //dt_itinerario.Columns.Add("hora", typeof(string));2
                //dt_itinerario.Columns.Add("fecha", typeof(string));3
                //dt_itinerario.Columns.Add("clase", typeof(string));4
                //dt_itinerario.Columns.Add("carrier", typeof(string))5;
                //dt_itinerario.Columns.Add("numero_vuelo", typeof(string));6
                //dt_itinerario.Columns.Add("tipo", typeof(string));7
                //dt_itinerario.Columns.Add("leg", typeof(string));8
                //dt_itinerario.Columns.Add("ld", typeof(string));9
                string[] aux_ida = lblItiIda.Text.Split('&');

                string aerolinea = "";
                for (int x = 1; x < aux_ida.Length; x++)
                {
                    Itinerario obj_i = new Itinerario();
                    string[] iti_ida = aux_ida[x].Split('|');
                    string[] fecha_aux1 = iti_ida[3].ToString().Split('-');

                    string fecha1 = fecha_aux1[2] + fecha_aux1[1] + fecha_aux1[0].Remove(0, 2);
                    obj_i.origen = iti_ida[0];
                    obj_i.destino = iti_ida[1];
                    obj_i.fecha = fecha1;
                    obj_i.clase = iti_ida[4];
                    obj_i.carrier = iti_ida[5];
                    obj_i.numero_vuelo = iti_ida[6];
                    obj_i.ld = iti_ida[9];
                    it_i.Add(obj_i);
                    if (x == 1)
                    {
                        aerolinea = "|aerolinea:" + iti_ida[5];
                    }
                    //dt_itinerario.Rows.Add(new string[10] { iti_ida[0], iti_ida[1], iti_ida[2], fecha, iti_ida[4], iti_ida[5], iti_ida[6], iti_ida[7], iti_ida[8], iti_ida[9] });//lblFechaSalidaTab.Text
                }
                //dt_itinerario.Columns.Add("origen", typeof(string));0
                //dt_itinerario.Columns.Add("destino", typeof(string));1
                //dt_itinerario.Columns.Add("hora", typeof(string));2
                //dt_itinerario.Columns.Add("fecha", typeof(string));3
                //dt_itinerario.Columns.Add("clase", typeof(string));4
                //dt_itinerario.Columns.Add("carrier", typeof(string))5;
                //dt_itinerario.Columns.Add("numero_vuelo", typeof(string));6
                //dt_itinerario.Columns.Add("tipo", typeof(string));7
                //dt_itinerario.Columns.Add("leg", typeof(string));8
                //dt_itinerario.Columns.Add("ld", typeof(string));9




                string origen_vuelta, total_pag_vuelta, destino_vuelta, fecha_vuelta, clase_vuelta, carrier_vuelta, nvuelo_vuelta;
                origen_vuelta = "";
                destino_vuelta = "";
                fecha_vuelta = "01/01/3000";
                clase_vuelta = "";
                carrier_vuelta = "";
                nvuelo_vuelta = "";
                total_pag_vuelta = "";
                if (lblTipoRuta.Text == "RT")
                {
                    string[] datos_vuelo_retorno_aux = lblItiVuelta.Text.Split('&');
                    string[] datos_vuelo_retorno = datos_vuelo_retorno_aux[1].Split('|');
                    string[] fecha_aux_ret = hfFechaRetorno.Value.Split('-');

                    string fecha_ret = fecha_aux_ret[2] + fecha_aux_ret[1] + fecha_aux_ret[0].Remove(0, 2);


                    string[] aux_vuelta = lblItiVuelta.Text.Split('&');
                    for (int z = 1; z < aux_vuelta.Length; z++)
                    {
                        Itinerario obj_ir = new Itinerario();
                        string[] iti_vuelta = aux_vuelta[z].Split('|');
                        string[] fecha_aux2 = iti_vuelta[3].ToString().Split('-');

                        string fecha2 = fecha_aux2[2] + fecha_aux2[1] + fecha_aux2[0].Remove(0, 2);
                        obj_ir.origen = iti_vuelta[0];
                        obj_ir.destino = iti_vuelta[1];
                        obj_ir.fecha = fecha2;
                        obj_ir.clase = iti_vuelta[4];
                        obj_ir.carrier = iti_vuelta[5];
                        obj_ir.numero_vuelo = iti_vuelta[6];
                        obj_ir.ld = iti_vuelta[9];
                        it_v.Add(obj_ir);
                        //dt_itinerario.Rows.Add(new string[10] { iti_vuelta[0], iti_vuelta[1], iti_vuelta[2], fecha, iti_vuelta[4], iti_vuelta[5], iti_vuelta[6], iti_vuelta[7], iti_vuelta[8], iti_vuelta[9] });//lblFechaSalidaTab.Text
                    }
                    origen_vuelta = datos_vuelo_retorno[0];
                    destino_vuelta = datos_vuelo_retorno[1];
                    fecha_vuelta = datos_vuelo_retorno[3];
                    clase_vuelta = datos_vuelo_retorno[4];
                    carrier_vuelta = datos_vuelo_retorno[5];
                    nvuelo_vuelta = datos_vuelo_retorno[6];
                    total_pag_vuelta = lblTotalPagarFinal.Text;
                    //obj_ir.origen = datos_vuelo_retorno[0];
                    //obj_ir.destino = datos_vuelo_retorno[1];
                    //obj_ir.fecha = fecha_ret;
                    //obj_ir.clase = datos_vuelo_retorno[8];
                    //obj_ir.carrier = datos_vuelo_retorno[10];
                    //obj_ir.numero_vuelo = datos_vuelo_retorno[7];
                    //obj_ir.ld = "";
                    //it_v.Add(obj_ir);



                }

                //0 txtRazonSocial.Text + "|" +
                //1 txtNit.Text + "|" +
                //2 txtEmailTit.Text + "|" +
                //3 txtTelefonoTit.Text + "|" +
                //4 txtCodFrec.Text;
                string[] datos_fac = datos_facturacion.Split('|');

                //      Session["datos_reserva"] =
                //      1 lblAdultosResumen.Text + "|" +
                //      2 lblNinosResumen.Text + "|" +
                //      3 lblInfanteResumen.Text + "|" +
                //      4 lblFechaIdaRes.Text + "|" +
                //      5 lblOrgDestIdaRes.Text + "|" +
                //      6 lblHorarioIdaRes.Text + "|" +
                //      7 lblVueloIdaRes.Text + "|" +
                //      8 lblTotalRes.Text + "|" +
                //      9 lblTarifaBaseRes.Text + "|" +
                //      10 lblTotalImpuestosRes.Text + "|" +
                //      11 lblGananciaRes.Text + "|" +
                //      12 lblIdaTitulo.Text
                //      13 lblOrgDestVueltaRes.Text + "|" +
                //      14 lblHorarioVueltaRes.Text + "|" +
                //      15 lblVueloVueltaRes.Text + "|" +
                //      16 lblVueltaTitulo.Text;
                //string[] datos_res = Session["datos_reserva"].ToString().Split('|');

                string comision = LocalBD.PR_GET_FM(datos_ida[5], datos_ida[4], clase_vuelta, lblOrigen.Text, lblDestino.Text, decimal.Parse(lblTotalRes.Text.Replace(",", ".")), decimal.Parse(lblTotalRes.Text.Replace(",", ".")), dt_pasajeros.Rows.Count);

                lblComisionPasajeros.Text = comision;
                lblComisionReserva.Text = comision;

                ReservasL obj_r = new ReservasL();
                {

                    obj_r.tourcode = "AAAAAA";
                    obj_r.comision = comision.Replace(',', '.');
                    obj_r.gds = lblGds.Text;
                    obj_r.datosFacturacion = datos_fac[1] + " " + datos_fac[0];
                    obj_r.email = datos_fac[2];
                    obj_r.telefono = datos_fac[3];
                    obj_r.origen = lblOrigenDes.Text;
                    obj_r.destino = lblDestinoDes.Text;
                    obj_r.moneda = lblMoneda.Text;
                    obj_r.codigo_ff = datos_fac[4];
                    obj_r.convenio_adt = "";
                    obj_r.convenio_inf = "";
                    obj_r.convenio_menor = "";
                    obj_r.itinerario_ida = it_i;
                    obj_r.itinerario_vuelta = it_v;
                    obj_r.pasajeros = pas;

                }

                string json = JsonConvert.SerializeObject(obj_r);
                dynamic respuesta = obj.Post("http://20.39.32.111/api/GetReserva.php", json, "Basic MDQ4NjQwNjY4c3R6cmVycjg2Y2Q3MGE4OTVjZDlmYTowNHdlcndld2V3NjhzdHpyZXJyODZjZDcwYTg5NWNkOWZh");


                string respuestaJson = respuesta.ToString();
                //string error = respuesta.First().Error.ToString();
                if (lblGds.Text.ToUpper() == "KIU")
                {
                    Reservas_kiu.Application respuesta_res = new Reservas_kiu.Application();
                    respuesta_res = JsonConvert.DeserializeObject<Reservas_kiu.Application>(respuestaJson);
                    if (respuesta_res.error == "00")
                    {
                        //MultiView1.ActiveViewIndex = 6;
                        txtPNR.Text = respuesta_res.datos.pnr;
                        lblMoneda.Text = respuesta_res.datos.moneda;

                        string[] fechHoraLim = respuesta_res.datos.fecha_limite_emision.Split(' ');
                        string[] fechLim = fechHoraLim[0].Split('-');
                        lblTiempoLimite.Text = "HORA: " + fechHoraLim[1] + " - " + fechLim[2] + " de " + Nombre_mes(int.Parse(fechLim[1])) + ", " + fechLim[0];
                        lblTotalPagarFinal.Text = respuesta_res.datos.total_acobrar.ToString();
                        //lblMonedaFinal.Text = respuesta_res.datos.moneda;
                        //lblSaldoCuenta.Text = "2500";
                        //lblEmail.Text = datos_fac[2];


                        string[] hora_limite = respuesta_res.datos.fecha_limite_emision.Split(' ');
                        string[] fecha_lim_aux = respuesta_res.datos.fecha_limite_emision.Split('-');
                        string[] dia_aux = fecha_lim_aux[2].Split(' ');
                        /////VERIFICAR LA FECHA DEL SERVIDOR FORMATO
                        // SERVIDOR FINAL: string fecha_lim_emision = fecha_lim_aux[1] + "/" + dia_aux[0] + "/" + fecha_lim_aux[0] + " " + hora_limite[1];
                        // MAQUINA DESARROLLO: string fecha_lim_emision = dia_aux[0] + "/" + fecha_lim_aux[1] + "/" + fecha_lim_aux[0] + " " + hora_limite[1];
                        string fecha_lim_emision = fecha_lim_aux[1] + "/" + dia_aux[0] + "/" + fecha_lim_aux[0] + " " + hora_limite[1];
                        lblFechaLimite.Text = fecha_lim_emision;
                        string sessionID = "";
                        string tipo_busqueda = "";
                        if (lblTipoRuta.Text == "RT")
                            tipo_busqueda = "T:2";
                        else
                            tipo_busqueda = "T:1";

                        sessionID = tipo_busqueda + "|PIda:" + it_i.Count().ToString() + "|PVuelta:" + it_v.Count().ToString() + "|6.97" + aerolinea;

                        //securitytoken = Session["securitytoken"].ToString().Replace(',', '.');
                        //0 Eval("boardAirport") +"|"+
                        //1 Eval("offAirport")+"|"+
                        //2 Eval("depDate")+"|"+
                        //3 Eval("depTime")+"|"+
                        //4 Eval("ArrivalDate")+"|"+
                        //5 Eval("hora_llegada")+"|"+
                        //6 Eval("duracion")+"|"+
                        //7 Eval("flightNumber")+"|"+
                        //8 Eval("bookClass")+"|"+
                        //9 Eval("precio")+"|"+
                        //10 Eval("marketCompany") + "|" +
                        //11 Eval("segment") %>'
                        //12 Eval("leg") %>'
                        string resultado = LocalBD.PUT_INGRESA_TICKETS("I", lblUsuario.Text, respuesta_res.datos.pnr, "AAAAAA",
                            datos_fac[0] + "/" + datos_fac[1], datos_fac[2], datos_fac[3], datos_ida[0],
                            datos_ida[1], DateTime.Parse(fecha_ida), datos_ida[4], datos_ida[5], datos_ida[6], origen_vuelta, destino_vuelta,
                            DateTime.Parse(fecha_vuelta), clase_vuelta, carrier_vuelta, nvuelo_vuelta,
                            DateTime.Parse(fecha_lim_emision), respuesta_res.datos.total_acobrar,
                            respuesta_res.datos.moneda, respuesta_res.datos.total_impuestos, respuesta_res.datos.monto_sin_impuestos,
                            sessionID, securitytoken.Replace(',', '.'));
                        string[] cod_ticket = resultado.Split('|');
                        lblCodTiket.Text = cod_ticket[2];
                        string resultado1 = "";
                        string resultado2 = "";
                        int cli_c = 0;
                        decimal tarifa_base_aux = 0;
                        decimal total_impuestos_aux = 0;
                        for (cli_c = 0; cli_c < respuesta_res.datos.pasajeros.Count(); cli_c++)
                        {
                            //string[] docs = respuesta_res.datos.pasajeros[cli_c].foid.Split('|');
                            resultado1 = LocalBD.PUT_INGRESA_CLIENTES(lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                            respuesta_res.datos.pasajeros[cli_c].foid, "", "");

                            if (respuesta_res.datos.pasajeros[cli_c].tipo == "ADT")
                            {
                                resultado2 = LocalBD.PUT_INGRESA_TICKETS_DET("I", lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                                    respuesta_res.datos.pasajeros[cli_c].tipo, respuesta_res.datos.pasajeros[cli_c].foid, DateTime.Now, respuesta_res.datos.total_adt, respuesta_res.datos.moneda,
                                    respuesta_res.datos.total_adt_sin_impuestos, respuesta_res.datos.total_adt_impuestos, cod_ticket[2]);
                                tarifa_base_aux = tarifa_base_aux + respuesta_res.datos.total_adt_sin_impuestos;
                                total_impuestos_aux = total_impuestos_aux + respuesta_res.datos.total_adt_impuestos;
                            }
                            if (respuesta_res.datos.pasajeros[cli_c].tipo == "CHD")
                            {
                                resultado2 = LocalBD.PUT_INGRESA_TICKETS_DET("I", lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                                    respuesta_res.datos.pasajeros[cli_c].tipo, respuesta_res.datos.pasajeros[cli_c].foid, DateTime.Now, respuesta_res.datos.total_chd, respuesta_res.datos.moneda,
                                    respuesta_res.datos.total_chd_sin_impuestos, respuesta_res.datos.total_chd_impuestos, cod_ticket[2]);
                                tarifa_base_aux = tarifa_base_aux + respuesta_res.datos.total_chd_sin_impuestos;
                                total_impuestos_aux = total_impuestos_aux + respuesta_res.datos.total_chd_impuestos;
                            }
                            if (respuesta_res.datos.pasajeros[cli_c].tipo == "INF")
                            {
                                resultado2 = LocalBD.PUT_INGRESA_TICKETS_DET("I", lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                                    respuesta_res.datos.pasajeros[cli_c].tipo, respuesta_res.datos.pasajeros[cli_c].foid, DateTime.Now, respuesta_res.datos.total_inf, respuesta_res.datos.moneda,
                                    respuesta_res.datos.total_inf_sin_impuestos, respuesta_res.datos.total_inf_impuestos, cod_ticket[2]);
                                tarifa_base_aux = tarifa_base_aux + respuesta_res.datos.total_inf_sin_impuestos;
                                total_impuestos_aux = total_impuestos_aux + respuesta_res.datos.total_inf_impuestos;
                            }



                        }


                        panel_ida.Visible = true;
                        lblAdultosResumen.Text = lblNroAdultos.Text;
                        lblNinosResumen.Text = lblNroNinos.Text;
                        lblInfanteResumen.Text = lblNroInfante.Text;
                        lblFechaIdaRes.Text = hfFechaSalida.Value;
                        lblOrgDestIdaRes.Text = lblOrigen.Text + " - " + lblDestino.Text;
                        lblHorarioIdaRes.Text = lblHorarioIdaRes.Text;
                        lblVueloIdaRes.Text = lblVueloIdaRes.Text;
                        panel_total_res.Visible = true;
                        //lblTotalRes.Text = datos_res[7];
                        //lblGananciaRes.Text = datos_res[10];
                        //lblIdaTitulo.Text = datos_res[11];

                        lblOrgDestVueltaRes.Text = lblDestino.Text + " - " + lblOrigen.Text;
                        lblHorarioVueltaRes.Text = lblHorarioVueltaRes.Text;
                        lblVueloVueltaRes.Text = lblVueloVueltaRes.Text;
                        //lblVueltaTitulo.Text = datos_res[15];

                        if (lblTipoRuta.Text == "OW")
                        {
                            panel_vuelta.Visible = false;
                        }
                        else
                        { panel_vuelta.Visible = true; }



                        btnComprarReserva.Enabled = true;
                    }
                    else
                    {
                        lblAvisoReserva.Text = "Error: " + respuesta_res.error + ", elija otro vuelo por favor.";
                        btnComprarReserva.Enabled = false;

                    }
                }
                else
                {
                    Reservas.Application respuesta_res = new Reservas.Application();
                    respuesta_res = JsonConvert.DeserializeObject<Reservas.Application>(respuestaJson);
                    if (respuesta_res.error == "00")
                    {
                        //MultiView1.ActiveViewIndex = 6;
                        txtPNR.Text = respuesta_res.datos.pnr;
                        lblMoneda.Text = respuesta_res.datos.moneda;
                        string[] fechHoraLim = respuesta_res.datos.fecha_limite_emision.Split(' ');
                        string[] fechLim = fechHoraLim[0].Split('-');
                        lblTiempoLimite.Text = "HORA: " + fechHoraLim[1] + " - " + fechLim[2] + " de " + Nombre_mes(int.Parse(fechLim[1])) + ", " + fechLim[0];
                        lblTotalPagarFinal.Text = respuesta_res.datos.total_acobrar.ToString();
                        //lblMonedaFinal.Text = respuesta_res.datos.moneda;
                        //lblSaldoCuenta.Text = "2500";
                        //lblEmail.Text = datos_fac[2];


                        string[] hora_limite = respuesta_res.datos.fecha_limite_emision.Split(' ');
                        string[] fecha_lim_aux = respuesta_res.datos.fecha_limite_emision.Split('-');
                        string[] dia_aux = fecha_lim_aux[2].Split(' ');
                        /////VERIFICAR LA FECHA DEL SERVIDOR FORMATO
                        // SERVIDOR FINAL: string fecha_lim_emision = fecha_lim_aux[1] + "/" + dia_aux[0] + "/" + fecha_lim_aux[0] + " " + hora_limite[1];
                        // MAQUINA DESARROLLO: string fecha_lim_emision = dia_aux[0] + "/" + fecha_lim_aux[1] + "/" + fecha_lim_aux[0] + " " + hora_limite[1];
                        string fecha_lim_emision = fecha_lim_aux[1] + "/" + dia_aux[0] + "/" + fecha_lim_aux[0] + " " + hora_limite[1];
                        lblFechaLimite.Text = fecha_lim_emision;
                        string sessionID = "";
                        string tipo_busqueda = "";
                        if (lblTipoRuta.Text == "RT")
                            tipo_busqueda = "T:2";
                        else
                            tipo_busqueda = "T:1";

                        sessionID = tipo_busqueda + "|PIda:" + it_i.Count().ToString() + "|PVuelta:" + it_v.Count().ToString() + "|6.97" + aerolinea;

                        //0 Eval("boardAirport") +"|"+
                        //1 Eval("offAirport")+"|"+
                        //2 Eval("depDate")+"|"+
                        //3 Eval("depTime")+"|"+
                        //4 Eval("ArrivalDate")+"|"+
                        //5 Eval("hora_llegada")+"|"+
                        //6 Eval("duracion")+"|"+
                        //7 Eval("flightNumber")+"|"+
                        //8 Eval("bookClass")+"|"+
                        //9 Eval("precio")+"|"+
                        //10 Eval("marketCompany") + "|" +
                        //11 Eval("segment") %>'
                        //12 Eval("leg") %>'
                        string resultado = LocalBD.PUT_INGRESA_TICKETS("I", lblUsuario.Text, respuesta_res.datos.pnr, "AAAAAA",
                            datos_fac[0] + "/" + datos_fac[1], datos_fac[2], datos_fac[3], datos_ida[0],
                            datos_ida[1], DateTime.Parse(fecha_ida), datos_ida[4], datos_ida[5], datos_ida[6], origen_vuelta, destino_vuelta,
                            DateTime.Parse(fecha_vuelta), clase_vuelta, carrier_vuelta, nvuelo_vuelta,
                            DateTime.Parse(fecha_lim_emision), respuesta_res.datos.total_acobrar,
                            respuesta_res.datos.moneda, respuesta_res.datos.total_impuestos, respuesta_res.datos.monto_sin_impuestos,
                            sessionID, securitytoken.Replace(',', '.'));
                        string[] cod_ticket = resultado.Split('|');
                        lblCodTiket.Text = cod_ticket[2];
                        string resultado1 = "";
                        string resultado2 = "";
                        int cli_c = 0;
                        for (cli_c = 0; cli_c < respuesta_res.datos.pasajeros.Count(); cli_c++)
                        {
                            //string[] docs = respuesta_res.datos.pasajeros[cli_c].foid.Split('|');
                            resultado1 = LocalBD.PUT_INGRESA_CLIENTES(lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                                respuesta_res.datos.pasajeros[cli_c].foid, "", "");

                            if (respuesta_res.datos.pasajeros[cli_c].tipo == "ADT")
                            {
                                resultado2 = LocalBD.PUT_INGRESA_TICKETS_DET("I", lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                                  respuesta_res.datos.pasajeros[cli_c].tipo, respuesta_res.datos.pasajeros[cli_c].foid, DateTime.Now, decimal.Parse(respuesta_res.datos.datos_por_tipo.ADT[0].costo), respuesta_res.datos.datos_por_tipo.ADT[0].moneda,
                                  decimal.Parse(respuesta_res.datos.datos_por_tipo.ADT[0].monto_sin_impuestos), decimal.Parse(respuesta_res.datos.datos_por_tipo.ADT[0].total_impuestos.ToString()), cod_ticket[2]);
                            }
                            if (respuesta_res.datos.pasajeros[cli_c].tipo == "CHD")
                            {
                                resultado2 = LocalBD.PUT_INGRESA_TICKETS_DET("I", lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                                   respuesta_res.datos.pasajeros[cli_c].tipo, respuesta_res.datos.pasajeros[cli_c].foid, DateTime.Now, decimal.Parse(respuesta_res.datos.datos_por_tipo.CHD[0].costo), respuesta_res.datos.datos_por_tipo.CHD[0].moneda,
                                   decimal.Parse(respuesta_res.datos.datos_por_tipo.CHD[0].monto_sin_impuestos), decimal.Parse(respuesta_res.datos.datos_por_tipo.CHD[0].total_impuestos.ToString()), cod_ticket[2]);
                            }
                            if (respuesta_res.datos.pasajeros[cli_c].tipo == "INF")
                            {
                                resultado2 = LocalBD.PUT_INGRESA_TICKETS_DET("I", lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                                   respuesta_res.datos.pasajeros[cli_c].tipo, respuesta_res.datos.pasajeros[cli_c].foid, DateTime.Now, decimal.Parse(respuesta_res.datos.datos_por_tipo.INF[0].costo), respuesta_res.datos.datos_por_tipo.INF[0].moneda,
                                   decimal.Parse(respuesta_res.datos.datos_por_tipo.INF[0].monto_sin_impuestos), decimal.Parse(respuesta_res.datos.datos_por_tipo.INF[0].total_impuestos.ToString()), cod_ticket[2]);
                            }
                            if (respuesta_res.datos.pasajeros[cli_c].tipo == "SNN")
                            {
                                string costo = "0";
                                string total_impuestos = "0";
                                string monto_sin_impuestos = "0";
                                resultado2 = LocalBD.PUT_INGRESA_TICKETS_DET("I", lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                                   respuesta_res.datos.pasajeros[cli_c].tipo, respuesta_res.datos.pasajeros[cli_c].foid, DateTime.Now, decimal.Parse(costo), "",
                                   decimal.Parse(monto_sin_impuestos), decimal.Parse(total_impuestos), cod_ticket[2]);
                            }
                            if (respuesta_res.datos.pasajeros[cli_c].tipo == "YCD")
                            {
                                resultado2 = LocalBD.PUT_INGRESA_TICKETS_DET("I", lblUsuario.Text, respuesta_res.datos.pasajeros[cli_c].nombre, respuesta_res.datos.pasajeros[cli_c].apellido,
                                   respuesta_res.datos.pasajeros[cli_c].tipo, respuesta_res.datos.pasajeros[cli_c].foid, DateTime.Now, decimal.Parse(respuesta_res.datos.datos_por_tipo.YCD[0].costo), respuesta_res.datos.datos_por_tipo.YCD[0].moneda,
                                   decimal.Parse(respuesta_res.datos.datos_por_tipo.YCD[0].monto_sin_impuestos), decimal.Parse(respuesta_res.datos.datos_por_tipo.YCD[0].total_impuestos.ToString()), cod_ticket[2]);
                            }



                        }


                        panel_ida.Visible = true;
                        lblAdultosResumen.Text = lblNroAdultos.Text;
                        lblNinosResumen.Text = lblNroNinos.Text;
                        lblInfanteResumen.Text = lblNroInfante.Text;
                        lblFechaIdaRes.Text = hfFechaSalida.Value;
                        lblOrgDestIdaRes.Text = lblOrigen.Text + " - " + lblDestino.Text;
                        lblHorarioIdaRes.Text = lblHorarioIdaRes.Text;
                        lblVueloIdaRes.Text = lblVueloIdaRes.Text;
                        panel_total_res.Visible = true;
                        //lblTotalRes.Text = datos_res[7];
                        lblTarifaBaseRes.Text = lblTarifaBaseRes.Text;// datos_res[8];
                        lblTotalImpuestosRes.Text = lblTotalImpuestosRes.Text;// datos_res[9];
                                                                              //lblGananciaRes.Text = datos_res[10];
                                                                              //lblIdaTitulo.Text = datos_res[11];

                        lblOrgDestVueltaRes.Text = lblDestino.Text + " - " + lblOrigen.Text;
                        lblHorarioVueltaRes.Text = lblHorarioVueltaRes.Text;
                        lblVueloVueltaRes.Text = lblVueloVueltaRes.Text;
                        //lblVueltaTitulo.Text = datos_res[15];

                        if (lblTipoRuta.Text == "OW")
                        {
                            panel_vuelta.Visible = false;
                        }
                        else
                        { panel_vuelta.Visible = true; }


                        btnComprarReserva.Enabled = true;

                    }
                    else
                    {
                        txtPNR.Text = "Error: " + respuesta_res.error + ", elija otro vuelo por favor.";
                        btnComprarReserva.Enabled = false;
                    }
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_realizar_reserva_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }

        }

        protected void imgCambiarFee_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                int adultos = 0;
                int senior = 0;
                int ninos = 0;

                int infantes = 0;

                adultos = int.Parse(lblNroAdultos.Text);
                ninos = int.Parse(lblNroNinos.Text);
                infantes = int.Parse(lblNroInfante.Text);
                senior = int.Parse(lblNroSeniors.Text);
                int total_pasajeros = adultos + ninos + senior + infantes;
                decimal desde, hasta;
                desde = decimal.Parse(lblComisionDesde.Text.Replace(",", "."));
                hasta = decimal.Parse(lblComisionHasta.Text.Replace(",", "."));
                //desde = decimal.Parse(lblComisionDesde.Text.Replace(".", ","));
                //hasta = decimal.Parse(lblComisionHasta.Text.Replace(".", ","));
                //if (decimal.Parse(txtComision.Text.Replace(".", ",")) >= desde & decimal.Parse(txtComision.Text.Replace(".", ",")) <= hasta)

                if (decimal.Parse(txtComision.Text.Replace(",", ".")) >= desde & decimal.Parse(txtComision.Text.Replace(",", ".")) <= hasta)
                {

                    lblFeeBroker.Text = txtComision.Text;
                    //decimal total_final = Math.Round((decimal.Parse(lblTotalRes.Text.Replace(".", ",")) + (decimal.Parse(txtComision.Text.Replace(".", ","))*total_pasajeros)), 2);
                    decimal total_final = Math.Round((decimal.Parse(lblTotalRes.Text.Replace(",", ".")) + (decimal.Parse(txtComision.Text.Replace(",", ".")) * total_pasajeros)), 2);
                    lblTotalRes.Text = total_final.ToString();
                    //lblOtrosCargos.Text = Math.Round((decimal.Parse(txtComision.Text.Replace(".", ",")) * total_pasajeros), 2).ToString();
                    lblOtrosCargos.Text = Math.Round((decimal.Parse(txtComision.Text.Replace(",", ".")) * total_pasajeros), 2).ToString();
                    lblAvisoRango.Text = "";
                }
                else
                {
                    lblAvisoRango.Text = "Fuera del rango";
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_cambiar_fee_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }


        }

        protected void btnAgregarPasajero_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblPasajerosAux.Text.Contains(txtCi.Text))
                {

                }
                else
                {
                    string fecha_adt = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                    string pasajero_ADT = "";
                    pasajero_ADT = txtNombre.Text + "&" + txtApellidos.Text + "&" + ddlTipoDocAdt.SelectedValue + "&" + txtCi.Text + "&ADT&" + fecha_adt + "|";

                    lblPasajerosAux.Text = lblPasajerosAux.Text + pasajero_ADT;
                    DataTable dt_pasajeros = new DataTable();
                    dt_pasajeros.Columns.Add("nombre", typeof(string));
                    dt_pasajeros.Columns.Add("apellido", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_doc", typeof(string));
                    dt_pasajeros.Columns.Add("documento", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_pax", typeof(string));
                    dt_pasajeros.Columns.Add("fecha_nacimiento", typeof(string));

                    string[] pasajeros_filas = lblPasajerosAux.Text.Split('|');
                    int i = 0;
                    for (i = 0; i < pasajeros_filas.Count() - 1; i++)
                    {
                        string[] pasajeros = pasajeros_filas[i].Split('&');
                        dt_pasajeros.Rows.Add(new string[6] { pasajeros[0], pasajeros[1], pasajeros[2], pasajeros[3], pasajeros[4], pasajeros[5] });
                        // }
                    }
                    Repeater7.DataSource = dt_pasajeros;
                    Repeater7.DataBind();
                    int resultado = int.Parse(lblCountAdl.Text) - 1;
                    lblCountAdl.Text = resultado.ToString();

                    if (resultado == 0)
                        btnAgregarPasajero.Enabled = false;
                    else
                        btnAgregarPasajero.Enabled = true;
                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    txtCi.Text = "";
                    //txtCodFrec.Text = "";
                    if (lblCountAdl.Text == "0")
                        if (lblNinosCount.Text == "0")
                            if (lblInfaneCount.Text == "0")
                                if (lblCountSen.Text == "0")
                                    panel_continuar_pasajero.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_agregar_adt_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }


        }
        protected void btnAgregarNino_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblPasajerosAux.Text.Contains(txtCiNino.Text))
                {

                }
                else
                {
                    string fecha = hfFechaNino.Value;
                    string pasajero_ADT = "";
                    pasajero_ADT = txtNombreNino.Text + "&" + txtApellidoNino.Text + "&" + ddlTipoDocNin.SelectedValue + "&" + txtCiNino.Text + "&CHD&" + fecha + "|";

                    lblPasajerosAux.Text = lblPasajerosAux.Text + pasajero_ADT;
                    DataTable dt_pasajeros = new DataTable();
                    dt_pasajeros.Columns.Add("nombre", typeof(string));
                    dt_pasajeros.Columns.Add("apellido", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_doc", typeof(string));
                    dt_pasajeros.Columns.Add("documento", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_pax", typeof(string));
                    dt_pasajeros.Columns.Add("fecha_nacimiento", typeof(string));

                    string[] pasajeros_filas = lblPasajerosAux.Text.Split('|');
                    int i = 0;
                    for (i = 0; i < pasajeros_filas.Count() - 1; i++)
                    {
                        string[] pasajeros = pasajeros_filas[i].Split('&');
                        dt_pasajeros.Rows.Add(new string[6] { pasajeros[0], pasajeros[1], pasajeros[2], pasajeros[3], pasajeros[4], pasajeros[5] });
                        // }
                    }
                    Repeater7.DataSource = dt_pasajeros;
                    Repeater7.DataBind();
                    int resultado = int.Parse(lblNinosCount.Text) - 1;
                    lblNinosCount.Text = resultado.ToString();

                    if (resultado == 0)
                        btnAgregarNino.Enabled = false;
                    else
                        btnAgregarNino.Enabled = true;
                    txtNombreNino.Text = "";
                    txtApellidoNino.Text = "";
                    txtCiNino.Text = "";

                    if (lblCountAdl.Text == "0")
                        if (lblNinosCount.Text == "0")
                            if (lblInfaneCount.Text == "0")
                                if (lblCountSen.Text == "0")
                                    panel_continuar_pasajero.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_agregar_nino_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }


        }

        protected void btnAgregarInfante_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblPasajerosAux.Text.Contains(txtCiInf.Text))
                {

                }
                else
                {
                    string fecha = hfFechaNacInf.Value;
                    string pasajero_ADT = "";
                    pasajero_ADT = txtNombreInf.Text + "&" + txtApellidoInf.Text + "&" + ddlTipoDocInf.SelectedValue + "&" + txtCiInf.Text + "&INF&" + fecha + "|";

                    lblPasajerosAux.Text = lblPasajerosAux.Text + pasajero_ADT;
                    DataTable dt_pasajeros = new DataTable();
                    dt_pasajeros.Columns.Add("nombre", typeof(string));
                    dt_pasajeros.Columns.Add("apellido", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_doc", typeof(string));
                    dt_pasajeros.Columns.Add("documento", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_pax", typeof(string));
                    dt_pasajeros.Columns.Add("fecha_nacimiento", typeof(string));

                    string[] pasajeros_filas = lblPasajerosAux.Text.Split('|');
                    int i = 0;
                    for (i = 0; i < pasajeros_filas.Count() - 1; i++)
                    {
                        string[] pasajeros = pasajeros_filas[i].Split('&');
                        dt_pasajeros.Rows.Add(new string[6] { pasajeros[0], pasajeros[1], pasajeros[2], pasajeros[3], pasajeros[4], pasajeros[5] });
                        // }
                    }
                    Repeater7.DataSource = dt_pasajeros;
                    Repeater7.DataBind();
                    int resultado = int.Parse(lblInfaneCount.Text) - 1;
                    lblInfaneCount.Text = resultado.ToString();

                    if (resultado == 0)
                        btnAgregarInfante.Enabled = false;
                    else
                        btnAgregarInfante.Enabled = true;
                    txtNombreInf.Text = "";
                    txtApellidoInf.Text = "";
                    txtCiInf.Text = "";
                    if (lblCountAdl.Text == "0")
                        if (lblNinosCount.Text == "0")
                            if (lblInfaneCount.Text == "0")
                                if (lblCountSen.Text == "0")
                                    panel_continuar_pasajero.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_agregar_inf_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }

        }
        protected void btnAgregarPasajeroSen_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblPasajerosAux.Text.Contains(txtCiSen.Text))
                {

                }
                else
                {
                    //string fecha = hfFechaNacInf.Value;
                    string pasajero_ADT = "";
                    pasajero_ADT = txtNombresSen.Text + "&" + txtApellidosSen.Text + "&" + ddlTipoDocSen.SelectedValue + "&" + txtCiSen.Text + "&SEN&" + DateTime.Now.ToShortDateString() + "|";

                    lblPasajerosAux.Text = lblPasajerosAux.Text + pasajero_ADT;
                    DataTable dt_pasajeros = new DataTable();

                    dt_pasajeros.Columns.Add("nombre", typeof(string));
                    dt_pasajeros.Columns.Add("apellido", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_doc", typeof(string));
                    dt_pasajeros.Columns.Add("documento", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_pax", typeof(string));
                    dt_pasajeros.Columns.Add("fecha_nacimiento", typeof(string));

                    string[] pasajeros_filas = lblPasajerosAux.Text.Split('|');
                    int i = 0;
                    for (i = 0; i < pasajeros_filas.Count() - 1; i++)
                    {
                        string[] pasajeros = pasajeros_filas[i].Split('&');
                        dt_pasajeros.Rows.Add(new string[6] { pasajeros[0], pasajeros[1], pasajeros[2], pasajeros[3], pasajeros[4], pasajeros[5] });
                        // }
                    }
                    Repeater7.DataSource = dt_pasajeros;
                    Repeater7.DataBind();
                    int resultado = int.Parse(lblCountSen.Text) - 1;
                    lblCountSen.Text = resultado.ToString();

                    if (resultado == 0)
                        btnAgregarPasajeroSen.Enabled = false;
                    else
                        btnAgregarPasajeroSen.Enabled = true;
                    txtNombresSen.Text = "";
                    txtApellidosSen.Text = "";
                    txtCiSen.Text = "";
                    if (lblCountAdl.Text == "0")
                        if (lblNinosCount.Text == "0")
                            if (lblInfaneCount.Text == "0")
                                if (lblCountSen.Text == "0")
                                    panel_continuar_pasajero.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_agregar_sen_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }


        }


        protected void lbtnQuitar_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton obj = (LinkButton)sender;
                string[] aux_datos = obj.CommandArgument.ToString().Split('|');
                string nro_doc = aux_datos[0];
                string tipo_pax = aux_datos[1];

                if (lblPasajerosAux.Text != "")
                {
                    DataTable dt_pasajeros = new DataTable();

                    dt_pasajeros.Columns.Add("nombre", typeof(string));
                    dt_pasajeros.Columns.Add("apellido", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_doc", typeof(string));
                    dt_pasajeros.Columns.Add("documento", typeof(string));
                    dt_pasajeros.Columns.Add("tipo_pax", typeof(string));
                    dt_pasajeros.Columns.Add("fecha_nacimiento", typeof(string));

                    string[] pasajeros_filas = lblPasajerosAux.Text.Split('|');
                    int i = 0;

                    for (i = 0; i < pasajeros_filas.Count() - 1; i++)
                    {
                        string[] pasajeros = pasajeros_filas[i].Split('&');
                        if (pasajeros[3] != (nro_doc))
                        { dt_pasajeros.Rows.Add(new string[6] { pasajeros[0], pasajeros[1], pasajeros[2], pasajeros[3], pasajeros[4], pasajeros[5] }); }

                    }
                    if (tipo_pax == "ADT")
                    {
                        int resultado = int.Parse(lblCountAdl.Text) + 1;
                        lblCountAdl.Text = resultado.ToString();
                        btnAgregarPasajero.Enabled = true;
                    }
                    if (tipo_pax == "CHD")
                    {
                        int resultado = int.Parse(lblNinosCount.Text) + 1;
                        lblNinosCount.Text = resultado.ToString();
                        btnAgregarNino.Enabled = true;
                    }
                    if (tipo_pax == "INF")
                    {
                        int resultado = int.Parse(lblInfaneCount.Text) + 1;
                        lblInfaneCount.Text = resultado.ToString();
                        btnAgregarInfante.Enabled = true;
                    }
                    string pasajeros_aux = "";

                    if (dt_pasajeros.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt_pasajeros.Rows)
                        {
                            pasajeros_aux = pasajeros_aux + dr["nombre"].ToString() + "&" + dr["apellido"].ToString() + "&" +
                                 dr["tipo_doc"].ToString() + "&" + dr["documento"].ToString() + "&" + dr["tipo_pax"].ToString() + "&" + dr["fecha_nacimiento"].ToString() + "|";

                        }
                    }
                    lblPasajerosAux.Text = pasajeros_aux;
                    panel_continuar_pasajero.Visible = false;
                    Repeater7.DataSource = dt_pasajeros;
                    Repeater7.DataBind();
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_quitar_pax_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Excepcion no controlada, reive los log o consulte con el administrador.";
            }

        }

        protected void btnGuardarReserva_Click(object sender, EventArgs e)
        {

            Response.Redirect("reserva_admin.aspx");
        }

        protected void btnComprarReserva_Click(object sender, EventArgs e)
        {
            Session["datos_iframe"] = txtPNR.Text + "|" + lblMontoTotalReserva.Text + "|" + lblMonedaIda.Text + "|" + txtEmailTit.Text + "|" + lblCodTiket.Text + "|" + lblGds.Text + "|" + lblFechaLimite.Text;
            Response.Redirect("pagar_reserva.aspx?admin=SI");
        }
    }
}