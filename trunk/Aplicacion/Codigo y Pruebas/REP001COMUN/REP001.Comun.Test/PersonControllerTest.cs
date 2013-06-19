using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using NUnit.Framework;
//using NUnit.Mocks;
using REP001.Comun.Web.MVC;
using REP001.Comun.BO;
using REP001.Comun.Web.MVC.Controllers;
using REP001.Comun.Service;

using Moq;
using REP001.Comun.Service.Interface;

namespace REP001.Comun.Test
{
    //[TestClass]
    [TestFixture]
    public class PersonControllerTest
    {
        //[TestMethod]
        [Test]
        public void TestMethodPersonControllerIndex()
        {
            string expected = "Index";
            PersonController personController = new PersonController();
            
            // act
            var result = personController.Index() as ViewResult;

            //assert
            Assert.AreEqual(expected, result.ViewName);
        }
        [Test]
        public void TesMethodPersonControllerIndexMoq() {
            string expected = "Index";
            var moq = new Mock<IPersonService>();

            PersonController controller = new PersonController(moq.Object);

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        
        }

        [Test]
        public void TestMethodPersonControllerDetailsMoq() 
        {
            string expected = "Details";
            var moq = new Mock<IPersonService>();
            PersonController controller = new PersonController(moq.Object);
            

            //act
            long id=2;
            moq.Setup(a => a.RetrievePersonById(id)).Returns(new Person { ID=2,Name="Daniela"});

            ViewResult result = controller.Details(id) as ViewResult;
            
            //assert
            Assert.NotNull(result);
            Assert.AreEqual(expected,result.ViewName);
        }

        [Test]
        public void TestMethodPersonControllerInsertMoq()
        {
            string expected = "Details";
            var moq = new Mock<IPersonService>();
            PersonController controller = new PersonController(moq.Object);


            //act
            long id = 2;
            //Person p = new Person { Name = "Daniela A", DateBird = DateTime.Now.AddYears(-20), LastName = "Avila", Email = "davila@email.com", ImgDir = "~/Content/Img" };
            Person p = new Person();
           
            RedirectToRouteResult result = controller.Create(p) as RedirectToRouteResult;

            //assert
            moq.Verify(a => a.Create(p));
        }
    }
}
