using System;
using System.Collections.Generic;

#nullable disable

namespace API_2.Models
{
    public partial class MTEmail
    {
        public MTEmail()
        {
            Emails = new HashSet<Email>();
        }

        public int IdTipo { get; set; }
        public string DescTipo { get; set; }

        public virtual ICollection<Email> Emails { get; set; }
    }
}
