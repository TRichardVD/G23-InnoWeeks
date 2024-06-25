using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoveIT
{
    public partial class MessageView : Form
    {
        public Controller Controller { get; set; }
        public MessageView()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merci d'avoir lu l'avertissement. Profitez de l'application!", "Confirmation");
            this.Close();
        }
    }
}
