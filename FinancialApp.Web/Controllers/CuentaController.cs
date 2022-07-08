using System.Security.Claims;
using FinancialApp.Web.DB;
using FinancialApp.Web.Models;
using FinancialApp.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Web.Controllers;

[Authorize]
public class CuentaController : Controller
{
    private readonly ITipoCuentaRepositorio _tipoCuentaRepositorio;
    private DbEntities _dbEntities;
    public CuentaController(ITipoCuentaRepositorio tipoCuentaRepositorio, DbEntities dbEntities)
    {
        _tipoCuentaRepositorio = tipoCuentaRepositorio;
        _dbEntities = dbEntities;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var user = GetLoggedUser();
        var cuentas = _dbEntities.Cuentas
            .Include(o => o.TipoCuenta)
            .Where(o => o.UsuarioId == user.Id).ToList();
        ViewBag.Total = cuentas.Any() ? cuentas.Sum(o => o.Monto) : 0; 
        return View(cuentas);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.TipoDeCuentas = _tipoCuentaRepositorio.ObtenerTodos();
        return View(new Cuenta());
    }

    [HttpPost]
    public IActionResult Create(Cuenta cuenta)
    {
        cuenta.UsuarioId = GetLoggedUser().Id;
        
        if (cuenta.TipoCuentaId > 6 || cuenta.TipoCuentaId < 1)
        {
            ModelState.AddModelError("TipoCuentaId", "Tipo de cuenta no exite");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.TipoDeCuentas = _dbEntities.TipoCuentas.ToList();
            return View("Create", cuenta);
        }

        
        _dbEntities.Cuentas.Add(cuenta);
        _dbEntities.SaveChanges();
        return RedirectToAction("Index");

    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var cuenta = _dbEntities.Cuentas.First(o => o.Id == id); // lambdas / LINQ
        ViewBag.TipoDeCuentas = _dbEntities.TipoCuentas.ToList();
        return View(cuenta);
    }
    
    [HttpPost]
    public IActionResult Edit(int id, Cuenta cuenta)
    {
        if (!ModelState.IsValid) {
            ViewBag.TipoDeCuentas = _dbEntities.TipoCuentas.ToList();
            return View("Edit", cuenta);
        }
        
        var cuentaDb = _dbEntities.Cuentas.First(o => o.Id == id);
        cuentaDb.Nombre = cuenta.Nombre;
        _dbEntities.SaveChanges();
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var cuentaDb = _dbEntities.Cuentas.First(o => o.Id == id);
        _dbEntities.Cuentas.Remove(cuentaDb);
        _dbEntities.SaveChanges();

        return RedirectToAction("Index");
    }

    private Usuario GetLoggedUser()
    {
        var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
        var username = claim.Value;
        return DbEntities.Usuarios.First(o => o.Username == username);

    }

    public class Cambio
    {
        public interface ITipoCambio
        {
            decimal GetTipoCambioSoles();
            decimal GetTipoCambioEuros();
        }
        private ITipoCambio _tipoCambio;
        public Cambio(ITipoCambio tipoCambio)
        {
            _tipoCambio = tipoCambio;
        }
        public decimal GetMontoTotalEnSoles(decimal montoDolares)
        {
            // var tipo = new TipoCambio().GetTipoCambioSoles()
            return montoDolares * _tipoCambio.GetTipoCambioSoles();
        }
    }

    
        public void Init()
        {
            var tipoDeCambio = new TipoCambio();
            var calculadora = new Cambio(tipoDeCambio);

            calculadora.GetMontoTotalEnSoles(100);
        }
    
}
}