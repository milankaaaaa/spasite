﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace spasite.Components
//{
//    internal class Navigation
//    {
//        static class Navigation
//        {
//            private static List<PageComponent> components = new List<PageComponent>();
//            public static MainWindow mainWindow;
//            public static void ClearHistory()
//            {
//                components.Clear();
//            }
//            public static void NextPage(PageComponent pageComponent)
//            {
//                components.Add(pageComponent);
//                Update(pageComponent);

//            }
//            public static void BackPage()
//            {
//                if (components.Count > 1)
//                {
//                    components.RemoveAt(components.Count - 1);
//                    Update(components[components.Count - 1]);
//                }
//            }
//            private static void Update(PageComponent pageComponent)
//            {
//                mainWindow.TitleTb.Text = pageComponent.Title;
//                mainWindow.BackBtn.Visibility = components.Count() > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
//                mainWindow.MainFrame.Navigate(pageComponent.Page);
//            }



//        }
//    }
//}
