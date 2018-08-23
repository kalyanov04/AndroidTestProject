using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using ToDoList;

namespace AndroidTestProject
{
    [TestFixture]
    class Test_NightMode:TestInitialize
    {
        MainWindow mainWindowInstance;
        SettingsWindow settingsWindowInstance;
        [OneTimeSetUp]
        public void Test_Initialize()
        {
            mainWindowInstance = new MainWindow(driver);
            settingsWindowInstance = new SettingsWindow(driver);
        }
        [Test]
        public void Test_EnableNightMode_BackgroundColorIsBlack()
        {
            mainWindowInstance.OptionsButton.Click();
            foreach (var item in mainWindowInstance.Options)
            {
                try
                {
                    if (item.Text.Equals("Settings"))
                    {
                        item.Click();
                        break;
                    }
                }
                catch (NoSuchElementException) { }
            }
            settingsWindowInstance.NightModeCheckbox.Click();
            wait.Until((driver) => SettingsWindow.IsOpened((AndroidDriver<AndroidElement>)driver));
            bool actual = settingsWindowInstance.NightModeCheckbox.GetAttribute("checked").Equals("true");
            Assert.IsTrue(actual);
        }
        [OneTimeTearDown]
        public void Test_Finalize()
        {
            driver.Quit();
        }
    }
}
