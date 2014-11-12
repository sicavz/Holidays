using Holidays.Interfaces;

namespace Holidays
{
    public class Company
    {
        public INotifyPolicy NotifyPolicy;

        public IHolidaysProcess GetHolidaysProcess()
        {
            return new HolidaysProcess
            {
                HREmailAddress = "hr@company.com",
                Notifier = NotifyPolicy.CreateNotifier()
            };
        }
    }
}