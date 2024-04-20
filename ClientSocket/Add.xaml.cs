using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            else  this.DialogResult = false;
        }
    }
}
