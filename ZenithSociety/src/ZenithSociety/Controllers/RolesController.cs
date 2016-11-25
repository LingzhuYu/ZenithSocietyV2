using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ZenithSociety.Models;
using Microsoft.AspNetCore.Authorization;

namespace ZenithSociety.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        RoleManager<IdentityRole> roleManager;
        UserManager<ApplicationUser> userManager;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context), null, null, null, null, null);
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context), null, null, null, null, null, null, null, null);

        }

        public IActionResult Index()
        {
            List<IdentityRole> roleList = _context.Roles.ToList();
            Dictionary<string, string> roles = new Dictionary<string, string>();

            foreach (IdentityRole role in roleList)
            {
                roles.Add(role.Id, role.Name);
            }

            ViewData["roles"] = roles;

            return View();
        }

        //Add role
        public async Task<IActionResult> Create()
        {
            var roleName = Request.Form["roleName"];

            if (!_context.Roles.Any(r => r.Name == roleName))
            {
                var role = new IdentityRole { Name = roleName };
                await roleManager.CreateAsync(role);
            }

            return RedirectToAction("Index");
        }

        //Delete role
        public async Task<IActionResult> Delete(string roleId)
        {
            if (_context.Roles.Any(r => r.Id == roleId))
            {
                var role = await roleManager.FindByIdAsync(roleId);

                //Cannot delete Admin and Member role
                if(!((role.Name.Equals("Admin")) || (role.Name.Equals("Member"))))
                {
                    await roleManager.DeleteAsync(role);
                }
               
            }

            return RedirectToAction("Index");
        }

        //Go to specific role page where you can add / remove users
        public async Task<IActionResult> Edit(string roleId)
        {
            if (_context.Roles.Any(r => r.Id == roleId))
            {
                var role = await roleManager.FindByIdAsync(roleId);

                //List<ApplicationUser> userList = _context.Users.Where(u => u.Roles == role).ToList();
                List <IdentityUserRole<String>> userList = _context.UserRoles.Where(u => u.RoleId == roleId).ToList();

                Dictionary<string,string> users = new Dictionary<string, string>();

                foreach (IdentityUserRole<String> user in userList)
                {
                    string userName = _context.Users.Where(i => i.Id == user.UserId).First().UserName;
                    users.Add(user.UserId, userName);
                }

                ViewData["users"] = users;
                ViewData["roleId"] = roleId;
                ViewData["roleName"] = role.Name;

                return View();

            }

            return RedirectToAction("Index");
        }

        //Add a user to a role
        public async Task<IActionResult> AddToRole()
        {
            var UserName = Request.Form["UserName"];
            var roleId = Request.Form["roleId"];
            var roleName = Request.Form["roleName"];

            if (_context.Roles.Any(r => r.Id == roleId))
            {
                if(_context.Users.Any(u => u.UserName == UserName))
                {
                    var userId = _context.Users.Where(u => u.UserName == UserName).First().Id;

                    if (!_context.UserRoles.Any(u => u.RoleId == roleId && u.UserId == userId))
                    {
                        var user = _context.Users.Where(u => u.UserName == UserName).First();

                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }

            return RedirectToAction("Edit", new { roleId = roleId });
        }

        //Delete a user from a role
        public async Task<IActionResult> DeleteFromRole(string userId, string roleId, string roleName)
        {
            var userName = _context.Users.Where(u => u.Id == userId).First().UserName;

            //Prevents a from being deleted from admin
            if ((roleName == "Admin") && (userName == "a"))
            {
                return RedirectToAction("Edit", new { roleId = roleId });
            }

            if (_context.Roles.Any(r => r.Id == roleId))
            {
                if (_context.Users.Any(u => u.Id == userId))
                {
                    var user = _context.Users.Where(u => u.Id == userId).First();

                    await userManager.RemoveFromRoleAsync(user, roleName);
                }
            }

            return RedirectToAction("Edit", new { roleId = roleId });
        }
    }
}