using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTest
{
    [TestFixture]
    public class Amazontests
    {
        private IWebDriver _driver;
        
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Url = "https://www.amazon.com";
            _driver.Manage().Window.Maximize();

        }

        [Test(Description = "Verify item in chart")]
        public void ItemInChart()
        {
            string productName_Find;
            string productName_Cart;
            IWebElement departments = _driver.FindElement(By.Id("nav-link-shopall"));
            
            Actions builder = new Actions(_driver);
            builder.MoveToElement(departments).Build().Perform();

            WebDriverWait wait_2sec = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            
            IWebElement itemInList = wait_2sec.Until<IWebElement>(d => d.FindElement(By.PartialLinkText("Toys & Games")));

            itemInList.Click();

            IWebElement ageBox = wait_2sec.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id=\"leftNav\"]/ul[1]/div/li[5]/span/span/div/label/span/span")));

            ageBox.Click();

            IWebElement priceLow = wait_2sec.Until<IWebElement>(d => d.FindElement(By.Id("low-price")));
            priceLow.SendKeys("10");

            _driver.FindElement(By.Id("high-price")).SendKeys("150");
            _driver.FindElement(By.Id("a-autoid-1")).Click();

            //IWebElement itemInList = wait_2sec.Until<IWebElement>(d => d.FindElement(By.PartialLinkText("Toys & Games")));
            IWebElement resultsTable = wait_2sec.Until<IWebElement>(d => d.FindElement(By.Id("search")));
            resultsTable.FindElement(By.XPath("./div[1]/div[2]/div/span[3]/div[1]/div[1]")).Click();

            productName_Find = _driver.FindElement(By.Id("productTitle")).Text;
                
            IWebElement qty = _driver.FindElement(By.Id("quantity"));

            qty.Click();
            qty.FindElement(By.XPath("./option[4]")).Click();


            _driver.FindElement(By.Id("add-to-cart-button")).Click();

            _driver.FindElement(By.Id("hlb-view-cart-announce")).Click();

            IWebElement cartItems = _driver.FindElement(By.Id("activeCartViewForm"));

            IWebElement cartItemName = cartItems.FindElement(By.XPath("./div[2]/div/div[4]/div/div[1]/div/div/div[2]/ul/li[1]/span/a/span"));

             productName_Cart = cartItemName.Text;

            Assert.AreEqual(productName_Find, productName_Cart);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
