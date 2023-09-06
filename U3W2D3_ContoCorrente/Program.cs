using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3W2D3_ContoCorrente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Banca banca = new Banca();

        for (int i = 1; i <= 10; i++)
            {
                string nome = $"Nome{i}";
                string cognome = $"Cognome{i}";
                DateTime dataApertura = DateTime.Now;
                string numeroConto = $"IT000000000{i}";
                decimal saldoIniziale = 1000.0m * i;

                ContoCorrente conto = new ContoCorrente(nome, cognome, dataApertura, numeroConto, saldoIniziale);
            }

            banca.MenuBanca();
        }
    }
}
