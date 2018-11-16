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
using System.Text.RegularExpressions;


namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Password_res.xaml
    /// </summary>
    public partial class Password_res : Window
    {
        public Password_res()
        {
            InitializeComponent();
        }
        private void go_click(object sender, RoutedEventArgs e)
        {         
                using (First_model db = new First_model())
                {
                    IEnumerable<User_info> user = db.User_info.Where(u => u.Login.Equals(logcheck.Text));
                    if (user.Count() == 0)
                    {
                        MessageBox.Show("Login not already exists", "Error");
                        logcheck.Clear();
                        Ans.Clear();
                        newe.Clear();
                        Quest.IsEnabled = false;
                        return;
                    }
                    User_info use = user.FirstOrDefault();
                    Quest.Content = use.Question;
                }
                Quest.IsEnabled = true;
            }
        private void logcheck_SelectionChanged(object sender, RoutedEventArgs e)
        {        
            if (logcheck.Text.Length == 0)
            {
                go1.IsEnabled = false;
                return;
            }
            else
                go1.IsEnabled = true;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Regex.IsMatch(newe.Text, register.pattern))
                {
                    MessageBox.Show("Invalid password format");
                    newe.Clear();
                    return;
                }
                using (First_model db = new First_model())
                {
                    IEnumerable<User_info> users = db.User_info.Where(u => u.Login.Equals(logcheck.Text));
                    User_info user = users.First();
                    if (user.Answer.Equals(Hash.GetHash(Ans.Text)))
                    {
                        user.Password = Hash.GetHash(newe.Text);
                        db.SaveChanges();
                        MessageBox.Show("ok");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("incorrect unswer", "Error");
                        Ans.Clear();
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Incorrectly entered data");
                logcheck.Clear();
                Ans.Clear();
                newe.Clear();
                Quest.IsEnabled = false;
                return;
            }
        }
        private void Ans_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Ans.Text.Length == 0 || newe.Text.Length==0 || Quest.IsEnabled==false )
            {
                rese.IsEnabled = false;
                return;
            }
            else
                rese.IsEnabled = true;
        }
    }
}
