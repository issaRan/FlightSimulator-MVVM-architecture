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
using WpfApp1.ViewModel;

namespace WpfApp1.Views.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private SettingsVM vm;
        public Settings()
        {
            this.vm = new SettingsVM();
            DataContext = this.vm;
            InitializeComponent();
        } 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
