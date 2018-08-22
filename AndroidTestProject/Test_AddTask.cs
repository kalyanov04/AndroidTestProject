using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using System.Threading;
using ToDoList;

namespace AndroidTestProject
{
    [TestFixture]
    class Test_AddTask:TestInitialize
    {
        MainWindow mainWindowInstance;
        AddWindow addWindowInstance;
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
            addWindowInstance = new AddWindow(driver);
        }
        [Test, TestCaseSource("testData")]
        public void Test1_AddTaskWithoutReminder_TaskAdded(string taskName)
        {
            Thread.Sleep(1000);
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
                Thread.Sleep(1000);
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
