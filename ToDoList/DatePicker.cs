using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ToDoList
{
    public class DatePicker
    {
        AppiumDriver<AndroidElement> driver;
        public DatePicker(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        private AndroidElement PickedYear { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/date_picker_year"); }
        private IList<AndroidElement> DatePickerYears { get => driver.FindElementsById("com.avjindersinghsekhon.minimaltodo:id/month_text_view"); }
        private AndroidElement PickedMonth { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/date_picker_month"); }
        private AndroidElement PickedDay { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/date_picker_day"); }
        private IList<AndroidElement> DateSelector { get => driver.FindElementsByXPath("//*[@class='android.widget.ListView']/*[@class='android.view.View']/*[@class='android.view.View']"); }
        public AndroidElement ConfirmButton { get => driver.FindElementById("com.avjindersinghsekhon.minimaltodo:id/ok"); }
        public void PickDate(string dateToPick)
        {
            string[] date = dateToPick.Split(' ');
            selectYear(date[2]);
            selectMonthAndDay(date[1], date[0]);
        }
        void selectYear(string yearToPick)
        {
            PickedYear.Click();
            bool yearFlag = true;
            while (yearFlag)
            {
                foreach (AndroidElement year in DatePickerYears)
                {
                    if (year.Text.Equals(yearToPick.Trim()))
                    {
                        year.Click();
                        yearFlag = false;
                        break;
                    }
                }
                if (yearFlag)
                {
                    if (yearToPick.CompareTo(DatePickerYears[0].Text) == -1)
                        calendarScroll(driver, DatePickerYears.First().Location, DatePickerYears.Last().Location, 600);
                    else
                        calendarScroll(driver, DatePickerYears.Last().Location, DatePickerYears.First().Location, 600);
                }
            }
        }
        void selectMonthAndDay(string month, string day)
        {
            List<string> months = new List<string> 
                { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            bool dateFlag = true;
            while (dateFlag)
            {
                foreach (AndroidElement date in DateSelector)
                {
                    if (date.GetAttribute("name").Contains(day + " " + month))
                    {
                        date.Click();
                        dateFlag = false;
                        break;
                    }
                }
                if (dateFlag)
                {
                    if (months.IndexOf(month)+1<DateTime.Now.Month)                  
                        driver.Swipe(DateSelector.First().Location.X, DateSelector.First().Location.Y, 
                            DateSelector.First().Location.X, DateSelector.First().Location.Y + 500, 400);                   
                    else
                        driver.Swipe(DateSelector.Last().Location.X, DateSelector.Last().Location.Y, 
                            DateSelector.Last().Location.X, DateSelector.Last().Location.Y - 500, 400);
                }
            }
        }
        static void calendarScroll(AppiumDriver<AndroidElement> driver, Point start, Point end, int duration)
        {
            driver.Swipe(start.X, start.Y, end.X, end.Y, duration);
            //int x = 700;
            //int starty = 1900;
            //int endy = 1110;
            //new TouchAction(driver).Press(x, starty).Wait(200).MoveTo(x, endy).Release().Perform();
        }
    }
}
