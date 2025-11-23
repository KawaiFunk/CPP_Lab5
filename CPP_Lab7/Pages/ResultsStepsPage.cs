using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CPP_Lab7.Pages;

public class GoogleResultsPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public GoogleResultsPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    private IReadOnlyCollection<IWebElement> Results =>
        _driver.FindElements(By.CssSelector("div.MjjYud"));
    
    public int GetResultsCount() 
    {
        Thread.Sleep(2000);
        
        try
        {
            _wait.Until(d => d.FindElements(By.CssSelector("div.MjjYud")).Count > 0);
            return Results.Count;
        }
        catch
        {
            return 0;
        }
    }

    public bool IsDidYouMeanVisible()
    {
        Thread.Sleep(2000);
        
        try 
        { 
            var spellContainer = _wait.Until(d => d.FindElement(By.CssSelector("div.QRYxYe")));
            return spellContainer.Displayed;
        }
        catch 
        {
            try
            {
                var searchInstead = _wait.Until(d => d.FindElement(By.XPath("//span[contains(text(),'Search instead for')]")));
                return searchInstead.Displayed;
            }
            catch
            {
                try
                {
                    var spellLink = _wait.Until(d => d.FindElement(By.CssSelector("a[href*='nfpr=1']")));
                    return spellLink.Displayed;
                }
                catch
                {
                    try
                    {
                        var didYouMean = _wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'These are results for') or contains(text(),'Search instead for')]")));
                        return didYouMean.Displayed;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
    }
}