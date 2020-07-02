using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomPlatform.ApplicationLogic.Services;
using ClassroomPlatform.VIewModels.Administrator;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomPlatform.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly EndUserService endUserService;

        public AdministratorController(UserManager<IdentityUser> userManager,
                                       RoleManager<IdentityRole> roleManager,
                                       EndUserService endUserService)
        {
            this.endUserService = endUserService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            try
            {
                var viewModel = new AdministratorViewModel
                {
                    Users = userManager.Users
                };
                return View(viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Remove(string userId)
        {
            try
            {
                var user = userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
                userManager.DeleteAsync(user).GetAwaiter().GetResult();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateAccountViewModel viewModel)
        {
            
            
            try
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email,
                };
                var createResult = await userManager.CreateAsync(user, viewModel.Password);
                if (createResult.Succeeded)
                {
                    var createdUser = await userManager.FindByEmailAsync(viewModel.Email);
                    endUserService.Add(user.Id, viewModel.FirstName, viewModel.LastName, viewModel.Email);
                    if (await roleManager.FindByNameAsync(viewModel.Role) == null)
                    {
                        var role = new IdentityRole(viewModel.Role);
                        await roleManager.CreateAsync(role);
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, viewModel.Role);
                    }
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}