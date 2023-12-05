using spasite.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Application = System.Windows.Application;

namespace spasite
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Lab_22Entities db = new Lab_22Entities();

        public static int COuntOfExams { get; internal set; }
        public static int CountOfEmployeers { get; internal set; }
    }
}
