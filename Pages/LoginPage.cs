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
            // refresh current page
            driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // click Sign In
            //driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a")).Click();
            driver.FindElement(By.LinkText("Sign In")).Click();

            // email address
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("0512gaoyuan@gmail.com");

            // password
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("123123");

            // click on verify email button
            //driver.FindElement(By.Id("submit-btn")).Click();

            // click on log in
            //driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
            driver.FindElement(By.XPath("//div[4]/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            //string text = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Text;
            //Assert.IsTrue(text.Contains("Login"));

            // validate log in
            try
            {
                //String logincheck = driver.FindElement(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.four.wide.column > div > div > div > div > div > div:nth-child(2) > div > div > div.title")).GetAttribute("innerText");
                //logincheck = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]")).GetAttribute("innerText");
                var logincheck = driver.FindElement(By.XPath("//*[contains(text(),'Gary Gao')]")).GetAttribute("innerText");
                //Console.Write($"logincheck:{logincheck}");
                Assert.That(logincheck == "Gary Gao");

                //IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.ClassName("title")).ToArray();
                ////Console.WriteLine("elements count：{0}", elements.Count);
                ////var elementlist = elements.ToArray();
                ////for (int i = 0; i < elements.Count; i++)
                //foreach (var element in elements)
                //{
                //    Console.WriteLine(element.Text);
                //}
                //Assert.That($"Seller1 Gao" == "Seller1 Gao");


                //IWebElement logIn = driver.FindElement(By.XPath("//*[@id=\"account - profile - section\"]/div/div[1]/div[2]/div/span"));
                //Console.Write($"logIn:{logIn}");
                //Assert.That(logIn.Text == "Seller1");                
            }
            catch (Exception ex)
            {
                Assert.Fail("validate log in failed", ex.Message);
            }
        }
    }
}
