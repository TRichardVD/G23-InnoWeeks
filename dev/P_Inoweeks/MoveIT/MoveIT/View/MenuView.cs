using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            Controller.LoadWeightData();
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
                searchPnl.Show();
            }

            else
            {
                listRadBtn.BackgroundImage = Properties.Resources.uncheckbox;
                infoPnl.Hide();
                searchPnl.Hide();
            }
        }

        private void chatRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (chatRadBtn.Checked)
            {
                chatRadBtn.BackgroundImage = Properties.Resources.checkbox;
                chatPnl.Location = new Point(195, 2);
                chatPnl.Show();
            }

            else
            {
                chatRadBtn.BackgroundImage = Properties.Resources.uncheckbox;
                chatPnl.Hide();
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

        private void Label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                string key = clickedLabel.Text;
                string info = Controller.GetBodyPartInfo(key);
                MessageBox.Show(info, key, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                string key = clickedButton.Tag.ToString();
                string info = Controller.GetBodyPartInfo(key);
                MessageBox.Show(info, key, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            Label enterLabel = sender as Label;
            if (enterLabel != null)           
                enterLabel.Font = new Font(enterLabel.Font, FontStyle.Bold);            
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label enterLabel = sender as Label;
            if (enterLabel != null)
                enterLabel.Font = new Font(enterLabel.Font, FontStyle.Regular);
        }

        private void promptTxtBx_TextChanged(object sender, EventArgs e)
        {
            string searchText = promptTxtBx.Text.ToLower();

            // Parcour tous les labels dans le panel infoPnl
            foreach (Control control in infoPnl.Controls)
            {
                if (control is Label label)
                {
                    string labelText = label.Text.ToLower();
                    if(promptTxtBx.Text != "")
                    {
                        // Vérifie si le texte de la TextBox est contenu dans le texte du Label
                        if (labelText.Contains(searchText))
                        {
                            // Met en avant le Label avec une couleur de fond IndianRed
                            label.BackColor = Color.IndianRed;
                        }
                        else
                        {
                            // Rétablit la couleur de fond par défaut du Label
                            label.BackColor = Color.White; 
                        }
                    }
                    else
                        label.BackColor = Color.White;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Controller.Send_Click();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Annuler l'événement KeyPress

                if (sender == searchTxtBx)
                {
                    btnSend.PerformClick();
                }
            }
        }
    }
}
