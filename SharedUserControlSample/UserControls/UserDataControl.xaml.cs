using System.ComponentModel;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SharedUserControlSample.UserControls
{
    public sealed partial class UserDataControl : UserControl, INotifyPropertyChanged
    {
        public static UserDataControl Instance { get; set; }
        public UserDataControl()
        {
            this.InitializeComponent();
            Instance = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
