using System;
using System.Windows;
using System.Windows.Controls;

namespace SunnyLize.Word
{
    /// <summary>
    /// Focus (keyboard focus) this element is onload 
    /// </summary>
    public class IsFocusProperty : BaseAttachedProperty<IsFocusProperty, bool>
    {
        /// <summary>
        /// This class basically allow keyboard focus on whatever object we attach it in our project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //if we don't have a control return nothing
            if (!(sender is Control control))
                return;

            //if we do have a control then we focus this control once it is loaded ---Focus() set keyboard focus on visual
            control.Loaded += (s, se) => control.Focus();
        }

       
    }
}
