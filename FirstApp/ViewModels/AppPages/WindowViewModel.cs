using System.Windows;
using System.Windows.Input;

namespace FirstApp
{
    public class WindowViewModel : BaseViewModel
    {
        private Window mWindow;

        //The size of the resize border around the window
        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }


        //Size for the drop shadow
        private int mOuterMarginSize = 10;

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        public int OuterMarginSize {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; }
            set { mOuterMarginSize = value; }
        }


        //The radius of the corners
        private int mWindowRadius = 10;

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; }
            set { mWindowRadius = value; }
        }


        //Height  of the task bar
        public int CaptionHeight { get; set; } = 42;

        public GridLength CaptionHeightGridLenght { get { return new GridLength(CaptionHeight); } }

        //Commands
        public ICommand MinimalizeCommand { get; set; }
        public ICommand MaximalizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        public WindowViewModel(Window window)
        {
            this.mWindow = window;

            //Check the syntax, analize the way it works
            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimalizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximalizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, WindowTools.GetMousePosition(mWindow)));

        }
    }
}

