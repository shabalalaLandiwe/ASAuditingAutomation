using System.Text.Json.Nodes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V141.CSS;

namespace SeleniumDocs.GettingStarted;

public static class ASNavigation
{
    public static void Main()
    {
        IWebDriver driver = new ChromeDriver();

//  0. Load credentials
//  NOTE:  json is a dictionary of key-Value pair
        var json = File.ReadAllText("secrets.json");
        var secrets = JsonObject.Parse(json);
        // converting to a string
        string email = secrets["AssetsSonarEmail"].ToString();
        string password = secrets["AssetSonarPassword"].ToString();

//  1. Login to AS
        driver.Navigate().GoToUrl("https://odek.assetsonar.com/login");

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        var emailBox = driver.FindElement(By.Id("email"));
        var passwordBox = driver.FindElement(By.Id("password"));
        var submitButton = driver.FindElement(By.TagName("button"));

        // logging in   
        emailBox.SendKeys(email);
        passwordBox.SendKeys(password);
        submitButton.Click();

//  2. Navigate to assests page
        driver.Navigate().GoToUrl("https://odek.assetsonar.com/assests");

        var title = driver.Title;
        Console.WriteLine("Page title" + title);

//  3.Search for assets  
        
// 4. Update   physical audit date
        driver.Quit();
    }
}