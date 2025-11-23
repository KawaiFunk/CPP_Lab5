using CPP_Lab6.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CPP_Lab6.Steps;

[Binding]
public class ShopNowSteps
{
    private IWebDriver _driver;
    private HomePage _homePage;

    [Given("the user is on the Home page for sale")]
    public void GivenTheUserIsOnTheHomePageForSale()
    {
        _driver = new FirefoxDriver();
        _driver.Manage().Window.Maximize();

        _homePage = new HomePage(_driver);
        _homePage.Open();
    }

    [When("the user clicks the Shop Now button")]
    public void WhenTheUserClicksTheShopNowButton()
    {
        _homePage.ClickShopNow();
    }

    [Then("the Sale page should load successfully")]
    public void ThenTheSalePageShouldLoadSuccessfully()
    {
        Assert.IsTrue(_homePage.IsSalePageLoaded(),
            "The Sale page did not load correctly after clicking Shop Now.");

        _driver.Quit();
    }
}