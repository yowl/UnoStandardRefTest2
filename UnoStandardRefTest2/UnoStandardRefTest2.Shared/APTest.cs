using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace UnoStandardRefTest2.Shared
{
    public class APTest 
    {
        public static readonly DependencyProperty KeyAwareProperty = DependencyProperty.RegisterAttached(
            "KeyAware", typeof(bool), typeof(APTest), new PropertyMetadata(false, KeyAwareChanged));

        static void KeyAwareChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
        {
            var box = dependencyobject as ComboBox;
            if ((bool) args.NewValue)
            {
                HookKeys(box);
            }
        }

        static void HookKeys(ComboBox box)
        {
            var keyDownHandler = new KeyEventHandler(ComboBoxKeyDown);
            box.AddHandler(UIElement.KeyDownEvent, keyDownHandler, false);
        }

        static void ComboBoxKeyDown(object sender, KeyRoutedEventArgs e)
        {
            var comboBox = (ComboBox) sender;
            if (e.Key == VirtualKey.Space)
            {
                comboBox.IsDropDownOpen = !comboBox.IsDropDownOpen;
            }
            if (e.Key == VirtualKey.Down)
            {
                if (comboBox.IsDropDownOpen)
                {
                    comboBox.SelectedIndex++;
                }
            }
            if (e.Key == VirtualKey.Up)
            {
                if (comboBox.IsDropDownOpen && comboBox.SelectedIndex > 0)
                {
                    comboBox.SelectedIndex--;
                }
            }
        }

        public static void SetKeyAware(DependencyObject element, bool value)
        {
            element.SetValue(KeyAwareProperty, value);
        }

        public static bool GetKeyAware(DependencyObject element)
        {
            return (bool) element.GetValue(KeyAwareProperty);
        }
    }
}
