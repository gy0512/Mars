using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Mars.Pages
{
    class SkillListPage
    {
        public void SearchSkill(IWebDriver driver)
        {
            // search the skill
            driver.FindElement(By.XPath("//input[@type='text']")).Click();
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("Locust");
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(Keys.Enter);

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

        public void FindSkill(IWebDriver driver)
        {
            // turn to last page
            driver.FindElement(By.XPath("//div[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[3]/div[2]/div")).Click();           
            try
            {
                var usernamecheck = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[last()]/div[1]/a[1][text()='Gary Gao']")).GetAttribute("textContent");
                var tagskillcheck = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[last()]/div[1]/a[2]/p[text()='Locust']")).GetAttribute("textContent");
                Console.WriteLine($"usernamecheck,tagskillcheck:{usernamecheck},{tagskillcheck}");
                Assert.That(usernamecheck == "Gary Gao" && tagskillcheck == "Locust");
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
                var titlecheck = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span[text()='Locust']")).GetAttribute("textContent");
                var descriptioncheck = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2][text()='Locust']")).GetAttribute("textContent");
                Console.WriteLine($"categorycheck,titlecheck,descriptioncheck:{categorycheck},{titlecheck},{descriptioncheck}");
                Assert.That(categorycheck == "Graphics & Design" && titlecheck == "Locust" && descriptioncheck == "Locust");
            }
            catch (Exception ex)
            {
                Assert.Fail("validate skill card detail failed", ex.Message);
            }
        }




    }
}
