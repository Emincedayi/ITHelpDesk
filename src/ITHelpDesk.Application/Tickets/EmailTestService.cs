using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;

namespace ITHelpDesk.Application.Tickets
{
    public class EmailTestService : ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        public EmailTestService(IEmailSender emailSender, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _configuration = configuration;
        }

        public async Task SendTestEmailAsync()
        {
            await TestSmtpConnectionAsync();
            // LogEmailSettings();
            //await _emailSender.SendAsync(
            //    to: "memincedayi@gmail.com",
            //    subject: "Test E-posta",
            //    body: "Bu bir test e-postasıdır. SMTP ayarları doğru çalışıyorsa bu mesajı almalısınız."
            //);
        }

        public void LogEmailSettings()
        {
            var smtpSettings = _configuration.GetSection("Emailing:Smtp");
            Console.WriteLine($"Host: {smtpSettings["Host"]}");
            Console.WriteLine($"Port: {smtpSettings["Port"]}");
            Console.WriteLine($"UserName: {smtpSettings["UserName"]}");
            Console.WriteLine($"Password: {smtpSettings["Password"]}");
            Console.WriteLine($"EnableSsl: {smtpSettings["EnableSsl"]}");
            Console.WriteLine($"UseDefaultCredentials: {smtpSettings["UseDefaultCredentials"]}");
        }

        public async Task TestSmtpConnectionAsync()
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("memincedayi@gmail.com", "nomvzbikriufpsim")
                };
                var message = new MailMessage
                {
                    From = new MailAddress("memincedayi@gmail.com", "HelpDesk"),
                    Subject = "Test Email",
                    Body = "This is a test email sent directly via SmtpClient."
                };
                message.To.Add("memincedayi@gmail.com");
                await client.SendMailAsync(message);
                Console.WriteLine("SMTP Test: Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SMTP Test Error: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
        }
    }
}