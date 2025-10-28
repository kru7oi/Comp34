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
using Элементы_компоновки.Models;

namespace Элементы_компоновки.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        // Промежуточный список отделов
        List<Department> departments = App.context.Departments.ToList();
        public EmployeesPage()
        {
            // Отрисовывает элементы интерфейса и придаёт им функциональность
            InitializeComponent();

            // Добавляем "отдел" в промежуточный список
            departments.Insert(0, new() { Name = "Все отделы"});
            FilterCmb.ItemsSource = departments;

            EmployeesLv.ItemsSource = App.context.Employees.ToList();
            // ItemsSource - свойство, которое представляет собой источник данных для элемента
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTb.Text))
            {
                EmployeesLv.ItemsSource = App.context.Employees.ToList();
            }
            else
            {
                EmployeesLv.ItemsSource = App.context.Employees.Where(employee => employee.Fullname.Contains(SearchTb.Text)).ToList();
            }
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 1. Получить выбранный отдел из выпадающего списка
            // 2. Получить полный список сотрудников
            // 3. Произвести в нём фильтрацию по названию отдела
            // 4. Полученный список передать в качестве источника элементов в ListView
            Department? selectedDepartment = FilterCmb.SelectedItem as Department;

            if (selectedDepartment.Name == "Все отделы")
            {
                EmployeesLv.ItemsSource = App.context.Employees.ToList();
            }
            else
            {
                EmployeesLv.ItemsSource = App.context.Employees.Where(employee => employee.DepartmentId == selectedDepartment.Id).ToList();
            }
        }
    }
}
