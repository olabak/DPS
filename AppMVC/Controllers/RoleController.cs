using AppMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userMrg)
        {
            this.roleManager = roleManager;
            userManager = userMrg;
        }


        public IActionResult Index()
        {
            List<AppUser> list = new List<AppUser>();
            foreach (var user in userManager.Users)
            {
                var roles = userManager.GetRolesAsync(user).Result.ToList();
                list.Add(new AppUser
                {
                    Id = user.Id,
                    Email = user.Email,
                    RoleName = roles.FirstOrDefault()
                });
            }
            return View(list);
        }

        public IActionResult Edit(string id)
        {
            IdentityUser user = userManager.FindByIdAsync(id).Result;
            var roles = userManager.GetRolesAsync(user).Result.ToList();
            AppUser appuser = new AppUser()
            {
                Id = user.Id,
                Email = user.Email,
                RoleName = roles.FirstOrDefault()

            };
            ViewBag.Role = new SelectList(roleManager.Roles.Where(u => !u.Name.Contains("SuperAdmin")).ToList(), "Name", "Name");
            return View(appuser);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(AppUser appuser)
        {
            IdentityResult result;
            IdentityUser user = await userManager.FindByEmailAsync(appuser.Email);
            if (user != null)
            {
                result = await userManager.AddToRoleAsync(user, appuser.RoleName);

                var roles = userManager.GetRolesAsync(user).Result.ToList();
                var rolesToRemove = roles.Where(x => !x.Contains(appuser.RoleName)).ToList();

                if (result.Succeeded)
                {
                    foreach (var r in rolesToRemove)
                    {
                        await userManager.RemoveFromRoleAsync(user, r);
                    }
                }
            }

            return RedirectToAction("Index");

        }
    }
}

