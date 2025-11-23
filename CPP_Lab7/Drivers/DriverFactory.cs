using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CPP_Lab7.Drivers;

public static class DriverFactory
{
    public static IWebDriver CreateDriver()
    {
        var options = new FirefoxOptions();
        options.AddArgument("--start-maximized");

        return new FirefoxDriver(options);
    }
}