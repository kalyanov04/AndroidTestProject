using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList;

namespace AndroidTestProject
{
    [TestFixture]
    public class Test_SelectDate : TestInitialize
    {
        MainWindow mainWindowInstance;
        AddWindow addWindowInstance;
        static object[] testData =
        {
            new object[]{"Sep 3, 2018  7:00 AM", "03 September 2018", "Wash a car"},
            new object[]{"Apr 9, 2020  7:00 AM", "09 April 2020", "Meet Ramzan"},
            new object[]{"Aug 22, 2010  7:00 AM", "21 November 2010", "Get rect"}
        };
        [OneTimeSetUp]
        public void Test_Initialize()
        {
            mainWindowInstance = new MainWindow(driver);
            addWindowInstance = new AddWindow(driver);
        }
        [Test, TestCaseSource("testData")]
        public void Test_AddTaskWithReminder_Success(string expected, string date, string taskName)
        {
            mainWindowInstance.AddButton.Click();
            addWindowInstance.RemindSwitcher.Click();
            addWindowInstance.EditDateField.Click();
            addWindowInstance.DatePickerInstance.PickDate(date);
            addWindowInstance.DatePickerInstance.ConfirmButton.Click();
            addWindowInstance.EditTextField.SendKeys(taskName);
            addWindowInstance.ApproveButton.Click();
            Assert.AreEqual(expected, mainWindowInstance.GetTaskTimes()[mainWindowInstance.GetTaskTimes().Count - 1]);
        }
        [OneTimeTearDown]
        public void Test_Finalize()
        {
            while (mainWindowInstance.TaskItems.Count != 0)
            {
                var taskItem = mainWindowInstance.TaskItems[0];
                driver.Swipe(taskItem.Location.X, taskItem.Location.Y, taskItem.Location.X + 500, taskItem.Location.Y, 200);
                Thread.Sleep(1000);
            }
            driver.Quit();
        }
    }
}