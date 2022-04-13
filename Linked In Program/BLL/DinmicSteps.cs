using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
 
namespace UmmAlQuwainIFrom.BLL
{
    class DinmicSteps
    {
        public void NavigatetoUrl(IWebDriver sender, String url)
        {
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            sender.Navigate().GoToUrl(url);
            
        }
        public void Click(IWebDriver sender, String xpath)
        {
            //Click by xpath
            try
            {

                sender.FindElement(By.XPath(xpath)).Click();
            }
            catch 
            {
                
             }
        }
        public String getTitleByXpath(IWebDriver sender, String xpath)
        {
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //Get The User name of the photo owener 
            return sender.FindElement(By.XPath(xpath)).GetAttribute("title");
        }
        public String getTitleByCssSelector(IWebDriver sender, String CssSelector)
        {
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //Get The User name of the photo owener 
            return sender.FindElement(By.CssSelector(CssSelector)).GetAttribute("title");
        }
        public String getTextByxpath(IWebDriver sender, String xpath)
        {
            try
            {

           
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //Get The User name of the photo owener //div[2]/div[2]/span/span
            return sender.FindElement(By.XPath(xpath)).Text;
            }
            catch (Exception)
            {
                return "";
            }

        }
        public void setTextByxpath(IWebDriver sender, String xpath , string Text)
        {
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //Get The User name of the photo owener //div[2]/div[2]/span/span
             sender.FindElement(By.XPath(xpath)).SendKeys(Text);
            

        }
        public void setTextByID(IWebDriver sender, String ID , string Text)
        {
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement TextBoxs = sender.FindElement(By.Id(ID));
            TextBoxs.Click();
            TextBoxs.SendKeys(Text);
        }

        public void setCheakBoxFalse(IWebDriver sender, String ID)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)sender;
            string title = (string)js.ExecuteScript(String.Format("document.getElementById('{0}').removeAttribute('disabled')","ctl00_PlaceHolderMain_chkSearch"));
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement TextBoxs = sender.FindElement(By.XPath(ID));
            TextBoxs.Click();

           // TextBoxs.SendKeys(Text);
        }


        public void SumitForm(IWebDriver sender, String ID)
        {
          
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement Objects = sender.FindElement(By.XPath(ID));
            Objects.Click();
           
           
        }

        public String getTextByCssSelector(IWebDriver sender, String CssSelector)
        {
            //Get The User name of the photo owener //div[2]/div[2]/span/span
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            return sender.FindElement(By.CssSelector(CssSelector)).Text;

        }

        public bool trygetAttrbute(IWebDriver sender, String ID , out String Output)
        {
            try
            {
                sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement Objects = sender.FindElement(By.Id(ID));
            Output = Objects.GetAttribute("onclick").ToString();
            return true;            
            }
            catch
            {
                Output = String.Empty;
                return false;
            }
        }

        public void setDropdownlistbyValue(IWebDriver sender, String Id , String Value)
        {
            //Get The User name of the photo owener //div[2]/div[2]/span/span
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
          //  return sender.FindElement(By.CssSelector(CssSelector)).Text;


            var education = sender.FindElement(By.Id(Id));
            //create select element object 
            var selectElement = new SelectElement(education);

            //select by value
            selectElement.SelectByValue(Value);
            // select by text
         
        }
        public void setDropdownlistbyText(IWebDriver sender, String Id , String Text)
        {
            //Get The User name of the photo owener //div[2]/div[2]/span/span
            sender.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
          //  return sender.FindElement(By.CssSelector(CssSelector)).Text;


            var education = sender.FindElement(By.Id(Id));
            //create select element object 
            var selectElement = new SelectElement(education);


            // select by text
            selectElement.SelectByText(Text);
        }
    }
}
