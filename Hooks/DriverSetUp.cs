using System;
using System.Configuration;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CSharpChallengeAngelicaSamir.Hooks
{
    public class DriverSetUp
    {
        protected ChromeDriver _driver;
        protected WebDriverWait _wait;
        protected Actions _actions;
        private readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver
            {
                Url = BaseUrl
            };
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
        }

        [TearDown]
         public void TearDown()
         {
             _driver.Close();
             _driver.Quit();
         }
    }
}
