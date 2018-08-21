using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace ToDoList
{
    public class AddWindow
    {
        AppiumDriver<AndroidElement> driver;
        public AddWindow(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        public AndroidElement ExitButton { get => driver.FindElementByAccessibilityId("Navigate up"); }
        public AndroidElement EditTextField { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/userToDoEditText"); }
        public AndroidElement ApproveButton { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/makeToDoFloatingActionButton"); }
        public AndroidElement RemindSwitcher { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/toDoHasDateSwitchCompat"); }
        public AndroidElement EditDateField { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/newTodoDateEditText"); }
        public AndroidElement EditTimeField { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/newTodoTimeEditText"); }
        public AndroidElement ReminderText { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/newToDoDateTimeReminderTextView"); }
        public bool IsOpened()
        {
            if (ExitButton.Enabled & EditTextField.Text.Equals("") & RemindSwitcher.GetAttribute("checked").Equals("false"))
                return true;
            else
                return false;
        }
        public bool IsReminderSwitchedOn()
        {
            if (RemindSwitcher.GetAttribute("checked").Equals("true") & EditDateField.Enabled & EditTimeField.Enabled)
                return true;
            else
                return false;
        }
    }
}
