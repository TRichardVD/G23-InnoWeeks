using Mysqlx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoveIT
{
    public class Controller
    {
        private readonly LoginView _loginView;
        private readonly RegisterView _registerView;
        private readonly MenuView _menuView;
        private readonly UserView _userView;
        private readonly ModifyView _modifyView;
        private readonly Model _model;

        private readonly string _usersFolder = "../../../Users";
        private string _currentView;
        private User _newUser;
        private User _actualName = new User();
        private List<User> _usersList = new List<User>();

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Sex { get; set; }

        private const string ERROR = "Erreur : ";
        private const string ERRORS = "Erreurs : ";

        private const string NamePattern = @"^[A-Za-zÀ-ÖØ-öø-ÿ\- ']+$";
        private const string PasswordPattern = @"^(?=.*\d)(?=.*[^a-zA-Z0-9,]).{12,}$";
        private const string HeightPattern = @"^(50|[5-9]\d|1\d{2}|2\d{2}|300)$";
        private const string WeightPattern = @"^\d{1,3}([,.]\d{1,2})?$";

        private double _bmi;

        public List<User> UserList
        {
            get => _usersList;
            set => _usersList = value;
        }

        public Controller(LoginView loginView, RegisterView registerView, MenuView menuView, UserView userView, ModifyView modifyView, Model model)
        {
            _loginView = loginView;
            _registerView = registerView;
            _menuView = menuView;
            _userView = userView;
            _modifyView = modifyView;
            _model = model;

            loginView.Controller = this;
            registerView.Controller = this;
            menuView.Controller = this;
            userView.Controller = this;
            modifyView.Controller = this;
            model.Controller = this;

            UserList = new List<User>();
            RegisterUser();
        }

        public void RegisterUser()
        {
            _usersList = _model.ListUsers();
        }

        private void GetBMI()
        {
            _bmi = Convert.ToDouble(Weight) / Math.Pow(Convert.ToDouble(Height) / 100, 2);
        }

        public void ShowMenu()
        {
            Update();
            _menuView.Show();
        }

        public void ShowLogin()
        {
            _loginView.Show();
        }

        public void ShowUser()
        {
            Update();
            _userView.Show();
        }

        public void ShowRegister()
        {
            _currentView = "register";
            _registerView.Show();
        }

        public void ShowModify()
        {
            _currentView = "modify";
            _modifyView.Show();
        }

        public void CreateNewUser(string name, string password, string age, string height, string weight, string gender)
        {
            foreach (User user in UserList)
            {
                if (name == user.Name)
                {
                    MessageBox.Show("L'utilisateur existe déjà", "Erreur", MessageBoxButtons.OK);
                    return;
                }
            }

            age = Age;

            if (password == _registerView.confirmPswTxtBx.Text)
            {
                _newUser = new User(name, password, Convert.ToInt32(age), Convert.ToInt32(height), Convert.ToDouble(weight.Replace(',', '.')), gender);

                UserList.Add(_newUser);
                SaveUser();

                _registerView.idTxtBx.Text = "";
                _registerView.pswTxtBx.Text = "";
                _registerView.confirmPswTxtBx.Text = "";
                _registerView.heightTxtBx.Text = "";
                _registerView.weightTxtBx.Text = "";
                _registerView.maleRdBtn.Checked = true;

                MessageBox.Show("Le nouveau compte a été créé", "Réussite", MessageBoxButtons.OK);
                ShowLogin();
                _registerView.Hide();
            }
            else
            {
                MessageBox.Show("Le mot de passe ne correspond pas", "Erreur", MessageBoxButtons.OK);
            }
        }

        private void SaveUser()
        {
            _model.InsertIntoDB(_newUser);
        }

        public void ModifyUser(string name, string password, string age, string height, string weight)
        {
            _actualName.Name = _userView.userLbl.Text;

            if (password == _modifyView.confirmPswTxtBx.Text)
            {
                foreach (User user in UserList)
                {
                    if (user.Name == _actualName.Name)
                    {
                        user.Name = name;
                        user.Password = password;
                        user.Age = Convert.ToInt32(age);
                        user.Height = Convert.ToInt32(height);
                        user.Weight = Convert.ToDouble(weight.Replace(',', '.'));

                        if (_modifyView.maleRdBtn.Checked)
                            user.Gender = "M";
                        if (_modifyView.femaleRdBtn.Checked)
                            user.Gender = "F";

                        // Met à jour les propriétés de l'utilisateur actuel dans le contrôleur
                        UserName = user.Name;
                        Password = user.Password;
                        Age = user.Age.ToString();
                        Height = user.Height.ToString();
                        Weight = user.Weight.ToString();
                        Sex = user.Gender;

                        // Supprime l'ancien utilisateur de la base de données
                        _model.DeleteFromDB(_actualName);

                        // Insère le nouvel utilisateur dans la base de données
                        _model.InsertIntoDB(user);

                        // Affiche un message de confirmation
                        MessageBox.Show("Modification enregistrée avec succès", "Succès", MessageBoxButtons.OK);

                        // Quitte la boucle après avoir trouvé l'utilisateur à modifier
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Le mot de passe ne correspond pas", "Erreur", MessageBoxButtons.OK);
            }
        }

        public void DeleteUser()
        {
            User userNameToDelete = new User(); // Récupère le nom de l'utilisateur à supprimer depuis la vue UserView

            userNameToDelete.Name = _userView.userLbl.Text;

            // Affiche une boîte de dialogue de confirmation
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le compte ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Vérifie la réponse de l'utilisateur
            if (result == DialogResult.Yes)
            {
                // Appelle la méthode DeleteFromDB pour supprimer l'utilisateur de la base de données
                _model.DeleteFromDB(userNameToDelete);

                // Supprime l'utilisateur de la liste locale
                foreach (User user in _usersList)
                {
                    if (user.Name == userNameToDelete.Name)
                    {
                        _usersList.Remove(user);
                        break;
                    }
                }

                // Affiche un message de confirmation
                MessageBox.Show("Utilisateur supprimé avec succès", "Succès", MessageBoxButtons.OK);

                // Affiche la page de connexion
                ShowLogin();
            }
        }

        public string CheckIfEntryIsOk(string name, string password, string height, string weight)
        {
            string error = ERROR;
            string errors = ERRORS;

            if (!Regex.IsMatch(name, NamePattern))
                error += error.Length > errors.Length ? ", identifiant" : "Identifiant";
            if (!Regex.IsMatch(password, PasswordPattern))
                error += error.Length > errors.Length ? ", mot de passe" : "Mot de passe";
            if (!Regex.IsMatch(height, HeightPattern))
                error += error.Length > errors.Length ? ", taille" : "Taille";
            if (!Regex.IsMatch(weight, WeightPattern))
                error += error.Length > errors.Length ? ", poids" : "Poids";

            return error;
        }

        /// <summary>
        /// Verifie les attribus et ajoute un nouvel utilisateur 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="age"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="gender"></param>
        public void NewUser(string name, string password, string age, string height, string weight, string gender)
        {
            string error = ERROR;
            string errors = ERRORS;

            error = CheckIfEntryIsOk(name, password, height, weight);

            if (error == ERROR)
            {
                if (_currentView == "register")
                    CreateNewUser(name, password, age, height, weight, gender);
                if (_currentView == "modify")
                    ModifyUser(name, password, age, height, weight);
            }
            else
            {
                MessageBox.Show(error.Length > errors.Length ? $"{error} ne correspond pas à la réglementation de nommage." : $"{errors} ne correspondent pas à la réglementation de nommage.");
            }
        }
        public void Update()
        {
            GetBMI();
            _userView.userLbl.Text = UserName;
            _userView.heightLbl.Text = $"Taille :     {Height} cm";
            _userView.weightLbl.Text = $"Poids :     {Weight} kg";
            _userView.ageLbl.Text = $"Age :       {Age}";
            _userView.bmiLbl.Text = $"IMC :       {_bmi:F2}";

            _modifyView.idTxtBx.Text = UserName;
            _modifyView.pswTxtBx.Text = Password;
            _modifyView.confirmPswTxtBx.Text = Password;
            _modifyView.heightTxtBx.Text = Height;
            _modifyView.weightTxtBx.Text = Weight;

            _menuView.userLbl.Text = UserName;

            if (Sex == "M")
            {
                _modifyView.maleRdBtn.Checked = true;
                _menuView.userBtn.BackgroundImage = Properties.Resources.Muser;
            }
            if (Sex == "F")
            {
                _modifyView.femaleRdBtn.Checked = true;
                _menuView.userBtn.BackgroundImage = Properties.Resources.Fuser;
            }
        }

        public void AbandonModification()
        {
            if (_modifyView.idTxtBx.Text != UserName || _modifyView.pswTxtBx.Text != Password || _modifyView.heightTxtBx.Text != Height || _modifyView.weightTxtBx.Text != Weight)
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

        public int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (DateTime.Today < birthDate.AddYears(age))
                age--;

            Age = age.ToString();

            return age;
        }
    }
}
