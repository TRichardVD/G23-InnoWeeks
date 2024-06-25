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
            // Récupération des données depuis les champs de texte et contrôles
            string name = idTxtBx.Text;
            string password = Controller.Password;
            if (pswTxtBx.Text != "" && newPswTxtBx.Text != "")            
                password = newPswTxtBx.Text;            
            DateTime birthDate = birthdateDtTmPkr.Value;
            string height = heightTxtBx.Text;

            // Calcul de l'âge à partir de la date de naissance
            int age = Controller.CalculateAge(birthDate);

            // Modification des données de l'utilisateur via le contrôleur
            Controller.ModifyUser(name, password, age.ToString(), birthDate, height);

            // Appel de la méthode de mise à jour dans le contrôleur
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

        private void viewNewPswBtn_MouseDown(object sender, MouseEventArgs e)
        {
            viewNewPswBtn.BackgroundImage = Properties.Resources.openEye;
            newPswTxtBx.UseSystemPasswordChar = false;
        }

        private void viewNewPswBtn_MouseUp(object sender, MouseEventArgs e)
        {
            viewNewPswBtn.BackgroundImage = Properties.Resources.closedEye;
            newPswTxtBx.UseSystemPasswordChar = true;
        }
    }
}
