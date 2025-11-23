using CPP_Lab6.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CPP_Lab6.Steps;

[Binding]
public class BackToTopSteps
{
    private IWebDriver _driver;
    private HomePage _homePage;

    [Given("the user opens the Home page for back to top test")]
    public void GivenTheUserOpensTheHomePageForBackToTopTest()
    {
        _driver = new FirefoxDriver();
        _driver.Manage().Window.Maximize();

        _homePage = new HomePage(_driver);
        _homePage.Open();
    }

    [When("the user scrolls down the page")]
    public void WhenTheUserScrollsDownThePage()
    {
        _homePage.ScrollDown();
    }

    [Then("the back to top button should become visible")]
    public void ThenTheBackToTopButtonShouldBecomeVisible()
    {
        Assert.IsTrue(_homePage.IsBackToTopButtonVisible(),
            "Back to top button should be visible after scrolling down.");
    }

    [When("the user clicks the back to top button")]
    public void WhenTheUserClicksTheBackToTopButton()
    {
        _homePage.ClickBackToTopButton();
    }

    [Then("the page should scroll back to the top")]
    public void ThenThePageShouldScrollBackToTheTop()
    {
        Assert.IsTrue(_homePage.IsAtTopOfPage(),
            "Page should be scrolled back to the top after clicking back to top button.");
        
        _driver.Quit();
    }
}
