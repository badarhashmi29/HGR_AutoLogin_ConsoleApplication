using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace HGR_CA
{
    class Program
    {
        static void Main(string[] args)
        {
            /*EYROX.COM*/
            //In this Console Application, we are Using OpenQA Selenium Library 
            //Initializing Driver for HGR Login process - Function will call and set the desired option for Browser Window Settings
            var HGRWebDriver = HGRLaunchChromeBrowser();
            try
            {
                //Initializing and Calling HGRLogin Method
                HGR_AutoLoginProcess HGRLP = new HGR_AutoLoginProcess(HGRWebDriver);
                var WebDriver = HGRLP.HGRLogin("https://app.hustlegotreal.com/Account/Login", "testing@hustlegotreal.com", "HGR2021");

                //Waiting for the Login Process to Complete and the next method will call 
                var Wait_HGR_Response = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
                //Getting Desired Value From the Home Screen. Class is same so used Class Indexing 
                var HGR_Desired_Value = Wait_HGR_Response.Until(wd => wd.FindElement(By.XPath("(//*[@class='value'])[2]"))).Text;
                //Printing the Value on the Console Screen
                Console.WriteLine("\n HGR Desired Value = {0} \n", HGR_Desired_Value);
                Console.ReadLine();
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured While Login Process");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                HGRWebDriver.Quit();
            }
        }

        static IWebDriver HGRLaunchChromeBrowser()
        {
            //Setting Options for the Browser Screen
            var Chrome_Window_Options = new ChromeOptions();
            Chrome_Window_Options.AddArgument("--start-maximized");
            Chrome_Window_Options.AddArgument("--disable-notifications");
            var NewDriver = new ChromeDriver(Environment.CurrentDirectory, Chrome_Window_Options);
            return NewDriver;
        }
    }
}
