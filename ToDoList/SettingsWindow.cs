using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace ToDoList
{
    public class SettingsWindow
    {
        AppiumDriver<AndroidElement> driver;
        public SettingsWindow(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        public AndroidElement OptionsList { get => driver.FindElementById("android:id/list"); }
        public AndroidElement NightModeTitle { get => driver.FindElementById("android:id/title"); }
        public AndroidElement NightModeCheckbox { get => driver.FindElementById("android:id/checkbox"); }     
        public AndroidElement BackButton { get => driver.FindElementByAccessibilityId("Navigate up"); }
        public static bool IsOpened(AppiumDriver<AndroidElement> driver)
        {
            if (driver.FindElementById("android:id/title").Enabled &
                driver.FindElementByAccessibilityId("Navigate up").Enabled &
                driver.FindElementById("android:id/checkbox").Enabled)
                return true;
            else
                return false;
        }
    }
}
