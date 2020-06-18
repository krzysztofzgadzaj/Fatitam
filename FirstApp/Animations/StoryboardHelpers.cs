using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace FirstApp
{
    public static class StoryboardHelpers
    {
        public static void AddSlightFromRight(this Storyboard storyboard, float seconds, double offset, float declarationRatio = 0.9f)
        {
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),
                From = new System.Windows.Thickness(offset, 0, -offset, 0),
                To = new System.Windows.Thickness(0),
                DecelerationRatio = 0.9f
            };
            Storyboard.SetTargetProperty(slideAnimation, new System.Windows.PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }

        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),
                From = 0.5,
                To = 1
            };
            Storyboard.SetTargetProperty(animation, new System.Windows.PropertyPath("Opacity"));
            storyboard.Children.Add(animation);

        }

        public static void AddSlightToLeft(this Storyboard storyboard, float seconds, double offset, float declarationRatio = 0.9f)
        {
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),
                From = new System.Windows.Thickness(0),
                To = new System.Windows.Thickness(-offset, 0, offset, 0),
                DecelerationRatio = 0.9f
            };
            Storyboard.SetTargetProperty(slideAnimation, new System.Windows.PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }

        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            Storyboard.SetTargetProperty(animation, new System.Windows.PropertyPath("Opacity"));
            storyboard.Children.Add(animation);

        }

        public static void AddSlightFromLeft(this Storyboard storyboard, float seconds, double offset, float declarationRatio = 0.9f)
        {
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),
                From = new System.Windows.Thickness(-offset, 0, offset, 0),
                To = new System.Windows.Thickness(0),
                DecelerationRatio = 0.9f
            };
            Storyboard.SetTargetProperty(slideAnimation, new System.Windows.PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }
    }
}
