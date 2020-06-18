using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstApp
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterPageViewModel>, IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
            InAnimation = PageAnimation.SlideAndFadeInFromLeft;
        }

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
