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

        ////////////////////////////////////////
        // Définition des énumérations pour les types de mots et les types de causes
        public enum MotType
        {
            Symptome,
            Cause
        }

        public enum CauseType
        {
            Maladie,
            Psychologique
            // Ajoutez d'autres types de causes si nécessaire
        }

        // Interface pour représenter les propriétés communes à tous les mots
        public interface IMot
        {
            string Valeur { get; set; }
            MotType Type { get; }
        }

        // Interface pour représenter les propriétés spécifiques aux symptômes
        public interface ISymptome : IMot
        {
            int Intensite { get; set; }
            TimeSpan Duree { get; set; }
        }

        // Interface pour représenter les propriétés spécifiques aux causes
        public interface ICause : IMot
        {
            CauseType TypeCause { get; set; }
            int Importance { get; set; }
        }

        // Classe de base implémentant l'interface IMot
        public class Mot : IMot
        {
            public string Valeur { get; set; }
            public MotType Type { get; }

            public Mot(string valeur, MotType type)
            {
                Valeur = valeur;
                Type = type;
            }
        }

        // Classe représentant un symptôme, héritant de Mot et implémentant ISymptome
        public class Symptome : Mot, ISymptome
        {
            public int Intensite { get; set; }
            public TimeSpan Duree { get; set; }

            public Symptome(string valeur, int intensite, TimeSpan duree) : base(valeur, MotType.Symptome)
            {
                Intensite = intensite;
                Duree = duree;
            }
        }

        // Classe représentant une cause, héritant de Mot et implémentant ICause
        public class Cause : Mot, ICause
        {
            public CauseType TypeCause { get; set; }
            public int Importance { get; set; }

            public Cause(string valeur, CauseType typeCause, int importance) : base(valeur, MotType.Cause)
            {
                TypeCause = typeCause;
                Importance = importance;
            }
        }
        ///////////////////////////////////////



        static void Main(string[] args)
        {   


            Console.WriteLine("Hello, \n\n");
            while (true)
            {



                Console.Write("Votre Texte : ");
                string[] tab_msg = RemoveAccents(Console.ReadLine().ToLower()).Replace(@"[^a-zA-Z0-9]", "").Split(' ');

                Console.WriteLine($"Texte corrigé : {tab_msg}");

                if (tab_msg.Length == 0)
                    continue;


                // Extraction des données

                foreach (string word in tab_msg)
                {
                    
                    

                }


            }
        }

    }
}
