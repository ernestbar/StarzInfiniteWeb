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
    public class datos_bd_local
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        public static Double PR_OBTIENE_COMISION_UPFRONT(string pv_usuario, string pv_rutaorigen, string pv_rutadestino,
            string pv_vueloorigen, string pv_vuelodestino, double pd_monto_vuelo, string fecha_vuelo)
        {
            try
            {
                Double resultado = 0;
                DateTime pd_fecha_vuelo = DateTime.Parse(fecha_vuelo);
                DbCommand cmd = db1.GetStoredProcCommand("PR_OBTIENE_COMISION_UPFRONT");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "pv_usuario", DbType.String, pv_usuario); // Enviar el código del usuario conectado
                db1.AddInParameter(cmd, "pv_rutaorigen", DbType.String, pv_rutaorigen);
                if (pv_rutadestino == "")
                    db1.AddInParameter(cmd, "pv_rutadestino", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "pv_rutadestino", DbType.String, pv_rutadestino);
                if (pv_vueloorigen == "")
                    db1.AddInParameter(cmd, "pv_vueloorigen", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "pv_vueloorigen", DbType.String, pv_vueloorigen);
                if (pv_vuelodestino == "")
                    db1.AddInParameter(cmd, "pv_vuelodestino", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "pv_vuelodestino", DbType.String, pv_vuelodestino);

                db1.AddInParameter(cmd, "pd_monto_vuelo", DbType.Double, pd_monto_vuelo);
                db1.AddInParameter(cmd, "pd_fecha_vuelo", DbType.DateTime, pd_fecha_vuelo);
                db1.AddOutParameter(cmd, "pd_comision", DbType.Double, 15);

                db1.ExecuteNonQuery(cmd);
                //DataTable dt= db1.ExecuteDataSet(cmd).Tables[0];
                //foreach
                resultado = (Double)db1.GetParameterValue(cmd, "pd_comision");
                return resultado;
            }
            catch (Exception es)
            {
                return 0;
            }

        }

        public static DataTable PR_GET_NOTIFICACIONES()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_NOTIFICACIONES");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception es)
            {
                DataTable dt = new DataTable();
                return dt;
            }

        }
    }
}