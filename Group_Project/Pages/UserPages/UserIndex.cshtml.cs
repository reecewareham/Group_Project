using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group_Project.Pages.UserPages
{
    public class UserIndexModel : PageModel
    {
        public string EmailAddress;
        public const string SessionKeyName1 = "EmailAddress";

        public string Username;
        public const string SessionKeyName2 = "Username";

        public string SessionID;
        public const string SessionKeyName3 = "sessionID";
        public IActionResult OnGet()
        {
            EmailAddress = HttpContext.Session.GetString(SessionKeyName1);
            Username = HttpContext.Session.GetString(SessionKeyName2);
            SessionID = HttpContext.Session.GetString(SessionKeyName3);

            if (string.IsNullOrEmpty(EmailAddress) && string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(SessionID))
            {
                return RedirectToPage("/Login/Login");
            }
            return Page();
        }
    }
}
