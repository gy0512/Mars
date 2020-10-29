using Mars.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Mars.StepDefinitions
{
    [Binding]
    // [Binding, Scope(Feature = "Profile")]
    public sealed class ShareSkillDefinitions
    {
        static void Main(string[] args)
        {

        }

        IWebDriver driver;

        [BeforeScenario]
        public void LogIn()
        {
            // initiate driver
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//FirefoxDriver

            // Log in
            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);
        }

        [AfterScenario]
        public void Dispose()
        {
            driver.Dispose();// close the window and release memory
        }

        [Given(@"I create the description in profile")]
        public void GivenICreateTheDescriptionInProfile()
        {
            ProfilePage profileObj = new ProfilePage();
            profileObj.CreateDescription(driver);
        }

        [Given(@"I Add the new language in profile")]
        public void GivenIAddTheNewLanguageInProfile()
        {
            ProfilePage profileObj = new ProfilePage();
            profileObj.AddNewLanguage(driver);
        }

        [Given(@"I click the share skill button in profile")]
        public void GivenIClickTheShareSkillButtonInProfile()
        {
            ShareSkillPage shareskillObj = new ShareSkillPage();
            shareskillObj.GotoShareSkillPage(driver);
        }
        
        [Given(@"I create skill in share skill page")]
        public void GivenICreateSkillInShareSkillPage()
        {
            ShareSkillPage shareskillObj = new ShareSkillPage();
            shareskillObj.CreateShareSkill(driver);
        }

    }
}
