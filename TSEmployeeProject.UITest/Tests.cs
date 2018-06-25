using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TSEmployeeProject.UITest
{
	[TestFixture(Platform.Android)]
	//[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void LoginUserTest()
		{
            // Could not get unit test to connect to device

            app.EnterText("entUsername", "pravin.gordhan");
            app.EnterText("entPassword", "pravin.gordhan");

            app.Tap("btnLogin");

		}
	}
}
