using System.Windows;
using MahApps.Metro.Controls;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Question.xaml
    /// </summary>
    public partial class Question : MetroWindow
    {
        public Question()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow man = new MainWindow();
            man.Show();
            onNewUser();
            Close();
        }
        public delegate void question();
        public static event question onNewUser;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
