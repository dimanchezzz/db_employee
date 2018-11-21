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
using System.Data;

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
        public int id_client_i=0;
        public float purse;
        public int termm;
        public float payy;
        public My_contract()
        {
            InitializeComponent();
            user.IsEnabled = false;

            decline.IsEnabled = false;
            exept.IsEnabled = false;
            check();
        }
        public void check()
        {
            if (listView.Items.Count == 0)
            {
                decline.IsEnabled = false;
                exept.IsEnabled = false;
            }
        }
        List<string> list = new List<string>();
        List<int> list_id = new List<int>();
        int ID_CONTRACT;
        private void RefreshList(string text)
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string take = "exec take_name_serv_bef_status @status='" + text + "',@dep='"+main_user_window.departament+"'";
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
        public void Clears()
        {
            user.Text = "";
            amount.Text = "";
            pay.Text = "";
            date.Text = "";
            percent.Text = "";
            term.Text = "";
            restr.Text = "";
        }
        private void new_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            decline.IsEnabled = true;
            exept.IsEnabled = true;
            
            Clears();
            listView.Items.Clear();
            list.Clear();
            list_id.Clear();
            RefreshList(@new.Content.ToString());
            check();
        }

        private void active_Click(object sender, RoutedEventArgs e)
        {
            decline.IsEnabled = false;
            exept.IsEnabled = false;
            Clears();
            listView.Items.Clear();
            list.Clear();
            list_id.Clear();
            RefreshList(active.Content.ToString());
        }

        private void rejected_Click(object sender, RoutedEventArgs e)
        {
            decline.IsEnabled = false;
            exept.IsEnabled = false;
            Clears();
            user.IsEnabled = false;
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
              using (SqlConnection connection = new SqlConnection(Hash.connect_str))
                {
                    connection.Open();
                    string str = "exec take_request_info @name='"+info.Name+"',@id_client="+info.id_client+"";
                    SqlCommand command = new SqlCommand(str, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.Text = reader.GetValue(3).ToString();
                            amount.Text ="Amount: " +reader.GetValue(0).ToString();
                            pay.Text ="Pay: "+ reader.GetValue(1).ToString();
                            payy = float.Parse(reader.GetValue(1).ToString());
                            date.Text = reader.GetValue(2).ToString();
                            percent.Text = reader.GetValue(5).ToString() + " %";
                            term.Text = "Term" + reader.GetValue(7).ToString();
                            termm = int.Parse(reader.GetValue(7).ToString());
                            restr.Text = "Restriction: " + reader.GetValue(6).ToString();
                            id_client_i =int.Parse(reader.GetValue(4).ToString());
                            ID_CONTRACT = int.Parse(reader.GetValue(8).ToString());
                            purse = float.Parse(reader.GetValue(9).ToString());

                        }
                    }
                    reader.Close();
                }
                user.IsEnabled = true;              

            }
        }

        private void user_MouseMove(object sender, MouseEventArgs e)
        {
            user.FontSize = 27;
        }

        private void user_MouseLeave(object sender, MouseEventArgs e)
        {
            user.FontSize = 25;
        }

        private void user_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Info_user user = new Info_user(id_client_i);
            user.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(Hash.connect_str))
                {
                    connection.Open();
                    string str = "exec update_contract_decline @id_contr=" + ID_CONTRACT + ", @id_client=" + id_client_i + "";
                    SqlCommand command = new SqlCommand(str, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Jo");
                }
            }
            catch
            {
                MessageBox.Show("Exeption");
            }
            
           
        }
        public delegate void MethodCHeck();
        public static event MethodCHeck isEnable;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //try
            //{
                using(SqlConnection connection = new SqlConnection(Hash.connect_str))
                {
                    float pu = purse + payy;
                    connection.Open();
                    string str = "Add_active_contract_credit";
                    SqlCommand cmd = new SqlCommand(str, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_contr", ID_CONTRACT);
                    cmd.Parameters.AddWithValue("@id_client", id_client_i);
                    cmd.Parameters.AddWithValue("@id_employee", main_user_window.Id_manager);
                    cmd.Parameters.AddWithValue("@after", pu);
                    cmd.Parameters.AddWithValue("@term", termm);
                    cmd.Parameters.AddWithValue("@purse", purse);
                    cmd.Parameters.AddWithValue("@name_oper", main_user_window.departament);
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int result = int.Parse(returnParameter.Value.ToString());
                    if(result!=1)
                    {
                        MessageBox.Show("Update don't saved");
                    }
                    else
                    {
                        MessageBox.Show("Ok");
                        isEnable();

                    }

                }
 //                @id_contr int,
 //                 @id_client int,
 //                 @id_employee int,
 //                 @after real,
 //                 @term int,
 //                 @purse real,
 //                 @name_oper nvarchar(50)











            //}
            //catch
            //{
            //    MessageBox.Show("Exeption");
              
            //}

        }
    }
}
