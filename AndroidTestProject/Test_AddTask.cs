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
        [OneTimeSetUp]
        public void Test_Initialize()
        {
            mainWindowInstance = new MainWindow(driver);
            addWindowInstance = new AddWindow(driver);
        }
        [Test]
        public void Test1_AddTask_TaskAdded()
        {
            Thread.Sleep(1000);
            mainWindowInstance.AddButton.Click();
            addWindowInstance.EditTextField.SendKeys("Create Test");
            addWindowInstance.ApproveButton.Click();
            Assert.AreEqual("Create Test", mainWindowInstance.GetTaskNames()[0]);
        }
        [Test]
        public void Test2_DeleteTask_TaskDeleted()
        {
            foreach (AndroidElement item in mainWindowInstance.TaskItems)
            {
                driver.Swipe(item.Location.X, item.Location.Y, item.Location.X + 500, item.Location.Y, 200);
            }
            Assert.IsTrue(mainWindowInstance.EmptyView.Displayed);
        }
        [OneTimeTearDown]
        public void Test_Finalize()
        {
            driver.Quit();
        }
    }
}
