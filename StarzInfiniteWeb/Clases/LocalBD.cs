using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace StarzInfiniteWeb
{
    public class LocalBD
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        public static string PUT_INGRESA_TICKETS(string pv_tipo_operacion, string pv_usuario, string pv_nro_pnr, string pv_tourcode,
                    string pv_datosfacturacion, string pv_emailfact, string pv_telefonofact, string pv_origenida,
                    string pv_destinoida, DateTime ps_fechaida, string pv_claseida, string pv_carrierida, string pv_numerovueloida,
                    string pv_origenvuelta, string pv_desitinovuelta, DateTime pd_fechavuelta, string pv_clasevuelta,
                    string pv_carriervuelta, string pv_numerovuelovuelta, DateTime pd_fechalimiteemision, decimal pd_totalcobrar,
                    string pv_moneda, decimal pd_totalimpuestos, decimal pd_montosinimpuestos, string pv_sessionid,
                    string pv_securitytogen)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PUT_INGRESA_TICKETS");
                db1.AddInParameter(cmd, "pv_tipo_operacion", DbType.String, pv_tipo_operacion);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddInParameter(cmd, "pv_nro_pnr", DbType.String, pv_nro_pnr);
                db1.AddInParameter(cmd, "pv_tourcode", DbType.String, pv_tourcode);
                db1.AddInParameter(cmd, "pv_datosfacturacion", DbType.String, pv_datosfacturacion);
                db1.AddInParameter(cmd, "pv_emailfact", DbType.String, pv_emailfact);
                db1.AddInParameter(cmd, "pv_telefonofact", DbType.String, pv_telefonofact);

                db1.AddInParameter(cmd, "pv_origenida", DbType.String, pv_origenida);
                db1.AddInParameter(cmd, "pv_destinoida", DbType.String, pv_destinoida);
                db1.AddInParameter(cmd, "ps_fechaida", DbType.DateTime, ps_fechaida);
                db1.AddInParameter(cmd, "pv_claseida", DbType.String, pv_claseida);
                db1.AddInParameter(cmd, "pv_carrierida", DbType.String, pv_carrierida);
                db1.AddInParameter(cmd, "pv_numerovueloida", DbType.String, pv_numerovueloida);

                if (pv_origenvuelta == "")
                {
                    db1.AddInParameter(cmd, "pv_origenvuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pv_desitinovuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pd_fechavuelta", DbType.DateTime, null);
                    db1.AddInParameter(cmd, "pv_clasevuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pv_carriervuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pv_numerovuelovuelta", DbType.String, null);
                }
                else
                {
                    db1.AddInParameter(cmd, "pv_origenvuelta", DbType.String, pv_origenvuelta);
                    db1.AddInParameter(cmd, "pv_desitinovuelta", DbType.String, pv_desitinovuelta);
                    db1.AddInParameter(cmd, "pd_fechavuelta", DbType.DateTime, pd_fechavuelta);
                    db1.AddInParameter(cmd, "pv_clasevuelta", DbType.String, pv_clasevuelta);
                    db1.AddInParameter(cmd, "pv_carriervuelta", DbType.String, pv_carriervuelta);
                    db1.AddInParameter(cmd, "pv_numerovuelovuelta", DbType.String, pv_numerovuelovuelta);
                }


                db1.AddInParameter(cmd, "pd_fechalimiteemision", DbType.DateTime, pd_fechalimiteemision);
                db1.AddInParameter(cmd, "pd_totalcobrar", DbType.Decimal, pd_totalcobrar);
                db1.AddInParameter(cmd, "pv_moneda", DbType.String, pv_moneda);
                db1.AddInParameter(cmd, "pd_totalimpuestos", DbType.Decimal, pd_totalimpuestos);
                db1.AddInParameter(cmd, "pd_montosinimpuestos", DbType.Decimal, pd_montosinimpuestos);
                db1.AddInParameter(cmd, "pv_sessionid", DbType.String, pv_sessionid);
                db1.AddInParameter(cmd, "pv_securitytogen", DbType.String, pv_securitytogen);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_COD_CLIENTE_TICKET", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";
                string PV_COD_CLIENTE_TICKET = "";
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_COD_CLIENTE_TICKET").ToString()))
                    PV_COD_CLIENTE_TICKET = "";
                else
                    PV_COD_CLIENTE_TICKET = (string)db1.GetParameterValue(cmd, "PV_COD_CLIENTE_TICKET");


                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_COD_CLIENTE_TICKET;
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString() + "|0";
            }

        }

        public static string PUT_INGRESA_TICKETS_WEB(string pv_tipo_operacion, string pv_usuario, string pv_nro_pnr, string pv_tourcode,
                    string pv_datosfacturacion, string pv_emailfact, string pv_telefonofact, string pv_origenida,
                    string pv_destinoida, DateTime ps_fechaida, string pv_claseida, string pv_carrierida, string pv_numerovueloida,
                    string pv_origenvuelta, string pv_desitinovuelta, DateTime pd_fechavuelta, string pv_clasevuelta,
                    string pv_carriervuelta, string pv_numerovuelovuelta, DateTime pd_fechalimiteemision, decimal pd_totalcobrar,
                    string pv_moneda, decimal pd_totalimpuestos, decimal pd_montosinimpuestos, string pv_sessionid,
                    string pv_securitytogen,string pv_horaorigenida,string pv_horadestinoida,string pv_horaorigenvuelta,
                    string pv_horadesitinovuelta,DateTime ps_fecha_llegada_ida, DateTime ps_fecha_llegada_vuelta)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PUT_INGRESA_TICKETS_WEB");
                db1.AddInParameter(cmd, "pv_tipo_operacion", DbType.String, pv_tipo_operacion);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddInParameter(cmd, "pv_nro_pnr", DbType.String, pv_nro_pnr);
                db1.AddInParameter(cmd, "pv_tourcode", DbType.String, pv_tourcode);
                db1.AddInParameter(cmd, "pv_datosfacturacion", DbType.String, pv_datosfacturacion);
                db1.AddInParameter(cmd, "pv_emailfact", DbType.String, pv_emailfact);
                db1.AddInParameter(cmd, "pv_telefonofact", DbType.String, pv_telefonofact);

                db1.AddInParameter(cmd, "pv_origenida", DbType.String, pv_origenida);
                db1.AddInParameter(cmd, "pv_destinoida", DbType.String, pv_destinoida);
                db1.AddInParameter(cmd, "ps_fechaida", DbType.DateTime, ps_fechaida);
                db1.AddInParameter(cmd, "ps_fecha_llegada_ida", DbType.DateTime, ps_fecha_llegada_ida);
                db1.AddInParameter(cmd, "pv_claseida", DbType.String, pv_claseida);
                db1.AddInParameter(cmd, "pv_carrierida", DbType.String, pv_carrierida);
                db1.AddInParameter(cmd, "pv_numerovueloida", DbType.String, pv_numerovueloida);
                db1.AddInParameter(cmd, "pv_horaorigenida", DbType.String, pv_horaorigenida);
                db1.AddInParameter(cmd, "pv_horadestinoida", DbType.String, pv_horadestinoida);

                if (pv_origenvuelta == "")
                {
                    db1.AddInParameter(cmd, "pv_origenvuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pv_desitinovuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pd_fechavuelta", DbType.DateTime, null);
                    db1.AddInParameter(cmd, "ps_fecha_llegada_vuelta", DbType.DateTime, null);
                    db1.AddInParameter(cmd, "pv_clasevuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pv_carriervuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pv_numerovuelovuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pv_horaorigenvuelta", DbType.String, null);
                    db1.AddInParameter(cmd, "pv_horadesitinovuelta", DbType.String, null);
                }
                else
                {
                    db1.AddInParameter(cmd, "pv_origenvuelta", DbType.String, pv_origenvuelta);
                    db1.AddInParameter(cmd, "pv_desitinovuelta", DbType.String, pv_desitinovuelta);
                    db1.AddInParameter(cmd, "pd_fechavuelta", DbType.DateTime, pd_fechavuelta);
                    db1.AddInParameter(cmd, "ps_fecha_llegada_vuelta", DbType.DateTime, ps_fecha_llegada_vuelta);
                    db1.AddInParameter(cmd, "pv_clasevuelta", DbType.String, pv_clasevuelta);
                    db1.AddInParameter(cmd, "pv_carriervuelta", DbType.String, pv_carriervuelta);
                    db1.AddInParameter(cmd, "pv_numerovuelovuelta", DbType.String, pv_numerovuelovuelta);
                    db1.AddInParameter(cmd, "pv_horaorigenvuelta", DbType.String, pv_horaorigenvuelta);
                    db1.AddInParameter(cmd, "pv_horadesitinovuelta", DbType.String, pv_horadesitinovuelta);
                }


                db1.AddInParameter(cmd, "pd_fechalimiteemision", DbType.DateTime, pd_fechalimiteemision);
                db1.AddInParameter(cmd, "pd_totalcobrar", DbType.Decimal, pd_totalcobrar);
                db1.AddInParameter(cmd, "pv_moneda", DbType.String, pv_moneda);
                db1.AddInParameter(cmd, "pd_totalimpuestos", DbType.Decimal, pd_totalimpuestos);
                db1.AddInParameter(cmd, "pd_montosinimpuestos", DbType.Decimal, pd_montosinimpuestos);
                db1.AddInParameter(cmd, "pv_sessionid", DbType.String, pv_sessionid);
                db1.AddInParameter(cmd, "pv_securitytogen", DbType.String, pv_securitytogen);

                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_COD_CLIENTE_TICKET", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";
                string PV_COD_CLIENTE_TICKET = "";
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_COD_CLIENTE_TICKET").ToString()))
                    PV_COD_CLIENTE_TICKET = "";
                else
                    PV_COD_CLIENTE_TICKET = (string)db1.GetParameterValue(cmd, "PV_COD_CLIENTE_TICKET");


                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_COD_CLIENTE_TICKET;
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString() + "|0";
            }

        }

        public static string PUT_INGRESA_TICKETS_DET(string pv_tipo_operacion, string pv_usuario, string pv_nombrePasajero, string pv_apellidoPasajero,
                    string pv_tipo_docPasjero, string pv_documentoPasajero, DateTime pd_fecha_nacimiento, decimal pd_costo,
                    string pv_moneda, decimal pd_montosinimpuestos, decimal pd_total_impuestos, string pv_cod_cliente_ticket)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PUT_INGRESA_TICKETS_DET");
                db1.AddInParameter(cmd, "pv_tipo_operacion", DbType.String, pv_tipo_operacion);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddInParameter(cmd, "pv_nombrePasajero", DbType.String, pv_nombrePasajero);
                db1.AddInParameter(cmd, "pv_apellidoPasajero", DbType.String, pv_apellidoPasajero);
                db1.AddInParameter(cmd, "pv_tipo_docPasjero", DbType.String, pv_tipo_docPasjero);
                db1.AddInParameter(cmd, "pv_documentoPasajero", DbType.String, pv_documentoPasajero);
                db1.AddInParameter(cmd, "pd_fecha_nacimiento", DbType.DateTime, pd_fecha_nacimiento);
                db1.AddInParameter(cmd, "pd_costo", DbType.Decimal, pd_costo);
                db1.AddInParameter(cmd, "pv_moneda", DbType.String, pv_moneda);
                db1.AddInParameter(cmd, "pd_montosinimpuestos", DbType.Decimal, pd_montosinimpuestos);
                db1.AddInParameter(cmd, "pd_total_impuestos", DbType.Decimal, pd_total_impuestos);
                db1.AddInParameter(cmd, "pv_cod_cliente_ticket", DbType.String, pv_cod_cliente_ticket);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR;
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString();
            }

        }

        public static string abm_cambia_data_tickets(string PV_TIPO_OPERACION, string PV_NRO_PNR, string PV_COD_TICKET_DETALLE, string PV_FORMA_PAGO,
                    string PV_USUARIO_RESERVA, string PV_NRO_TICKET,  string pv_usuario_reg)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("abm_cambia_data_tickets");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION);
                if(PV_NRO_PNR=="")
                    db1.AddInParameter(cmd, "PV_NRO_PNR", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_NRO_PNR", DbType.String, PV_NRO_PNR);
                if(PV_COD_TICKET_DETALLE=="")
                    db1.AddInParameter(cmd, "PV_COD_TICKET_DETALLE", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_COD_TICKET_DETALLE", DbType.String, PV_COD_TICKET_DETALLE);
                if(PV_FORMA_PAGO=="SELECCIONAR")
                    db1.AddInParameter(cmd, "PV_FORMA_PAGO", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_FORMA_PAGO", DbType.String, PV_FORMA_PAGO);
                if(PV_USUARIO_RESERVA=="SELECCIONAR")
                    db1.AddInParameter(cmd, "PV_USUARIO_RESERVA", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_USUARIO_RESERVA", DbType.String, PV_USUARIO_RESERVA);
                if(PV_NRO_TICKET=="")
                    db1.AddInParameter(cmd, "PV_NRO_TICKET", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_NRO_TICKET", DbType.String, PV_NRO_TICKET);
                db1.AddInParameter(cmd, "pv_usuario_reg", DbType.String, pv_usuario_reg);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";
                string PV_ERROR = "";
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString();
            }

        }

        public static string PUT_INGRESA_CLIENTES(string pv_usuario, string pv_nombre_cliente, string pv_apellidos, string pv_nro_documento,
                    string pv_email, string pv_telefono)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PUT_INGRESA_CLIENTES");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddInParameter(cmd, "pv_nombre_cliente", DbType.String, pv_nombre_cliente);
                db1.AddInParameter(cmd, "pv_apellidos", DbType.String, pv_apellidos);
                db1.AddInParameter(cmd, "pv_nro_documento", DbType.String, pv_nro_documento);
                db1.AddInParameter(cmd, "pv_email", DbType.String, pv_email);
                db1.AddInParameter(cmd, "pv_telefono", DbType.String, pv_telefono);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");



                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR;
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString();
            }

        }

        public static string abm_cambia_tickets(string PV_TIPO_OPERACION, string PV_NRO_PNR, string PV_ESTADO, string pv_usuario_reg)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("abm_cambia_tickets");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_NRO_PNR", DbType.String, PV_NRO_PNR);
                db1.AddInParameter(cmd, "PV_ESTADO", DbType.String, PV_ESTADO);
                db1.AddInParameter(cmd, "pv_usuario_reg", DbType.String, pv_usuario_reg);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";
                string PV_ERROR = "";

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");


                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString() + "|";
            }

        }

        public static string PR_GET_FM(string PV_OPERADOR, string PV_CLASE_IDA, string PV_CLASE_VUELTA, string PV_ORIGEN,
                    string PV_DESTINO, decimal PV_MONTO_IDA, decimal PV_MONTO_VUELTA, int PI_CANTIDAD_PASAJEROS)
        {
            try
            {
                string resultado = "0";
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_FM");
                db1.AddInParameter(cmd, "PV_OPERADOR", DbType.String, PV_OPERADOR);
                db1.AddInParameter(cmd, "PV_CLASE_IDA", DbType.String, PV_CLASE_IDA);
                db1.AddInParameter(cmd, "PV_CLASE_VUELTA", DbType.String, PV_CLASE_VUELTA);
                db1.AddInParameter(cmd, "PV_ORIGEN", DbType.String, PV_ORIGEN);
                db1.AddInParameter(cmd, "PV_DESTINO", DbType.String, PV_DESTINO);
                db1.AddInParameter(cmd, "PV_MONTO_IDA", DbType.String, PV_MONTO_IDA);
                db1.AddInParameter(cmd, "PV_MONTO_VUELTA", DbType.String, PV_MONTO_VUELTA);
                db1.AddInParameter(cmd, "PI_CANTIDAD_PASAJEROS", DbType.String, PI_CANTIDAD_PASAJEROS);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        resultado = dr["MONTO_FM"].ToString();
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                //DataTable dt = new DataTable();
                return ex.ToString();
            }

        }
        public static string PR_GET_PREPAGO(string PV_USUARIO)
        {
            try
            {
                string resultado = "0";
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_PREPAGO");
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, PV_USUARIO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        resultado = dr["TIENE_PREPAGO"].ToString();
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                //DataTable dt = new DataTable();
                return ex.ToString();
            }

        }

        public static DataTable PR_GET_DATOSPASARELAPAGO(string PV_NRO_PNR)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOSPASARELAPAGO");
                db1.AddInParameter(cmd, "PV_NRO_PNR", DbType.String, PV_NRO_PNR);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static string PR_GET_FEE(string PV_OPERADOR, string PV_TIPO_VUELO, string PV_TIPO_VENTA, string PV_ORIGEN,
                    string PV_DESTINO, string PV_RUTA)
        {
            try
            {
                string resultado = "0";
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_FEE_WEB");
                db1.AddInParameter(cmd, "PV_OPERADOR", DbType.String, PV_OPERADOR);
                db1.AddInParameter(cmd, "PV_TIPO_VUELO", DbType.String, PV_TIPO_VUELO);
                db1.AddInParameter(cmd, "PV_TIPO_VENTA", DbType.String, PV_TIPO_VENTA);
                db1.AddInParameter(cmd, "PV_ORIGEN", DbType.String, PV_ORIGEN);
                db1.AddInParameter(cmd, "PV_DESTINO", DbType.String, PV_DESTINO);
                db1.AddInParameter(cmd, "PV_RUTA", DbType.String, PV_RUTA);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        resultado = dr["FEE_AGENCIA"].ToString() + "|" + dr["FEE_TOTAL"].ToString() + "|" + dr["FEE_SZI"].ToString() + "|" + dr["FEE_BROKER"].ToString() + "|" + dr["COMISION_DESDE"].ToString() + "|" + dr["COMISION_HASTA"].ToString();
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                //DataTable dt = new DataTable();
                return ex.ToString();
            }

        }

        public static string PR_GET_FEE_WEB_ITINERARIO(string PV_OPERADOR, string PV_TIPO_VUELO, string PV_TIPO_VENTA, string PV_ORIGEN,
                    string PV_DESTINO, string PV_RUTA, int PI_CANT_PASAJEROS)
        {
            try
            {
                string resultado = "0";
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_FEE_WEB_ITINERARIO");
                db1.AddInParameter(cmd, "PV_OPERADOR", DbType.String, PV_OPERADOR);
                db1.AddInParameter(cmd, "PV_TIPO_VUELO", DbType.String, PV_TIPO_VUELO);
                db1.AddInParameter(cmd, "PV_TIPO_VENTA", DbType.String, PV_TIPO_VENTA);
                db1.AddInParameter(cmd, "PV_ORIGEN", DbType.String, PV_ORIGEN);
                db1.AddInParameter(cmd, "PV_DESTINO", DbType.String, PV_DESTINO);
                db1.AddInParameter(cmd, "PV_RUTA", DbType.String, PV_RUTA);
                db1.AddInParameter(cmd, "PI_CANT_PASAJEROS", DbType.String, PI_CANT_PASAJEROS);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        resultado = dr["FEE_TOTAL"].ToString();
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                //DataTable dt = new DataTable();
                return ex.ToString();
            }

        }

        public static string PR_GET_FEE_WEB_ITINERARIO_ENVIO(string PV_OPERADOR, string PV_TIPO_VUELO, string PV_TIPO_VENTA, string PV_ORIGEN,
                  string PV_DESTINO, string PV_RUTA, int PI_CANT_PASAJEROS)
        {
            try
            {
                string resultado = "0";
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_FEE_WEB_ITINERARIO_ENVIO");
                db1.AddInParameter(cmd, "PV_OPERADOR", DbType.String, PV_OPERADOR);
                db1.AddInParameter(cmd, "PV_TIPO_VUELO", DbType.String, PV_TIPO_VUELO);
                db1.AddInParameter(cmd, "PV_TIPO_VENTA", DbType.String, PV_TIPO_VENTA);
                db1.AddInParameter(cmd, "PV_ORIGEN", DbType.String, PV_ORIGEN);
                db1.AddInParameter(cmd, "PV_DESTINO", DbType.String, PV_DESTINO);
                db1.AddInParameter(cmd, "PV_RUTA", DbType.String, PV_RUTA);
                db1.AddInParameter(cmd, "PI_CANT_PASAJEROS", DbType.String, PI_CANT_PASAJEROS);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        resultado = dr["FEE_AGENCIA"].ToString() + "|" + dr["FEE_TOTAL"].ToString() + "|" + dr["FEE_SZI"].ToString() + "|" + dr["FEE_BROKER"].ToString() + "|" + dr["COMISION_DESDE"].ToString() + "|" + dr["COMISION_HASTA"].ToString();
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                //DataTable dt = new DataTable();
                return ex.ToString();
            }

        }

        public static string PR_GET_INTERNACIONAL_NACIONAL(string PV_ORIGEN, string PV_DESTINO)
        {
            try
            {
                string resultado = "0";
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_INTERNACIONAL_NACIONAL");
                db1.AddInParameter(cmd, "PV_ORIGEN", DbType.String, PV_ORIGEN);
                db1.AddInParameter(cmd, "PV_DESTINO", DbType.String, PV_DESTINO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        resultado = dr["TIPO_CAMBIO"].ToString();
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                //DataTable dt = new DataTable();
                return ex.ToString();
            }

        }
        public static string PUT_PAGO_EMISION(string pv_tipo_operacion, string pv_usuario, string pv_nro_pnr, string pv_detalle)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PUT_PAGO_EMISION");
                db1.AddInParameter(cmd, "pv_tipo_operacion", DbType.String, pv_tipo_operacion);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddInParameter(cmd, "pv_nro_pnr", DbType.String, pv_nro_pnr);
                db1.AddInParameter(cmd, "pv_detalle", DbType.String, pv_detalle);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");



                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR;
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString();
            }

        }

        public static DataTable PR_OBTIENE_BOLETOS_VENDIDOS_MANUAL_IND(string pv_COD_CLIENTE_TICKET)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_VENDIDOS_MANUAL_IND");
                db1.AddInParameter(cmd, "pv_COD_CLIENTE_TICKET", DbType.String, pv_COD_CLIENTE_TICKET);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static string PUT_INGRESA_TICKETS_MANUAL(string pv_tipo_operacion, string pv_usuario, string pv_producto, string pv_proveedor,
            string pv_nro_pnr, string pv_tourcode, string pv_datosfacturacion, string pv_emailfact,
            string pv_telefonofact, string pv_origenida, string pv_destinoida, string ps_fechaida,
            string pv_claseida, string pv_carrierida, string pv_numerovueloida, string pv_origenvuelta,
            string pv_desitinovuelta, string pd_fechavuelta, string pv_clasevuelta, string pv_carriervuelta,
            string pv_numerovuelovuelta, string pd_fechalimiteemision, string pd_fecha_regitro, string pv_broker,
            decimal pd_totalcobrar, string pv_moneda, decimal pd_totalimpuestos, decimal pd_montosinimpuestos,
            string pv_tipo_venta, decimal pd_comisionbroker, string pv_detalle, string pv_tipo_vuelo, string PV_COD_CLIENTE_TICKET)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PUT_INGRESA_TICKETS_MANUAL");
                db1.AddInParameter(cmd, "pv_tipo_operacion", DbType.String, pv_tipo_operacion);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddInParameter(cmd, "pv_producto", DbType.String, pv_producto);
                db1.AddInParameter(cmd, "pv_proveedor", DbType.String, pv_proveedor);
                db1.AddInParameter(cmd, "pv_nro_pnr", DbType.String, pv_nro_pnr);
                db1.AddInParameter(cmd, "pv_tourcode", DbType.String, pv_tourcode);
                db1.AddInParameter(cmd, "pv_datosfacturacion", DbType.String, pv_datosfacturacion);
                db1.AddInParameter(cmd, "pv_emailfact", DbType.String, pv_emailfact);
                db1.AddInParameter(cmd, "pv_telefonofact", DbType.String, pv_telefonofact);
                db1.AddInParameter(cmd, "pv_origenida", DbType.String, pv_origenida);
                db1.AddInParameter(cmd, "pv_destinoida", DbType.String, pv_destinoida);
                db1.AddInParameter(cmd, "ps_fechaida", DbType.DateTime, ps_fechaida);
                db1.AddInParameter(cmd, "pv_claseida", DbType.String, pv_claseida);
                db1.AddInParameter(cmd, "pv_carrierida", DbType.String, pv_carrierida);
                db1.AddInParameter(cmd, "pv_numerovueloida", DbType.String, pv_numerovueloida);
                db1.AddInParameter(cmd, "pv_origenvuelta", DbType.String, pv_origenvuelta);
                db1.AddInParameter(cmd, "pv_desitinovuelta", DbType.String, pv_desitinovuelta);
                db1.AddInParameter(cmd, "pd_fechavuelta", DbType.DateTime, pd_fechavuelta);
                db1.AddInParameter(cmd, "pv_clasevuelta", DbType.String, pv_clasevuelta);
                db1.AddInParameter(cmd, "pv_carriervuelta", DbType.String, pv_carriervuelta);
                db1.AddInParameter(cmd, "pv_numerovuelovuelta", DbType.String, pv_numerovuelovuelta);
                db1.AddInParameter(cmd, "pd_fechalimiteemision", DbType.DateTime, pd_fechalimiteemision);
                db1.AddInParameter(cmd, "pd_fecha_regitro", DbType.String, pd_fecha_regitro);
                db1.AddInParameter(cmd, "pv_broker", DbType.String, pv_broker);
                db1.AddInParameter(cmd, "pd_totalcobrar", DbType.Decimal, pd_totalcobrar);
                db1.AddInParameter(cmd, "pv_moneda", DbType.String, pv_moneda);
                db1.AddInParameter(cmd, "pd_totalimpuestos", DbType.Decimal, pd_totalimpuestos);
                db1.AddInParameter(cmd, "pd_montosinimpuestos", DbType.Decimal, pd_montosinimpuestos);
                db1.AddInParameter(cmd, "pv_tipo_venta", DbType.String, pv_tipo_venta);
                db1.AddInParameter(cmd, "pd_comisionbroker", DbType.Decimal, pd_comisionbroker);
                db1.AddInParameter(cmd, "pv_detalle", DbType.String, pv_detalle);
                db1.AddInParameter(cmd, "pv_tipo_vuelo", DbType.String, pv_tipo_vuelo);
                if(PV_COD_CLIENTE_TICKET=="")
                    db1.AddInParameter(cmd, "PV_COD_CLIENTE_TICKET", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_COD_CLIENTE_TICKET", DbType.String, PV_COD_CLIENTE_TICKET);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");



                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR;
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString();
            }

        }

        public static string PR_OBTIENE_HOME_VENTAS(string pv_usuario)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_HOME_VENTAS");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddOutParameter(cmd, "pv_empresa", DbType.String, 450);
                db1.AddOutParameter(cmd, "pv_tipo_participane", DbType.String, 450);
                db1.AddOutParameter(cmd, "pv_nombre", DbType.String, 450);
                db1.AddOutParameter(cmd, "pd_saldo_cuenta", DbType.Double, 18);
                db1.AddOutParameter(cmd, "pv_cuena_cte", DbType.String, 450);
                db1.AddOutParameter(cmd, "pd_ganancia_mes", DbType.Double, 18);
                db1.AddOutParameter(cmd, "pd_boletos_mes", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                string pv_empresa = "";
                string pv_tipo_participane = "";
                string pv_nombre = "";
                double pd_saldo_cuenta = 0;
                string pv_cuena_cte = "";
                double pd_ganancia_mes = 0;
                int pd_boletos_mes = 0;


                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pv_empresa").ToString()))
                    pv_empresa = "";
                else
                    pv_empresa = (string)db1.GetParameterValue(cmd, "pv_empresa");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pv_tipo_participane").ToString()))
                    pv_tipo_participane = "";
                else
                    pv_tipo_participane = (string)db1.GetParameterValue(cmd, "pv_tipo_participane");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pv_nombre").ToString()))
                    pv_nombre = "";
                else
                    pv_nombre = (string)db1.GetParameterValue(cmd, "pv_nombre");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pd_saldo_cuenta").ToString()))
                    pd_saldo_cuenta = 0;
                else
                    pd_saldo_cuenta = (double)db1.GetParameterValue(cmd, "pd_saldo_cuenta");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pv_cuena_cte").ToString()))
                    pv_cuena_cte = "";
                else
                    pv_cuena_cte = (string)db1.GetParameterValue(cmd, "pv_cuena_cte");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pd_ganancia_mes").ToString()))
                    pd_ganancia_mes = 0;
                else
                    pd_ganancia_mes = (double)db1.GetParameterValue(cmd, "pd_ganancia_mes");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pd_boletos_mes").ToString()))
                    pd_boletos_mes = 0;
                else
                    pd_boletos_mes = int.Parse(db1.GetParameterValue(cmd, "pd_boletos_mes").ToString());

                resultado = pv_empresa + "|" + pv_tipo_participane + "|" + pv_nombre + "|" + pd_saldo_cuenta.ToString() + "|" + pv_cuena_cte + "|" + pd_ganancia_mes.ToString() + "|" + pd_boletos_mes.ToString();
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString();
            }

        }
        public static DataTable PR_OBTIENE_BOLETOS_TODOS(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_TODOS_web");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_GET_PARTICIPANTES_USUARIO(string PV_TIPO_PARTICIPANTE)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_PARTICIPANTES_USUARIO");
                db1.AddInParameter(cmd, "PV_TIPO_PARTICIPANTE", DbType.String, PV_TIPO_PARTICIPANTE);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static string PR_VALIDA_RESERVAS(string pv_DATOSFACTURACION,string pv_ORIGENIDA,string pv_DESTINOIDA,
            string pv_ORIGENVUELTA,string pv_DESITINOVUELTA,string pv_USUARIO)
        {
            try
            {
                string resultado = "0";
                DbCommand cmd = db1.GetStoredProcCommand("PR_VALIDA_RESERVAS_WEB");
                db1.AddInParameter(cmd, "pv_DATOSFACTURACION", DbType.String, pv_DATOSFACTURACION);
                db1.AddInParameter(cmd, "pv_ORIGENIDA", DbType.String, pv_ORIGENIDA);
                db1.AddInParameter(cmd, "pv_DESTINOIDA", DbType.String, pv_DESTINOIDA);
                if(pv_ORIGENVUELTA=="")
                    db1.AddInParameter(cmd, "pv_ORIGENVUELTA", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "pv_ORIGENVUELTA", DbType.String, pv_ORIGENVUELTA);
                if(pv_DESITINOVUELTA=="")
                    db1.AddInParameter(cmd, "pv_DESITINOVUELTA", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "pv_DESITINOVUELTA", DbType.String, pv_DESITINOVUELTA);
                db1.AddInParameter(cmd, "pv_USUARIO", DbType.String, pv_USUARIO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                foreach (DataRow dr in db1.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    resultado = dr[0].ToString();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return ex.ToString();
                
            }

        }

        public static DataTable PR_OBTIENE_BOLETOS_PNR(string PNR)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_PNR");
                db1.AddInParameter(cmd, "PNR", DbType.String, PNR);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_OBTIENE_TICKETS_WEB(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_TICKETS_WEB");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_OBTIENE_TICKETS_WEB_FILTRO(string pv_usuario, string pv_pnr, string pv_cliente, string pd_fdesde, string pd_fhasta)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_TICKETS_WEB_FILTRO");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                if (String.IsNullOrEmpty(pv_pnr))
                    db1.AddInParameter(cmd, "pv_pnr", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "pv_pnr", DbType.String, pv_pnr);
                if (String.IsNullOrEmpty(pv_cliente))
                    db1.AddInParameter(cmd, "pv_cliente", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "pv_cliente", DbType.String, pv_cliente);
                if (String.IsNullOrEmpty(pd_fdesde))
                    db1.AddInParameter(cmd, "pd_fdesde", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "pd_fdesde", DbType.DateTime, DateTime.Parse(pd_fdesde));
                if (String.IsNullOrEmpty(pd_fhasta))
                    db1.AddInParameter(cmd, "pd_fhasta", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "pd_fhasta", DbType.Date, DateTime.Parse(pd_fhasta));
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_OBTIENE_BOLETOS_VENDIDOS_MANUAL(string pd_fdesde, string pd_fhasta, string pv_pnr, string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_VENDIDOS_MANUAL");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                if (String.IsNullOrEmpty(pv_pnr))
                    db1.AddInParameter(cmd, "pv_NRO_PNR", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "pv_NRO_PNR", DbType.String, pv_pnr);

                if (String.IsNullOrEmpty(pd_fdesde))
                    db1.AddInParameter(cmd, "pd_fechadesde", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "pd_fechadesde", DbType.DateTime, DateTime.Parse(pd_fdesde));
                if (String.IsNullOrEmpty(pd_fhasta))
                    db1.AddInParameter(cmd, "pd_fechahasta", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "pd_fechahasta", DbType.Date, DateTime.Parse(pd_fhasta));
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_OBTIENE_DETALLE_MANUAL(string pv_pnr)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_DETALLE_MANUAL");
                if (String.IsNullOrEmpty(pv_pnr))
                    db1.AddInParameter(cmd, "pv_pnr", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "pv_pnr", DbType.String, pv_pnr);

                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_OBTIENE_REPORTE_GANANCIAS(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_REPORTE_GANANCIAS");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }


        public static DataTable PR_OBTIENE_BOLETOS_VENDIDOS(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_VENDIDOS");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddOutParameter(cmd, "pd_ganancia_mes", DbType.Decimal, 18);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_OBTIENE_BOLETOS_VENDIDOS_WEB(string pv_usuario, string pd_fechadesde, string pd_fechahasta)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_VENDIDOS_WEB");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddInParameter(cmd, "pd_fechadesde", DbType.DateTime, pd_fechadesde);
                db1.AddInParameter(cmd, "pd_fechahasta", DbType.DateTime, pd_fechahasta);
                db1.AddOutParameter(cmd, "pd_ganancia_mes", DbType.Decimal, 18);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_OBTIENE_REPORTE_COUNTER(string pv_usuario, string pd_fechadesde, string pd_fechahasta)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_REPORTE_COUNTER");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                if(pd_fechadesde=="")
                    db1.AddInParameter(cmd, "pd_fechadesde", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "pd_fechadesde", DbType.DateTime, pd_fechadesde);
                if(pd_fechahasta=="")
                    db1.AddInParameter(cmd, "pd_fechahasta", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "pd_fechahasta", DbType.DateTime, pd_fechahasta);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_OBTIENE_REPORTE_BROKER(string pv_usuario, string pd_fechadesde, string pd_fechahasta)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_REPORTE_BROKER");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                if (pd_fechadesde == "")
                    db1.AddInParameter(cmd, "pd_fechadesde", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "pd_fechadesde", DbType.DateTime, pd_fechadesde);
                if (pd_fechahasta == "")
                    db1.AddInParameter(cmd, "pd_fechahasta", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "pd_fechahasta", DbType.DateTime, pd_fechahasta);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_OBTIENE_BOLETOS_VENDIDOS_ADM(string fecha1, string fecha2, string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_VENDIDOS_ADM");
                db1.AddInParameter(cmd, "pd_fechadesde", DbType.String, fecha1);
                db1.AddInParameter(cmd, "pd_fechahasta", DbType.String, fecha2);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_OBTIENE_BOLETOS_VENDIDOS_DET_ADM_ESTADO(DateTime fecha1, DateTime fecha2, string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_VENDIDOS_DET_ADM_ESTADO");
                db1.AddInParameter(cmd, "pd_fechadesde", DbType.DateTime, fecha1);
                db1.AddInParameter(cmd, "pd_fechahasta", DbType.DateTime, fecha2);
                db1.AddInParameter(cmd, "pv_NRO_PNR", DbType.String, null);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_OBTIENE_BOLETOS_VENDIDOS_DET_ADM(DateTime fecha1, DateTime fecha2, string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_VENDIDOS_DET_ADM");
                db1.AddInParameter(cmd, "pd_fechadesde", DbType.DateTime, fecha1);
                db1.AddInParameter(cmd, "pd_fechahasta", DbType.DateTime, fecha2);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE_ADM(string pv_pnr)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE_ADM");
                db1.AddInParameter(cmd, "pv_pnr", DbType.String, pv_pnr);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_OBTIENE_MOVIMIENTOS_CUENTA(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_MOVIMIENTOS_CUENTA");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddOutParameter(cmd, "pd_saldo_cuenta", DbType.Decimal, 18);
                db1.AddOutParameter(cmd, "pv_cuena_cte", DbType.String, 45);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static string PR_OBTIENE_MOVIMIENTOS_CUENTA_totales(string pv_usuario)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_MOVIMIENTOS_CUENTA");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddOutParameter(cmd, "pd_saldo_cuenta", DbType.Decimal, 18);
                db1.AddOutParameter(cmd, "pv_cuena_cte", DbType.String, 45);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                decimal pd_saldo_cuenta = 0;
                string pv_cuena_cte = "";

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pd_saldo_cuenta").ToString()))
                    pd_saldo_cuenta = 0;
                else
                    pd_saldo_cuenta = (decimal)db1.GetParameterValue(cmd, "pd_saldo_cuenta");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pv_cuena_cte").ToString()))
                    pv_cuena_cte = "";
                else
                    pv_cuena_cte = (string)db1.GetParameterValue(cmd, "pv_cuena_cte");

                resultado = pd_saldo_cuenta.ToString() + "|" + pv_cuena_cte;
                return resultado;
            }
            catch (Exception ex)
            {
                ex.ToString();

                return ex.ToString() + "||";
            }

        }
        public static DataTable PR_OBTIENE_REPORTE_REFERIDO(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_REPORTE_REFERIDO");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddOutParameter(cmd, "pd_totaequipo", DbType.String, 45);
                db1.AddOutParameter(cmd, "pd_codigoreferido", DbType.String, 45);
                db1.AddOutParameter(cmd, "pd_totalganancia", DbType.String, 45);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static string PR_OBTIENE_REPORTE_REFERIDO_totales(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_REPORTE_REFERIDO");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddOutParameter(cmd, "pd_totaequipo", DbType.String, 45);
                db1.AddOutParameter(cmd, "pd_codigoreferido", DbType.String, 45);
                db1.AddOutParameter(cmd, "pd_totalganancia", DbType.String, 45);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string pd_totaequipo = "";
                string pd_codigoreferido = "";
                string pd_totalganancia = "";
                string resultado = "";

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pd_totaequipo").ToString()))
                    pd_totaequipo = "";
                else
                    pd_totaequipo = (string)db1.GetParameterValue(cmd, "pd_totaequipo");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pd_codigoreferido").ToString()))
                    pd_codigoreferido = "";
                else
                    pd_codigoreferido = (string)db1.GetParameterValue(cmd, "pd_codigoreferido");

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pd_totalganancia").ToString()))
                    pd_totalganancia = "";
                else
                    pd_totalganancia = (string)db1.GetParameterValue(cmd, "pd_totalganancia");


                resultado = pd_totaequipo + "|" + pd_codigoreferido + "|" + pd_totalganancia;
                return resultado;
            }
            catch (Exception ex)
            {
                ex.ToString();

                return ex.ToString() + "||";
            }

        }

        public static string PR_OBTIENE_GANANCIA_TOTAL(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_GANANCIA_TOTAL");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                db1.AddOutParameter(cmd, "pd_ganancia_mes", DbType.Decimal, 18);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                decimal pd_ganancia_mes = 0;

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pd_ganancia_mes").ToString()))
                    pd_ganancia_mes = 0;
                else
                    pd_ganancia_mes = decimal.Parse(db1.GetParameterValue(cmd, "pd_ganancia_mes").ToString());


                return pd_ganancia_mes.ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();

                return ex.ToString();
            }

        }
        public static DataTable PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE(string pv_pnr)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE");
                db1.AddInParameter(cmd, "pv_pnr", DbType.String, pv_pnr);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_OBTIENE_COMUNICADOS(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_COMUNICADOS");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }


        public static DataTable PR_OBTIENE_CLIENTES(string pv_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_CLIENTES");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
    }
}