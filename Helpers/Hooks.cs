using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using Mars.Pages;

namespace Mars
{
    [Binding]
    public sealed class Hooks
    {
        //IWebDriver driver;

        //[BeforeScenario]
        //public void BeforeScenario()
        //{
        //    // initiate driver
        //    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//FirefoxDriver

        //    // Log in
        //    LoginPage loginObj = new LoginPage();
        //    loginObj.LoginSteps(driver);
        //}

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    driver.Dispose();// close the window and release memory
        //}
    }
}
