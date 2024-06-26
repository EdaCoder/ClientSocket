using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ClientSocket
{
    /// <summary>
    /// Add.xaml 的交互逻辑
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }

        private void DownEvent(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Handle(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void HandleEvent(object sender, RoutedEventArgs e)
        {
            var target = int.Parse((sender as Button).CommandParameter.ToString());
            if (target == 1) this.DialogResult = true;
            else this.DialogResult = false;
        }

        private void AutoChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InvetCtrl != null)
            {
                if (bool.Parse(((ComboBoxItem)AutoDevice.SelectedValue).Content.ToString()))
                    InvetCtrl.Visibility = Visibility.Visible;
                else
                    InvetCtrl.Visibility = Visibility.Collapsed;
            }
        }
    }
}
