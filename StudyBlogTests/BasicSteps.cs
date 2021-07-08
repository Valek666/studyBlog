using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StudyBlogTests
{
    public class BasicSteps : IDisposable
    {
        private readonly IWebDriver _driver;
        private const string MainPageUrl = "http://localhost:5000";
        private const string LoginPageUrl = MainPageUrl + "/Account/Login";

        public BasicSteps()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        public bool IsElementFound(string text)
        {
            var element = _driver.FindElement(By.XPath($"//*[contains(text(), '{text}')]"));
            return element != null;
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void GoToMainPage()
        {
            GoToUrl(MainPageUrl);
        }

        public void GoToLoginPage()
        {
            GoToUrl(LoginPageUrl);
        }

        public void ClickLink(string linkText)
        {
            var link = _driver.FindElement(By.LinkText(linkText));
            link.Click();
        }

        public void ClickButtonById(string id)
        {
            _driver.FindElement(By.Id(id)).Click();
        }

        public void FillFormField(string fieldId, string inputText)
        {
            var field = _driver.FindElement(By.Id(fieldId));
            field.SendKeys(inputText);
        }
    }
}