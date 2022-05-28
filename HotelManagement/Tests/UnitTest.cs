using HotelManagement.Bean;
using HotelManagement.CommonUtils;
using HotelManagement.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Tests
{
    [TestFixture]
    public class UnitTest : LaunchBrowser
    {
        private BookingRoomPage m_BookingRoomPage;
        private FeedBackBean m_FeedBackBean;
        private FeedBackPage m_FeedBackPage;
        private BookingRoomBean m_BookingRoomBean;

        [OneTimeSetUp]
        public void Init()
        {
            m_BookingRoomPage = new BookingRoomPage();
            m_FeedBackPage = new FeedBackPage();
            m_FeedBackBean = (FeedBackBean)JsonReader.ReadInputs(AppDomain.CurrentDomain.BaseDirectory + "\\TestInputs\\FeedBackDetails.json", typeof(FeedBackBean));
            m_BookingRoomBean = (BookingRoomBean)JsonReader.ReadInputs(AppDomain.CurrentDomain.BaseDirectory + "\\TestInputs\\BookingDetails.json", typeof(BookingRoomBean));
            OpenBrowser(BrowserType.Chrome);
        }

        [Test, Description(""), Order(1)]
        public void VerifyThatUserCanLaunchHotelApp()
        {
            Base.ScrollDownPage(m_BookingRoomPage.btnHack);
            m_BookingRoomPage.ClickHackButton();
            Base.ScrollDownPage(m_BookingRoomPage.btnBookRoom);
            m_BookingRoomPage.ClickBookRoomButton();
            Assert.That(m_BookingRoomPage.AssertCalendarVisibility(), Is.True, "Calendar is not visible");
        }

        /// <summary>
        /// This method fails because calendar control is not working properly
        /// Date Selection is mandatory for booking room
        /// </summary>
        [Test, Description(""), Order(2)]
        public void VerifyThatUserCanBookTheRoom()
        {
            m_BookingRoomPage.EnterBookingDetails(m_BookingRoomBean);
            m_BookingRoomPage.ClickBookButton();
            Assert.That(m_BookingRoomPage.AssertBookingFormVisibility(), Is.False, "Booking details should not be visible after successful submit");
        }

        [Test, Description(""), Order(3)]
        public void VerifyThatUserCanProvideFeedBack()
        {
            m_FeedBackPage.EnterFeedBackDetails(m_FeedBackBean);
            m_FeedBackPage.ClickSubmitButton();
            Assert.That(m_FeedBackPage.AssertFeedBackFormVisibility(), Is.False, "Feed Back form should not be visible after successful submit");
        }

        
        

    }
}
