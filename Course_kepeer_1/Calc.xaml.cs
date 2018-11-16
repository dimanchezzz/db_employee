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
    /// Логика взаимодействия для Calc.xaml
    /// </summary>
    
    public partial class Calc : Page
    {
        
       
        public Calc()
        {
             {
                InitializeComponent();
                isEnable += Isena;
                Calc_info go = new Calc_info();
                info = go.get_info();
            } 
           
           
         
        }
        public delegate void MethodCHeck();
        public static event MethodCHeck isEnable;

        //countr.Add(usd);
        //    countr.Add(eur);
        //    countr.Add(pol);
        //    countr.Add(bgn);
        //    countr.Add(rub);
        //    countr.Add(gbp);
        //    countr.Add(uah);
        List<float> info;
        public void Isena()
        {
          if(blr.IsFocused)
            {
                usa.Text = (float.Parse(blr.Text)/ info.ElementAt(0)).ToString();
                eur.Text = ( float.Parse(blr.Text)/ info.ElementAt(1)).ToString();
                rus.Text = ((float.Parse(blr.Text)/ info.ElementAt(4)) * 100).ToString();
                uk.Text = (( float.Parse(blr.Text)/ info.ElementAt(6)) *100).ToString();
                gbp.Text = (  float.Parse(blr.Text)/ info.ElementAt(5)).ToString();
                bgn.Text = (  float.Parse(blr.Text)/ info.ElementAt(3)).ToString();                               
            }
          else if (usa.IsFocused)
            {
                blr.Text = (float.Parse(usa.Text) * info.ElementAt(0)).ToString();
                eur.Text = (float.Parse(blr.Text) / info.ElementAt(1)).ToString();
                rus.Text = ((float.Parse(blr.Text) / info.ElementAt(4)) * 100).ToString();
                uk.Text = ((float.Parse(blr.Text) / info.ElementAt(6)) * 100).ToString();
                gbp.Text = (float.Parse(blr.Text) / info.ElementAt(5)).ToString();
                bgn.Text = (float.Parse(blr.Text) / info.ElementAt(3)).ToString();
            }
          else if (eur.IsFocused)
            {
                blr.Text = (float.Parse(eur.Text) * info.ElementAt(1)).ToString();
                usa.Text = (float.Parse(blr.Text) / info.ElementAt(0)).ToString();
                rus.Text = ((float.Parse(blr.Text) / info.ElementAt(4)) * 100).ToString();
                uk.Text = ((float.Parse(blr.Text) / info.ElementAt(6)) * 100).ToString();
                gbp.Text = (float.Parse(blr.Text) / info.ElementAt(5)).ToString();
                bgn.Text = (float.Parse(blr.Text) / info.ElementAt(3)).ToString();
            }
          else if (rus.IsFocused)
            {
                //rus.Text = ((float.Parse(blr.Text)/ info.ElementAt(4)) * 100).ToString();
                blr.Text = (float.Parse(rus.Text) * info.ElementAt(4) / 100).ToString();
                usa.Text = (float.Parse(blr.Text) / info.ElementAt(0)).ToString();
                eur.Text = (float.Parse(blr.Text) / info.ElementAt(1)).ToString();
                uk.Text = ((float.Parse(blr.Text) / info.ElementAt(6)) * 100).ToString();
                gbp.Text = (float.Parse(blr.Text) / info.ElementAt(5)).ToString();
                bgn.Text = (float.Parse(blr.Text) / info.ElementAt(3)).ToString();
            }
          else if (uk.IsFocused)
            {
                blr.Text = (float.Parse(uk.Text) * info.ElementAt(6) / 100).ToString();
                usa.Text = (float.Parse(blr.Text) / info.ElementAt(0)).ToString();
                eur.Text = (float.Parse(blr.Text) / info.ElementAt(1)).ToString();
                gbp.Text = (float.Parse(blr.Text) / info.ElementAt(5)).ToString();
                rus.Text = ((float.Parse(blr.Text) / info.ElementAt(4)) * 100).ToString();
                bgn.Text = (float.Parse(blr.Text) / info.ElementAt(3)).ToString();
            }
          else if (gbp.IsFocused)
            {
                blr.Text = (float.Parse(gbp.Text) * info.ElementAt(5)).ToString();
                usa.Text = (float.Parse(blr.Text) / info.ElementAt(0)).ToString();
                eur.Text = (float.Parse(blr.Text) / info.ElementAt(1)).ToString();
                uk.Text = ((float.Parse(blr.Text) / info.ElementAt(6)) * 100).ToString();
                bgn.Text = (float.Parse(blr.Text) / info.ElementAt(3)).ToString();
                rus.Text = ((float.Parse(blr.Text) / info.ElementAt(4)) * 100).ToString();
            }
          else if (bgn.IsFocused)
            {
                blr.Text = (float.Parse(bgn.Text) * info.ElementAt(3)).ToString();
                usa.Text = (float.Parse(blr.Text) / info.ElementAt(0)).ToString();
                eur.Text = (float.Parse(blr.Text) / info.ElementAt(1)).ToString();
                rus.Text = ((float.Parse(blr.Text) / info.ElementAt(4)) * 100).ToString();
                uk.Text = ((float.Parse(blr.Text) / info.ElementAt(6)) * 100).ToString();
                gbp.Text = (float.Parse(blr.Text) / info.ElementAt(5)).ToString();
            }
        }
        
        
        private void blr_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(blr.Text!="")
            isEnable();
        }

        private void usa_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (usa.Text != "")
                isEnable();
           
        }

        private void eur_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(eur.Text!="")
            isEnable();
           
        }

        private void rus_SelectionChanged(object sender, RoutedEventArgs e)
        { if(rus.Text!="")
            isEnable();
          
        }

        private void uk_SelectionChanged(object sender, RoutedEventArgs e)
        { 
            if(uk.Text!="")
            isEnable();
            
        }

        private void gbp_SelectionChanged(object sender, RoutedEventArgs e)
        { if(gbp.Text!="")
            isEnable();
            
        }

        private void bgn_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(bgn.Text!="")
            isEnable();
            
        }

        

        private void blr_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!(Char.IsDigit(e.Text,0)|| (e.Text==".") && (!blr.Text.Contains(".")&& blr.Text.Length!=0)))
            {
                e.Handled = true;
            }

        }

        private void usa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!usa.Text.Contains(".") && usa.Text.Length != 0)))
            {
                e.Handled = true;
            }

        }

        private void eur_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!eur.Text.Contains(".") && eur.Text.Length != 0)))
            {
                e.Handled = true;
            }

        }

        private void rus_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!rus.Text.Contains(".") && rus.Text.Length != 0)))
            {
                e.Handled = true;
            }

        }

        private void uk_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!uk.Text.Contains(".") && uk.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void gbp_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!gbp.Text.Contains(".") && gbp.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void bgn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!bgn.Text.Contains(".") && bgn.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
