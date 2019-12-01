using System;
using System.Collections.Generic;

namespace filmoteca_core.Models
{
    public partial class Filme
    {
        public Filme()
        {
            Cotacao = new HashSet<Cotacao>();
        }

        public int CdFilme { get; set; }
        public string DsTitulo { get; set; }
        public string DsDiretor { get; set; }
        public string DsElenco { get; set; }
        public string DsGenero { get; set; }
        public string DsEstudio { get; set; }
        public DateTime? DtLancamento { get; set; }

        public virtual Estoque Estoque { get; set; }
        public virtual ICollection<Cotacao> Cotacao { get; set; }
    }
}
