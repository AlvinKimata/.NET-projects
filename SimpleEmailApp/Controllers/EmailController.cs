using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("napoleon.dicki29@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("napoleon.dicki29@ethereal.email"));
            email.Subject = "Test email subject";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("napoleon.dicki29@ethereal.email", "BHRUaYEWCYJxR2dsNM");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
