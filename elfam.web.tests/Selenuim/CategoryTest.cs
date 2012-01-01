using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
	[TestFixture]
	public class CategoryTest 
	{
		private ISelenium selenium;
		private StringBuilder verificationErrors;
	    private string url;
		
		[SetUp]
		public void SetupTest()
		{
		    url = "http://localhost:52994/";
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", url);
			selenium.Start();
			verificationErrors = new StringBuilder();
		}
		
		[TearDown]
		public void TeardownTest()
		{
			try
			{
				selenium.Stop();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}
			Assert.AreEqual("", verificationErrors.ToString());
		}
		
		[Test]
		public void TheUntitled()
		{
		    var categoryName = Guid.NewGuid().ToString();
            var childCategoryName = Guid.NewGuid().ToString();
		    

            selenium.Open("/");
            selenium.Type("email", "kpdpok@gmail.com");
            selenium.Type("password", "1");
            selenium.Click("//input[@value='Войти']");
            selenium.WaitForPageToLoad("30000");
			selenium.Click("link=добавить");
			selenium.WaitForPageToLoad("30000");
			selenium.Type("Name", categoryName);
			selenium.Click("//input[@value='Создать']");
			selenium.WaitForPageToLoad("30000");
			selenium.Click("link=список");
			selenium.WaitForPageToLoad("30000");
			try
			{
				Assert.IsTrue(selenium.IsTextPresent(categoryName));
			}
			catch (AssertionException e)
			{
				verificationErrors.Append(e.Message);
			}
			selenium.Click("link=добавить");
			selenium.WaitForPageToLoad("30000");
			selenium.Select("ParentId", "label=" + categoryName);
			selenium.Type("Name", childCategoryName);
			selenium.Click("//input[@value='Создать']");
			selenium.WaitForPageToLoad("30000");
			selenium.Click("//div[@id='content']/div/li/ul/li/a");
			selenium.WaitForPageToLoad("30000");
			selenium.Click("link=список");
			selenium.WaitForPageToLoad("30000");
			selenium.Click("//div[@id='content']/div/li/ul/li/a");
			selenium.WaitForPageToLoad("30000");
			try
			{
				Assert.AreEqual(categoryName, selenium.GetSelectedLabel("ParentId"));
                
			}
			catch (AssertionException e)
			{
				verificationErrors.Append(e.Message);
			}
		}
	}
}
