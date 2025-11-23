using BoDi;
using CPP_Lab7.Drivers;
using CPP_Lab7.Utils;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CPP_Lab7.Hooks;

[Binding]
public sealed class Hooks
{
    private readonly IObjectContainer _container;
    private IWebDriver _driver;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void BeforeScenario(ScenarioContext context)
    {
        _driver = DriverFactory.CreateDriver();
        _container.RegisterInstanceAs<IWebDriver>(_driver);
        context.Set(_driver);
    }

    [AfterScenario]
    public void AfterScenario(ScenarioContext context)
    {
        if (context.TestError != null)
        {
            ScreenshotHelper.TakeScreenshot(_driver, context.ScenarioInfo.Title);
        }

        _driver.Quit();
    }
}