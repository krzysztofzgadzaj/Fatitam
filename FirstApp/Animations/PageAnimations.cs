using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FirstApp
{
    public static class PageAnimations
    {
        public static async Task SlideAndFadeInFromRight(this Page page,  float durationTime)
        {
            var sb = new Storyboard();
            sb.AddSlightFromRight(durationTime, page.WindowWidth);
            sb.AddFadeIn(durationTime);
            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)durationTime * 1000);
        }

        public static async Task SlideAndFadeOutToLeft(this Page page, float durationTime)
        {
            var sb = new Storyboard();
            sb.AddSlightToLeft(durationTime, page.WindowWidth);
            sb.AddFadeOut(durationTime);
            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)durationTime * 1000);
        }

        public static async Task FadeIn(this Page page, float durationTime)
        {
            var sb = new Storyboard();
            sb.AddFadeIn(durationTime);
            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)durationTime * 1000);
        }

        public static async Task SlideAndFadeInFromLeft(this Page page, float durationTime)
        {
            var sb = new Storyboard();
            sb.AddSlightFromLeft(durationTime, page.WindowWidth);
            sb.AddFadeIn(durationTime);
            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)durationTime * 1000);
        }
    }
}
