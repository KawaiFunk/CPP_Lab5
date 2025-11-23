using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CPP_Lab7.Pages;

public class GoogleHomePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public GoogleHomePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement SearchBox => _driver.FindElement(By.Name("q"));

    public void Navigate() =>
        _driver.Navigate().GoToUrl("https://www.google.co.in");

    public bool IsDisplayed() => SearchBox.Displayed;

    public void Type(string text) => SearchBox.SendKeys(text);

    public void ClickSearch() 
    {
        SearchBox.SendKeys(Keys.Enter);
    }

    public void ClickSearchButton()
    {
        try
        {
            var button = _wait.Until(d => d.FindElement(By.Name("btnK")));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", button);
            System.Threading.Thread.Sleep(500);
            button.Click();
        }
        catch (ElementNotInteractableException)
        {
            var button = _driver.FindElement(By.Name("btnK"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", button);
        }
    }
}