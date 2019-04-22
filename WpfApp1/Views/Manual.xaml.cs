using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.ViewModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Manual.xaml
    /// </summary>
    /// 
    public partial class Manual : UserControl
    {
        public Manual()
        {
            this.DataContext = new ManualVM();
            InitializeComponent();
        }

    }
}
