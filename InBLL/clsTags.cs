using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBLL
{
    public class clsTags
    {


        DatabaseClass db = new DatabaseClass();

        public bool Deletetags(int TagId, int userNo)
        {
            string Sql = "delete from tags where TagId =" + TagId;
            return db.ExecuteNonQuery(Sql) > 0;
        }


        public System.Data.DataTable GettagsById(int TagId)
        {
            try
            {
                string Sql = "Select * from tags where TagId =  " + TagId;
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new System.Data.DataTable();
            }
        }

        public int Addtags(string TagName)
        {
            string Sql = String.Format("insert into tags (TagName) values ('{0}');SELECT @@IDENTITY AS 'Identity';", TagName);
            return db.ExecuteInsertWithIDReturn(Sql, "tags");
        }

        public bool Updatetags(string TagName,  int TagId, int p4)
        {
            string Sql = String.Format("update  tags set TagName = @TagName where  TagId = @TagId");
            SqlCommand cmd = new SqlCommand(Sql);
            cmd.Parameters.AddWithValue("@TagName", TagName);
            cmd.Parameters.AddWithValue("@TagId", TagId);
            return db.ExecuteNonQuery(cmd) > 0;
        }

        public System.Data.DataTable GetTags()
        {
            try
            {
                string Sql = "Select * from tags ";
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new System.Data.DataTable();
            }
        }



        public System.Data.DataTable GetTagsForReport()
        {
            try
            {
                string Sql = "Select * from vwTagsReport ";
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new System.Data.DataTable();
            }
        }
        public System.Data.DataTable GetTagsForReport(int TagId)
        {
            try
            {
                string Sql = "Select * from vwTagsReportGroup where TagId = " + TagId;
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new System.Data.DataTable();
            }
        }
    }
}
