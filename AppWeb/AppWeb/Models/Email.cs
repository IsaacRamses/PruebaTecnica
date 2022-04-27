using System;
using System.Collections.Generic;

#nullable disable

namespace AppWeb.Models
{
    public partial class Email
    {
        public long IdEmail { get; set; }
        public long IdFkcliente { get; set; }
        public int IdFktipo { get; set; }
        public string Email1 { get; set; }
        public DateTime FechReg { get; set; }
        public DateTime? FechAct { get; set; }
        public bool Estatus { get; set; }

        public virtual Cliente IdFkclienteNavigation { get; set; }
        public virtual MTEmail IdFktipoNavigation { get; set; }
    }
}
