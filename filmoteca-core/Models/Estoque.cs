using System;
using System.Collections.Generic;

namespace filmoteca_core.Models
{
    public partial class Estoque
    {
        public int CdFilme { get; set; }
        public int VlQuantidade { get; set; }

        public virtual Filme CdFilmeNavigation { get; set; }
    }
}
