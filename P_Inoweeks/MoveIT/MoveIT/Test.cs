using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveIT
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
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

        private void body_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if(clickedButton != null)
            {
                switch (clickedButton.Name)
                {
                    case "mHeadBtn":
                        MessageBox.Show("Tête");
                        break;
                    case "mNeckBtn":
                        MessageBox.Show("Cou");
                        break;
                }
            }
        }
    }
}
