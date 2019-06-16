using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoStandardRefTest2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            Items = Enumerable.Range(0, 5).Select(i => i.ToString()).ToList();
            //            Items = Enumerable.Range(0, 2000).Select(i => i.ToString()).ToList();
            this.InitializeComponent();
            DataContext = this;
#if __WASM__
//            var keyDownHandler = new KeyEventHandler(OnMenuBarItemKeyDown);
//            AddHandler(UIElement.KeyDownEvent, keyDownHandler, true);
//            comboBox.AddHandler(UIElement.KeyDownEvent, keyDownHandler, true);
            //            this.RegisterHtmlEventHandler("keydown", OnSimpleEvent);
#endif
        }

//        void OnMenuBarItemKeyDown(object sender, KeyRoutedEventArgs e)
//        {
//            if (e.Key == VirtualKey.Space)
//            {
//                comboBox.IsDropDownOpen = !comboBox.IsDropDownOpen;
//            }
//            if (e.Key == VirtualKey.Down)
//            {
//                if (comboBox.IsDropDownOpen)
//                {
//                    comboBox.SelectedIndex++;
//                }
//            }
//        }

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

        public List<string> Items { get; set; }
    }
}
