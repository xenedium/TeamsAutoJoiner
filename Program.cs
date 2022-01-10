using System;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TeamsAutoJoiner
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            var chromeDriver = new ChromeDriver(@"D:\");
            Log.Info("Chrome driver loaded.");

            var config = await Config.CreateAsync("config.json");
            
            try
            {
                new LogIn(chromeDriver, config.EmailId, config.PasswordId, config.SubmitId, config.Email, config.Password, config.Timeout)
                    .Start();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            
            
            
            await Task.Delay(-1);   //wait indefinitely
        }
    }
}