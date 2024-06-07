
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

        private void modifyBtn_Click(object sender, System.EventArgs e)
        {
            Controller.ShowModify();
            this.Hide();
        }

        private void menuBtn_Click(object sender, System.EventArgs e)
        {
            Controller.ShowMenu();
            this.Hide();
        }
    }
}
