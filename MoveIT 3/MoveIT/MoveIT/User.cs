using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveIT
{
    public class User
    {
        // Nom de l'utilisateur
        private string _name;

        // Mot de passe de l'utilisateur
        private string _password;

        // Age de l'utilisateur
        private int _age;

        // Taille de l'utilisateur
        private int _height;

        // Poids de l'utilisateur
        private double _weight;

        // Sexe de l'utilisateur
        private string _gender;

        /// <summary>
        /// Nom de l'utilisateur
        /// </summary>
        public string Name
        { 
            get { return _name; } 
            set { _name = value; } 
        }

        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// Age de l'utilisateur
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        /// <summary>
        /// Taille de l'utilisateur
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Poids de l'utilisateur
        /// </summary>
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        /// <summary>
        /// Sexe de l'utilisateur
        /// </summary>
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public User()
        {

        }

        public User(string name, string password, int age, int height, double weight, string gender)
        {
            _name = name;
            _password = password;
            _age = age;
            _height = height;
            _weight = weight;
            _gender = gender;
        }
    }
}
