using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174LibraryTest
{
    [TestClass]
    public class SessionControllerTest
    {
        /* 
        public IActionResult Index()
        {
            int num = HttpContext.Session.GetInt32("num") ?? 0;
            num += 1;
            HttpContext.Session.SetInt32("num", num);

            var options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("username", "evan", options);

            return View();
        }
        */
        public delegate void TryGetValueCallback(string name, out byte[] value);
        [TestMethod]
        public void Index_Happy()
        {
            var session = new Mock<ISession>();

            byte[] outvalue;
            byte[] mockvalue = BitConverter.GetBytes(90);
            // little-endian
            Array.Reverse(mockvalue);

            session.Setup(x => x.TryGetValue(It.IsAny<string>(), out outvalue))
                .Returns(true)
                .Callback(new TryGetValueCallback((string name, out byte[] value) => value = mockvalue));
                //.Callback((string name, out byte[] value) => value = BitConverter.GetBytes(99));

            var mockHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            var mockResponse = new Mock<HttpResponse>();

            mockHttpContext.SetupGet(x => x.Session).Returns(session.Object);

            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.SetupGet(x => x.Response).Returns(mockResponse.Object);

            var controller = new SessionController();
            controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext
            {
                HttpContext = mockHttpContext.Object,
            };

            var result = controller.Index();


        }
    }

}
