using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> HandleForm(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Correo de: {0} ({1})</p><p>Mensaje:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("winning.com@gmail.com"));  // replace with valid value 
                message.From = new MailAddress(contact.Email);  // replace with valid value
                message.Subject = contact.Name;
                message.Body = string.Format(body, contact.Name, contact.Email, contact.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "winning.com@gmail.com",  // replace with valid value
                        Password = "sanlorenzoARG84"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    //return RedirectToAction("Sent");
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }

    }
}
