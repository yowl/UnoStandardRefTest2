using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
#if __WASM__
using Uno.Extensions;
#endif

namespace UnoStandardRefTest2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private ComboBox comboBox;

        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
            //Items = Enumerable.Range(0, 5).Select(i => i.ToString()).ToList();
            Items = new List<string>
            {
                "abcstring1",
                "xyzstring2",
                "pstring3",
                "jstring4",
                "string5",
            };
#if __WASM__
            comboBox = comboBoxWasm;
            //var keyDownHandler = new KeyEventHandler(OnMenuBarItemKeyDown);
            //AddHandler(UIElement.KeyDownEvent, keyDownHandler, true);
            //comboBox.AddHandler(UIElement.KeyDownEvent, keyDownHandler, true);
            //this.RegisterHtmlEventHandler("keydown", OnSimpleEvent);
#else
            comboBox = comboBoxWin;
#endif
        }

        void OnMenuBarItemKeyDown(object sender, KeyRoutedEventArgs e)
        {
            //Console.WriteLine($"Key {e.Key} was pressed");
            //if (e.Key == VirtualKey.Space)
            //{
            //    Console.WriteLine("ComboBox should open");
            //    comboBox.IsDropDownOpen = !comboBox.IsDropDownOpen;
            //}

            //if (e.Key == VirtualKey.Up)
            //{
            //    if (comboBox.IsDropDownOpen)
            //    {
            //        var selectedIndex = (comboBox.SelectedIndex - 1) % Items.Count;
            //        if (selectedIndex < 0)
            //        {
            //            selectedIndex = Items.Count - 1;
            //        }

            //        comboBox.SelectedIndex = selectedIndex;
            //    }
            //}
            //if (e.Key == VirtualKey.Down)
            //{
            //    if (comboBox.IsDropDownOpen)
            //    {
            //        var selectedIndex = (comboBox.SelectedIndex + 1) % Items.Count;
            //        if (selectedIndex >= Items.Count)
            //        {
            //            selectedIndex = 0;
            //        }

            //        comboBox.SelectedIndex = selectedIndex;
            //    }
            //}
            //if (e.Key == VirtualKey.Delete || e.Key == VirtualKey.Back)
            //{
            //    comboBox.SelectedItem = null;
            //    comboBox.IsDropDownOpen = false;
            //}
        }

#if __WASM__
        private void OnSimpleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("keydown2");
            if (e == null)
            {
                Console.WriteLine("e is null " );
            }
            else Console.WriteLine("e is " + e.GetType());
        }
#endif
        private List<string> _items;
        public List<string> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
