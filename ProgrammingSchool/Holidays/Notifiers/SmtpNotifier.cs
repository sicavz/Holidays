using System;
using System.Net.Mail;
using Holidays.Interfaces;

namespace Holidays.Notifiers
{
    public class SmtpNotifier : IHolidayRequestConsumer
    {
        private readonly IRequestRenderer<MailMessage> requestRenderer;

        public SmtpNotifier(IRequestRenderer<MailMessage> requestRenderer)
        {
            this.requestRenderer = requestRenderer;
        }

        public void Consume(HolidayRequest request)
        {
            var mailMessage = requestRenderer.RenderRequest(request);

            Console.WriteLine("Email sent:");
            Console.WriteLine("\tFrom   \t:{0} <{1}>", mailMessage.From.DisplayName, mailMessage.From.Address);
            Console.WriteLine("\tTo     \t:{0} <{1}>", mailMessage.To[0].DisplayName, mailMessage.To[0].Address);
            Console.WriteLine("\tSubject\t:{0}", mailMessage.Subject);
            Console.WriteLine("\tBody   \t:\n{0}", mailMessage.Body);
            Console.WriteLine("----------------------------[EOM]");
            Console.WriteLine();
        }
    }
}