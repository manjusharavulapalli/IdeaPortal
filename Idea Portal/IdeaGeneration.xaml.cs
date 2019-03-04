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
using System.Data;
using System.IO;
using System.Net.Mail;


namespace Idea_Portal
{
    /// <summary>
    /// Interaction logic for IdeaGeneration.xaml
    /// </summary>
  
    public partial class IdeaGeneration : Window 
    {
        public IdeaGeneration()
        {
            InitializeComponent();
        }
        DataBaseManager Obj = new DataBaseManager();
        int Documentid = 0;
        int Ideaid = 0;
        private void BtnSubmitIdea_Click(object sender, RoutedEventArgs e)
        {
            Ideas rec= new Ideas();
            // byte[] data=null;
            rec.Title = TxtTitle.Text;
           rec.Description=TxtDesc.Text;
           rec.category = CmbCategory.Text;
            rec.currentprocess = TxtCurrentProcess.Text;
            rec.Proposedsolution = TxtProposedSolution.Text;
            rec.Benfits =TxtBenfits.Text;
            rec.otherInformation = TxtOtherInformations.Text;
            rec.status = "Submited";
            rec.createdon  = DateTime.Now;


            if (Documentid > 0)
            {
                rec.documentid = Documentid;
            }

            if (TxtTitle.Text == "")
            {
                MessageBox.Show("Enter Title");
                return;
            }
            if (TxtDesc.Text == "")
            {
                MessageBox.Show("Enter Description");
                return;
            }
            //if (CmbCategory.SelectedValue == null)
            //{
            //    MessageBox.Show("Select category");
            //    return;
            //}
            if (TxtCurrentProcess.Text=="")
            {
                MessageBox.Show("Select CurrentProcess");
                return;
            }
            if (TxtProposedSolution.Text == "")
            {
                MessageBox.Show("Select PoposedSolution");
                return;
            }
            if (TxtBenfits.Text == "")
            {
                MessageBox.Show("Select Benfits");
                return;
            }
          
             Ideaid= Obj.CreateIdea(rec);
             MessageBox.Show("Idea "+ Ideaid +" Created");
             Ideas IdeaRec = Obj.IdeaDisplay(Ideaid);
                 
                

           
             IEnumerable<string> maillist=Obj.GetIdeaInfo().Where(x => x.ideaid == Ideaid).Select(x => x.Mailtoid);

             String Data = "Dear Approver," + Environment.NewLine 
                          + "Below idea submitted by " + Login.Name + " is awaiting your approvals."+Environment.NewLine
                           + "Please review and provide your feedback." + Environment.NewLine
                           + "Idea#       " + Ideaid + Environment.NewLine 
                           +" Idea Desc:  "+rec.Title;

             foreach (string temp in maillist)
            {
                Obj.SendMail(temp,Data);
            }


             this.Visibility = System.Windows.Visibility.Collapsed;
             MyIdea my = new MyIdea();
             my.ShowDialog();
        }

       


        public byte[] ReadFile(String spath)
        {
                        
            byte[] Data = null;
            FileInfo fInfo = new FileInfo(spath);
            long bytes = fInfo.Length;

            FileStream fs = new FileStream(spath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Data = br.ReadBytes((int)bytes);
            fs.Close();
            return Data;

        }

        public void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog Opd = new System.Windows.Forms.OpenFileDialog();
            Opd.Filter = "Text Files (.txt)|*.txt|Word Documents (.docx)|*.docx|Word Template (.dotx)|*.dotx|All Files (*.*)|*.*";
            Opd.ValidateNames = true;
            Opd.FilterIndex = 1;
            String Type;
            String FileName;
            byte[] Data;
            if (Opd.ShowDialog().ToString() == "OK")
            {
                TxtFilePath.Text = Opd.FileName;
                Type = System.IO.Path.GetExtension(Opd.FileName);
                Data =  ReadFile(TxtFilePath.Text);
                FileName = System.IO.Path.GetFileNameWithoutExtension(Opd.FileName);
               Documentid =  Obj.InsertDocument(FileName, Type, Data);
              
            }
        }

        private void IdeaCreationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LblWish.Content = "Welcome " + Login.Name;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
            MyIdea my = new MyIdea();
            my.ShowDialog();
        }
                  








                   
        }
    }

