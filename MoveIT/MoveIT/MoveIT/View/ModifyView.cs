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
            string name = idTxtBx.Text;
            string password = pswTxtBx.Text;
            string age = ageTxtBx.Text;
            string height = heightTxtBx.Text;
            string weight = weightTxtBx.Text;
            // Modifie les données de l'utilisateur
            Controller.ModifyUser(name, password, age, height, weight);
            Controller.Update();
        }

        private void menuBtn_Click(object sender, EventArgs e)
        {
            Controller.AbandonModification();
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
