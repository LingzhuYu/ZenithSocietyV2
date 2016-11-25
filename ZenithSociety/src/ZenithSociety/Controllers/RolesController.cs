using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ZenithSociety.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        RoleManager<IdentityRole> roleManager;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context), null, null, null, null, null);
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

        public async Task<IActionResult> Delete(string roleId)
        {
            if (_context.Roles.Any(r => r.Id == roleId))
            {
                var role = await roleManager.FindByIdAsync(roleId);
                await roleManager.DeleteAsync(role);
            }

            return RedirectToAction("Index");
        }
    }
}