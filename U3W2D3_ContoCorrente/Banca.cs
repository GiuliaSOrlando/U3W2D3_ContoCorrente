using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3W2D3_ContoCorrente
{
    internal class Banca
    {
        private List<ContoCorrente> contiCorrenti = new List<ContoCorrente>();
        private static int IDUnivocoConto = 1;

        private ContoCorrente TrovaContoPerNumero(string numeroConto)
        {
            foreach (ContoCorrente conto in contiCorrenti)
            {
                if (conto.NumeroConto == numeroConto)
                {
                    return conto;
                }
            }
            return null;
        }

        public void MenuBanca()
        {
            while (true)
            {
                Console.WriteLine("╔══════════════════════════╗");
                Console.WriteLine("║        Benvenuto in      ║");
                Console.WriteLine("║        Banca Console     ║");
                Console.WriteLine("╚══════════════════════════╝");
                Console.WriteLine("1. Crea nuovo conto corrente");
                Console.WriteLine("2. Memorizza una movimentazione di conto");
                Console.WriteLine("3. Elenco delle movimentazion di un conto");
                Console.WriteLine("4. Saldo di tutti i conti correnti");
                Console.WriteLine("5. Esci");

                Console.Write("Scelta: ");
                int scelta = int.Parse(Console.ReadLine());

                switch (scelta) {
                    case 1:
                        CreaNuovoConto();
                        break;
                    case 2:
                        MemorizzaMovimentazione();
                        break;
                    case 3:
                        ElencoMovimentazioniConto();
                        break;
                    case 4:
                        SaldoTuttiConti();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                }
                Console.WriteLine();
                            
                           
            }
        }
        private void CreaNuovoConto()
        {
            Console.WriteLine("Inserire nome correntista:");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserire cognome correntista");
            string cognome = Console.ReadLine();
            DateTime dataapertura = DateTime.Now;
            string numeroconto = GeneraIban();
            Console.WriteLine($"\nConto generato correttamente, numero conto {numeroconto}");
            decimal saldo = 0;

            contiCorrenti.Add(new ContoCorrente(nome, cognome, dataapertura, numeroconto, saldo));
        }
        private string GeneraIban()
        {
          string IBAN = "IT" + IDUnivocoConto.ToString().PadLeft(10, '0');
            IDUnivocoConto++;
            return IBAN;
        }

        private void MemorizzaMovimentazione()
        {
            Console.WriteLine("Inserire il numero di conto:");
            string numeroConto = Console.ReadLine();
            ContoCorrente conto = TrovaContoPerNumero(numeroConto);

            if (conto != null)
            {
                Console.WriteLine("Inserire l'importo in euro che si vuole accreditare/addebitare:");
                decimal importo;
                if (decimal.TryParse(Console.ReadLine(), out importo))
                {
                    Console.WriteLine("Indicare il tipo di movimento (C per accredito, D per addebito):");
                    char tipoMovimento = char.ToUpper(Console.ReadKey().KeyChar);

                    if (tipoMovimento == 'C')
                    {
                        conto.Accredita(importo);
                        Console.WriteLine("\nMovimentazione di accredito memorizzata con successo.");
                    }
                    else if (tipoMovimento == 'D')
                    {
                        if (conto.Addebita(importo))
                        {
                            Console.WriteLine("\nMovimentazione di addebito memorizzata con successo.");
                        }
                        else
                        {
                            Console.WriteLine("\nSaldo insufficiente per l'addebito.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nTipo di movimento non valido.");
                    }
                }
                else
                {
                    Console.WriteLine("\nImporto non valido. Inserire un valore numerico.");
                }
            }
            else
            {
                Console.WriteLine("\nConto non trovato. Verificare il numero di conto.");
            }
        }

        private void ElencoMovimentazioniConto()
        {
            Console.WriteLine("Inserire il numero di conto:");
            string numeroConto = Console.ReadLine();
            ContoCorrente conto = TrovaContoPerNumero(numeroConto);

            if (conto != null)
            {
                Console.WriteLine($"Movimentazioni per il conto {numeroConto}:");
                foreach (Movimentazione movimento in conto.Movimentazioni)
                {
                    Console.WriteLine($"{movimento.Data}: € {movimento.Importo:N} ({movimento.Tipo})");
                }
                Console.WriteLine($"Saldo attuale: € {conto.Saldo:N}");
            }
            else
            {
                Console.WriteLine("\nConto non trovato. Verificare il numero di conto.");
            }
        }

        private void SaldoTuttiConti()
        {
            Console.WriteLine("Saldo di tutti i conti correnti:");
            foreach (ContoCorrente conto in contiCorrenti)
            {
                Console.WriteLine($"{conto.NomeCorrentista} {conto.CognomeCorrentista} - {conto.NumeroConto}: € {conto.Saldo:N}");
            }
        }
    }
}





