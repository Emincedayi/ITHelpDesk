using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;

namespace ITHelpDesk.Application.Tickets
{
    public class EmailTestService : ITransientDependency
    {
        private readonly IEmailSender _emailSender;

        public EmailTestService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task SendTestEmailAsync()
        {
            await _emailSender.SendAsync(
                to: "memincedayi@gmail.com",
                subject: "Test E-posta",
                body: "Bu bir test e-postasıdır. SMTP ayarları doğru çalışıyorsa bu mesajı almalısınız."
            );
        }
    }
}