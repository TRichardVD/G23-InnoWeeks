using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveIT
{
    public class User
    {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string Sex { get; set; }

        public User(string mail, string name, string password, int age, DateTime birthDate, int height, double weight, string sex)
        {
            Mail = mail;
            Name = name;
            Password = password;
            Age = age;
            BirthDate = birthDate;
            Height = height;
            Weight = weight;
            Sex = sex;
        }

        // Constructeur par défaut nécessaire pour les opérations de base de données
        public User() { }
    }
}
