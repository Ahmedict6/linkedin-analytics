using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class clsUser
    {
        DatabaseClass db = new DatabaseClass();

        public byte[] LoadUserPhoto(int UserId)
        {
            try
            {
                if (UserId == 0)
                    return null;

                //DatabaseClass db = new DatabaseClass();
                string sql = string.Format("select Photo from [User] where UserId={0}", UserId);

                DataTable dt = db.ExecuteQuery(sql);

                if (dt.Rows.Count == 1)
                    return (Byte[])dt.Rows[0]["Photo"];
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Login(string Email, string Password)
        {
            try
            {

            

                SqlCommand cmd = new SqlCommand();
              cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = Email;
              //cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 100).Value = Email;
              cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = Password;
              cmd.CommandText = "SELECT * FROM [vwUsers] WHERE (Email=@Email or FirstName=@Email) AND Password=@Password";//and IsActive=1
              cmd.Connection = db.cn;
              return db.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int InsertUsers(string Firstname,string MiddleName,string LastName, string email, string PhoneNo, byte[] Photo, int UserTypeNo, string MartialStatus, string Location, bool IsMale, string BirthDate ,int UserNo)
        {
            if (db.cn.State != ConnectionState.Open)
            {
                db.cn.Open();
            }

            SqlTransaction trans = db.cn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.cn;
                cmd.Transaction = trans;
                int UserId = 0;
                if (Photo == null)
                    cmd.Parameters.AddWithValue("@Photo", null);
                else
                cmd.Parameters.AddWithValue("@Photo", Photo);

                string Password = MartialStatus;
                string sql = string.Format("Insert into [User](FirstName,Email,PhoneNo,Photo,UserTypeNo,IsActive,MartialStatus,Location,IsMale,Password,MiddleName,LastName) values ('{0}','{1}','{2}',@Photo,{3},'true','','{5}','{6}','{8}','{9}','{10}');SELECT @@IDENTITY AS 'Identity';", Firstname, email, PhoneNo, UserTypeNo, MartialStatus, Location, IsMale,"Null", Password, MiddleName, LastName);
                cmd.CommandText = sql;
                UserId = int.Parse(cmd.ExecuteScalar().ToString());
                string Operation = string.Format("Insert User : Name {0} Email {1} PhoneNo {2}", Firstname+ " " + MiddleName+ " "+LastName, email, PhoneNo);
                //string pageName = System.IO.Path.GetFileNameWithoutExtension(HttpContext.Current.Request.Url.AbsolutePath);
                bool IsLoged = DatabaseClass.Log(UserNo, Operation, trans, db.cn);
                if (UserId > 0 && IsLoged)
                {
                    trans.Commit();
                    db.cn.Close();
                    return UserId;
                }
                else
                {
                    trans.Rollback();
                    db.cn.Close();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                db.cn.Close();
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateUsers(string Firstname, string MiddleName, string LastName, string email, string PhoneNo, byte[] Photo, int UserTypeNo, string MartialStatus, string Location, bool IsMale, string BirthDate, int UserId, int UserNo)
        {
            if (db.cn.State != ConnectionState.Open)
            {
                db.cn.Open();
            }

            SqlTransaction trans = db.cn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.cn;
                cmd.Transaction = trans;
                int RowsCount = 0;
                cmd.Parameters.AddWithValue("@Photo", Photo);
                string Password = Firstname.Substring(0, 4) + PhoneNo.Substring(Math.Max(0, PhoneNo.Length - 4));
                string sql = string.Format("Update  [User] SET FirstName='{0}',Email='{1}',PhoneNo='{2}',Photo=@Photo,UserTypeNo='{3}',MartialStatus='',Location='{5}',IsMale='{6}',MiddleName='{9}',LastName='{10}',Password='{11}' where UserId={8}", Firstname, email, PhoneNo, UserTypeNo, MartialStatus, Location, IsMale, "", UserId, MiddleName, LastName, Password);
                cmd.CommandText = sql;
                RowsCount += int.Parse(cmd.ExecuteNonQuery().ToString());
                string Operation = string.Format("Update User : Name {0} Email {1} PhoneNo {2} Id {3}", Firstname+" "+MiddleName+" "+LastName, email, PhoneNo, UserId);
                //string pageName = System.IO.Path.GetFileNameWithoutExtension(HttpContext.Current.Request.Url.AbsolutePath);
                bool IsLoged = DatabaseClass.Log(UserNo, Operation, trans, db.cn);
                if (RowsCount > 0 && IsLoged)
                {
                    trans.Commit();
                    db.cn.Close();
                    return true;
                }
                else
                {
                    trans.Rollback();
                    db.cn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                db.cn.Close();
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateUsersWithoutPhoto(string FirstName, string MiddleName, string LastName, string email, string PhoneNo, int UserTypeNo, string MartialStatus, string Location, bool IsMale, string BirthDate, int UserId, int UserNo)
        {
            if (db.cn.State != ConnectionState.Open)
            {
                db.cn.Open();
            }

            SqlTransaction trans = db.cn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.cn;
                cmd.Transaction = trans;
                int RowsCount = 0;
                string Password = MartialStatus;
                string sql = string.Format("Update  [User] SET Email='{1}',PhoneNo='{2}',UserTypeNo='{3}', MartialStatus='',Location='{5}',IsMale='{6}', MiddleName='{9}',LastName='{10}',Password='{11}' where UserId={8}", FirstName, email, PhoneNo, UserTypeNo, MartialStatus, Location, IsMale, "Null", UserId, MiddleName, LastName, Password);
                cmd.CommandText = sql;
                RowsCount += int.Parse(cmd.ExecuteNonQuery().ToString());
                string Operation = string.Format("Update User : Name {0} Email {1} PhoneNo {2} Id {3}", FirstName, email, PhoneNo, UserId);
                //string pageName = System.IO.Path.GetFileNameWithoutExtension(HttpContext.Current.Request.Url.AbsolutePath);
                bool IsLoged = DatabaseClass.Log(UserNo, Operation, trans, db.cn);
                if (RowsCount > 0 && IsLoged)
                {
                    trans.Commit();
                    db.cn.Close();
                    return true;
                }
                else
                {
                    trans.Rollback();
                    db.cn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                db.cn.Close();
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateUserStatus(bool IsActive, int UserId, int UserNo)
        {
            if (db.cn.State != ConnectionState.Open)
            {
                db.cn.Open();
            }

            SqlTransaction trans = db.cn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.cn;
                cmd.Transaction = trans;
                int RowsCount = 0;

                string sql = string.Format("Update  [User] SET IsActive='{0}' where UserId={1}", IsActive, UserId);
                cmd.CommandText = sql;
                RowsCount += int.Parse(cmd.ExecuteNonQuery().ToString());
                string Operation = string.Format("Update User Status : IsActive {0}  Id {1}", IsActive, UserId);
                //string pageName = System.IO.Path.GetFileNameWithoutExtension(HttpContext.Current.Request.Url.AbsolutePath);
                bool IsLoged = DatabaseClass.Log(UserNo, Operation, trans, db.cn);
                if (RowsCount > 0 && IsLoged)
                {
                    trans.Commit();
                    db.cn.Close();
                    return true;
                }
                else
                {
                    trans.Rollback();
                    db.cn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                db.cn.Close();
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteUser(int UserId, int UserNo)
        {
            if (db.cn.State != ConnectionState.Open)
            {
                db.cn.Open();
            }

            SqlTransaction trans = db.cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.cn;
                cmd.Transaction = trans;
                int RowsCount = 0;
                string sql = string.Format("Delete from [User] where UserId={0}", UserId);
                cmd.CommandText = sql;
                RowsCount += int.Parse(cmd.ExecuteNonQuery().ToString());
                string Operation = string.Format("Delete User : Id {0}", UserId);
                //string pageName = System.IO.Path.GetFileNameWithoutExtension(HttpContext.Current.Request.Url.AbsolutePath);
                bool IsLoged = DatabaseClass.Log(UserNo, Operation, trans, db.cn);
                if (RowsCount > 0 && IsLoged)
                {

                    trans.Commit();
                    db.cn.Close();
                    return true;
                }
                else
                {
                    trans.Rollback();
                    db.cn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {

                trans.Rollback();
                db.cn.Close();
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetActiveUsers()
        {
            try
            {
                string sql = "Select * from [User] where IsActive='True'";
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAllUsers()
        {
            try
            {
                string sql = "Select * from vwUsers order by IsActive desc";
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public DataTable GetLoginLog()
        {
            try
            {
                string sql = "Select * from LoginLog order by Time desc";
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable GetUserTypes()
        {
            try
            {
                string sql = "Select * from UserType";
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable GetUsersbyId(int UserId)
        {
            try
            {
                string sql = string.Format("select * from vwUsers where UserId={0}", UserId);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public void AddLoginLog(string UserName , bool IsSuccessful)
        {
            try
            {
                string sql = string.Format("Insert into [LoginLog] (UserName,IpAddress,IsSuccessful) values ('{0}','{1}','{2}')" , UserName,GetIPAddress(),IsSuccessful.ToString());
                 db.ExecuteNonQuery(sql);
            }
            catch (Exception e)
            {
              
            }
        }
    }
}
