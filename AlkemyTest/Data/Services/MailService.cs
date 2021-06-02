using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Services
{
    public class MailService
    {
        private IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMail(string ToEmail, string subject, string content)
        {
            var apiKey = _configuration["SendGridAPI"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("pedro.lucero@outlook.com", "Test Alkemy Disney");  
            var to = new EmailAddress(ToEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            var e = 0;

        }

    }
}
