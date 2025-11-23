using CPP_Lab6.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CPP_Lab6.Steps;

[Binding]
public class HomePageSteps
{
    private IWebDriver _driver;
    private HomePage _homePage;

    [Given("the user opens the Home page")]
    public void GivenTheUserOpensTheHomePage()
    {
        _driver = new FirefoxDriver();
        _driver.Manage().Window.Maximize();

        _homePage = new HomePage(_driver);
        _homePage.Open();
    }

    [Then("the main elements are displayed")]
    public void ThenTheMainElementsAreDisplayed()
    {
        Assert.IsTrue(_homePage.IsLoaded(),
            "Home page elements are not displayed correctly.");

        _driver.Quit();
    }
}