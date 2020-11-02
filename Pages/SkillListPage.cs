using Mars.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Mars.Pages
{
    class SkillListPage
    {
        public void SearchSkill(IWebDriver driver, long randnum)
        {
            // search the skill
            driver.FindElement(By.XPath("//input[@type='text']")).Click();
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys($"{RuntimeData.tags}{randnum}");
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);

            // verify the share skill page
            try
            {   
                var skillsearchresult = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/h3[text()='Refine Results']")).GetAttribute("textContent");
                Console.WriteLine($"skillsearchresult:{skillsearchresult}");
                Assert.That(skillsearchresult == "Refine Results");
            }
            catch (Exception ex)
            {
                Assert.Fail("validate skill search result failed", ex.Message);
            }
        }

        public void FindSkill(IWebDriver driver, long randnum)
        {
            // turn to last page
            //var resultcount = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span")).GetAttribute("innerText");
            driver.FindElement(By.XPath("//div[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[3]/div[2]/div")).Click();           
            try
            {
                var usernamecheck = driver.FindElement(By.XPath($"//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[last()]/div[1]/a[1][text()='{RuntimeData.firstName} {RuntimeData.lastName}']")).GetAttribute("textContent");
                var tagskillcheck = driver.FindElement(By.XPath($"//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[last()]/div[1]/a[2]/p[text()='{RuntimeData.tags}{randnum}']")).GetAttribute("textContent");
                //Console.WriteLine($"usernamecheck,tagskillcheck:{usernamecheck},{tagskillcheck}");
                Assert.That(usernamecheck == "Gary Gao" && tagskillcheck == $"{RuntimeData.tags}{randnum}");
            }
            catch (Exception ex)
            {
                Assert.Fail("validate skill card failed", ex.Message);
            }


            // click the skill card on the last record
            driver.FindElement(By.XPath("//div[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[last()]/div/a[2]/p")).Click();

            // verify the category, title and description details
            try
            {
                var categorycheck = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2][text()='Graphics & Design']")).GetAttribute("textContent");
                var titlecheck = driver.FindElement(By.XPath($"//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span[text()='{RuntimeData.tags}{randnum}']")).GetAttribute("textContent");
                var descriptioncheck = driver.FindElement(By.XPath($"//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2][text()='{RuntimeData.tags}{randnum}']")).GetAttribute("textContent");
                //Console.WriteLine($"categorycheck,titlecheck,descriptioncheck:{categorycheck},{titlecheck},{descriptioncheck}");
                Assert.That(categorycheck == "Graphics & Design" && titlecheck == $"{RuntimeData.tags}{randnum}" && descriptioncheck == $"{RuntimeData.tags}{randnum}");
            }
            catch (Exception ex)
            {
                Assert.Fail("validate skill card detail failed", ex.Message);
            }
        }
    }
}
