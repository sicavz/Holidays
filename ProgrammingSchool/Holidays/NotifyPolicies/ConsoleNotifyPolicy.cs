using Holidays.Interfaces;
using Holidays.Notifiers;

namespace Holidays.NotifyPolicies
{
    public class ConsoleNotifyPolicy : INotifyPolicy
    {
        public INotifier CreateNotifier()
        {
            return new ConsoleNotifier();
        }
    }
}