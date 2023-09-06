using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3W2D3_ContoCorrente
{
    internal class ContoCorrente
    {
        public string NomeCorrentista { get; set; }
        public string CognomeCorrentista { get; set; }
        public DateTime DataAperturaConto { get; set; }
        public string NumeroConto { get; set; }
        public decimal Saldo { get; set; }
        public List<Movimentazione> Movimentazioni { get; } = new List<Movimentazione>();


        public ContoCorrente(string nomeCorrentista, string cognomeCorrentista, DateTime dataAperturaConto, string numeroConto, decimal saldo)
        {
            NomeCorrentista = nomeCorrentista;
            CognomeCorrentista = cognomeCorrentista;
            DataAperturaConto = dataAperturaConto;
            NumeroConto = numeroConto;
            Saldo = saldo;
        }

        public void Accredita(decimal importo)
        {
            if (importo > 0)
            {
                Saldo += importo;
                Movimentazioni.Add(new Movimentazione(DateTime.Now, importo, 'C'));
            
        }
        }

        public bool Addebita(decimal importo)
        {
            if (importo > 0 && Saldo >= importo)
            {
                Saldo -= importo;
                Movimentazioni.Add(new Movimentazione(DateTime.Now, importo, 'D'));
                return true;
            }
            return false;
        }

    }
}
