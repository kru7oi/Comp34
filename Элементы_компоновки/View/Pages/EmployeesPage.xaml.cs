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

namespace Элементы_компоновки.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();

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
    }
}
