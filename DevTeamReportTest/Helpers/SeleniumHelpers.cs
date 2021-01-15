using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamReportTest.SeleniumHelpers
{
    class SeleniumHelpers
    {
        public static void WaitForElement(IWebDriver driver, By by) 
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                try
                {
                    IWebElement element = Web.FindElement(by);
                    if (element.Displayed)
                    {
                        return true;
                    }
                    return false;
                }
                catch (NoSuchElementException ex)
                {
                    return false;
                }
            });

            try
            {
                wait.Until(waitForElement);
            }
            catch (WebDriverTimeoutException ex)
            { 

            }
        }
    }
}
