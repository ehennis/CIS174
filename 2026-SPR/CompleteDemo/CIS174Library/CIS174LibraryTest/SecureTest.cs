using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CIS174LibraryTest
{
    [TestClass]
    public class SecureTest
    {
        [TestMethod]
        public void CheckAuthorization()
        {
            SecureController controller = new SecureController();
            var type = controller.GetType();
            var attribute = type.GetCustomAttribute(typeof(AuthorizeAttribute));
            Assert.IsNotNull(attribute);

            var logger = new Mock<ILogger<HomeController>>();
            var lrMock = new Mock<ILibraryRepository>();
            HomeController home = new HomeController(logger.Object, lrMock.Object);
            var ht = home.GetType();
            var att = ht.GetCustomAttribute(typeof(AuthorizeAttribute));
            Assert.IsNull(att);
        }
    }
}
