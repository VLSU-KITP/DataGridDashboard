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

namespace DataGridDashboard
{
    /// <summary>
    /// Interaction logic for WindowDialog.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public CustomMessageBox(string message, bool choise = false)
        {
            InitializeComponent();
            Message = message;
            DataContext = this;
            if (Owner != null)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            if (choise)
            {
                buttonCancel.Visibility = Visibility.Visible;
                buttonCancel.Content = "No";
                buttonOK.Content = "Yes";
            }
        }

        public string Message { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
