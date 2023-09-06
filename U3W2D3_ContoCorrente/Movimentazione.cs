using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3W2D3_ContoCorrente
{
    internal class Movimentazione
    {
        public DateTime Data { get; }
        public decimal Importo { get; }
        public char Tipo { get; }

        public Movimentazione(DateTime data, decimal importo, char tipo)
        {
            Data = data;
            Importo = importo;
            Tipo = tipo;
        }
        }
}
