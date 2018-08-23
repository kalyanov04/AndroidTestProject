using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Threading;
using ToDoList;

namespace AndroidTestProject
{
    [TestFixture]
    class Test_AddTask:TestInitialize
    {
        MainWindow mainWindowInstance;
        EditTaskWindow addWindowInstance;
        static object[] testData =
            {
                new object[]{"Do Exercise"},
                new object[]{"Walk a dog"},
                new object[]{"Test App"}
            };
        [OneTimeSetUp]
        public void Test_Initialize()
        {
            mainWindowInstance = new MainWindow(driver);
            addWindowInstance = new EditTaskWindow(driver);
        }
        [Test, TestCaseSource("testData")]
        public void Test1_AddTaskWithoutReminder_TaskAdded(string taskName)
        {
            mainWindowInstance.AddButton.Click();
            addWindowInstance.EditTextField.SendKeys(taskName);
            addWindowInstance.ApproveButton.Click();
            Assert.AreEqual(taskName, mainWindowInstance.GetTaskNames()[mainWindowInstance.GetTaskNames().Count - 1]);
        }
        [Test]
        public void Test2_DeleteTasks_TaskDeleted()
        {
            while(mainWindowInstance.TaskItems.Count!=0)
            {
                var taskItem = mainWindowInstance.TaskItems[0];
                driver.Swipe(taskItem.Location.X,taskItem.Location.Y, taskItem.Location.X + 500, taskItem.Location.Y, 200);
                //wait.Until((driver) => MainWindow.IsOpened((AppiumDriver<AndroidElement>)driver));
            }
            Assert.IsTrue(mainWindowInstance.EmptyView.Enabled);
        }
        [OneTimeTearDown]
        public void Test_Finalize()
        {
            driver.Quit();
        }
    }
}
