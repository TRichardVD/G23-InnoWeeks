
using System.Windows.Forms;

namespace MoveIT
{
    public partial class UserView : Form
    {
        public Controller Controller { get; set; }

        public UserView()
        {
            InitializeComponent();
        }

        private void menuBtn_Click(object sender, System.EventArgs e)
        {
            Controller.ShowMenu(this);
            this.Hide();
        }

        private void addWeightBtn_Click(object sender, System.EventArgs e)
        {
            if(weightTxtBx.Text != "")
            {
                Controller.AddWeight();
                Controller.LoadWeightData();
            }
            else
                MessageBox.Show("Veuillez indiquer le poids à ajouter/modifier", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addWeightBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                addWeightBtn.PerformClick();                
            }
        }
    }
}