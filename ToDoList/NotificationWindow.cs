using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;

namespace ToDoList
{
    public class NotificationWindow
    {
        AppiumDriver<AndroidElement> driver;
        public NotificationWindow(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        public AndroidElement DoneButton { get => driver.FindElementByAccessibilityId("Done"); }
        public AndroidElement TaskName { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/toDoReminderTextViewBody"); }
        public AndroidElement SnoozeDDL { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/todoReminderSnoozeSpinner"); }
        public IList<AndroidElement> DDLOoptions { get => driver.FindElementsByXPath("/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.ListView/android.widget.TextView"); }
        public AndroidElement RemoveButton { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/toDoReminderRemoveButton"); }
    }
}
