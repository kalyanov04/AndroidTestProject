using NUnit.Framework;
using ToDoList;

namespace AndroidTestProject
{
    [TestFixture]
    public class Test_AddTaskWithReminder : TestInitialize
    {
        MainWindow mainWindowInstance;
        EditTaskWindow addWindowInstance;
        static object[] testData =
        {
            new object[]{"Sep 3, 2018  4:20 AM", "03 September 2018", "4:20am", "Get rect"},
            new object[]{"May 10, 2020  7:40 PM", "10 May 2020", "7:40pm",  "Meet Antonio"},
            new object[]{"Aug 2, 2030  12:00 AM", "02 August 2030", "12:00am", "Eat Pizza"}
        };
        [OneTimeSetUp]
        public void Test_Initialize()
        {
            mainWindowInstance = new MainWindow(driver);
            addWindowInstance = new EditTaskWindow(driver);
        }
        [Test, TestCaseSource("testData")]
        public void Test_AddTaskWithReminder_Success(string expected, string date, string time, string taskName)
        {
            mainWindowInstance.AddButton.Click();
            addWindowInstance.SetTaskName(taskName)
                .SwitchReminder()
                .SetDate(date)
                .SetTime(time)
                .ConfirmChanges();       
            Assert.AreEqual(expected, mainWindowInstance.GetTaskTimes()[mainWindowInstance.GetTaskTimes().Count - 1]);
        }
        [OneTimeTearDown]
        public void Test_Finalize()
        {
            while (mainWindowInstance.TaskItems.Count != 0)
            {
                var taskItem = mainWindowInstance.TaskItems[0];
                driver.Swipe(taskItem.Location.X, taskItem.Location.Y, taskItem.Location.X + 500, taskItem.Location.Y, 200);
                //wait.Until((driver) => MainWindow.IsOpened((AppiumDriver<AndroidElement>)driver));
            }
            driver.Quit();
        }
    }
}