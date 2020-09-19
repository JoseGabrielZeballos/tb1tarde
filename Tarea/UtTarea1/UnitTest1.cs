using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tarea.Controllers;
using Tarea.Models;

namespace UtTarea1
{
    [TestClass]
    public class UnitTest1
    {
        //GET
        [TestMethod]
        public void TestGet()
        {
            //arrange
            ZeballossController controller = new ZeballossController();

            //act
            var result = controller.GetZeballos();

            //assert
            Assert.IsNotNull(result);
        }

        //POST
        [TestMethod]
        public void TestPost()
        {
            //arrange
            ZeballossController controller = new ZeballossController();
            Zeballos expected = new Zeballos()
            {
                ZeballosID = 10,
                FriendofZeballos = "Bob Smith",
                Place = CategoryType.Chocoloate,
                Email = "123@hotmail.com",
                Birthdate = DateTime.Today
            };

            //act
            var actionResult = controller.PostZeballos(expected);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Zeballos>;

            //assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(expected.FriendofZeballos, createdResult.Content.FriendofZeballos);
        }

        //PUT
        [TestMethod]
        public void TestPut()
        {
            //arrange
            ZeballossController controller = new ZeballossController();
            Zeballos expected = new Zeballos()
            {
                ZeballosID = 10,
                FriendofZeballos = "Bob Smith",
                Place = CategoryType.Chocoloate,
                Email = "123@hotmail.com",
                Birthdate = DateTime.Today
            };

            //act
            IHttpActionResult actionResult = controller.PostZeballos(expected);
            var result = controller.PutZeballos(expected.ZeballosID, expected) as StatusCodeResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        //DELETE
        [TestMethod]
        public void TestDelete()
        {
            //arrange
            ZeballossController controller = new ZeballossController();
            Zeballos expected = new Zeballos()
            {
                ZeballosID = 10,
                FriendofZeballos = "Bob Smith",
                Place = CategoryType.Chocoloate,
                Email = "123@hotmail.com",
                Birthdate = DateTime.Today
            };

            //act
            IHttpActionResult actionResult = controller.PostZeballos(expected);
            IHttpActionResult actionDelete = controller.DeleteZeballos(expected.ZeballosID);

            //assert
            Assert.IsInstanceOfType(actionDelete, typeof(OkNegotiatedContentResult<Zeballos>));

        }

    }
}

