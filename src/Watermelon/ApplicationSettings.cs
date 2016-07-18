using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watermelon
{
    public class ApplicationSettings
    {
        public WanSettings Wan { get; set; }
        public TicketMasterSettings TicketMaster { get; set; }

        public class WanSettings
        {
            public string Host { get; set; }
            public WanKeys Keys { get; set; }
            public WanEndpoints Endpoints { get; set; }

            public class WanKeys
            {
                public string ApiKey { get; set; }
                public string TsCode { get; set; }
            }

            public class WanEndpoints
            {
                public FlightEndpoints Flights { get; set; }
                public HotelEndpoints Hotels { get; set; }

                public class FlightEndpoints
                {
                    public string Search { get; set; }
                }

                public class HotelEndpoints
                {

                }
            }
        }

        public class TicketMasterSettings
        {

        }
    }
}
