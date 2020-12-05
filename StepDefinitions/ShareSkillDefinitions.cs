using Mars.Helpers;
using Mars.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Mars.StepDefinitions
{
    [Binding] //[Binding, Scope(Feature = "Profile")]
    public sealed class ShareSkillDefinitions : Steps
    {
        static void Main(string[] args)
        {

        }

        //private readonly ScenarioContext _scenarioContext;

        //public ShareSkillDefinitions(ScenarioContext scenarioContext)
        //{
        //    _scenarioContext = scenarioContext;
        //}
        
        public readonly RuntimeData runtimeData;

        public ShareSkillDefinitions(RuntimeData dyndata)
        {
            this.runtimeData = dyndata;
        }

        IWebDriver driver;

        [BeforeScenario] //[BeforeFeature] [OneTimeSetUp]

        public void LogIn()
        {
            //this.ScenarioContext.Set("Global", "ScenarioContext");

            // initiate driver
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//FirefoxDriver

            // Log in
            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);
        }

        [AfterScenario] //[AfterFeature] [OneTimeTearDown]
        public void Dispose()
        {
            driver.Dispose();// close the window and release memory
        }

        [Given(@"I goto the profile page")]
        public void GivenIGotoTheProfilePage()
        {
            // go to profile page
            ProfilePage profileObj = new ProfilePage();
            profileObj.GotoProfilePage(driver);
        }

        [When(@"ScenarioContext dynamic data details")]
        public void WhenScenarioContextDynamicDataDetails(Table table)
        {
            // set dynamic data
            var data = table.CreateDynamicSet();

            foreach (var item in data)
            {
                item.randnum = RuntimeData.rd.Next(1, 99999999);
                runtimeData.randnum = (long)item.randnum;
                //Console.WriteLine($"runtimeData:{runtimeData.randnum}");
            }

        }

        [Then(@"I create the description in profile")]
        public void ThenICreateTheDescriptionInProfile()
        {
            Console.WriteLine($"runtimeData:{runtimeData.randnum}");
            ProfilePage profileObj = new ProfilePage();
            profileObj.CreateDescription(driver, runtimeData.randnum);

        }

        [Given(@"I Add the new language in profile")]
        public void GivenIAddTheNewLanguageInProfile()
        {
            ProfilePage profileObj = new ProfilePage();
            profileObj.AddNewLanguage(driver);
        }


        [Given(@"Share the skill I goto the profile page")]
        public void GivenShareTheSkillIGotoTheProfilePage()
        {
            ProfilePage profileObj = new ProfilePage();
            profileObj.GotoProfilePage(driver);
        }

        [When(@"Share the skill data details")]
        public void WhenShareTheSkillDataDetails(Table table)
        {
            var data = table.CreateDynamicSet();

            foreach (var item in data)
            {
                item.randnum = RuntimeData.rd.Next(1, 99999999);
                runtimeData.randnum = (long)item.randnum;
                //Console.WriteLine($"runtimeData:{runtimeData.randnum}");
            }
        }

        [When(@"Share the skill I create the description in profile")]
        public void WhenShareTheSkillICreateTheDescriptionInProfile()
        {
            //Console.WriteLine($"runtimeData:{runtimeData.randnum}");
            ProfilePage profileObj = new ProfilePage();
            profileObj.CreateDescription(driver, runtimeData.randnum);
        }

        [When(@"Share the skill I click the share skill button in profile")]
        public void WhenShareTheSkillIClickTheShareSkillButtonInProfile()
        {
            ShareSkillPage shareskillObj = new ShareSkillPage();
            shareskillObj.GotoShareSkillPage(driver);
        }

        [Then(@"Share the skill I create skill in share skill page")]
        public void ThenShareTheSkillICreateSkillInShareSkillPage()
        {
            //Console.WriteLine($"runtimeData:{runtimeData.randnum}");
            ShareSkillPage shareskillObj = new ShareSkillPage();
            shareskillObj.CreateShareSkill(driver, runtimeData.randnum);
        }



        [Given(@"SFTWO Share the skill I goto the profile page")]
        public void GivenSFTWOShareTheSkillIGotoTheProfilePage()
        {
            ProfilePage profileObj = new ProfilePage();
            profileObj.GotoProfilePage(driver);
        }


        [When(@"SFTWO Share the skill data details")]
        public void WhenSFTWOShareTheSkillDataDetails(Table table)
        {
            var data = table.CreateDynamicSet();

            foreach (var item in data)
            {
                item.randnum = RuntimeData.rd.Next(1, 99999999);
                runtimeData.randnum = (long)item.randnum;
                //Console.WriteLine($"runtimeData:{runtimeData.randnum}");
            }
        }

        [When(@"SFTWO Share the skill I click the share skill button in profile")]
        public void WhenSFTWOShareTheSkillIClickTheShareSkillButtonInProfile()
        {
            ShareSkillPage shareskillObj = new ShareSkillPage();
            shareskillObj.GotoShareSkillPage(driver);
        }

        [When(@"SFTWO Share the skill I create skill in share skill page")]
        public void WhenSFTWOShareTheSkillICreateSkillInShareSkillPage()
        {
            ShareSkillPage shareskillObj = new ShareSkillPage();
            shareskillObj.CreateShareSkill(driver, runtimeData.randnum);
        }

        [When(@"I search the skill name in search box")]
        public void WhenISearchTheSkillNameInSearchBox()
        {
            SkillListPage skilllistObj = new SkillListPage();
            skilllistObj.SearchSkill(driver, runtimeData.randnum);
        }

        [Then(@"I turn page to find the skill card")]
        public void ThenITurnPageToFindTheSkillCard()
        {
            SkillListPage skilllistObj = new SkillListPage();
            skilllistObj.FindSkill(driver, runtimeData.randnum);
        }
    }
}
