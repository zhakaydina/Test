using System;
using System.Collections.Generic;

namespace CoreImport.Models.DBF
{
    public partial class Flights
    {
        public Flights()
        {
            PaxData = new HashSet<PaxData>();
        }

        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }

        public ICollection<PaxData> PaxData { get; set; }
    }
}
