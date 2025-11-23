using CPP_Lab6.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CPP_Lab6.Steps;

[Binding]
public class SignUpSteps
{
    private IWebDriver _driver;
    private HomePage _homePage;

    [Given("the user opens the Home page for sign up")]
    public void GivenTheUserOpensTheHomePageForSignUp()
    {
        _driver = new FirefoxDriver();
        _driver.Manage().Window.Maximize();

        _homePage = new HomePage(_driver);
        _homePage.Open();
    }

    [When("the user clicks the Sign Up button")]
    public void WhenTheUserClicksTheSignUpButton()
    {
        _homePage.ClickSignUp();
    }

    [When("the sign up modal appears")]
    public void WhenTheSignUpModalAppears()
    {
        _homePage.DebugModalContent();
        
        Assert.IsTrue(_homePage.IsSignUpModalVisible(),
            "Sign Up modal is not visible after clicking the Sign Up button.");
    }

    [When("the user fills the sign up form with \"(.*)\", \"(.*)\", \"(.*)\", \"(.*)\"")]
    public void WhenTheUserFillsTheSignUpForm(string name, string email, string password, string confirmPassword)
    {
        _homePage.FillSignUpForm(name, email, password, confirmPassword);
    }

    [When("the user clicks the Sign Up submit button")]
    public void WhenTheUserClicksTheSignUpSubmitButton()
    {
        _homePage.ClickSignUpSubmit();
    }

    [Then("the user should be redirected to the home page")]
    public void ThenTheUserShouldBeRedirectedToTheHomePage()
    {
        Assert.IsTrue(_homePage.IsRedirectedToHomePage(),
            "User was not redirected to the home page after sign up.");
        
        _driver.Quit();
    }
}
