using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Collections;
using System.IO;
using System.Net.Mail;

namespace Idea_Portal
{

    public class Login
    {
        public static int id;
        public static String role;
        public static String Name;
        public static String Courseid;
        public static String CourseName;
        public static String Link;
    }


 public class users
  {
      public int Id { set; get; }
      public String Name {set;get;}
      public String Password{set;get;}
      public String Role {set;get;}
      public Nullable<int> Courseid { set; get; }
      public String Email { set; get; }
      public Nullable<DateTime> ValidFrom { set; get; }
      public Nullable<DateTime> ValidTo { set; get; }
  }

 public class IdeaInfo
 {
     public int ideaid { set; get; }
     public string Title { set; get; }
     public String studentName { set; get; }
     public String CourseName { set; get; }
     public String status { set; get; }
     public String pendingwith { set; get; }
     public string mailid { set; get; }
 }



 public class Courses
 {
     public int Id { set; get; }
     public String DeptName { set; get; }
     public String Location { set; get; }
     public String Aprover1 { set; get; }
     public String Aprover2 { set; get; }
    
 }
    
 public class Aprover
 {
     public int Id { set; get; }
     public String DeptName { set; get; }
 }

 public class CourseLocations
 {
     public int Id { set; get; }
     public String CourseLocation { set; get; }
 }
 public class Ideas
 {
     public int IdeaId{set;get;}
     public int userid { set; get; }
     public int courseid { set; get; }
     public String Title { set; get; }
     public String Description { set; get; }
     public String category { set; get; }
     public String currentprocess { set; get; }
     public String Proposedsolution { set; get; }
     public String otherInformation { set; get; }
     public String Benfits  { set; get; }
     public String comment1 { set; get; }
     public String comment2 { set; get; }
     public DateTime createdon { set; get; }
     public String status { set; get; }
     public int documentid { set; get; }
 }

 public class IdeaRecords
 {
   
   public int ideaid{set;get;}
     public String Title{set;get;}
     public String Name{set;get;}
     public String Course{set;get;}

     public String CreatedOn{set;get;}
     public String Status{set;get;}
     public String PendingWith{set;get;}

     public String Mailtoid{set;get;}
     public String Role { set; get; }
    
     
 }
    
           
           

     class DataBaseManager
    {
       public String connectionString = ConfigurationManager.ConnectionStrings["PortalCS"].ConnectionString;
    //   public SqlConnection conn = new SqlConnection("Data Source=MITHUN-HP;Initial Catalog=IdeaPortal;Integrated Security=True");

        public int LoginCheck(String pName, String pPassword)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            String str = "select users.id Id,Name,Role,Courseid,course.DeptName CourseName from users left outer join course  on  users.Courseid = course.id where Name = '" + pName + "' and Password ='" + pPassword + "' and ISNULL(validto,GETDATE()+1) > GETDATE()";
            
          //  String str = "select Id,Role,Courseid from users where Name = '" + pName + "' and Password ='" + pPassword + "'";
          
            SqlCommand cmd = new SqlCommand(str,conn);
           int localid=0;
            try
            {
                conn.Open();
                   
                SqlDataReader rd = cmd.ExecuteReader();
              if (rd.HasRows)
             
              {

                  rd.Read();
                 
                       
                         localid = (Int32)rd["Id"];
                         Login.id = localid;
                         Login.Name = rd["Name"].ToString();
                         Login.role = rd["Role"].ToString();
                 
                         if (Login.role == "Admin")
                         {
                             Login.Courseid = null;
                         }
                         else
                         {
                             Login.Courseid = rd["Courseid"].ToString();
                              Login.CourseName =rd["CourseName"].ToString();
                         }

                  conn.Close();
                  return localid;
                        
              }
                    else
                    {
                        conn.Close();
                        MessageBox.Show("Check Your UserName And Password");
                        return localid;
                   }

                }
            
            catch (Exception Ex)
            {
                MessageBox.Show("Error Occured:" + Ex.Message);
                return localid;
            }         
        }

        public users FindUser(String pUserName)
        {
            users Rec = new users();
            SqlConnection conn = new SqlConnection(connectionString);
            String str = "select Id,Name,PassWord,Role,Courseid,Email,ValidFRom,ValidTo From Users where Name ='" + pUserName + "'";
           
            SqlCommand cmd = new SqlCommand(str, conn);
           
            try
            {
                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    Rec.Id = (Int32)rd["Id"];
                    Rec.Name=(String)rd["Name"];
                    Rec.Password = (String)rd["PassWord"];
                    Rec.Role = (String)rd["Role"];
                    Rec.Email = (String)rd["Email"];
                   
                    if(rd.IsDBNull(4))
                    {
                        Rec.Courseid = (int?)null;
                    }
                    else
                    {
                        Rec.Courseid = (Int32)rd["Courseid"];
                    }
                    //Rec.Courseid = (rd["Courseid"] == null) ? (int?)null : (Int32)rd["Courseid"];
                    
                    Rec.ValidFrom =  rd.IsDBNull(6) == true ? (DateTime?)null : (DateTime)rd[6];

                    Rec.ValidTo = rd.IsDBNull(7) == true ? (DateTime?)null : (DateTime)rd[7];
                }
                else
                {
                    Rec = null;
                   
                }


                return Rec;
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error Occured:" + Ex.Message);
                return Rec;
            }

        }


          public void CreateUser(users user)
        {
            users Rec = new users();
            SqlConnection conn = new SqlConnection(connectionString);
             
           // String str = "Insert Into Users(Name,PassWord,Role,ValidFRom,ValidTo) values('"+user.Name+"','"+user.Password+"','"+user.Role+"','"+user.ValidFrom.Date +"','"+user.ValidTo.Date+ "')";
            String str = "Insert Into Users(Name,PassWord,Role,Courseid,Email,validFrom,ValidTo) values(@UserName,@Password,@Role,@Courseid,@Email,@ValidFrom,@ValidTo)";
          
            SqlCommand cmd = new SqlCommand(str, conn);
           // MessageBox.Show(user.ValidFrom.Date.ToString());
            cmd.Parameters.Add(new SqlParameter("@UserName", (object)user.Name));
            cmd.Parameters.Add(new SqlParameter("@Password", (object)user.Password));
            cmd.Parameters.Add(new SqlParameter("@Role", (object)user.Role));
            cmd.Parameters.Add(new SqlParameter("@Courseid", user.Courseid == null ? (Object)DBNull.Value : (object)user.Courseid));
            cmd.Parameters.Add(new SqlParameter("@Email", (object)user.Email));
            cmd.Parameters.Add(new SqlParameter("@ValidFrom", user.ValidFrom == null ? (Object)DBNull.Value : user.ValidFrom));
            cmd.Parameters.Add(new SqlParameter("@ValidTo", user.ValidTo == null ? (Object)DBNull.Value : user.ValidTo));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
   
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error Occured:" + Ex.Message);
                return;
            }

        }


          public void UpdateUser(users user)
          {

              
              SqlConnection conn = new SqlConnection(connectionString);
              String str = "Update users set Name=@UserName,Password=@Password,Role=@Role,Courseid=@Courseid,Email=@Email,ValidFrom=@ValidFrom,ValidTo=@ValidTo where ID=" + user.Id;
              SqlCommand cmd = new SqlCommand(str, conn);
              cmd.Parameters.Add(new SqlParameter("@UserName", (object)user.Name));
              cmd.Parameters.Add(new SqlParameter("@Password", (object)user.Password));
              cmd.Parameters.Add(new SqlParameter("@Role", (object)user.Role));
              cmd.Parameters.Add(new SqlParameter("@Courseid", user.Courseid ==null ? (Object)DBNull.Value: (object)user.Courseid));
              cmd.Parameters.Add(new SqlParameter("@Email", (object)user.Email));
              cmd.Parameters.Add(new SqlParameter("@ValidFrom", user.ValidFrom == null ? (Object)DBNull.Value : (object)user.ValidFrom));
              cmd.Parameters.Add(new SqlParameter("@ValidTo", user.ValidTo == null ? (Object)DBNull.Value : (object)user.ValidTo));
            try
            {
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error Occured:" + Ex.Message);
                return;
            }
          }
        

          public List<Aprover> AproverList()
          {
              SqlConnection conn = new SqlConnection(connectionString);
              String str = "select Id,name from users where role='Aprover'";
              SqlCommand cmd = new SqlCommand(str, conn);
              List<Aprover> AproverList = new List<Aprover>();
              try
              {
                  conn.Open();

                  SqlDataReader rd = cmd.ExecuteReader();
                  while (rd.Read())
                  {
                      Aprover rec = new Aprover();
                      rec.Id = ((Int32)rd["Id"]);
                      rec.DeptName = rd["name"].ToString();
                      AproverList.Add(rec);
                  }
                  return AproverList;

              }

              catch (Exception Ex)
              {
                  MessageBox.Show("Error Occured:" + Ex.Message);
                  return null;
              }         
          }


          public List<CourseLocations> CourseLocationsList()
          {
              SqlConnection conn = new SqlConnection(connectionString);
              String str = "select id,deptname+'" + "'+Location CourseLocations from course";
              SqlCommand cmd = new SqlCommand(str, conn);
              List<CourseLocations> CourseLocationsList = new List<CourseLocations>();
              try
              {
                  conn.Open();

                  SqlDataReader rd = cmd.ExecuteReader();
                  while (rd.Read())
                  {
                      CourseLocations rec = new CourseLocations();
                      rec.Id = ((Int32)rd["id"]);
                      rec.CourseLocation = rd["CourseLocations"].ToString();
                      CourseLocationsList.Add(rec);
                  }
                  return CourseLocationsList;

              }

              catch (Exception Ex)
              {
                  MessageBox.Show("Error Occured:" + Ex.Message);
                  return null;
              }
          }


          public bool CheckAproverList(int Couserid)
          {
              SqlConnection conn = new SqlConnection(connectionString);
              String str = "select count(*) from course where Approver1 is not null and approver2 is not null and id =" + Couserid;
              SqlCommand cmd = new SqlCommand(str, conn);
              
              try
              {
                  conn.Open();

                int count = (Int32)cmd.ExecuteScalar();

                if (count > 0)
                {
                    return true;
                }  
                else
                {
                    return false;
                }
              }

              catch (Exception Ex)
              {
                  MessageBox.Show("Error Occured:" + Ex.Message);
                  return false;
              }
          }


          public void CreateCourse(Courses course)
          {

              users Rec = new users();
              SqlConnection conn = new SqlConnection(connectionString);
              String str = "Insert Into course(DeptName,Location,Approver1,Approver2) values(@DeptName,@Location,@Approver1,@Approver2)";
              SqlCommand cmd = new SqlCommand(str, conn);             
              cmd.Parameters.Add(new SqlParameter("@DeptName", (object)course.DeptName));
              cmd.Parameters.Add(new SqlParameter("@Location", (object)course.Location));
              cmd.Parameters.Add(new SqlParameter("@Approver1", (object)course.Aprover1));
              cmd.Parameters.Add(new SqlParameter("@Approver2", (object)course.Aprover2));             

              try
              {
                  conn.Open();
                  cmd.ExecuteNonQuery();
                  conn.Close();

              }

              catch (Exception Ex)
              {
                  MessageBox.Show("Error Occured:" + Ex.Message);
                  return;
              }
          }


          public Courses FindCourse(int CourseId)
          {
              Courses course = new Courses();
              SqlConnection conn = new SqlConnection(connectionString);
              String str = "select course.Id Id,DeptName,Location,app1.Name Approver1,app2.Name Approver2 from course join Users app1 on course.Approver1 = app1.id Join Users app2 on course.Approver2 = app2.id where course.id=" + CourseId;

              SqlCommand cmd = new SqlCommand(str, conn);
             
              try
              {
                  conn.Open();

                  SqlDataReader rd = cmd.ExecuteReader();
                  rd.Read();
                  if (rd.HasRows)
                  {
                      course.Id = (Int32)rd["Id"];
                      course.DeptName = (String)rd["DeptName"];
                      course.Location = (String)rd["Location"];
                      course.Aprover1 = (String)rd["Approver1"];
                      course.Aprover2 = (String)rd["Approver2"];
                  }

                  else
                  {
                      course = null;
                      
                  }


                  return course;
              }

              catch (Exception Ex)
              {
                  MessageBox.Show("Error Occured:" + Ex.Message);
                  return null;
              }
          }

        public void UpdateCourse(int courseId,int aprover1id,int aprover2id)

        {
            SqlConnection conn = new SqlConnection(connectionString); 
            String str = "Update course set Approver1=@Approver1,Approver2=@Approver2 where ID=" + courseId;                      
            SqlCommand cmd = new SqlCommand(str, conn);                   
            cmd.Parameters.Add(new SqlParameter("@Approver1", (object)aprover1id));
            cmd.Parameters.Add(new SqlParameter("@Approver2", (object)aprover2id));          
            try
              {
                  conn.Open();
                 int i = cmd.ExecuteNonQuery();
                  conn.Close();
              }
              catch (Exception Ex)
              {
                  MessageBox.Show("Error Occured:" + Ex.Message);
                  return;
              }
        }

        public int CreateIdea(Ideas Idea)
        {
            users Rec = new users();
            SqlConnection conn = new SqlConnection(connectionString);
            int Ideaid;
            String str = "Insert Into Idea(userid,courseid,Title,Description,category,currentprocess,Proposedsolution,Benfits,otherInformation,createdon,status,documentid) values(@userid,@courseId,@Title,@Description,@category,@currentprocess,@Proposedsolution,@Benfits,@otherInformation,@createdon,@status,@documentid);SELECT CAST(scope_identity() AS int)";
            SqlCommand cmd = new SqlCommand(str, conn);       
            cmd.Parameters.Add(new SqlParameter("@userid",(object)Login.id));
            cmd.Parameters.Add(new SqlParameter("@courseId", Login.Courseid == null ? (Object)DBNull.Value : Login.Courseid));
            cmd.Parameters.Add(new SqlParameter("@Title", (object)Idea.Title));
            cmd.Parameters.Add(new SqlParameter("@Description", (object)Idea.Description));
            cmd.Parameters.Add(new SqlParameter("@category", (object)Idea.category));
            cmd.Parameters.Add(new SqlParameter("@currentprocess", (object)Idea.currentprocess));
            cmd.Parameters.Add(new SqlParameter("@Proposedsolution", (object)Idea.Proposedsolution));
            cmd.Parameters.Add(new SqlParameter("@Benfits", (object)Idea.Benfits));
            cmd.Parameters.Add(new SqlParameter("@otherInformation", (object)Idea.otherInformation));
            cmd.Parameters.Add(new SqlParameter("@createdon",(object)Idea.createdon));
            cmd.Parameters.Add(new SqlParameter("@status", (object)Idea.status));
            cmd.Parameters.Add(new SqlParameter("@documentid", (object)Idea.documentid));

            try
            {
                conn.Open();
                Ideaid = (int)cmd.ExecuteScalar();
                conn.Close();
                return Ideaid;
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error Occured:" + Ex.Message);
                return 0;
            }

        }

           public String GetFileType(int pid)
          {
              SqlConnection conn = new SqlConnection(connectionString);
              String str = "select content_type from documents where id ="+ pid;
              String content_type="";

               SqlCommand cmd = new SqlCommand(str, conn);
             
              try
              {
                  conn.Open();

                  SqlDataReader rd = cmd.ExecuteReader();
                  if (rd.Read())
                  {
                      CourseLocations rec = new CourseLocations();
                      content_type = rd["content_type"].ToString();
                     
                  }
                 return content_type;

              }

              catch (Exception Ex)
              {
                  MessageBox.Show("Error Occured:" + Ex.Message);
                  return null;
              }
          }



        public int InsertDocument(String pfilename,String pfiletype,byte[] pData)
        {
            users Rec = new users();
            SqlConnection conn = new SqlConnection(connectionString);
            int Documentid = 0;           
            // String str = "Insert Into Users(Name,PassWord,Role,ValidFRom,ValidTo) values('"+user.Name+"','"+user.Password+"','"+user.Role+"','"+user.ValidFrom.Date +"','"+user.ValidTo.Date+ "')";
            String str = "Insert Into documents(content_type,Filename,Data) values(@filetype,@filename,@Data);SELECT CAST(scope_identity() AS int)";        
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(new SqlParameter("@filetype", (object)pfiletype));
            cmd.Parameters.Add(new SqlParameter("@filename", (object)pfilename));
            cmd.Parameters.Add(new SqlParameter("@Data", (object)pData));                     
            // MessageBox.Show(user.ValidFrom.Date.ToString());
            try
            {
                conn.Open();
                Documentid = (int)cmd.ExecuteScalar();
                conn.Close();
                return Documentid;
            }               
             catch (Exception Ex)
            {
                MessageBox.Show("Error Occured:" + Ex.Message);
                return 0;
            }
        }
        public Ideas IdeaDisplay(int pideaid)
        {           
            SqlConnection conn = new SqlConnection(connectionString);           
            // String str = "Insert Into Users(Name,PassWord,Role,ValidFRom,ValidTo) values('"+user.Name+"','"+user.Password+"','"+user.Role+"','"+user.ValidFrom.Date +"','"+user.ValidTo.Date+ "')";
            String str = "select ideaid,userid,courseid,title,description,category,currentprocess,Proposedsolution,Benfits,otherInformation,Documentid,comment1,comment2,createdon,status from Idea where ideaid=" + pideaid;
            SqlCommand cmd = new SqlCommand(str, conn);
            // MessageBox.Show(user.ValidFrom.Date.ToString());            
            Ideas rec=new Ideas();
            try
            { 
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                 rd.Read();
                  if (rd.HasRows)
                  {                                   
                      // Ideas rec=new Ideas();
                      rec.IdeaId=(int)rd["ideaid"];
                      rec.userid=(int)rd["userid"];
                      rec.courseid=(int)rd["courseId"];
                       rec.Title=rd["title"].ToString();
                       rec.Description=rd["description"].ToString();
                       rec.category=rd["category"].ToString();
                       rec.currentprocess=rd["currentprocess"].ToString();
                       rec.Proposedsolution=rd["Proposedsolution"].ToString();
                       rec.Benfits=rd["Benfits"].ToString();
                       rec.otherInformation=rd["otherInformation"].ToString();
                       rec.createdon=(DateTime)rd["createdon"];         
                        rec.status=rd["status"].ToString(); 
                        rec.comment1=rd["comment1"].ToString();
                        rec.comment2=rd["comment2"].ToString();
                        rec.documentid = (int)rd["Documentid"];
                        conn.Close();                 
                    
            }
                  return rec;
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error Occured:" + Ex.Message);
                return null;
            }

        }

        public List<IdeaRecords> GetIdeaInfo()
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;
            
            SqlConnection conn = new SqlConnection(connectionString);

            // String str = "Insert Into Users(Name,PassWord,Role,ValidFRom,ValidTo) values('"+user.Name+"','"+user.Password+"','"+user.Role+"','"+user.ValidFrom.Date +"','"+user.ValidTo.Date+ "')";
            String str = "select ideaid,Title,users.Name,course.DeptName Course,CreatedOn ,idea.status Status,CASE When idea.status='Submited' Then apr1.Name When Idea.status='level1' then apr2.Name when Idea.status='level2' then 'ImplementationPhase' End as Pendngwith " +
                          ",CASE When idea.status='Submited' Then apr1.Email When Idea.status='level1' then apr2.Email when Idea.status='level2' then null End as Mailtoid "+
                          "from idea Join Users On idea.userid = users.Id Join course On course.Id = idea.courseid Join Users Apr1 On apr1.Id = course.Approver1 Join Users Apr2 on apr2.Id = course.Approver2";
            
            SqlCommand cmd = new SqlCommand(str, conn);
            List<IdeaRecords> IdeaRecordsCollect = new List<IdeaRecords>();
           
           
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
               
                while (dr.Read())
                {
                    IdeaRecords rec = new IdeaRecords();
                    rec.ideaid = (int)dr["ideaid"];
                    rec.Course = dr["Course"].ToString();
                    rec.CreatedOn = dr["CreatedOn"].ToString();
                    rec.Mailtoid = dr["Mailtoid"].ToString();
                    rec.Name = dr["Name"].ToString();
                    rec.PendingWith = dr["PendngWith"].ToString();
                    rec.Status = dr["Status"].ToString();
                    rec.Title = dr["Title"].ToString();
                    rec.Role = Login.role;
                    IdeaRecordsCollect.Add(rec);
                }

                conn.Close();
                return IdeaRecordsCollect;
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error Occured:" + Ex.Message);
                return null;
            }

        }

        public void updatesatus(int pideaid,String pComments,String pstatus,int i)
        {
            users Rec = new users();
            SqlConnection conn = new SqlConnection(connectionString);            
            // String str = "Insert Into Users(Name,PassWord,Role,ValidFRom,ValidTo) values('"+user.Name+"','"+user.Password+"','"+user.Role+"','"+user.ValidFrom.Date +"','"+user.ValidTo.Date+ "')";
            String str = null;                    
            if (i == 1)
            {
                 str = "update Idea set status=@status,comment1=@comment where ideaid =" + pideaid;                
            }
            if (i == 2)
            {
                 str = "update Idea set status=@status,comment2=@comment where ideaid =" + pideaid;               
            }
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(new SqlParameter("@status", (object)pstatus));
            cmd.Parameters.Add(new SqlParameter("@comment", (object)pComments));            
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error Occured:" + Ex.Message);
                return;
            }

        }


       public void WriteFile(string path,String Type,int id)
        {           
           string fileName = path+Type;          
            SqlConnection conn = new SqlConnection(connectionString);          
            // String str = "Insert Into Users(Name,PassWord,Role,ValidFRom,ValidTo) values('"+user.Name+"','"+user.Password+"','"+user.Role+"','"+user.ValidFrom.Date +"','"+user.ValidTo.Date+ "')";
            String str = "select data from documents where id = @id";
            SqlCommand cmd = new SqlCommand(str, conn);
            conn.Open();
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                      while (dr.Read())
                        {
                            int size = 1024 * 1024;
                            byte[] buffer = new byte[size];
                            int readBytes = 0;
                            int index = 0;
                          using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                while ((readBytes = (int)dr.GetBytes(0, index, buffer, 0, size)) > 0)
                                {
                                    fs.Write(buffer, 0, readBytes);
                                    index += readBytes;
                                }
                            }
                       
                      }
                       
                        }                       
                  

        }


       public void SendMail(String ToMailId, String Data)
       {
           try
           {
               MailMessage mail = new MailMessage();
               SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

               mail.From = new MailAddress("Ideaportal.vision@gmail.com");
               mail.To.Add(ToMailId);
               mail.Subject ="Idea - Pending your Approval";
               mail.IsBodyHtml = false;
               mail.Body = Data + "is Waiting for your aproval can u please review";
               // mail.Attachments.Add(new Attachment(Imgloc));

               SmtpServer.Port = 587;
               SmtpServer.Credentials = new System.Net.NetworkCredential("Ideaportal.vision@gmail.com", "ATCHamilton");
               SmtpServer.EnableSsl = true;

               SmtpServer.Send(mail);
               // System.Windows.Forms.MessageBox.Show("mail Send");
           }
           catch (Exception ex)
           {
               System.Windows.Forms.MessageBox.Show(ex.ToString());
           }
       }

      
    }
}
