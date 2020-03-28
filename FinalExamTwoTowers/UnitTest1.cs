using System;
using ConsoleTheTeaStory;
using ConsoleTheTeaStory.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinalExamTwoTowers
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void VerifyContactUsFormHasBeenSent()
        {
            HomePage.GoTo();
            HomePage.GoToTeaOption(HomePage.TeaOptions.ContactUs);

            ContactUsPage.SetName("testName")
                .SetEmail("test@test.com")
                .SetMessage("test test test test test")
                .PressSendButton();

            var isSend = ContactUsPage.IsMessageSend("We'll get back to you shortly!");

            Assert.IsTrue(isSend, "Contact message has not been sent");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
