using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarzInfiniteWeb
{
    public class Reservas_kiu
    {
        public class Impuestos_tasas
        {
            public string taxIndicator { get; set; }
            public string taxCurrency { get; set; }
            public string taxAmount { get; set; }
            public string taxCountryCode { get; set; }
            public string taxNatureCode { get; set; }

        }
        public class ADT
        {
            public string costo { get; set; }
            public string moneda { get; set; }
            public string monto_sin_impuestos { get; set; }
            public string total_impuestos { get; set; }
            public IList<Impuestos_tasas> impuestos_tasas { get; set; }

        }
        public class CHD
        {
            public string costo { get; set; }
            public string moneda { get; set; }
            public string monto_sin_impuestos { get; set; }
            public string total_impuestos { get; set; }
            public IList<Impuestos_tasas> impuestos_tasas { get; set; }

        }
        public class INF
        {
            public string costo { get; set; }
            public string moneda { get; set; }
            public string monto_sin_impuestos { get; set; }
            public string total_impuestos { get; set; }
            public IList<Impuestos_tasas> impuestos_tasas { get; set; }

        }

        public class YCD
        {
            public string costo { get; set; }
            public string moneda { get; set; }
            public string monto_sin_impuestos { get; set; }
            public string total_impuestos { get; set; }
            public IList<Impuestos_tasas> impuestos_tasas { get; set; }

        }

        public class SNN
        {
            public string costo { get; set; }
            public string moneda { get; set; }
            public string monto_sin_impuestos { get; set; }
            public string total_impuestos { get; set; }
            public IList<Impuestos_tasas> impuestos_tasas { get; set; }

        }
        public class Datos_por_tipo
        {
            public IList<ADT> ADT { get; set; }
            public IList<CHD> CHD { get; set; }
            public IList<INF> INF { get; set; }
            public IList<INF> YCD { get; set; }
            public IList<INF> SNN { get; set; }


        }
        public class Itinerario
        {
            public string depDate { get; set; }
            public string depTime { get; set; }
            public string arrDate { get; set; }
            public string arrTime { get; set; }
            public string cityCode_origen { get; set; }
            public string cityCode_destino { get; set; }
            public string identification { get; set; }
            public string classOfService { get; set; }
            public string controlNumber { get; set; }

        }
        public class Pasajeros
        {
            public string nombre { get; set; }
            public string tipo { get; set; }
            public string apellido { get; set; }
            public string quantity { get; set; }
            public string foid { get; set; }
            public string reference { get; set; }
            public string ticket_long { get; set; }
            public string ticket { get; set; }

        }
        public class Datos
        {
            public string pnr { get; set; }
            public decimal total_acobrar { get; set; }
            public string moneda { get; set; }
            public decimal total_impuestos { get; set; }
            public decimal monto_sin_impuestos { get; set; }
            public decimal total_adt { get; set; }
            public decimal total_adt_impuestos { get; set; }
            public decimal total_adt_sin_impuestos { get; set; }
            public decimal total_chd { get; set; }
            public decimal total_chd_impuestos { get; set; }
            public decimal total_chd_sin_impuestos { get; set; }
            public decimal total_inf { get; set; }
            public decimal total_inf_impuestos { get; set; }
            public decimal total_inf_sin_impuestos { get; set; }
            public string fecha_limite_emision { get; set; }
            public string correo_titular { get; set; }
            public IList<Datos_por_tipo> datos_por_tipo { get; set; }
            public string SessionId { get; set; }
            public string SecurityToken { get; set; }
            public IList<Itinerario> itinerario { get; set; }
            public IList<Pasajeros> pasajeros { get; set; }

        }
        public class Application
        {
            public string error { get; set; }
            public Datos datos { get; set; }

        }
    }
}