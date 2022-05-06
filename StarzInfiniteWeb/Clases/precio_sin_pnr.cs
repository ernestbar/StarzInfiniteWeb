using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarzInfiniteWeb
{
    public class precio_sin_pnr
    {
        public string error { get; set; }
        //public IList<string> datos { get; set; }
        public DatosSP datos { get; set; }
        public class DatosSP
        {
            public double monto_total { get; set; }
            public double monto_total_sin_impuestos { get; set; }
            public string adultos { get; set; }
            public int menores { get; set; }
            public string infantes { get; set; }
            public string moneda { get; set; }
            public double monto_total_impuestos { get; set; }
            //public IList<Segmentos1> SEGMENTOS { get; set; }
            public DetallesSP detalle { get; set; }


        }

    }
    public class DetallesSP
    {
        public ADTs ADT { get; set; }
        public CHDs CHD { get; set; }
        public INFs INF { get; set; }


    }
    public class ADTs
    {
        public string numero_pax { get; set; }
        public string monto_impuestos_tipo_pax { get; set; }
        public string monto_sin_impuestos_tipo_pax { get; set; }
        public string monto_total_por_tipo_pax { get; set; }
        public string moneda { get; set; }
        public IList<ImpuestosSP> impuestos { get; set; }

    }
    public class CHDs
    {
        public string numero_pax { get; set; }
        public string monto_impuestos_tipo_pax { get; set; }
        public string monto_sin_impuestos_tipo_pax { get; set; }
        public string monto_total_por_tipo_pax { get; set; }
        public string moneda { get; set; }
        public IList<ImpuestosSP> impuestos { get; set; }

    }
    public class INFs
    {
        public string numero_pax { get; set; }
        public string monto_impuestos_tipo_pax { get; set; }
        public string monto_sin_impuestos_tipo_pax { get; set; }
        public string monto_total_por_tipo_pax { get; set; }
        public string moneda { get; set; }
        public IList<ImpuestosSP> impuestos { get; set; }

    }

    public class ImpuestosSP
    {
        public string monto { get; set; }
        public string tipo { get; set; }

    }
}