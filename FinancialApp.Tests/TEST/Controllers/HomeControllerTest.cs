using Financial.Controllers;
using Financial.Models;
using Financial.servicios;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financial.Test.PruebasUnitarias
{
    [TestFixture]
    public class TestHomeController
    {
        [Test]
        public void GetIndexIsOk()
        {


            var IBancoServicesMock = new Mock<IBancoServices>();
            var IValidacionServiceMock = new Mock<IValidacionService>();

            var home = new HomeController(IBancoServicesMock.Object, IValidacionServiceMock.Object);

            var result = home.Index() as ViewResult;


            Assert.IsInstanceOf<ViewResult>(result);


        }
        [Test]
        public void GetAddCuentaTest()
        {

            var IBancoServicesMock = new Mock<IBancoServices>();
            var IValidacionServiceMock = new Mock<IValidacionService>();

            var home = new HomeController(IBancoServicesMock.Object, IValidacionServiceMock.Object);

            var result = home.AddCuenta() as ViewResult;


            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void AddCuentaErrorIsOkTest()
        {

            var IBancoServicesMock = new Mock<IBancoServices>();
            var IValidacionServiceMock = new Mock<IValidacionService>();

            var home = new HomeController(IBancoServicesMock.Object, IValidacionServiceMock.Object);
            home.ModelState.AddModelError("Error", "No Carga");
            var result = home.AddCuenta(new Cuenta()) as ViewResult;


            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void AddCuentaIsOkTest()
        {

            var IBancoServicesMock = new Mock<IBancoServices>();
            var IValidacionServiceMock = new Mock<IValidacionService>();

            var home = new HomeController(IBancoServicesMock.Object, IValidacionServiceMock.Object);

            var result = home.AddCuenta(new Cuenta());


            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
        [Test]
        public void GetAddIngresoTest()
        {

            var IBancoServicesMock = new Mock<IBancoServices>();
            var IValidacionServiceMock = new Mock<IValidacionService>();

            var home = new HomeController(IBancoServicesMock.Object, IValidacionServiceMock.Object);

            var result = home.AddIngreso() as ViewResult;


            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void AddIngresoErrorIsOkTest()
        {

            var IBancoServicesMock = new Mock<IBancoServices>();
            var IValidacionServiceMock = new Mock<IValidacionService>();

            var home = new HomeController(IBancoServicesMock.Object, IValidacionServiceMock.Object);
            home.ModelState.AddModelError("Error", "No Carga");
            var result = home.AddIngreso(new Ingreso()) as ViewResult;


            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void AddIngresoIsOkTest()
        {

            var IBancoServicesMock = new Mock<IBancoServices>();
            var IValidacionServiceMock = new Mock<IValidacionService>();

            var home = new HomeController(IBancoServicesMock.Object, IValidacionServiceMock.Object);

            var result = home.AddIngreso(new Ingreso());


            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
        [Test]
        public void GetAddGastoTest()
        {

            var IBancoServicesMock = new Mock<IBancoServices>();
            var IValidacionServiceMock = new Mock<IValidacionService>();

            var home = new HomeController(IBancoServicesMock.Object, IValidacionServiceMock.Object);

            var result = home.AddGasto() as ViewResult;


            Assert.IsInstanceOf<ViewResult>(result);
        }
       
}