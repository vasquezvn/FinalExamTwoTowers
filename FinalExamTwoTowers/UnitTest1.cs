using ConsoleTheTeaStory;
using ConsoleTheTeaStory.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleFirstQuestion;
using ConsoleSecondQuestion;
using System.Threading.Tasks;

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
            ConsoleFirstQuestion.Program p = new ConsoleFirstQuestion.Program();

            int[] array1 = new int[] { 1, 2, 3, 4 };
            int[] array2 = new int[] { 4, 5, 7, 8, 10 };
            int[] array3 = new int[] { 3, 4, 6, 7, 9 };

            int[] missingNumbs = p.GetMissingNumbers(array3);
            var isTherePrimeNumb = p.IsTherePrimeNumbers(missingNumbs);

            Assert.IsTrue(isTherePrimeNumb, "There isn't prime numbers");
        }

        [TestMethod]
        public async Task VerifyFirstStudentAsync()
        {
            ConsoleSecondQuestion.Program p = new ConsoleSecondQuestion.Program();
            Student s = new Student();
            s.id = 1;
            s.firstName = "Vernon";
            s.lastName = "Harper";
            s.email = "egestas.rhoncus.Proin@massaQuisqueporttitor.org";
            s.programme = "Financial Analysis";
            s.courses = new string[] { "Accounting", "Statistics" };

            await p.IsFirstStudentAsync(s);

            var isFirstStudent = p.GetStudentApi().Equals(s);
            Assert.IsTrue(isFirstStudent, "Student is not the first student on API");
        }

        [TestMethod]
        public async Task VerifyCreateStudentAsync()
        {
            ConsoleSecondQuestion.Program p = new ConsoleSecondQuestion.Program();
            Student s = new Student();
            s.firstName = Helper.RandomString(5);
            s.lastName = Helper.RandomString(5);
            s.email = $"{Helper.RandomString(5)}@test.org";
            s.programme = Helper.RandomString(5);
            s.courses = new string[] { Helper.RandomString(5), Helper.RandomString(5) };

            await p.CreateStudentAsync(s);
            await p.GetStudentByName(s.firstName);

            var isCreated = p.GetStudentApi().Equals(s);

            Assert.IsTrue(isCreated, "User Was not created on API");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
