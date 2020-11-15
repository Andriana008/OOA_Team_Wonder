using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace TaskManager.EmailService
{
    public class EmailManagerService : EmailManager.EmailManagerBase
    {
        private readonly ILogger<EmailManagerService> _logger;
        private readonly IEmailSender _emailSender;

        public EmailManagerService(ILogger<EmailManagerService> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public override Task<SendEmailReply> SendEmail(SendEmailRequest request, ServerCallContext context)
        {
            var status = Status.Ok;
            try
            {
                //_emailSender.SendEmailAsync(request.Email, request.Subject, request.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                status = Status.Error;
            }

            return Task.FromResult(new SendEmailReply { Status = status });
        }
    }
}
