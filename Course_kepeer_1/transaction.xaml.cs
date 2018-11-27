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
using System.Data.SqlClient;

namespace Course_kepeer_1
{
    public class MyItems
    {
        public string before { get; set; }

        public string after { get; set; }
        public string resourc { get; set; }
        public string date { get; set; }

    }
    /// <summary>
    /// Логика взаимодействия для transaction.xaml
    /// </summary>
    public partial class transaction : MetroWindow
    {
        int ID;
        public transaction(int id)
        {
            ID = id;
            InitializeComponent();
            Take_info();
        }
        List<string> before = new List<string>();
        List<string> after = new List<string>();
        List<string> resourc = new List<string>();
        List<string> date = new List<string>();
        public void Take_info()
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string take = "Take_money_trans_info @id=" + ID + "";
                SqlCommand command = new SqlCommand(take, connection);
                SqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        before.Add(read.GetValue(2).ToString());
                        after.Add(read.GetValue(3).ToString());
                        resourc.Add(read.GetValue(5).ToString());
                        date.Add(read.GetValue(4).ToString());
                    }
                    read.Close();
                }
            }
            for (int i = 0; i < date.Count; i++)
            {
                listView.Items.Add(new MyItems { before = before.ElementAt(i), after = after.ElementAt(i), resourc = resourc.ElementAt(i), date = date.ElementAt(i) });
            }

        }
    }
}
