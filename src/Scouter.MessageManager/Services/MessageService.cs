using Microsoft.Extensions.Options;
using Scouter.MessageManager.Configuration;
using Scouter.MessageManager.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scouter.MessageManager.Services
{
    public class MessageService : IEmailSender, ISmsSender
    {
        private readonly IOptions<SendGridConfiguration> _configuration;

        public MessageService(IOptions<SendGridConfiguration> configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message, string htmlContent, string userName)
        {
            var from = new EmailAddress(_configuration.Value.Email, _configuration.Value.SenderName);
            var to = new EmailAddress(email, userName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, htmlContent);
            await SendConfiguredEmailAsync(msg);
        }

        private async Task SendConfiguredEmailAsync(SendGridMessage msg)
        {
            var client = new SendGridClient(_configuration.Value.Key);
            await client.SendEmailAsync(msg);
        }

        public Task SendSmsAsync(string number, string message)
        {
            throw new NotImplementedException();
        }
    }
}
