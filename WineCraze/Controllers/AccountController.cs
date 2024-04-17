﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Account;
using WineCraze.Infrastructure.Data.Models;
using static WineCraze.Core.Constants.RoleConstants;
using static WineCraze.Infrastructure.Constants.CustomClaimsNames;

namespace WineCraze.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private IUserStore<ApplicationUser> userStore;

        public AccountController(SignInManager<ApplicationUser> _signInManager,
            UserManager<ApplicationUser> _userManager,
            IUserStore<ApplicationUser> _userStore)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            userStore = _userStore;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser applicationUser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,

            };

            await userManager.SetEmailAsync(applicationUser, model.Email);
            await userManager.SetUserNameAsync(applicationUser, model.Email);

            var result = await userManager.CreateAsync(applicationUser, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            await userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim(UserFullNameClaim, $"{applicationUser.FirstName} {applicationUser.LastName}"));
            await signInManager.SignInAsync(applicationUser, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await signInManager
                .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "There was an error while logging you in! Please try again later or contact an administrator.");

                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction("DashBoard", "Home", new { area = "Admin" });
            }
            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }
    }
}


// Summary - Handles user authentication and authorization, including login,
// registration, and managing user roles.