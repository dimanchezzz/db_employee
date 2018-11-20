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
    public class MyItem
    {
        public string id_client { get; set; }

        public string Name { get; set; }
      

    }
    /// <summary>
    /// Логика взаимодействия для My_contract.xaml
    /// </summary>
    public partial class My_contract : Page
    {
        public My_contract()
        {
            InitializeComponent();
           // RefreshList();
        }
        List<string> list = new List<string>();
        List<int> list_id = new List<int>();
        private void RefreshList(string text)
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string take = "exec take_name_serv_bef_status @status='" + text + "'";
                SqlCommand commandd = new SqlCommand(take, connection);
                SqlDataReader reader = commandd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetValue(0).ToString());
                        list_id.Add(Convert.ToInt32(reader.GetValue(1)));
                    }
                }
                reader.Close();
                if (list.Count != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        listView.Items.Add(new MyItem { id_client = list_id.ElementAt(i).ToString(), Name = list.ElementAt(i) });
                    }
                }
                else listView.Items.Clear();
            }
        }

       

        private void new_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            list.Clear();
            list_id.Clear();
            RefreshList(@new.Content.ToString());
        }

        private void active_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            list.Clear();
            list_id.Clear();
            RefreshList(active.Content.ToString());
        }

        private void rejected_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            list.Clear();
            list_id.Clear();
            RefreshList(rejected.Content.ToString());
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListView)sender;
            var info = (MyItem)listView.SelectedItem;
            if (info != null)
            {
                MessageBox.Show("id= " + info.id_client + " " + "Name= " + info.Name);
            }
        }
    }
}
