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
    /// Логика взаимодействия для Delete_User.xaml
    /// </summary>
    public partial class Delete_User : MetroWindow
    {
        public Delete_User()
        {
            InitializeComponent();
        }
        public delegate void question();
        public static event question onNewUser;
        private void Button_Click(object sender, RoutedEventArgs e)
        {         
            using (First_model db = new First_model())
            {
               
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {           
            Close();
        }    
    }
}
