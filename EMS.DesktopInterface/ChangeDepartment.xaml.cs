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

namespace EMS.DesktopInterface
{
    /// <summary>
    /// Interaction logic for Change_Department.xaml
    /// </summary>
    public partial class ChangeDepartment : Window
    {
        public ChangeDepartment()
        {
            InitializeComponent();
        }

        private void NewDepartmentStartsOn_Loaded(object sender, RoutedEventArgs e)
        {
            this.NewDepartmentStartsOn.DisplayDate = DateTime.Today;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewDepartment_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
