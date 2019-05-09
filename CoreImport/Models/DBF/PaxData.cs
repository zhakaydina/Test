using System;
using System.Collections.Generic;

namespace CoreImport.Models.DBF
{
    public partial class PaxData
    {
        public PaxData()
        {
            PaxSsr = new HashSet<PaxSsr>();
        }

        public int Id { get; set; }
        public string ResNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Document { get; set; }
        public string ServiceYj { get; set; }
        public string Country { get; set; }
        public DateTime? Expires { get; set; }
        public string Seats { get; set; }
        public string Escort { get; set; }
        public string Ssr { get; set; }
        public int? Changed { get; set; }
        public string ChangedType { get; set; }
        public int? RequestNumber { get; set; }
        public int? StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public int? UserId { get; set; }
        public int? FlightId { get; set; }
        public string PaxOrder { get; set; }

        public Flights Flight { get; set; }
        public ICollection<PaxSsr> PaxSsr { get; set; }
    }
}

