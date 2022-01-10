using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace TeamsAutoJoiner
{
    public class LogIn
    {
        private readonly ChromeDriver _chromeDriver;    //webdriver
        private readonly WebDriverWait _waiter;         //waiter
        private static string _emailId;                 //ID of the email field in the web page
        private static string _passwordId;              //ID of the password field in the web page
        private static string _submitId;                //ID of the submit button in the web page
        private readonly string _email;                 //email of the client
        private readonly string _password;              //password of the client

        public LogIn(ChromeDriver chromeDriver, string emailId, string passwordId, string submitId, string email, string password, int timeout)
        {
            if (chromeDriver == null || emailId == null || passwordId == null || submitId == null || email == null ||
                password == null)
                throw new Exception("Data provided from json is not valid");
            
            _chromeDriver = chromeDriver;
            _waiter = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(timeout));
            _emailId = emailId;
            _passwordId = passwordId;
            _submitId = submitId;
            _email = email;
            _password = password;
        }

        public void Start()
        {
            _chromeDriver.Manage().Window.Maximize();
            
            Log.Info("Navigating to teams.");
            _chromeDriver.Navigate().GoToUrl("https://teams.microsoft.com/");
            
            Log.Info("Waiting for the page to load");
            
            _waiter.Until(driver => driver.FindElement(By.Id(_emailId))).SendKeys(_email);
            Log.Info("Email written navigating to the password page.");
            Thread.Sleep(2000);
            _waiter.Until(driver => driver.FindElement(By.Id(_submitId))).Click();
            
            _waiter.Until(driver => driver.FindElement(By.Id(_passwordId))).SendKeys(_password);
            Log.Info("Password written navigating to the main page");
            Thread.Sleep(2000);
            _waiter.Until(driver => driver.FindElement(By.Id(_submitId))).Click();

            try
            {
                Thread.Sleep(1000);
                _waiter.Until(driver => driver.FindElement(By.Id(_submitId))).Click();
                Log.Warn("Signin confirmation done.");
            }
            catch 
            {
                Log.Warn("Signing confirmation not found, Skipping");
            }
            
        }
    }
}