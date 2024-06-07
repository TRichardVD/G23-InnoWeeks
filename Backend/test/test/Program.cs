using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {



        public static string RemoveAccents(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Remplacer les caractères accentués par leurs équivalents non accentués
            string[] accents = new string[] { "áàâäãåą", "éèêëę", "íìîïı", "óòôöõő", "úùûüŭů", "çćč", "ñń", "ýÿ", "žźż" };
            string[] replacements = new string[] { "a", "e", "i", "o", "u", "c", "n", "y", "z" };

            for (int i = 0; i < accents.Length; i++)
            {
                foreach (char accent in accents[i])
                {
                    input = input.Replace(accent, replacements[i][0]);
                }
            }

            return input;
        }

        public object





        static void Main(string[] args)
        {   






            Console.WriteLine("Hello, \n\n");
            while (true)
            {
                Console.Write("Votre Texte : ");
                string[] tab_msg = RemoveAccents(Console.ReadLine()).Replace(@"[^a-zA-Z0-9]", "").Split(' '); ;

                Console.WriteLine($"Texte corrigé : {tab_msg}");
                

                // Extraction des données

                foreach (string word in tab_msg)
                {
                    
                    







                }







            }
        }

    }
}
