using OpenQA.Selenium;
using System;

namespace ConsoleTheTeaStory.Pages
{
    public class ContactUsCommand
    {
        #region locators
        private By locatorTxtName => By.Id("field1");

        #endregion

        #region Iwebelements
        private IWebElement txtName => Driver.Instance.FindElement(locatorTxtName);
        private IWebElement txtEmail => Driver.Instance.FindElement(By.Id("field2"));
        private IWebElement txtAreaMessage => Driver.Instance.FindElement(By.Id("comp-j4o1qim5fieldMessage"));
        private IWebElement btnSend => Driver.Instance.FindElement(By.Id("comp-j4o1qim5submit"));
        private IWebElement lblNotificationMessage => Driver.Instance.FindElement(By.Id("comp-j4o1qim5notifications"));

        #endregion

        public ContactUsCommand SetName(string name)
        {
            Helper.WaitUntilElementClickable(locatorTxtName);

            try
            {
                txtName.SendKeys(name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Name field could't be find. \n Details: \n{ex.Message}");
            }

            return this;
        }

        public ContactUsCommand SetEmail(string email)
        {

            try
            {
                txtEmail.SendKeys(email);
            }
            catch (Exception ex)
            {
                throw new Exception($"Email field could't be find. \n Details: \n{ex.Message}");
            }

            return this;
        }

        public ContactUsCommand SetMessage(string message)
        {

            try
            {
                txtAreaMessage.SendKeys(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Message field could't be find. \n Details: \n{ex.Message}");
            }

            return this;
        }

        public ContactUsCommand PressSendButton()
        {

            try
            {
                btnSend.Click();
            }
            catch (Exception ex)
            {
                throw new Exception($"Send button could't be find. \n Details: \n{ex.Message}");
            }

            return this;
        }

        public bool IsMessageSend(string message)
        {
            bool result = false;

            if (lblNotificationMessage.Text.Contains(message))
                result = true;

            return result;
        }

    }
}
