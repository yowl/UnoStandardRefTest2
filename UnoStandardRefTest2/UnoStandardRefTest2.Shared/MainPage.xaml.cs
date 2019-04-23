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
            Items = Enumerable.Range(0, 5).Select(i => i.ToString()).ToList();
            //            Items = Enumerable.Range(0, 2000).Select(i => i.ToString()).ToList();
            this.InitializeComponent();
            DataContext = this;
        }

        public List<string> Items { get; set; }

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
            "SelectedValue", typeof(object), typeof(MainPage), new PropertyMetadata(default(object)));

        public object SelectedValue
        {
            get { return (object)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        void BtnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SelectedIndex before reset " + cmb.SelectedIndex);
            SelectedValue = null;
            Debug.WriteLine("SelectedIndex after reset " + cmb.SelectedIndex);
        }
    }
}
