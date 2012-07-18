using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> names = new List<string>();
            names.Add("hermit");
            names.Add("help");
            names.Add("him");
            names.Add("hang");
            names.Add("his");
            names.Add("dirty");
            names.Add("laundry");
            names.Add("somewhere");

            this.actbNames.ItemsSource = names;
        }

        private async void btnPrompt_Click_1(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog(this.actbNames.Text, "test");
            await md.ShowAsync();
        }
    }
}
