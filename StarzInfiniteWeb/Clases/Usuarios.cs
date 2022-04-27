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
    public class Usuarios
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        public static string setValidaCredenciales(string pv_usuario, string pv_password)
        {
            try
            {
                string resultado = "";

                DbCommand cmd = db1.GetStoredProcCommand("setValidaCredencialesWeb");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario); // Enviar el código del usuario conectado
                db1.AddInParameter(cmd, "pv_password", DbType.String, pv_password);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 45);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 45);
                db1.AddOutParameter(cmd, "pv_temporal", DbType.String, 45);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string stadopr, descripcionpr, temporal;
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    stadopr = "";
                else
                    stadopr = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    descripcionpr = "";
                else
                    descripcionpr = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "pv_temporal").ToString()))
                    temporal = "";
                else
                    temporal = (string)db1.GetParameterValue(cmd, "pv_temporal");
                resultado = stadopr + "|" + descripcionpr + "|" + temporal;
                return resultado;

            }
            catch (Exception es)
            {
                return "|sin conexion|";

            }

        }
        public static string PR_OBTIENE_TOKEN(string pv_usuario)
        {
            try
            {
                string resultado = "";

                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_TOKEN");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario); // Enviar el código del usuario conectado
                db1.AddOutParameter(cmd, "pv_token", DbType.String, 45);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);

                resultado = (string)db1.GetParameterValue(cmd, "pv_token");
                return resultado;

            }
            catch (Exception es)
            {
                return "";
            }

        }

        public static Int64 PR_OBTIENE_CANTIDAD_NOTIFICACION(string pv_usuario)
        {
            try
            {
                Int64 resultado = 0;

                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_CANTIDAD_NOTIFICACION");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario); // Enviar el código del usuario conectado
                db1.AddOutParameter(cmd, "pv_notificaciones", DbType.String, 45);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);

                resultado = Int64.Parse(db1.GetParameterValue(cmd, "pv_notificaciones").ToString());
                return resultado;

            }
            catch (Exception es)
            {
                return 0;
            }

        }

        public static int PR_ELIMINA_CANTIDAD_NOTIFICACION(string pv_usuario)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_ELIMINA_CANTIDAD_NOTIFICACION");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario); // Enviar el código del usuario conectado
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);

                return 1;

            }
            catch (Exception es)
            {
                return 0;
            }

        }
        public static string PR_VALIDA_TOKEN(string pv_usuario, string pv_token)
        {
            try
            {
                string resultado = "";

                DbCommand cmd = db1.GetStoredProcCommand("PR_VALIDA_TOKEN");
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario); // Enviar el código del usuario conectado
                db1.AddInParameter(cmd, "pv_token", DbType.String, pv_token); // Enviar el código del usuario conectado
                db1.AddOutParameter(cmd, "pv_valida", DbType.String, 45);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);

                resultado = (string)db1.GetParameterValue(cmd, "pv_valida");
                return resultado;

            }
            catch (Exception es)
            {
                return "";
            }

        }

        public static string PR_CAMBIO_PASSWORD(string PV_TIPO_OPERACION, string PV_USUARIO, string PV_NUMERO_DOCUMENTO, string PV_PASSWORD_ANTERIOR, string PV_PASSWORD_NUEVO, string PV_COD_INVITACION_REFERIDO)
        {
            try
            {
                string resultado = "";

                DbCommand cmd = db1.GetStoredProcCommand("PR_CAMBIO_PASSWORD");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION); // Enviar el código del usuario conectado
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, PV_USUARIO);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, PV_NUMERO_DOCUMENTO);
                db1.AddInParameter(cmd, "PV_PASSWORD_ANTERIOR", DbType.String, PV_PASSWORD_ANTERIOR);
                db1.AddInParameter(cmd, "PV_PASSWORD_NUEVO", DbType.String, PV_PASSWORD_NUEVO);
                if (PV_COD_INVITACION_REFERIDO == "")
                    db1.AddInParameter(cmd, "PV_COD_INVITACION_REFERIDO", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_COD_INVITACION_REFERIDO", DbType.String, PV_COD_INVITACION_REFERIDO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 45);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 45);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 45);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR, PV_DESCRIPCIONPR, PV_ERROR;
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString();

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString();

                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = db1.GetParameterValue(cmd, "PV_ERROR").ToString();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;

                return resultado;

            }
            catch (Exception es)
            {
                return "||";
            }

        }
    }
}