using CPP_Lab7.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CPP_Lab7.Steps;

[Binding]
public class ResultsSteps
{
    private readonly GoogleResultsPage _results;

    public ResultsSteps(IWebDriver driver)
    {
        _results = new GoogleResultsPage(driver);
    }

    [Then("Search results should be displayed")]
    public void ResultsDisplayed()
    {
        Assert.True(_results.GetResultsCount() > 0);
    }

    [Then("Did you mean should appear")]
    public void DidYouMeanShouldAppear()
    {
        Assert.True(_results.IsDidYouMeanVisible());
    }
}