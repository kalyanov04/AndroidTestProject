using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace AndroidTestProject
{
    public class TestInitialize
    {
        protected AppiumDriver<AndroidElement> driver;
        DesiredCapabilities capabilities;
        public TestInitialize()
        {
            capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            capabilities.SetCapability(MobileCapabilityType.App, @"C:\Users\kalya_chd13fj\AndroidStudioProjects\Minimal-Todo-master\app\app-release.apk");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
        }  
    }
}
