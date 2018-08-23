using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ToDoList
{
    public class TimePicker
    {
        AppiumDriver<AndroidElement> driver;
        public TimePicker(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        public AndroidElement ClockWidget { get => driver.FindElementByXPath("//android.widget.FrameLayout"); }
        public AndroidElement ConfirmBUtton { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/ok"); }
    }
}