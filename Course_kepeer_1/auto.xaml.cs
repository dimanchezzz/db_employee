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
using System.Security.Cryptography;
using System.Data.SqlClient;
namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для auto.xaml
    /// </summary>
    public partial class auto : Page, INotifyPropertyChanged
    {       
        Window a;
        public string departament;
        public auto(Window o)
        {
            InitializeComponent();
            a = o;
            DataContext = this;
        }
        private void click_reset(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "select dbo.auto_manager('" + auto_log.Text + "', '" + auto_pass.Password + "');";
            string take_id = " select dbo.Take_id_manager('" + auto_log.Text + "');";
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                Int32 number = Convert.ToInt32(command.ExecuteScalar());
                if (number == 0)
                {
                    MessageBox.Show("invalid Data");
                    auto_log.Clear();
                    auto_pass.Clear();
                }
                else if (number == 1)
                {
                    SqlCommand take_id_ = new SqlCommand(take_id, connection);
                    int id = Convert.ToInt32(take_id_.ExecuteScalar());
                    string login = auto_log.Text;
                    string take = "exec ManTake__info @id=" + id + ";";
                    SqlCommand commandd = new SqlCommand(take, connection);
                    SqlDataReader reader = commandd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                             departament = (reader.GetValue(1).ToString());
                           
                        }
                    }
                    reader.Close();
                    main_user_window man = new main_user_window(login, id,departament);
                    man.Show();
                    a.Close();
                   
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        private void Enter(object sender, KeyEventArgs e)
        {
           // if (e.Key == Key.Enter) ;
               
        }
        private void auto_log_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }

        }

        private void auto_pass_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
          

        }
    }
}
