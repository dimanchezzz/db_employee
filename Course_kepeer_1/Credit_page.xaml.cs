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

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Credit_page.xaml
    /// </summary>
    public partial class Credit_page : Page
    {
        public Credit_page()
        {
            InitializeComponent();
            isEnable += Isena;
            count.IsEnabled = false;
        }
        public delegate void MethodCHeck();
        public static event MethodCHeck isEnable;
        public void Isena()
        {
            if (amount.Text == "" || mounth.Text == "" || persent.Text == "")

            {
                count.IsEnabled = false;
            }
            else
            {
                count.IsEnabled = true;
            }
        }

        private void count_Click(object sender, RoutedEventArgs e)
        {
            result.Text = (float.Parse(amount.Text) / 12 * float.Parse(mounth.Text) * float.Parse(persent.Text) / 100+ float.Parse(amount.Text)).ToString();
        }

        private void persent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) ))
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
