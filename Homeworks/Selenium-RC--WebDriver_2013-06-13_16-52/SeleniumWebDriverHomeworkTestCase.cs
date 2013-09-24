using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumWebDriverHomeworkTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://test.telerikacademy.com/SoftwareAcademy/Candidate";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheSeleniumWebDriverHomeworkTestCaseTest()
        {
            driver.Navigate().GoToUrl("http://test.telerikacademy.com/SoftwareAcademy/Candidate");
            driver.FindElement(By.Id("UsernameOrEmail")).Clear();
            driver.FindElement(By.Id("UsernameOrEmail")).SendKeys("qaacademy2013");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("qastudent");
            driver.FindElement(By.CssSelector("input.submit-button")).Click();
            driver.FindElement(By.Id("FirstName")).Clear();
            driver.FindElement(By.Id("FirstName")).SendKeys("QA");
            driver.FindElement(By.Id("SecondName")).Clear();
            driver.FindElement(By.Id("SecondName")).SendKeys("QA");
            driver.FindElement(By.Id("LastName")).Clear();
            driver.FindElement(By.Id("LastName")).SendKeys("QA");
            driver.FindElement(By.CssSelector("span.k-icon.k-i-calendar")).Click();
            driver.FindElement(By.LinkText("1900 - 1909")).Click();
            driver.FindElement(By.LinkText("1900")).Click();
            driver.FindElement(By.LinkText("ян")).Click();
            driver.FindElement(By.LinkText("1")).Click();
            driver.FindElement(By.Id("Phone")).Clear();
            driver.FindElement(By.Id("Phone")).SendKeys("0881235467");
            driver.FindElement(By.Id("SchoolName")).Clear();
            driver.FindElement(By.Id("SchoolName")).SendKeys("myschool");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("");
            driver.FindElement(By.XPath("//*[@id=\"SendButton\"]")).Click();
            try
            {
                Assert.AreEqual("Имейл адресът е задължителен.", driver.FindElement(By.XPath("//html/body/div/div/section/form/fieldset/div[12]/span/span")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [getEval | generateUniqueAccountName("email") | ]]
            Console.WriteLine(newUniqueEmail);
            String newUniqueEmail = newUniqueEmail + "@abv.bg";
            Console.WriteLine(newUniqueEmail);
            driver.FindElement(By.XPath("//*[@id=\"Email\"]")).Clear();
            driver.FindElement(By.XPath("//*[@id=\"Email\"]")).SendKeys(newUniqueEmail);
            driver.FindElement(By.XPath("//*[@id=\"Email\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"FacultyName\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"SendButton\"]")).Click();
            // Warning: verifyTextNotPresent may require manual changes
            try
            {
                Assert.IsFalse(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Имейл адресът е задължителен\\.[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//*[@id=\"ExitMI\"]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
