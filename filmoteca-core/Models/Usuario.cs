using System;
using System.Collections.Generic;

namespace filmoteca_core.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int CdUsuario { get; set; }
        public string NmUsuario { get; set; }
        public string DsSenha { get; set; }

        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}
