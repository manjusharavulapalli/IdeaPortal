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
    /// Interaction logic for AproverForm.xaml
    /// </summary>
    public partial class AproverForm : Window
    {
        List<IdeaRecords> IdeaRecColle;
        List<IdeaRecords> Totalrecords;
       
        DataBaseManager obj = new DataBaseManager();
        public AproverForm(List<IdeaRecords> pIdeaRecColle)
        {
            InitializeComponent();
            IdeaRecColle = pIdeaRecColle;
            Totalrecords = obj.GetIdeaInfo();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            DgRecords.ItemsSource = IdeaRecColle;
            ImgAprove.Source = new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/Aprove.jpg", UriKind.Absolute));
            lblwish.Content = "Welcome " + Login.Name;
        }

        private void BtnIdeaInfo_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            IdeaInfoReadOnly window = new IdeaInfoReadOnly((int)button.Content);
            this.Visibility = System.Windows.Visibility.Collapsed;
            window.ShowDialog();
           // this.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnTotalIdeas_Click(object sender, RoutedEventArgs e)
        {
            DgRecords.ItemsSource = Totalrecords;
        }

        private void BtnCourseIdeas_Click(object sender, RoutedEventArgs e)
        {
            DgRecords.ItemsSource = (Totalrecords.Where(x => x.Course == Login.CourseName)).ToList();
          
        }

        private void BtnPendingIdeas_Click(object sender, RoutedEventArgs e)
        {
            DgRecords.ItemsSource = (Totalrecords.Where(x => x.PendingWith == Login.Name)).ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (TxtSearch.Text == "")
            {
                MessageBox.Show("Enter Id Values");
                return;
            }
            int res;
            int.TryParse(TxtSearch.Text, out res);
            if (res > 0)
            {

                DgRecords.ItemsSource = (Totalrecords.Where(x => x.ideaid == res)).ToList();
            }
            else
            {
                MessageBox.Show("Enter valid number");
                return;
            }
        }
    }
}
