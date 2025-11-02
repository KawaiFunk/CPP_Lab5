using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CPP_Lab_5;

[TestFixture]
public class Search999Test
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    [SetUp]
    public void Setup()
    {
        var options = new FirefoxOptions();
        _driver = new FirefoxDriver(options);
        _driver.Manage().Window.Maximize();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [Test]
    public void Search999_HeaderDisplayed()
    {
        _driver.Navigate().GoToUrl("https://999.md");
        var searchBox = _wait.Until(
            ExpectedConditions.ElementToBeClickable(
                By.CssSelector("input[placeholder='Căutare în anunțuri']")
            )
        );
        searchBox.SendKeys("computer");
        searchBox.SendKeys(Keys.Enter);


        var header = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("header")));
        Assert.That(header.Displayed, "999.md header should be visible after search.");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}