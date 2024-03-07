using COMP1640_WebDev.Services.Interfaces;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace COMP1640_WebDev.Services
{
    
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string SendEmail(string sendToEmail, string subject, string content)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(configuration["MAILKIT:EMAIL"]));
            email.To.Add(MailboxAddress.Parse(sendToEmail));

            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = content };

            var smtp = new SmtpClient();
            smtp.Connect(configuration["MAILKIT:HOST"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(configuration["MAILKIT:EMAIL"], configuration["MAILKIT:PASSWORD"]);

            smtp.Send(email);
            smtp.Disconnect(true);

            return sendToEmail;
        }
    }
}
