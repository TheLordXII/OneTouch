using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Cucumber
{
    [Binding]
    public class TestSteps
    {
        public ChromeDriver driver = new ChromeDriver();

        [Given(@"the OneTouchNextGen blog site is open")]
        public void GivenTheOneTouchNextGenBlogSiteIsOpen()
        {
            driver.Url = "https://onetouch940978896.wordpress.com/2019/10/02/example-post/"; ;
        }
        
        [When(@"I click on the custom link labeled ""(.*)""")]
        public void WhenIClickOnTheCustomLinkLabeled(string p0)
        {
            IList<IWebElement> links = driver.FindElementsByTagName("li");
            links.First(element => element.Text == p0).Click();
        }
        
        [Then(@"the page title should contain ""(.*)""")]
        public void ThenThePageTitleShouldContain(string p0)
        {
            IList<IWebElement> schriften = driver.FindElementsByClassName("entry-title");
            schriften.First(element => element.Text.Contains(p0));
        }
    }
}
