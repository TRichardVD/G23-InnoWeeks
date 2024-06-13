using Mysqlx;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private readonly WarningPopup _warningPopup;
        private readonly ModifyView _modifyView;
        private readonly Model _model;

        private string _currentView;
        private User _newUser;
        private User _actualName = new User();
        private List<User> _usersList = new List<User>();

        public string Mail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Sex { get; set; }

        private const string ERROR = "Erreur : ";
        private const string ERRORS = "Erreurs : ";

        private const string MAIL_PATTERN = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
        private const string NAME_PATTERN = @"^[A-Za-zÀ-ÖØ-öø-ÿ\- ']+$";
        private const string PASSWORD_PATTERN = @"^(?=.*\d)(?=.*[^a-zA-Z0-9,]).{12,}$";
        private const string HEIGHT_PATTERN = @"^(50|[5-9]\d|1\d{2}|2\d{2}|300)$";
        private const string WEIGHT_PATTERN = @"^\d{1,3}([,.]\d{1,2})?$";

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
            _warningPopup = ShowWarningPopup();

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

        public void ShowMenu(Form form)
        {
            Update();
            _menuView.Location = new Point(form.Location.X, form.Location.Y);
            _menuView.Show();
        }

        public void ShowLogin(Form form)
        {
            _loginView.Location = new Point(form.Location.X, form.Location.Y);
            _loginView.Show();
        }

        public void ShowUser(Form form)
        {
            Update();
            _userView.Location = new Point(form.Location.X, form.Location.Y);
            _userView.Show();
        }

        public void ShowRegister(Form form)
        {
            _registerView.Location = new Point(form.Location.X, form.Location.Y);
            _registerView.Show();
            _currentView = "register";
        }

        public void ShowModify(Form form)
        {
            _modifyView.Location = new Point(form.Location.X, form.Location.Y);
            _modifyView.Show();
            _currentView = "modify";
        }

        public void ShowRegister_Click()
        {
            ShowRegister(_loginView);
        }

        public void ShowUser_Click()
        {
            ShowUser(_menuView);
        }

        public void ShowModify_Click()
        {
            ShowModify(_userView);
        }


        public void ShowWarningPopup()
        {
            ShowModify(_WarningPopup);
        }


        public void CreateNewUser(string mail, string name, string password, string age, string height, string weight, string sex)
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
                _newUser = new User(mail, name, password, Convert.ToInt32(age), Convert.ToInt32(height), Convert.ToDouble(weight.Replace(',', '.')), sex);

                UserList.Add(_newUser);
                SaveUser();

                _registerView.idTxtBx.Text = "";
                _registerView.pswTxtBx.Text = "";
                _registerView.confirmPswTxtBx.Text = "";
                _registerView.heightTxtBx.Text = "";
                _registerView.weightTxtBx.Text = "";
                _registerView.maleRdBtn.Checked = true;

                MessageBox.Show("Le nouveau compte a été créé", "Réussite", MessageBoxButtons.OK);
                ShowLogin(_registerView);
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
            _actualName.Name = _menuView.userLbl.Text;

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
                            user.Sex = "M";
                        if (_modifyView.femaleRdBtn.Checked)
                            user.Sex = "F";

                        // Met à jour les propriétés de l'utilisateur actuel dans le contrôleur
                        Name = user.Name;
                        Password = user.Password;
                        Age = user.Age.ToString();
                        Height = user.Height.ToString();
                        Weight = user.Weight.ToString();
                        Sex = user.Sex;

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

            userNameToDelete.Name = _menuView.userLbl.Text;

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
                ShowLogin(_modifyView);
            }
        }

        public string CheckIfEntryIsOk(string mail, string name, string password, string height, string weight)
        {
            string error = ERROR;
            string errors = ERRORS;

            if (!Regex.IsMatch(mail, MAIL_PATTERN))
                error += error.Length > errors.Length ? ", email" : "Email";
            if (!Regex.IsMatch(name, NAME_PATTERN))
                error += error.Length > errors.Length ? ", identifiant" : "Identifiant";
            if (!Regex.IsMatch(password, PASSWORD_PATTERN))
                error += error.Length > errors.Length ? ", mot de passe" : "Mot de passe";
            if (!Regex.IsMatch(height, HEIGHT_PATTERN))
                error += error.Length > errors.Length ? ", taille" : "Taille";
            if (!Regex.IsMatch(weight, WEIGHT_PATTERN))
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
        public void NewUser(string mail, string name, string password, string age, string height, string weight, string gender)
        {
            string error = ERROR;
            string errors = ERRORS;

            error = CheckIfEntryIsOk(mail, name, password, height, weight);

            if (error == ERROR)
            {
                if (_currentView == "register")
                    CreateNewUser(mail, name, password, age, height, weight, gender);
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
            _menuView.userLbl.Text = Name;
            _menuView.heightLbl.Text = $"Taille : {Height} cm";
            _menuView.weightLbl.Text = $"Poids :  {Weight} kg";
            _menuView.ageLbl.Text =    $"Age :    {Age}";
            _menuView.bmiLbl.Text =    $"IMC :    {_bmi:F2}";

            _modifyView.idTxtBx.Text = Name;
            _modifyView.pswTxtBx.Text = Password;
            _modifyView.confirmPswTxtBx.Text = Password;
            _modifyView.heightTxtBx.Text = Height;
            _modifyView.weightTxtBx.Text = Weight;

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
            if (_modifyView.idTxtBx.Text != Name || _modifyView.pswTxtBx.Text != Password || _modifyView.heightTxtBx.Text != Height || _modifyView.weightTxtBx.Text != Weight)
            {
                DialogResult result = MessageBox.Show("Voulez-vous abandonner la modification ?", "Attention", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    ShowMenu(_modifyView);
                    _modifyView.Hide();
                }
            }
            else
            {
                ShowMenu(_modifyView);
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
