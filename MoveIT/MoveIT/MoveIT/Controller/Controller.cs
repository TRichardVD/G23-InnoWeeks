
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MoveIT
{
    public class Controller
    {
        private LoginView _loginView;
        private RegisterView _registerView;
        private MenuView _menuView;
        private UserView _userView;
        private ModifyView _modifyView;
        private Model _model;

        private string _usersFolder = "../../../Users";

        private string _currentView;

        private User _newUser;

        private List<User> _usersList = new List<User>();

        private string _userName;   
        private string _password;
        private string _age;
        private string _height;
        private string _weight;
        private string _gender;

        string error = "Erreur : ";
        string errors = "Erreurs : ";

        // Vérification du nom
        private string _regexName = @"^[A-Za-zÀ-ÖØ-öø-ÿ\- ']+$";

        // Vérification des normes du mot de passe
        private string _regexPsw = @"^(?=.*\d)(?=.*[^a-zA-Z0-9,]).{12,}$";

        // Vérification de l'age
        private string _regexAge = @"^(?:1[0-9]{2}|[1-9]?[0-9])$";

        // Vérification de la taille
        private string _regexHeight = @"^(50|[5-9]\d|1\d{2}|2\d{2}|300)$";

        // Vérification du poids
        private string _regexWeight = @"^\d{1,3}(,\d{1,2})?$";


        private double _bmi;

        /// <summary>
        /// Liste des utilisateurs du programme
        /// </summary>
        public List<User> UserList
        {
            get { return _usersList; }
            set { _usersList = value; }
        }


        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }


        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }


        public string Height
        {
            get { return _height; }
            set { _height = value;}
        }


        public string Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }


        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }


        public Controller(LoginView loginView, RegisterView registerView, MenuView menuView, UserView userView, ModifyView modifyView, Model model)
        {
            this._loginView = loginView;
            this._registerView = registerView;
            this._menuView = menuView;
            this._userView = userView;
            this._modifyView = modifyView;
            this._model = model;

            loginView.Controller = this;
            registerView.Controller = this;
            menuView.Controller = this;
            userView.Controller = this;
            modifyView.Controller = this;
            model.Controller = this;

            UserList = new List<User>();
            LoadUsersFromFiles();
        }

        private void GetBMI()
        {
            _bmi = Convert.ToDouble(Weight) / Math.Pow(Convert.ToDouble(Height) / 100, 2);
        }

        /// <summary>
        /// Affiche le menu principale
        /// </summary>
        public void ShowMenu()
        {
            // Met à jour les informations
            Update();
            _menuView.Show();
        }

        /// <summary>
        /// Affiche la page de connexion
        /// </summary>
        public void ShowLogin()
        {
            _loginView.Show();
        }

        /// <summary>
        /// Affiche la page des paramètres utilisateurs
        /// </summary>
        public void ShowUser()
        {
            // Met à jour les informations
            Update();
            _userView.Show();
        }

        /// <summary>
        /// Affiche la page de création de compte
        /// </summary>
        public void ShowRegister()
        {
            _currentView = "register";
            _registerView.Show();
        }

        /// <summary>
        /// Affiche la page de modification
        /// </summary>
        public void ShowModify()
        {
            _currentView = "modify";
            _modifyView.Show();
        }

        /// <summary>
        /// Créé un nouvel utilisateur
        /// </summary>
        /// <param name="name">Nom de l'utlisateur</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        /// <param name="age">Age de l'utilisateur</param>
        /// <param name="height">Taille de l'utilisateur</param>
        /// <param name="weight">Poids de l'utilisateur</param>
        /// <param name="gender">Sexe de l'utilisateur</param>
        public void CreateNewUser(string name, string password, string age, string height, string weight, string gender)
        {
            // Vérifier que l'utilisateur n'existe pas déjà
            foreach (User user in UserList)
            {
                if (name == user.Name)
                {
                    MessageBox.Show("L'utilisateur existe déjà", "Erreur", MessageBoxButtons.OK);
                    return;
                }
            }

            if (password == _registerView.confirmPswTxtBx.Text)
            {
                // Créer le nouvel utilisateur
                _newUser = new User(name, password, Convert.ToInt32(age), Convert.ToInt32(height), Convert.ToDouble(weight), gender);

                // Ajouter l'utilisateur à la liste
                UserList.Add(_newUser);

                // Stocker les données utilisateur dans un fichier texte
                SaveUserToFile(_newUser);

                // Réinitialiser les champs
                _registerView.idTxtBx.Text = "";
                _registerView.pswTxtBx.Text = "";
                _registerView.confirmPswTxtBx.Text = "";
                _registerView.ageTxtBx.Text = "";
                _registerView.heightTxtBx.Text = "";
                _registerView.weightTxtBx.Text = "";
                _registerView.maleRdBtn.Checked = true;

                // Afficher un message de confirmation
                MessageBox.Show("Le nouveau compte a été créé", "Réussite", MessageBoxButtons.OK);

                // Rediriger vers la page de connexion
                ShowLogin();
                _registerView.Hide();
            }
            else            
                MessageBox.Show("Le mot de passe ne correspond pas", "Erreur", MessageBoxButtons.OK);            
        }

        /// <summary>
        /// Stocke les données de l'utilisateur dans un fichier texte
        /// </summary>
        private void SaveUserToFile(User user)
        {
            // Créer le dossier Users s'il n'existe pas
            if (!Directory.Exists(_usersFolder))
            {
                Directory.CreateDirectory(_usersFolder);
            }

            string userFilePath = Path.Combine(_usersFolder, $"{user.Name}.txt");
            string userData = $"Name: {user.Name}\nPassword: {user.Password}\nAge: {user.Age}\nHeight: {user.Height}\nWeight: {user.Weight}\nGender: {user.Gender}";

            File.WriteAllText(userFilePath, userData);
        }

        /// <summary>
        /// Modifie les données de l'utilisateur
        /// </summary>
        public void ModifyUser(string name, string password, string age, string height, string weight)
        {
            string actualName = _userView.userLbl.Text;

            if(password == _modifyView.confirmPswTxtBx.Text)
            {
                foreach (User user in UserList)
                {
                    if (user.Name == actualName)
                    {
                        user.Name = name;
                        user.Password = password;
                        user.Age = Convert.ToInt32(age);
                        user.Height = Convert.ToInt32(height);
                        user.Weight = Convert.ToInt32(weight);

                        if (_modifyView.maleRdBtn.Checked == true)
                            user.Gender = "M";
                        if (_modifyView.femaleRdBtn.Checked == true)
                            user.Gender = "F";

                        UserName = user.Name;
                        Password = user.Password;
                        Age = user.Age.ToString();
                        Height = user.Height.ToString();
                        Weight = user.Weight.ToString();
                        Gender = user.Gender;

                        // Supprimer l'ancien fichier utilisateur
                        string oldUserFilePath = Path.Combine(_usersFolder, $"{actualName}.txt");
                        if (File.Exists(oldUserFilePath))
                        {
                            File.Delete(oldUserFilePath);
                        }

                        MessageBox.Show("Modification enregistrée avec succès", "Succès", MessageBoxButtons.OK);

                        // Sauvegarder les modifications dans un nouveau fichier
                        SaveUserToFile(user);
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Le mot de passe ne correspond pas", "Erreur", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Vérifie si l'entrée du nouvel utilisateur est acceptable
        /// </summary>
        public string CheckIfEntryIsOk(string name, string password, string age, string height, string weight)
        {
            string error = "Erreur : ";
            string errors = "Erreurs : ";

            if (!Regex.IsMatch(name, _regexName))
                error += error.Length > errors.Length ? ", identifiant" : "Identifiant";
            if (!Regex.IsMatch(password, _regexPsw))
                error += error.Length > errors.Length ? ", mot de passe" : "Mot de passe";
            if (!Regex.IsMatch(age, _regexAge))
                error += error.Length > errors.Length ? ", age" : "Age";
            if (!Regex.IsMatch(height, _regexHeight))
                error += error.Length > errors.Length ? ", taille" : "Taille";
            if (!Regex.IsMatch(weight, _regexWeight))
                error += error.Length > errors.Length ? ", poids" : "Poids";

            return error;
        }

        /// <summary>
        /// Récupert tous les utilisateurs depuis la database
        /// </summary>
        private void LoadUsersFromFiles()
        {
            string usersFolder = "../../../Users";
            if (Directory.Exists(usersFolder))
            {
                foreach (string file in Directory.GetFiles(usersFolder, "*.txt"))
                {
                    string[] lines = File.ReadAllLines(file);
                    string name = lines[0].Split(':')[1].Trim();
                    string password = lines[1].Split(':')[1].Trim();
                    int age = int.Parse(lines[2].Split(':')[1].Trim());
                    int height = int.Parse(lines[3].Split(':')[1].Trim());
                    double weight = double.Parse(lines[4].Split(':')[1].Trim());
                    string gender = lines[5].Split(':')[1].Trim();

                    User user = new User(name, password, age, height, weight, gender);
                    UserList.Add(user);
                }
            }
        }

        /// <summary>
        /// Créer ou met à jour les informations de l'utilisateur
        /// </summary>
        /// <param name="name">Nom de l'utlisateur</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        /// <param name="age">Age de l'utilisateur</param>
        /// <param name="height">Taille de l'utilisateur</param>
        /// <param name="weight">Poids de l'utilisateur</param>
        /// <param name="gender">Sexe de l'utilisateur</param>
        public void NewUser(string name, string password, string age, string height, string weight, string gender)
        {
            // Réinitialiser l'erreur
            error = "Erreur : ";
            errors = "Erreurs : ";

            // Vérifier si les entrées sont valides
            error = CheckIfEntryIsOk(name, password, age, height, weight);

            if (error == "Erreur : ")
            {
                if(_currentView == "register")
                    CreateNewUser(name, password, age, height, weight, gender);
                if(_currentView == "modify")
                    ModifyUser(name, password, age, height, weight);
            }
            else
            {
                MessageBox.Show(error.Length > errors.Length ? $"{error} ne correspond pas à la réglementation de nommage." : $"{errors} ne correspondent pas à la réglementation de nommage.");
            }
        }

        /// <summary>
        /// Met à jour toutes les informations
        /// </summary>
        public void Update()
        {
            // Calcule l'IMC de l'utilisateur
            GetBMI();

            // Change le texte affiché avec les information de l'utilisateur
            _userView.userLbl.Text = UserName;
            _userView.heightLbl.Text = $"Taille :     {Height} cm";
            _userView.weightLbl.Text = $"Poids :     {Weight} kg";
            _userView.ageLbl.Text = $"Age :       {Age}";
            _userView.bmiLbl.Text = $"IMC :       {_bmi:F2}";

            // Ajoute les informations de l'utilisateur dans la page modifier
            _modifyView.idTxtBx.Text = UserName;
            _modifyView.pswTxtBx.Text = Password;
            _modifyView.confirmPswTxtBx.Text = Password;
            _modifyView.ageTxtBx.Text = Age;
            _modifyView.heightTxtBx.Text = Height;
            _modifyView.weightTxtBx.Text = Weight;

            // Affiche le nom de l'utilisateur
            _menuView.userLbl.Text = UserName;

            if (Gender == "M")
            {
                _modifyView.maleRdBtn.Checked = true;
                // Change la photo de profil selon le sexe de l'utilisateur
                _menuView.userBtn.BackgroundImage = Properties.Resources.Muser;

            }
            if (Gender == "F")
            {
                _modifyView.femaleRdBtn.Checked = true;
                // Change la photo de profil selon le sexe de l'utilisateur
                _menuView.userBtn.BackgroundImage = Properties.Resources.Fuser;
            }
        }

        public void AbandonModification()
        {
            if(_modifyView.idTxtBx.Text != UserName || _modifyView.pswTxtBx.Text != Password || _modifyView.heightTxtBx.Text != Height || _modifyView.weightTxtBx.Text != Weight)
            {
                DialogResult result = MessageBox.Show("Voulez-vous abandonner la modification ?", "Attention", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    ShowUser();
                    _modifyView.Hide();
                }
            }
            else
            {
                ShowUser();
                _modifyView.Hide();
            }

        }
    }
}
