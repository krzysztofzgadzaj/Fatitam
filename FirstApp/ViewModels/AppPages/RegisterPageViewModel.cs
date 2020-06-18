using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirstApp
{
    public class RegisterPageViewModel : BaseViewModel
    {
        #region Public Properties

        public string Login { get; set; }
        public string Email { get; set; }       
        public bool RegisterIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand RegisterCommand { get; set; }
        public ICommand BackToLoginPageCommand { get; set; }

        #endregion

        #region Constructor

        public RegisterPageViewModel()
        {
            RegisterCommand = new RelayParamCommand(async (parameter) => await Register(parameter));
            BackToLoginPageCommand = new RelayCommand(async () => await BackToLoginPage());
        }

        #endregion

        private async Task Register(object parameter)
        {
            await RunExpression(() => this.RegisterIsRunning, async () =>
            {
                OnPropertyChanged(nameof(RegisterIsRunning));
                await Task.Delay(3000);

                var Login = this.Login;
                var email = this.Email;

                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

                IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.LoginPage;
            });
            OnPropertyChanged(nameof(RegisterIsRunning));
        }

        private async Task BackToLoginPage()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.LoginPage;

            await Task.Delay(1);
        }
    }
}
