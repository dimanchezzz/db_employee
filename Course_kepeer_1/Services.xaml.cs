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
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : Page
    {
       
        public Services()
        {
            InitializeComponent();
            RefreshList();
            drop.IsEnabled = false;
        }
        string Name;
        private void RefreshList()
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string take = "exec take_name_serv @dep='"+main_user_window.departament+"'";
                SqlCommand commandd = new SqlCommand(take, connection);
                SqlDataReader reader = commandd.ExecuteReader();
              
                List<string> list = new List<string>();
               
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetValue(0).ToString());                                           
                    }
                }
                reader.Close();
                services.ItemsSource = list;            
            }
        }
        private void services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            drop.IsEnabled = true;
            string select = services.SelectedItem.ToString();
            Name = select;
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string take = " exec Take_service_info @name='"+select+"';";
                SqlCommand commandd = new SqlCommand(take, connection);
                SqlDataReader reader = commandd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        term.Text = "Term: "+reader.GetValue(2);
                        percent.Text = "Percent: " + reader.GetValue(3) + " %";
                        restrict.Text = "Restriction: " + reader.GetValue(6);
                        date_create.Text = "Date create: " + reader.GetValue(7);
                        comment.Text = "Comment: " + reader.GetValue(8);
                    }
                }
                reader.Close();
            }
        }
        public delegate void MethodContainer();
        public static event MethodContainer delete;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialog = MessageBox.Show("Are you sure you want end the service?", "Sure?", MessageBoxButton.YesNo);
            if (dialog == MessageBoxResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Hash.connect_str))
                {
                    connection.Open();
                    string take = "exec delete_service @name='"+services.SelectedItem.ToString()+ "',@id=" + main_user_window.Id_manager + ";";
                    SqlCommand commandd = new SqlCommand(take, connection);
                    commandd.ExecuteNonQuery();
                    delete();
                  
                }
            }

        }
    }
}
