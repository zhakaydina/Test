using System;
using System.Collections.Generic;

namespace CoreImport.Models.DBF
{
    public partial class AuthPerson
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonPassword { get; set; }
        public string PersonRole { get; set; }
    }
}
