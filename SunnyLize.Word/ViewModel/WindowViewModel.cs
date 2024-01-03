
using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Input;

namespace SunnyLize.Word
{
    /// <summary>
    /// View model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Valuable_store

        private Window mWindow;
        /// <summary>
        /// The margine around the window to allow for a drop shadow
        /// </summary>
        private int  mOuterMargineSize = 10;

        /// <summary>
        /// The radius of the edges f window
        /// </summary>
        private int mWindowRadius = 10;
        #endregion

        #region public properties
        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resize border around the window taking into account the outermargin
        /// </summary>
        public Thickness ResizeBorderThickness { get{ return new Thickness(ResizeBorder + OuterMargineSize); } }

        /// <summary>
        /// The padding of the Inner content of main window
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }


        /// <summary>
        /// The margine around the window to allow for a drop shadow
        /// </summary>
        public int OuterMargineSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMargineSize;
            }
            set
            {
                mOuterMargineSize = value;
            }
        }

        /// <summary>
        /// The margine around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMargineSizeThickness { get { return new Thickness(OuterMargineSize); } }
           
        /// <summary>
        /// The radius of the edges f window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edges f window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar/caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }
        #endregion pr

        /// <summary>
        /// The smallest width the window can go to when minimizing our window
        /// </summary>
        public double WindowMinimiumWidth { get; set; } = 400;

        /// <summary>
        /// The smallest height the window can go to when minimizing our window
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        #region Commands
        
        /// <summary>
        /// the command to minimized our window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// the command to maximized our window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// the command to close our window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// the command for window ssystem menu
        /// </summary>
        public ICommand MenuCommand { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //Listen out for the window resizing when the state changes
            mWindow.StateChanged += (sender, e) =>
            {
                //we implement all our event everytime there is change in our activity
                //fire of event for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMargineSize));
                OnPropertyChanged(nameof(OuterMargineSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius)); 
                //OnPropertyChanged(nameof(TitleHeightGridLength)); 
            };

            //Creating a command
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized); //minimize window
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized); //maximize window using Dock
            CloseCommand = new RelayCommand(() => mWindow.Close()); //close command window 
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition())); //menu command window 

            //Fix window resize issue
            var resizer = new WindowResizer(mWindow);
        }

        #endregion

        #region Private Helper

       
        /// <summary>
        /// Get the current mouse position on the creen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            //The position of the mouse relative  to the window
            var position = Mouse.GetPosition(mWindow);

            //Add the window psition
            return new Point(position.X + mWindow.Left, position.Y +mWindow.Top);
        }
        #endregion
    }
}
