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
    /// Логика взаимодействия для Add_service.xaml
    /// </summary>
    public partial class Add_service : Page
    { 
        public Add_service()
        {
            InitializeComponent();
            isEnable += Isena;
            agree.IsEnabled = false;
        }
        public delegate void MethodCHeck();
        public static event MethodCHeck isEnable;
        public void Isena()
        {
            if (name.Text == "" || term.Text == "" || percent.Text == "" || rest.Text=="")

            {
                agree.IsEnabled = false;
            }
            else
                agree.IsEnabled = true;                   
        }
        private void agree_Click_1(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str_manager))
            {
                connection.Open();
                string str = " select dbo.If_exist_name_service('" + name.Text + "')";
                SqlCommand cmd = new SqlCommand(str, connection);
                int a = int.Parse(cmd.ExecuteScalar().ToString());
                if (a == 1)
                {
                    MessageBox.Show("This name exists");
                    name.Clear();
                    term.Clear();
                    percent.Clear();
                    comment.Clear();
                    rest.Clear();
                    return;
                }
            }
            using (SqlConnection conn= new SqlConnection(Hash.connect_str))
            {
                conn.Open();                           
                string sql_add = @"exec Insert_service @name='" + name.Text + "',@term=" + term.Text + ",@persent=" + percent.Text + ",@id_emp=" + main_user_window.Id_manager + ",@depart='" + main_user_window.departament + "', @restriction="+rest.Text+ ", @comment='" + comment.Text + "';";
                SqlCommand command = new SqlCommand(sql_add, conn);
                command.ExecuteNonQuery();
                name.Clear();
                term.Clear();
                percent.Clear();           
                comment.Clear();
                rest.Clear();
            }
        }
        private void adress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
        private void amount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            isEnable();
        }
    }
}
