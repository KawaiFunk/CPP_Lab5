using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CPP_Lab6.Pages;

public class HomePage
{
    private readonly IWebDriver _driver;
    private const string Url = "https://adoring-pasteur-3ae17d.netlify.app/";

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void Open()
    {
        _driver.Navigate().GoToUrl(Url);
    }

    public IWebElement Header => _driver.FindElement(By.CssSelector("#home.header"));
    public IWebElement PageContent => _driver.FindElement(By.CssSelector(".banner-bootom-w3-agileits"));
    public IWebElement Coupons => _driver.FindElement(By.CssSelector(".coupons"));
    public IWebElement Footer => _driver.FindElement(By.CssSelector(".footer"));

    public IWebElement SearchInput
    {
        get
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(driver => driver.FindElement(By.CssSelector("input[type='search']")));
        }
    }

    public IWebElement SearchButton
    {
        get
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(driver => driver.FindElement(By.CssSelector("input[type='submit']")));
        }
    }

    public void ClickShopNow()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var shopNowButton = wait.Until(driver =>
        {
            try
            {
                var element = driver.FindElement(By.CssSelector("a.button2[href='/mens']"));
                return element.Displayed && element.Enabled ? element : null;
            }
            catch
            {
                try
                {
                    var altElement =
                        driver.FindElement(By.XPath("//a[contains(@href, 'mens') or contains(text(), 'Shop Now')]"));
                    return altElement.Displayed && altElement.Enabled ? altElement : null;
                }
                catch
                {
                    return null;
                }
            }
        });

        if (shopNowButton != null)
        {
            shopNowButton.Click();
        }
        else
        {
            throw new NoSuchElementException("ShopNow button not found or not clickable");
        }
    }

    public bool IsSalePageLoaded()
    {
        return _driver.Url.Contains("mens")
               || _driver.Title.Contains("Men")
               || _driver.FindElements(By.CssSelector(".page-head_agile_info_w3l")).Count != 0;
    }

    public void ClickSearchEmpty()
    {
        SearchButton.Click();
    }

    public bool IsValidationErrorTriggered()
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver =>
            {
                var searchInput = driver.FindElement(By.CssSelector("input[type='search']"));
                var message = searchInput.GetAttribute("validationMessage");
                return !string.IsNullOrEmpty(message);
            });

            var message = SearchInput.GetAttribute("validationMessage");
            return !string.IsNullOrEmpty(message);
        }
        catch
        {
            var message = SearchInput.GetAttribute("validationMessage");
            return !string.IsNullOrEmpty(message);
        }
    }

    public bool IsLoaded()
    {
        return Header.Displayed
               && PageContent.Displayed
               && Footer.Displayed
               && Coupons.Displayed;
    }

    public void ScrollDown()
    {
        var jsExecutor = (IJavaScriptExecutor)_driver;
        jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight / 2);");

        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        wait.Until(_ =>
        {
            var scrollY = (long)jsExecutor.ExecuteScript("return window.pageYOffset;");
            return scrollY > 0;
        });
    }

    public bool IsBackToTopButtonVisible()
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var backToTopButton = wait.Until(driver =>
            {
                try
                {
                    var button = driver.FindElement(By.CssSelector("a.scroll[href='#home']#toTop"));
                    var display = button.GetCssValue("display");
                    return display != "none" ? button : null;
                }
                catch
                {
                    return null;
                }
            });

            return backToTopButton != null && backToTopButton.Displayed;
        }
        catch
        {
            return false;
        }
    }

    public void ClickBackToTopButton()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var backToTopButton = wait.Until(driver =>
        {
            try
            {
                var button = driver.FindElement(By.CssSelector("a.scroll[href='#home']#toTop"));
                var display = button.GetCssValue("display");
                return display != "none" && button.Displayed && button.Enabled ? button : null;
            }
            catch
            {
                return null;
            }
        });

        if (backToTopButton != null)
        {
            var jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", backToTopButton);
        }
        else
        {
            throw new NoSuchElementException("Back to top button not found or not clickable");
        }
    }

    public bool IsAtTopOfPage()
    {
        try
        {
            var jsExecutor = (IJavaScriptExecutor)_driver;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            wait.Until(_ =>
            {
                var scrollY = (long)jsExecutor.ExecuteScript("return window.pageYOffset;");
                return scrollY == 0;
            });

            var scrollPosition = (long)jsExecutor.ExecuteScript("return window.pageYOffset;");
            return scrollPosition == 0;
        }
        catch
        {
            var jsExecutor = (IJavaScriptExecutor)_driver;
            var scrollPosition = (long)jsExecutor.ExecuteScript("return window.pageYOffset;");
            return scrollPosition == 0;
        }
    }

    public void ClickAddToCart()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var addToCartButton = wait.Until(driver =>
        {
            try
            {
                var button = driver.FindElement(By.CssSelector("input[type='submit'][name='submit'].button"));
                return button.Displayed && button.Enabled ? button : null;
            }
            catch
            {
                try
                {
                    var altButton =
                        driver.FindElement(By.XPath("//input[@type='submit' and contains(@value, 'Add to cart')]"));
                    return altButton.Displayed && altButton.Enabled ? altButton : null;
                }
                catch
                {
                    return null;
                }
            }
        });

        if (addToCartButton != null)
        {
            var jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", addToCartButton);
        }
        else
        {
            throw new NoSuchElementException("Add to Cart button not found or not clickable");
        }
    }

    public bool IsProductAddedToCart()
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var miniCart = wait.Until(driver =>
            {
                try
                {
                    var cart = driver.FindElement(By.CssSelector("#PPMiniCart"));
                    return cart.Displayed ? cart : null;
                }
                catch
                {
                    return null;
                }
            });

            return miniCart != null && miniCart.Displayed;
        }
        catch
        {
            return false;
        }
    }

    public void ClickSignUp()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var jsExecutor = (IJavaScriptExecutor)_driver;

        var signUpButton = wait.Until(driver =>
        {
            try
            {
                var button = driver.FindElement(By.CssSelector("a[data-target='#myModal2']"));
                return button.Displayed && button.Enabled ? button : null;
            }
            catch
            {
                return null;
            }
        });

        if (signUpButton != null)
        {
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", signUpButton);
            Thread.Sleep(500);
            jsExecutor.ExecuteScript("arguments[0].click();", signUpButton);
        }
        else
        {
            throw new NoSuchElementException("Sign Up button not found or not clickable");
        }
    }

    public bool IsSignUpModalVisible()
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

            var modal = wait.Until(driver =>
            {
                try
                {
                    var modalElement = driver.FindElement(By.CssSelector("#myModal2"));
                    var display = modalElement.GetCssValue("display");
                    var visibility = modalElement.GetCssValue("visibility");
                    var opacity = modalElement.GetCssValue("opacity");

                    return display != "none" && visibility != "hidden" &&
                           (string.IsNullOrEmpty(opacity) || opacity != "0") &&
                           modalElement.Displayed
                        ? modalElement
                        : null;
                }
                catch
                {
                    return null;
                }
            });

            if (modal == null) return false;

            Thread.Sleep(1000);

            try
            {
                var nameField = modal.FindElement(By.CssSelector("input[name='Name']"));
                var emailField = modal.FindElement(By.CssSelector("input[name='Email']"));
                var passwordField = modal.FindElement(By.CssSelector("input[name='password']"));
                var confirmPasswordField = modal.FindElement(By.CssSelector("input[name='Confirm Password']"));
                var submitButton = modal.FindElement(By.CssSelector("input[type='submit'][value='Sign Up']"));

                return nameField != null && emailField != null && passwordField != null &&
                       confirmPasswordField != null && submitButton != null &&
                       nameField.Displayed && emailField.Displayed && passwordField.Displayed &&
                       confirmPasswordField.Displayed && submitButton.Displayed;
            }
            catch
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    public void FillSignUpForm(string name, string email, string password, string confirmPassword)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        var jsExecutor = (IJavaScriptExecutor)_driver;

        Thread.Sleep(2000);

        var modalBody = wait.Until(driver =>
        {
            try
            {
                var modal = driver.FindElement(By.CssSelector("#myModal2"));
                var body = modal.FindElement(By.CssSelector(".modal-body"));
                return body.Displayed ? body : null;
            }
            catch
            {
                return null;
            }
        });

        var nameField = wait.Until(driver =>
        {
            try
            {
                var element =
                    driver.FindElement(By.CssSelector("#myModal2 .styled-input input[type='text'][name='Name']"));
                return element.Displayed && element.Enabled ? element : null;
            }
            catch
            {
                try
                {
                    var altElement = driver.FindElement(By.CssSelector("#myModal2 input[name='Name']"));
                    return altElement.Displayed && altElement.Enabled ? altElement : null;
                }
                catch
                {
                    return null;
                }
            }
        });

        if (nameField != null)
        {
            jsExecutor.ExecuteScript("arguments[0].focus();", nameField);
            Thread.Sleep(300);
            jsExecutor.ExecuteScript("arguments[0].value = '';", nameField);
            nameField.SendKeys(name);
        }

        var emailField = wait.Until(driver =>
        {
            try
            {
                var element =
                    driver.FindElement(By.CssSelector("#myModal2 .styled-input input[type='email'][name='Email']"));
                return element.Displayed && element.Enabled ? element : null;
            }
            catch
            {
                try
                {
                    var altElement = driver.FindElement(By.CssSelector("#myModal2 input[name='Email']"));
                    return altElement.Displayed && altElement.Enabled ? altElement : null;
                }
                catch
                {
                    return null;
                }
            }
        });

        if (emailField != null)
        {
            jsExecutor.ExecuteScript("arguments[0].focus();", emailField);
            Thread.Sleep(300);
            jsExecutor.ExecuteScript("arguments[0].value = '';", emailField);
            emailField.SendKeys(email);
        }

        var passwordField = wait.Until(driver =>
        {
            try
            {
                var element =
                    driver.FindElement(
                        By.CssSelector("#myModal2 .styled-input input[type='password'][name='password']"));
                return element.Displayed && element.Enabled ? element : null;
            }
            catch
            {
                try
                {
                    var altElement = driver.FindElement(By.CssSelector("#myModal2 input[name='password']"));
                    return altElement.Displayed && altElement.Enabled ? altElement : null;
                }
                catch
                {
                    return null;
                }
            }
        });

        if (passwordField != null)
        {
            jsExecutor.ExecuteScript("arguments[0].focus();", passwordField);
            Thread.Sleep(300);
            jsExecutor.ExecuteScript("arguments[0].value = '';", passwordField);
            passwordField.SendKeys(password);
        }

        var confirmPasswordField = wait.Until(driver =>
        {
            try
            {
                var element =
                    driver.FindElement(
                        By.CssSelector("#myModal2 .styled-input input[type='password'][name='Confirm Password']"));
                return element.Displayed && element.Enabled ? element : null;
            }
            catch
            {
                try
                {
                    var altElement = driver.FindElement(By.CssSelector("#myModal2 input[name='Confirm Password']"));
                    return altElement.Displayed && altElement.Enabled ? altElement : null;
                }
                catch
                {
                    return null;
                }
            }
        });

        if (confirmPasswordField != null)
        {
            jsExecutor.ExecuteScript("arguments[0].focus();", confirmPasswordField);
            Thread.Sleep(300);
            jsExecutor.ExecuteScript("arguments[0].value = '';", confirmPasswordField);
            confirmPasswordField.SendKeys(confirmPassword);
        }
    }

    public void ClickSignUpSubmit()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var jsExecutor = (IJavaScriptExecutor)_driver;

        var submitButton = wait.Until(driver =>
        {
            try
            {
                var button = driver.FindElement(By.CssSelector("#myModal2 input[type='submit'][value='Sign Up']"));
                return button.Displayed && button.Enabled ? button : null;
            }
            catch
            {
                try
                {
                    var altButton = driver.FindElement(By.CssSelector("#myModal2 form input[type='submit']"));
                    return altButton.Displayed && altButton.Enabled ? altButton : null;
                }
                catch
                {
                    return null;
                }
            }
        });

        if (submitButton != null)
        {
            jsExecutor.ExecuteScript("arguments[0].click();", submitButton);
        }
        else
        {
            throw new NoSuchElementException("Sign Up submit button not found or not clickable");
        }
    }

    public void DebugModalContent()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        try
        {
            var modal = _driver.FindElement(By.CssSelector("#myModal2"));
            var jsExecutor = (IJavaScriptExecutor)_driver;
            var innerHTML = jsExecutor.ExecuteScript("return arguments[0].innerHTML;", modal);
            Console.WriteLine("Modal HTML Content:");
            Console.WriteLine(innerHTML);

            var inputs = modal.FindElements(By.TagName("input"));
            Console.WriteLine($"Found {inputs.Count} input elements:");
            foreach (var input in inputs)
            {
                var type = input.GetAttribute("type");
                var name = input.GetAttribute("name");
                var value = input.GetAttribute("value");
                var isDisplayed = input.Displayed;
                var isEnabled = input.Enabled;
                Console.WriteLine(
                    $"Input: type={type}, name={name}, value={value}, displayed={isDisplayed}, enabled={isEnabled}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error debugging modal: {ex.Message}");
        }
    }

    public bool IsRedirectedToHomePage()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.Url.Contains("adoring-pasteur-3ae17d.netlify.app/#"));
        return _driver.Url == "https://adoring-pasteur-3ae17d.netlify.app/#";
    }
}