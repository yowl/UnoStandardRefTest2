using System;
using System.Linq;
using System.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Uno.Extensions.Specialized;
using System.Timers;

namespace UnoStandardRefTest2.Shared
{
    public class APTest 
    {
        private static Timer aTimer = new Timer(2000);

        private static string prefixFilter = "";

        public static readonly DependencyProperty KeyAwareProperty = DependencyProperty.RegisterAttached(
            "KeyAware", typeof(bool), typeof(APTest), new PropertyMetadata(null, KeyAwareChanged));

        static APTest()
        {
            aTimer.Elapsed += ResetPrefix;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        static void ResetPrefix(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Prefix reset");
            prefixFilter = "";
        }

        static void KeyAwareChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
        {
            var box = dependencyobject as ComboBox;
            if ((bool)args.NewValue)
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
            var comboBox = (ComboBox)sender;
            var items = comboBox.ItemsSource as ICollection;
            if (e.Key == VirtualKey.Space)
            {
                comboBox.IsDropDownOpen = !comboBox.IsDropDownOpen;
            }
            else if (e.Key == VirtualKey.Up)
            {
                if (comboBox.IsDropDownOpen)
                {
                    var selectedIndex = (comboBox.SelectedIndex - 1) % items.Count;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = items.Count - 1;
                    }

                    comboBox.SelectedIndex = selectedIndex;
                }
            }
            else if (e.Key == VirtualKey.Down)
            {
                if (comboBox.IsDropDownOpen)
                {
                    var selectedIndex = (comboBox.SelectedIndex + 1) % items.Count;
                    if (selectedIndex >= items.Count)
                    {
                        selectedIndex = 0;
                    }

                    comboBox.SelectedIndex = selectedIndex;
                }
            }
            else if (e.Key == VirtualKey.Delete)
            {
                comboBox.SelectedIndex = -1;
                comboBox.SelectedItem = null;
                comboBox.IsDropDownOpen = false;
            }
            else
            {
                FilterSelection(comboBox, items, e.Key);
            }
        }

        static void FilterSelection(ComboBox comboBox, ICollection items, VirtualKey key)
        {
            aTimer.Stop();
            Console.WriteLine($"Filtering selection of {items.Count} items");
            var stringRepresentation = key.ToString();
            Console.WriteLine($"prefix: {prefixFilter}");
            prefixFilter = prefixFilter + stringRepresentation;
            Console.WriteLine($"New prefix: {prefixFilter}");
            Console.WriteLine($"string representation is {stringRepresentation}");
            var bestMatch = items.Where(item => ((string)item).StartsWith(prefixFilter, StringComparison.InvariantCultureIgnoreCase)).ElementAt(0);
            if (bestMatch != null)
            {
                Console.WriteLine("Filtering selection");
                var bestIndex = items.IndexOf(bestMatch);
                Console.WriteLine($"best index is {bestIndex}");
                comboBox.SelectedIndex = bestIndex;
                comboBox.IsDropDownOpen = true;
            }
            else
            {
                Console.WriteLine("There is no best match");
                comboBox.SelectedIndex = -1;
                comboBox.IsDropDownOpen = true;
            }

            aTimer.Start();
        }

        public static void SetKeyAware(DependencyObject element, bool value)
        {
            element.SetValue(KeyAwareProperty, value);
        }

        public static bool GetKeyAware(DependencyObject element)
        {
            return (bool)element.GetValue(KeyAwareProperty);
        }
    }
}
