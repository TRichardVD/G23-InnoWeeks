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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (options2ChckBx.Checked)
            {
                options2ChckBx.BackgroundImage = Properties.Resources.checkbox;
                infoPnl.Hide();
                if(Controller.Sex == "M")
                {

                }
                if(Controller.Sex == "F")
                {

                }
            }

            else
            {
                options2ChckBx.BackgroundImage = Properties.Resources.uncheckbox;
                infoPnl.Show();
            }
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            Controller.ShowUser();
            this.Hide();
        }

        private void infoPnl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
