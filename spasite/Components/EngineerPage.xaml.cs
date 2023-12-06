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

namespace spasite.Components
{
    /// <summary>
    /// Логика взаимодействия для EngineerPage.xaml
    /// </summary>
    public partial class EngineerPage : Page
    {
        public EngineerPage()
        {
            InitializeComponent();
            EmployeesDataGrid.ItemsSource = App.db.Employee.ToList();
            EmployeesDataGrid.DataContext = App.db.Employee.ToList();
            var PositionEmployee = App.db.Employee.Where(x => x.Position != "зав.кафедрой").ToList();
            var chiefEmployee = App.db.Employee.Where(e => e.Position == "зав.кафедрой").ToList();
            App.CountOfEmployeers = App.db.Employee.Count();
        }

        StringBuilder Validator()
        {
            StringBuilder stringBuilder = new StringBuilder();
            return stringBuilder;
        }
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage(new Employee()));
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        void Refresh()
        {
            EmployeesDataGrid.ItemsSource = null;
            IEnumerable<Employee> empList = App.db.Employee.ToList();
            if (NameOfDisciplineSearchTb.Text.Length > 0)
            {
                empList = empList.Where(x => x.LastName.ToString().ToLower().Contains(NameOfDisciplineSearchTb.Text.ToLower()));
            }
            EmployeesDataGrid.ItemsSource = empList;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage(EmployeesDataGrid.SelectedItem as Employee));
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee employee)
            {
                foreach (var em in App.db.Teacher.ToList())
                {
                    if (em.Employee == EmployeesDataGrid.SelectedItem as Employee)
                    {
                        App.db.Teacher.Remove(App.db.Teacher.Find(em.id));
                        App.db.SaveChanges();
                    }
                }
                foreach (var em in App.db.Engineer.ToList())
                {
                    if (em.Employee == EmployeesDataGrid.SelectedItem as Employee)
                    {
                        App.db.Engineer.Remove(App.db.Engineer.Find(em.id));
                        App.db.SaveChanges();
                    }

                }
                
                App.db.Employee.Remove(App.db.Employee.Find(employee.id));
                App.db.SaveChanges();

            }
            MessageBox.Show("Удалено");
            Refresh();
        }
        private void NameOfDisciplineSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizatePage());
        }
    }
}
 