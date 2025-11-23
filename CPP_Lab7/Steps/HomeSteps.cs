using CPP_Lab7.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CPP_Lab7.Steps;

[Binding]
public class HomeSteps
{
    private readonly GoogleHomePage _homePage;

    public HomeSteps(IWebDriver driver)
    {
        _homePage = new GoogleHomePage(driver);
    }

    [Given("I open Google Home page")]
    public void OpenGoogle()
    {
        _homePage.Navigate();
    }

    [Then("Google homepage should be displayed")]
    public void HomeDisplayed()
    {
        Assert.True(_homePage.IsDisplayed());
    }

    [When("I search for \"(.*)\"")]
    public void Search(string text)
    {
        _homePage.Type(text);
        _homePage.ClickSearch();
    }

    [When("I click search with empty field")]
    public void ClickEmpty()
    {
        _homePage.ClickSearchButton();
    }

    [Then("Google homepage should remain displayed")]
    public void HomeStillDisplayed()
    {
        Assert.True(_homePage.IsDisplayed());
    }
}