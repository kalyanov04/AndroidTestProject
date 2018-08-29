using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Threading;
using ToDoList;

namespace AndroidTestProject
{
    [TestFixture]
    public class Test_ManageNotification:TestInitialize
    {
        MainWindow mainWindowInstance;
        EditTaskWindow editTaskWindowInstance;
        NotificationWindow notificationWindowInstance;
        [OneTimeSetUp]
        public void Test_Initialize()
        {
            capabilities.SetCapability(MobileCapabilityType.NoReset, "true");
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            mainWindowInstance = new MainWindow(driver);
            editTaskWindowInstance = new EditTaskWindow(driver);
            notificationWindowInstance = new NotificationWindow(driver);
        }
        [Test]
        public void Test_Notification_NotificationIsInBar()
        {
            mainWindowInstance.AddButton.Click();
            editTaskWindowInstance.SetTaskName("Get the camera")
                .SwitchReminder();
            int minutes;
            for (; ; )
            {
                string timeToSet = "";
                string[] deviceDateTime = driver.DeviceTime.Split(' ');
                string[] deviceTime = deviceDateTime[3].Split(':');
                Int32.TryParse(deviceTime[0], out int hours);
                Int32.TryParse(deviceTime[1], out minutes);
                if (hours <= 12)
                {
                    if (minutes < 10)
                    {
                        timeToSet = hours.ToString() + ":0" + (minutes + 1).ToString();
                        timeToSet += "am";
                    }
                    else
                    {
                        timeToSet = hours.ToString() + ":" + (minutes + 1).ToString();
                        timeToSet += "am";
                    }
                }
                else
                {
                    if (minutes < 10)
                    {
                        timeToSet = (hours - 12).ToString() + ":0" + (minutes + 1).ToString();
                        timeToSet += "pm";
                    }
                    else
                    {
                        timeToSet = (hours - 12).ToString() + ':' + (minutes + 1).ToString();
                        timeToSet += "pm";
                    }
                }
                editTaskWindowInstance.SetTime(timeToSet);
                if (minutes + 1 == DateTime.Now.Minute)
                    continue;
                else
                {
                    editTaskWindowInstance.ConfirmChanges();
                    break;
                }
            }
            do
            {
                if (DateTime.Now.Minute == minutes + 1 && DateTime.Now.Second == 10)
                    break;
            } while (true);
            driver.Swipe(750, 1, 750, 750, 350);
            Assert.AreEqual("Get the camera", driver.FindElementById("android:id/status_bar_latest_event_content")
                .FindElementById("android:id/title").Text);
        }           
        [Test]
        public void Test_Snooze30Minutes_TaskSnoozed()
        {
            driver.FindElementById("android:id/status_bar_latest_event_content").Click();
            notificationWindowInstance.SnoozeDDL.Click();
            notificationWindowInstance.DDLOoptions[1].Click();
            string expected = "";
            string[] deviceDateTime = driver.DeviceTime.Split(' ');
            expected = expected + deviceDateTime[1] + " " + deviceDateTime[2] + ", 2018  ";
            string[] deviceTime = deviceDateTime[3].Split(':');
            int.TryParse(deviceTime[0], out int hours);
            int.TryParse(deviceTime[1], out int minutes);
            minutes += 30;
            if (minutes >= 60)
            {
                minutes = minutes % 60;
                hours += 1;
            }
            if (hours <= 12)
            {
                if (minutes < 10)
                {
                    expected = expected + hours.ToString() + ":0" + minutes.ToString();
                    expected += " AM";

                }
                else
                {
                    expected = expected + hours.ToString() + ':' + minutes.ToString();
                    expected += " AM";
                }
            }
            else
            {
                if (minutes < 10)
                {
                    expected = expected + (hours - 12).ToString() + ":0" + minutes.ToString();
                    expected += " PM";
                }
                else
                {
                    expected = expected + (hours - 12).ToString() + ':' + minutes.ToString();
                    expected += " PM";
                }
            }
            notificationWindowInstance.DoneButton.Click();          
            driver.LaunchApp();
            Assert.AreEqual(expected,mainWindowInstance.GetTaskTimes()[0]);
        }
        [OneTimeTearDown]
        public void Test_Finalize()
        {
            driver.Quit();
        }
    }
}
