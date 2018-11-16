using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для register.xaml
    /// </summary>
    /// 
    
    public partial class register : Page, INotifyPropertyChanged
    {
        public static string pattern = @"[^0-9a-zA-Z_-]+";
        public register()
        {
            InitializeComponent();
            DataContext = this;
            isEnable += Isena;
        }     
        private void Click_agreement(object sender, MouseButtonEventArgs e)
        {
            Agree ag = new Agree();
            ag.Show();
            
        }
        private void TextBlock_MouseMove(object sender, MouseEventArgs e)
        {
            agreement.FontSize = 15;
        }
        private void agreement_MouseLeave(object sender, MouseEventArgs e)
        {
            agreement.FontSize = 12;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public delegate void MethodContainer();
        public static event MethodContainer onregClick;
        private void registers_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(log) == true || Validation.GetHasError(pw1))
            {
                MessageBox.Show("Incorrectly filled data!");
                return;
            }

            else if (Regex.IsMatch(log.Text, pattern))
            {
                MessageBox.Show("Invalid login format");
                log.Clear();
                return;
            }
            
            object m = departament.SelectedIndex;

            string n = departament.Text;
            string sqlExpression = @"exec Bank_DB.dbo.Insert_manager 
                @name='" + log.Text + "',@city='" + city.Text + "',@number=" + phone.Text + ",@email='" + email.Text + @"',
                @password ='" + pw1.Password + "',@departament='" + n + "';";
            string isEmpty = "select Bank_DB.dbo.IsEmpty_depart('" + log.Text + "');";
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                SqlCommand command_is_empty = new SqlCommand(isEmpty, connection);
                int is_empty = Convert.ToInt32(command_is_empty.ExecuteScalar());
                if(is_empty==0)
                {
                    
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show("Complete");
                    onregClick();
                    
                }
                else if (is_empty==1)
                {
                    MessageBox.Show("This name is used by onather user");
                    log.Clear();
                }

            }
        }
        public delegate void MethodCHeck();
        public static event MethodCHeck isEnable;
        private void check_Checked(object sender, RoutedEventArgs e)
        {
            isEnable();
        }
        private void check_Unchecked(object sender, RoutedEventArgs e)
        {
            isEnable();
        }
        private void log_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }
        }
        private void pw1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }
        }
        private void purse_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
        public void Isena()
        {
            if (log.Text == "" || pw1.Text == "" || city.Text == "" || phone.Text == "" || email.Text == "" || check.IsChecked==false)

            {
                registers.IsEnabled = false;
            }
            else
            {
                registers.IsEnabled = true;
            }
        }

        private void pw1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            isEnable();
        }
    }
}
