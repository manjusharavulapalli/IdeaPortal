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
    /// Interaction logic for IdeasRecords.xaml
    /// </summary>
    public partial class IdeasRecords : Window
    {
        public List<IdeaRecords> ideainfoRecords;
        public IdeasRecords(List<IdeaRecords> pideainfoRecords )
        {
            InitializeComponent();
            ideainfoRecords = pideainfoRecords;
        }
        DataBaseManager obj = new DataBaseManager();
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ImageReports.Source =  new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/Aprove.jpg", UriKind.Absolute));
            DgIdeas.ItemsSource = ideainfoRecords;
            lblwish.Content = "Welcome " + Login.Name;

        }

        private void BtnIdeaInfo_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;                               
            IdeaInfoReadOnly window = new IdeaInfoReadOnly((int)button.Content);
            this.Visibility = System.Windows.Visibility.Collapsed;
            window.ShowDialog();
           // IdeaInfoReadOnly.id = (int)button.Content;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {          
            if (TxtSearch.Text =="")
            {
            MessageBox.Show("Enter Id Values");
                return;
            }
            int res;
            int.TryParse(TxtSearch.Text,out res);
            if (res > 0)
            {

                DgIdeas.ItemsSource = ideainfoRecords.Where(x => x.ideaid == res).ToList();
            }
            else
            {
                MessageBox.Show("Enter valid number");
                return;
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
            MyIdea my = new MyIdea();
            my.ShowDialog();
           
        }
    }
}
