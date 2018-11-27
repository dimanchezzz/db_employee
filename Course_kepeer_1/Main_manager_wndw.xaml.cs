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
using System.Data;
using System.Xml;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Course_kepeer_1
{
    
    /// <summary>
    /// Логика взаимодействия для Main_manager_wndw.xaml
    /// </summary>
    public partial class Main_manager_wndw : MetroWindow
    {
        int info = 0;
        int Id_employee, Id_service;
        int Id_client;

        List<string> employee = new List<string>();
        List<string> users = new List<string>();
        public Main_manager_wndw()
        {
            InitializeComponent();
           
            isEnable += Isena;
        }
        public void Take_name()
        {
            if (info == 0)
            {
                using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
                {
                    string str = "exec Take_names_emp";
                    connection.Open();
                    SqlCommand command = new SqlCommand(str, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employee.Add(reader.GetValue(0).ToString());
                        }
                    }
                    reader.Close();
                }
                listView1.ItemsSource = employee;
            }
            else if (info == 1)
            {
                using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
                {
                    string str = "exec Take_names_user";
                    connection.Open();
                    SqlCommand command = new SqlCommand(str, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            users.Add(reader.GetValue(0).ToString());
                        }
                    }
                    reader.Close();
                }
                listView1.ItemsSource = users;

            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conection = new SqlConnection(Hash.connect_str_manager))
            {
                conection.Open();
               
                string str1 = "exec Take_xml_client";
                string str3 = "exec Take_xml_employee";
                string str4 = "exec Take_xml_Money_transaction";
                string str5 = "exec Take_xml_service";
                string str2 = "exec Take_xml_contract";
                SqlDataAdapter da = new SqlDataAdapter(str1, conection);
                SqlDataAdapter da2 = new SqlDataAdapter(str2, conection);
                SqlDataAdapter da3 = new SqlDataAdapter(str3, conection);
                SqlDataAdapter da4 = new SqlDataAdapter(str4, conection);
                SqlDataAdapter da5 = new SqlDataAdapter(str5, conection);
                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();
                DataSet ds3 = new DataSet();
                DataSet ds4 = new DataSet();
                DataSet ds5 = new DataSet();
                da.Fill(ds);
                da2.Fill(ds2);
                da3.Fill(ds3);
                da4.Fill(ds4);
                da5.Fill(ds5);
                conection.Close();           
                ds.WriteXml(@"..\..\..\xml\Clients.xml");
                ds2.WriteXml(@"..\..\..\xml\Contracts.xml");
                ds3.WriteXml(@"..\..\..\xml\Employees.xml");
                ds4.WriteXml(@"..\..\..\xml\Money_transactions.xml");
                ds5.WriteXml(@"..\..\..\xml\Services.xml");
                MessageBox.Show("Successfully..");

            }


        }
        int isButton;

        private void emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isButton==1)
            {
                if (listView1.SelectedItem != null)
                {
                    string take = "select dbo.Take_id_manager('" + listView1.SelectedItem.ToString() + "')";
                    using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(take, connection);
                        int id = int.Parse(command.ExecuteScalar().ToString());
                        Id_employee = id;
                        string str1 = "exec ManTake__info @id=" + id + "";
                        SqlCommand cmd = new SqlCommand(str1, connection);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                city.Text = reader.GetValue(3).ToString();
                                phone_number.Text = reader.GetValue(4).ToString();
                                email.Text = reader.GetValue(5).ToString();
                                dep.Text = reader.GetValue(1).ToString();
                            }
                        }
                        reader.Close();
                    }
                    using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
                    {
                        connection.Open();
                        string takee = "exec ManTake__info_service @id='" + Id_employee + "'";
                        SqlCommand commandd = new SqlCommand(takee, connection);
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
                        listview.ItemsSource = list;
                    }
                }

            }
            else if(isButton==0)
            {
                if (listView1.SelectedItem != null)
                {
                    using (SqlConnection conection = new SqlConnection(Hash.connect_str_manager))
                    {
                        conection.Open();
                        string str = "select dbo.Take_id('" + listView1.SelectedItem.ToString() + "')";
                        SqlCommand cmd = new SqlCommand(str, conection);
                        int id = int.Parse(cmd.ExecuteScalar().ToString());
                        Id_client = id;
                        string str1 = "exec Take_user_info @id=" + id + "";
                        SqlCommand cmd1 = new SqlCommand(str1, conection);
                        SqlDataReader reader = cmd1.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                adress.Text = reader.GetValue(2).ToString();
                                city.Text = reader.GetValue(3).ToString();
                                phone_number.Text = reader.GetValue(4).ToString();
                                email.Text = reader.GetValue(5).ToString();

                            }
                        }
                        reader.Close();
                        dep.Visibility = Visibility.Hidden;
                    }
                    using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
                    {
                        connection.Open();
                        string take = "exec take_name_serv_bef_id @id=" + Id_client + "";
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
                        listview.ItemsSource = list;
                    }

                }
            }
        }
      

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            isButton = 1;
            employee.Clear();
            listview.ItemsSource = null;
            listView1.ItemsSource = null;
            city.Text = "";
            phone_number.Text = "";
            adress.Text = "";
            email.Text = "";
            dep.Text = "";
           
            date_start.Text = "";
            date_end.Text = "";
            pay.Text = "";
            debt.Text = "";           
            status.Text = "";
            dep.Visibility = Visibility.Visible;
            info = 0;
            Take_name();
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            users.Clear();
            isButton = 0;
            listView1.ItemsSource = null;
            listview.ItemsSource = null;
            term.Text = "";
            city.Text = "";
            phone_number.Text = "";
            adress.Text = "";
            email.Text = "";
            dep.Text = "";
            percent.Text = "";
            restrict.Text = "";
            date_create.Text = "";
            comment.Text = "";         
            info = 1;
            Take_name();
         


        }

       
        private void adress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
        public delegate void MethodCHeck();
        public static event MethodCHeck isEnable;
        public void Isena()
        {
            if (name.Text == "" || termmm.Text == "" || percenttt.Text == "" || rest.Text == "")

            {
                add.IsEnabled = false;
            }
            else
                add.IsEnabled = true;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
            {
                connection.Open();
                string str = " select dbo.If_exist_name_service('"+name.Text+"')";
                SqlCommand cmd = new SqlCommand(str, connection);
                int a = int.Parse(cmd.ExecuteScalar().ToString());
                if(a==1)
                {
                    MessageBox.Show("This name exists");
                    name.Clear();
                    termmm.Clear();
                    percenttt.Clear();
                    commenttt.Clear();
                    rest.Clear();
                    return;
                }
            }
                XmlTextWriter xriter = new XmlTextWriter(@"..\..\..\xml\Contract.xml", Encoding.UTF8);
            xriter.Formatting = Formatting.Indented;
            xriter.WriteStartElement("info");
            xriter.WriteStartElement("name");
            xriter.WriteString(name.Text);
            xriter.WriteEndElement();
            xriter.WriteStartElement("term");
            xriter.WriteString(termmm.Text);
            xriter.WriteEndElement();
            xriter.WriteStartElement("percent_t");
            xriter.WriteString(percenttt.Text);
            xriter.WriteEndElement();
            xriter.WriteStartElement("id_employee");
            xriter.WriteString(0.ToString());
            xriter.WriteEndElement();
            xriter.WriteStartElement("departament");
            xriter.WriteString(departament.Text);
            xriter.WriteEndElement();
            xriter.WriteStartElement("restriction");
            xriter.WriteString(rest.Text);
            xriter.WriteEndElement();
            xriter.WriteStartElement("comment");
            xriter.WriteString(commenttt.Text);
            xriter.WriteEndElement();
            xriter.WriteStartElement("is_end");
            xriter.WriteString(0.ToString());
            xriter.WriteEndElement();
            xriter.WriteEndElement();
            xriter.Close();
            using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
            {
                connection.Open();
                string str = "exec Insert_service_xml ";
                SqlCommand cmd = new SqlCommand(str, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ok");
                name.Clear();
                termmm.Clear();
                percenttt.Clear();
                commenttt.Clear();
                rest.Clear();

            }


        }
        private void amount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            isEnable();
        }
        List<string> passport_list = new List<string>();
        List<string> resource_list = new List<string>();
        List<float> amount_list = new List<float>();
        
        float purse;
        int id_user;

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //add_user_stack.Visibility = Visibility.Visible;
            XML_user user1 = new XML_user("123124999",  "Phone", (float)23.12);
            XML_user user2 = new XML_user("123124329",  "Phone", 23);
            XML_user[] users = new XML_user[] { user1, user2 };
            XmlSerializer formatter = new XmlSerializer(typeof(XML_user[]));
            using (FileStream fs= new FileStream(@"..\..\..\xml\New_info.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, users);
            }
            using (FileStream fs = new FileStream(@"..\..\..\xml\New_info.xml", FileMode.OpenOrCreate))
            {
                XML_user[] newuser = (XML_user[])formatter.Deserialize(fs);
                foreach(XML_user x in newuser)
                {
                    passport_list.Add(x.Passport);
                    resource_list.Add(x.Resource);
                    amount_list.Add(x.Amount);                   
                }
                for(int i = 0; i < passport_list.Count; i++)
                {
                    using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
                    {
                        connection.Open();
                        string str = " select dbo.Is_passport('" + passport_list[i] + "')";
                        SqlCommand cmd = new SqlCommand(str, connection);
                        int a = (int)cmd.ExecuteScalar();
                        if(a==1)
                        {
                            string str1 = "select dbo.Take_purse_passport('"+passport_list[i]+"')";
                            SqlCommand command = new SqlCommand(str1, connection);
                            purse = float.Parse(command.ExecuteScalar().ToString());
                            string str2 = "select dbo.Take_id_passport('" + passport_list[i] + "')";
                            SqlCommand cmd2 = new SqlCommand(str2, connection);
                            id_user = int.Parse(cmd2.ExecuteScalar().ToString());
                            //////////////
                            float after =purse-amount_list[i];
                            string res = resource_list[i].ToString();
                            string take_purse = "XML_PAY";
                            SqlCommand cmd3 = new SqlCommand(take_purse, connection);
                            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd3.Parameters.AddWithValue("@id_client",id_user);
                            cmd3.Parameters.AddWithValue("@before", purse);
                            cmd3.Parameters.AddWithValue("@name_oper", res);
                            cmd3.Parameters.AddWithValue("@after", after);
                            var returnParameter = cmd3.Parameters.Add("@ReturnVal", SqlDbType.Int);
                            returnParameter.Direction = ParameterDirection.ReturnValue;
                            cmd3.ExecuteNonQuery();
                            int result = int.Parse(returnParameter.Value.ToString());
                            if (result != 1)
                                MessageBox.Show("Update don't saved");
                            else
                            {
                                MessageBox.Show("Ok");
                                resource_list.Clear();
                                passport_list.Clear();
                                amount_list.Clear();
                            }
                        }
                    }
                }
            }

        }


        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (info == 0)
            {             
                if (listview.SelectedItem != null)
                {
                    string select = listview.SelectedItem.ToString();
                    using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
                    {
                        connection.Open();
                        string take = " exec Take_service_info @name='" + select + "';";
                        SqlCommand commandd = new SqlCommand(take, connection);
                        SqlDataReader reader = commandd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                term.Text = "Term: " + reader.GetValue(2);
                                percent.Text = "Percent: " + reader.GetValue(3) + " %";
                                restrict.Text = "Restriction: " + reader.GetValue(6);
                                date_create.Text = "Date create: " + reader.GetValue(7);
                                comment.Text = "Comment: " + reader.GetValue(8);
                            }
                        }
                        reader.Close();
                    }
                }

            }
            else if (info==1)
            {
                if (listview.SelectedItem != null)
                {
                    string select = listview.SelectedItem.ToString();
                    using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
                    {
                        connection.Open();
                        string take = " exec Take_service_info @name='" + select + "';";
                        SqlCommand commandd = new SqlCommand(take, connection);
                        SqlDataReader reader = commandd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Id_service = int.Parse(reader.GetValue(0).ToString());
                            }
                        }
                        reader.Close();
                        string take_info_contr = "exec take_contr_info @id_service=" + Id_service + ",@id_client=" + Id_client + ";";
                        SqlCommand com = new SqlCommand(take_info_contr, connection);
                        SqlDataReader read = com.ExecuteReader();
                        if (read.HasRows)
                        {
                            while (read.Read())
                            {
                                date_start.Text = "Start date: " + read.GetValue(4);
                                date_end.Text = "End date: " + read.GetValue(5);
                                pay.Text = "Pay: " + read.GetValue(8);
                                debt.Text = "Debt: " + read.GetValue(9);
                               
                                status.Text = "Status: " + read.GetValue(6);
                               
                            }
                            read.Close();
                        }
                    }
                }
            }
        }
    }
}
