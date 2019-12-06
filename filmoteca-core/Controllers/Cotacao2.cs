using System;

namespace filmoteca_core.Controllers
{
    public partial class CotacaosController
    {
        public class Cotacao2
        {
            public int CdCotacao { get; set; }
            public int CdFilme { get; set; }
            public string DsTitulo { get; set; }
            public int CdPessoa { get; set; }
            public string NmPessoa { get; set; }
            public decimal VlValor { get; set; }
            public DateTime DtEntrega { get; set; }
            public DateTime DtEntregaPrevista { get; set; }
        }
    }
}
