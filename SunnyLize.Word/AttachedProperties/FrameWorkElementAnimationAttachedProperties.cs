

using Newtonsoft.Json.Linq;
using SunnyLize.Word.Animation;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace SunnyLize.Word
{
    /// <summary>
    /// the base class to run any animation method when the boolean is set to true and
    /// a reverse animation is set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> :BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region public property
        /// <summary>
        /// the flag indicating if it is the first the property that have  load
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        #endregion

       
        public override void OnvalueUpdated(DependencyObject sender, object value)
        {
            //try to find the framwork element
            if (!(sender is FrameworkElement element)) return;


            //don't fire if the vaue doesn't change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad) return; //if the value doesn't change, then do nothing except if it is the first time

            //On first load...
            if(FirstLoad)
            {
                //hooking it to first load on a single file - by creating single self-unhookable event
                //For the element loaded to the event
                //RoutedEventHandler onLoaded = (ss, ee) =>
                // {  
                //     element.Loaded -= onLoaded; //encounter error use of unassign local variable when we try this way
                // };


                //practical we create event allow it to run and load, hook to event and there after unhook itself
                RoutedEventHandler onLoaded = null;   //technically it been assign
                //created an event
                onLoaded = (ss, ee) =>
                {
                    //Unhooked ourselves
                    element.Loaded -= onLoaded;

                    //We doing the desired animation
                    DoAnimation(element, (bool)value);

                    //Once we done it no longer in first load

                    FirstLoad = false;
                };

                //Hook into the loaded event of the element
                element.Loaded += onLoaded;
            }
            else 
                DoAnimation(element, (bool)value);

        }

        /// <summary>
        /// the animation method that is fire when the value changes
        /// </summary>
        /// <param name="element">the element</param>
        /// <param name="value">the new value</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
            
        }
    }



    /// <summary>
    /// Animate a framework element sliding in from the left show 
    /// and slide out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //Animate in---///FirstLoad ? 0 : 0.3f if it firstload do nothing otherwise animate the same
                //FirstLoad ? 0.3f : 0.3f will allow our both pages to load at the same time
                await element.SlideAndFadeInFromLeft(FirstLoad ? 0 : 0.3f, keepMargin:false);
            else
                //otherwise animate out
                await element.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.3f, keepMargin:false);

        }
    }



    /// <summary>
    /// Animate a framework element sliding up from the bottom show 
    /// and slide out from the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //Animate in---///FirstLoad ? 0 : 0.3f if it firstload do nothing otherwise animate the same
                //FirstLoad ? 0.3f : 0.3f will allow our both pages to load at the same time
                await element.SlideAndFadeInFromBottom(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //otherwise animate out
                await element.SlideAndFadeOutToBottom(FirstLoad ? 0 : 0.3f, keepMargin: false);

        }
    }

}
