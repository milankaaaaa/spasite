using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
             if (PasswordTb.Text == "1111")
            {
                NavigationService.Navigate(new TeacherPage());
            }
            else if (PasswordTb.Text == "2222")
            {
                NavigationService.Navigate(new EngineerPage());
            }
            else if (PasswordTb.Text =="3333")
            {
                NavigationService.Navigate(new HeadOfTheDepartmentPage());
            }
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GuestPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Кнопка создания QR кода
        {
            // Ссылка на XL таблицу
            string soucer_xl = "https://sun9-33.userapi.com/impg/cz3daX-emq569M98GO2lcuyZHSJC1PHhiuwNJw/Z_UkLjbqEUk.jpg?size=736x734&quality=95&sign=025cc195c04ff974f288706210452692&c_uniq_tag=X6kgob0wFHl8KGS8LfM9aBU5ezW4pdeLpjk0yyWifLM&type=album"; 
            // Создание переменной библиотеки QRCoder
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            // Присваеваем значиения
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);
            // переводим в Qr
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            /// Создание картинки
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();


                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                imageQr.Source = bitmapimage;
            }
        }



    }
}
