using HotelManagement.Bean;
using HotelManagement.CommonUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Pages
{
    class FeedBackPage
    {
        internal IWebElement UserName
        {
            get { return DriverContext.Driver.FindElement(By.Id("name")); }
        }
        internal IWebElement EmailId
        {
            get { return DriverContext.Driver.FindElement(By.Id("email")); }
        }

        internal IWebElement Phone
        {
            get { return DriverContext.Driver.FindElement(By.Id("phone")); }
        }

        internal IWebElement MailSubject
        {
            get { return DriverContext.Driver.FindElement(By.Id("subject")); }
        }

        internal IWebElement MailMessage
        {
            get { return DriverContext.Driver.FindElement(By.Id("description")); }
        }

        internal IWebElement btnSubmit
        {
            get { return DriverContext.Driver.FindElement(By.Id("submitContact")); }
        }

        public void ClickSubmitButton()
        {
            btnSubmit.Click();
            Thread.Sleep(1000);
        }

        internal void EnterFeedBackDetails(FeedBackBean m_FeedBackBean)
        {
            UserName.SendKeys(m_FeedBackBean.Name);
            EmailId.SendKeys(m_FeedBackBean.Email);
            Phone.SendKeys(m_FeedBackBean.Phone);
            MailSubject.SendKeys(m_FeedBackBean.MailSubject);
            MailMessage.SendKeys(m_FeedBackBean.MailBody);
        }

        internal bool AssertFeedBackFormVisibility()
        {
            bool IsVisible = false;
            try
            {
                DriverContext.Driver.FindElement(By.Id("submitContact"));
                IsVisible = true;
            }
            catch (NoSuchElementException ex)
            {
                IsVisible = false;
                Base.LogMessage(ex.Message);
            }


            return IsVisible;
        }

    }
}
