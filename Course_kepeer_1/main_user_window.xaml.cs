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
using System.Security.Cryptography;
using MahApps.Metro.Controls;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для main_user_window.xaml
    /// </summary>
    public partial class main_user_window : MetroWindow
    {
        public static int Id_manager;
        public static string departament;
        
        public main_user_window(string login,int id,string dep)
        {      
            InitializeComponent();
            //  User.Content = new Help();
            departament = dep;
            Id_manager = id;
            date.Content = login.ToString() ;
            Question.onNewUser += Closedf;
            Delete_User.onNewUser += Closedf;
            Services.delete += cl;
        }
        private void cl()
        {
            User.Content = new Services();
        }




        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            main_user.Close();

        }
      
        private void Mouse_move(object sender, MouseEventArgs e)
        {
            date.FontFamily = new FontFamily("Garamond");
        }

        private void leave(object sender, MouseEventArgs e)
        {
            date.FontFamily = new FontFamily("Italic");
        }

        private void clack(object sender, MouseButtonEventArgs e)
        {
            Question qu = new Question();
            qu.Show();      
        }
        
        private MetroWindow accentThemeTestWindow;       
        private void Stylce()
        {
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }
            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 2.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 2.0;
            accentThemeTestWindow.Show();
        }
        private void Closedf()
        {
            Close();
        }
       

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            try { User.Content = new Calc(); } catch (Exception m) { MessageBox.Show("No internet connection"); return; }
            
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            User.Content = new Credit_calc();
        }
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            User.Content = new Services();
        }

       

        

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            User.Content = new My_contract();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            User.Content = new History();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.Content = new Personal_Area();

        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }
            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 2.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 2.0;
            accentThemeTestWindow.Show();

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            User.Content = new Add_service();
        }
    }
}
