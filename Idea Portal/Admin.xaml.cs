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
using System.Globalization;
using System.Text.RegularExpressions;

namespace Idea_Portal
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
        
    {
        public Admin()
        {
            InitializeComponent();
        }

        DataBaseManager obj= new DataBaseManager();
        Int32 UserId;
        
        bool invalid = false;

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
             users user = new users();
          
           user.Name = TxtUserName.Text;
           user.Password = PwPassWord.Password;
          
            if (((TxtUserName.Text).ToString()).Trim() == "")
           {
               MessageBox.Show("Enter UserName");
               return;
           }
           if (((PwPassWord.Password).ToString()).Trim() == "")
           {
               MessageBox.Show("Enter Password");
               return;
           }

            if (((TxtEmail.Text).ToString()).Trim() == "")
           {
               MessageBox.Show("Enter Email");
               return;
           }
            if (!IsValidEmail(TxtEmail.Text))
            {
                MessageBox.Show("Enter valid Email");
                return;
            }
            


           user.Role =TxtRole.Text;


           if (TxtRole.Text == "Admin")
           {
               user.Courseid = (int?)null;
           }
           else
           {
              if(CmbCourse.SelectedValue == null)
              {
             MessageBox.Show("Select Course Details");
               return;
              }
               user.Courseid = CmbCourse.SelectedValue != null ? (int)CmbCourse.SelectedValue : (int?)null; 
                  
           }
         
           
           user.Email = TxtEmail.Text;
           user.ValidFrom = TxtValidFrom.SelectedDate != null ? TxtValidFrom.SelectedDate.Value : (DateTime?)null;
          

           user.ValidTo = TxtValidTo.SelectedDate != null ? TxtValidTo.SelectedDate.Value : (DateTime?)null;


           if (TxtValidFrom.SelectedDate != null && TxtValidTo.SelectedDate != null)
            {
                if (DateTime.Compare(TxtValidFrom.SelectedDate.Value, TxtValidTo.SelectedDate.Value) > 0)
               {
                   MessageBox.Show("ValidTo Must be Greater than ValidFrom");
                   return;
               }
            }
           
            
            users CheckUser = obj.FindUser(TxtUserName.Text);


                
            if (CheckUser == null)
           {
               if(TxtRole.Text=="Student")
                {
                   if( !obj.CheckAproverList((Int32)user.Courseid))
                    {
                        MessageBox.Show("Approvers are not asigned for this course please contact your Admin");
                        return;
                    }
                  
                }
                obj.CreateUser(user);
              
               MessageBox.Show("User Created");
               
               TxtUserName.Text = "";
               PwPassWord.Password = "";
               TxtRole.Text = "Student";
               TxtEmail.Text = "";
               TxtValidFrom.Text = "";
               TxtValidTo.Text = "";
               CmbCourse.Text = "";
                CmbApr1.ItemsSource = obj.AproverList();
                CmbApr2.ItemsSource = obj.AproverList();
            }
           else
           {
               MessageBox.Show(TxtUserName.Text+" UserName already exists");
           }


            }

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper);
            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                   RegexOptions.IgnoreCase);
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            users user = new users();
            user = obj.FindUser(TxtSearchUser.Text);
            if (user != null)
            {
               
                UserId = user.Id;
                TxtUserName.Text = user.Name;
                PwPassWord.Password = user.Password;
                TxtRole.Text = user.Role;
                TxtEmail.Text = user.Email;
                IEnumerable<string> temp = obj.CourseLocationsList().Where(x => x.Id == user.Courseid).Select(x => x.CourseLocation);
                foreach (String rec in temp)
                {
                    CmbCourse.Text = rec;
                }
               
               TxtValidFrom.SelectedDate = user.ValidFrom;
                TxtValidTo.SelectedDate = user.ValidTo;
                BtnCreate.IsEnabled = false;
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            users user = new users();

            user.Id = UserId;
            user.Name = TxtUserName.Text;
            user.Password = PwPassWord.Password;
            user.Role = TxtRole.Text;
            user.Email = TxtEmail.Text;
            user.ValidFrom = TxtValidFrom.SelectedDate != null ? TxtValidFrom.SelectedDate.Value : (DateTime?)null;
            user.ValidTo = TxtValidTo.SelectedDate != null ? TxtValidTo.SelectedDate.Value : (DateTime?)null;
          
            
              if (((TxtUserName.Text).ToString()).Trim() == "")
           {
               MessageBox.Show("Enter UserName");
               return;
           }
           if (((PwPassWord.Password).ToString()).Trim() == "")
           {
               MessageBox.Show("Enter Password");
               return;
           }

            if (((TxtEmail.Text).ToString()).Trim() == "")
           {
               MessageBox.Show("Enter Email");
               return;
           }

           
           if (TxtRole.Text == "Admin")
           {
               user.Courseid = (int?)null;
           }
           else
           {
              if(CmbCourse.SelectedValue == null)
              {
             MessageBox.Show("Select Course Details");
               return;
              }
               user.Courseid = CmbCourse.SelectedValue != null ? (int)CmbCourse.SelectedValue : (int?)null; 
                  
           }
         
            
            users CheckUser = obj.FindUser(TxtUserName.Text);
                             
                obj.UpdateUser(user);
                MessageBox.Show("User Updated");

                TxtUserName.Text = "";
                PwPassWord.Password = "";
                TxtRole.Text = "";
                TxtEmail.Text = "";
                TxtValidFrom.Text = "";
                TxtValidTo.Text = "";
            CmbCourse.ItemsSource = obj.CourseLocationsList(); 
            BtnCreate.IsEnabled = true;
          }

        private void winAdmin_Loaded(object sender, RoutedEventArgs e)
        {
            CmbApr1.ItemsSource = obj.AproverList();
            CmbApr2.ItemsSource = obj.AproverList();
            CmbCourse.ItemsSource = obj.CourseLocationsList(); 
            CmbCourses.ItemsSource = obj.CourseLocationsList();
          


            //List<Aprover> AproverList = obj.AproverList();
            

        }

        //private void BtnDeptCreate_Click(object sender, RoutedEventArgs e)
        //{
        //    Courses course = new Courses();

        //    course.DeptName = cmbDeptName.Text;

        //    course.Location = CmbLocation.Text;
        //    if (CmbApr1.SelectedValue != null)
        //    {
        //        course.Aprover1 = (CmbApr1.SelectedValue).ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Select Approver");
        //        return;
        //    }

        //     if (CmbApr2.SelectedValue != null)
        //    {
        //    course.Aprover2 = (CmbApr2.SelectedValue).ToString();
        //    }
        //     else
        //     {
        //         MessageBox.Show("Select Approver");
        //         return;
        //     }
          

        //    Courses CheckUser = obj.FindCourse(cmbDeptName.Text, CmbLocation.Text);

        //    if (CheckUser == null)
        //    {
        //        obj.CreateCourse(course);
        //        MessageBox.Show("Course Created");
        //    }
        //    else
        //    {
        //        MessageBox.Show(TxtUserName.Text + " Course already exists in the Location");
        //    }
        //    CmbApr1.ItemsSource = obj.AproverList();
        //    CmbApr2.ItemsSource = obj.AproverList();
        //    CmbCourse.ItemsSource = obj.CourseLocationsList();
            
        //}

        private void BtnDeptUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (CmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Select Course Details");
                return;
            }
            if (CmbApr1.SelectedValue == null)
            {
                MessageBox.Show("Select Lower Aprover Details");
                return;
            }
            if (CmbApr2.SelectedValue == null)
            {
                MessageBox.Show("Select Higher Aprover Details");
                return;
            }
            obj.UpdateCourse(Convert.ToInt32(CmbCourses.SelectedValue), Convert.ToInt32(CmbApr1.SelectedValue), Convert.ToInt32(CmbApr2.SelectedValue));

            MessageBox.Show("Approvers Are Asigned");
            CmbApr1.Text = "";
            CmbApr2.Text = "";
            CmbCourses.Text = "";
            CmbCourses.ItemsSource = obj.CourseLocationsList();
            CmbCourses.ItemsSource = obj.CourseLocationsList();

            //Courses course = new Courses();

            //course.Id = CourseId;
            //course.DeptName = cmbDeptName.Text;
            //course.Location = CmbLocation.Text;
            //course.Aprover1 = CmbApr1.SelectedValue.ToString();
            //course.Aprover2 = CmbApr2.SelectedValue.ToString();
            //Courses CheckUser = obj.FindCourse(cmbDeptName.Text, CmbLocation.Text);

            //if (CheckUser == null)
            //{
            //    obj.UpdateCourse(course);
            //}
            //else
            //{
            //    MessageBox.Show(TxtUserName.Text + " Course already exists in the Location");
            //}
            //CmbApr1.ItemsSource = obj.AproverList();
            //CmbApr2.ItemsSource = obj.AproverList();
            //CmbCourse.ItemsSource = obj.CourseLocationsList();
        }

        private void BtnCourseSearch_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(CmbCourses.SelectedValue.ToString());
        }

        //private void CmbCourse_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    CmbCourse.ItemsSource = obj.CourseLocationsList();
        //}

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtUserName.Text = "";
            PwPassWord.Password = "";
            TxtRole.Text = "Student";
            TxtEmail.Text = "";
            TxtValidFrom.Text = "";
            TxtValidTo.Text = "";
            CmbCourse.ItemsSource = obj.CourseLocationsList();
            BtnCreate.IsEnabled = true;
        }

        private void TxtRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            string temp = TxtRole.SelectedValue.ToString();
            int index = temp.IndexOf(':');
            if (index > 0)
            {

                if (temp.Substring(index + 1).Trim() == "Admin")
                {
                    CmbCourse.Text = "";
                    CmbCourse.IsEnabled = false;

                }
                else
                {
                    CmbCourse.IsEnabled = true;
                }
            }
            
        }

        private void BtnFindapprovers_Click(object sender, RoutedEventArgs e)
        {
            if(CmbCourses.Text == "")
            {
            MessageBox.Show("Enter Course Details");
                return;
            }

            Courses course = new Courses();
                course = obj.FindCourse(Convert.ToInt32(CmbCourses.SelectedValue));
                if (course != null)
                {
                                     
                   
                    CmbApr1.Text = course.Aprover1.ToString();
                    CmbApr2.Text = course.Aprover2.ToString();


                }
                else
                {
                MessageBox.Show("No Approvers Asigned");

                }

            }
        }

        //private void TxtRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBox cmb = sender as ComboBox;
        //    string temp = TxtRole.SelectedValue.ToString();
        //    int index = temp.IndexOf(':');
        //    if (index >0)
        //    {
                
        //       if(temp.Substring(index+1).Trim()=="Admin")
        //       {
        //           CmbCourse.Text = "";
        //           CmbCourse.IsEnabled = false;
                  
        //       }
        //       else
        //       {
        //           CmbCourse.IsEnabled = true;
        //       }
        //    }
            
        //}

       


        




    
    }

