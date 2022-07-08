using System.Security.Claims;
using FinancialApp.Web.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Web.Controllers;

public class AuthController : Controller
{
    public class HomeController : Controller
    {
        private IBancoServices bancoserv;
        private IValidacionService valCuenta;
        public HomeController(IBancoServices bancoserv, IValidacionService valCuenta)
        {
            this.bancoserv = bancoserv;
            this.valCuenta = valCuenta;
        }

        public ActionResult Index()
        {
            ViewBag.Cuentas = bancoserv.getCuentas();
            return View();
        }
        [HttpGet]
        public ActionResult AddCuenta()
        {
            ViewBag.Cuenta = new Cuenta();
            return View();
        }

        [HttpPost]
        public ActionResult AddCuenta(Cuenta cuenta)
        {
            valCuenta.validarCuenta(cuenta, ModelState);
            if (ModelState.IsValid)
            {
                bancoserv.addCuenta(cuenta);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Cuenta = cuenta;
            return View(cuenta);
        }
        [HttpGet]
        public ActionResult AddIngreso()
        {
            ViewBag.Cuentas = bancoserv.getCuentas();
            return View();
        }
        [HttpPost]
        public ActionResult AddIngreso(Ingreso ingreso)
        {
            valCuenta.validarIngreso(ingreso, ModelState);
            if (ModelState.IsValid)
            {
                bancoserv.addIngreso(ingreso);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Cuentas = bancoserv.getCuentas();
            return View(ingreso);

        }
        [HttpGet]
        public ActionResult AddGasto()
        {
            ViewBag.Cuentas = bancoserv.getCuentas();
            return View();
        }
        [HttpPost]
        public ActionResult AddGasto(Gasto gasto)
        {
            var temp = bancoserv.GetCuentaById(gasto.Cuenta);
            var saldo = bancoserv.CalcularSaldo(temp);

            valCuenta.validarGasto(gasto, ModelState, saldo);
            if (ModelState.IsValid)
            {
                bancoserv.addGasto(gasto);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Cuentas = bancoserv.getCuentas();
            return View(gasto);
        }
        [HttpGet]
        public ActionResult VerSaldo(int Cuenta)
        {
            var temp = bancoserv.GetCuentaById(Cuenta);
            var saldo = bancoserv.CalcularSaldo(temp);

            ViewBag.Cuenta = temp;
            ViewBag.Saldo = saldo;
            return View();
        }


    }

}