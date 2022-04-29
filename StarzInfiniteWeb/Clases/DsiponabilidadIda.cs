using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;

namespace StarzInfiniteWeb
{
    public class DsiponabilidadIda
    {
        public string error { get; set; }
        public string convenio_adt { get; set; }
        public string convenio_menor { get; set; }
        public string convenio_inf { get; set; }
        //public IList<string> datos { get; set; }
        public List<DATOS> datos { get; set; }

        public class DATOS
        {
            public OPCIONES opciones { get; set; }
            public string precio { get; set; }
            public string moneda { get; set; }
            public string gds { get; set; }
            
            public class OPCIONES
            {
                public List<List<SEGMENTOS>> ida { get; set; }
                public List<List<SEGMENTOS>> vuelta { get; set; }
                //public class IDA
                //{
                //    public List<SEGMENTOS> SEGMENTOS1  { get; set; }
                    
                //}
                public class SEGMENTOS
                {
                    public int segment { get; set; }
                    public int leg { get; set; }
                    public string flightNumber { get; set; }
                    public string boardAirport { get; set; }
                    public string offAirport { get; set; }
                    public string depDate { get; set; }
                    public string ArrivalDate { get; set; }
                    public string depTime { get; set; }
                    public string hora_llegada { get; set; }
                    public string marketCompany { get; set; }
                    public string operCompany { get; set; }
                    public string bookClass { get; set; }
                    public string lugres_disponibles { get; set; }
                    public string duracion { get; set; }
                    public string equipaje { get; set; }
                    public string ld { get; set; }
                }

                //public class VUELTA
                //{
                //    public List<SEGMENTOS> SEGMENTOS1 { get; set; }
                //}

               

            }
        }

        
    }
    
    
}