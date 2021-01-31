using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Ryhmätyöprojektiomaversio
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string database_path = @"membership_database.json";
            List<Asiakas> database = new List<Asiakas>();


            // tehdään lista alkutilanteesta, eli json tiedostoon jo valmiiksi tallennetuista asiakkaista.

            List<Asiakas> alkutilanne = JsonConvert.DeserializeObject<List<Asiakas>>(File.ReadAllText(database_path));
            
            //database.Add(alkutilanne);

            //Toistaiseksi vasta 1 ominaisuus, eli asiakkaan lisääminen Asiakas-luokan avulla.

            Console.WriteLine("Laskutussofta v1.0" + Environment.NewLine);
            Console.Write("[1] Lisää uusi asiakas: ");

            var toiminto = int.Parse(Console.ReadLine());

            if (toiminto == 1)
            {
                Console.Write("Anna etunimi: ");
                var etunimi = Console.ReadLine();
                Console.Write("Anna sukunimi: ");
                var sukunimi = Console.ReadLine();
                Console.Clear();

                Asiakas asiakas = new Asiakas();
                asiakas.FirstName = etunimi;
                asiakas.LastName = sukunimi;
                asiakas.JoinedDate = DateTime.Now;

                               
                database.Add(asiakas);

            }

            // Lisätään databasen sisältö Json tiedostoon  + testitulostus


            var db =  JsonConvert.SerializeObject(database);

            File.WriteAllText(database_path, db, Encoding.UTF8);

            Console.WriteLine(db);
            
            Console.ReadLine();

            
            // Tulostetaan asiakaslista


            var tulosta = JsonConvert.DeserializeObject<List<Asiakas>>(File.ReadAllText(database_path));

            
            Console.WriteLine("Asiakaslista: " + Environment.NewLine);
            foreach (var item in tulosta)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            Console.ReadKey();
        
        }

    }

}
