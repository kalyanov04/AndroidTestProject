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
        public AndroidElement NightModeTitle { get => driver.FindElementById("android:id/title"); }
        public AndroidElement NightModeCheckbox { get => driver.FindElementById("android:id/checkbox"); }     
        public AndroidElement BackButton { get => driver.FindElementByAccessibilityId("Navigate up"); }
        public bool IsOpened()
        {
            if (NightModeTitle.Enabled & BackButton.Enabled & NightModeCheckbox.GetAttribute("checked").Equals("false"))
                return true;
            else
                return false;
        }
    }
}
