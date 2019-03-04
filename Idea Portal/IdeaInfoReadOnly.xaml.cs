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
    /// Interaction logic for IdeaInfoReadOnly.xaml
    /// </summary>
    public partial class IdeaInfoReadOnly : Window
    {
      
       public int id;
       Ideas Ideainfo = new Ideas();

        public IdeaInfoReadOnly()
        {
            InitializeComponent();
           
        }
        public IdeaInfoReadOnly(int i)
        {
            InitializeComponent();
            id = i;

        }
        DataBaseManager obj = new DataBaseManager();
        int Documentid = 0;

        private void IdeaReadOnly_Loaded(object sender, RoutedEventArgs e)
        {
            LblWish.Content = "WelCome "+Login.Name;
            string comp="";
            Ideainfo = obj.IdeaDisplay(id);
            List<IdeaRecords> colle = obj.GetIdeaInfo();
         IEnumerable<string> xx = from rec in colle where rec.ideaid == id select rec.PendingWith;

         foreach(string Name in xx)
         {
             comp = Name;
         }
               if ((Login.role == "Aprover") && (comp.Equals(Login.Name)))
          {
              Gidonoff.Visibility = Visibility.Visible;
             
          }
         else
         {
             Gidonoff.Visibility = Visibility.Hidden;
         }

          if (Login.role == "Student") 
          {
              Gidonoff.Visibility = Visibility.Hidden;
             
          }
          if (Ideainfo.documentid < 1)
          {
          BtnDownLoad.Visibility = Visibility.Hidden;
          }


            if (Ideainfo != null)
            {
                TxtTitle.Text = Ideainfo.Title;

                TxtBenfits.Text = Ideainfo.Benfits;
                TxtCurrentProcess.Text = Ideainfo.currentprocess;
                TxtProposedSolution.Text = Ideainfo.Proposedsolution;
                TxtDesc.Text = Ideainfo.Description;
                CmbCategory.Text = Ideainfo.category;
               
                TxtLevel1comments.Text = Ideainfo.comment1;
                TxtLevel2comments.Text = Ideainfo.comment2;
                Documentid = Ideainfo.documentid;
            }
            LblWish.Content = "Welcome " + Login.Name;

            
        }

       

        private void BtnAprove_Click(object sender, RoutedEventArgs e)
        {
            String status=null;
            int i = 0;
            if (Ideainfo.status == "Submited")
            {
                status = "level1";
                i = 1;
            }
            if (Ideainfo.status == "level1")
            {
                status = "level2";
                i = 2;
            }

            if (TxtComments.Text == "")
            {
                MessageBox.Show("Enter Comments");
                return;
            }

            obj.updatesatus(id, TxtComments.Text, status,i);
            MessageBox.Show("Approved");

            IEnumerable<string> maillist = obj.GetIdeaInfo().Where(x => x.ideaid == id).Select(x => x.Mailtoid);

         
            String Data = "Dear Approver," + Environment.NewLine
                         + "Below idea has been submitted by " + Login.Name + " and is awaiting your approvals." + Environment.NewLine
                          + "Please review and provide your feedback." + Environment.NewLine
                          + "Idea#       " + id + Environment.NewLine
                          + " Idea Desc:  " + Ideainfo.Title;


            foreach (string temp in maillist)
            {
                if (Ideainfo.status == "Submited")
                {
                    obj.SendMail(temp, Data);
                }
            }
            this.Visibility = System.Windows.Visibility.Collapsed;
            AproverForm ap = new AproverForm((obj.GetIdeaInfo().Where(x=>x.PendingWith==Login.Name)).ToList());
            ap.ShowDialog();
        }

        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            String status=null;
            int i = 0;
            if (Ideainfo.comment1 == "")
            {
                i = 1;
                status = "Rejected";
            }
            else
            {
                i = 2;
                status = "Rejected";
            }
            obj.updatesatus(id, TxtComments.Text, status, i);
            MessageBox.Show("Rejected");
            this.Visibility = System.Windows.Visibility.Collapsed;
            AproverForm ap = new AproverForm((obj.GetIdeaInfo().Where(x => x.PendingWith == Login.Name)).ToList());
            ap.ShowDialog();

        }

        private void BtnDownLoad_Click(object sender, RoutedEventArgs e)
        {

         

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

                  saveFileDialog1.Filter = "Files (*)|*" ;
 
                                saveFileDialog1.Title = "Save File as";

                               // saveFileDialog1.CheckPathExists = true;

                                if (saveFileDialog1.ShowDialog().ToString() == "OK")
                                {
                                    
                                    string fileName = saveFileDialog1.FileName;
                                    String FileType = obj.GetFileType(Documentid);
                                 
                                    
                                     obj.WriteFile(fileName,FileType, Documentid);
                                    
                                }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
           
            if (Login.role == "Aprover")
            {
                AproverForm ap = new AproverForm((obj.GetIdeaInfo().Where(x => x.PendingWith == Login.Name)).ToList());
                ap.ShowDialog();
            }
            if (Login.role == "Student")
            {
                if (Login.Link == "Total")
                {
                   // this.Visibility = System.Windows.Visibility.Collapsed;
                    IEnumerable<IdeaRecords> result = from Ideas in obj.GetIdeaInfo() select Ideas;
                    IdeasRecords ideaswindow = new IdeasRecords(result.ToList());
                   

                    ideaswindow.ShowDialog();
                }
                if (Login.Link == "Self")
                {
                   // this.Visibility = System.Windows.Visibility.Collapsed;
                    IEnumerable<IdeaRecords> result = from Ideas in obj.GetIdeaInfo() where Ideas.Name == Login.Name select Ideas;
                    IdeasRecords ideaswindow = new IdeasRecords(result.ToList());                   
                    ideaswindow.ShowDialog();
                }

                if (Login.Link == "Course")
                {
                  //  this.Visibility = System.Windows.Visibility.Collapsed;
                    IEnumerable<IdeaRecords> result = from Ideas in obj.GetIdeaInfo() where Ideas.Course == Login.CourseName select Ideas;
                    IdeasRecords ideaswindow = new IdeasRecords(result.ToList());
                  
                    ideaswindow.ShowDialog();
                }
           
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
           
            if (Login.role == "Aprover")
            {
                AproverForm ap = new AproverForm((obj.GetIdeaInfo().Where(x => x.PendingWith == Login.Name)).ToList());
                ap.ShowDialog();
            }
            if (Login.role == "Student")
            {
                MyIdea MyIdea = new MyIdea();
                MyIdea.ShowDialog();
            }
                            
        }
    }
}
