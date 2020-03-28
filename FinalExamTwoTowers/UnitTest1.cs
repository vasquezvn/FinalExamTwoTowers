using ConsoleTheTeaStory;
using ConsoleTheTeaStory.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleFirstQuestion;

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

        [TestMethod]
        public void VerifyPrimeNumberExists()
        {
            ConsoleFirstQuestion.Program p = new Program();

            int[] array1 = new int[] { 1, 2, 3, 4 };
            int[] array2 = new int[] { 4, 5, 7, 8, 10 };
            int[] array3 = new int[] { 3, 4, 6, 7, 9 };

            int[] missingNumbs = p.GetMissingNumbers(array3);
            var isTherePrimeNumb = p.IsTherePrimeNumbers(missingNumbs);

            Assert.IsTrue(isTherePrimeNumb, "There isn't prime numbers");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
