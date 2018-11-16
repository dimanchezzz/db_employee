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
using MahApps.Metro.Controls;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new first();
            register.onregClick += Au;
        }
        private void btn_click_auto(object sender, RoutedEventArgs e)
        {
            Main.Content = new auto(first_window);
        }
        public void Au()
        {
            Main.Content = new auto(first_window);
        }

        private void claick_register(object sender, RoutedEventArgs e)
        {
            Main.Content = new register();
        }
    }
}
