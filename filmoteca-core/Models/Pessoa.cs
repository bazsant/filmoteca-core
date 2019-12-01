using System;
using System.Collections.Generic;

namespace filmoteca_core.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Cotacao = new HashSet<Cotacao>();
        }

        public int CdPessoa { get; set; }
        public string NmPessoa { get; set; }
        public DateTime? DtNascimento { get; set; }
        public string CdSexo { get; set; }
        public string DsEmail { get; set; }
        public string DsTelefone { get; set; }
        public int? CdUsuario { get; set; }
        public int? CdPerfil { get; set; }

        public virtual Perfil CdPerfilNavigation { get; set; }
        public virtual Usuario CdUsuarioNavigation { get; set; }
        public virtual ICollection<Cotacao> Cotacao { get; set; }
    }
}
