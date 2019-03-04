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
using System.Windows.Threading;

namespace Idea_Portal
{
    /// <summary>
    /// Interaction logic for MyIdea.xaml
    /// </summary>
    public partial class MyIdea : Window
    {
        private DispatcherTimer timer
      = new DispatcherTimer(DispatcherPriority.Render);
        int i = 0;

        List<IdeaRecords> IdeasCollection = new List<IdeaRecords>();
       
        DataBaseManager Obj = new DataBaseManager();

        public MyIdea()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.IsEnabled = true;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (i % 4 == 0)
            {
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/Image5.jpg", UriKind.Absolute));
              //  Img_BackGround.Source = new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/BackGround.jpg", UriKind.Absolute));
            }
           if(i%4==1)
            {
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/Image4.jpg", UriKind.Absolute));
            }
           if (i % 4 == 2)
           {
               Img.Source = new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/Image1.jpg", UriKind.Absolute));
           }
           if (i % 4 == 3)
           {
               Img.Source = new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/Image2.jpg", UriKind.Absolute));
           }
          
            i = i + 1;
            if (i == 5)
            {
                i = 0;
            }

        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Img1.Source = new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/Image3.jpg", UriKind.Absolute));
            Img.Source = new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/Image1.jpg", UriKind.Absolute));
            IdeasCollection = Obj.GetIdeaInfo();
            
           
        }

        private void BtnIdea_Click(object sender, RoutedEventArgs e)
        {
            IdeaGeneration Ideagen = new IdeaGeneration();
            this.Visibility = Visibility.Collapsed;
            Ideagen.ShowDialog();
           
            IdeasCollection = Obj.GetIdeaInfo();
        }

        private void BtnTotalIdeas_Click(object sender, RoutedEventArgs e)
        {
            Login.Link = "Total";
            IEnumerable<IdeaRecords> result = from Ideas in IdeasCollection select Ideas;
            IdeasRecords ideaswindow = new IdeasRecords(result.ToList());
            this.Visibility = System.Windows.Visibility.Collapsed;
                            
            ideaswindow.ShowDialog();
           
        }

        private void BtnMyIdea_Click(object sender, RoutedEventArgs e)
        {
            Login.Link = "Self";
            IEnumerable<IdeaRecords> result = from Ideas in IdeasCollection where Ideas.Name == Login.Name select Ideas;
            IdeasRecords ideaswindow = new IdeasRecords(result.ToList());
            this.Visibility = System.Windows.Visibility.Collapsed;




            ideaswindow.ShowDialog();
           
           
        }

        private void BtnCourseIdeas_Click(object sender, RoutedEventArgs e)
        {
            Login.Link = "Course";
            IEnumerable<IdeaRecords> result = from Ideas in IdeasCollection where Ideas.Course == Login.CourseName select Ideas;
            IdeasRecords ideaswindow = new IdeasRecords(result.ToList());
            this.Visibility = System.Windows.Visibility.Collapsed;




            ideaswindow.ShowDialog();
           
        }

        private void BtnNewsLetter_Click(object sender, RoutedEventArgs e)
        {
            NewsLetter window = new NewsLetter();
            this.Visibility = System.Windows.Visibility.Collapsed;
            window.ShowDialog();

        }
    }
}
