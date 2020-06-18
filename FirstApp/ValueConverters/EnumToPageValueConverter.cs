using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    public class EnumToPageValueConverter : BaseValueConverter<EnumToPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ApplicationPage)value)
            {
                case ApplicationPage.LoginPage:
                    return new LoginPage();

                case ApplicationPage.RegisterPage:
                    return new RegisterPage();

                case ApplicationPage.MainAppPage:
                    return new MainApplicationPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
