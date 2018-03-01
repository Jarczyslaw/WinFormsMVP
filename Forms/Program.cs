using Core.Presenters;
using Core.ViewsAbstraction;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Forms;

namespace Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMainView mainView = new MainForm();
            IUsersRepository usersRepository = new UsersRepository();

            var mainPresenter = new MainPresenter(mainView, usersRepository);
            mainPresenter.ShowView();
        }
    }
}
