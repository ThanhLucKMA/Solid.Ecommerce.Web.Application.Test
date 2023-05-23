using Microsoft.AspNetCore.Identity.UI.Services;
using Solid.Ecommerce.Shared;
using System.Net;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;

namespace AspNetCoreSecurity.IdentitySamples.Classes
{
    public class SmtpEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject,
        string htmlMessage)
        {
            var smtpClient = new SmtpClient
            {
                //You Gmail ID (Do not use a personal Email ID, quite risky if compromised.) I always have a mail - id specifically for this purpose.
                //The Password.
                //Host or SMTP Server address – If you are going with Gmail, use smtp.gmail.com
                //Port – Use 465(SSL) or 587(TLS)
                Port = 465,
                Host = "smtp.gmail.com",
                DeliveryMethod =
                SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("your-email@example.com", "your-password"),
                EnableSsl = true

            };
            return smtpClient.SendMailAsync(
             "website@localhost", email,
             subject, htmlMessage);
        }
    }
    
}
