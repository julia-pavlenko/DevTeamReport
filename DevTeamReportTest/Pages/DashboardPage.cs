using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamReportTest.Pages
{
    class DashboardPage : Page
    {
        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        internal bool OnDashboardPage()
        {
            return driver.FindElement(By.XPath("//h1[contains(text(), 'Dashboard')]")).Displayed;
        }
    }
}
