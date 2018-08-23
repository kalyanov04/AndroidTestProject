using NUnit.Framework;
using ToDoList;

namespace AndroidTestProject
{
    [TestFixture]
    class Test_ContactMeLink:TestInitialize
    {
        MainWindow mainWindowInstance;
        AboutWindow aboutWindowInstance;
        [OneTimeSetUp]
        public void Test_Initialize()
        {
            mainWindowInstance = new MainWindow(driver);
            mainWindowInstance.SelectOption("About");
            aboutWindowInstance = new AboutWindow(driver);
        }
        [Test]
        public void Test_ClickContactLink_GmailOpened()
        {
            aboutWindowInstance.ContactMe.Click();
            Assert.AreEqual("WEBVIEW_com.google.android.gm", driver.Context);
        }
    }
}
