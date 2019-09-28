using Microsoft.AspNetCore.Identity;
using ServiceSuite.Data.Contexts;
using ServiceSuite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSuite.Services
{
    public class UserService
    {
        private readonly MainContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(MainContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

            GenerateDefaultUser().GetAwaiter().GetResult();
        }



        private async Task GenerateDefaultUser()
        {
            var userCount = _context.Users.Select(x => 1).Count();

            if (userCount == 0)
            {
                var user = new ApplicationUser();

                await _userManager.CreateAsync(user, "Password123!");
            }
        }
    }
}