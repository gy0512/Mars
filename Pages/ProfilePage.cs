using Mars.Helpers;
using Mars.StepDefinitions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Mars.Pages
{
    class ProfilePage
    {
        public void GotoProfilePage(IWebDriver driver)
        {
            // click the go to profile sub-menu
            driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/div/div[2]/div/span")).Click();
            driver.FindElement(By.LinkText("Go to Profile")).Click();

            // verify the profile page
            try
            {
                var gotoprofilepagecheck = driver.FindElement(By.XPath($"//*[contains(text(),'{RuntimeData.firstName} {RuntimeData.lastName}')]")).GetAttribute("innerText");
                //Console.Write($"gotoprofilepagecheck:{gotoprofilepagecheck}");
                Assert.That(gotoprofilepagecheck == $"{RuntimeData.firstName} {RuntimeData.lastName}");
            }
            catch (Exception ex)
            {
                Assert.Fail("validate go to profile page failed", ex.Message);
            }
        }

        public void CreateDescription(IWebDriver driver, long randnum)
        {
            // click the description icon button
            driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i")).Click();

            // description
            driver.FindElement(By.Name("value")).Click();
            driver.FindElement(By.Name("value")).Clear();
            driver.FindElement(By.Name("value")).SendKeys($"{RuntimeData.firstName} {RuntimeData.lastName} profile description{RuntimeData.currentdatetime}-{randnum}");

            // save
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            // verify description
            try
            {
                var descriptioncheck = driver.FindElement(By.XPath($"//*[contains(text(),'{RuntimeData.firstName} {RuntimeData.lastName} profile description{RuntimeData.currentdatetime}-{randnum}')]")).GetAttribute("textContent");
                Console.WriteLine($"descriptioncheck:{descriptioncheck}");
                Assert.That(descriptioncheck == $"{RuntimeData.firstName} {RuntimeData.lastName} profile description{RuntimeData.currentdatetime}-{randnum}");           
            }
            catch (Exception ex)
            {
                Assert.Fail("verify description failed", ex.Message);
            }         
        }

        public void AddNewLanguage(IWebDriver driver)
        {
            /*
             while traverse whether language has existed in language list
            //languagename //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]
            //languagelevel //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]           
            */

            // click the add new language button
            driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            // input language name
            driver.FindElement(By.Name("name")).Click();
            //driver.FindElement(By.Name("name")).Clear();
            driver.FindElement(By.Name("name")).SendKeys("English");

            // choose language level
            driver.FindElement(By.Name("level")).Click();
            new SelectElement(driver.FindElement(By.Name("level"))).SelectByText("Basic");

            // add new language
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();

            // verify new language
            try
            {
                var languagenamecheck = driver.FindElement(By.XPath(".//table[@class=\"ui fixed table\"]/tbody[last()]/tr/td[text()='English']")).GetAttribute("textContent");
                var languagelevelcheck = driver.FindElement(By.XPath(".//table[@class=\"ui fixed table\"]/tbody[last()]/tr/td[text()='Basic']")).GetAttribute("textContent");
                Console.WriteLine($"languagenamecheck,languagelevelcheck:{languagenamecheck},{languagelevelcheck}");
                Assert.That(languagenamecheck == "English" && languagelevelcheck == "Basic");
            }
            catch (Exception ex)
            {
                Assert.Fail("verify new language failed", ex.Message);
            }
        }

    }
}
