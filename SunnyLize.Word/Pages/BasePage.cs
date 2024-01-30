

using SunnyLize.Word.Animation;
using SunnyLize.Word.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SunnyLize.Word
{
    /// <summary>
    /// Base page for all pages to gain base functionality
    /// </summary>
    public class BasePage: UserControl
    {
        #region Public Properties
        /// <summary>
        /// The animation that play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation that play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// the time the animation take to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// Aflag to indicate  if this page should animate when is on load
        /// usefull for when we are moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public BasePage()
        {
            //IF at we don't want to bother or worrying animating during design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return; //this basically mean if we are in design time don't bother animating

            //if we are animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            //Listening out for the page loaded
            this.Loaded += BasePage_Loaded;
          
            
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
           
            //if we are setup to animate out on load
            if (ShouldAnimateOut)
                //animate ut
                await AniminateOut();
            //otherwise....
            else
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
            if (PageLoadAnimation == PageAnimation.None)
                return;
            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    
                    //start the animation
                   // await this.SlideAndFadeInFromRight(SlideSeconds, width: (int)Application.Current.MainWindow.Width); //we can decide to remove the *5 and it will slide in faster
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width);
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
            if (PageUnLoadAnimation == PageAnimation.None)
                return;
            switch (PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    //start the animation
                    //await this.SlideAndFadeOutToLeft(SlideSeconds /*width: (int)Application.Current.MainWindow.Width*/); //we can decide to remove the *5 and it will slide in faster
                    await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, /*false,*/ SlideSeconds);

                    break;
            }
        }
        #endregion




    }





    /// <summary>
    /// Base page for added viewmodel support
    /// </summary>
    public class BasePage<VM>: BasePage
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
        public BasePage() : base()
        {
           
            //create a default ViewModel
          this.ViewModel = new VM();
        }
        #endregion

       
    }
}
