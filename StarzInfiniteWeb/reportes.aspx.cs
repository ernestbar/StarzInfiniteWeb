using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StarzInfiniteWeb
{
    public partial class reportes : System.Web.UI.Page
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
                    hfFecha1.Value = DateTime.Now.ToShortDateString();
                    hfFecha2.Value = DateTime.Now.ToShortDateString();

                    lblUsuario.Text = "adrianavera_d@hotmail.com"; //Session["usuario"].ToString();
                    MultiView1.ActiveViewIndex = 0;
                    //DataTable dt = new DataTable();
                    //dt = clases.LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_WEB(lblUsuario.Text,hfFecha1.Value,hfFecha2.Value);
                    //labelsInfo("", "", true);
                    ////Repeater1.DataSource = dt;
                    ////Repeater1.DataBind();
                    //int contador = 0;
                    //int total_ventas = 0;
                    //string labelD = "";
                    //string datosD = "";
                    //for (int dias = 1; dias <= 31; dias++)
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        DateTime fecha = DateTime.Parse(dr["FECHA"].ToString());

                    //        if (fecha.Month == DateTime.Now.Month && fecha.Year == DateTime.Now.Year)
                    //        {
                    //            if (fecha.Day == dias)
                    //            {
                    //                contador++;
                    //                total_ventas++;

                    //            }
                    //        }

                    //    }

                    //    if (contador > 0)
                    //    {
                    //        labelD = labelD + "'" + dias.ToString() + "',";
                    //        datosD = datosD + contador.ToString() + ",";
                    //    }
                    //    contador = 0;
                    //}

                    //if (labelD != "")
                    //{
                    //    string mes_nombre = Nombre_mes(DateTime.Now.Month);
                    //    string aux = labelD.Remove(labelD.Length - 1, 1);
                    //    string script_str = "var ctx = document.getElementById('myChart').getContext(\"2d\");" +
                    //        " var myChart = new Chart(ctx, { type: \"line\", data:{labels: [" +
                    //        labelD.Remove(labelD.Length - 1, 1) + "], datasets: [{label: 'Ventas del mes:" + mes_nombre + "',data: [" + datosD.Remove(datosD.Length - 1, 1) + "]," +
                    //            "fill: false," +
                    //            "borderColor: 'rgb(42, 89, 211 )'," +
                    //            "tension: 0.1" +
                    //        "}]," +
                    //        "options:" +
                    //        "{" +
                    //        "scales:" +
                    //           " {" +
                    //            "yAxes: [{" +
                    //                "ticks:" +
                    //                    "{" +
                    //                    "beginAtZero: true" +
                    //                    "}" +
                    //                "}]" +
                    //            "}" +
                    //        "}" +
                    //    "}" +
                    //"});";

                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "graficoBarras", script_str, true);
                    //}
                    //else
                    //{

                    //}
                }
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

        public void labelsInfo(string fecha1, string fecha2, bool todos)
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                DataTable dt = new DataTable();
                dt = LocalBD.PR_OBTIENE_BOLETOS_TODOS(lblUsuario.Text);
                int count_vendidos = 0;
                int count_pendientes = 0;
                int count_cancelados = 0;
                int count_vencidos = 0;
                if (todos == true)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["estado"].ToString() == "EMITIDO")
                                count_vendidos++;
                            if (dr["estado"].ToString() == "PENDIENTE")
                                count_pendientes++;
                            if (dr["estado"].ToString() == "CANCELADO")
                                count_cancelados++;
                            if (dr["estado"].ToString() == "VENCIDO")
                                count_vencidos++;

                        }
                    }
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (DateTime.Parse(dr["fechaida"].ToString()) >= DateTime.Parse(fecha1) & DateTime.Parse(dr["fechaida"].ToString()) <= DateTime.Parse(fecha2))
                            {
                                if (dr["estado"].ToString() == "EMITIDO")
                                    count_vendidos++;
                                if (dr["estado"].ToString() == "PENDIENTE")
                                    count_pendientes++;
                                if (dr["estado"].ToString() == "CANCELADO")
                                    count_cancelados++;
                                if (dr["estado"].ToString() == "VENCIDO")
                                    count_vencidos++;
                            }
                        }
                    }
                }
                //lblBolVendidos.Text = count_vendidos.ToString();
                //lblPendientes.Text = count_pendientes.ToString();
                //lblCancelados.Text = count_cancelados.ToString();
                //lblExpirados.Text = count_vencidos.ToString();
            }
            if (MultiView1.ActiveViewIndex == 1)
            {
                lblGanAcu.Text = LocalBD.PR_OBTIENE_GANANCIA_TOTAL(lblUsuario.Text);
                DataTable dt = new DataTable();
                dt = LocalBD.PR_OBTIENE_REPORTE_GANANCIAS(lblUsuario.Text);
                decimal gan_mis_ventas = 0;
                decimal gan_equi_ventas = 0;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (DateTime.Parse(dr["fecha"].ToString()) >= DateTime.Parse(fecha1) & DateTime.Parse(dr["fecha"].ToString()) <= DateTime.Parse(fecha2))
                        {
                            string[] montos = dr["MONTO"].ToString().Split(' ');
                            if (dr["CONCEPTO"].ToString().Contains("Ganancia por venta de boleto"))
                            {
                                gan_mis_ventas = gan_mis_ventas + decimal.Parse(montos[2].Replace(".", ","));
                            }
                            if (dr["CONCEPTO"].ToString().Contains("Ganancia por equipo de ventas"))
                            {
                                gan_equi_ventas = gan_equi_ventas + decimal.Parse(montos[2].Replace(".", ","));
                            }

                        }
                    }

                }
                lblGanAcu.Text = "Bs. " + (gan_mis_ventas + gan_equi_ventas).ToString();
                lblGanMisVentas.Text = "Bs. " + gan_mis_ventas.ToString();
                lblGanEquipo.Text = "Bs. " + gan_equi_ventas.ToString();
                //lblGanMisVentas.Text=clases.LocalBD.
            }

        }
        protected void lbtnVoletosVendidos_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;

            DataTable dt = new DataTable();
            dt = LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_WEB(lblUsuario.Text, hfFecha1.Value, hfFecha2.Value);
            labelsInfo("", "", true);
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();
            int contador = 0;
            int total_ventas = 0;
            string labelD = "";
            string datosD = "";
            for (int dias = 1; dias <= 31; dias++)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fecha = DateTime.Parse(dr["FECHA"].ToString());

                    if (fecha.Month == DateTime.Now.Month && fecha.Year == DateTime.Now.Year)
                    {
                        if (fecha.Day == dias)
                        {
                            contador++;
                            total_ventas++;

                        }
                    }

                }

                if (contador > 0)
                {
                    labelD = labelD + "'" + dias.ToString() + "',";
                    datosD = datosD + contador.ToString() + ",";
                }
                contador = 0;
            }

            if (labelD != "")
            {
                string mes_nombre = Nombre_mes(DateTime.Now.Month);
                string aux = labelD.Remove(labelD.Length - 1, 1);
                string script_str = "var ctx = document.getElementById('myChart').getContext(\"2d\");" +
                    " var myChart = new Chart(ctx, { type: \"line\", data:{labels: [" +
                    labelD.Remove(labelD.Length - 1, 1) + "], datasets: [{label: 'Ventas del mes:" + mes_nombre + "',data: [" + datosD.Remove(datosD.Length - 1, 1) + "]," +
                        "fill: false," +
                        "borderColor: 'rgb(42, 89, 211 )'," +
                        "tension: 0.1" +
                    "}]," +
                    "options:" +
                    "{" +
                    "scales:" +
                       " {" +
                        "yAxes: [{" +
                            "ticks:" +
                                "{" +
                                "beginAtZero: true" +
                                "}" +
                            "}]" +
                        "}" +
                    "}" +
                "}" +
            "});";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "graficoBarras", script_str, true);
            }
            else
            {

            }

        }

        protected void lbtnMovBilletera_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            string fecha_sal = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-1";
            string fecha_reg = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            string filteringExpression = string.Format("FECHA >= '{0}' AND FECHA <= '{1} 23:59:59'", fecha_sal, fecha_reg);
            odsMovimientosCuenta.FilterExpression = filteringExpression;
            odsMovimientosCuenta.DataBind();
            Repeater3.DataBind();
            string[] datBilletera = LocalBD.PR_OBTIENE_MOVIMIENTOS_CUENTA_totales(lblUsuario.Text).Split('|');
            lblSaldoBilletera.Text = "Bs. " + datBilletera[0];
        }

        protected void btnFiltrarFechas_Click(object sender, EventArgs e)
        {

            MultiView1.ActiveViewIndex = 0;
            Repeater1.DataBind();
            //string fecha_sal = ""; //hfFechaSalida.Value;
            //string fecha_reg = ""; // hfFechaRetorno.Value;
            //if (fecha_sal == "")
            //{ fecha_sal = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-1"; }
            //if (fecha_reg == "")
            //{ fecha_reg = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString(); }
            //string filteringExpression = string.Format("FECHA >= '{0}' AND FECHA <= '{1} 23:59:59'", fecha_sal, fecha_reg);
            ////ds.Tables[0].DefaultView.RowFilter = "State = 'Maharashtra'";
            //if (MultiView1.ActiveViewIndex == 0)
            //{
            //    labelsInfo(fecha_sal, fecha_reg, false);

            //    odsBoletosVendidos.FilterExpression = filteringExpression;
            //    odsBoletosVendidos.DataBind();
            //    DataTable dt = new DataTable();
            //    dt = clases.LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_WEB(lblUsuario.Text, hfFecha1.Value, hfFecha2.Value);
            //    int contador = 0;
            //    int total_ventas = 0;
            //    string labelD = "";
            //    string datosD = "";
            //    for (int dias = 1; dias <= 31; dias++)
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            DateTime fecha = DateTime.Parse(dr["FECHA"].ToString());

            //            if (fecha >= DateTime.Parse(fecha_sal) && fecha <= DateTime.Parse(fecha_reg))
            //            {
            //                if (fecha.Day == dias)
            //                {
            //                    contador++;
            //                    total_ventas++;

            //                }
            //            }

            //        }

            //        if (contador > 0)
            //        {
            //            labelD = labelD + "'" + dias.ToString() + "',";
            //            datosD = datosD + contador.ToString() + ",";
            //        }
            //        contador = 0;
            //    }

            //    if (labelD != "")
            //    {
            //        string mes_nombre = Nombre_mes(DateTime.Parse(fecha_sal).Month);
            //        string aux = labelD.Remove(labelD.Length - 1, 1);
            //        string script_str = "var ctx = document.getElementById('myChart').getContext(\"2d\");" +
            //            " var myChart = new Chart(ctx, { type: \"line\", data:{labels: [" +
            //            labelD.Remove(labelD.Length - 1, 1) + "], datasets: [{label: 'Ventas del mes:" + mes_nombre + "',data: [" + datosD.Remove(datosD.Length - 1, 1) + "]," +
            //                "fill: false," +
            //                "borderColor: 'rgb(42, 89, 211 )'," +
            //                "tension: 0.1" +
            //            "}]," +
            //            "options:" +
            //            "{" +
            //            "scales:" +
            //               " {" +
            //                "yAxes: [{" +
            //                    "ticks:" +
            //                        "{" +
            //                        "beginAtZero: true" +
            //                        "}" +
            //                    "}]" +
            //                "}" +
            //            "}" +
            //        "}" +
            //    "});";

            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "graficoBarras", script_str, true);

            //    }
            //}
            //if (MultiView1.ActiveViewIndex == 1)
            //{


            //    labelsInfo(fecha_sal, fecha_reg, false);

            //    odsObtieneGanancias.FilterExpression = filteringExpression;
            //    odsObtieneGanancias.DataBind();
            //    Repeater2.DataBind();
            //    DataTable dt = new DataTable();
            //    dt = clases.LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_WEB(lblUsuario.Text, hfFecha1.Value, hfFecha2.Value);
            //    int contador = 0;
            //    int total_ventas = 0;
            //    string labelD = "";
            //    string datosD = "";
            //    for (int dias = 1; dias <= 31; dias++)
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            DateTime fecha = DateTime.Parse(dr["FECHA"].ToString());

            //            if (fecha >= DateTime.Parse(fecha_sal) && fecha <= DateTime.Parse(fecha_reg))
            //            {
            //                if (fecha.Day == dias)
            //                {
            //                    contador++;
            //                    total_ventas++;

            //                }
            //            }

            //        }

            //        if (contador > 0)
            //        {
            //            labelD = labelD + "'" + dias.ToString() + "',";
            //            datosD = datosD + contador.ToString() + ",";
            //        }
            //        contador = 0;
            //    }

            //    if (labelD != "")
            //    {
            //        string mes_nombre = Nombre_mes(DateTime.Parse(fecha_sal).Month);
            //        string aux = labelD.Remove(labelD.Length - 1, 1);
            //        string script_str = "var ctx = document.getElementById('myChart2').getContext(\"2d\");" +
            //            " var myChart = new Chart(ctx, { type: \"line\", data:{labels: [" +
            //            labelD.Remove(labelD.Length - 1, 1) + "], datasets: [{label: 'Ventas del mes:" + mes_nombre + "',data: [" + datosD.Remove(datosD.Length - 1, 1) + "]," +
            //                "fill: false," +
            //                "borderColor: 'rgb(42, 89, 211 )'," +
            //                "tension: 0.1" +
            //            "}]," +
            //            "options:" +
            //            "{" +
            //            "scales:" +
            //               " {" +
            //                "yAxes: [{" +
            //                    "ticks:" +
            //                        "{" +
            //                        "beginAtZero: true" +
            //                        "}" +
            //                    "}]" +
            //                "}" +
            //            "}" +
            //        "}" +
            //    "});";

            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "graficoBarras", script_str, true);

            //    }
            //}

            //if (MultiView1.ActiveViewIndex == 2)
            //{

            //    odsMovimientosCuenta.FilterExpression = filteringExpression;
            //    odsMovimientosCuenta.DataBind();
            //    Repeater3.DataBind();

            //}


        }

        protected void lbtnGanancias_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            DataTable dt = new DataTable();
            dt = LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_WEB(lblUsuario.Text, hfFecha1.Value, hfFecha2.Value);
            //labelsInfo("", "", true);
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();
            int contador = 0;
            int total_ventas = 0;
            string labelD = "";
            string datosD = "";
            for (int dias = 1; dias <= 31; dias++)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fecha = DateTime.Parse(dr["FECHA"].ToString());

                    if (fecha.Month == DateTime.Now.Month && fecha.Year == DateTime.Now.Year)
                    {
                        if (fecha.Day == dias)
                        {
                            contador++;
                            total_ventas++;

                        }
                    }

                }

                if (contador > 0)
                {
                    labelD = labelD + "'" + dias.ToString() + "',";
                    datosD = datosD + contador.ToString() + ",";
                }
                contador = 0;
            }

            if (labelD != "")
            {
                string mes_nombre = Nombre_mes(DateTime.Now.Month);
                string aux = labelD.Remove(labelD.Length - 1, 1);
                string script_str = "var ctx = document.getElementById('myChart2').getContext(\"2d\");" +
                    " var myChart = new Chart(ctx, { type: \"line\", data:{labels: [" +
                    labelD.Remove(labelD.Length - 1, 1) + "], datasets: [{label: 'Ventas del mes:" + mes_nombre + "',data: [" + datosD.Remove(datosD.Length - 1, 1) + "]," +
                        "fill: false," +
                        "borderColor: 'rgb(42, 89, 211 )'," +
                        "tension: 0.1" +
                    "}]," +
                    "options:" +
                    "{" +
                    "scales:" +
                       " {" +
                        "yAxes: [{" +
                            "ticks:" +
                                "{" +
                                "beginAtZero: true" +
                                "}" +
                            "}]" +
                        "}" +
                    "}" +
                "}" +
            "});";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "graficoBarras", script_str, true);
            }
            else
            {

            }
            string fecha_sal = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-1";
            string fecha_reg = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            string filteringExpression = string.Format("FECHA >= '{0}' AND FECHA <= '{1} 23:59:59'", fecha_sal, fecha_reg);
            //ds.Tables[0].DefaultView.RowFilter = "State = 'Maharashtra'";
            labelsInfo(fecha_sal, fecha_reg, true);
            //labelsInfo(fecha_sal, fecha_reg, false);
            //DataTable dt_ini = new DataTable();
            //dt_ini = clases.LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS(lblUsuario.Text);
            //dt_ini.DefaultView.RowFilter = filteringExpression;
            //DataTable dt_fil = (dt_ini.DefaultView).ToTable();
            //Repeater1.DataSource = dt_fil;
            //Repeater1.DataBind();

            odsObtieneGanancias.FilterExpression = filteringExpression;
            odsObtieneGanancias.DataBind();
            Repeater2.DataBind();

        }

        protected void btnCanelarIframe_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            DataTable dt = new DataTable();
            dt = LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_WEB(lblUsuario.Text, hfFecha1.Value, hfFecha2.Value);
            labelsInfo("", "", true);
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();
            int contador = 0;
            int total_ventas = 0;
            string labelD = "";
            string datosD = "";
            for (int dias = 1; dias <= 31; dias++)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fecha = DateTime.Parse(dr["FECHA"].ToString());

                    if (fecha.Month == DateTime.Now.Month && fecha.Year == DateTime.Now.Year)
                    {
                        if (fecha.Day == dias)
                        {
                            contador++;
                            total_ventas++;

                        }
                    }

                }

                if (contador > 0)
                {
                    labelD = labelD + "'" + dias.ToString() + "',";
                    datosD = datosD + contador.ToString() + ",";
                }
                contador = 0;
            }

            if (labelD != "")
            {
                string mes_nombre = Nombre_mes(DateTime.Now.Month);
                string aux = labelD.Remove(labelD.Length - 1, 1);
                string script_str = "var ctx = document.getElementById('myChart').getContext(\"2d\");" +
                    " var myChart = new Chart(ctx, { type: \"line\", data:{labels: [" +
                    labelD.Remove(labelD.Length - 1, 1) + "], datasets: [{label: 'Ventas del mes:" + mes_nombre + "',data: [" + datosD.Remove(datosD.Length - 1, 1) + "]," +
                        "fill: false," +
                        "borderColor: 'rgb(42, 89, 211 )'," +
                        "tension: 0.1" +
                    "}]," +
                    "options:" +
                    "{" +
                    "scales:" +
                       " {" +
                        "yAxes: [{" +
                            "ticks:" +
                                "{" +
                                "beginAtZero: true" +
                                "}" +
                            "}]" +
                        "}" +
                    "}" +
                "}" +
            "});";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "graficoBarras", script_str, true);
            }
            else
            {

            }
        }

        protected void lbtnVer_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            //DataTable dt = clases.LocalBD.PR_OBTIENE_BOLETOS_TODOS(lblUsuario.Text);
            string url = "";
            DataTable dtPass = new DataTable();
            dtPass.Columns.Add("NOMBRE");
            dtPass.Columns.Add("APELLIDO");
            dtPass.Columns.Add("TIPO");
            DataTable dt = new DataTable();
            dt = LocalBD.PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE(id);
            int i = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    //Session["datos_iframe"] = id + "|" + dr["TOTALCOBRAR"].ToString() + "|" + dr["MONEDA"].ToString() + "|" + dr["EMAILFACT"].ToString();

                    string[] nob_aux = dr["pasajero"].ToString().Split('|');
                    dtPass.Rows.Add(nob_aux[0], nob_aux[1], nob_aux[2]);



                }
            }
            Repeater4.DataSource = dtPass;
            Repeater4.DataBind();
            //myIframe.Src = url;
            MultiView1.ActiveViewIndex = 3;
        }

        protected void btnVolverReporte_Click(object sender, EventArgs e)
        {


            MultiView1.ActiveViewIndex = 0;
        }
    }
}