using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DevTeamReportTest.Pages
{
    class LoginPage : Page
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        internal void EnterEmail(string email)
        {
            driver.FindElement(By.Id("sign-up-email")).SendKeys(email);
        }

        internal void EnterPassword(string pass)
        {
            driver.FindElement(By.Id("sign-up-pass")).SendKeys(pass);
        }

        internal void ClickLogin()
        {
            driver.FindElement(By.CssSelector("button[class='btn pop-up-form__btn']")).Click();
        }

        internal void WaitForLogin()
        {
            SeleniumHelpers.SeleniumHelpers.WaitForElement(driver, By.XPath("//h1[contains(text(), 'Dashboard')]"));
        }

        internal bool OnLoginPage()
        {
            return driver.Title == "Sign In | DevTeam.Report";
        }

    }
}
