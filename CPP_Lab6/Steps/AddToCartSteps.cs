using CPP_Lab6.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CPP_Lab6.Steps;

[Binding]
public class AddToCartSteps
{
    private IWebDriver _driver;
    private HomePage _homePage;

    [Given("the user opens the product page for add to cart test")]
    public void GivenTheUserOpensTheProductPageForAddToCartTest()
    {
        _driver = new FirefoxDriver();
        _driver.Manage().Window.Maximize();

        _homePage = new HomePage(_driver);
        _homePage.Open();
    }

    [When("the user clicks the Add to Cart button")]
    public void WhenTheUserClicksTheAddToCartButton()
    {
        _homePage.ClickAddToCart();
    }

    [Then("the product should be added to the cart")]
    public void ThenTheProductShouldBeAddedToTheCart()
    {
        Assert.IsTrue(_homePage.IsProductAddedToCart(),
            "Product was not added to cart successfully.");
        
        _driver.Quit();
    }
}
