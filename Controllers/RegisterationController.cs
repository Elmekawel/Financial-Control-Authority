using MICLifePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;

namespace MICLifePortal.Controllers
{
    public class RegisterationController : Controller
    {

        private readonly ApplicationDbContext _context;

        public RegisterationController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User loguser)
        {
            if (ModelState.IsValid)
            {
                var obuser = _context.Users.FirstOrDefault(x => x.UserName == loguser.UserName && x.Password == loguser.Password);

                if (obuser != null)
                {
                    int roleID = obuser.RoleID;

                    if (roleID == 1)
                    {
                        HttpContext.Session.SetString("role", "Manager");
                        return RedirectToAction("Index", "Home");
                    }
                    else if (roleID == 2)
                    {
                        HttpContext.Session.SetString("role", "Admin");
                        return RedirectToAction("Index", "Home");
                    }
                    else if (roleID == 3)
                    {
                        HttpContext.Session.SetString("role", "User");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.SetString("role", "LessValidity");
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("role");

            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            ViewBag.RolesList = new SelectList(_context.Roles, "RoleID", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                //await SendRegistrationEmail(user.UserName, user.Password);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.RolesList = new SelectList(_context.Roles, "RoleID", "RoleName");
            return View(user);
        }

        //private async Task SendRegistrationEmail(string userName, string password)
        //{
        //    // Set up email configuration
        //    string smtpServer = "your-smtp-server.com";
        //    int smtpPort = 587;
        //    string smtpUsername = "your-smtp-username";
        //    string smtpPassword = "your-smtp-password";

        //    // Sender and recipient email addresses
        //    string senderEmail = "your-sender-email@example.com";
        //    string recipientEmail = "user@example.com"; // Use the user's actual email here

        //    // Create the email message
        //    string subject = "Welcome to Mohandes Life Portal";
        //    string body = $"Dear {userName},\n\nThank you for registering with MICLifePortal. Your credentials are as follows:\n\nUsername: {userName}\nPassword: {password}\n\nBest regards,\nThe MICLifePortal Team";

        //    using (var client = new SmtpClient(smtpServer, smtpPort))
        //    {
        //        client.UseDefaultCredentials = false;
        //        client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
        //        client.EnableSsl = true;

        //        var message = new MailMessage(senderEmail, recipientEmail, subject, body);

        //        await client.SendMailAsync(message);
        //    }
        //}
    }
}
