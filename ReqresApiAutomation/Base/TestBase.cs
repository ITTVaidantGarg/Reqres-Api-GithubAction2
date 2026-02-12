using Allure.Net.Commons;
using NUnit.Framework;
using ReqresApiAutomation.Clients;

namespace ReqresApiAutomation.Base
{
    [SetUpFixture]
    public class TestBase
    {
        protected static ReqresClient client = null!;
        
        [OneTimeSetUp]
        public static void GlobalSetup()
        {
            client = new ReqresClient();
        }
    }
}