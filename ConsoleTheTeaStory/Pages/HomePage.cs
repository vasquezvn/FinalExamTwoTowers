using OpenQA.Selenium;

namespace ConsoleTheTeaStory.Pages
{
    public class HomePage
    {
        public enum TeaOptions
        {
            ContactUs,
        }

        private static By locatorContactUs => By.XPath("//p[@class='font_8']/span[1]/a/span/span[@class='color_11']");

        private static IWebElement linkContactUs => Driver.Instance.FindElement(locatorContactUs);

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://www.theteastory.co/");
        }

        public static void GoToTeaOption(TeaOptions option)
        {
            Helper.WaitUntilElementClickable(locatorContactUs);

            switch (option)
            {
                case TeaOptions.ContactUs:
                    linkContactUs.Click();

                    break;

                default:
                    break;
            }
        }
    }
}
