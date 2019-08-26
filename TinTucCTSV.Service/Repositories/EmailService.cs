using System.Net.Mime;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Utility;

namespace TinTucCTSV.Service.Repositories
{
    public class EmailService : IEmail
    {
    private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _configuration["EmailSender:UserName"],
                    Password = _configuration["EmailSender:Password"]
                };

                client.Credentials = credential;
                client.Host = _configuration["EmailSender:Host"];
                client.Port = int.Parse(_configuration["EmailSender:Port"]);
                client.EnableSsl = _configuration.GetValue<bool>("EmailSender:EnableSSL");

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email,"To Name"));
                    emailMessage.CC.Add(new MailAddress(email,"CC"));
                    emailMessage.Bcc.Add(new MailAddress(email,"BCC"));
                    emailMessage.From = new MailAddress(_configuration["EmailSender:UserName"],_configuration["EmailSender:SenderName"]);
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    emailMessage.IsBodyHtml = true;
                    client.Send(emailMessage);
                }
            }
            await Task.CompletedTask;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("----------------------"+ex);
            }
        }
    }
}