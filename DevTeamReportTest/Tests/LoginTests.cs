
using DevTeamReportTest.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DevTeamReportTest
{
    [AllureNUnit]
    class LoginTests
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");

            driver = new ChromeDriver("C:\\Users\\jipav\\source\\drivers", options, TimeSpan.FromMinutes(3));
        }

        [Test]
        public void PositiveLogin()
        {
            driver.Url = Const.AppUrl;
            LoginPage loginPage = new LoginPage(driver);
            DashboardPage dashboardPage = new DashboardPage(driver); 

            loginPage.EnterEmail("ji.pavlenko@gmail.com");
            loginPage.EnterPassword("youcandoit10");
            loginPage.ClickLogin();
            loginPage.WaitForLogin();

            Assert.IsTrue(dashboardPage.OnDashboardPage(), "User is not on Dashboard page");


        }
        [Test]
        public void NegativeLogin()
        {
            driver.Url = Const.AppUrl;
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterEmail("test@gmail.com");
            loginPage.EnterPassword("youcandoit10");
            loginPage.ClickLogin();
            loginPage.WaitForLogin();

            Assert.IsTrue(loginPage.OnLoginPage(), "User is not on Login page");
        }

        [Test]
        public void NegativeLoginIncorrectPass()
        {
            driver.Url = Const.AppUrl;
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterEmail("ji.pavlenko@gmail.com");
            loginPage.EnterPassword("youcandoit");
            loginPage.ClickLogin();
            loginPage.WaitForLogin();

            Assert.IsTrue(loginPage.OnLoginPage(), "User is not on Login page");
        }

        [Test]
        public void NegativeLoginEmptyLogin()
        {
            driver.Url = Const.AppUrl;
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterEmail("");
            loginPage.EnterPassword("youcandoit");
            loginPage.ClickLogin();
            loginPage.WaitForLogin();

            Assert.IsTrue(loginPage.OnLoginPage(), "User is not on Login page");
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
