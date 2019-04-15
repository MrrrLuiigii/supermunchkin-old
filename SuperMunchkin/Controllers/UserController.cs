using Logic.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using SuperMunchkin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SuperMunchkin.Controllers
{
    public class UserController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        private UserCollectionLogic userCollectionLogic = new UserCollectionLogic();

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (((ClaimsIdentity)User.Identity).Claims.Count() != 0)
            {
                return RedirectToAction("GameLobby", "Game");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                User user = userCollectionLogic.Login(uvm.Username, uvm.Password);

                if(user != null)
                {
                    user.Password = "";
                    var claims = new List<Claim>
                    {
                        new Claim("Person", JsonConvert.SerializeObject(user))
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToAction("GameLobby", "Game");
                }

                ViewBag.ErrorMessage = "Username and/or password are incorrect.";
                return View();
            }

            ViewBag.ErrorMessage = "Username and password are required.";
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterUserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                if(uvm.Password == uvm.PasswordCheck)
                {
                    User user = new User(uvm.Username, uvm.Password, uvm.Email);
                    
                    if (userCollectionLogic.AddUser(user))
                    {
                        return RedirectToAction("Login");
                        
                    }

                    ViewBag.ErrorMessage = "This username and/or email has already been taken.";
                    return View();
                }
            }

            ViewBag.ErrorMessage = "All fields have to be filled in correctly.";
            return View();
        }
    }
}