using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace FirstApp
{
    public static class IoC
    {
        #region Public Properties

        public static IKernel Kernel { get; private set; } = new StandardKernel();

        #endregion

        #region Construction

        public static void Setup()
        {
            BindViewModels();
        }

        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
