using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using Solid.Ecommerce.Shared;
using System.Net;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;

namespace Solid.Ecommerce.WebApplication.Helper;

public class SmtpEmailSender : IEmailSender
{
    //public Task SendEmailAsync2(string email, string subject, string htmlMessage)
    //{
    //    string senderEmail = "thanhlucyth@gmail.com";
    //    string appPassword = "xfcjpolwyktgoyzud";            


    //    var smtpClient = new SmtpClient("smtp.gmail.com", 587)
    //    {
    //        UseDefaultCredentials = false,
    //        Credentials = new NetworkCredential(senderEmail, appPassword),
    //        EnableSsl = true,

    //    };

    //    var message = new MailMessage(senderEmail, email, subject, htmlMessage);
    //    message.IsBodyHtml = true;

    //   return  smtpClient.SendMailAsync(message);
    //    /*var smtpClient = new SmtpClient
    //    {
    //        //You Gmail ID (Do not use a personal Email ID, quite risky if compromised.) I always have a mail - id specifically for this purpose.
    //        //The Password.
    //        //Host or SMTP Server address – If you are going with Gmail, use smtp.gmail.com
    //        //Port – Use 465(SSL) or 587(TLS)
    //        Port = 587,
    //        Host = "smtp.gmail.com",
    //        DeliveryMethod =
    //        SmtpDeliveryMethod.Network,
    //        UseDefaultCredentials = false,
    //        Credentials = new NetworkCredential("thanhlucyth@gmail.com", "xfcjpolwyktgoyzu"),
    //        EnableSsl = true

    //    };
    //    return smtpClient.SendMailAsync(
    //     "website@localhost", email,
    //     subject, htmlMessage);*/
    //}


    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var mailSettings = new MailSettings
        {
            Mail = "yeuthuhoaiforever@gmail.com",
            DisplayName = "thanhluc",
            Password = "qvngxygmpmjfllzp",
            Host = "smtp.gmail.com",
            Port = 587
        };
        var email = new MimeMessage();
        email.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
        email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
      
        email.To.Add(MailboxAddress.Parse(to.Trim()));
                   

        email.Subject = subject;

        var builder = new BodyBuilder();
        builder.HtmlBody = body;
        email.Body = builder.ToMessageBody();

        // dùng SmtpClient của MailKit
        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        try
        {
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate("sendermail252@gmail.com", "aifxjfngziujmvsa");
            await smtp.SendAsync(email);
        }
        catch (Exception ex)
        {
            throw ex;
        }
           

        smtp.Disconnect(true);

        //logger.LogInformation("send mail to " + mailContent.To);
    }
}

