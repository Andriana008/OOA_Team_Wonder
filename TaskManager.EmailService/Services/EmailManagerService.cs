using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace TaskManager.EmailService
{
    public class EmailManagerService : EmailManager.EmailManagerBase
    {
        private readonly ILogger<EmailManagerService> _logger;
        public EmailManagerService(ILogger<EmailManagerService> logger)
        {
            _logger = logger;
        }

        public override Task<SendEmailReply> SendEmail(SendEmailRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SendEmailReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
