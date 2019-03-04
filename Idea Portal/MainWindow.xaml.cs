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

namespace Idea_Portal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
  
    public partial class MainWindow : Window
    {
        DataBaseManager Obj = new DataBaseManager();

        public List<IdeaRecords> IdeasCollection = new List<IdeaRecords>();
             
        public MainWindow()
        {
            InitializeComponent();
            IdeasCollection = Obj.GetIdeaInfo();
        }

        private void IdeaPortal_Login_Loaded(object sender, RoutedEventArgs e)
        {
          Img_BackGround.Source = new BitmapImage(new Uri("pack://application:,,,/Idea Portal;component/Resources/BackGround.jpg", UriKind.Absolute));
         
        }

        private void BtnLogin1_Click(object sender, RoutedEventArgs e)
        {
            if (((TxtUserName.Text).ToString()).Trim() == "")
            {
                MessageBox.Show("Enter UserName");
                return;
            }
            if (((PwdPassword.Password).ToString()).Trim() == "")
            {
                MessageBox.Show("Enter Password");
                return;
            }

          int res =   Obj.LoginCheck(TxtUserName.Text, PwdPassword.Password);
         // MessageBox.Show(res);
            if (res > 0)
          {
             if (Login.role == "Admin") 
             {
                 Admin Adminwindow = new Admin();
                 this.Visibility = Visibility.Collapsed;
                 Adminwindow.ShowDialog();
             }
              if(Login.role == "Student")
              {
                  MyIdea IdeaWindow = new MyIdea();
                  this.Visibility = Visibility.Collapsed;
                  IdeaWindow.ShowDialog();
              
              }
              if (Login.role == "Aprover")
              {
                  IEnumerable<IdeaRecords> result = from Ideas in IdeasCollection where Ideas.PendingWith == Login.Name  select Ideas;
                 
                  AproverForm ideaswindow = new AproverForm(result.ToList());
                  this.Visibility = System.Windows.Visibility.Collapsed;

               
                  ideaswindow.ShowDialog();
                  
              }
             
          }

        }

       
    }
}
