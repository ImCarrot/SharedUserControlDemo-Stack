using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SharedUserControlSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += (s, e) =>
            {
                if (UserControls.UserDataControl.Instance == null)
                    UserControls.UserDataControl.Instance = new UserControls.UserDataControl();

                rootLayout.Children.Add(UserControls.UserDataControl.Instance);
            };
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //remove the user control as a child as leaving it as a child will throw you an
            //error "No installed components were detected.  Element is already the child of another element."
            if (rootLayout.Children.Contains(UserControls.UserDataControl.Instance))
                rootLayout.Children.Remove(UserControls.UserDataControl.Instance);
            base.OnNavigatingFrom(e);
        }

        private void GoToSecondPage(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SecondPage));
        }
    }
}
