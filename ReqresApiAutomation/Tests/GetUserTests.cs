using NUnit.Framework;
using System.Net;
using ReqresApiAutomation.Base;
using Allure.NUnit.Attributes;
                            
namespace ReqresApiAutomation.Tests
{
    // Quick read-only check -> Smoke suite
    [Allure.NUnit.AllureNUnit]
    [TestFixture, Category("SmokeSuite")]
    [AllureSuite("User Management")]
    [AllureFeature("Get User")]
    public class GetUserTests : TestBase
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureDescription("Verify that retrieving a user returns 200 OK status with valid response body")]
        [AllureTag("smoke", "get", "api")]
        public void GetUser_ShouldReturn200_AndValidBody()
        {
            var response = client.GetUser(2);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Does.Contain("email"));
            Assert.That(response.ContentType, Does.Contain("application/json"));
            Assert.That(response.ResponseStatus, Is.EqualTo(RestSharp.ResponseStatus.Completed));
        }
    }
}
