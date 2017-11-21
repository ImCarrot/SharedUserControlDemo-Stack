using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SharedUserControlSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
            Loaded += SecondPage_Loaded;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //remove the user control as a child as leaving it as a child will throw you an
            //error "No installed components were detected.  Element is already the child of another element."
            if (rootLayout.Children.Contains(UserControls.UserDataControl.Instance))
                rootLayout.Children.Remove(UserControls.UserDataControl.Instance);
            base.OnNavigatingFrom(e);
        }

        private void SecondPage_Loaded(object sender, RoutedEventArgs e)
        {
            rootLayout.Children.Add(UserControls.UserDataControl.Instance);
        }

        private void GoToMainPage(object sender, RoutedEventArgs e)
        {
            //Delibertate Frame.Navigate to check if the fresh navigation still holds the data
            Frame.Navigate(typeof(MainPage));
        }
    }
}
