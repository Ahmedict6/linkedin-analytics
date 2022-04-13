using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBLL
{
    public class clsGroups
    {


        DatabaseClass db = new DatabaseClass();

        public bool DeleteGroups(int GroupId, int userNo)
        {
            string Sql = "delete from Groups where GroupId =" + GroupId;
            return db.ExecuteNonQuery(Sql) > 0;
        }


        public System.Data.DataTable GetGroupsById(int GroupId)
        {
            try
            {
                string Sql = "Select * from Groups where GroupId =  " + GroupId;
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new System.Data.DataTable();
            }
        }

        public int AddGroups(string GroupName, string GroupUrl)
        {
            string Sql = String.Format("insert into Groups (GroupName,GroupUrl) values ('{0}','{1}');SELECT @@IDENTITY AS 'Identity';", GroupName, GroupUrl);
            return db.ExecuteInsertWithIDReturn(Sql, "Groups");
        }

        public bool UpdateGroups(string GroupName, string GroupUrl, int GroupId, int p4)
        {
            string Sql = String.Format("update  Groups set GroupName = @GroupName, GroupUrl  =  @GroupUrl where  GroupId = @GroupId");
            SqlCommand cmd = new SqlCommand(Sql);
            cmd.Parameters.AddWithValue("@GroupName", GroupName);
            cmd.Parameters.AddWithValue("@GroupUrl", GroupUrl);
            cmd.Parameters.AddWithValue("@GroupId", GroupId);
            return db.ExecuteNonQuery(cmd) > 0;
        }

        public System.Data.DataTable GetGrops()
        {
            try
            {
                string Sql = "Select * from Groups ";
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new System.Data.DataTable();
            }
        }
    }
}
