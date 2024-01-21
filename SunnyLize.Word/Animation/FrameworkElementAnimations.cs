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
        /// <summary>
        /// Slides an element in from the right
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //created the storyboard
            var sb = new Storyboard();

            //add fade in animation
            sb.AddFadeIn(seconds);

            //Add slide from right animation
            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            //start animating
            sb.Begin(element);

            //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }


        /// <summary>
        /// Slides an element in from the right
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //created the storyboard
            var sb = new Storyboard();
         
            //Add slide from right animation
            sb.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            //add fade in animation
            sb.AddFadeIn(seconds);
            //start animating
            sb.Begin(element);

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
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //created the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            //add fade in animation
            sb.AddFadeOut(seconds);


            //start animating
            sb.Begin(element);

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
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //created the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            //add fade in animation
            sb.AddFadeOut(seconds);


            //start animating
            sb.Begin(element);

            //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }
    }
}
