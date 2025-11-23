using OpenQA.Selenium;

namespace CPP_Lab7.Utils;

public static class ScreenshotHelper
{
    public static void TakeScreenshot(IWebDriver driver, string name)
    {
        var ss = ((ITakesScreenshot)driver).GetScreenshot();
        var file = $"{name.Replace(" ", "_")}.png";

        ss.SaveAsFile(file);
    }
}