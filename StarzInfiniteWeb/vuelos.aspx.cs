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
                //////////////////////////TRAE LOS VUELOS DISPONIBLES OW////////////////////////////////
                //   0         1        2      3          4         5       6    7       8      9    10     11     12       13       14          15        16
                //TIPO RUTA|ORIGEN|DESSTINO|FECHAIDA|FECHAVUELTA|ADULTOS|NINOS|INFANTE|SENIOR|LINEA|TURNO|CABINA|EQUIPAJE|DIRECTO|NOMBORIGEN|NOMBDESTINO|TIPOVENTA
                string[] datos = Session["DATOSINI"].ToString().Split('|');

                //lblTipoRuta.Text = hfTipoRuta.Value;
                //if (rblTipoVenta.SelectedValue == "1")
                //    panel_rango.Visible = false;
                //else
                //{
                //    panel_rango.Visible = true;
                //}
                //panel_seccion_vuelos.Visible = true;
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
                        vuelos_incluyeequipaje = vuelos_incluyenequipaje,
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
                    Label id = (Label)e.Item.FindControl("lblIdopcion");
                    Label id2 = (Label)e.Item.FindControl("lblIdDatos");
                    //Label resumen = (Label)e.Item.FindControl("lblResumenCab");
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
                            // }
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
                    //Label resumen = (Label)e.Item.FindControl("lblResumenCab");
                    Label escalaslbl = (Label)e.Item.FindControl("lblEscalas");
                    Button elegir = (Button)e.Item.FindControl("btnElegirRT");
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
                            elegir.ToolTip = aux;
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
            public string vuelos_incluyeequipaje { get; set; }
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
    }
}