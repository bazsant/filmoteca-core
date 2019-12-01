using System;
using System.Collections.Generic;

namespace filmoteca_core.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int CdPerfil { get; set; }
        public string DsPerfil { get; set; }
        public int CdNivelAcesso { get; set; }

        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}
