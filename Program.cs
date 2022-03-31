using System;
using System.Configuration;
using LibrarieModele;
using StocareDateClienti;

namespace EvidentaClienti
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrareClienti_FisierText adminClienti = new AdministrareClienti_FisierText(numeFisier);
            int nrClienti = 0;
            string optiune;
            do
            {
                Console.WriteLine("C.citire date de la tastatura");
                Console.WriteLine("F. Afisare clienti din fisier");
                Console.WriteLine("S. Salvare client in fisier");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "C":
                        int i= 5;
                        string cnp, nume, prenume;
                        Console.WriteLine("Dati cnp-ul clientului: ");
                        cnp = Console.ReadLine();
                        while (cnp.Length != 13 && i!=0)
                        {
                            Console.WriteLine("CNP invalid-incercati din nou");
                            cnp = Console.ReadLine();
                            i--;
                            if (i == 0)
                            {
                                Console.WriteLine("ne pare rau, dar ati introdus de prea multe ori CNP-ul gresit!");
                                return;
                            }
                        }
                        Console.WriteLine("Dati numele clientului: ");
                        nume = Console.ReadLine();
                        Console.WriteLine("Dati prenumele clientului: ");
                        prenume = Console.ReadLine();
                        Client client1 = new Client(nrClienti, cnp, nume, prenume);
                        adminClienti.AddClient(client1);
                        break;
                    case "F":
                        Client[] clienti = adminClienti.GetClienti(out nrClienti);
                        AfisareClienti(clienti, nrClienti);
                        break;
                    case "S":
                        int idClient = nrClienti + 1;
                        nrClienti++;
                        Client client = new Client(idClient, "5010729330215", "Ioana", "Radu");
                        //adaugare client in fisier
                        adminClienti.AddClient(client);
                        break;
                    case "L":
                        string nume1, prenume1;
                        Console.WriteLine("Dati numele clientului cautat: ");
                        nume1 = Console.ReadLine();
                        Console.WriteLine("Dati prenumele clientului cautat: ");
                        prenume1 = Console.ReadLine();
                        Console.WriteLine((adminClienti.GetClient(nume1, prenume1)).ToString());
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;

                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }
        public static void AfisareClienti(Client[] clienti, int nrClienti)
        {
            Console.WriteLine("Clientii sunt:");
            for (int contor = 0; contor < nrClienti; contor++)
            {
                string infoClient = string.Format("Clientul cu id-ul #{0} are numele: {1} {2} si CNP-ul {3} ",
                   clienti[contor].GetIdClient(),
                   clienti[contor].GetNume() ?? " NECUNOSCUT ",
                   clienti[contor].GetPrenume() ?? " NECUNOSCUT ",
                   clienti[contor].GetCNP() ?? " NECUNOSCUT ");

                Console.WriteLine(infoClient);
            }

        }
    }
}
