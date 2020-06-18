using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FirstApp
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Public Properties

        public string Email { get; set; }
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }
        public ICommand GoToRegisterCommand { get; set; }

        #endregion

        #region Constructor

        public LoginPageViewModel()
        {
            LoginCommand = new RelayParamCommand(async (parameter) => await Login(parameter));
            GoToRegisterCommand = new RelayCommand(async () => await RegisterPage());
        }

        #endregion

        public async Task Login(object parameter)
        {
            await RunExpression(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(3000);
            
                var email = this.Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

                IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.MainAppPage;
            });
            
        }

        public async Task RegisterPage()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.RegisterPage;
            await Task.Delay(1);
        }
    }
}
