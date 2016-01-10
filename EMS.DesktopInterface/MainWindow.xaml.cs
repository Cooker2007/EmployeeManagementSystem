using EMS.Services.Interfaces;
using EMS.Services.Messaging.Department;
using EMS.Services.Messaging.Employee;
using EMS.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace EMS.DesktopInterface
{
    using EMS.Services;

    /// <summary>
    /// Interaction logic for MainWindow.xaml management
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Processing processing;

        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;

        private EmployeeViewModel CurrentEmployeeData { get; set; }



        public MainWindow(IEmployeeService employeeService, IDepartmentService departmentService, Processing processing)
        {
            this.InitializeComponent();

            this.employeeService = employeeService;
            this.departmentService = departmentService;
            this.processing = processing;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.ResetErrorMessage();
            this.HistoryData.ItemsSource = null;

            int searchNumber;
            int.TryParse(this.SearchInput.Text, out searchNumber);
            this.SearchForEmployee(searchNumber);
        }

        private void SearchForEmployee(int searchNumber)
        {
            var request = new GetEmployeeRequest(searchNumber);
            var response = this.employeeService.GetEmployee(request);

            if (response.Exception != null)
            {
                this.DisplayErrorMessage("Employee could not be found.");
            }
            else
            {
                this.CurrentEmployeeData = response.Employee;
                this.DisplayEmployeeData(response);
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            this.SaveEmployeeChanges();
        }

        private void SaveEmployeeChanges()
        {
            int employeeId;

            if (int.TryParse(this.EmployeeNumber.Content.ToString(), out employeeId))
            {
                var request = new UpdateEmployeeRequest(employeeId);
                var viewModel = this.CreateEmployeePropertiesViewModel();
                request.EmployeePorperties = viewModel;
                this.employeeService.UpdateEmployee(request);
            }
        }

        private EmployeePorperties CreateEmployeePropertiesViewModel()
        {
            var viewModel = new EmployeePorperties
            {
                BirthDate = this.DateOfBirth.SelectedDate.ToString(),
                Gender = this.GenderSelection.Text,
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text
            };

            return viewModel;
        }

        private void SalaryHistory_Click(object sender, RoutedEventArgs e)
        {
            int employeeId;
            if (int.TryParse(this.EmployeeNumber.Content.ToString(), out employeeId))
            {
                this.HistoryData.ItemsSource = this.processing.GetEmployeeSalaryHistory(employeeId);
            }
        }

       private void DepartmentHistory_Click(object sender, RoutedEventArgs e)
       {

           int employeeId;
           if (int.TryParse(this.EmployeeNumber.Content.ToString(), out employeeId))
           {
               this.HistoryData.ItemsSource = this.processing.GetEmployeeDepartmentHistory(employeeId);
           }
       }

       private void TitleHistory_Click(object sender, RoutedEventArgs e)
       {
           int employeeId;
           if (int.TryParse(this.EmployeeNumber.Content.ToString(), out employeeId))
           {
               this.HistoryData.ItemsSource = this.processing.GetEmployeeTitleHistory(employeeId);
           }
       }

        private void Gender_Loaded(object sender, RoutedEventArgs e)
        {
            var data = new List<string> { "Male", "Female", "Other" };

            var comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                comboBox.ItemsSource = data;
            }
        }

        private void DisplayEmployeeData(GetEmployeeResponse response)
        {
            this.EmployeeNumber.Content = response.Employee.Id;
            this.FirstName.Text = response.Employee.FirstName;
            this.LastName.Text = response.Employee.LastName;
            this.DateOfBirth.SelectedDate = this.ConvertToDateTime(response.Employee.BirthDate);
            this.HiredDate.Content = this.ConvertToDateTime(response.Employee.HireDate);
            this.CurrentDepartment.Text = response.Employee.CurrentDepartment;
            this.CurrentSalary.Text = response.Employee.CurrentSalary;
            this.CurrentTitle.Text = response.Employee.CurrentTitle;

            this.DisplayGender(response.Employee.Gender);
        }

        private void DisplayGender(string gender)
        {
            if (gender.Equals("Male"))
            {
                this.GenderSelection.SelectedIndex = 0;
            }
            else if (gender.Equals("Female"))
            {
                this.GenderSelection.SelectedIndex = 1;
            }
            else if (gender.Equals("Other"))
            {
                this.GenderSelection.SelectedIndex = 2;
            }
        }

        private DateTime ConvertToDateTime(string input)
        {
            DateTime dt;
            DateTime.TryParse(input, out dt);
            return dt;
        }

        private void SearchInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }

        private void DisplayErrorMessage(string errorMessage)
        {
            this.LblEmpNoBetween.Visibility = Visibility.Hidden;
            this.LblError.Visibility = Visibility.Visible;
            this.ErrorMessage.Visibility = Visibility.Visible;
            this.ErrorMessage.Content = errorMessage;
        }

        private void ResetErrorMessage()
        {
            this.LblError.Visibility = Visibility.Hidden;
            this.ErrorMessage.Visibility = Visibility.Hidden;
            this.ErrorMessage.Content = string.Empty;
            this.LblEmpNoBetween.Visibility = Visibility.Visible;
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChangeTitle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChaneDepatment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChangeSalary_Click(object sender, RoutedEventArgs e)
        {
            if(this.CurrentEmployeeData != null)
            {
                var changeSalaryWindow = new ChangeSalary(this.processing, CurrentEmployeeData);
                changeSalaryWindow.Show();
            }

        }

        private void btnCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            var createEmployeeWindow = new CreateEmployee(this.processing);

            createEmployeeWindow.Show();
        }
    }
}