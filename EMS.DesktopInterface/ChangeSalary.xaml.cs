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
    /// Interaction logic for ChangeSalary.xaml
    /// </summary>
    public partial class ChangeSalary : Window
    {
        private readonly Processing processor;
        private readonly EmployeeViewModel employeeData;

        public ChangeSalary()
        {
            this.InitializeComponent();
        }
        
        public ChangeSalary(Processing processing, EmployeeViewModel currentEmployeeData)
        {

            this.InitializeComponent();
            this.processor = processing;
            this.employeeData = currentEmployeeData;

        }

        private void SalaryStartsOn_Loaded(object sender, RoutedEventArgs e)
        {
            this.SalaryStartsOn.Text = DateTime.Today.ToShortDateString();
            this.EmployeeId.Content = this.employeeData.Id;
            this.CurrentSalaryAmount.Content = this.employeeData.CurrentSalary;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            var result = this.processor.SendChangeEmployeeSalaryRequest(this.PopulateProperties());
            if (result)
            {
                this.Close();
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private SalaryProperties PopulateProperties()
        {
            var properties = new SalaryProperties
            {
                EmployeeId = this.employeeData.Id,
                Amount = this.NewSalaryAmount.Text,
                FromDate = this.SalaryStartsOn.Text
            };
            return properties;
        }

    }
}
