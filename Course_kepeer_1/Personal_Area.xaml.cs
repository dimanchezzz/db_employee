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
using System.Data.SqlClient;


namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Personal_Area.xaml
    /// </summary>
    public partial class Personal_Area : Page
    {
        

        public void Take_info()
        {
            string take = "exec ManTake__info @id=" + main_user_window.Id_manager + ";";
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(take, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                      
                        city.Text = reader.GetValue(3).ToString();
                        phone_number.Text = reader.GetValue(4).ToString();
                        email.Text = reader.GetValue(5).ToString();
                        password.Text = reader.GetValue(6).ToString();
                       
                    }
                }
                reader.Close();
            }
        }
        public Personal_Area()
        {
            InitializeComponent();
            Take_info();
        }

        private void agree_Click(object sender, RoutedEventArgs e)
        {
            info_panel.IsEnabled = true;

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string Update_manager = @"exec Update_manager  @city = '" + city.Text + "' , @number = " + phone_number.Text + " , @email = '" + email.Text + "' , @password = '" + password.Text + "' , @id = " + main_user_window.Id_manager + ";";
            using(SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Update_manager, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Update Manager info", "Info");
            }


            info_panel.IsEnabled = false;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
