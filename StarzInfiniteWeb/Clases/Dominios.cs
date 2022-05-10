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
    public class Dominios
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        public static DataTable Lista(string PV_DOMINIO)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_DOMINIOS");
                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, PV_DOMINIO);
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

        public static DataTable Lista2(string PV_DOMINIO, string PV_PRODUCTO)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DOMINIO_LISTAS");
                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, PV_DOMINIO);
                db1.AddInParameter(cmd, "PV_PRODUCTO", DbType.String, PV_PRODUCTO);
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