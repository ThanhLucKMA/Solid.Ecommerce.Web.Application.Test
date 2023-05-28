using System;
using MailKit.Security;
using MimeKit;
using Solid.Ecommerce.WebApplication.Models;

namespace Test_send_mail.Helper
{
    public interface ISendMailService
    {
        Task SendMailAction(MailContent mailContent);    
    }
    public class SendMail : ISendMailService
        {
            private readonly MailSettings mailSettings;
            // private readonly ILogger<SendMailService> logger;
            public SendMail()
            {
                mailSettings = new MailSettings
                {
                    Mail = "yeuthuhoaiforever@gmail.com",
                    DisplayName = "MailService",
                    Password = "qvngxygmpmjfllzp",
                    Host = "smtp.gmail.com",
                    Port = 587
                };
            }

            public async Task SendEmailAsync(string email , string subject, string htmlMessage)
            {
                await SendMailAction(
                    new MailContent()
                    {
                        To = email,
                        Subject = subject,
                        Body = htmlMessage
                    }
                );
            }

            public async Task SendMailAction(MailContent mailContent)
            {
                var email = new MimeMessage();
                email.Sender = new MailboxAddress(mailSettings.DisplayName,mailSettings.Mail);
                email.From.Add(new MailboxAddress(mailSettings.DisplayName,mailSettings.Mail));
                
                string[] multi = mailContent.To.Split(",");
                foreach (string receiver in multi)
                {
                    email.To.Add(MailboxAddress.Parse(receiver.Trim()));
                }
                if (!String.IsNullOrEmpty(mailContent.CC))
                {
                    string[] multiCC = mailContent.CC.Split(",");
                    foreach (string receiver in multiCC)
                    {
                        email.Cc.Add(MailboxAddress.Parse(receiver.Trim()));
                    }
                }

                email.Subject = mailContent.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = mailContent.Body;
                email.Body = builder.ToMessageBody();

                // dùng SmtpClient của MailKit
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                try
                {
                    smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                    smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                    await smtp.SendAsync(email);
                }
                catch (Exception ex)
                {
                        
                }
                smtp.Disconnect(true);
            }
        }
}
