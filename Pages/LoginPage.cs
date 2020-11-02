using Mars.Helpers;
using Mars.StepDefinitions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace Mars.Pages
{
    class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {          
            // launch log in page
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // maximise web browser
            driver.Manage().Window.Maximize();

            // refresh current page
            driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // click Sign In
            //driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a")).Click();
            driver.FindElement(By.LinkText("Sign In")).Click();

            // email address
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys($"{RuntimeData.email}");

            // password
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys($"{RuntimeData.password}");

            // click on verify email button //driver.FindElement(By.Id("submit-btn")).Click();

            // click on log in
            //driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
            driver.FindElement(By.XPath("//div[4]/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //string text = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Text; //Assert.IsTrue(text.Contains("Login"));
           
            // validate log in
            try
            {
                //IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.ClassName("title")).ToArray();
                ////Console.WriteLine("elements count：{0}", elements.Count);
                ////var elementlist = elements.ToArray();
                ////for (int i = 0; i < elements.Count; i++)
                //foreach (var element in elements)
                //{
                //    Console.WriteLine(element.Text);
                //}
                //Assert.That($"Seller1 Gao" == "Seller1 Gao");

                var logincheck = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span[text()='{RuntimeData.firstName}']")).GetAttribute("innerText");
                //Console.Write($"logincheck:{logincheck}");
                Assert.That(logincheck == "Hi " + RuntimeData.firstName);
            }
            catch (Exception ex)
            {
                Assert.Fail("validate log in failed", ex.Message);
            }
        }        
    }
}
