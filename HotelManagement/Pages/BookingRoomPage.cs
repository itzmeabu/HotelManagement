using System;
using HotelManagement.Bean;
using HotelManagement.CommonUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace HotelManagement.Pages
{
    public class BookingRoomPage
    {

        public IWebElement btnHack
        {
            get { return DriverContext.Driver.FindElement(By.XPath("//button[@class='btn btn-primary']")); }
        }

        public IWebElement btnBookRoom
        {
            get { return DriverContext.Driver.FindElement(By.XPath("//button[@class='btn btn-outline-primary float-right openBooking']")); }
        }

        public IWebElement FirstName
        {
            get { return DriverContext.Driver.FindElement(By.Name("firstname")); }
        }

        public IWebElement LastName
        {
            get { return DriverContext.Driver.FindElement(By.Name("lastname")); }
        }

        internal IWebElement EmailId
        {
            get { return DriverContext.Driver.FindElement(By.Name("email")); }
        }

        internal IWebElement Phone
        {
            get { return DriverContext.Driver.FindElement(By.Name("phone")); }
        }

        internal IWebElement BtnBook
        {
            get { return DriverContext.Driver.FindElement(By.XPath("//button[text()='Book']")); }
        }

        public void ClickBookRoomButton()
        {
            btnBookRoom.Click();
        }

        public void ClickHackButton()
        {
            btnHack.Click();
        }

        public bool AssertCalendarVisibility()
        {
            return Base.IsElementPresent(FirstName);
        }

        internal void EnterBookingDetails(BookingRoomBean m_BookingRoomBean)
        {
            FirstName.SendKeys(m_BookingRoomBean.FirstName);
            LastName.SendKeys(m_BookingRoomBean.LastName);
            EmailId.SendKeys(m_BookingRoomBean.Email);
            Phone.SendKeys(m_BookingRoomBean.Phone);
        }

        public void ClickBookButton()
        {
            BtnBook.Click();
        }

        internal bool AssertBookingFormVisibility()
        {
            bool IsVisible = false;
            try
            {
                DriverContext.Driver.FindElement(By.XPath("//button[text()='Book']"));
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
