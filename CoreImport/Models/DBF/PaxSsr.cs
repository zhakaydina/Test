using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreImport.Models.DBF
{
    public class PaxSsr
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DescriptionSsr { get; set; }
        public int? PaxId { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public string F5 { get; set; }
        public string F6 { get; set; }
        public string F7 { get; set; }
        public string F8 { get; set; }
        public string F9 { get; set; }
        public string F10 { get; set; }

        public PaxData Pax { get; set; }
    }
}
