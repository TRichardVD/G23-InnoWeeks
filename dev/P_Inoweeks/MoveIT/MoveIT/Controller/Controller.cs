using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using SimMetrics.Net.API;
using SimMetrics.Net.Metric;
using System.Windows.Forms.DataVisualization.Charting;


namespace MoveIT
{
    public class Controller
    {
        private readonly LoginView _loginView;
        private readonly RegisterView _registerView;
        private readonly MenuView _menuView;
        private readonly UserView _userView;
        private readonly ModifyView _modifyView;
        private readonly MessageView _messageView;
        private readonly Model _model;

        private string _currentView;

        private User _newUser;
        private List<User> _usersList = new List<User>();

        private const int SALT_LENGTH = 40;

        private bool _log = false;

        public string Mail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
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
        private const string TEXT_PATTERN = @"^[\w\s',\.!?:;éèàêûô]{2,}$";

        private double _bmi;

        public List<User> UserList
        {
            get => _usersList;
            set => _usersList = value;
        }

        public Controller(LoginView loginView, RegisterView registerView, MenuView menuView, UserView userView, ModifyView modifyView, MessageView messageView, Model model)
        {
            _loginView = loginView;
            _registerView = registerView;
            _menuView = menuView;
            _userView = userView;
            _modifyView = modifyView;
            _messageView = messageView;
            _model = model;

            loginView.Controller = this;
            registerView.Controller = this;
            menuView.Controller = this;
            userView.Controller = this;
            modifyView.Controller = this;
            _messageView.Controller = this;
            model.Controller = this;

            UserList = new List<User>();
            RegisterUser();
        }


        public void RegisterUser()
        {
            _usersList = _model.ListUsers();
        }

        public void AddWeight()
        {
            User currentUser = new User();

            currentUser.Mail = Mail;

            if (_userView.weightTxtBx.Text != "")
                currentUser.Weight = Convert.ToDouble(_userView.weightTxtBx.Text);

            Weight = currentUser.Weight.ToString();

            GetBMI();

            _model.AddWeightInDb(currentUser);
        }

        private void GetBMI()
        {
            _bmi = Convert.ToDouble(Weight) / Math.Pow(Convert.ToDouble(Height) / 100, 2);
        }

        public void ShowMessage()
        {
            _messageView.Show();
        }

        public void ShowMenu(Form form)
        {
            _menuView.Location = new Point(form.Location.X, form.Location.Y);
            Update();
            _menuView.Show();
        }

        public void ShowLogin(Form form)
        {
            _loginView.Location = new Point(form.Location.X, form.Location.Y);
            _loginView.Show();
        }

        public void ShowUser(Form form)
        {
            _userView.Location = new Point(form.Location.X, form.Location.Y);
            Update();
            _userView.Show();
        }

        public void ShowRegister(Form form)
        {
            _registerView.Location = new Point(form.Location.X, form.Location.Y);
            _registerView.Show();
            _currentView = "register";
        }

        /// <summary>
        /// Affiche la page de modification du compte
        /// </summary>
        public void ShowModify(Form form)
        {
            _modifyView.Location = new Point(form.Location.X, form.Location.Y);
            _modifyView.Show();
            _currentView = "modify";
        }

        /// <summary>
        /// Affiche la page de modification du compte
        /// </summary>
        public void ShowModify_Click()
        {
            ShowModify(_userView);
        }

        /// <summary>
        /// Affiche la page d'inscription
        /// </summary>
        public void ShowRegister_Click()
        {
            ShowRegister(_loginView);
        }

        /// <summary>
        /// Affiche la page de l'utilisateur
        /// </summary>
        public void ShowUser_Click()
        {
            ShowUser(_menuView);
        }



        /// <summary>
        /// Crypte le mot de passe
        /// </summary>
        /// <param name="clearPassword">Mot de passe non crypté</param>
        /// <returns></returns>
        private static string HashPassword(string clearPassword)
        {
            string salt = "";
            string hashPassword = "";
            int randomDigit;

            Random random = new Random();

            for (int i = 0; i < SALT_LENGTH; i++)
            {
                // Génère un chiffre entre 0 et 9
                randomDigit = random.Next(0, 10);
                salt += randomDigit.ToString();
            }

            clearPassword += salt;

            // Convertir le mot de passe clair en tableau de bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(clearPassword);

            // Créer un objet de hachage SHA-256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Calcule le hachage du mot de passe
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                // Converti le tableau de bytes haché en une chaîne hexadécimale
                hashPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            return hashPassword + salt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="mail"></param>
        /// <returns></returns>
        private string MasterPasswordVerification(string userInput, string mail)
        {
            User verifyUser = new User();
            foreach (User user in UserList)
            {
                if (user.Mail == mail)
                {
                    verifyUser = user;
                }
            }
            string hashMasterPassword = verifyUser.Password;

            // Extrait le sel en clair
            string salt = hashMasterPassword.Substring(hashMasterPassword.Length - SALT_LENGTH);

            string hashPassword = "";

            userInput += salt;

            // Convertir le mot de passe clair en tableau de bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(userInput);

            // Créer un objet de hachage SHA-256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Calcule le hachage du mot de passe
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                // Converti le tableau de bytes haché en une chaîne hexadécimale
                hashPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            // Retourne le userInput hash avec le sel du MasterPassword + le sel en clair
            return hashPassword + salt;
        }

        public void CreateNewUser(string mail, string name, string password, string age, DateTime birthdate, string height, string weight, string sex)
        {
            foreach (User user in UserList)
            {
                if (mail == user.Mail)
                {
                    MessageBox.Show("L'utilisateur existe déjà", "Erreur", MessageBoxButtons.OK);
                    return;
                }
            }

            if (password == _registerView.confirmPswTxtBx.Text)
            {
                _newUser = new User(mail, name, HashPassword(password), Convert.ToInt32(age), birthdate, Convert.ToInt32(height), Convert.ToDouble(weight.Replace(',', '.')), sex);

                UserList.Add(_newUser);

                Mail = mail;
                Name = name;
                Age = age;
                BirthDate = birthdate;
                Height = height;
                Weight = weight;
                Sex = sex;

                SaveUser();

                // Réinitialise les champs du formulaire d'inscription après l'ajout
                ClearRegisterFields();
            }
            else
            {
                MessageBox.Show("Le mot de passe ne correspond pas", "Erreur", MessageBoxButtons.OK);
            }
        }

        private void ClearRegisterFields()
        {
                _registerView.mailTxtBx.Text = "";
                _registerView.idTxtBx.Text = "";
                _registerView.pswTxtBx.Text = "";
                _registerView.confirmPswTxtBx.Text = "";
                _registerView.birthdateDtTmPkr.Value = _registerView.birthdateDtTmPkr.MaxDate;
                _registerView.heightTxtBx.Text = "";
                _registerView.weightTxtBx.Text = "";
                _registerView.maleRdBtn.Checked = true;
        }

        public void AbandonRegister()
        {
            if (_registerView.mailTxtBx.Text != "" || _registerView.idTxtBx.Text != "" || _registerView.pswTxtBx.Text != "" || _registerView.confirmPswTxtBx.Text != "" || _registerView.heightTxtBx.Text != "" || _registerView.weightTxtBx.Text != "" || _registerView.birthdateDtTmPkr.Value != _registerView.birthdateDtTmPkr.MaxDate)
            {
                DialogResult result = MessageBox.Show("Voulez-vous abandonner l'inscription ?", "Attention", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    ClearRegisterFields();
                    ShowLogin(_registerView);
                    _registerView.Hide();
                }
            }
            else
            {
                ShowLogin(_registerView);
                _registerView.Hide();
            }
        }

        private void SaveUser()
        {
            _model.InsertIntoDB(_newUser);
            AddWeight();
        }

        public void ModifyUser(string name, string password, string age, DateTime birthDate, string height)
        {
            User currentUser = new User();

            currentUser.Mail = Mail;

            if(_modifyView.pswTxtBx.Text == "" && _modifyView.confirmPswTxtBx.Text == "" && _modifyView.newPswTxtBx.Text == "")
            {
                foreach (User user in UserList)
                {
                    if (user.Mail == currentUser.Mail)
                    {
                        user.Name = name;
                        user.BirthDate = birthDate;
                        user.Age = CalculateAge(birthDate);
                        user.Height = Convert.ToInt32(height);
                      
                        if (_modifyView.maleRdBtn.Checked)
                            user.Sex = "M";
                        if (_modifyView.femaleRdBtn.Checked)
                            user.Sex = "F";

                        // Met à jour les propriétés de l'utilisateur actuel dans le contrôleur
                        Name = user.Name;
                        Age = user.Age.ToString();
                        BirthDate = birthDate;
                        Height = user.Height.ToString();
                        Sex = user.Sex;

                        // Met à jour les données de l'utilisateur de la base de données
                        _model.UpdateInDB(user);
                        break;
                    }
                }                
            }
            else
            {
                if (password == _modifyView.confirmPswTxtBx.Text)
                {
                    foreach (User user in UserList)
                    {
                        if (user.Mail == currentUser.Mail)
                        {
                            user.Name = name;
                            user.Password = HashPassword(password);
                            user.BirthDate = birthDate;
                            user.Age = CalculateAge(birthDate);
                            user.Height = Convert.ToInt32(height);

                            if (_modifyView.maleRdBtn.Checked)
                                user.Sex = "M";
                            if (_modifyView.femaleRdBtn.Checked)
                                user.Sex = "F";

                            // Met à jour les propriétés de l'utilisateur actuel dans le contrôleur
                            Name = user.Name;
                            Password = user.Password;
                            Age = user.Age.ToString();
                            BirthDate = birthDate;
                            Height = user.Height.ToString();
                            Weight = user.Weight.ToString();
                            Sex = user.Sex;

                            // Met à jour les données de l'utilisateur de la base de données
                            _model.UpdateInDB(user);
                            break;
                        }
                    }
                }
                else
                    MessageBox.Show("Le mot de passe ne correspond pas", "Erreur", MessageBoxButtons.OK);
            }
        }        

        public void DeleteUser()
        {
            User currentUser = new User();

            currentUser.Mail = Mail;
            currentUser.Name = Name;

            // Affiche une boîte de dialogue de confirmation
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le compte ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Vérifie la réponse de l'utilisateur
            if (result == DialogResult.Yes)
            {
                // Appelle la méthode DeleteFromDB pour supprimer l'utilisateur de la base de données
                _model.DeleteFromDB(currentUser);

                // Supprime l'utilisateur de la liste locale
                foreach (User user in _usersList)
                {
                    if (user.Name == currentUser.Name)
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
        /// <param name="birthDate"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="gender"></param>
        public void NewUser(string mail, string name, string password, string age, DateTime birthDate, string height, string weight, string gender)
        {
            string error = ERROR;
            string errors = ERRORS;

            error = CheckIfEntryIsOk(mail, name, password, height, weight);

            if (error == ERROR)
            {
                if (_currentView == "register")
                    CreateNewUser(mail, name, password, age, birthDate, height, weight, gender);
                if (_currentView == "modify")
                    ModifyUser(name, password, age, birthDate, height);
            }
            else
            {
                MessageBox.Show(error.Length > errors.Length ? $"{error} ne correspond pas à la réglementation de nommage." : $"{errors} ne correspondent pas à la réglementation de nommage.");
            }
        }

        public void Login()
        {
            _log = false;

            foreach (User user in UserList)
            {
                if (user.Mail == _loginView.mailTxtBx.Text)
                {
                    _log = true;

                    if (user.Password == MasterPasswordVerification(_loginView.pswTxtBx.Text, user.Mail))
                    {
                        _log = true;

                        // Recupert les données de l'utilisateur
                        Mail = user.Mail;
                        Name = user.Name;
                        Password = user.Password;
                        BirthDate = user.BirthDate;
                        Height = user.Height.ToString();
                        Weight = user.Weight.ToString();
                        Sex = user.Sex;

                        // Affiche le menu principal
                        ShowMenu(_loginView);
                        _loginView.Hide();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Le mot de passe ne correspond pas", "Erreur", MessageBoxButtons.OK);
                        _log = true;
                        break;
                    }
                }
                else
                    _log = false;
            }

            if (!_log)
                MessageBox.Show("Le compte n'existe pas", "Erreur", MessageBoxButtons.OK);
        }

        public void Update()
        {
            GetBMI();
            _menuView.userLbl.Text = Name;
            _menuView.heightLbl.Text = $"Taille : {Height} cm";
            _menuView.weightLbl.Text = $"Poids :  {Weight} kg";
            _menuView.ageLbl.Text = $"Age :    {Age}";
            _menuView.bmiLbl.Text = $"IMC :    {_bmi:F2}";

            _modifyView.idTxtBx.Text = Name;
            _modifyView.birthdateDtTmPkr.Value = BirthDate;
            _modifyView.heightTxtBx.Text = Height;

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
            if (_modifyView.idTxtBx.Text != Name || _modifyView.pswTxtBx.Text != "" || _modifyView.heightTxtBx.Text != Height)
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
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - birthDate.Year;

            // Vérifier si l'anniversaire de cette année n'est pas encore arrivé
            if (birthDate.Date > currentDate.AddYears(-age))
                age--;

            return age;
        }

        public string GetBodyPartInfo(string bodyPart)
        {
            string valueOfKey = "Information non disponible.";

            foreach (string partBody in _model.PartBodyAndMessage.Keys)
            {
                if (partBody.Contains(bodyPart.ToLower()))
                {
                    if (_model.PartBodyAndMessage.TryGetValue(partBody, out string value))
                    {
                        valueOfKey = value;
                        break;
                    }
                }
            }
            return valueOfKey;
        }

        public void Send_Click()
        {
            if (!Regex.IsMatch(_menuView.searchTxtBx.Text, TEXT_PATTERN))
            {
                MessageBox.Show("Vous devez écrire une partie de votre corps qui vous gêne !");
            }
            else
            {
                string request = _menuView.searchTxtBx.Text;

                Label userLabel = new Label();
                userLabel.Text = request;
                userLabel.Width = 320;
                userLabel.Height = CalculateLabelHeight(userLabel.Text);
                userLabel.AutoEllipsis = true;
                userLabel.Location = new Point(_menuView.answerPnl.Width - userLabel.Width - 5, CalculateNextLabelPosition());
                userLabel.BackColor = Color.CornflowerBlue;
                userLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                userLabel.BorderStyle = BorderStyle.None;
                userLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                _menuView.answerPnl.Controls.Add(userLabel);

                ChatResponse(request);

                _menuView.answerPnl.ScrollControlIntoView(userLabel);
            }

            _menuView.searchTxtBx.Text = string.Empty;
            _menuView.searchTxtBx.Focus();
        }

        public void ChatResponse(string request)
        {
            // Supprimer tous les caractères spéciaux sauf lettres, chiffres, espaces et tirets
            string cleanedRequest = Regex.Replace(request, @"[^a-zA-Z0-9\s\-]", "");

            // Remplacer les accents
            cleanedRequest = cleanedRequest
                .Replace("é", "e")
                .Replace("è", "e")
                .Replace("à", "a")
                .Replace("ê", "e")
                .Replace("û", "u")
                .Replace("ô", "o");

            // Convertir en minuscules et séparer par mots
            string[] requestWords = cleanedRequest.Trim().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Liste pour stocker les messages trouvés
            List<string> messagesToDisplay = new List<string>();

            // Parcourir chaque mot de la phrase
            foreach (string word in requestWords)
            {
                // Vérifier si le mot exact existe dans le dictionnaire
                if (_model.PartBodyAndMessage.ContainsKey(word))
                {
                    // Récupérer le message correspondant au mot
                    _model.PartBodyAndMessage.TryGetValue(word, out string message);

                    // Ajouter le message à la liste des messages à afficher
                    messagesToDisplay.Add(message);
                }
                else
                {
                    // Si le mot exact n'est pas trouvé, rechercher les correspondances avec SimMetrics
                    var matches = _model.PartBodyAndMessage.Keys
                        .Select(key => new { Word = key, Similarity = GetSimilarity(word, key) })
                        .OrderByDescending(x => x.Similarity);

                    // Récupérer toutes les correspondances avec une similarité suffisamment élevée
                    var validMatches = matches.Where(m => m.Similarity > 0.9);

                    // Parcourir les correspondances valides trouvées
                    foreach (var match in validMatches)
                    {
                        _model.PartBodyAndMessage.TryGetValue(match.Word, out string message);

                        // Ajouter le message à la liste des messages à afficher, uniquement s'il n'a pas déjà été ajouté
                        if (!messagesToDisplay.Contains(message))
                        {
                            messagesToDisplay.Add(message);
                        }
                    }
                }
            }

            // Si des messages ont été trouvés, les afficher
            if (messagesToDisplay.Count > 0)
            {
                // Construire le texte à afficher en concaténant tous les messages trouvés
                string responseText = string.Join(Environment.NewLine, messagesToDisplay);

                // Créer une étiquette de réponse avec le message construit
                Label responseLabel = new Label();
                responseLabel.Text = responseText;
                responseLabel.Width = 320;
                responseLabel.Height = CalculateLabelHeight(responseText);
                responseLabel.AutoEllipsis = true;
                responseLabel.Location = new Point(5, CalculateNextLabelPosition());
                responseLabel.BackColor = Color.IndianRed;
                responseLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                responseLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                responseLabel.BorderStyle = BorderStyle.None;

                _menuView.answerPnl.Controls.Add(responseLabel);
                _menuView.answerPnl.ScrollControlIntoView(responseLabel);
            }
            else
            {
                // Si aucun message n'a été trouvé, afficher un message par défaut
                string defaultMessage = "Veuillez reformuler votre phrase en évoquant une partie de votre corps qui vous gêne!";

                Label defaultLabel = new Label();
                defaultLabel.Text = defaultMessage;
                defaultLabel.Width = 320;
                defaultLabel.Height = CalculateLabelHeight(defaultMessage);
                defaultLabel.AutoEllipsis = true;
                defaultLabel.Location = new Point(5, CalculateNextLabelPosition());
                defaultLabel.BackColor = Color.IndianRed;
                defaultLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                defaultLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                defaultLabel.BorderStyle = BorderStyle.None;

                _menuView.answerPnl.Controls.Add(defaultLabel);
                _menuView.answerPnl.ScrollControlIntoView(defaultLabel);
            }

            // Nettoyer et réinitialiser l'entrée utilisateur
            _menuView.searchTxtBx.Text = string.Empty;
            _menuView.searchTxtBx.Focus();
        }

        // Méthode pour calculer la similarité entre deux chaînes avec SimMetrics
        private double GetSimilarity(string str1, string str2)
        {
            AbstractStringMetric metric = new JaroWinkler();
            return metric.GetSimilarity(str1, str2);
        }


        private int CalculateLabelHeight(string text)
        {
            // Calculer la hauteur du label en fonction de la longueur du texte
            int lines = (text.Length / 35) + 1;
            return lines * 25;
        }

        private int CalculateNextLabelPosition()
        {
            // Calculer la position Y pour le prochain label en fonction des hauteurs des labels existants
            int positionY = 10;
            foreach (Control control in _menuView.answerPnl.Controls)
            {
                if (control is Label)
                {
                    positionY = control.Bottom + 10;
                }
            }
            return positionY;
        }

        public void LoadWeightData()
        {
            var weights = _model.GetWeightsForUser(Mail);

            _userView.weightChart.Series.Clear();

            var series = new Series("Poids")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime
            };

            foreach (var (date, weight) in weights)
            {
                series.Points.AddXY(date, weight);
            }

            _userView.weightChart.Series.Add(series);

            // Configuration de l'axe X
            _userView.weightChart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
            _userView.weightChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
            _userView.weightChart.ChartAreas[0].AxisX.Interval = 1;

            // Configuration de l'axe Y pour afficher uniquement des dizaines
            _userView.weightChart.ChartAreas[0].AxisY.Minimum = Math.Floor(weights.Min(w => w.Weight) / 10) * 10;
            _userView.weightChart.ChartAreas[0].AxisY.Maximum = Math.Ceiling(weights.Max(w => w.Weight) / 10) * 10;
            _userView.weightChart.ChartAreas[0].AxisY.Interval = 10;

            _userView.weightChart.ChartAreas[0].AxisY.Title = "Poids (kg)";
            _userView.weightChart.ChartAreas[0].AxisX.Title = "Date";
        }
    }
}
