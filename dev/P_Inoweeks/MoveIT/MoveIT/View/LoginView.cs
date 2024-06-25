using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoveIT
{
    public partial class LoginView : Form
    {
        public Controller Controller { get; set; }

        public LoginView()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Controller.Login();            
            mailTxtBx.Text = "";
            pswTxtBx.Text = "";
        }

        private void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            Controller.ShowRegister_Click();
            this.Hide();
        }

        private void viewPswBtn_MouseDown(object sender, MouseEventArgs e)
        {
            viewPswBtn.BackgroundImage = Properties.Resources.openEye;
            pswTxtBx.UseSystemPasswordChar = true;            
        }

        private void viewPswBtn_MouseUp(object sender, MouseEventArgs e)
        {
            viewPswBtn.BackgroundImage = Properties.Resources.closedEye;
            pswTxtBx.UseSystemPasswordChar = false;            
        }

        // Méthode pour gérer l'événement Enter pour les champs de texte
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox == pswTxtBx)
            {
                textBox.PasswordChar = '\u25CF'; // Définir le caractère de masquage du mot de passe comme un cercle (●)
            }

            if (textBox.ForeColor == Color.Gray)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        // Méthode pour gérer l'événement Leave pour les champs de texte
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == mailTxtBx)
                {
                    textBox.Text = "Adresse mail";
                }
                else if (textBox == pswTxtBx)
                {
                    textBox.Text = "Mot de passe";
                    textBox.PasswordChar = '\0'; // Réinitialiser le caractère de masquage du mot de passe
                }
                textBox.ForeColor = Color.Gray;
            }
        }

        // Méthode pour gérer l'événement KeyPress
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Annuler l'événement KeyPress

                // Si l'utilisateur est dans le champ de mot de passe, simuler un clic sur le bouton de connexion
                if (sender == pswTxtBx)
                {
                    loginBtn.PerformClick();
                }
            }
        }

        private void showMessageLbl_Click(object sender, EventArgs e)
        {
            Controller.ShowMessage();
        }
    }
}
