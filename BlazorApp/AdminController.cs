using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace BlazorApp
{
    [Route("/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Login([FromForm] string account)
        {
            if (account == "user")
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "user")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "auth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

            }
            if (account == "admin")
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "admin")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "auth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

            }
            return Redirect("/adminpage");
        }
    }
}
