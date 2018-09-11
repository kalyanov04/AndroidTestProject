using NUnit.Framework;
using ToDoList;

namespace AndroidTestProject
{
    [TestFixture]
    class Test_PastDateTimeSetting:TestInitialize
    {
        MainWindow mainWindowInstance;
        EditTaskWindow addWindowInstance;
        [OneTimeSetUp]
        public void Test_Initialize()
        {
            mainWindowInstance = new MainWindow(driver);
            addWindowInstance = new EditTaskWindow(driver);
        }
        [Test]
        public void Test_PastDateSetting_TodaySet()
        {
            mainWindowInstance.AddButton.Click();
            addWindowInstance.SetTaskName("New Task")
                .SwitchReminder()
                .SetDate("07 July 2017");        
            Assert.AreEqual("Today", addWindowInstance.EditDateField.Text);
        }
        [Test]
        public void Test_PastTimeSettings_ErrorMessage()
        {
            addWindowInstance.SetTime("12:00am");
            Assert.AreEqual("The date you entered is in the past.", addWindowInstance.InfoTextView.Text);
        }
        [Test]
        public void Test_PastTimeSettingsAddTask_EmptyList()
        {
            addWindowInstance.ConfirmChanges();
            Assert.IsTrue(mainWindowInstance.EmptyView.Displayed);
        }
        [OneTimeTearDown]
        public void Test_Finalize()
        {
            driver.Quit();
        }
    }
}
