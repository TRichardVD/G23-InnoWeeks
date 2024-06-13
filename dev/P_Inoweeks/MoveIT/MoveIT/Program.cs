using System;
using System.Windows.Forms;

namespace MoveIT
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Creation de la vue
            LoginView loginView = new LoginView();
            RegisterView registerView = new RegisterView();
            MenuView menuView = new MenuView();
            UserView userView = new UserView();
            ModifyView modifyView = new ModifyView();


            Test test = new Test();

            // Creation du modèle
            Model model = new Model();

            // Creation du contrôleur.
            Controller controller = new Controller(loginView, registerView, menuView, userView, modifyView, model);

            Application.Run(loginView);
        }
    }
}
