using NUnit.Framework;
using OpenQA.Selenium;
using ToDoList;

namespace AndroidTestProject
{
    [TestFixture]
    public class Test_AppViews:TestInitialize
    {
        MainWindow mainWindowInstance;
        EditTaskWindow addWindowInstance;
        SettingsWindow settingsWindowInstance;
        [OneTimeSetUp]
        public void Test_Initialize()
        {
            mainWindowInstance = new MainWindow(driver);
            addWindowInstance = new EditTaskWindow(driver);
            settingsWindowInstance = new SettingsWindow(driver);
        }
        [Test]
        public void Test1_OpenMainWindow_Opened()
        {                
            Assert.IsTrue(MainWindow.IsOpened(driver));
        }
        [Test]
        public void Test2_OpenSettingsWindow_Opened()
        {
            mainWindowInstance.SelectOption("Settings");
            Assert.IsTrue(SettingsWindow.IsOpened(driver));
        }
        [Test]
        public void Test3_OpenAddWindow_Opened()
        {
            settingsWindowInstance.BackButton.Click();
            mainWindowInstance.AddButton.Click();
            Assert.IsTrue(addWindowInstance.IsOpened());
        }
        [Test]
        public void Test4_AddWindowWithReminder_Opened()
        {
            addWindowInstance.RemindSwitcher.Click();
            Assert.IsTrue(addWindowInstance.IsReminderSwitchedOn());
        }
        [OneTimeTearDown]
        public void Test_CleanUp()
        {
            driver.Quit();
        }
    }
}
