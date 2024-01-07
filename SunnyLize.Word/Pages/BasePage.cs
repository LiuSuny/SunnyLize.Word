

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SunnyLize.Word
{
   
    /// <summary>
    /// Base page for all pages to gain base functionality
    /// </summary>
    public class BasePage<VM>: Page
        where VM : BaseViewModel, new()
    {
        #region Private memeber
        /// <summary>
        /// View models associated with this page
        /// </summary>
        private VM mViewModel { get; set; }

        #endregion

        #region Public Properties
        /// <summary>
        /// The animation that play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation that play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInOutToLeft;

        /// <summary>
        /// the time the animation take to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// View models associated with this page
        /// </summary>
        public VM ViewModel 
        { get { return mViewModel; }
            set
            {
                //if nothing change, return nothing
                if (mViewModel == value)
                    return;
                //otherwise update the value
                mViewModel = value;

                //set our datacontext to viewmodel on this page
                this.DataContext = mViewModel;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public BasePage()
        {
            //if we are animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            //Listening out for the page loaded
            this.Loaded += BasePage_Loaded;

            //create a default ViewModel
          this.ViewModel = new VM();
        }
        #endregion

        #region Animation Load/Unload

        /// <summary>
        /// Once the page is loaded it required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            //Animate in this page 
            await AnimateIn();
        }
       
        /// <summary>
        /// AnimateIn in this page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            //Trying to make sure we have something to do
            if (this.PageLoadAnimation == PageAnimation.None)
                return;
            switch(this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    /* Note: we move the following code to seperate classes 
                    //var sb = new Storyboard();
                    //var slideAnimation = new ThicknessAnimation
                    //{
                    //    Duration = new Duration(TimeSpan.FromSeconds(this.SlideSeconds)),
                    //    From = new Thickness(this.WindowWidth, 0, -this.WindowWidth, 0),
                    //    To = new Thickness(0),
                    //    DecelerationRatio = 0.9f
                    //};
                    //Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                    //sb.Children.Add(slideAnimation);
                    //sb.Begin(this);

                    //this.Visibility = Visibility.Visible;
                    //await Task.Delay((int)(this.SlideSeconds * 1000));
                    */

                    //start the animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds); //we can decide to remove the *5 and it will slide in faster
                    break;
            }
        }

        /// <summary>
        /// Animate the page out
        /// </summary>
        /// <returns></returns>
        public async Task AniminateOut()
        {
            //Trying to make sure we have something to do
            if (this.PageUnLoadAnimation == PageAnimation.None)
                return;
            switch (this.PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInOutToLeft:

                    //start the animation
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds); //we can decide to remove the *5 and it will slide in faster
                    break;
            }
        }
        #endregion
    }
}
