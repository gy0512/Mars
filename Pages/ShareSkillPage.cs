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

            // verify the share skill page
            try
            {
                var gotoshareskillpagecheck = "test";
                gotoshareskillpagecheck = driver.FindElement(By.XPath(".//div[@class=\"tooltip-target vertically padded ui grid\"]/div/div[2]/div/div[2]/p[text()='100']")).GetAttribute("textContent");
                Console.Write($"gotoshareskillpagecheck:{gotoshareskillpagecheck}");
                Assert.That(gotoshareskillpagecheck == "Characters remaining: 100");
            }
            catch (Exception ex)
            {
                Assert.Fail("validate go to share skill page failed", ex.Message);
            }
        }

        public void CreateShareSkill(IWebDriver driver)
        {
            // title
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys("Locust");

            // description
            driver.FindElement(By.Name("description")).Click();
            driver.FindElement(By.Name("description")).Clear();
            driver.FindElement(By.Name("description")).SendKeys("Locust");

            // category
            driver.FindElement(By.Name("categoryId")).Click();
            new SelectElement(driver.FindElement(By.Name("categoryId"))).SelectByText("Graphics & Design");
            //driver.FindElement(By.Name("categoryId")).Click();


            // subcategory
            driver.FindElement(By.Name("subcategoryId")).Click();
            new SelectElement(driver.FindElement(By.Name("subcategoryId"))).SelectByText("Logo Design");
            //driver.FindElement(By.Name("subcategoryId")).Click();

            // tags
            driver.FindElement(By.XPath("//input[@value='']")).Click();
            //driver.FindElement(By.XPath("//input[@value='']")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//input[@value='']")).Clear();
            driver.FindElement(By.XPath("//input[@value='']")).SendKeys("Locust2");
            driver.FindElement(By.XPath("//input[@value='']")).SendKeys(Keys.Enter);

            // service type
            driver.FindElement(By.XPath("(//input[@name='serviceType'])[2]")).Click();

            // Llocation type
            driver.FindElement(By.Name("locationType")).Click();

            // available days - start date
            driver.FindElement(By.Name("startDate")).Click();
            driver.FindElement(By.Name("startDate")).Clear();
            driver.FindElement(By.Name("startDate")).SendKeys("2020-10-31");

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
            driver.FindElement(By.XPath("(//input[@value=''])[15]")).SendKeys("JMeter");
            driver.FindElement(By.XPath("(//input[@value=''])[15]")).SendKeys(Keys.Enter);

            // work samples //to be continued

            // active
            driver.FindElement(By.XPath("(//input[@name='isActive'])[2]")).Click();//hidden
            driver.FindElement(By.Name("isActive")).Click();//active

            // save
            driver.FindElement(By.XPath("//input[@value='Save']")).Click();



            // verify the share skill page
            try
            {
                
                var shareskillcheck1 = "test";
                var shareskillcheck2 = "test";
                var shareskillcheck3 = "test";
                shareskillcheck1 = driver.FindElement(By.XPath(".//table[@class=\"ui striped table\"]/tbody/tr/td[2][text()='Graphics & Design']")).GetAttribute("textContent");
                shareskillcheck2 = driver.FindElement(By.XPath(".//table[@class=\"ui striped table\"]/tbody/tr/td[3][text()='Locust']")).GetAttribute("textContent");
                shareskillcheck3 = driver.FindElement(By.XPath(".//table[@class=\"ui striped table\"]/tbody/tr/td[4][text()='Locust']")).GetAttribute("textContent");
                Console.Write($"languagecheck:{shareskillcheck1},{shareskillcheck2},{shareskillcheck3}");
                Assert.That(shareskillcheck1 == "Graphics & Design" && shareskillcheck2 == "Locust" && shareskillcheck3 == "Locust");
            }
            catch (Exception ex)
            {
                Assert.Fail("verify the share skill page failed", ex.Message);
            }
        }


   


    }
}
