using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

namespace SunnyLize.Word.Animation
{
    /// <summary>
    /// Help us to animate framework element in specific ways
    /// </summary>
    public static class FrameworkElementAnimations
    {
        #region SlideAnd Fade in and out from LEFT
       
        /// <summary>
        /// Slides an element in from the left
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        ///  <param name="width">The animation width  to animate to, if not specified the element width is use</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //created the storyboard
            var sb = new Storyboard();
         
            //Add slide from left animation
            sb.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            //add fade in animation
            sb.AddFadeIn(seconds);
            //start animating
            sb.Begin(element);

            if (seconds != 0) //make a page visible ony when we are animating
             //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }


        /// <summary>
        /// Slides an element out to left 
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        ///  <param name="width">The animation width  to animate to, if not specified the element width is use</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //created the storyboard
            var sb = new Storyboard();

            //Add slide from left animation
            sb.AddSlideToLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            //add fade in animation
            sb.AddFadeOut(seconds);


            //start animating
            sb.Begin(element);

            if (seconds != 0) //make a page visible ony when we are animating
              //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);

            //make element invisible
            element.Visibility = Visibility.Hidden;
        }

        #endregion


        #region SlideAnd Fade in and out from RIGHT

        /// <summary>
        /// Slides an element in from the right
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        /// <param name="width">The animation width  to animate to, if not specified the element width is use</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //created the storyboard
            var sb = new Storyboard();

            //add fade in animation
            sb.AddFadeIn(seconds);

            //Add slide from right animation
            sb.AddSlideFromRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            //start animating
            sb.Begin(element);

            if(seconds != 0) //Making zero invisbile from the start untill it needed
            //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides an element out to right
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        ///  <param name="width">The animation width  to animate to, if not specified the element width is use</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //created the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            //add fade in animation
            sb.AddFadeOut(seconds);


            //start animating
            sb.Begin(element);

            if (seconds != 0) //make a page visible ony when we are animating
            //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);


            //make element invisible
            element.Visibility = Visibility.Hidden;
        }

        #endregion


        #region Slide And Fade in and out from BOTTOM

        /// <summary>
        /// Slides an element in from the bottom
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same height during the animation</param>
        ///  <param name="height">The animation height  to animate to, if not specified the element height is use</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromBottom(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            //created the storyboard
            var sb = new Storyboard();

            //Add slide from bottom animation
            sb.AddSlideFromBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            //add fade in animation
            sb.AddFadeIn(seconds);
            //start animating
            sb.Begin(element);

            if (seconds != 0) //make a page visible ony when we are animating
            //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }


        /// <summary>
        /// Slides an element out to bottom 
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same height during the animation</param>
        ///  <param name="height">The animation width  to animate to, if not specified the element height is use</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToBottom(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            //created the storyboard
            var sb = new Storyboard();

            //Add slide to bottom animation
            sb.AddSlideToBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            //add fade in animation
            sb.AddFadeOut(seconds);


            //start animating
            sb.Begin(element);

            if(seconds != 0) //make a page visible ony when we are animating
            //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);


            //make element invisible
            element.Visibility = Visibility.Hidden;
        }

        #endregion


        #region Fade In / Out

        /// <summary>
        /// Fade an element in 
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <returns></returns>
        public static async Task FadeInAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //created the storyboard
            var sb = new Storyboard();

            //add fade in animation
            sb.AddFadeIn(seconds);
            //start animating
            sb.Begin(element);

            if (seconds != 0) //make a page visible ony when we are animating
             //make the pag visiable
             element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }


        /// <summary>
        /// Fade an element out
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <returns></returns>
        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //created the storyboard
            var sb = new Storyboard();

            //add fade in animation
            sb.AddFadeOut(seconds);
            //start animating
            sb.Begin(element);

            if (seconds != 0) //make a page visible ony when we are animating
             //make the pag visiable
             element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);

            //Once we are done we make our visibility hidden (fully hide the element)
            element.Visibility = Visibility.Collapsed;
        }


        #endregion
    }
}
