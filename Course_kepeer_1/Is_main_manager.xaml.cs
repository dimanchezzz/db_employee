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

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Is_main_manager.xaml
    /// </summary>
    public partial class Is_main_manager : Page
    {
        Window o;
        public Is_main_manager(Window s)
        {
            o = s;
            InitializeComponent();
            Ok.IsEnabled = false;
        }

        private void email_SelectionChanged(object sender, RoutedEventArgs e)
        {
            err.Text = "";
            if (email.Text != "")
                Ok.IsEnabled = true;
            else
                Ok.IsEnabled = false;
            

        }
        public delegate void MethodCHeck();
        public static event MethodCHeck closeee;

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (email.Password != "1244")
            {
                err.Text = "ERROR";
            }
            else
            {
                Main_manager_wndw m = new Main_manager_wndw();
                m.Show();
              //  closeee();
               
                
            }
               

        }
    }
}
