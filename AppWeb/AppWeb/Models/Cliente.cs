using System;
using System.Collections.Generic;

#nullable disable

namespace AppWeb.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Emails = new HashSet<Email>();
        }

        public long IdCliente { get; set; }
        public string Nombre_1 { get; set; }
        public string Nombre_2 { get; set; }
        public string Apellido_1 { get; set; }
        public string Apellido_2 { get; set; }
        public string Nom_Compl { get; set; }
        public int Id_Fkdocumento { get; set; }
        public string Nacionalidad { get; set; }
        public int Nro_Documento { get; set; }
        public DateTime Fecha_Reg { get; set; }
        public DateTime? Fecha_Act { get; set; }
        public bool Estatus { get; set; }
        public int IdEmail { get; set; }
        public string Email { get; set; }
        public int TipoEmail { get; set; }

        public virtual MTDocumento IdFkdocumentoNavigation { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}
