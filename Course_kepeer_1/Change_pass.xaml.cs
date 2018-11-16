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
using MahApps.Metro.Controls;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Change_pass.xaml
    /// </summary>
    public partial class Change_pass : MetroWindow
    {
        public Change_pass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cler();
            Close();

        }
        public delegate void question();
        public static event question onNewUser;
        public static event question cler;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            onNewUser();
        }
    }
}
