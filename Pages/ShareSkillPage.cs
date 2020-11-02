using Mars.Helpers;
using Mars.StepDefinitions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Mars.Pages
{
    class ShareSkillPage
    {
        public void GotoShareSkillPage(IWebDriver driver)
        {
            // click the share skill button           
            driver.FindElement(By.LinkText("Share Skill")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // verify the share skill page
            try
            {
                var gotoshareskillpagecheck = driver.FindElement(By.XPath(".//div[@class=\"tooltip-target vertically padded ui grid\"]/div/div[2]/div/div[2]/p[text()='100']")).GetAttribute("textContent");
                Console.WriteLine($"gotoshareskillpagecheck:{gotoshareskillpagecheck}");
                Assert.That(gotoshareskillpagecheck == "Characters remaining: 100");
            }
            catch (Exception ex)
            {
                Assert.Fail("validate go to share skill page failed", ex.Message);
            }
        }

        public void CreateShareSkill(IWebDriver driver, long randnum)
        {
            // title
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys($"{RuntimeData.tags}{randnum}");

            // description
            driver.FindElement(By.Name("description")).Click();
            driver.FindElement(By.Name("description")).Clear();
            driver.FindElement(By.Name("description")).SendKeys($"{RuntimeData.tags}{randnum}");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);

            // category
            driver.FindElement(By.Name("categoryId")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            new SelectElement(driver.FindElement(By.Name("categoryId"))).SelectByText("Graphics & Design");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //driver.FindElement(By.Name("categoryId")).Click();


            // subcategory
            driver.FindElement(By.Name("subcategoryId")).Click();
            new SelectElement(driver.FindElement(By.Name("subcategoryId"))).SelectByText("Logo Design");
            //driver.FindElement(By.Name("subcategoryId")).Click();

            // tags
            driver.FindElement(By.XPath("//input[@value='']")).Click();
            //driver.FindElement(By.XPath("//input[@value='']")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//input[@value='']")).Clear();
            driver.FindElement(By.XPath("//input[@value='']")).SendKeys($"{RuntimeData.tags}{randnum}");
            driver.FindElement(By.XPath("//input[@value='']")).SendKeys(Keys.Enter);

            // service type
            driver.FindElement(By.XPath("(//input[@name='serviceType'])[2]")).Click();

            // Location type
            driver.FindElement(By.Name("locationType")).Click();

            // available days - start date
            driver.FindElement(By.Name("startDate")).Click();
            driver.FindElement(By.Name("startDate")).Clear();
            driver.FindElement(By.Name("startDate")).SendKeys($"{RuntimeData.currentdate}");
            Console.WriteLine($"currentdate:{RuntimeData.currentdate}");

            // available days - someday of a week
            driver.FindElement(By.XPath("(//input[@name='Available'])[2]")).Click();

            // available days - start time
            driver.FindElement(By.XPath("(//input[@name='StartTime'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name='StartTime'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@name='StartTime'])[2]")).SendKeys("00:53");

            // available days - end time
            driver.FindElement(By.XPath("(//input[@name='EndTime'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name='EndTime'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@name='EndTime'])[2]")).SendKeys("00:58");

            // skill trade
            driver.FindElement(By.XPath("(//input[@name='skillTrades'])[2]")).Click();//credit
            driver.FindElement(By.Name("skillTrades")).Click();//skill-exchange

            // skill-exchange
            driver.FindElement(By.XPath("(//input[@value=''])[15]")).Click();
            driver.FindElement(By.XPath("(//input[@value=''])[15]")).Clear();
            driver.FindElement(By.XPath("(//input[@value=''])[15]")).SendKeys($"{RuntimeData.skillexchange}{randnum}");
            driver.FindElement(By.XPath("(//input[@value=''])[15]")).SendKeys(Keys.Enter);

            // work samples //to be continued

            // active
            driver.FindElement(By.XPath("(//input[@name='isActive'])[2]")).Click();//hidden
            driver.FindElement(By.Name("isActive")).Click();//active

            // save
            driver.FindElement(By.XPath("//input[@value='Save']")).Click();

            // turn to last page
            driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[2]/button[2]")).Click();

            // verify the share skill page
            try
            {
                var categorycheck = driver.FindElement(By.XPath(".//table[@class=\"ui striped table\"]/tbody/tr[1]/td[2][text()='Graphics & Design']")).GetAttribute("textContent");//tr[last()]
                var titlecheck = driver.FindElement(By.XPath($".//table[@class=\"ui striped table\"]/tbody/tr[1]/td[3][text()='{RuntimeData.tags}{randnum}']")).GetAttribute("textContent");
                var descriptioncheck = driver.FindElement(By.XPath($".//table[@class=\"ui striped table\"]/tbody/tr[1]/td[4][text()='{RuntimeData.tags}{randnum}']")).GetAttribute("textContent");
                //Console.WriteLine($"categorycheck,titlecheck,descriptioncheck:{categorycheck},{titlecheck},{descriptioncheck}");
                Assert.That(categorycheck == "Graphics & Design" && titlecheck == $"{RuntimeData.tags}{randnum}" && descriptioncheck == $"{RuntimeData.tags}{randnum}");
            }
            catch (Exception ex)
            {
                Assert.Fail("verify the share skill page failed", ex.Message);
            }
        }


   


    }
}
