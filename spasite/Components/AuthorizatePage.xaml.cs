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
    /// Логика взаимодействия для AuthorizatePage.xaml
    /// </summary>
    public partial class AuthorizatePage : Page
    {
        public AuthorizatePage()
        {
            InitializeComponent();
        }

     

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTb.Text == "0000")
            {
                NavigationService.Navigate(new GuestPage());
            }
            else if (PasswordTb.Text == "1111")
            {
                NavigationService.Navigate(new TeacherPage());
            }
            else if (PasswordTb.Text == "2222")
            {
                NavigationService.Navigate(new EngineerPage());
            }
        }
    }
}
