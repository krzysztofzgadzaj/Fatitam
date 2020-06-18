using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FirstApp
{
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {

        private VM viewModel;

        #region Public properties


        public PageAnimation InAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation OutAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        public float DurationTime { get; set; } = 0.6f;

        public VM ViewModel {
            get { return viewModel; }
            set
            {
                if (viewModel == value)
                    return;

                viewModel = value;
                this.DataContext = viewModel;
            }
        }

        #endregion

        #region Constructors

        public BasePage()
        {
            if (this.InAnimation != PageAnimation.NoAnimation)
                this.Visibility = System.Windows.Visibility.Collapsed;

            this.Loaded += BasePage_LoadedAsync;
            ViewModel = new VM();
        }

        ~BasePage()
        {
             AnimationOutAsync();
        }

        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimationInAsync();
        }

        #endregion

        public async Task AnimationInAsync()
        {
            
            switch (InAnimation)
            {
                case PageAnimation.NoAnimation:
                    return;

                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(DurationTime);
                    break;

                case PageAnimation.FadeIn:
                    await this.FadeIn(DurationTime);
                    break;

                case PageAnimation.SlideAndFadeInFromLeft:
                    await this.SlideAndFadeInFromLeft(DurationTime);
                    break;

                default:
                    break;
            }
        }

        public async Task AnimationOutAsync()
        {

            switch (OutAnimation)
            {
                case PageAnimation.NoAnimation:
                    return;

                case PageAnimation.SlideAndFadeOutToLeft:

                    await this.SlideAndFadeOutToLeft(DurationTime);
                    break;

                default:
                    break;
            }
        }

    }
}
