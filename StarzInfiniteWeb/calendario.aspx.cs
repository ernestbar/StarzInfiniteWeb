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
    public partial class calendario : System.Web.UI.Page
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
                    //   0         1        2      3          4         5       6    7       8      9    10     11     12       13       14          15         16
                    //TIPO RUTA|ORIGEN|DESSTINO|FECHAIDA|FECHAVUELTA|ADULTOS|NINOS|INFANTE|SENIOR|LINEA|TURNO|CABINA|EQUIPAJE|DIRECTO|NOMBORIGEN|NOMBDESTINO|TIPOVENTA
                    string[] datos = Session["DATOSINI"].ToString().Split('|');
                    MultiView1.ActiveViewIndex = 0;
                    lblTipoRuta.Text = datos[0];
                    rblTipoVenta.SelectedValue = datos[16];

                    hfTipoRuta.Value = datos[0];

                    if (lblTipoRuta.Text == "OW")
                    {
                        //Panel_fecha_regreso.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionTipoOW", "TipoVueloOW();", true);
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionTipo", "TipoVuelo();", true);
                    }
                    else
                    {
                        //Panel_fecha_regreso.Visible = true;
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionTipoRT", "TipoVueloRT();", true);
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionTipo2", "TipoVuelo2();", true);
                    }

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
                        if (datos[13] == "1")
                            cbVueloDirecto.Checked = true;
                        else
                            cbVueloDirecto.Checked = false;
                        string vuelos_incluyenequipaje = datos[12];
                        if (datos[12] == "1")
                            cbEquipaje.Checked = true;
                        else
                            cbEquipaje.Checked = false;
                        string gds1 = "A1";
                        string linea_aerea = datos[9];
                        if (datos[9] != "TODAS")
                            ddlLineArea.SelectedValue = datos[9];
                        else
                            linea_aerea = "";
                        string convenio_adt = "";
                        string convenio_menor = "";
                        string convenio_inf = "";
                        string turno = datos[10];
                        if (datos[10] != "TODAS")
                            ddlTurnos.SelectedValue = datos[10];
                        else
                            turno = "";

                        string[] fecha_inf_desde, fecha_inf_hasta;

                        string cabina = datos[11];
                        if (datos[11] != "TODAS")
                            ddlCabina.SelectedValue = datos[11];
                        else
                            cabina = "";
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
                        matriz7 vuelos = new matriz7();
                        string fechaIda, fechaVuelta;
                        string[] auxfechaIda = fecha_sal.Split('-');
                        string[] auxfechaVuelta = fecha_reg.Split('-');

                        fechaIda = auxfechaIda[2] + auxfechaIda[1] + auxfechaIda[0].Remove(0, 2);
                        fechaVuelta = auxfechaVuelta[2] + auxfechaVuelta[1] + auxfechaVuelta[0].Remove(0, 2);

                        List<itinerario_datos> itinerarioList = new List<itinerario_datos>();
                        if (lblTipoRuta.Text == "OW")
                        {
                            itinerario_datos item_itinerario = new itinerario_datos();
                            item_itinerario.origen = datos[1];
                            item_itinerario.destino = datos[2];
                            item_itinerario.fecha = fechaIda;
                            itinerarioList.Add(item_itinerario);
                        }
                        else
                        {
                            itinerario_datos item_itinerario = new itinerario_datos();
                            item_itinerario.origen = datos[1];
                            item_itinerario.destino = datos[2];
                            item_itinerario.fecha = fechaIda;
                            itinerarioList.Add(item_itinerario);

                            itinerario_datos item_itinerario2 = new itinerario_datos();
                            item_itinerario2.origen = datos[2];
                            item_itinerario2.destino = datos[1];
                            item_itinerario2.fecha = fechaVuelta;
                            itinerarioList.Add(item_itinerario2);

                        }

                        //lblTitTipoVuelo.Text = "Seleccionar viaje de Ida";
                        Datos datos1 = new Datos
                        {
                            gds = gds1,
                            adultos = adultos.ToString(),
                            infante = infantes.ToString(),
                            menor = ninos.ToString(),
                            vuelos_directos = vuelos_directos,
                            vuelos_incluyenequipaje = vuelos_incluyenequipaje,
                            tipo_cabina = cabina,
                            aerolinea = linea_aerea,
                            hora_salida = turno,
                            hora_regreso = turno,
                            moneda = moneda1,
                            id_session = id_session,
                            itinerario=itinerarioList
                        };

                        string json = JsonConvert.SerializeObject(datos1);
                        dynamic respuesta = obj.Post("http://20.39.32.111/api/GetCalendario.php", json, "Basic MDQ4NjQwNjY4c3R6cmVycjg2Y2Q3MGE4OTVjZDlmYTowNHdlcndld2V3NjhzdHpyZXJyODZjZDcwYTg5NWNkOWZh");

                        string respuestaJson = respuesta.ToString();


                        vuelos = JsonConvert.DeserializeObject<matriz7>(respuestaJson);



                        DataTable dt_matriz = new DataTable();

                        DateTime fMatriz = DateTime.Parse(fecha_sal);



                        dt_matriz.Columns.AddRange(new DataColumn[18]
                        {
                             new DataColumn("+/-3", typeof(DateTime)),
                             new DataColumn(fMatriz.AddDays(-3).ToShortDateString(), typeof(decimal)),
                             new DataColumn(fMatriz.AddDays(-2).ToShortDateString(), typeof(decimal)),
                             new DataColumn(fMatriz.AddDays(-1).ToShortDateString(), typeof(decimal)),
                             new DataColumn(fMatriz.ToShortDateString(), typeof(decimal)),
                             new DataColumn(fMatriz.AddDays(1).ToShortDateString(), typeof(decimal)),
                             new DataColumn(fMatriz.AddDays(2).ToShortDateString(), typeof(decimal)),
                             new DataColumn(fMatriz.AddDays(3).ToShortDateString(), typeof(decimal)),
                             new DataColumn("moneda", typeof(string)),
                             new DataColumn("origen", typeof(string)),
                             new DataColumn("destino", typeof(string)),
                             new DataColumn("op1", typeof(string)),
                             new DataColumn("op2", typeof(string)),
                             new DataColumn("op3", typeof(string)),
                             new DataColumn("op4", typeof(string)),
                             new DataColumn("op5", typeof(string)),
                             new DataColumn("op6", typeof(string)),
                             new DataColumn("op7", typeof(string))
                        });


                        DataTable dt_datos = new DataTable();
                        dt_datos.Columns.AddRange(new DataColumn[5] {
                            //new DataColumn("id_datos", typeof(int)),
                            new DataColumn("precio", typeof(string)),
                            new DataColumn("moneda", typeof(string)),
                            //new DataColumn("gds", typeof(string)),
                            //new DataColumn("boardAirport",typeof(string)),
                            //new DataColumn("offAirport",typeof(string)),
                            new DataColumn("depDate",typeof(string)),
                            new DataColumn("ArrivalDate",typeof(string)),
                            //new DataColumn("depTime",typeof(string)),
                            //new DataColumn("hora_llegada",typeof(string)),
                            //new DataColumn("duracion",typeof(string)),
                            //new DataColumn("flightNumber",typeof(string)),
                            //new DataColumn("bookClass",typeof(string)),
                            //new DataColumn("segment",typeof(string)),
                            new DataColumn("marketCompany",typeof(string))
                            //new DataColumn("leg",typeof(string)),
                            //new DataColumn("ORIGEN",typeof(string)),
                            //new DataColumn("DESTINO",typeof(string)),
                            //new DataColumn("gds1",typeof(string))

                            });
                        





                        if (vuelos.error == "00")
                        {
                           
                            List<ListItem> vuelosDisponibles = new List<ListItem>();
                            for (int i = 0; i < vuelos.datos.Count; i++)
                            {
                                string carrier_aux = "";
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
                                for (int x = 0; x < vuelos.datos[i].op.Count; x++)
                                {
                                    //if (x == 0)
                                    //{


                                    for (int y = 0; y < vuelos.datos[i].op[x].Count; y++)
                                    {
                                        if (x == 0)
                                        {
                                            DataTable DT_dom = new DataTable();
                                            DT_dom = Dominios.Lista("AEROLINEA");
                                            if (DT_dom.Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in DT_dom.Rows)
                                                {
                                                    if (dr["codigo"].ToString() == vuelos.datos[i].op[x][y].operCompany)
                                                        AEROLINEA = dr["descripcion"].ToString();
                                                }
                                            }
                                            escalas = vuelos.datos[i].op[x][y].segment.ToString();
                                            origen = vuelos.datos[i].op[x][y].boardAirport;
                                            fecha_partida = vuelos.datos[i].op[x][y].depDate;
                                            hora_salida = vuelos.datos[i].op[x][y].depTime;
                                            numero_vuelo = vuelos.datos[i].op[x][y].flightNumber;
                                            carrier =vuelos.datos[i].op[x][y].marketCompany;
                                            carrier_aux = carrier;
                                            lugares_disponibles = "";// vuelos.datos[i].op[x][y].lugres_disponibles;
                                            destino = vuelos.datos[i].op[x][y].offAirport;
                                            fecha_llegada = "Sólo ida";// vuelos.datos[i].op[x][y].ArrivalDate;
                                            hora_llegada = vuelos.datos[i].op[x][y].hora_llegada;
                                            duracion = vuelos.datos[i].op[x][y].duracion;
                                            clase = "";// vuelos.datos[i].op[x][y].bookClass;
                                            leg = vuelos.datos[i].op[x][y].leg.ToString();

                                            string feetotal_aux = LocalBD.PR_GET_FEE_WEB_ITINERARIO(carrier, moneda, datos[16], origen, destino, lblTipoRuta.Text, total_pasajeros);
                                            if (decimal.Parse(feetotal_aux) > 0)
                                                FeeTotal = feetotal_aux;

                                            //SERVIDOR: monto_total = decimal.Parse(monto.Replace(",",".")) + decimal.Parse(FeeTotal.Replace(",", "."));
                                            //monto_total = Math.Round(( decimal.Parse(monto.Replace(".",",")) + decimal.Parse(FeeTotal.Replace(".", ","))),2);
                                           
                                            //lblDtSegmentos.Text = lblDtSegmentos.Text + y + "&" + i + "&" + vuelos.datos[i].op[x][y].segment.ToString() + "&" + vuelos.datos[i].op[x][y].leg + "&" +
                                            //        vuelos.datos[i].op[x][y].flightNumber + "&" + vuelos.datos[i].op[x][y].boardAirport + "&" + vuelos.datos[i].op[x][y].offAirport + "&" +
                                            //        vuelos.datos[i].op[x][y].depDate + "&" + vuelos.datos[i].op[x][y].ArrivalDate + "&" + vuelos.datos[i].op[x][y].depTime + "&" +
                                            //        vuelos.datos[i].op[x][y].hora_llegada + "&" + vuelos.datos[i].op[x][y].marketCompany + "&" + vuelos.datos[i].op[x][y].operCompany + "&" +
                                            //        "" + "&" + "" + "&" + vuelos.datos[i].op[x][y].duracion + "&" +
                                            //        "" + "&" + vuelos.datos[i].op[x][y].Id + "&" + monto_total.ToString() + "&" + AEROLINEA + "&" + gds + "&" + x + "&" + moneda +
                                            //    "|";

                                            //dt_segmentos.Rows.Add(y, i, vuelos.datos[i].opciones.ida[x][y].segment.ToString(), vuelos.datos[i].opciones.ida[x][y].leg,
                                            //        vuelos.datos[i].opciones.ida[x][y].flightNumber, vuelos.datos[i].opciones.ida[x][y].boardAirport, vuelos.datos[i].opciones.ida[x][y].offAirport,
                                            //        vuelos.datos[i].opciones.ida[x][y].depDate, vuelos.datos[i].opciones.ida[x][y].ArrivalDate, vuelos.datos[i].opciones.ida[x][y].depTime,
                                            //        vuelos.datos[i].opciones.ida[x][y].hora_llegada, vuelos.datos[i].opciones.ida[x][y].marketCompany, vuelos.datos[i].opciones.ida[x][y].operCompany,
                                            //        vuelos.datos[i].opciones.ida[x][y].bookClass, vuelos.datos[i].opciones.ida[x][y].lugres_disponibles, vuelos.datos[i].opciones.ida[x][y].duracion,
                                            //        vuelos.datos[i].opciones.ida[x][y].equipaje, vuelos.datos[i].opciones.ida[x][y].ld, monto, AEROLINEA, gds, x, moneda);
                                        }
                                        if (x == 1)
                                        {
                                            fecha_llegada =DateTime.Parse(vuelos.datos[i].op[x][y].depDate).ToShortDateString();
                                          
                                        }
                                       

                                    }
                                    
                                    lblDtOpciones.Text = lblDtOpciones.Text + x + "&" + i + "&" + monto_total.ToString() + "&" + moneda + "&" + AEROLINEA + "|";
                                    //dt_opciones.Rows.Add(x, i, monto, moneda, AEROLINEA);
                                    monto_total = decimal.Parse(monto.Replace(",", ".")) + decimal.Parse(FeeTotal.Replace(",", "."));
                                    //duracion = dur_aux[0] + "h" + dur_aux[1] + "m";
                                   

                                }
                                lblF1.Text = fMatriz.AddDays(-3).ToShortDateString();
                                lblF2.Text = fMatriz.AddDays(-2).ToShortDateString();
                                lblF3.Text = fMatriz.AddDays(-1).ToShortDateString();
                                lblF4.Text = fMatriz.ToShortDateString();
                                lblF5.Text = fMatriz.AddDays(1).ToShortDateString();
                                lblF6.Text = fMatriz.AddDays(2).ToShortDateString();
                                lblF7.Text = fMatriz.AddDays(3).ToShortDateString();
                                if (fMatriz.AddDays(-3).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                    dt_matriz.Rows.Add(fecha_llegada, monto, 0, 0, 0, 0, 0, 0,moneda, origen,destino, carrier_aux,"","","","","","" );
                                if (fMatriz.AddDays(-2).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                    dt_matriz.Rows.Add(fecha_llegada, 0, monto, 0, 0, 0, 0, 0, moneda, origen, destino, "",carrier_aux, "", "", "", "", "");
                                if (fMatriz.AddDays(-1).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                    dt_matriz.Rows.Add(fecha_llegada, 0, 0, monto, 0, 0, 0, 0, moneda, origen, destino, "", "", carrier_aux, "", "", "", "");
                                if (fMatriz.ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                    dt_matriz.Rows.Add(fecha_llegada, 0, 0, 0, monto, 0, 0, 0, moneda, origen, destino, "", "", "", carrier_aux, "", "", "");
                                if (fMatriz.AddDays(1).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                    dt_matriz.Rows.Add(fecha_llegada, 0, 0, 0, 0, monto, 0, 0, moneda, origen, destino, "", "", "", "", carrier_aux, "", "");
                                if (fMatriz.AddDays(2).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                    dt_matriz.Rows.Add(fecha_llegada, 0, 0, 0, 0, 0, monto, 0, moneda, origen, destino, "", "", "", "", "", carrier_aux, "");
                                if (fMatriz.AddDays(3).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                    dt_matriz.Rows.Add(fecha_llegada, 0, 0, 0, 0, 0, 0, monto, moneda, origen, destino, "", "", "", "", "", "", carrier_aux);
                                //monto_total = Math.Round((decimal.Parse(monto.Replace(".", ",")) + decimal.Parse(FeeTotal.Replace(".", ","))), 2);
                                monto_total = Math.Round((decimal.Parse(monto.Replace(",", ".")) + decimal.Parse(FeeTotal.Replace(",", "."))), 2);
                                lblDtDatosAll.Text = lblDtDatosAll.Text + i + "&" + monto_total.ToString() + "&" + vuelos.datos[i].moneda + "&" + vuelos.datos[i].gds + "&" + origen + "&" + destino + "&" + fecha_partida + "&" + fecha_llegada + "&" +
                                        hora_salida + "&" + hora_llegada + "&" + duracion + "&" + numero_vuelo + "&" + clase + "&" + escalas + "&" + carrier + "&" + leg + "&" + ORIGEN_NOM + "&" + DESTINO_NOM + "&" + gds + "|";
                                //dt_datos.Rows.Add(i, monto_total, vuelos.datos[i].moneda, vuelos.datos[i].gds, origen, destino, fecha_partida, fecha_llegada,
                                //    hora_salida, hora_llegada, duracion, numero_vuelo, clase, escalas, carrier, leg, ORIGEN_NOM, DESTINO_NOM, gds);
                                dt_datos.Rows.Add(monto_total, vuelos.datos[i].moneda, fecha_partida, fecha_llegada,
                                     carrier);
                                //if (lblTipoRuta.Text == "RT")
                                //{
                                //    string montoR, claseR, monedaR, lugares_disponiblesR, escalasR, legR, origenR, destinoR,
                                //        fecha_partidaR, fecha_llegadaR, hora_salidaR, hora_llegadaR, duracionR, numero_vueloR, carrierR;
                                //    string ORIGEN_NOMR, DESTINO_NOMR, AEROLINEAR, gdsR;
                                //    AEROLINEAR = "";
                                //    ORIGEN_NOMR = datos[15];
                                //    DESTINO_NOMR = datos[14];
                                //    if (String.IsNullOrEmpty(vuelos.datos[i].precio))
                                //        montoR = "0";
                                //    else
                                //        montoR = vuelos.datos[i].precio.ToString();
                                //    claseR = "";
                                //    gdsR = vuelos.datos[i].gds;
                                //    monedaR = vuelos.datos[i].moneda;
                                //    escalasR = "1";
                                //    legR = "";


                                //    duracionR = "0";
                                //    hora_salidaR = ""; hora_llegadaR = ""; fecha_partidaR = ""; fecha_llegadaR = ""; origenR = ""; destinoR = ""; numero_vueloR = ""; carrierR = "";
                                //    for (int x = 0; x < vuelos.datos[i].op.vuelta.Count; x++)
                                //    {
                                //        //if (x == 0)
                                //        //{


                                //        for (int y = 0; y < vuelos.datos[i].op.vuelta[x].Count; y++)
                                //        {
                                //            DataTable DT_dom = new DataTable();
                                //            DT_dom = Dominios.Lista("AEROLINEA");
                                //            if (DT_dom.Rows.Count > 0)
                                //            {
                                //                foreach (DataRow dr in DT_dom.Rows)
                                //                {
                                //                    if (dr["codigo"].ToString() == vuelos.datos[i].op.vuelta[x][y].operCompany)
                                //                        AEROLINEAR = dr["descripcion"].ToString();
                                //                }
                                //            }
                                //            escalasR = vuelos.datos[i].op.vuelta[x][y].segment.ToString();
                                //            origenR = vuelos.datos[i].op.vuelta[x][y].boardAirport;
                                //            fecha_partidaR = vuelos.datos[i].op.vuelta[x][y].depDate;
                                //            hora_salidaR = vuelos.datos[i].op.vuelta[x][y].depTime;
                                //            numero_vueloR = vuelos.datos[i].op.vuelta[x][y].flightNumber;
                                //            carrierR = vuelos.datos[i].op.vuelta[x][y].marketCompany;
                                //            lugares_disponiblesR = vuelos.datos[i].op.vuelta[x][y].lugres_disponibles;
                                //            destinoR = vuelos.datos[i].op.vuelta[x][y].offAirport;
                                //            fecha_llegadaR = vuelos.datos[i].op.vuelta[x][y].ArrivalDate;
                                //            hora_llegadaR = vuelos.datos[i].op.vuelta[x][y].hora_llegada;
                                //            duracionR = vuelos.datos[i].op.vuelta[x][y].duracion;
                                //            claseR = vuelos.datos[i].op.vuelta[x][y].bookClass;
                                //            legR = vuelos.datos[i].op.vuelta[x][y].leg.ToString();



                                //            lblDtSegmentosRT.Text = lblDtSegmentosRT.Text + y + "&" + i + "&" + vuelos.datos[i].op.vuelta[x][y].segment.ToString() + "&" + vuelos.datos[i].op.vuelta[x][y].leg + "&" +
                                //                    vuelos.datos[i].op.vuelta[x][y].flightNumber + "&" + vuelos.datos[i].op.vuelta[x][y].boardAirport + "&" + vuelos.datos[i].op.vuelta[x][y].offAirport + "&" +
                                //                    vuelos.datos[i].op.vuelta[x][y].depDate + "&" + vuelos.datos[i].op.vuelta[x][y].ArrivalDate + "&" + vuelos.datos[i].op.vuelta[x][y].depTime + "&" +
                                //                    vuelos.datos[i].op.vuelta[x][y].hora_llegada + "&" + vuelos.datos[i].op.vuelta[x][y].marketCompany + "&" + vuelos.datos[i].op.vuelta[x][y].operCompany + "&" +
                                //                    vuelos.datos[i].op.vuelta[x][y].bookClass + "&" + vuelos.datos[i].op.vuelta[x][y].lugres_disponibles + "&" + vuelos.datos[i].op.vuelta[x][y].duracion + "&" +
                                //                    vuelos.datos[i].op.vuelta[x][y].equipaje + "&" + vuelos.datos[i].op.vuelta[x][y].ld + "&" + monto_total.ToString() + "&" + AEROLINEAR + "&" + gdsR + "&" + x + "&" + monedaR + "|";
                                //            //dt_segmentosRT.Rows.Add(y, i, vuelos.datos[i].opciones.vuelta[x][y].segment.ToString(), vuelos.datos[i].opciones.vuelta[x][y].leg,
                                //            //        vuelos.datos[i].opciones.vuelta[x][y].flightNumber, vuelos.datos[i].opciones.vuelta[x][y].boardAirport, vuelos.datos[i].opciones.vuelta[x][y].offAirport,
                                //            //        vuelos.datos[i].opciones.vuelta[x][y].depDate, vuelos.datos[i].opciones.vuelta[x][y].ArrivalDate, vuelos.datos[i].opciones.vuelta[x][y].depTime,
                                //            //        vuelos.datos[i].opciones.vuelta[x][y].hora_llegada, vuelos.datos[i].opciones.vuelta[x][y].marketCompany, vuelos.datos[i].opciones.vuelta[x][y].operCompany,
                                //            //        vuelos.datos[i].opciones.vuelta[x][y].bookClass, vuelos.datos[i].opciones.vuelta[x][y].lugres_disponibles, vuelos.datos[i].opciones.vuelta[x][y].duracion,
                                //            //        vuelos.datos[i].opciones.vuelta[x][y].equipaje, vuelos.datos[i].opciones.vuelta[x][y].ld, montoR, AEROLINEAR, gdsR, x, monedaR);

                                //        }
                                //        lblDtOpcionesRT.Text = lblDtOpcionesRT.Text + x + "&" + i + "&" + monto_total.ToString() + "&" + monedaR + "&" + AEROLINEAR + "|";
                                //        //dt_opcionesRT.Rows.Add(x, i, montoR, monedaR, AEROLINEAR);

                                //    }
                                //    lblDtDatosRTAll.Text = lblDtDatosRTAll.Text + i + "&" + monto_total.ToString() + "&" + vuelos.datos[i].moneda + "&" + vuelos.datos[i].gds + "&" + origenR + "&" + destinoR + "&" + fecha_partidaR + "&" + fecha_llegadaR + "&" +
                                //        hora_salidaR + "&" + hora_llegadaR + "&" + duracionR + "&" + numero_vueloR + "&" + claseR + "&" + escalasR + "&" + carrierR + "&" + legR + "&" + ORIGEN_NOMR + "&" + DESTINO_NOMR + "&" + gdsR + "|";
                                //    dt_datosRT.Rows.Add(i, monto_total.ToString(), vuelos.datos[i].moneda, vuelos.datos[i].gds, origenR, destinoR, fecha_partidaR, fecha_llegadaR,
                                //        hora_salidaR, hora_llegadaR, duracionR, numero_vueloR, claseR, escalasR, carrierR, legR, ORIGEN_NOMR, DESTINO_NOMR, gdsR);

                                //}


                            }
                            lblVueloIdaNoDisponible.Text = "";
                        }
                        else
                        {
                            lblVueloIdaNoDisponible.Text = "El servicio web no devuelve datos, consulte con el administrador.";
                        }

                        //DataTable dt = new DataTable();
                        //dt = dt_matriz.AsEnumerable().GroupBy(r => r.Field<string>(0)).Select(g => g.First()).CopyToDataTable();

                        DataTable dtFinal = dt_matriz.AsEnumerable()
                                            .GroupBy(r1 => r1[0])
                                            .Select(x =>
                                            {
                                                var row = dt_matriz.NewRow();
                                                row[0] = x.Key;
                                                row[1] = x.Sum(r => Convert.ToDecimal(r[1]));
                                                row[2] = x.Sum(r => Convert.ToDecimal(r[2]));
                                                row[3] = x.Sum(r => Convert.ToDecimal(r[3]));
                                                row[4] = x.Sum(r => Convert.ToDecimal(r[4]));
                                                row[5] = x.Sum(r => Convert.ToDecimal(r[5]));
                                                row[6] = x.Sum(r => Convert.ToDecimal(r[6]));
                                                row[7] = x.Sum(r => Convert.ToDecimal(r[7]));
                                                row[8] = x.First().Field<string>(8);
                                                row[9] = x.First().Field<string>(9);
                                                row[10] = x.First().Field<string>(10);
                                                row[11] = x.Last().Field<string>(11);
                                                row[12] = x.Last().Field<string>(12);
                                                row[13] = x.Last().Field<string>(13);
                                                row[14] = x.Last().Field<string>(14);
                                                row[15] = x.Last().Field<string>(15);
                                                row[16] = x.Last().Field<string>(16);
                                                row[17] = x.Last().Field<string>(17);
                                                return row;
                                            }).CopyToDataTable();


                        DataView dtV = dtFinal.DefaultView;
                        dtV.Sort = "+/-3 ASC";
                        dtFinal = dtV.ToTable();

                        gvMatriz.DataSource = dt_matriz;
                        gvMatriz.DataBind();
                        Repeater1.DataSource = dtFinal;
                        Repeater1.DataBind();



                    }

                }



            }

        }
        #region busquedas

        public DataTable GroupBy(string i_sGroupByColumn, string i_sAggregateColumn, DataTable i_dSourceTable)
        {

            DataView dv = new DataView(i_dSourceTable);

            //getting distinct values for group column
            DataTable dtGroup = dv.ToTable(true, new string[] { i_sGroupByColumn });

            //adding column for the row count
            dtGroup.Columns.Add("Count", typeof(int));

            //looping thru distinct values for the group, counting
            foreach (DataRow dr in dtGroup.Rows)
            {
                dr["Count"] = i_dSourceTable.Compute("Count(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
            }

            //returning grouped/counted result
            return dtGroup;
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
            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + hfFechaSalida.Value + "|" + hfFechaRetorno.Value
                 + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                  + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                  + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("calendario.aspx",false);
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
            public string infante { get; set; }
            public string menor { get; set; }
            public string vuelos_directos { get; set; }
            public string vuelos_incluyenequipaje { get; set; }
            public string tipo_cabina { get; set; }
            public string aerolinea { get; set; }
            public string hora_salida { get; set; }
            public string hora_regreso { get; set; }
            public string moneda { get; set; }
            public string id_session { get; set; }
            public IList<itinerario_datos> itinerario { get; set; }

        }
        public class itinerario_datos
        {
            public string origen { get; set; }
            public string destino { get; set; }
            public string fecha { get; set; }

        }
        #endregion

       

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string fecha1 = datos[2];
            string fecha2 = "";
            if (datos[3]=="")
                 fecha2 = datos[1];
            else
                fecha2 = datos[2];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + datos[0] + "|" + datos[1] + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");

        }

        protected void btnComprar1_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF1.Text.Split('/');


            
            string fecha1 = aux_fecha1[2] +"-"+aux_fecha1[1] + "-" + aux_fecha1[0];
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else 
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2] + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }


            //if (datos[3] == "")
            //    fecha2 = datos[1];
            //else
            //    fecha2 = datos[2];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + datos[1] + "|" + datos[2] + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar2_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF1.Text.Split('/');



            string fecha1 = aux_fecha1[2] + "-" + aux_fecha1[1] + "-" + aux_fecha1[0];
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2] + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }


            //if (datos[3] == "")
            //    fecha2 = datos[1];
            //else
            //    fecha2 = datos[2];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + datos[1] + "|" + datos[2] + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar3_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF1.Text.Split('/');



            string fecha1 = aux_fecha1[2] + "-" + aux_fecha1[1] + "-" + aux_fecha1[0];
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2] + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }


            //if (datos[3] == "")
            //    fecha2 = datos[1];
            //else
            //    fecha2 = datos[2];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + datos[1] + "|" + datos[2] + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar4_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF1.Text.Split('/');



            string fecha1 = aux_fecha1[2] + "-" + aux_fecha1[1] + "-" + aux_fecha1[0];
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2] + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }


            //if (datos[3] == "")
            //    fecha2 = datos[1];
            //else
            //    fecha2 = datos[2];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + datos[1] + "|" + datos[2] + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar5_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF1.Text.Split('/');



            string fecha1 = aux_fecha1[2] + "-" + aux_fecha1[1] + "-" + aux_fecha1[0];
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2] + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }


            //if (datos[3] == "")
            //    fecha2 = datos[1];
            //else
            //    fecha2 = datos[2];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + datos[1] + "|" + datos[2] + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar6_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF1.Text.Split('/');



            string fecha1 = aux_fecha1[2] + "-" + aux_fecha1[1] + "-" + aux_fecha1[0];
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2] + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }


            //if (datos[3] == "")
            //    fecha2 = datos[1];
            //else
            //    fecha2 = datos[2];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + datos[1] + "|" + datos[2] + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar7_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF1.Text.Split('/');



            string fecha1 = aux_fecha1[2] + "-" + aux_fecha1[1] + "-" + aux_fecha1[0];
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2] + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }


            //if (datos[3] == "")
            //    fecha2 = datos[1];
            //else
            //    fecha2 = datos[2];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + datos[1] + "|" + datos[2] + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }
    }
}