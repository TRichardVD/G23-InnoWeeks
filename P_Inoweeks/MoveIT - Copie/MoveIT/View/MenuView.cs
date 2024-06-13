using System;
using System.Windows.Forms;

namespace MoveIT
{
    public partial class MenuView : Form
    {
        public Controller Controller { get; set; }

        public MenuView()
        {
            InitializeComponent();
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            Controller.ShowUser_Click();
            this.Hide();
        }

        private void modifyBtn_Click(object sender, System.EventArgs e)
        {
            Controller.ShowModify_Click();
            this.Hide();
        }

        private void selectRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (selectRadBtn.Checked)
            {
                mBodyPnl.Location = new System.Drawing.Point(300, 20);
                fBodyPnl.Location = new System.Drawing.Point(300, 20);
                selectRadBtn.BackgroundImage = Properties.Resources.checkbox;
                if (Controller.Sex == "M")
                    mBodyPnl.Visible = true;   
                if(Controller.Sex == "F")
                    fBodyPnl.Visible = true;
            }

            else
            {
                selectRadBtn.BackgroundImage = Properties.Resources.uncheckbox;
                mBodyPnl.Visible = false;
                fBodyPnl.Visible = false;
            }
        }

        private void listRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (listRadBtn.Checked)
            {
                listRadBtn.BackgroundImage = Properties.Resources.checkbox;
                infoPnl.Show();
            }

            else
            {
                listRadBtn.BackgroundImage = Properties.Resources.uncheckbox;
                infoPnl.Hide();
            }
        }

        private void chatRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (chatRadBtn.Checked)
            {
                chatRadBtn.BackgroundImage = Properties.Resources.checkbox;
            }

            else
            {
                chatRadBtn.BackgroundImage = Properties.Resources.uncheckbox;
            }
        }

        private void mHeadBtn_MouseEnter(object sender, EventArgs e)
        {
            mHeadPnl.Visible = true;
        }

        private void headPnl_MouseLeave(object sender, EventArgs e)
        {
            mHeadPnl.Visible = false;
        }
        private void fHeadBtn_MouseEnter(object sender, EventArgs e)
        {
            fHeadPnl.Visible = true;
        }

        private void fHeadPnl_MouseLeave(object sender, EventArgs e)
        {
            fHeadPnl.Visible = false;
        }

        private void heightLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
