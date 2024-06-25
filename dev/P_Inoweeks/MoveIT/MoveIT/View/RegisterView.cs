using System;
using System.Windows.Forms;

namespace MoveIT
{
    public partial class RegisterView : Form
    {
        public Controller Controller { get; set; }

        public RegisterView()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // Mail de l'utilisateur
            string mail = mailTxtBx.Text;

            // Nom de l'utilisateur
            string name = idTxtBx.Text;

            // Mot de passe de l'utilisateur
            string password = pswTxtBx.Text;

            // Age de l'utilisateur
            DateTime birthDate = birthdateDtTmPkr.Value;
            int age = Controller.CalculateAge(birthDate);

            // Taille de l'utilisateur
            string height = heightTxtBx.Text;

            // Poids de l'utilisateur
            string weight = weightTxtBx.Text;

            // Sexe de l'utilisateur
            string gender = "";

            // Sexe de l'utilisateur
            if (maleRdBtn.Checked)
                gender = "M";
            if(femaleRdBtn.Checked)
                gender  = "F";

            // Créer les données de l'utilisateur
            Controller.NewUser(mail, name, password, age.ToString(), birthDate, height, weight, gender);
        }

        private void viewPswBtn_MouseDown(object sender, MouseEventArgs e)
        {
            viewPswBtn.BackgroundImage = Properties.Resources.openEye;
            pswTxtBx.UseSystemPasswordChar = false;
        }

        private void viewPswBtn_MouseUp(object sender, MouseEventArgs e)
        {
            viewPswBtn.BackgroundImage = Properties.Resources.closedEye;
            pswTxtBx.UseSystemPasswordChar = true;
        }

        private void viewConfirmPswBtn_MouseDown(object sender, MouseEventArgs e)
        {
            viewConfirmPswBtn.BackgroundImage = Properties.Resources.openEye;
            confirmPswTxtBx.UseSystemPasswordChar = false;
        }

        private void viewConfirmPswBtn_MouseUp(object sender, MouseEventArgs e)
        {
            viewConfirmPswBtn.BackgroundImage = Properties.Resources.closedEye;
            confirmPswTxtBx.UseSystemPasswordChar = true;
        }

        private void menuBtn_Click(object sender, EventArgs e)
        {
            Controller.AbandonRegister();
        }
    }
}
