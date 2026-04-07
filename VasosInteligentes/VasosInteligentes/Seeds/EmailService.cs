using System.Net.Mail;
using Mailkit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace VasosInteligentes.Seeds
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public async Task SendEmailAsync(string ToEmail, string subject, string message)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
                email.To.Add(MailboxAddress.Parse(ToEmail));
                email.Subject = subject;

                email.Body = new TextPart(TextFormat.Html) { Text = message};
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, MailKit.Security.SecureSocketOptions.StartLs);
                await smtp.AuthenticateAsync(_emailSettings.SmtpServer), _emailSettings.SmtpPort );
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch(Exception ex)
            {
                //logue o erro para diagnosticar depois
                Console.WriteLine($"Erro ao enviar email: {ex.Message}");
                //opcionalmente
            }
        }
    }//classe
}//namespace
