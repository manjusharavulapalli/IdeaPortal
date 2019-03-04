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

namespace Idea_Portal
{
    /// <summary>
    /// Interaction logic for NewsLetter.xaml
    /// </summary>
    public partial class NewsLetter : Window
    {
        public NewsLetter()
        {
            InitializeComponent();
        }
        DataBaseManager obj = new DataBaseManager();
        //private void NewsletterWIndow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    int[] result = new int[3];
        //    result = obj.StatusInfo();
        //    ImgHeader.Source =  new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/Image3.jpg", UriKind.Absolute));

        //    lblactivestudents.Content = result[0].ToString();
        //    lblIdeasproposed.Content = result[1].ToString();
        //    lblIdeasImplemented.Content = result[2].ToString();

          
           
        //}

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
            MyIdea my = new MyIdea();
            my.ShowDialog();
        }
    }
}
