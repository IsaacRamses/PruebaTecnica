using System;
using System.Collections.Generic;

#nullable disable

namespace AppWeb.Models
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
