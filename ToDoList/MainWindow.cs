using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace ToDoList
{
    public class MainWindow
    {
        AppiumDriver<AndroidElement> driver;
        public MainWindow(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        public AndroidElement AppTitle { get => driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.view.ViewGroup/android.widget.LinearLayout[2]/android.view.ViewGroup/android.widget.TextView"); }
        public AndroidElement EmptyView { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/toDoEmptyView"); }
        public IList<AndroidElement> TaskItems { get => driver.FindElementsById("com.avjindersinghsekhon.minimaltodo:id/listItemLinearLayout"); }       
        public AndroidElement OptionsButton { get => driver.FindElementByAccessibilityId("More options"); }
        public IList<AndroidElement> Options { get => driver.FindElementsByXPath("/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.ListView/android.widget.LinearLayout/android.widget.RelativeLayout/android.widget.TextView"); }
        public AndroidElement AddButton { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/addToDoItemFAB"); }
        public bool IsOpened()
        {
            if (AppTitle.Text == "Minimal" & OptionsButton.Enabled & EmptyView.Enabled & AddButton.Enabled)
                return true;
            else
                return false;
        }
        public List<string> GetTaskNames()
        {
            List<string> TaskNames = new List<string>(TaskItems.Count);
            foreach (var item in TaskItems)
            {
                TaskNames.Add(item.FindElement(By.Id("com.avjindersinghsekhon.minimaltodo:id/toDoListItemTextview")).Text);
            }
            return TaskNames;
        }
    }
}
