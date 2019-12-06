using System;
using System.Collections.Generic;

namespace filmoteca_core.Models
{
    public partial class Cotacao
    {
        public int CdCotacao { get; set; }
        public int CdFilme { get; set; }
        public int CdPessoa { get; set; }
        public decimal VlValor { get; set; }
        public DateTime DtEntrega { get; set; }
        public DateTime DtEntregaPrevista { get; set; }
        public bool FlEntregue { get; set; }

        public virtual Filme CdFilmeNavigation { get; set; }
        public virtual Pessoa CdPessoaNavigation { get; set; }
    }
}
