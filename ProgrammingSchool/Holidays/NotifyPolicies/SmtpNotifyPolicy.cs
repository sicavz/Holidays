using Holidays.Interfaces;
using Holidays.Notifiers;

namespace Holidays.NotifyPolicies
{
    public class SmtpNotifyPolicy: INotifyPolicy
    {
        public INotifier CreateNotifier()
        {
            return new SmtpNotifier
            {
                SmtpServer = "...",
                SmtpServerPort = 25
            };
        }
    }
}