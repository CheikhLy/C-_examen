using System.Security.Claims;
using ges_commande.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AccessController : Controller
{
    private readonly ApplicationDbContext _context;

        public AccessController(ApplicationDbContext context)
        {
            _context = context;
        }
    

[HttpPost]
  public async Task<IActionResult> Login(User modelLogin)
  {
    var users = await _context.users.ToListAsync();
    foreach (var user in users)
    {
      if (user.login == modelLogin.login && user.password == modelLogin.password)
      {
        List<Claim> claims = new List<Claim>(){
      new Claim(ClaimTypes.NameIdentifier, modelLogin.login),
      new Claim(ClaimTypes.Name, modelLogin.login),
      new Claim(ClaimTypes.Role, user.role.ToString()),
      new Claim(ClaimTypes.NameIdentifier, user.Nom.ToString()),

    };
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        AuthenticationProperties properties = new AuthenticationProperties()
        {
          AllowRefresh = true,
          // IsPersistent = modelLogin.KeepLoggedIn
        };

        await HttpContext.SignInAsync(
          CookieAuthenticationDefaults.AuthenticationScheme,
          new ClaimsPrincipal(claimsIdentity),
          properties
        );

        return RedirectToAction("Index", "Home");
      }
    }
    ViewData["ValidateMessage"] = "Utilisateur ou mot de passe incorrect";
    return View();
  }
  public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
}