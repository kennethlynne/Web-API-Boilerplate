using Boilerplate.Data;
using Boilerplate.Data.Interfaces.Services;
using Boilerplate.Tests.Mocks;
using Boilerplate.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Boilerplate.Tests.Controllers
{
    [TestClass]
    public class MessageControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IMessagingService service = new MockMessagingService();
            MessageController controller = new MessageController(service);
            
            var result = controller.GetMessage("Hello world");

            Assert.AreEqual("Hello world, your mock says hi!", result.Text);
        }
    }
}
