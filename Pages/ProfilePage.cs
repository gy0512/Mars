using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Mars.Pages
{
    class ProfilePage
    {
        public void CreateDescription(IWebDriver driver)
        {
            // click the description icon button
            driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i")).Click();

            // description
            driver.FindElement(By.Name("value")).Click();
            driver.FindElement(By.Name("value")).Clear();
            driver.FindElement(By.Name("value")).SendKeys("Gary Gao profile description");

            // save
            driver.FindElement(By.XPath("//button[@type='button']")).Click();

            // verify description
            try
            {
                var descriptioncheck = "test";
                //driver.FindElement(By.XPath("//*[@id=\"account - profile - section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span")).Click();
                //descriptioncheck = driver.FindElement(By.XPath("//*[@id=\"account - profile - section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span")).GetAttribute("innerText");
                descriptioncheck = driver.FindElement(By.XPath("//*[contains(text(),'Gary Gao profile description')]")).GetAttribute("textContent");
                Console.WriteLine($"descriptioncheck:{descriptioncheck}");
                Assert.That(descriptioncheck == "Gary Gao profile description");           
            }
            catch (Exception ex)
            {
                Assert.Fail("verify description failed", ex.Message);
            }         
        }

        public void AddNewLanguage(IWebDriver driver)
        {
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
                var languagecheck1 = "test";
                var languagecheck2 = "test";
                languagecheck1 = driver.FindElement(By.XPath(".//table[@class=\"ui fixed table\"]/tbody/tr/td[text()='English']")).GetAttribute("textContent");
                languagecheck2 = driver.FindElement(By.XPath(".//table[@class=\"ui fixed table\"]/tbody/tr/td[text()='Basic']")).GetAttribute("textContent");
                Console.WriteLine($"languagecheck:{languagecheck1},{languagecheck2}");
                Assert.That(languagecheck1 == "English" && languagecheck2 == "Basic");
            }
            catch (Exception ex)
            {
                Assert.Fail("verify new language failed", ex.Message);
            }
        }

    }
}
