using System.Collections.Generic;
using System.Security.Claims;
using FinancialApp.Web.Controllers;
using FinancialApp.Web.Models;
using FinancialApp.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Controllers;

public class CuentaControllerTest
{
    [Test]
    public void CreateViewCase01()
    {
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        mockTipoRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<TipoCuenta>());

        var controller = new CuentaController(mockTipoRepositorio.Object, null);
        var view = controller.Create();

        Assert.IsNotNull(view);
    }
    [Test]
    public void CrearCuenta()
    {

        var usuario = new Usuario();

        usuario.Nombres = "Juan";
        usuario.Categoria = "frecuente";
        usuario.SaldoInicial = "1000";
        usuario.Moneda = "soles", "dolares";
        var userMock = new Mock<IUsuarioRepository>();
        userMock.Setup(o => o.ObtenerUsuarioLoggin(null)).Returns(usuario);



        var cuentaMoq = new Mock<ICuentaRepository>();
        cuentaMoq.Setup(o => o.AddCuenta(usuario, new Cuenta()));
        var cookMock = new Mock<ICookieAuthService>();



        var CuentaController = new CuentaController(userMock.Object, cookMock.Object, null, cuentaMoq.Object);

        var guardarCom = CuentaController.AddCuenta(new Cuenta());

        Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
    }



    [Test]
    public void IndexCase01()
    {

        var claimsPrincipal = new Mock<ClaimsPrincipal>();
        claimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() { new Claim(ClaimTypes.Name, "admin") });
        var context = new Mock<HttpContext>();
        context.Setup(o => o.User).Returns(claimsPrincipal.Object);
        var mock = new Mock<ITipoCuentaRepositorio>();
        var controller = new CuentaController(mock.Object, null);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = context.Object
        };
        var result = controller.Index();

        [Test]
       
        public void ListarDeCuenta()
        {
            var sess = new Mock<IUsuario>();
            var list = new Mock<IListarDeCuenta>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                usuario = "usuario"
                Cuenta = "cuenta",
                Fecha = "fecha",
                Descripcion = "descrip"
                Monto = " monto"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetListarDeCuenta(usuario)).Returns(new List<Cuenta>());

            var listaBi = new ListarDeCuenta(list.Object, sess.Object);

            var view = listaBi.Index() as ViewResult;

            Assert.IsInstanceOf<List<Cuenta>>(view.Model);
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void AddCuenta()
        {
            var sess = new Mock<IUsuario>();
            var list = new Mock<ICuenta>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                usuario = "usuario"
                Cuenta = "cuenta",
                Fecha = "fecha",
                Descripcion = "descrip"
                Monto = " monto"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetCuenta(usuario)).Returns(new List<Cuenta>());

            var listaBi = new ListarDeCuenta(list.Object, sess.Object);

            var view = listaBi.Add(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        
    }

}
}