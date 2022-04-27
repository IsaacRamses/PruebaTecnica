using System;
using System.Collections.Generic;

#nullable disable

namespace API_2.Models
{
    public partial class MTDocumento
    {
        public MTDocumento()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdDocumento { get; set; }
        public string DesDocumento { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
