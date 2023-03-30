using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.AdvancedServices
{
    public class MailingService : IMailingService
    {
        private readonly IConfiguration _configuration;

        public MailingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendCustom(string to, string subject, string html, string from = null)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _configuration["SmtpSettings:EmailFrom"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _configuration["SmtpSettings:SmtpHost"], 
                int.Parse(_configuration["SmtpSettings:SmtpPort"]),
                SecureSocketOptions.StartTls
            );

            smtp.Authenticate(
                _configuration["SmtpSettings:SmtpUser"], 
                _configuration["SmtpSettings:SmtpPass"]
            );

            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public void SendUserCredentials(User user, string username, string password)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["SmtpSettings:EmailFrom"]));
            email.To.Add(MailboxAddress.Parse(_configuration["SmtpSettings:TestEmail"]));
            email.Subject = "Micro & Soft Greens account created";
            email.Body = new TextPart(TextFormat.Html) { Text = GetEmailBody(username, password) };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _configuration["SmtpSettings:SmtpHost"], 
                int.Parse(_configuration["SmtpSettings:SmtpPort"]), 
                SecureSocketOptions.StartTls
            );

            smtp.Authenticate(
                _configuration["SmtpSettings:SmtpUser"], 
                _configuration["SmtpSettings:SmtpPass"]
            );

            smtp.Send(email);
            smtp.Disconnect(true);
        }

        private string GetEmailBody(string username, string password)
        {
            return $@"<h2>Thanks for making order</h2>
                      <p>Our administrator verified your order, and created account for you!</p>
                      <p>Use this credentials to log into your personal account:</p>
                      <hr>
                      <p><strong>USER NAME:</strong> <i>{username}</i></p>
                      <p><strong>PASSWORD:</strong> <i>{password}</i></p>
                      <hr>
                      <p>This data can be changed later</p>

                      <p><small>Thanks for ordering</small></p>
                      <p><small>Best wishes</small></p>
                      <p><small>MSG Team</small></p>
                      <p><small>{DateTime.Now}</small></p>";
        }
    }
}
