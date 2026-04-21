using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CIS174LibraryTest
{
    [TestClass]
    public class AccountControllerTest
    {
        Mock<UserManager<User>> _userManager;
        Mock<SignInManager<User>> _signInManager;
        private List<User> _users;

        public AccountControllerTest()
        {
            // NOTE: In MsTest this will get called on EVERY test method

            // Mock the UserManager
            var store = new Mock<IUserStore<User>>();
            _userManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
            _userManager.Object.UserValidators.Add(new UserValidator<User>());
            _userManager.Object.PasswordValidators.Add(new PasswordValidator<User>());

            // Generate some users
            _users = new List<User>();
            _users.Add(new User() { Id = "1", UserName = "TestUser" });

            _userManager.Setup(x => x.DeleteAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);
            _userManager.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<User, string>((x, y) => _users.Add(x));
            _userManager.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);

            // Mock the SignInManager
            _signInManager = new Mock<SignInManager<User>>(
                _userManager.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<User>>(), null, null, null, null);
        }

        [TestMethod]
        public void AccountController_Register()
        {
            AccountController ctrl = new AccountController(_userManager.Object, _signInManager.Object);
            var result = ctrl.Register();

            Assert.IsInstanceOfType(result, typeof(IActionResult));
        }

        [TestMethod]
        public void Register_HappyPath()
        {
            RegisterViewModel mdl = new RegisterViewModel();
            mdl.Username = "RegisterTest";
            mdl.Email = "Register@dmacc.edu";
            mdl.Password = "FancyPassword123!";

            AccountController ctrl = new AccountController(_userManager.Object, _signInManager.Object);
            var result = ctrl.Register(mdl).Result;

            // Assert we got a View back
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));

            // Test we redirect to Home\Index
            var rda = result as RedirectToActionResult;
            Assert.IsNotNull(rda);
            Assert.AreEqual("Index", rda.ActionName);
            Assert.AreEqual("Home", rda.ControllerName);

            // Ensure we added the user
            var usr = _users.FirstOrDefault(u => u.UserName == mdl.Username);
            Assert.IsNotNull(usr);
        }

        [TestMethod]
        public void Register_InvalidModelState()
        {
            RegisterViewModel mdl = new RegisterViewModel();
            mdl.Username = "RegisterTest";
            mdl.Email = "Register@dmacc.edu";
            mdl.Password = "FancyPassword123!";

            AccountController ctrl = new AccountController(_userManager.Object, _signInManager.Object);
            // Add a failed validation
            ctrl.ModelState.AddModelError("Username", "Invalid Username");
            var result = ctrl.Register(mdl).Result;

            // Assert we got a View back
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            // Test we return back to our view
            var vr = result as ViewResult;
            Assert.IsNotNull(vr);
        }

        [TestMethod]
        public void Register_FailedUserCreate()
        {
            // NOTE: This is WAY past what we learned but here is how you would test failures

            RegisterViewModel mdl = new RegisterViewModel();
            mdl.Username = "RegisterTest";
            mdl.Email = "Register@dmacc.edu";
            mdl.Password = "FancyPassword123!";


            // Create a userManager.CreateAsync that returns a failure
            var store = new Mock<IUserStore<User>>();
            Mock<UserManager<User>> badUserManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
            badUserManager.Object.UserValidators.Add(new UserValidator<User>());
            badUserManager.Object.PasswordValidators.Add(new PasswordValidator<User>());

            badUserManager.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed(new IdentityError() { Code = "Username", Description = "Invalid Username" }));

            AccountController ctrl = new AccountController(badUserManager.Object, _signInManager.Object);
            var result = ctrl.Register(mdl).Result;

            // Assert we got a View back
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            // Test we return back to our view
            var vr = result as ViewResult;
            Assert.IsNotNull(vr);

            // Check ModelState Errors
            Assert.AreEqual(1, ctrl.ModelState.ErrorCount);

        }
    }
}
