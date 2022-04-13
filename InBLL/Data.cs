using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
namespace InBLL
{
    public class Data
    {
        DatabaseClass db = new DatabaseClass();

        public DataTable GetGrops()
        {
            try
            {
                string Sql = "Select * from Groups ";
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        public DataTable GetusersProfiles()
        {
            try
            {
                string Sql = "Select top(150) profileId , AccountLink from Profiles where ProfileCheck = 0 ";
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public DataTable GetGropsbyId(string GroupId)
        {
            try
            {
                string Sql = "Select * from Groups where GroupId =  " + GroupId;
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public DataTable GetTags()
        {
            try
            {
                string Sql = "Select * from tags";
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public void AddUser(string userName, string Description, string Location, string Url, string imageUrl, int GroupNo)
        {
            string Sql = String.Format("insert into [Profiles] ([UserName],[Description],[Location],[AccountLink],[ImageUrl],[GroupNo]) values (@UserName,@Description,@Location,@AccountLink,@ImageUrl,{0})", GroupNo);
            SqlCommand cmd = new SqlCommand(Sql);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Location", Location);
            cmd.Parameters.AddWithValue("@AccountLink", Url);
            cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);


            db.ExecuteNonQuery(cmd);
        }

        public void AddPost(string userurl, string postText, int GroupNo)
        {
            try
            {

                string Sql = "select * from GroupsPosts where GroupsPostText = @GroupsPostText and  GroupNo = " + GroupNo;
                SqlCommand cmd = new SqlCommand(Sql);
                cmd.Parameters.AddWithValue("@GroupsPostText", postText);
                DataTable dt = db.ExecuteQuery(cmd);


                Sql = "Select profileId from Profiles where AccountLink like '" + userurl + "%'";
                int profileId = int.Parse(db.ExecuteScalar(Sql).ToString());


                if (dt.Rows.Count > 0)
                {

                    if (dt.Select("profileId = " + profileId + " and  GroupNo = " + GroupNo).Count() > 0)
                        return;
                }


                Sql = String.Format("insert into [GroupsPosts] ([GroupsPostText],[profileId],[GroupNo],AccountLink) values (@postText,{1},{2},@AccountLink)",
                postText, profileId, GroupNo, userurl);
                cmd = new SqlCommand(Sql);
                cmd.Parameters.AddWithValue("@postText", postText);
                cmd.Parameters.AddWithValue("@AccountLink", userurl);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

            }
        }


        public void PostClassification()
        {
            try
            {
                DataTable dtTags = GetTags();
                String Sql = "Delete TagsGroupsPosts;DBCC CHECKIDENT ('TagsGroupsPosts', RESEED, 1)  ";
                db.ExecuteNonQuery(Sql);

                foreach (DataRow dr in dtTags.Rows)
                {
                    Sql = String.Format("insert into [dbo].[TagsGroupsPosts]  SELECT   GroupsPostId as GroupsPostNo  , {0} as TagNo  FROM [GroupsPosts] where GroupsPostText like '% {1} %'", dr["TagId"].ToString(), dr["TagName"].ToString());
                    db.ExecuteNonQuery(Sql);

                }
            }
            catch (Exception)
            {

            }
        }

        public DataTable GetMostPostingUsers()
        {
            try
            {
                string Sql = "Select * from vwPostbyUsers order by [PostsCounter] Desc ";
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public DataTable GetMostPostingUsers(int GroupId)
        {
            try
            {
                string Sql = String.Format("Select * from vwPostbyUsers where GroupId = {0} order by [PostsCounter] DESC ", GroupId);
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public DataTable GetGropTags(int GroupId)
        {
            try
            {
                string Sql = String.Format("select [TagId],[TagName] FROM [vwGroupsPosts]  where GroupNo = {0} group by [TagId],[TagName] ", GroupId);
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public DataTable getpsotsbyGropNoAndTagNo(int GroupId, int TagId)
        {
            try
            {
                string Sql = String.Format("select * FROM [vwGroupsPosts] where GroupNo = {0} and TagId ={1}    ", GroupId, TagId);
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }


        public DataTable getpsotsbyGropNo(int GroupId)
        {
            try
            {
                string Sql = String.Format("select * FROM [vwAllGroupsPosts] where GroupNo = {0} ", GroupId);
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }


        public String GetallPostCount()
        {

            try
            {
                string Sql = "select count(GroupsPostId) FROM GroupsPosts";
                return db.ExecuteScalar(Sql).ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public string GetTodayPostCount()
        {
            try
            {
                string Sql = "SELECT   count(GroupsPostId)  FROM vwGroupsPosts  WHERE      insetedDate >= CAST(GETDATE() AS DATE)";
                return db.ExecuteScalar(Sql).ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }
        public DataTable GetTodayPosts()
        {
            try
            {
                string Sql = "SELECT  *   FROM vwGroupsPosts  WHERE insetedDate >= CAST(GETDATE() AS DATE)";
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        public string GetProfileCount()
        {
            try
            {
                string Sql = "SELECT   count(profileId)  FROM Profiles  ";
                return db.ExecuteScalar(Sql).ToString();
            }
            catch (Exception)
            {
                return "0";
            }

        }

        public string GetTagsCount()
        {
            try
            {
                string Sql = "SELECT   count(TagId)  FROM tags  ";
                return db.ExecuteScalar(Sql).ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public DataTable GetGropsPostCounter()
        {

            try
            {
                string Sql = String.Format("SELECT GroupName , count([GroupNo]) as count FROM vwGroupsPosts group by GroupName");
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public DataTable GetUserMotePostingCounter()
        {
            try
            {
                string Sql = String.Format("  SELECT top 25 UserName , PostsCounter as count FROM [vwPostbyUsers]  Order by PostsCounter desc ");
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public DataTable GetAllUsers()
        {
            try
            {
                string Sql = String.Format("  SELECT  *  FROM [Profiles]  ");
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public DataTable GetAllUsers(int count)
        {
            try
            {
                string Sql = String.Format("WITH MyCte AS (SELECT * ,RowNum = row_number() OVER ( order by profileId ) from Profiles ) SELECT * FROM MyCte WHERE RowNum >" + (count - 150) + " and  RowNum  <" + count);
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        public DataTable GetUserByProfileId(int profileId)
        {
            try
            {
                string Sql = String.Format("  SELECT *  FROM Profiles where  profileId={0} ", profileId);
                return db.ExecuteQuery(Sql);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }


        public void AddUpdateUserProfile(string About, string Location, byte[] PDF, string ProfileNo)
        {
            try
            {

                string Sql = String.Format("insert into [ProfilePdfs] ([Pdf],[ProfileNo]) values (@Pdf,{0})", ProfileNo);
                SqlCommand cmd = new SqlCommand(Sql);
                cmd.Parameters.AddWithValue("@Pdf", PDF);
                db.ExecuteNonQuery(cmd);

                Sql = String.Format("update [Profiles] set Location ='{0}' ,  About = '{1}'  , ProfileCheck = 1 where profileId = {2}", Location, About, ProfileNo);
                cmd = new SqlCommand(Sql);
                db.ExecuteNonQuery(cmd);


            }
            catch (Exception)
            {

            }
        }

        public byte[] GetUserProfilePDFByProfileId(int ProfileNo)
        {
            try
            {
                string Sql = String.Format("  SELECT Pdf  FROM ProfilePdfs where  ProfileNo={0} ", ProfileNo);
                return (byte[])db.ExecuteScalar(Sql);
            }
            catch (Exception)
            {
                return new byte[0];
            }
        }

        public void AddGroup(string GroupLinkUrl, string GroupName)
        {

            try
            {

                string Sql = String.Format("insert into [Groups] (GroupUrl,GroupName) values ('{0}','{1}')", GroupLinkUrl, GroupName);
                SqlCommand cmd = new SqlCommand(Sql);

                db.ExecuteNonQuery(cmd);



            }
            catch (Exception)
            {

            }
        }

        public void UpdateGroupMembersCount(string GroupNo , int MembersCount)
        {
            try
            {

                string Sql = String.Format("update [Groups] set MembersCount = {0} where GroupId = {1}", MembersCount, GroupNo);
                SqlCommand cmd = new SqlCommand(Sql,db.cn);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

            }
        }
    }
}
