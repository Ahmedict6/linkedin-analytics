using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Linked_In_Program;
using InBLL;
using System.Text.RegularExpressions;
namespace UmmAlQuwainIFrom.BLL
{




    public class Controling
    {

        private static readonly object GetSavelocker = new object();

        //int ProxyID;
        DinmicSteps dinminc = new DinmicSteps();
        IWebDriver Drivers;
        static string LoginURL = "https://www.linkedin.com/login";

        static string UserNameLoginXpath = "//*[@id='username']";
        static string PasswordLoginXpath = "//*[@id='password']";
        string UserName = "jcperez2019@hushmail.com";   // "";
        string Password = "Nelsonmaria1"; // "";
        static string BtnLoginXpath = "//*[@data-litms-control-urn='login-submit']";
        static string path = "";

        ChromeOptions options = new ChromeOptions();

        public Controling(String _UserName, String _Password)
        {
            UserName = _UserName;
            Password = _Password;

        }
           
     ~Controling()
        {
            Drivers.Close();
            Drivers.Dispose();

        }

        private void SetChromeOptions(Boolean hiden)
        {
            try
            {
                if (Drivers != null)
                {
                    Drivers.Close();
                    Drivers.Dispose();
                }

                string dirpath = Directory.GetCurrentDirectory();
                //  options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);

                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();

                driverService.HideCommandPromptWindow = true;

                path = Directory.GetCurrentDirectory() + @"\Files\";
                options.AddUserProfilePreference("download.default_directory", path);
                options.AddUserProfilePreference("disable-popup-blocking", "true");
                options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                options.AddArgument("--disable-popup-blocking");
                if (hiden)
                {
                    options.AddArgument("--headless");
                    options.AddArgument("--disable-gpu");
                }
                ChromeDriver ChromDriver = new ChromeDriver(driverService, options);

                EnableDownloadInHeadlessChrome(ChromDriver, path);

                Drivers = ChromDriver;
                Drivers.Manage().Cookies.DeleteAllCookies();

                Drivers.Manage().Window.Maximize(); 


            }
            catch (Exception)
            {

            }
        }
        public void EnableDownloadInHeadlessChrome(ChromeDriver driver, string downloadDir)
        {
            // There is no need to add support for the Chrome "send_command"; the ChromeDriver
            // class already has it built in.
            var paramss = new Dictionary<string, object>();
            paramss["behavior"] = "allow";
            paramss["downloadPath"] = downloadDir;
            driver.ExecuteChromeCommand("Page.setDownloadBehavior", paramss);
        }
        public void GetGropsPosts(string GroupNo, Boolean SilentMode, bool newBrowwser)
        {
            try
            {

                if (newBrowwser)
                {

                    SetChromeOptions(SilentMode);
                    inslaize(LoginURL);
                    dinminc.setTextByxpath(Drivers, UserNameLoginXpath, UserName);
                    dinminc.setTextByxpath(Drivers, PasswordLoginXpath, Password);
                    dinminc.Click(Drivers, BtnLoginXpath);
                    Thread.Sleep(6000);

                }



                DataTable dtGrops;
                if (GroupNo == "0")
                    dtGrops = new Data().GetGrops();
                else
                    dtGrops = new Data().GetGropsbyId(GroupNo);


                foreach (DataRow dr in dtGrops.Rows)
                {
                    ReadOnlyCollection<IWebElement> Posts;
                    int count = 0;
                    inslaize(dr["GroupUrl"].ToString());

                    do
                    {
                        //1. Scrple to the end of the page 

                        ((IJavaScriptExecutor)Drivers).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                        count++;
                        Thread.Sleep(1000);
                    } while (count < 150);


                    Posts = Drivers.FindElements(By.XPath("//*[@data-urn]"));


                    foreach (var post in Posts)
                    {
                        try
                        {

                            string profileLinkUrl = post.FindElement(By.XPath(".//*[@class='feed-shared-actor__container-link relative display-flex flex-grow-1 app-aware-link ember-view']")).GetAttribute("href");
                            string profileText = post.FindElement(By.XPath(".//*[@class='feed-shared-text relative feed-shared-update-v2__commentary  ember-view']")).Text;
                            string userurl = profileLinkUrl.Substring(0, profileLinkUrl.LastIndexOf('?') - 1);



                            int CourrentGroupNo = int.Parse(dr["GroupId"].ToString());
                            new Data().AddPost(userurl, profileText, CourrentGroupNo);


                        }
                        catch (Exception)
                        {
                            string log = Directory.GetCurrentDirectory() + "\\" + dr["GroupName"].ToString().Trim() + "_Postes.txt";

                            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidFileNameChars());
                            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                            log = r.Replace(log, "");

                            using (StreamWriter w = File.AppendText(log))
                            {
                                w.WriteLine("Error : " + post.Text);
                            }
                        }
                    }


                }
            }
            catch
            {


            }
        }

        public void GetGropsUsers(string GroupNo, Boolean SilentMode, bool newBrowwser)
        {
            try
            {
                if (newBrowwser)
                {
                    SetChromeOptions(SilentMode);
                    inslaize(LoginURL);
                    dinminc.setTextByxpath(Drivers, UserNameLoginXpath, UserName);
                    dinminc.setTextByxpath(Drivers, PasswordLoginXpath, Password);
                    dinminc.Click(Drivers, BtnLoginXpath);
                    Thread.Sleep(6000);
                }

                DataTable dtGrops;
                if (GroupNo == "0")
                    dtGrops = new Data().GetGrops();
                else
                    dtGrops = new Data().GetGropsbyId(GroupNo);


                foreach (DataRow dr in dtGrops.Rows)
                {
                    ReadOnlyCollection<IWebElement> Users;

                    inslaize(dr["GroupUrl"].ToString() + @"members/");
                    Thread.Sleep(6000);
                    string MembersCountTxet = dinminc.getTextByxpath(Drivers, @"//*[@class='t-24 t-black t-light']");
                    int MembersCount = int.Parse(MembersCountTxet.Split(' ')[0].ToString().Replace(",", ""));
                    if (MembersCount == int.Parse(dr["MembersCount"].ToString()))
                        continue;
                    else
                        new Data().UpdateGroupMembersCount(GroupNo , MembersCount);

                    int count = 0;
                    int chech = 0;
                    int Tryal = 0;
                    do
                    {
                        //1. Scrple to the end of the page 

                        ((IJavaScriptExecutor)Drivers).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");

                        chech = count;
                        Users = Drivers.FindElements(By.XPath("//*[@data-control-name='view_profile']"));
                        count = Users.Count;
                        if (chech == count)
                        {
                            Tryal++;
                            Thread.Sleep(2500);
                        }
                        else
                        {
                            Tryal = 0;
                        }
                        if (Tryal == 10) { break; }
                        Thread.Sleep(600);
                    } while (count != MembersCount);


                    List<String> Links = new List<string>();
                    foreach (var User in Users)
                    {
                        String link = User.GetAttribute("href");
                        Links.Add(link);


                        try
                        {


                            String userName = User.FindElement(By.XPath(".//*[@class='artdeco-entity-lockup__title ember-view']")).Text;//dinminc.getTextByxpath(Drivers, @"//*/div[2]/div[2]/div[1]/ul[1]/li[1]");
                            String Description = User.FindElement(By.XPath(".//*[@class='artdeco-entity-lockup__subtitle ember-view']")).Text; //dinminc.getTextByxpath(Drivers, @"//*/div[2]/div[2]/div[1]/h2");
                            String Location = "";// dinminc.getTextByxpath(Drivers, @"//*[@class='t-16 t-black t-normal inline-block']");
                            String Url = link;
                            String imageUrl = "";
                            try
                            {
                                var IMag = User.FindElements(By.XPath(@".//*[@class=' presence-entity__image EntityPhoto-circle-4 lazy-image loaded ember-view']"));
                                imageUrl = IMag[0].GetAttribute("src");
                            }
                            catch (Exception)
                            {

                            }

                            int CourrentGroupNo = int.Parse(dr["GroupId"].ToString());
                            new Data().AddUser(userName, Description, Location, Url, imageUrl, CourrentGroupNo);
                            //Thread.Sleep(1000);

                        }
                        catch (Exception)
                        {
                            string log = Directory.GetCurrentDirectory() + "\\" + dr["GroupName"].ToString().Trim() + ".txt";

                            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidFileNameChars());
                            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                            log = r.Replace(log, "");

                            using (StreamWriter w = File.AppendText(log))
                            {
                                w.WriteLine("Error : Link : " + link);
                            }
                        }


                    }

                }
            }
            catch
            {


            }

        }

        public void GetUsersProfile(Boolean SilentMode, bool newBrowwser)
        {
            try
            {

                if (newBrowwser)
                {
                    SetChromeOptions(SilentMode);
                    inslaize(LoginURL);
                    dinminc.setTextByxpath(Drivers, UserNameLoginXpath, UserName);
                    dinminc.setTextByxpath(Drivers, PasswordLoginXpath, Password);
                    dinminc.Click(Drivers, BtnLoginXpath);
                    Thread.Sleep(6000);
                }

                DataTable dtusers = new Data().GetusersProfiles();

                String FilePath = path + @"\Profile.pdf";

                foreach (DataRow dr in dtusers.Rows)
                {

                    inslaize(dr["AccountLink"].ToString());

                    try
                    {

                        dinminc.Click(Drivers, "//*[@id='line-clamp-show-more-button']");

                    
                        String About = dinminc.getTextByxpath(Drivers, @"//*/div[*]/div[*]/div[*]/h2");
                        String Location = dinminc.getTextByxpath(Drivers, @"//*/div[*]/div[*]/div[*]/ul[2]/li[1]");
                        try
                        {
                            // Pdf
                            dinminc.Click(Drivers, @"//button[@type='button' and contains(., 'More…') ]");
                            Thread.Sleep(1000);
                            dinminc.Click(Drivers, @"//ul/li[ contains(., 'Save to PDF') ]/div/div"); //@"//*[@class='pv-s-profile-actions pv-s-profile-actions--save-to-pdf pv-s-profile-actions__overflow-button full-width text-align-left artdeco-dropdown__item artdeco-dropdown__item--is-dropdown ember-view']


                            for (int i = 0; i < 4; i++)
                            {
                                Thread.Sleep(4000);
                                if (File.Exists(FilePath))
                                {


                                    byte[] PDF = File.ReadAllBytes(FilePath);
                                    new Data().AddUpdateUserProfile(About, Location, PDF, dr["profileId"].ToString());
                                    File.Delete(FilePath);
                                    break;
                                    //   

                                }
                            }



                        }
                        catch (Exception)
                        {

                        }

                        //int CourrentGroupNo = int.Parse(dr["GroupId"].ToString());
                        //  new Data().AddUpdateUserProfile(userName, Description, Location, Url, imageUrl, CourrentGroupNo);
                        //Thread.Sleep(1000);

                    }
                    catch (Exception)
                    {
                        //string log = Directory.GetCurrentDirectory() + "\\" + dr["GroupName"].ToString().Trim() + ".txt";

                        //using (StreamWriter w = File.AppendText(log))
                        //{
                        //    w.WriteLine("Error : Link : " + link);
                        // }
                    }




                }

            }
            catch
            {


            }
        }



        private void inslaize(String Url)
        {
            try
            {
                dinminc.NavigatetoUrl(Drivers, Url);
            }
            catch (Exception ex)
            {

            }
        }



        internal void AutoMode(bool SilentMode)
        {
            SetChromeOptions(SilentMode);
            inslaize(LoginURL);
            dinminc.setTextByxpath(Drivers, UserNameLoginXpath, UserName);
            dinminc.setTextByxpath(Drivers, PasswordLoginXpath, Password);
            Thread.Sleep(2000);
            dinminc.Click(Drivers, BtnLoginXpath);
            Thread.Sleep(6000);
            Thread.Sleep(4000);
            do
            {

                try
                {

              
           

                CheckNewGropus("0", SilentMode, false);
                Thread.Sleep(4000);

                GetGropsUsers("0", SilentMode, false);
                Thread.Sleep(4000);
                GetGropsPosts("147", SilentMode, false);

                Thread.Sleep(4000);
                GetUsersProfile(SilentMode, false);
                new Data().PostClassification();
                Thread.Sleep(24 * 60 * 60 * 1000);
                }
                catch (Exception)
                {

                  
                }
            } while (true);

        }

        private void CheckNewGropus(string p1, bool SilentMode, bool newBrowwser)
        {

            try
            {

                if (newBrowwser)
                {
                    SetChromeOptions(SilentMode);
                    inslaize(LoginURL);
                    dinminc.setTextByxpath(Drivers, UserNameLoginXpath, UserName);
                    dinminc.setTextByxpath(Drivers, PasswordLoginXpath, Password);
                    dinminc.Click(Drivers, BtnLoginXpath);
                    Thread.Sleep(6000);

                }

                inslaize(@"https://www.linkedin.com/groups/");
                int count = 0;

                Thread.Sleep(6000);

                do
                {
                    //1. Scrple to the end of the page 

                    ((IJavaScriptExecutor)Drivers).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                    count++;
                    Thread.Sleep(1000);
                } while (count < 6);

                ReadOnlyCollection<IWebElement> Groups;

                Groups = Drivers.FindElements(By.XPath(@"//*[@class='artdeco-list__item display-flex justify-space-between align-items-center ember-view']"));

                foreach (var Group in Groups)
                {
                    try
                    {

                        string GroupLinkUrl = Group.FindElement(By.XPath(".//*[@class='link-without-visited-state ember-view']")).GetAttribute("href");
                        string GroupName = Group.FindElement(By.XPath(".//*[@class='link-without-visited-state ember-view']/span")).Text;


                        new Data().AddGroup(GroupLinkUrl, GroupName);



                    }
                    catch { }
                }

            }



            catch
            {

            }
        }
    }
}
