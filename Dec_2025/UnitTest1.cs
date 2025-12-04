using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace Nov24th2025
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            // driver=new EdgeDriver();
            //driver=new FirefoxDriver();
            ChromeOptions options = new ChromeOptions();

            driver = new ChromeDriver(options);
            // driver =new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://tutorialsninja.com/demo/index.php?");
            Assert.That(driver.Title.Equals("Your Store"));
            Assert.That(driver.Url.Equals("https://tutorialsninja.com/demo/index.php?"));
            IWebElement myaccount = driver.FindElement(By.LinkText("My Account"));
            if (myaccount.Displayed)
            {
                myaccount.Click();
            }

            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("input-firstname")).SendKeys("leena");
            driver.FindElement(By.Id("input-lastname")).SendKeys("kumari");
            driver.FindElement(By.Id("input-email")).SendKeys("abcrrrrrr@gmail.com");
            driver.FindElement(By.Id("input-telephone")).SendKeys("1234567890");
            driver.FindElement(By.Id("input-password")).SendKeys("welcome");
            driver.FindElement(By.Id("input-confirm")).SendKeys("welcome");

            IWebElement nooption = driver.FindElement(By.CssSelector("input[name='newsletter'][value='0']"));

            nooption.Click();
            if (nooption.Selected)
            {
                Console.WriteLine("No option is selected");

            }

            driver.FindElement(By.Name("agree")).Click();

            driver.FindElement(By.CssSelector("input[type='submit'][value='Continue']")).Click();



        }
        [Test]
        public void findelements()
        {

            driver.Navigate().GoToUrl("https://www.amazon.in/");
            IReadOnlyCollection<IWebElement> amazonlinks = driver.FindElements(By.TagName("a"));
            List<IWebElement> amazonlinks2 = amazonlinks.ToList();
            foreach (var link in amazonlinks2)
            {
                Console.WriteLine(link.Text);

            }


        }
        [Test]
        public void usingkeys()
        {
            driver.Navigate().GoToUrl("https://tutorialsninja.com/demo/index.php?");
            IWebElement myaccount = driver.FindElement(By.LinkText("My Account"));
            if (myaccount.Displayed)
            {
                myaccount.Click();
            }

            driver.FindElement(By.LinkText("Register")).Click();
            IWebElement firstname = driver.FindElement(By.Id("input-firstname"));

            firstname.Click();
            firstname.SendKeys(Keys.Tab);
            firstname.SendKeys(Keys.Tab);




        }
        [Test]
        public void dropdown()
        {

            driver.Navigate().GoToUrl("https://tutorialsninja.com/demo/index.php?");
            driver.FindElement(By.LinkText("Desktops")).Click();
            driver.FindElement(By.LinkText("Mac (1)")).Click();
            SelectElement sortsize = new SelectElement(driver.FindElement(By.Id("input-sort")));
            sortsize.SelectByIndex(4);



        }

        [Test]
        public void alerts()
        {
            driver.Navigate().GoToUrl("https://letcode.in/alert");
            driver.FindElement(By.Id("accept")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
            alert.Accept();

            driver.FindElement(By.Id("confirm")).Click();
            IAlert confirm = driver.SwitchTo().Alert();
            Console.WriteLine(confirm.Text);
            confirm.Accept();

            driver.FindElement(By.Id("prompt")).Click();
            IAlert prompt = driver.SwitchTo().Alert();
            Console.WriteLine(prompt.Text);
            prompt.SendKeys("ggggggg");
            prompt.Accept();


            driver.FindElement(By.Id("modern")).Click();
            // IAlert modern = driver.SwitchTo().Alert();
            //Console.WriteLine(modern.Text);
            driver.FindElement(By.XPath("//button[@aria-label='close']")).Click();






        }

        [Test]
        public void Notificationpopup()
        {
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
            alert.Accept();

        }

        [TearDown]
        public void quit1()
        {
            // driver.Quit();

        }
    }
}
