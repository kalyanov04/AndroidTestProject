using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ToDoList
{
    public class EditTaskWindow
    {
        AppiumDriver<AndroidElement> driver;
        DatePicker datePickerInstance;
        TimePicker timePickerInstance;
        public EditTaskWindow(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        public AndroidElement ExitButton { get => driver.FindElementByAccessibilityId("Navigate up"); }
        public AndroidElement EditTextField { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/userToDoEditText"); }
        public AndroidElement ConfirmButton { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/makeToDoFloatingActionButton"); }
        public AndroidElement RemindSwitcher { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/toDoHasDateSwitchCompat"); }
        public AndroidElement EditDateField { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/newTodoDateEditText"); }
        public AndroidElement EditTimeField { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/newTodoTimeEditText"); }
        public AndroidElement InfoTextView { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/newToDoDateTimeReminderTextView"); }
        public DatePicker DatePickerInstance
        {
            get
            {
                if (datePickerInstance != null)
                    return datePickerInstance;
                else
                {
                    datePickerInstance = new DatePicker(driver);
                    return datePickerInstance;
                }
            }
        }

        public TimePicker TimePickerInstance
        {
            get
            {
                if (timePickerInstance != null)
                    return timePickerInstance;
                else
                {
                    timePickerInstance = new TimePicker(driver);
                    return timePickerInstance;
                }
            }
        }
        public EditTaskWindow SetTaskName(string taskName)
        {
            EditTextField.SendKeys(taskName);
            return this;
        }
        public EditTaskWindow SwitchReminder()
        {
            RemindSwitcher.Click();
            return this;
        }
        public EditTaskWindow SetDate(string date)
        {
            EditDateField.Click();
            DatePickerInstance.PickDate(date);
            DatePickerInstance.ConfirmButton.Click();
            return this;
        }
        public EditTaskWindow SetTime(string time)
        {
            EditTimeField.Click();
            TimePickerInstance.ClockWidget.SendKeys(time);
            TimePickerInstance.ConfirmButton.Click();
            return this;
        }
        public EditTaskWindow ConfirmChanges()
        {
            ConfirmButton.Click();
            return this;
        }
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
