using CPP_Lab6.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CPP_Lab6.Steps;

[Binding]
public class SearchSteps
{
    private IWebDriver _driver;
    private HomePage _homePage;

    [Given("the user is on the Home page")]
    public void GivenTheUserIsOnTheHomePage()
    {
        _driver = new FirefoxDriver();
        _driver.Manage().Window.Maximize();

        _homePage = new HomePage(_driver);
        _homePage.Open();
    }

    [When("the user clicks the search button without typing anything")]
    public void WhenTheUserClicksWithoutText()
    {
        _homePage.ClickSearchEmpty();
    }

    [Then("a validation error should be shown")]
    public void ThenAValidationErrorShouldBeShown()
    {
        Assert.IsTrue(_homePage.IsValidationErrorTriggered());
        _driver.Quit();
    }
}