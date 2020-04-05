using ConsoleTheTeaStory;
using ConsoleTheTeaStory.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void VerifyFirstStudentAsync()
        {
            ConsoleSecondQuestion.Program p = new ConsoleSecondQuestion.Program();
            Student s = new Student();
            s.id = 1;
            s.firstName = "Vernon";
            s.lastName = "Harper";
            s.email = "IKFVY@test.com";
            s.programme = "Financial Analysis";
            s.courses = new string[] { "Accounting", "Statistics" };

            var isFirst = p.IsFirstStudent(s).Result;

            Assert.IsTrue(isFirst, "Student is not the first student on API");
        }

        [TestMethod]
        public void VerifyCreateStudentAsync()
        {
            ConsoleSecondQuestion.Program p = new ConsoleSecondQuestion.Program();
            Student s = new Student();
            s.firstName = Helper.RandomString(5);
            s.lastName = Helper.RandomString(5);
            s.email = $"{Helper.RandomString(5)}@test.org";
            s.programme = Helper.RandomString(5);
            s.courses = new string[] { Helper.RandomString(5), Helper.RandomString(5) };

            var isStudentCreated = p.CreateStudentAsync(s).Result;
            var studentFromApi = p.GetStudentByName(s.firstName).Result;

            var isCreated = studentFromApi.Equals(s) && isStudentCreated;

            Assert.IsTrue(isCreated, "User Was not created on API");
        }

        [TestMethod]
        public void VerifyUpdateStudentEmailAsync()
        {
            ConsoleSecondQuestion.Program p = new ConsoleSecondQuestion.Program();
            var idStudentToUpdate = 1;

            var studentFromApi = p.GetStudentAsync(idStudentToUpdate).Result;
            var emailPreUpdate = studentFromApi.email;


            studentFromApi.email = $"{Helper.RandomString(20)}@test.com";
            var isStudentUpdated = p.UpdateStudentAsync(studentFromApi).Result;

            var studentPostUpdate = p.GetStudentAsync(idStudentToUpdate).Result;

            var isUpdated = !studentPostUpdate.email.Equals(emailPreUpdate) && isStudentUpdated;

            Assert.IsTrue(isUpdated, "Email was not been updated to selected Student");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
