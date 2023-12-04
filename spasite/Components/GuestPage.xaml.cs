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
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        public GuestPage()
        {
            InitializeComponent();
            DisciplineDataGrid.ItemsSource = App.db.Discipline.ToList();
            DisciplineDataGrid.DataContext = App.db.Discipline.ToList();
        }

        private void DisciplineDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }
    }
}
