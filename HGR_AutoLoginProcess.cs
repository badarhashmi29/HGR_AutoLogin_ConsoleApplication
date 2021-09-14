using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HGR_CA
{
    class HGR_AutoLoginProcess
    {
        private readonly IWebDriver HGRWEBDriver;

        public HGR_AutoLoginProcess(IWebDriver webDriver)
        {
            this.HGRWEBDriver = webDriver;
        }

        public IWebDriver HGRLogin(string LoginURL, string Email, string Password)
        {
            try
            {
                //Calling URL
                HGRWEBDriver.Navigate().GoToUrl(LoginURL);

                //Getting and Setting Email Input Field
                var EmailInput = HGRWEBDriver.FindElement(By.Id("Email"));
                EmailInput.SendKeys(Email);

                //Getting and Setting Password Input Field
                var PaaswordInput = HGRWEBDriver.FindElement(By.Id("Password"));
                PaaswordInput.SendKeys(Password);

                //Getting Submit Button to Login
                var LogInButton = HGRWEBDriver.FindElement(By.XPath("//button[@type='submit']"));
                LogInButton.Click();

                return HGRWEBDriver;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
