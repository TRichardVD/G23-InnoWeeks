using Mysqlx.Crud;
using System;
using System.Windows.Forms;

namespace MoveIT
{
    public partial class ModifyView : Form
    {
        public Controller Controller { get; set; }

        public ModifyView()
        {
            InitializeComponent();
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
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

            // Modifie les données de l'utilisateur
            Controller.ModifyUser(name, password, age.ToString(), height, weight);
            Controller.Update();
        }

        private void menuBtn_Click(object sender, EventArgs e)
        {
            Controller.AbandonModification();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Controller.DeleteUser();
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

        private void viewConfirmBtnPsw_MouseUp(object sender, MouseEventArgs e)
        {
            viewConfirmPswBtn.BackgroundImage = Properties.Resources.closedEye;
            confirmPswTxtBx.UseSystemPasswordChar = true;
        }

    }
}
