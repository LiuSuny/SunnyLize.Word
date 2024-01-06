

using System.Windows;
using System;
using System.Windows.Media.Animation;

namespace SunnyLize.Word
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StoryBoardHelpers
    {
        /// <summary>
        /// Add a slide from right animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add from right animation to</param>
        /// <param name="seconds">the time the animatio will take</param>
        /// <param name="offset"> the distance to the right to start from</param>
        /// <param name="decelerationRatio">the rate of acceleration</param>
        public static void AddSlideFromRight(this Storyboard storyboard, 
            float seconds, double offset,  float decelerationRatio = 0.9f)
        {
            //created margin animation from right
            var Animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            //setting the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));
            //add this to the storyboard
            storyboard.Children.Add(Animation);
        }



        /// <summary>
        /// Add a slide from left animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add left animation to</param>
        /// <param name="seconds">the time the animatio will take</param>
        /// <param name="offset"> the distance to the right to start from</param>
        /// <param name="decelerationRatio">the rate of acceleration</param>
        public static void AddSlideToLeft(this Storyboard storyboard,
            float seconds, double offset, float decelerationRatio = 0.9f)
        {
            //created margin animation from right
            var Animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };
            //setting the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));
            //add this to the storyboard
            storyboard.Children.Add(Animation);
        }


        /// <summary>
        /// Add a slide fade in animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add fade in animation to</param>
        /// <param name="seconds">the time the animatio will take</param>

        public static void AddFadeIn(this Storyboard storyboard,  float seconds)          
        {
            //created margin animation from right
            var Animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
               
            };

            //setting the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));
            //add this to the storyboard
            storyboard.Children.Add(Animation);
        }



        /// <summary>
        /// Add a slide fade out animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add fade out animation to</param>
        /// <param name="seconds">the time the animatio will take</param>

        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            //created margin animation from right
            var Animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0

            };

            //setting the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));
            //add this to the storyboard
            storyboard.Children.Add(Animation);
        }
    }
}
