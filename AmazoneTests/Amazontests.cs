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

        [Test(Description = "Verify item in cart")]
        public void ItemInCart()
        {
            string productName_Find; //Title of found product
            string productName_Cart; //Title of product in cart
            Actions builder = new Actions(_driver);
            WebDriverWait wait_2sec = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            WebDriverWait wait_3sec = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));

            //////arrange+act

            //Navigate to Departments
            builder.MoveToElement(_driver.FindElement(By.Id("nav-link-shopall"))).Build().Perform();
            
            //wait for list and click on Toys&Games
            wait_2sec.Until<IWebElement>(d => d.FindElement(By.PartialLinkText("Toys & Games"))).Click();

            //wait for page to load and click on Age box "14 years and up"
            wait_2sec.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id=\"leftNav\"]/ul[1]/div/li[5]/span/span/div/label/span/span"))).Click();

            //enter price range and click GO
            _driver.FindElement(By.Id("low-price")).SendKeys("10");
            _driver.FindElement(By.Id("high-price")).SendKeys("150");
            _driver.FindElement(By.Id("high-price")).SendKeys(Keys.Tab);
            _driver.FindElement(By.Id("high-price")).SendKeys(Keys.Enter);
           

            //wait results to load and click on the first item found
            wait_3sec.Until<IWebElement>(d => d.FindElement(By.Id("search"))).FindElement(By.XPath("./div[1]/div[2]/div/span[3]/div[1]/div[1]")).Click(); 

            //read the product title
            productName_Find = _driver.FindElement(By.Id("productTitle")).Text;

            //if 4 or more qty available 
            if(_driver.FindElement(By.XPath("//*[@id=\"availability\"]/span")).Displayed == false) {

                if (_driver.FindElement(By.XPath("//*[@id=\"availability\"]/span")).Text != "Only 1 left in stock - order soon." &&
                    _driver.FindElement(By.XPath("//*[@id=\"availability\"]/span")).Text != "Only 2 left in stock - order soon." &&
                    _driver.FindElement(By.XPath("//*[@id=\"availability\"]/span")).Text != "Only 3 left in stock - order soon.")
                {
                    //set quantity to 4
                    _driver.FindElement(By.Id("quantity")).Click();
                    _driver.FindElement(By.Id("quantity")).FindElement(By.XPath("./option[4]")).Click();
                }
            }


            //else set 1 qty in cart
            //Add to cart
            _driver.FindElement(By.Id("add-to-cart-button")).Click();

            //Open the cart
            _driver.FindElement(By.Id("hlb-view-cart-announce")).Click();

            //Read product title from cart
            productName_Cart = _driver.FindElement(By.Id("activeCartViewForm")).FindElement(By.XPath("./div[2]/div/div[4]/div/div[1]/div/div/div[2]/ul/li[1]/span/a/span")).Text;


            //////Assert
            Assert.AreEqual(productName_Find, productName_Cart);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
