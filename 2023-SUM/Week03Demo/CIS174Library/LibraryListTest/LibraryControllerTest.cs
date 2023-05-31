using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryListTest
{
    [TestClass]
    public class LibraryControllerTest
    {
        public LibraryControllerTest() 
        {
            
        }

        // Step 7
        //
        //
        //[TestMethod]
        //public void LibraryController_Add()
        //{
        //    Mock<ILibraryRepository> repo = new Mock<ILibraryRepository>();
        //
        //    LibraryController ctrl = new LibraryController(repo.Object);
        //    var ret = ctrl.Add();
        //
        //    Assert.IsNotNull(ret);
        //    Assert.IsInstanceOfType(ret, typeof(ViewResult));
        //}
        //
        //[TestMethod]
        //public void LibraryController_Edit_Book10()
        //{
        //    Mock<ILibraryRepository> repo = new Mock<ILibraryRepository>();
        //    repo.Setup(x => x.Find(It.IsAny<int>())).Returns(new Book() {  BookId = 10, Name ="Test Book", Year = 2023});
        //
        //    LibraryController ctrl = new LibraryController(repo.Object);
        //    var ret = ctrl.Edit(1);
        //
        //    Assert.IsNotNull(ret);
        //    Assert.IsInstanceOfType(ret, typeof(ViewResult));
        //
        //    var vr = ret as ViewResult;
        //    var bk = vr.Model as Book;
        //
        //    Assert.AreEqual(-1, bk.Year);
        //}
        //
        //[TestMethod]
        //public void LibraryController_Edit_Book_Normal()
        //{
        //    Mock<ILibraryRepository> repo = new Mock<ILibraryRepository>();
        //    repo.Setup(x => x.Find(It.IsAny<int>())).Returns(new Book() { BookId = 11, Name = "Test Book", Year = 2023 });
        //
        //    LibraryController ctrl = new LibraryController(repo.Object);
        //    var ret = ctrl.Edit(1);
        //
        //    Assert.IsNotNull(ret);
        //    Assert.IsInstanceOfType(ret, typeof(ViewResult));
        //
        //    var vr = ret as ViewResult;
        //    var bk = vr.Model as Book;
        //
        //    Assert.AreEqual(2023, bk.Year);
        //}
    }
}
