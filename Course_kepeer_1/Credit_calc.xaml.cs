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
    /// Логика взаимодействия для Credit_calc.xaml
    /// </summary>
    public partial class Credit_calc : Page
    {

        public Credit_calc()
        {
            InitializeComponent();
            Service.Content = new Credit_page();

        }      
    }
}
