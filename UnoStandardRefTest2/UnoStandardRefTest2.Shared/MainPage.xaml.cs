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
            var s = new Stopwatch();
            Items = Enumerable.Range(0, 5).Select(i => i.ToString()).ToList();
            //            Items = Enumerable.Range(0, 2000).Select(i => i.ToString()).ToList();
            this.InitializeComponent();
            s.Start();
            DataContext = this;
//            textBlock.Text = s.Elapsed.ToString("G");

            cmb.KeyDown += DeletableComboBoxKeyDown;
        }

        void DeletableComboBoxKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Delete || e.Key == VirtualKey.Back)
            {
                SelectedItem = null;
            }
        }
        public List<string> Items { get; set; }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(MainPage), new PropertyMetadata(default(object)));

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
    }
}
