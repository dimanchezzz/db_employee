using System.Windows;
using MahApps.Metro.Controls;
using System.Data.SqlClient;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Info_user.xaml
    /// </summary>
    public partial class Info_user : MetroWindow
    {
        public int Id;
        public Info_user(int id)
        {
            Id = id;
            InitializeComponent();
            info();
        }
        public void info()
        {
            string take = "exec Take_user_info @id=" + Id + ";";
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(take, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        adress.Text = reader.GetValue(2).ToString();
                        city.Text = reader.GetValue(3).ToString();
                        phone_number.Text = reader.GetValue(4).ToString();
                        email.Text = reader.GetValue(5).ToString();
                        pasport.Text = reader.GetValue(9).ToString();
                        Purse.Text = reader.GetValue(7).ToString();
                    }
                }
                reader.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
