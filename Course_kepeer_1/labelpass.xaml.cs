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
using System.Windows.Media.Animation;
using System.Windows.Threading;


namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для labelpass.xaml
    /// </summary>
    public partial class labelpass : Page
    {
        Resource_info info;
        Border Bo;
        private DispatcherTimer dispatcherTimer;
        public labelpass(Resource_info Info, Border bo)
        {
            Coding cod = new Coding();
            Bo = bo;
            InitializeComponent();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,2);
            if (Info != null)
            {
                info = Info;
                resou.Content = Info.Resource;
                log.Content = Info.Login_resource;
                pass.Content = cod.Decode(Info.Password_resource);
            }
         
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            notification.Visibility = Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
        }
        private void log_MouseDown(object sender, MouseButtonEventArgs e)
        {
            notification.Visibility = Visibility.Visible;
            Clipboard.SetText(log.Content.ToString());
            dispatcherTimer.Start();
        }
        private void cory(object sender, MouseButtonEventArgs e)
        {
            notification.Visibility = Visibility.Visible;
            Clipboard.SetText(pass.Content.ToString());
            dispatcherTimer.Start();
        }
    }
}
