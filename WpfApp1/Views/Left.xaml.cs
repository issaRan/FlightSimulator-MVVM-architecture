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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;
using WpfApp1.Views.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Manual.xaml
    /// </summary>
    public partial class Left : UserControl
    {
        private LeftVM vm;
        public Left()
        {
            this.vm = new LeftVM();
            InitializeComponent();
            DataContext = this.vm;
        }
    }
}
