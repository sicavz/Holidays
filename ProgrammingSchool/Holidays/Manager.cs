using Holidays.Interfaces;

namespace Holidays
{
    public class Manager : Employee
    {
        public Manager(ICompany company, string name, string email)
            : base(company, name, email)
        {
        }

        public void ApproveHoliday(HolidayRequest request)
        {
            request.SetAccepted();
        }

        public void RejectHoliday(HolidayRequest request)
        {
            request.SetRejected();
        }
    }
}