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
            addWindowInstance.EditTextField.SendKeys("New Task");
            addWindowInstance.RemindSwitcher.Click();
            addWindowInstance.EditDateField.Click();
            addWindowInstance.DatePickerInstance.PickDate("07 July 2017");
            addWindowInstance.DatePickerInstance.ConfirmButton.Click();
            Assert.AreEqual("Today", addWindowInstance.EditDateField.Text);
        }
        [Test]
        public void Test_PastTimeSettings_ErrorMessage()
        {
            addWindowInstance.EditTimeField.Click();
            addWindowInstance.TimePickerInstance.ClockWidget.SendKeys("1200am");
            addWindowInstance.TimePickerInstance.ConfirmButton.Click();
            Assert.AreEqual("The date you entered is in the past.", addWindowInstance.InfoTextView.Text);
        }
        [Test]
        public void Test_PastTimeSettingsAddTask_EmptyList()
        {
            addWindowInstance.ApproveButton.Click();
            Assert.IsTrue(mainWindowInstance.EmptyView.Displayed);
        }
    }
}
