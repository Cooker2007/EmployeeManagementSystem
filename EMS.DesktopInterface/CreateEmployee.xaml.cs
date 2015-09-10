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
using EMS.Services.ViewModels;

namespace EMS.DesktopInterface
{
    /// <summary>
    /// Interaction logic for CreateEmployee.xaml
    /// </summary>
    public partial class CreateEmployee : Window
    {
        private readonly Processing processing;

        public CreateEmployee()
        {
            this.InitializeComponent();
        }

        public CreateEmployee(Processing processing)
        {
            this.InitializeComponent();
            this.processing = processing;
        }

        private void Gender_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>() { "Male", "Female", "Other" };

            var comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                comboBox.ItemsSource = data;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool result = this.processing.SendCreateEmployeeRequest(this.PopulateProperties());
            if (result)
            {
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private InsertEmployeeProperties PopulateProperties()
        {
            InsertEmployeeProperties viewModel = new InsertEmployeeProperties
            {
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text,
                Gender = this.GenderSelection.Text,
                BirthDate = this.DateOfBirth.Text,
                HireDate = this.HireDate.Text,
            };
            return viewModel;

        }




    }
}
