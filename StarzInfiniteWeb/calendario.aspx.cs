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
                    //rblCuotas.SelectedValue = datos[17];

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
                        DateTime fMatriz2 = DateTime.Parse(fecha_reg);


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




                        string monto1A="0", monto2A = "0", monto3A = "0", monto4A = "0", monto5A = "0", monto6A = "0", monto7A = "0";
                        string monto1B = "0", monto2B = "0", monto3B = "0", monto4B = "0", monto5B = "0", monto6B = "0", monto7B = "0";
                        string monto1C = "0", monto2C = "0", monto3C = "0", monto4C = "0", monto5C = "0", monto6C = "0", monto7C = "0";
                        string monto1D = "0", monto2D = "0", monto3D = "0", monto4D = "0", monto5D = "0", monto6D = "0", monto7D = "0";
                        string monto1E = "0", monto2E = "0", monto3E = "0", monto4E = "0", monto5E = "0", monto6E = "0", monto7E = "0";
                        string monto1F = "0", monto2F = "0", monto3F = "0", monto4F = "0", monto5F = "0", monto6F = "0", monto7F = "0";
                        string monto1G = "0", monto2G = "0", monto3G = "0", monto4G = "0", monto5G = "0", monto6G = "0", monto7G = "0";
                        string carrier1A ="", carrier2A = "", carrier3A = "", carrier4A = "", carrier5A = "", carrier6A = "", carrier7A = "";
                        string carrier1B = "", carrier2B = "", carrier3B = "", carrier4B = "", carrier5B = "", carrier6B = "", carrier7B = "";
                        string carrier1C = "", carrier2C = "", carrier3C = "", carrier4C = "", carrier5C = "", carrier6C = "", carrier7C = "";
                        string carrier1D = "", carrier2D = "", carrier3D = "", carrier4D = "", carrier5D = "", carrier6D = "", carrier7D = "";
                        string carrier1E = "", carrier2E = "", carrier3E = "", carrier4E = "", carrier5E = "", carrier6E = "", carrier7E = "";
                        string carrier1F = "", carrier2F = "", carrier3F = "", carrier4F = "", carrier5F = "", carrier6F = "", carrier7F = "";
                        string carrier1G = "", carrier2G = "", carrier3G = "", carrier4G = "", carrier5G = "", carrier6G = "", carrier7G = "";
                        string fecha_llegada1 = "", fecha_llegada2 = "", fecha_llegada3 = "", fecha_llegada4 = "", fecha_llegada5 = "", fecha_llegada6 = "", fecha_llegada7 = "";
                        //string fecha_llegada1B = "", fecha_llegada2B = "", fecha_llegada3B = "", fecha_llegada4B = "", fecha_llegada5B = "", fecha_llegada6B = "", fecha_llegada7B = "";
                        //string fecha_llegada1C = "", fecha_llegada2C = "", fecha_llegada3C = "", fecha_llegada4C = "", fecha_llegada5C = "", fecha_llegada6C = "", fecha_llegada7C = "";
                        //string fecha_llegada1D = "", fecha_llegada2D = "", fecha_llegada3D = "", fecha_llegada4D = "", fecha_llegada5D = "", fecha_llegada6D = "", fecha_llegada7D = "";
                        //string fecha_llegada1E = "", fecha_llegada2E = "", fecha_llegada3E = "", fecha_llegada4E = "", fecha_llegada5E = "", fecha_llegada6E = "", fecha_llegada7E = "";
                        //string fecha_llegada1F = "", fecha_llegada2F = "", fecha_llegada3F = "", fecha_llegada4F = "", fecha_llegada5F = "", fecha_llegada6F = "", fecha_llegada7F = "";
                        //string fecha_llegada1G = "", fecha_llegada2G = "", fecha_llegada3G = "", fecha_llegada4G = "", fecha_llegada5G = "", fecha_llegada6G = "", fecha_llegada7G = "";


                        decimal monto_total = 0;
                        decimal monto_totalR = 0;
                        string moneda_all = "", origen_all = "", destino_all = "";
                        if (vuelos.error == "00")
                        {
                           
                            List<ListItem> vuelosDisponibles = new List<ListItem>();
                            for (int i = 0; i < vuelos.datos.Count; i++)
                            {
                                string carrier_aux = "";
                               
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
                                moneda_all = vuelos.datos[i].moneda;
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
                                            origen_all = vuelos.datos[i].op[x][y].boardAirport;
                                            fecha_partida = vuelos.datos[i].op[x][y].depDate;
                                            hora_salida = vuelos.datos[i].op[x][y].depTime;
                                            numero_vuelo = vuelos.datos[i].op[x][y].flightNumber;
                                            carrier =vuelos.datos[i].op[x][y].marketCompany;
                                            carrier_aux = carrier;
                                            lugares_disponibles = "";// vuelos.datos[i].op[x][y].lugres_disponibles;
                                            destino = vuelos.datos[i].op[x][y].offAirport;
                                            destino_all  = vuelos.datos[i].op[x][y].offAirport;
                                            fecha_llegada = "Solo Ida";// vuelos.datos[i].op[x][y].ArrivalDate;
                                            hora_llegada = vuelos.datos[i].op[x][y].hora_llegada;
                                            duracion = vuelos.datos[i].op[x][y].duracion;
                                            clase = "";// vuelos.datos[i].op[x][y].bookClass;
                                            leg = vuelos.datos[i].op[x][y].leg.ToString();

                                            string feetotal_aux = LocalBD.PR_GET_FEE_WEB_ITINERARIO(carrier, moneda, datos[16], ddlOrigen.SelectedValue, ddlDestino.SelectedValue, lblTipoRuta.Text, total_pasajeros);
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
                                            fecha_llegada =vuelos.datos[i].op[x][y].depDate;
                                          
                                        }
                                       

                                    }
                                    
                                    lblDtOpciones.Text = lblDtOpciones.Text + x + "&" + i + "&" + monto_total.ToString() + "&" + moneda + "&" + AEROLINEA + "|";
                                    //dt_opciones.Rows.Add(x, i, monto, moneda, AEROLINEA);
                                    monto_total = decimal.Parse(monto.Replace(",", ".")) + decimal.Parse(FeeTotal.Replace(",", "."));
                                    //duracion = dur_aux[0] + "h" + dur_aux[1] + "m";

                                }


                                //lblF1.Text = fMatriz.AddDays(-3).ToShortDateString();
                                lblF1.Text = fMatriz.AddDays(-3).Day.ToString() + "/" + fMatriz.AddDays(-3).Month.ToString() + "/" + fMatriz.AddDays(-3).Year.ToString();
                                //lblF2.Text = fMatriz.AddDays(-2).ToShortDateString();
                                lblF2.Text = fMatriz.AddDays(-2).Day.ToString() + "/" + fMatriz.AddDays(-2).Month.ToString() + "/" + fMatriz.AddDays(-2).Year.ToString();
                                //lblF3.Text = fMatriz.AddDays(-1).ToShortDateString();
                                lblF3.Text = fMatriz.AddDays(-1).Day.ToString() + "/" + fMatriz.AddDays(-1).Month.ToString() + "/" + fMatriz.AddDays(-1).Year.ToString();
                                //lblF4.Text = fMatriz.ToShortDateString();
                                lblF4.Text = fMatriz.Day.ToString() + "/" + fMatriz.Month.ToString() + "/" + fMatriz.Year.ToString();
                                //lblF5.Text = fMatriz.AddDays(1).ToShortDateString();
                                lblF5.Text = fMatriz.AddDays(1).Day.ToString() + "/" + fMatriz.AddDays(1).Month.ToString() + "/" + fMatriz.AddDays(1).Year.ToString();
                                //lblF6.Text = fMatriz.AddDays(2).ToShortDateString();
                                lblF6.Text = fMatriz.AddDays(2).Day.ToString() + "/" + fMatriz.AddDays(2).Month.ToString() + "/" + fMatriz.AddDays(2).Year.ToString();
                                //lblF7.Text = fMatriz.AddDays(3).ToShortDateString();
                                lblF7.Text = fMatriz.AddDays(3).Day.ToString() + "/" + fMatriz.AddDays(3).Month.ToString() + "/" + fMatriz.AddDays(3).Year.ToString();

                                fecha_llegada1 = fMatriz2.AddDays(-3).ToShortDateString();
                                fecha_llegada2 = fMatriz2.AddDays(-2).ToShortDateString();
                                fecha_llegada3 = fMatriz2.AddDays(-1).ToShortDateString();
                                fecha_llegada4 = fMatriz2.ToShortDateString();
                                fecha_llegada5 = fMatriz2.AddDays(1).ToShortDateString();
                                fecha_llegada6 = fMatriz2.AddDays(2).ToShortDateString();
                                fecha_llegada7 = fMatriz2.AddDays(3).ToShortDateString();



                                if (fMatriz.AddDays(-3).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                {

                                    if (fMatriz2.AddDays(-3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada1 = fecha_llegada;
                                        monto1A = Math.Round(monto_total,2).ToString();
                                        carrier1A = carrier;
                                    }
                                    if (fMatriz2.AddDays(-2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada2 = fecha_llegada;
                                        monto2A = Math.Round(monto_total,2).ToString(); 
                                        carrier2A = carrier;
                                    }
                                    if (fMatriz2.AddDays(-1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada3 = fecha_llegada;
                                        monto3A = Math.Round(monto_total,2).ToString();
                                        carrier3A = carrier;
                                    }
                                    if (fMatriz2.ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada4 = fecha_llegada;
                                        monto4A = Math.Round(monto_total,2).ToString();
                                        carrier4A = carrier;
                                    }
                                    if (fMatriz2.AddDays(1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada5 = fecha_llegada;
                                        monto5A = Math.Round(monto_total,2).ToString();
                                        carrier5A = carrier;
                                    }
                                    if (fMatriz2.AddDays(2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada6 = fecha_llegada;
                                        monto6A = Math.Round(monto_total,2).ToString();
                                        carrier6A = carrier;
                                    }
                                    if (fMatriz2.AddDays(3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada7 = fecha_llegada;
                                        monto7A = Math.Round(monto_total,2).ToString();
                                        carrier7A = carrier;
                                    }
                                }
                                // dt_matriz.Rows.Add(fecha_llegada, monto, 0, 0, 0, 0, 0, 0, moneda, origen, destino, carrier_aux, "", "", "", "", "", "");
                                if (fMatriz.AddDays(-2).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                {
                                    if (fMatriz2.AddDays(-3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada1 = fecha_llegada;
                                        monto1B = Math.Round(monto_total,2).ToString();
                                        carrier1B = carrier;
                                    }
                                    if (fMatriz2.AddDays(-2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada2 = fecha_llegada;
                                        monto2B = Math.Round(monto_total,2).ToString();
                                        carrier2B = carrier;
                                    }
                                    if (fMatriz2.AddDays(-1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada3 = fecha_llegada;
                                        monto3B = Math.Round(monto_total,2).ToString();
                                        carrier3B = carrier;
                                    }
                                    if (fMatriz2.ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada4 = fecha_llegada;
                                        monto4B = Math.Round(monto_total,2).ToString();
                                        carrier4B = carrier;
                                    }
                                    if (fMatriz2.AddDays(1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada5 = fecha_llegada;
                                        monto5B = Math.Round(monto_total,2).ToString();
                                        carrier5B = carrier;
                                    }
                                    if (fMatriz2.AddDays(2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada6 = fecha_llegada;
                                        monto6B = Math.Round(monto_total,2).ToString();
                                        carrier6B = carrier;
                                    }
                                    if (fMatriz2.AddDays(3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada7 = fecha_llegada;
                                        monto7B = Math.Round(monto_total,2).ToString();
                                        carrier7B = carrier;
                                    }
                                }
                                if (fMatriz.AddDays(-1).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                {
                                    if (fMatriz2.AddDays(-3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada1 = fecha_llegada;
                                        monto1C = Math.Round(monto_total,2).ToString();
                                        carrier1C = carrier;
                                    }
                                    if (fMatriz2.AddDays(-2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada2 = fecha_llegada;
                                        monto2C = Math.Round(monto_total,2).ToString();
                                        carrier2C = carrier;
                                    }
                                    if (fMatriz2.AddDays(-1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada3 = fecha_llegada;
                                        monto3C = Math.Round(monto_total,2).ToString();
                                        carrier3C = carrier;
                                    }
                                    if (fMatriz2.ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada4 = fecha_llegada;
                                        monto4C = Math.Round(monto_total,2).ToString();
                                        carrier4C = carrier;
                                    }
                                    if (fMatriz2.AddDays(1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada5 = fecha_llegada;
                                        monto5C = Math.Round(monto_total,2).ToString();
                                        carrier5C = carrier;
                                    }
                                    if (fMatriz2.AddDays(2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada6 = fecha_llegada;
                                        monto6C = Math.Round(monto_total,2).ToString();
                                        carrier6C = carrier;
                                    }
                                    if (fMatriz2.AddDays(3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada7 = fecha_llegada;
                                        monto7C = Math.Round(monto_total,2).ToString();
                                        carrier7C = carrier;
                                    }
                                }
                                if (fMatriz.ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                {
                                    if (fMatriz2.AddDays(-3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada1 = fecha_llegada;
                                        monto1D = Math.Round(monto_total,2).ToString();
                                        carrier1D = carrier;
                                    }
                                    if (fMatriz2.AddDays(-2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada2 = fecha_llegada;
                                        monto2D = Math.Round(monto_total,2).ToString();
                                        carrier2D = carrier;
                                    }
                                    if (fMatriz2.AddDays(-1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada3 = fecha_llegada;
                                        monto3D = Math.Round(monto_total,2).ToString();
                                        carrier3D = carrier;
                                    }
                                    if (fMatriz2.ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada4 = fecha_llegada;
                                        monto4D = Math.Round(monto_total,2).ToString();
                                        carrier4D = carrier;
                                    }
                                    if (fMatriz2.AddDays(1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada5 = fecha_llegada;
                                        monto5D = Math.Round(monto_total,2).ToString();
                                        carrier5D = carrier;
                                    }
                                    if (fMatriz2.AddDays(2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada6 = fecha_llegada;
                                        monto6D = Math.Round(monto_total,2).ToString();
                                        carrier6D = carrier;
                                    }
                                    if (fMatriz2.AddDays(3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada7 = fecha_llegada;
                                        monto7D = Math.Round(monto_total,2).ToString();
                                        carrier7D = carrier;
                                    }
                                }
                                if (fMatriz.AddDays(1).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                {
                                    if (fMatriz2.AddDays(-3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada1 = fecha_llegada;
                                        monto1E = Math.Round(monto_total,2).ToString();
                                        carrier1E = carrier;
                                    }
                                    if (fMatriz2.AddDays(-2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada2 = fecha_llegada;
                                        monto2E = Math.Round(monto_total,2).ToString();
                                        carrier2E = carrier;
                                    }
                                    if (fMatriz2.AddDays(-1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada3 = fecha_llegada;
                                        monto3E = Math.Round(monto_total,2).ToString();
                                        carrier3E = carrier;
                                    }
                                    if (fMatriz2.ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada4 = fecha_llegada;
                                        monto4E = Math.Round(monto_total,2).ToString();
                                        carrier4E = carrier;
                                    }
                                    if (fMatriz2.AddDays(1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada5 = fecha_llegada;
                                        monto5E = Math.Round(monto_total,2).ToString();
                                        carrier5E = carrier;
                                    }
                                    if (fMatriz2.AddDays(2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada6 = fecha_llegada;
                                        monto6E = Math.Round(monto_total,2).ToString();
                                        carrier6E = carrier;
                                    }
                                    if (fMatriz2.AddDays(3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada7 = fecha_llegada;
                                        monto7E = Math.Round(monto_total,2).ToString();
                                        carrier7E = carrier;
                                    }
                                }
                                if (fMatriz.AddDays(2).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                {
                                    if (fMatriz2.AddDays(-3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada1 = fecha_llegada;
                                        monto1F = Math.Round(monto_total,2).ToString();
                                        carrier1F = carrier;
                                    }
                                    if (fMatriz2.AddDays(-2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada2 = fecha_llegada;
                                        monto2F = Math.Round(monto_total,2).ToString();
                                        carrier2F = carrier;
                                    }
                                    if (fMatriz2.AddDays(-1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada3 = fecha_llegada;
                                        monto3F = Math.Round(monto_total,2).ToString();
                                        carrier3F = carrier;
                                    }
                                    if (fMatriz2.ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada4 = fecha_llegada;
                                        monto4F = Math.Round(monto_total,2).ToString();
                                        carrier4F = carrier;
                                    }
                                    if (fMatriz2.AddDays(1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada5 = fecha_llegada;
                                        monto5F = Math.Round(monto_total,2).ToString();
                                        carrier5F = carrier;
                                    }
                                    if (fMatriz2.AddDays(2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada6 = fecha_llegada;
                                        monto6F = Math.Round(monto_total,2).ToString();
                                        carrier6F = carrier;
                                    }
                                    if (fMatriz2.AddDays(3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada7 = fecha_llegada;
                                        monto7F = Math.Round(monto_total,2).ToString();
                                        carrier7F = carrier;
                                    }
                                }
                                if (fMatriz.AddDays(3).ToShortDateString() == DateTime.Parse(fecha_partida).ToShortDateString())
                                {
                                    if (fMatriz2.AddDays(-3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada1 = fecha_llegada;
                                        monto1G = Math.Round(monto_total,2).ToString();
                                        carrier1G = carrier;
                                    }
                                    if (fMatriz2.AddDays(-2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada2 = fecha_llegada;
                                        monto2G = Math.Round(monto_total,2).ToString();
                                        carrier2G = carrier;
                                    }
                                    if (fMatriz2.AddDays(-1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada3 = fecha_llegada;
                                        monto3G = Math.Round(monto_total,2).ToString();
                                        carrier3G = carrier;
                                    }
                                    if (fMatriz2.ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada4 = fecha_llegada;
                                        monto4G = Math.Round(monto_total,2).ToString();
                                        carrier4G = carrier;
                                    }
                                    if (fMatriz2.AddDays(1).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada5 = fecha_llegada;
                                        monto5G = Math.Round(monto_total,2).ToString();
                                        carrier5G = carrier;
                                    }
                                    if (fMatriz2.AddDays(2).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada6 = fecha_llegada;
                                        monto6G = Math.Round(monto_total,2).ToString();
                                        carrier6G = carrier;
                                    }
                                    if (fMatriz2.AddDays(3).ToShortDateString() == DateTime.Parse(fecha_llegada).ToShortDateString())
                                    {
                                        fecha_llegada7 = fecha_llegada;
                                        monto7G = Math.Round(monto_total,2).ToString();
                                        carrier7G = carrier;
                                    }
                                }


                                //monto_total = Math.Round((decimal.Parse(monto.Replace(".", ",")) + decimal.Parse(FeeTotal.Replace(".", ","))), 2);
                                monto_total = Math.Round((decimal.Parse(monto.Replace(",", ".")) + decimal.Parse(FeeTotal.Replace(",", "."))), 2);
                                lblDtDatosAll.Text = lblDtDatosAll.Text + i + "&" + monto_total.ToString() + "&" + vuelos.datos[i].moneda + "&" + vuelos.datos[i].gds + "&" + origen + "&" + destino + "&" + fecha_partida + "&" + fecha_llegada + "&" +
                                        hora_salida + "&" + hora_llegada + "&" + duracion + "&" + numero_vuelo + "&" + clase + "&" + escalas + "&" + carrier + "&" + leg + "&" + ORIGEN_NOM + "&" + DESTINO_NOM + "&" + gds + "|";
                                //dt_datos.Rows.Add(i, monto_total, vuelos.datos[i].moneda, vuelos.datos[i].gds, origen, destino, fecha_partida, fecha_llegada,
                                //    hora_salida, hora_llegada, duracion, numero_vuelo, clase, escalas, carrier, leg, ORIGEN_NOM, DESTINO_NOM, gds);
                                dt_datos.Rows.Add(monto_total, vuelos.datos[i].moneda, fecha_partida, fecha_llegada,
                                     carrier);
                            }

                            
                            dt_matriz.Rows.Add(fecha_llegada1, monto1A, monto1B, monto1C, monto1D, monto1E, monto1F, monto1G, moneda_all, origen_all, destino_all, carrier1A, carrier1B, carrier1C, carrier1D, carrier1E, carrier1F, carrier1G);
                            dt_matriz.Rows.Add(fecha_llegada2, monto2A, monto2B, monto2C, monto2D, monto2E, monto2F, monto2G, moneda_all, origen_all, destino_all, carrier2A, carrier2B, carrier2C, carrier2D, carrier2E, carrier2F, carrier2G);
                            dt_matriz.Rows.Add(fecha_llegada3, monto3A, monto3B, monto3C, monto3D, monto3E, monto3F, monto3G, moneda_all, origen_all, destino_all, carrier3A, carrier3B, carrier3C, carrier3D, carrier3E, carrier3F, carrier3G);
                            dt_matriz.Rows.Add(fecha_llegada4, monto4A, monto4B, monto4C, monto4D, monto4E, monto4F, monto4G, moneda_all, origen_all, destino_all, carrier4A, carrier4B, carrier4C, carrier4D, carrier4E, carrier4F, carrier4G);
                            dt_matriz.Rows.Add(fecha_llegada5, monto5A, monto5B, monto5C, monto5D, monto5E, monto5F, monto5G, moneda_all, origen_all, destino_all, carrier5A, carrier5B, carrier5C, carrier5D, carrier5E, carrier5F, carrier5G);
                            dt_matriz.Rows.Add(fecha_llegada6, monto6A, monto6B, monto6C, monto6D, monto6E, monto6F, monto6G, moneda_all, origen_all, destino_all, carrier6A, carrier6B, carrier6C, carrier6D, carrier6E, carrier6F, carrier6G);
                            dt_matriz.Rows.Add(fecha_llegada7, monto7A, monto7B, monto7C, monto7D, monto7E, monto7F, monto7G, moneda_all, origen_all, destino_all, carrier7A, carrier7B, carrier7C, carrier7D, carrier7E, carrier7F, carrier7G);

                            lblVueloIdaNoDisponible.Text = "";
                        }
                        else
                        {
                            lblVueloIdaNoDisponible.Text = "El servicio web no devuelve datos, consulte con el administrador.";
                        }

                        DataView dtV = dt_matriz.DefaultView;
                        dtV.Sort = "+/-3 ASC";
                        dt_matriz = dtV.ToTable();

                        gvMatriz.DataSource = dt_matriz;
                        gvMatriz.DataBind();
                        Repeater1.DataSource = dt_matriz;
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


            string mes1 = "";
            string dia1 = "";
            if (aux_fecha1[1].Length == 1) { mes1 = "0" + aux_fecha1[1]; } else { mes1 = aux_fecha1[1]; }
            if (aux_fecha1[0].Length == 1) { dia1 = "0" + aux_fecha1[0]; } else { dia1 = aux_fecha1[0]; }

            string fecha1 = aux_fecha1[2] + "-" + mes1 + "-" + dia1;
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else 
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2].Replace(" 12:00:00 AM", "") + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }

           ddlLineArea.SelectedValue = datos[3];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

           // lblAviso.Text = Session["DATOSINI"].ToString();

           Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar2_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF2.Text.Split('/');



            string mes1 = "";
            string dia1 = "";
            if (aux_fecha1[1].Length == 1) { mes1 = "0" + aux_fecha1[1]; } else { mes1 = aux_fecha1[1]; }
            if (aux_fecha1[0].Length == 1) { dia1 = "0" + aux_fecha1[0]; } else { dia1 = aux_fecha1[0]; }

            string fecha1 = aux_fecha1[2] + "-" + mes1 + "-" + dia1;
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2].Replace(" 12:00:00 AM", "") + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }

            ddlLineArea.SelectedValue = datos[3];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar3_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF3.Text.Split('/');



            string mes1 = "";
            string dia1 = "";
            if (aux_fecha1[1].Length == 1) { mes1 = "0" + aux_fecha1[1]; } else { mes1 = aux_fecha1[1]; }
            if (aux_fecha1[0].Length == 1) { dia1 = "0" + aux_fecha1[0]; } else { dia1 = aux_fecha1[0]; }

            string fecha1 = aux_fecha1[2] + "-" + mes1 + "-" + dia1;
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2].Replace(" 12:00:00 AM", "") + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }
            ddlLineArea.SelectedValue = datos[3];

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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar4_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF4.Text.Split('/');



            string mes1 = "";
            string dia1 = "";
            if (aux_fecha1[1].Length == 1) { mes1 = "0" + aux_fecha1[1]; } else { mes1 = aux_fecha1[1]; }
            if (aux_fecha1[0].Length == 1) { dia1 = "0" + aux_fecha1[0]; } else { dia1 = aux_fecha1[0]; }

            string fecha1 = aux_fecha1[2] + "-" + mes1 + "-" + dia1;
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2].Replace(" 12:00:00 AM", "") + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }

            ddlLineArea.SelectedValue = datos[3];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar5_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF5.Text.Split('/');



            string mes1 = "";
            string dia1 = "";
            if (aux_fecha1[1].Length == 1) { mes1 = "0" + aux_fecha1[1]; } else { mes1 = aux_fecha1[1]; }
            if (aux_fecha1[0].Length == 1) { dia1 = "0" + aux_fecha1[0]; } else { dia1 = aux_fecha1[0]; }

            string fecha1 = aux_fecha1[2] + "-" + mes1 + "-" + dia1;
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2].Replace(" 12:00:00 AM", "") + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }

            ddlLineArea.SelectedValue = datos[3];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar6_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF6.Text.Split('/');



            string mes1 = "";
            string dia1 = "";
            if (aux_fecha1[1].Length == 1) { mes1 = "0" + aux_fecha1[1]; } else { mes1 = aux_fecha1[1]; }
            if (aux_fecha1[0].Length == 1) { dia1 = "0" + aux_fecha1[0]; } else { dia1 = aux_fecha1[0]; }

            string fecha1 = aux_fecha1[2] + "-" + mes1 + "-" + dia1;
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2].Replace(" 12:00:00 AM", "") + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }

            ddlLineArea.SelectedValue = datos[3];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void btnComprar7_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string[] datos = obj.CommandArgument.ToString().Split('|');
            string[] aux_fecha1 = lblF7.Text.Split('/');



            string mes1 = "";
            string dia1 = "";
            if (aux_fecha1[1].Length == 1) { mes1 = "0" + aux_fecha1[1]; } else { mes1 = aux_fecha1[1]; }
            if (aux_fecha1[0].Length == 1) { dia1 = "0" + aux_fecha1[0]; } else { dia1 = aux_fecha1[0]; }

            string fecha1 = aux_fecha1[2] + "-" + mes1 + "-" + dia1;
            string fecha2 = "";

            if (datos[0] == "Sólo ida")
                fecha2 = fecha1;
            else
            {
                string[] aux_fecha2 = datos[0].Split('/');
                fecha2 = aux_fecha2[2].Replace(" 12:00:00 AM", "") + "-" + aux_fecha2[1] + "-" + aux_fecha2[0];
            }

            ddlLineArea.SelectedValue = datos[3];
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

            Session["DATOSINI"] = hfTipoRuta.Value + "|" + ddlOrigen.SelectedValue + "|" + ddlDestino.SelectedValue + "|" + fecha1 + "|" + fecha2
                + "|" + txtAdultos.Text + "|" + txtNinos.Text + "|" + txtInfante.Text + "|" + txtSenior.Text + "|" + ddlLineArea.SelectedValue + "|" + ddlTurnos.SelectedValue
                 + "|" + ddlCabina.SelectedValue + "|" + vuelos_incluyenequipaje + "|" + vuelos_directos + "|" + ddlOrigen.SelectedItem.Text
                 + "|" + ddlDestino.SelectedItem.Text + "|" + rblTipoVenta.SelectedValue;

            Response.Redirect("vuelos.aspx");
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            { 
            
            }
            
        }
    }
}